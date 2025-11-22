Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq

Public Class MenuDashboardForm
    Public Property SelectedTableID As Integer = 0
    Public Property OrderType As String = "Dine-In"
    Private cartItems As New List(Of CartItem)
    Private selectedCategoryId As Integer = 0

    Public Class CartItem
        Public Property ProductId As Integer
        Public Property ProductName As String
        Public Property Price As Decimal
        Public Property Quantity As Integer
        Public ReadOnly Property Subtotal As Decimal
            Get
                Return Quantity * Price
            End Get
        End Property
    End Class

    Private Sub MenuDashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OrderType = "Takeout" Then
            Me.Text = "GrillMate - Menu Dashboard (Takeout)"
        Else
            Me.Text = "GrillMate - Menu Dashboard (Table: " & SelectedTableID & ")"
        End If
        LoadCategories()
        LoadAllProducts()
        UpdateCartDisplay()
    End Sub

    Private Sub LoadCategories()
        flpCategories.Controls.Clear()

        ' Add "All" category control first
        CreateCategoryControl(0, "All")

        Try
            Dim query As String = "SELECT CategoryID, CategoryName FROM MenuCategories ORDER BY CategoryName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    CreateCategoryControl(reader("CategoryID"), reader("CategoryName").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateCategoryControl(categoryId As Integer, categoryName As String)
        Dim categoryControl As New CategoryControl()
        categoryControl.CategoryId = categoryId
        categoryControl.CategoryName = categoryName
        categoryControl.Size = New Size(140, 50)

        AddHandler categoryControl.CategorySelected, AddressOf CategoryControl_CategorySelected
        flpCategories.Controls.Add(categoryControl)
    End Sub

    Private Sub CategoryControl_CategorySelected(sender As Object, e As CategorySelectedEventArgs)
        selectedCategoryId = e.CategoryId

        ' Highlight selected category control
        HighlightSelectedCategory(DirectCast(sender, CategoryControl))

        ' Load products
        If selectedCategoryId = 0 Then
            LoadAllProducts()
        Else
            LoadProductsByCategory(selectedCategoryId)
        End If
    End Sub

    Private Sub HighlightSelectedCategory(selectedControl As CategoryControl)
        For Each ctrl As Control In flpCategories.Controls
            If TypeOf ctrl Is CategoryControl Then
                Dim catControl As CategoryControl = DirectCast(ctrl, CategoryControl)
                catControl.IsSelected = (catControl Is selectedControl)
            End If
        Next
    End Sub

    Private Sub LoadAllProducts()
        flpProducts.Controls.Clear()
        Try
            Dim query As String = "SELECT p.ProductID, p.ProductName, p.Description, p.Price, c.CategoryName " &
                                 "FROM Products p INNER JOIN MenuCategories c ON p.CategoryID = c.CategoryID " &
                                 "WHERE p.IsAvailable = 1 ORDER BY c.CategoryName, p.ProductName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    CreateProductCard(reader("ProductID"), reader("ProductName").ToString(),
                                     reader("Description").ToString(), reader("Price"), "")
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProductsByCategory(categoryId As Integer)
        flpProducts.Controls.Clear()
        Try
            Dim query As String = "SELECT p.ProductID, p.ProductName, p.Description, p.Price " &
                                 "FROM Products p WHERE p.CategoryID = @CategoryID AND p.IsAvailable = 1 ORDER BY p.ProductName"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@CategoryID", categoryId)
            }
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query, parameters)
                While reader.Read()
                    CreateProductCard(reader("ProductID"), reader("ProductName").ToString(),
                                     reader("Description").ToString(), reader("Price"), "")
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateProductCard(productId As Integer, productName As String, description As String, price As Decimal, categoryName As String)
        Dim productCard As New ProductCardControl()
        productCard.ProductId = productId
        productCard.ProductName = productName
        productCard.Description = description
        productCard.Price = price
        
        AddHandler productCard.AddToCartClicked, AddressOf ProductCard_AddToCartClicked
        
        flpProducts.Controls.Add(productCard)
    End Sub

    Private Sub ProductCard_AddToCartClicked(sender As Object, e As ProductCardEventArgs)
        Dim productId As Integer = e.ProductId

        Try
            Dim query As String = "SELECT ProductName, Price FROM Products WHERE ProductID = @ProductID"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@ProductID", productId)
            }
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query, parameters)
                If reader.Read() Then
                    Dim productName As String = reader("ProductName").ToString()
                    Dim price As Decimal = CDec(reader("Price"))
                    
                    Dim existingItem = cartItems.FirstOrDefault(Function(x) x.ProductId = productId)
                    If existingItem IsNot Nothing Then
                        existingItem.Quantity += 1
                    Else
                        cartItems.Add(New CartItem With {
                            .ProductId = productId,
                            .ProductName = productName,
                            .Price = price,
                            .Quantity = 1
                        })
                    End If
                    UpdateCartDisplay()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding item to cart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateCartDisplay()
        pnlCartItems.Controls.Clear()
        Dim subtotal As Decimal = 0
        Dim yPosition As Integer = 0

        For Each item In cartItems
            Dim cartControl As New CartItemControl()
            cartControl.CartItem = item
            cartControl.Location = New Point(0, yPosition)
            cartControl.Width = pnlCartItems.Width - 20

            ' Add event handlers
            AddHandler cartControl.QuantityChanged, AddressOf CartControl_QuantityChanged
            AddHandler cartControl.ItemRemoved, AddressOf CartControl_ItemRemoved

            pnlCartItems.Controls.Add(cartControl)
            yPosition += cartControl.Height + 2
            subtotal += item.Subtotal
        Next

        ' Calculate discount (20% if PWD/Senior discount is checked)
        Dim discount As Decimal = 0
        If chkPwdSeniorDiscount.Checked Then
            discount = subtotal * 0.2D
        End If

        ' Calculate amount after discount
        Dim amountAfterDiscount As Decimal = subtotal - discount

        ' Calculate tax VAT (12% of amount after discount, but 0% if PWD/Senior discount is applied)
        Dim tax As Decimal = 0
        If Not chkPwdSeniorDiscount.Checked Then
            tax = amountAfterDiscount * 0.12D
        End If

        ' Calculate final total
        Dim total As Decimal = amountAfterDiscount + tax

        ' Update display labels
        lblSubtotal.Text = "Subtotal: ₱" & subtotal.ToString("N2")
        
        If chkPwdSeniorDiscount.Checked Then
            lblDiscount.Text = "Discount (20%): -₱" & discount.ToString("N2")
            lblDiscount.Visible = True
            lblTax.Text = "Tax VAT: ₱0.00 (Exempt)"
        Else
            lblDiscount.Visible = False
            lblTax.Text = "Tax VAT (12%): ₱" & tax.ToString("N2")
        End If
        lblTotal.Text = "Total: ₱" & total.ToString("N2")
        btnCheckout.Enabled = cartItems.Count > 0
    End Sub

    Private Sub CartControl_QuantityChanged(sender As Object, e As QuantityChangedEventArgs)
        Dim item = cartItems.FirstOrDefault(Function(x) x.ProductId = e.ProductId)
        If item IsNot Nothing Then
            item.Quantity = e.NewQuantity
            UpdateCartDisplay()
        End If
    End Sub

    Private Sub CartControl_ItemRemoved(sender As Object, e As ItemRemovedEventArgs)
        cartItems.RemoveAll(Function(x) x.ProductId = e.ProductId)
        UpdateCartDisplay()
    End Sub

    Private Sub chkPwdSeniorDiscount_CheckedChanged(sender As Object, e As EventArgs) Handles chkPwdSeniorDiscount.CheckedChanged
        UpdateCartDisplay()
    End Sub

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If cartItems.Count = 0 Then
            MessageBox.Show("Your cart is empty!", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Calculate totals with discount and tax
        Dim subtotal As Decimal = cartItems.Sum(Function(x) x.Subtotal)
        Dim discount As Decimal = 0
        If chkPwdSeniorDiscount.Checked Then
            discount = subtotal * 0.2D
        End If
        Dim amountAfterDiscount As Decimal = subtotal - discount
        ' Tax is 0 if PWD/Senior discount is applied, otherwise 12%
        Dim tax As Decimal = 0
        If Not chkPwdSeniorDiscount.Checked Then
            tax = amountAfterDiscount * 0.12D
        End If
        Dim total As Decimal = amountAfterDiscount + tax

        ShowOrderSummaryConfirmation(total)
    End Sub

    Private Function ProcessOrder() As String
        Try
            ' Generate sequential order number
            Dim orderNumber As String = GetNextOrderNumber()

            ' Calculate totals with discount and tax
            Dim subtotal As Decimal = cartItems.Sum(Function(x) x.Subtotal)
            Dim discount As Decimal = 0
            If chkPwdSeniorDiscount.Checked Then
                discount = subtotal * 0.2D
            End If
            Dim amountAfterDiscount As Decimal = subtotal - discount
            Dim tax As Decimal = 0
            If Not chkPwdSeniorDiscount.Checked Then
                tax = amountAfterDiscount * 0.12D
            End If
            Dim totalAmount As Decimal = amountAfterDiscount + tax

            ' Insert order using helper method
            ' For takeout orders, TableID should be NULL
            Dim tableIdParam As SqlParameter
            If OrderType = "Takeout" Or SelectedTableID = 0 Then
                tableIdParam = DatabaseConnection.CreateParameter("@TableID", DBNull.Value)
            Else
                tableIdParam = DatabaseConnection.CreateParameter("@TableID", SelectedTableID)
            End If
            
            ' Insert order with discount and tax information
            Dim orderQuery As String = "INSERT INTO Orders (TableID, OrderNumber, OrderType, OrderStatus, Subtotal, Discount, Tax, TotalAmount, HasPwdDiscount) " &
                                      "VALUES (@TableID, @OrderNumber, @OrderType, @OrderStatus, @Subtotal, @Discount, @Tax, @TotalAmount, @HasPwdDiscount)"
            Dim orderParameters() As SqlParameter = {
                tableIdParam,
                DatabaseConnection.CreateParameter("@OrderNumber", orderNumber),
                DatabaseConnection.CreateParameter("@OrderType", OrderType),
                DatabaseConnection.CreateParameter("@OrderStatus", "Pending"),
                DatabaseConnection.CreateParameter("@Subtotal", subtotal),
                DatabaseConnection.CreateParameter("@Discount", discount),
                DatabaseConnection.CreateParameter("@Tax", tax),
                DatabaseConnection.CreateParameter("@TotalAmount", totalAmount),
                DatabaseConnection.CreateParameter("@HasPwdDiscount", chkPwdSeniorDiscount.Checked)
            }
            DatabaseConnection.ExecuteNonQuery(orderQuery, orderParameters)

            ' Get the OrderID using helper method
            Dim orderIdQuery As String = "SELECT OrderID FROM Orders WHERE OrderNumber = @OrderNumber"
            Dim orderIdParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderNumber", orderNumber)
            }
            Dim orderId As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(orderIdQuery, orderIdParameters))

            ' Insert order items using helper method
            For Each item As CartItem In cartItems
                Dim itemQuery As String = "INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)"
                Dim itemParameters() As SqlParameter = {
                    DatabaseConnection.CreateParameter("@OrderID", orderId),
                    DatabaseConnection.CreateParameter("@ProductID", item.ProductId),
                    DatabaseConnection.CreateParameter("@Quantity", item.Quantity),
                    DatabaseConnection.CreateParameter("@Price", item.Price)
                }
                DatabaseConnection.ExecuteNonQuery(itemQuery, itemParameters)
            Next

            ' Update table status to Occupied only for dine-in orders
            If OrderType = "Dine-In" And SelectedTableID > 0 Then
                Dim updateTableQuery As String = "UPDATE Tables SET Status = 'Occupied' WHERE TableID = @TableID"
                Dim updateTableParameters() As SqlParameter = {
                    DatabaseConnection.CreateParameter("@TableID", SelectedTableID)
                }
                DatabaseConnection.ExecuteNonQuery(updateTableQuery, updateTableParameters)
            End If

            ' Clear cart
            cartItems.Clear()
            UpdateCartDisplay()

            Return orderNumber
        Catch ex As Exception
            MessageBox.Show("Error processing order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "ERROR"
        End Try
    End Function

    Private Function GetNextOrderNumber() As String
        Try
            ' Get the highest order number from today using a more reliable approach
            Dim today As String = DateTime.Now.ToString("yyyyMMdd")
            Dim query As String = "SELECT ISNULL(MAX(CAST(RIGHT(OrderNumber, 3) AS INT)), 0) FROM Orders WHERE OrderNumber LIKE @Pattern"

            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Pattern", "ORD-" & today & "-%")
            }
            Dim lastNumber As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters))

            ' Generate next number
            Dim nextNumber As Integer = lastNumber + 1
            Return "ORD-" & today & "-" & nextNumber.ToString("000")
        Catch ex As Exception
            ' Fallback to timestamp if error
            Return "ORD-" & DateTime.Now.ToString("HHmmss")
        End Try
    End Function

    Private Sub ShowOrderSummaryConfirmation(total As Decimal)
        ' Calculate breakdown
        Dim subtotal As Decimal = cartItems.Sum(Function(x) x.Subtotal)
        Dim discount As Decimal = 0
        If chkPwdSeniorDiscount.Checked Then
            discount = subtotal * 0.2D
        End If
        Dim amountAfterDiscount As Decimal = subtotal - discount
        Dim tax As Decimal = 0
        If Not chkPwdSeniorDiscount.Checked Then
            tax = amountAfterDiscount * 0.12D
        End If
        
        ' Create and show OrderSummaryConfirmation as centered popup
        Dim summaryForm As New OrderSummaryConfirmation()
        summaryForm.SetOrderSummary(SelectedTableID, cartItems, total, subtotal, discount, tax, chkPwdSeniorDiscount.Checked)
        
        ' Handle events
        AddHandler summaryForm.OrderConfirmed, AddressOf OrderSummaryConfirmation_OrderConfirmed
        AddHandler summaryForm.OrderCancelled, AddressOf OrderSummaryConfirmation_OrderCancelled
        
        ' Show as centered dialog
        Dim popupForm As New Form()
        popupForm.Text = "Order Summary"
        popupForm.Size = New Size(520, 650)
        popupForm.StartPosition = FormStartPosition.CenterParent
        popupForm.FormBorderStyle = FormBorderStyle.FixedDialog
        popupForm.MaximizeBox = False
        popupForm.MinimizeBox = False
        popupForm.ShowInTaskbar = False
        popupForm.Controls.Add(summaryForm)
        summaryForm.Dock = DockStyle.Fill
        
        ' Show dialog
        popupForm.ShowDialog(Me)
        
        ' Clean up
        popupForm.Dispose()
    End Sub

    Private Sub OrderSummaryConfirmation_OrderConfirmed(sender As Object, e As EventArgs)
        ' Close the summary form
        Dim summaryForm As OrderSummaryConfirmation = DirectCast(sender, OrderSummaryConfirmation)
        Dim parentForm As Form = summaryForm.ParentForm
        parentForm.Close()
        
        ' Process the order and get order number
        Dim orderNumber As String = ProcessOrder()
        
        ' Show OrderConfirmationForm
        ShowOrderConfirmation(orderNumber)
    End Sub

    Private Sub OrderSummaryConfirmation_OrderCancelled(sender As Object, e As EventArgs)
        ' Close the summary form (menu form remains visible)
        Dim summaryForm As OrderSummaryConfirmation = DirectCast(sender, OrderSummaryConfirmation)
        Dim parentForm As Form = summaryForm.ParentForm
        parentForm.Close()
        
        ' No need to show menu form again as it was never hidden
    End Sub

    Private Sub ShowOrderConfirmation(orderNumber As String)
        ' Hide current form
        Me.Hide()
        
        ' Create and show OrderConfirmationForm
        Dim confirmationForm As New OrderConfirmationForm()
        confirmationForm.SetOrderNumber(orderNumber)
        
        ' Handle NewOrderRequested event
        AddHandler confirmationForm.NewOrderRequested, AddressOf OrderConfirmationForm_NewOrderRequested
        
        ' Show as dialog
        Dim parentForm As New Form()
        parentForm.WindowState = FormWindowState.Maximized
        parentForm.FormBorderStyle = FormBorderStyle.None
        parentForm.Controls.Add(confirmationForm)
        parentForm.Dock = DockStyle.Fill
        parentForm.ShowDialog()
        
        ' Clean up
        parentForm.Dispose()
    End Sub

    Private Sub OrderConfirmationForm_NewOrderRequested(sender As Object, e As EventArgs)
        ' Close the confirmation form and return to order type selection
        Dim confirmationForm As OrderConfirmationForm = DirectCast(sender, OrderConfirmationForm)
        Dim parentForm As Form = confirmationForm.ParentForm
        parentForm.Close()
        
        ' Return to DineInOrTakeout
        Dim dineInOrTakeoutForm As New DineInOrTakeout()
        dineInOrTakeoutForm.Show()
        Me.Close()
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        ' Ask for confirmation before canceling
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel this order? All items in your cart will be lost.",
            "Cancel Order",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            ' Clear cart
            cartItems.Clear()
            UpdateCartDisplay()

            ' Return to DineInOrTakeout
            Dim dineInOrTakeoutForm As New DineInOrTakeout()
            dineInOrTakeoutForm.Show()
            Me.Hide()
        End If
    End Sub
End Class