Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Public Partial Class UC_ManualOrderEntry
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Enum ManualOrderType
        Reservation
        Delivery
        DineIn
        Takeout
    End Enum

    ' Use MenuDashboardForm.CartItem for compatibility with CartItemControl
    Private cartItems As New List(Of MenuDashboardForm.CartItem)()
    Private selectedCategoryId As Integer = 0

    Private Sub UC_ManualOrderEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeOrderTypeSection()
        LoadTables()
        LoadCategories()
        LoadAllProducts()
        UpdateCartDisplay()
        radCash.Checked = True
    End Sub

    ' ---------------------------
    '  Order Type / Context
    ' ---------------------------

    Private Sub InitializeOrderTypeSection()
        ' Default to Dine-In
        If Not rdoReservation.Checked AndAlso Not rdoDelivery.Checked AndAlso
           Not rdoDineIn.Checked AndAlso Not rdoTakeout.Checked Then
            rdoDineIn.Checked = True
        End If
        UpdateContextVisibility()
    End Sub

    Private Sub OrderType_CheckedChanged(sender As Object, e As EventArgs) _
        Handles rdoReservation.CheckedChanged, rdoDelivery.CheckedChanged, rdoDineIn.CheckedChanged, rdoTakeout.CheckedChanged

        UpdateContextVisibility()
        UpdateCartDisplay()
    End Sub

    Private Sub UpdateContextVisibility()
        Dim orderType = GetSelectedOrderType()

        pnlReservationContext.Visible = (orderType = ManualOrderType.Reservation)
        pnlDeliveryNote.Visible = (orderType = ManualOrderType.Delivery)

        ' Table selection needed for dine-in and reservation
        lblTable.Visible = (orderType = ManualOrderType.DineIn OrElse orderType = ManualOrderType.Reservation)
        cmbTable.Visible = lblTable.Visible
    End Sub

    Private Function GetSelectedOrderType() As ManualOrderType
        If rdoReservation.Checked Then
            Return ManualOrderType.Reservation
        ElseIf rdoDelivery.Checked Then
            Return ManualOrderType.Delivery
        ElseIf rdoTakeout.Checked Then
            Return ManualOrderType.Takeout
        Else
            Return ManualOrderType.DineIn
        End If
    End Function

    Private Sub LoadTables()
        Try
            Dim dt As New DataTable()
            Dim query As String = "SELECT TableID, TableNumber FROM Tables ORDER BY TableNumber"
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using da As New SqlDataAdapter(query, conn)
                    da.Fill(dt)
                End Using
            End Using

            cmbTable.DataSource = dt
            cmbTable.DisplayMember = "TableNumber"
            cmbTable.ValueMember = "TableID"
            cmbTable.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading tables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------------------------
    '  Categories / Products
    ' ---------------------------

    Private Sub LoadCategories()
        flpCategories.Controls.Clear()

        CreateCategoryControl(0, "All")

        Try
            Dim query As String = "SELECT CategoryID, CategoryName FROM MenuCategories ORDER BY CategoryName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    CreateCategoryControl(CInt(reader("CategoryID")), reader("CategoryName").ToString())
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
            Dim query As String = "SELECT p.ProductID, p.ProductName, p.Description, p.Price " &
                                  "FROM Products p WHERE p.IsAvailable = 1 ORDER BY p.ProductName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    CreateProductCardControl(CInt(reader("ProductID")),
                                      reader("ProductName").ToString(),
                                      reader("Description").ToString(),
                                      CDec(reader("Price")))
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
                    CreateProductCardControl(CInt(reader("ProductID")),
                                      reader("ProductName").ToString(),
                                      reader("Description").ToString(),
                                      CDec(reader("Price")))
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateProductCardControl(productId As Integer, productName As String, description As String, price As Decimal)
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
                    Dim name As String = reader("ProductName").ToString()
                    Dim price As Decimal = CDec(reader("Price"))

                    Dim existing = cartItems.FirstOrDefault(Function(x) x.ProductId = productId)
                    If existing IsNot Nothing Then
                        existing.Quantity += 1
                    Else
                        cartItems.Add(New MenuDashboardForm.CartItem With {
                            .ProductId = productId,
                            .ProductName = name,
                            .Price = price,
                            .Quantity = 1
                        })
                    End If

                    UpdateCartDisplay()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------------------------
    '  Cart & Totals
    ' ---------------------------

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
        ' Subtotal at top
        lblSubtotal.Text = "Subtotal: ₱" & subtotal.ToString("N2")
        
        ' Show either Discount OR Tax (not both) below the checkbox
        If chkPwdSeniorDiscount.Checked Then
            lblDiscount.Text = "Discount (20%): -₱" & discount.ToString("N2")
            lblDiscount.Visible = True
            lblTax.Visible = False
        Else
            lblDiscount.Visible = False
            lblTax.Text = "Tax VAT (12%): ₱" & tax.ToString("N2")
            lblTax.Visible = True
        End If
        
        ' Total at bottom
        lblTotal.Text = "Total: ₱" & total.ToString("N2")
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

    ' ---------------------------
    '  Payment + Order Creation
    ' ---------------------------


    Private Function GetCurrentTotal() As Decimal
        Dim subtotal As Decimal = cartItems.Sum(Function(x) x.Subtotal)
        Dim discount As Decimal = If(chkPwdSeniorDiscount.Checked, subtotal * 0.2D, 0D)
        Dim amountAfterDiscount As Decimal = subtotal - discount
        Dim tax As Decimal = If(chkPwdSeniorDiscount.Checked, 0D, amountAfterDiscount * 0.12D)
        Return amountAfterDiscount + tax
    End Function

    Private Sub btnCreateOrderAndPay_Click(sender As Object, e As EventArgs) Handles btnCreateOrderAndPay.Click
        If cartItems.Count = 0 Then
            MessageBox.Show("Please add items to the cart.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not (radCash.Checked OrElse radGCash.Checked) Then
            MessageBox.Show("Please select a payment method.", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim orderType = GetSelectedOrderType()

        ' For dine-in & reservation, require a table
        If (orderType = ManualOrderType.DineIn OrElse orderType = ManualOrderType.Reservation) AndAlso cmbTable.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a table for this order.", "Table Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim totalAmount As Decimal = GetCurrentTotal()

        Try
            Dim orderNumber As String = GetNextOrderNumber()

            Dim subtotal As Decimal = cartItems.Sum(Function(x) x.Subtotal)
            Dim discount As Decimal = If(chkPwdSeniorDiscount.Checked, subtotal * 0.2D, 0D)
            Dim amountAfterDiscount As Decimal = subtotal - discount
            Dim tax As Decimal = If(chkPwdSeniorDiscount.Checked, 0D, amountAfterDiscount * 0.12D)

            Dim orderTypeString As String
            Dim tableId As Object = DBNull.Value

            Select Case orderType
                Case ManualOrderType.Delivery
                    orderTypeString = "Delivery"
                Case ManualOrderType.Takeout
                    orderTypeString = "Takeout"
                Case Else
                    orderTypeString = "Dine-In"
                    tableId = CInt(cmbTable.SelectedValue)
                End Select

            ' Insert order
            Dim orderQuery As String = "INSERT INTO Orders (TableID, OrderNumber, OrderType, OrderStatus, Subtotal, Discount, Tax, TotalAmount, HasPwdDiscount) " &
                                       "VALUES (@TableID, @OrderNumber, @OrderType, @OrderStatus, @Subtotal, @Discount, @Tax, @TotalAmount, @HasPwdDiscount)"
            Dim orderParams() As SqlParameter = {
                DatabaseConnection.CreateParameter("@TableID", tableId),
                DatabaseConnection.CreateParameter("@OrderNumber", orderNumber),
                DatabaseConnection.CreateParameter("@OrderType", orderTypeString),
                DatabaseConnection.CreateParameter("@OrderStatus", "Paid"),
                DatabaseConnection.CreateParameter("@Subtotal", subtotal),
                DatabaseConnection.CreateParameter("@Discount", discount),
                DatabaseConnection.CreateParameter("@Tax", tax),
                DatabaseConnection.CreateParameter("@TotalAmount", amountAfterDiscount + tax),
                DatabaseConnection.CreateParameter("@HasPwdDiscount", chkPwdSeniorDiscount.Checked)
            }
            DatabaseConnection.ExecuteNonQuery(orderQuery, orderParams)

            ' Get OrderID
            Dim orderIdQuery As String = "SELECT OrderID FROM Orders WHERE OrderNumber = @OrderNumber"
            Dim orderIdParams() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderNumber", orderNumber)
            }
            Dim orderId As Integer = CInt(DatabaseConnection.ExecuteScalar(orderIdQuery, orderIdParams))

            ' Insert order items
            For Each item In cartItems
                Dim itemQuery As String = "INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)"
                Dim itemParams() As SqlParameter = {
                    DatabaseConnection.CreateParameter("@OrderID", orderId),
                    DatabaseConnection.CreateParameter("@ProductID", item.ProductId),
                    DatabaseConnection.CreateParameter("@Quantity", item.Quantity),
                    DatabaseConnection.CreateParameter("@Price", item.Price)
                }
                DatabaseConnection.ExecuteNonQuery(itemQuery, itemParams)
            Next

            ' Update table status for dine-in/reservation
            If orderTypeString = "Dine-In" AndAlso Not IsDBNull(tableId) Then
                Dim updateTableQuery As String = "UPDATE Tables SET Status = 'Occupied' WHERE TableID = @TableID"
                Dim updateParams() As SqlParameter = {
                    DatabaseConnection.CreateParameter("@TableID", CInt(tableId))
                }
                DatabaseConnection.ExecuteNonQuery(updateTableQuery, updateParams)
            End If

            ' Insert payment
            Dim paymentMethod As String = If(radCash.Checked, "Cash", "GCash")
            Dim paymentQuery As String = "INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid) VALUES (@OrderID, @PaymentMethod, @AmountPaid)"
            Dim paymentParams() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderId),
                DatabaseConnection.CreateParameter("@PaymentMethod", paymentMethod),
                DatabaseConnection.CreateParameter("@AmountPaid", totalAmount)
            }
            DatabaseConnection.ExecuteNonQuery(paymentQuery, paymentParams)

            ' For delivery orders, create a delivery record and navigate
            If orderType = ManualOrderType.Delivery Then
                Dim deliveryId As Integer = CreateDeliveryRecord(orderId, paymentMethod)
                MessageBox.Show("Delivery order created and paid successfully." & Environment.NewLine &
                                "Order Number: " & orderNumber, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NavigateToDelivery(deliveryId)
            Else
                MessageBox.Show("Order created and paid successfully." & Environment.NewLine &
                                "Order Number: " & orderNumber, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Clear for next order
            cartItems.Clear()
            UpdateCartDisplay()

        Catch ex As Exception
            MessageBox.Show("Error creating order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateDeliveryRecord(orderId As Integer, paymentMethod As String) As Integer
        ' Create minimal delivery row; customer info will be filled in UC_Delivery
        Dim itemsSummary As String = $"{cartItems.Count} item(s) - Total ₱{GetCurrentTotal():N2}"
        Dim query As String =
            "INSERT INTO Deliveries (CustomerName, Address, ContactNumber, Items, PaymentMethod, DeliveryStatus, DeliveryDate) " &
            "VALUES ('', '', '', @Items, @PaymentMethod, 'Pending', @DeliveryDate); " &
            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Dim parameters() As SqlParameter = {
            DatabaseConnection.CreateParameter("@Items", itemsSummary),
            DatabaseConnection.CreateParameter("@PaymentMethod", paymentMethod),
            DatabaseConnection.CreateParameter("@DeliveryDate", DateTime.Now)
        }

        Dim result As Object = DatabaseConnection.ExecuteScalar(query, parameters)
        Return CInt(result)
    End Function

    Private Sub NavigateToDelivery(deliveryId As Integer)
        Dim staffForm As StaffMenuDashboard = TryCast(Me.FindForm(), StaffMenuDashboard)
        If staffForm Is Nothing Then
            Return
        End If

        Dim contentPanelField = staffForm.GetType().GetField("ContentPanel",
                                                              Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public)
        Dim contentPanel As Panel = Nothing
        If contentPanelField IsNot Nothing Then
            contentPanel = TryCast(contentPanelField.GetValue(staffForm), Panel)
        End If

        If contentPanel Is Nothing Then
            ' Fallback: try to find a panel named ContentPanel
            contentPanel = staffForm.Controls.OfType(Of Panel)().
                FirstOrDefault(Function(p) String.Equals(p.Name, "ContentPanel", StringComparison.OrdinalIgnoreCase))
        End If

        If contentPanel Is Nothing Then
            Return
        End If

        contentPanel.Controls.Clear()
        Dim deliveryControl As New UC_Delivery()
        deliveryControl.Dock = DockStyle.Fill
        contentPanel.Controls.Add(deliveryControl)

        ' After the control is loaded, ask it to select the created delivery
        'deliveryControl.ReloadAndSelectDelivery(deliveryId)
    End Sub

    Private Function GetNextOrderNumber() As String
        Try
            Dim today As String = DateTime.Now.ToString("yyyyMMdd")
            Dim query As String = "SELECT ISNULL(MAX(CAST(RIGHT(OrderNumber, 3) AS INT)), 0) FROM Orders WHERE OrderNumber LIKE @Pattern"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Pattern", "ORD-" & today & "-%")
            }
            Dim lastNumber As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters))
            Dim nextNumber As Integer = lastNumber + 1
            Return "ORD-" & today & "-" & nextNumber.ToString("000")
        Catch ex As Exception
            Return "ORD-" & DateTime.Now.ToString("HHmmss")
        End Try
    End Function

End Class
