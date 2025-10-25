Imports System.Data.SqlClient

Public Class UC_Billing
    Private currentOrder As OrderInfo?
    Private totalAmount As Decimal = 0

    ' Structure to hold order information
    Public Structure OrderInfo
        Public OrderID As Integer
        Public OrderNumber As String
        Public OrderDate As DateTime
        Public OrderType As String
        Public OrderStatus As String
        Public TableNumber As String
        Public Items As List(Of OrderItemInfo)
        Public TotalAmount As Decimal
    End Structure

    Public Structure OrderItemInfo
        Public ProductName As String
        Public Quantity As Integer
        Public Price As Decimal
        Public Subtotal As Decimal
    End Structure

    Private Sub UC_Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the billing control
        ClearForm()
        radCash.Checked = True
    End Sub

    Private Sub btnSearchOrder_Click(sender As Object, e As EventArgs) Handles btnSearchOrder.Click
        If String.IsNullOrWhiteSpace(txtOrderNumber.Text) Then
            MessageBox.Show("Please enter an order number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SearchOrder(txtOrderNumber.Text.Trim())
    End Sub

    Private Sub txtOrderNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrderNumber.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearchOrder_Click(sender, e)
        End If
    End Sub

    Private Sub radCash_CheckedChanged(sender As Object, e As EventArgs) Handles radCash.CheckedChanged
        If radCash.Checked Then
            ValidatePayment()
        End If
    End Sub

    Private Sub radGCash_CheckedChanged(sender As Object, e As EventArgs) Handles radGCash.CheckedChanged
        If radGCash.Checked Then
            ValidatePayment()
        End If
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        If Not currentOrder.HasValue Then
            MessageBox.Show("No order selected for payment.", "No Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ProcessPayment()
    End Sub

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If Not currentOrder.HasValue Then
            MessageBox.Show("No receipt to print.", "No Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' For now, just a message 
        MessageBox.Show("Receipt printing functionality will be implemented.", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SearchOrder(orderNumber As String)
        Try
            ' Clear previous search results
            ClearForm()

            ' Convert simple number to full order number format
            Dim today As String = DateTime.Now.ToString("yyyyMMdd")
            Dim fullOrderNumber As String = "ORD-" & today & "-" & orderNumber.PadLeft(3, "0"c)

            ' Search for order by order number using helper method
            Dim orderQuery As String = "SELECT o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, " &
                                     "t.TableNumber FROM Orders o " &
                                     "LEFT JOIN Tables t ON o.TableID = t.TableID " &
                                     "WHERE o.OrderNumber = @OrderNumber"

            Dim orderParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderNumber", fullOrderNumber)
            }

            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(orderQuery, orderParameters)
                If reader.Read() Then
                    Dim orderInfo As New OrderInfo()
                    orderInfo.OrderID = reader.GetInt32("OrderID")
                    orderInfo.OrderNumber = reader.GetString("OrderNumber")
                    orderInfo.OrderType = reader.GetString("OrderType")
                    orderInfo.OrderStatus = reader.GetString("OrderStatus")
                    orderInfo.OrderDate = reader.GetDateTime("CreatedAt")
                    orderInfo.TableNumber = If(reader.IsDBNull("TableNumber"), "Takeout", reader.GetString("TableNumber"))
                    orderInfo.Items = New List(Of OrderItemInfo)()

                    reader.Close()

                    ' Get order items using helper method
                    orderInfo.Items = GetOrderItems(orderInfo.OrderID)
                    orderInfo.TotalAmount = orderInfo.Items.Sum(Function(item) item.Subtotal)

                    ' Set current order
                    currentOrder = orderInfo

                    ' Display order details
                    DisplayOrderDetails()

                    ' Show success message with order info
                    'MessageBox.Show("Order found: " & orderInfo.OrderNumber & vbCrLf &
                    '"Items: " & orderInfo.Items.Count & vbCrLf &
                    '"Total: ₱" & orderInfo.TotalAmount.ToString("F2"),
                    '"Order Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Try alternative search - look for any order ending with the number
                    Dim alternativeQuery As String = "SELECT o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, " &
                                                   "t.TableNumber FROM Orders o " &
                                                   "LEFT JOIN Tables t ON o.TableID = t.TableID " &
                                                   "WHERE o.OrderNumber LIKE @AlternativePattern"

                    Dim altParameters() As SqlParameter = {
                        DatabaseConnection.CreateParameter("@AlternativePattern", "%-" & orderNumber.PadLeft(3, "0"c))
                    }

                    Using altReader As SqlDataReader = DatabaseConnection.ExecuteReader(alternativeQuery, altParameters)
                        If altReader.Read() Then
                            ' Found an order with alternative format
                            Dim orderInfo As New OrderInfo()
                            orderInfo.OrderID = altReader.GetInt32("OrderID")
                            orderInfo.OrderNumber = altReader.GetString("OrderNumber")
                            orderInfo.OrderType = altReader.GetString("OrderType")
                            orderInfo.OrderStatus = altReader.GetString("OrderStatus")
                            orderInfo.OrderDate = altReader.GetDateTime("CreatedAt")
                            orderInfo.TableNumber = If(altReader.IsDBNull("TableNumber"), "Takeout", altReader.GetString("TableNumber"))
                            orderInfo.Items = New List(Of OrderItemInfo)()

                            altReader.Close()

                            ' Get order items using helper method
                            orderInfo.Items = GetOrderItems(orderInfo.OrderID)
                            orderInfo.TotalAmount = orderInfo.Items.Sum(Function(item) item.Subtotal)

                            ' Set current order
                            currentOrder = orderInfo

                            ' Display order details
                            DisplayOrderDetails()

                            MessageBox.Show("Found order with alternative format: " & orderInfo.OrderNumber & vbCrLf &
                                          "Items: " & orderInfo.Items.Count & vbCrLf &
                                          "Total: ₱" & orderInfo.TotalAmount.ToString("F2"),
                                          "Order Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    End Using

                    ' Show more detailed error message
                    Dim errorMessage As String = "Order not found: " & fullOrderNumber & vbCrLf & vbCrLf
                    errorMessage &= "Please check:" & vbCrLf
                    errorMessage &= "1. The order number is correct" & vbCrLf
                    errorMessage &= "2. The order was created today" & vbCrLf
                    errorMessage &= "3. The order exists in the database" & vbCrLf & vbCrLf
                    errorMessage &= "Check the console output for available orders."

                    MessageBox.Show(errorMessage, "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ClearForm()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error searching for order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClearForm()
        End Try
    End Sub

    Private Function GetOrderItems(orderId As Integer) As List(Of OrderItemInfo)
        Dim items As New List(Of OrderItemInfo)()
        Dim total As Decimal = 0

        Dim itemsQuery As String = "SELECT p.ProductName, oi.Quantity, oi.Price, oi.Subtotal " &
                                  "FROM OrderItems oi " &
                                  "INNER JOIN Products p ON oi.ProductID = p.ProductID " &
                                  "WHERE oi.OrderID = @OrderID"

        Dim parameters() As SqlParameter = {
            DatabaseConnection.CreateParameter("@OrderID", orderId)
        }

        Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(itemsQuery, parameters)
            Dim itemCount As Integer = 0
            While reader.Read()
                Dim item As New OrderItemInfo()
                item.ProductName = reader.GetString("ProductName")
                item.Quantity = reader.GetInt32("Quantity")
                item.Price = reader.GetDecimal("Price")
                item.Subtotal = reader.GetDecimal("Subtotal")

                items.Add(item)
                total += item.Subtotal
            End While
        End Using

        Return items
    End Function

    Private Sub DisplayOrderDetails()
        If Not currentOrder.HasValue Then Return

        Dim orderInfo = currentOrder.Value

        ' Clear existing items
        lstOrderItems.Items.Clear()

        ' Add items to list view
        For Each item In orderInfo.Items
            Dim listItem As New ListViewItem(item.ProductName)
            listItem.SubItems.Add(item.Quantity.ToString())
            listItem.SubItems.Add("₱" & item.Price.ToString("F2"))
            listItem.SubItems.Add("₱" & item.Subtotal.ToString("F2"))
            lstOrderItems.Items.Add(listItem)
            Console.WriteLine("Added to ListView: " & item.ProductName & " x" & item.Quantity)
        Next

        ' Update total amount - use the order's total amount
        lblTotalAmount.Text = "Total: ₱" & orderInfo.TotalAmount.ToString("F2")
        Console.WriteLine("Updated total label: " & lblTotalAmount.Text)

        ' Update receipt preview
        GenerateReceiptPreview()

        ' Enable payment controls
        btnProcessPayment.Enabled = True

        ' Update payment validation
        ValidatePayment()
    End Sub

    Private Sub GenerateReceiptPreview()
        If Not currentOrder.HasValue Then Return

        Dim orderInfo = currentOrder.Value
        Dim receipt As String = ""
        receipt &= "=========================================" & vbCrLf
        receipt &= "            GRILL MATE POS              " & vbCrLf
        receipt &= "=========================================" & vbCrLf
        receipt &= "Order Number: " & orderInfo.OrderNumber & vbCrLf
        receipt &= "Date: " & orderInfo.OrderDate.ToString("MM/dd/yyyy HH:mm") & vbCrLf
        receipt &= "Type: " & orderInfo.OrderType & vbCrLf
        If orderInfo.OrderType = "Dine-In" Then
            receipt &= "Table: " & orderInfo.TableNumber & vbCrLf
        End If
        receipt &= "-----------------------------------------" & vbCrLf
        receipt &= "Items:" & vbCrLf

        For Each item In orderInfo.Items
            receipt &= item.ProductName.PadRight(20) & vbCrLf
            receipt &= ("  " & item.Quantity.ToString() & " x ₱" & item.Price.ToString("F2")).PadRight(15) & "₱" & item.Subtotal.ToString("F2") & vbCrLf
        Next

        receipt &= "-----------------------------------------" & vbCrLf
        receipt &= ("TOTAL:".PadRight(35) & "₱" & orderInfo.TotalAmount.ToString("F2")) & vbCrLf
        receipt &= "=========================================" & vbCrLf
        receipt &= "Thank you for your business!" & vbCrLf
        receipt &= "=========================================" & vbCrLf

        txtReceiptPreview.Text = receipt
    End Sub

    Private Sub ValidatePayment()
        If Not currentOrder.HasValue Then
            btnProcessPayment.Enabled = False
            Return
        End If

        ' Enable payment button if order is found and payment method is selected
        btnProcessPayment.Enabled = (radCash.Checked OrElse radGCash.Checked)
    End Sub

    Private Sub ProcessPayment()
        If Not currentOrder.HasValue Then Return

        Dim orderInfo = currentOrder.Value

        Try
            ' Update order status to Paid using helper method
            Dim updateOrderQuery As String = "UPDATE Orders SET OrderStatus = 'Paid' WHERE OrderID = @OrderID"
            Dim updateParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderInfo.OrderID)
            }
            DatabaseConnection.ExecuteNonQuery(updateOrderQuery, updateParameters)

            ' Insert payment record using helper method
            Dim paymentMethod As String = If(radCash.Checked, "Cash", "GCash")
            Dim amountPaid As Decimal = orderInfo.TotalAmount

            Dim insertPaymentQuery As String = "INSERT INTO Payments (OrderID, PaymentMethod, AmountPaid) VALUES (@OrderID, @PaymentMethod, @AmountPaid)"
            Dim paymentParameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderInfo.OrderID),
                DatabaseConnection.CreateParameter("@PaymentMethod", paymentMethod),
                DatabaseConnection.CreateParameter("@AmountPaid", amountPaid)
            }
            DatabaseConnection.ExecuteNonQuery(insertPaymentQuery, paymentParameters)

            ' Update table status if dine-in using helper method
            If orderInfo.OrderType = "Dine-In" AndAlso Not String.IsNullOrEmpty(orderInfo.TableNumber) Then
                Dim updateTableQuery As String = "UPDATE Tables SET Status = 'Vacant' WHERE TableNumber = @TableNumber"
                Dim tableParameters() As SqlParameter = {
                    DatabaseConnection.CreateParameter("@TableNumber", orderInfo.TableNumber)
                }
                DatabaseConnection.ExecuteNonQuery(updateTableQuery, tableParameters)
            End If

            MessageBox.Show("Payment processed successfully!" & vbCrLf & "Order Status: Paid", "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Enable print receipt button
            btnPrintReceipt.Enabled = True

            ' Clear form for next order
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error processing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearForm()
        currentOrder = Nothing
        totalAmount = 0
        txtOrderNumber.Clear()
        lstOrderItems.Items.Clear()
        lblTotalAmount.Text = "Total: ₱0.00"
        txtReceiptPreview.Clear()
        radCash.Checked = True
        btnProcessPayment.Enabled = False
        btnPrintReceipt.Enabled = False
    End Sub

    ' Connection string method removed - now using centralized DatabaseConnection class

End Class