﻿Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq

Public Class MenuDashboardForm
    Public Property SelectedTableID As Integer = 0
    Private cartItems As New List(Of CartItem)
    Private selectedCategoryId As Integer = 0
    
    ' Cart item class
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
        Me.Text = "GrillMate - Menu Dashboard (Table: " & SelectedTableID & ")"
        LoadCategories()
        LoadAllProducts()
        UpdateCartDisplay()
    End Sub

    Private Sub LoadCategories()
        flpCategories.Controls.Clear()
        
        ' Add "All" button first
        CreateCategoryButton(0, "All")
        
        Try
            Dim query As String = "SELECT CategoryID, CategoryName FROM MenuCategories ORDER BY CategoryName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    CreateCategoryButton(reader("CategoryID"), reader("CategoryName").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateCategoryButton(categoryId As Integer, categoryName As String)
        Dim btnCategory As New Button()
        btnCategory.Size = New Size(140, 50)
        btnCategory.Text = categoryName
        btnCategory.Font = New Font("Arial", 12, FontStyle.Bold)
        btnCategory.BackColor = Color.White
        btnCategory.ForeColor = Color.FromArgb(33, 37, 41)
        btnCategory.FlatStyle = FlatStyle.Flat
        btnCategory.FlatAppearance.BorderSize = 1
        btnCategory.FlatAppearance.BorderColor = Color.LightGray
        btnCategory.Cursor = Cursors.Hand
        btnCategory.Margin = New Padding(5)
        btnCategory.Tag = categoryId

        AddHandler btnCategory.Click, AddressOf CategoryButton_Click
        flpCategories.Controls.Add(btnCategory)
    End Sub

    Private Sub CategoryButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = DirectCast(sender, Button)
        selectedCategoryId = Convert.ToInt32(clickedButton.Tag)
        
        ' Highlight selected button
        HighlightSelectedCategory(clickedButton)
        
        ' Load products
        If selectedCategoryId = 0 Then
            LoadAllProducts()
        Else
            LoadProductsByCategory(selectedCategoryId)
        End If
    End Sub

    Private Sub HighlightSelectedCategory(selectedBtn As Button)
        For Each ctrl As Control In flpCategories.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                If btn Is selectedBtn Then
                    btn.BackColor = Color.FromArgb(255, 193, 7)
                    btn.ForeColor = Color.White
                Else
                    btn.BackColor = Color.White
                    btn.ForeColor = Color.FromArgb(33, 37, 41)
                End If
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
        Dim pnlCard As New Panel()
        pnlCard.Size = New Size(180, 220)
        pnlCard.BackColor = Color.White
        pnlCard.BorderStyle = BorderStyle.FixedSingle
        pnlCard.Margin = New Padding(10)
        pnlCard.Cursor = Cursors.Hand

        ' Product Image Placeholder
        Dim picProduct As New PictureBox()
        picProduct.Size = New Size(160, 100)
        picProduct.Location = New Point(10, 10)
        picProduct.BackColor = Color.LightGray
        picProduct.SizeMode = PictureBoxSizeMode.StretchImage
        picProduct.BorderStyle = BorderStyle.FixedSingle

        ' Product Name
        Dim lblName As New Label()
        lblName.Text = productName
        lblName.Font = New Font("Arial", 12, FontStyle.Bold)
        lblName.Location = New Point(10, 120)
        lblName.Size = New Size(160, 20)
        lblName.ForeColor = Color.FromArgb(33, 37, 41)

        ' Product Description
        Dim lblDescription As New Label()
        lblDescription.Text = If(description.Length > 40, description.Substring(0, 40) & "...", description)
        lblDescription.Font = New Font("Arial", 9)
        lblDescription.Location = New Point(10, 145)
        lblDescription.Size = New Size(160, 30)
        lblDescription.ForeColor = Color.Gray

        ' Product Price
        Dim lblPrice As New Label()
        lblPrice.Text = "₱" & price.ToString("N2")
        lblPrice.Font = New Font("Arial", 14, FontStyle.Bold)
        lblPrice.Location = New Point(10, 180)
        lblPrice.Size = New Size(80, 25)
        lblPrice.ForeColor = Color.FromArgb(40, 167, 69)

        ' Add to Cart Button
        Dim btnAdd As New Button()
        btnAdd.Text = "Add"
        btnAdd.Font = New Font("Arial", 10, FontStyle.Bold)
        btnAdd.Size = New Size(60, 30)
        btnAdd.Location = New Point(110, 180)
        btnAdd.BackColor = Color.FromArgb(40, 167, 69)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.Cursor = Cursors.Hand
        btnAdd.Tag = productId

        AddHandler btnAdd.Click, AddressOf AddToCart_Click
        AddHandler pnlCard.Click, AddressOf AddToCart_Click

        pnlCard.Controls.AddRange({picProduct, lblName, lblDescription, lblPrice, btnAdd})
        flpProducts.Controls.Add(pnlCard)
    End Sub

    Private Sub AddToCart_Click(sender As Object, e As EventArgs)
        Dim productId As Integer
        If TypeOf sender Is Button Then
            productId = Convert.ToInt32(CType(sender, Button).Tag)
        Else
            ' Find the button in the panel
            Dim panel As Panel = DirectCast(sender, Panel)
            Dim btnAdd As Button = DirectCast(panel.Controls.OfType(Of Button)().First(), Button)
            productId = Convert.ToInt32(btnAdd.Tag)
        End If

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
        Dim total As Decimal = 0
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
            total += item.Subtotal
        Next

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

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If cartItems.Count = 0 Then
            MessageBox.Show("Your cart is empty!", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Calculate total
        Dim total As Decimal = cartItems.Sum(Function(x) x.Subtotal)
        
        ' Show OrderSummaryConfirmation UserControl
        ShowOrderSummaryConfirmation(total)
    End Sub

    Private Function ProcessOrder() As String
        Try
            ' Generate sequential order number
            Dim orderNumber As String = GetNextOrderNumber()

            ' Insert order using helper method
            Dim orderQuery As String = "INSERT INTO Orders (TableID, OrderNumber, OrderType, OrderStatus) VALUES (@TableID, @OrderNumber, @OrderType, @OrderStatus)"
            Dim orderParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@TableID", SelectedTableID),
                DatabaseConnection.CreateParameter("@OrderNumber", orderNumber),
                DatabaseConnection.CreateParameter("@OrderType", "Dine-In"),
                DatabaseConnection.CreateParameter("@OrderStatus", "Pending")
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

            ' Update table status to Occupied using helper method
            Dim updateTableQuery As String = "UPDATE Tables SET Status = 'Occupied' WHERE TableID = @TableID"
            Dim updateTableParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@TableID", SelectedTableID)
            }
            DatabaseConnection.ExecuteNonQuery(updateTableQuery, updateTableParameters)

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
        ' Create and show OrderSummaryConfirmation as centered popup
        Dim summaryForm As New OrderSummaryConfirmation()
        summaryForm.SetOrderSummary(SelectedTableID, cartItems, total)
        
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
        ' Close the confirmation form and return to table selection
        Dim confirmationForm As OrderConfirmationForm = DirectCast(sender, OrderConfirmationForm)
        Dim parentForm As Form = confirmationForm.ParentForm
        parentForm.Close()
        
        ' Return to TableSelectionForm
        Dim tableForm As New TableSelectionForm()
        tableForm.Show()
        Me.Close()
    End Sub
End Class