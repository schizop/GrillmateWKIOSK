Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Linq

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
        Public Subtotal As Decimal
        Public Discount As Decimal
        Public Tax As Decimal
        Public TotalAmount As Decimal
        Public HasPwdDiscount As Boolean
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
        LoadRecentOrders()
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

        Try
            ' Generate PDF receipt using Receipt_Generator
            Dim receiptGenerator As New Receipt_Generator()
            Dim receiptOrderInfo = ConvertToReceiptGeneratorOrderInfo(currentOrder.Value)
            Dim pdfPath As String = receiptGenerator.GeneratePdfReceipt(receiptOrderInfo)

            ' Show receipt in popup
            ShowReceiptPopup(pdfPath)
        Catch ex As Exception
            MessageBox.Show("Error generating receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ConvertToReceiptGeneratorOrderInfo(orderInfo As OrderInfo) As Receipt_Generator.OrderInfo
        Dim receiptOrderInfo As New Receipt_Generator.OrderInfo()
        receiptOrderInfo.OrderID = orderInfo.OrderID
        receiptOrderInfo.OrderNumber = orderInfo.OrderNumber
        receiptOrderInfo.OrderDate = orderInfo.OrderDate
        receiptOrderInfo.OrderType = orderInfo.OrderType
        receiptOrderInfo.OrderStatus = orderInfo.OrderStatus
        receiptOrderInfo.TableNumber = orderInfo.TableNumber
        receiptOrderInfo.Subtotal = orderInfo.Subtotal
        receiptOrderInfo.Discount = orderInfo.Discount
        receiptOrderInfo.Tax = orderInfo.Tax
        receiptOrderInfo.TotalAmount = orderInfo.TotalAmount
        receiptOrderInfo.HasPwdDiscount = orderInfo.HasPwdDiscount

        receiptOrderInfo.Items = New List(Of Receipt_Generator.OrderItemInfo)()
        For Each item In orderInfo.Items
            Dim receiptItem As New Receipt_Generator.OrderItemInfo()
            receiptItem.ProductName = item.ProductName
            receiptItem.Quantity = item.Quantity
            receiptItem.Price = item.Price
            receiptItem.Subtotal = item.Subtotal
            receiptOrderInfo.Items.Add(receiptItem)
        Next

        Return receiptOrderInfo
    End Function

    Private Function ConvertToReceiptPreviewOrderInfo(orderInfo As OrderInfo) As ReceiptPreviewControl.OrderInfo
        Dim receiptOrderInfo As New ReceiptPreviewControl.OrderInfo()
        receiptOrderInfo.OrderID = orderInfo.OrderID
        receiptOrderInfo.OrderNumber = orderInfo.OrderNumber
        receiptOrderInfo.OrderDate = orderInfo.OrderDate
        receiptOrderInfo.OrderType = orderInfo.OrderType
        receiptOrderInfo.OrderStatus = orderInfo.OrderStatus
        receiptOrderInfo.TableNumber = orderInfo.TableNumber
        receiptOrderInfo.Subtotal = orderInfo.Subtotal
        receiptOrderInfo.Discount = orderInfo.Discount
        receiptOrderInfo.Tax = orderInfo.Tax
        receiptOrderInfo.TotalAmount = orderInfo.TotalAmount
        receiptOrderInfo.HasPwdDiscount = orderInfo.HasPwdDiscount

        receiptOrderInfo.Items = New List(Of ReceiptPreviewControl.OrderItemInfo)()
        For Each item In orderInfo.Items
            Dim receiptItem As New ReceiptPreviewControl.OrderItemInfo()
            receiptItem.ProductName = item.ProductName
            receiptItem.Quantity = item.Quantity
            receiptItem.Price = item.Price
            receiptItem.Subtotal = item.Subtotal
            receiptOrderInfo.Items.Add(receiptItem)
        Next

        Return receiptOrderInfo
    End Function

    Private Sub ShowReceiptPopup(filePath As String)
        Try
            ' Open the PDF file with default PDF viewer
            Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Error opening receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchOrder(orderNumber As String)
        Try
            ' Clear previous search results
            ClearForm()

            ' Convert simple number to full order number format
            Dim today As String = DateTime.Now.ToString("yyyyMMdd")
            Dim fullOrderNumber As String = "ORD-" & today & "-" & orderNumber.PadLeft(3, "0"c)

            ' Search for order by order number using helper method
            ' Include discount and tax columns if they exist
            Dim orderQuery As String = "SELECT o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, " &
                                     "t.TableNumber, " &
                                     "ISNULL(o.Subtotal, 0) AS Subtotal, " &
                                     "ISNULL(o.Discount, 0) AS Discount, " &
                                     "ISNULL(o.Tax, 0) AS Tax, " &
                                     "ISNULL(o.TotalAmount, 0) AS TotalAmount, " &
                                     "ISNULL(o.HasPwdDiscount, 0) AS HasPwdDiscount " &
                                     "FROM Orders o " &
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

                    ' Try to read discount/tax from database (if columns exist)
                    Try
                        orderInfo.Subtotal = If(reader.IsDBNull("Subtotal"), 0, reader.GetDecimal("Subtotal"))
                        orderInfo.Discount = If(reader.IsDBNull("Discount"), 0, reader.GetDecimal("Discount"))
                        orderInfo.Tax = If(reader.IsDBNull("Tax"), 0, reader.GetDecimal("Tax"))
                        orderInfo.TotalAmount = If(reader.IsDBNull("TotalAmount"), 0, reader.GetDecimal("TotalAmount"))
                        orderInfo.HasPwdDiscount = If(reader.IsDBNull("HasPwdDiscount"), False, reader.GetBoolean("HasPwdDiscount"))
                    Catch
                        ' Columns don't exist yet, calculate from items
                        orderInfo.Subtotal = 0
                        orderInfo.Discount = 0
                        orderInfo.Tax = 0
                        orderInfo.TotalAmount = 0
                        orderInfo.HasPwdDiscount = False
                    End Try

                    reader.Close()

                    ' Get order items using helper method
                    orderInfo.Items = GetOrderItems(orderInfo.OrderID)

                    ' If subtotal wasn't stored, calculate from items
                    If orderInfo.Subtotal = 0 Then
                        orderInfo.Subtotal = orderInfo.Items.Sum(Function(item) item.Subtotal)
                    End If

                    ' If discount/tax weren't stored, try to calculate or get from payment
                    If orderInfo.TotalAmount = 0 Then
                        ' Try to get paid amount from Payments table if order is paid
                        Dim paidAmount As Decimal = GetPaidAmount(orderInfo.OrderID)

                        If paidAmount > 0 Then
                            ' Use paid amount to calculate discount/tax
                            CalculateDiscountAndTax(orderInfo, paidAmount)
                        Else
                            ' For pending orders without stored values, calculate with standard tax
                            orderInfo.Discount = 0
                            orderInfo.Tax = orderInfo.Subtotal * 0.12D
                            orderInfo.TotalAmount = orderInfo.Subtotal + orderInfo.Tax
                            orderInfo.HasPwdDiscount = False
                        End If
                    End If

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
                                                   "t.TableNumber, " &
                                                   "ISNULL(o.Subtotal, 0) AS Subtotal, " &
                                                   "ISNULL(o.Discount, 0) AS Discount, " &
                                                   "ISNULL(o.Tax, 0) AS Tax, " &
                                                   "ISNULL(o.TotalAmount, 0) AS TotalAmount, " &
                                                   "ISNULL(o.HasPwdDiscount, 0) AS HasPwdDiscount " &
                                                   "FROM Orders o " &
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

                            ' Try to read discount/tax from database (if columns exist)
                            Try
                                orderInfo.Subtotal = If(altReader.IsDBNull("Subtotal"), 0, altReader.GetDecimal("Subtotal"))
                                orderInfo.Discount = If(altReader.IsDBNull("Discount"), 0, altReader.GetDecimal("Discount"))
                                orderInfo.Tax = If(altReader.IsDBNull("Tax"), 0, altReader.GetDecimal("Tax"))
                                orderInfo.TotalAmount = If(altReader.IsDBNull("TotalAmount"), 0, altReader.GetDecimal("TotalAmount"))
                                orderInfo.HasPwdDiscount = If(altReader.IsDBNull("HasPwdDiscount"), False, altReader.GetBoolean("HasPwdDiscount"))
                            Catch
                                ' Columns don't exist yet, calculate from items
                                orderInfo.Subtotal = 0
                                orderInfo.Discount = 0
                                orderInfo.Tax = 0
                                orderInfo.TotalAmount = 0
                                orderInfo.HasPwdDiscount = False
                            End Try

                            altReader.Close()

                            ' Get order items using helper method
                            orderInfo.Items = GetOrderItems(orderInfo.OrderID)

                            ' If subtotal wasn't stored, calculate from items
                            If orderInfo.Subtotal = 0 Then
                                orderInfo.Subtotal = orderInfo.Items.Sum(Function(item) item.Subtotal)
                            End If

                            ' If discount/tax weren't stored, try to calculate or get from payment
                            If orderInfo.TotalAmount = 0 Then
                                Dim paidAmount As Decimal = GetPaidAmount(orderInfo.OrderID)

                                If paidAmount > 0 Then
                                    CalculateDiscountAndTax(orderInfo, paidAmount)
                                Else
                                    ' No payment yet, calculate based on standard rules
                                    orderInfo.Discount = 0
                                    orderInfo.Tax = orderInfo.Subtotal * 0.12D
                                    orderInfo.TotalAmount = orderInfo.Subtotal + orderInfo.Tax
                                    orderInfo.HasPwdDiscount = False
                                End If
                            End If

                            ' Set current order
                            currentOrder = orderInfo

                            ' Display order details
                            DisplayOrderDetails()
                            Return
                        End If
                    End Using

                    ' Order not found - silently clear form
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

        Dim itemsQuery As String = "SELECT p.ProductName, oi.Quantity, oi.Price, oi.Subtotal " &
                                  "FROM OrderItems oi " &
                                  "INNER JOIN Products p ON oi.ProductID = p.ProductID " &
                                  "WHERE oi.OrderID = @OrderID"

        Dim parameters() As SqlParameter = {
            DatabaseConnection.CreateParameter("@OrderID", orderId)
        }

        Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(itemsQuery, parameters)
            While reader.Read()
                Dim item As New OrderItemInfo()
                item.ProductName = reader.GetString("ProductName")
                item.Quantity = reader.GetInt32("Quantity")
                item.Price = reader.GetDecimal("Price")
                item.Subtotal = reader.GetDecimal("Subtotal")

                items.Add(item)
            End While
        End Using

        Return items
    End Function

    Private Function GetPaidAmount(orderId As Integer) As Decimal
        Try
            Dim query As String = "SELECT AmountPaid FROM Payments WHERE OrderID = @OrderID"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderId)
            }
            Dim result As Object = DatabaseConnection.ExecuteScalar(query, parameters)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToDecimal(result)
            End If
        Catch
        End Try
        Return 0
    End Function

    Private Sub CalculateDiscountAndTax(ByRef orderInfo As OrderInfo, totalAmount As Decimal)
        orderInfo.TotalAmount = totalAmount

        If orderInfo.Subtotal <= 0 Then
            orderInfo.Discount = 0
            orderInfo.Tax = 0
            orderInfo.HasPwdDiscount = False
            Return
        End If

        ' Calculate expected totals for both scenarios
        Dim withDiscount As Decimal = orderInfo.Subtotal * 0.8D
        Dim withTax As Decimal = orderInfo.Subtotal * 1.12D
        Dim withNeither As Decimal = orderInfo.Subtotal

        ' Calculate the difference from each expected total
        Dim diffFromDiscount As Decimal = Math.Abs(totalAmount - withDiscount)
        Dim diffFromTax As Decimal = Math.Abs(totalAmount - withTax)
        Dim diffFromNeither As Decimal = Math.Abs(totalAmount - withNeither)

        ' Use a tolerance of 0.50 (50 centavos) for rounding differences
        Dim tolerance As Decimal = 0.5D

        ' Determine which pattern matches best
        ' Priority: Check discount first (most specific pattern)
        If diffFromDiscount <= tolerance OrElse (diffFromDiscount < diffFromTax AndAlso diffFromDiscount < diffFromNeither) Then
            ' PWD discount applied (20% off, no tax)
            orderInfo.Discount = orderInfo.Subtotal * 0.2D
            orderInfo.Tax = 0
            orderInfo.HasPwdDiscount = True
            ' Recalculate total to ensure accuracy
            orderInfo.TotalAmount = orderInfo.Subtotal - orderInfo.Discount
            Console.WriteLine("Detected PWD Discount: Subtotal=" & orderInfo.Subtotal.ToString("N2") & ", Total=" & totalAmount.ToString("N2") & ", Expected=" & withDiscount.ToString("N2"))
        ElseIf diffFromTax <= tolerance OrElse (diffFromTax < diffFromDiscount AndAlso diffFromTax < diffFromNeither) Then
            ' Tax applied (12%, no discount)
            orderInfo.Discount = 0
            orderInfo.Tax = orderInfo.Subtotal * 0.12D
            orderInfo.HasPwdDiscount = False
            ' Recalculate total to ensure accuracy
            orderInfo.TotalAmount = orderInfo.Subtotal + orderInfo.Tax
            Console.WriteLine("Detected Tax: Subtotal=" & orderInfo.Subtotal.ToString("N2") & ", Total=" & totalAmount.ToString("N2") & ", Expected=" & withTax.ToString("N2"))
        ElseIf diffFromNeither <= tolerance Then
            ' Neither discount nor tax
            orderInfo.Discount = 0
            orderInfo.Tax = 0
            orderInfo.HasPwdDiscount = False
            orderInfo.TotalAmount = orderInfo.Subtotal
            Console.WriteLine("Detected No Discount/Tax: Subtotal=" & orderInfo.Subtotal.ToString("N2") & ", Total=" & totalAmount.ToString("N2"))
        Else
            ' If none match exactly, use the closest match
            If diffFromDiscount <= diffFromTax AndAlso diffFromDiscount <= diffFromNeither Then
                ' Closest to discount pattern
                orderInfo.Discount = orderInfo.Subtotal * 0.2D
                orderInfo.Tax = 0
                orderInfo.HasPwdDiscount = True
                orderInfo.TotalAmount = orderInfo.Subtotal - orderInfo.Discount
                Console.WriteLine("Closest match: PWD Discount (diff=" & diffFromDiscount.ToString("N2") & ")")
            ElseIf diffFromTax <= diffFromNeither Then
                ' Closest to tax pattern
                orderInfo.Discount = 0
                orderInfo.Tax = orderInfo.Subtotal * 0.12D
                orderInfo.HasPwdDiscount = False
                orderInfo.TotalAmount = orderInfo.Subtotal + orderInfo.Tax
                Console.WriteLine("Closest match: Tax (diff=" & diffFromTax.ToString("N2") & ")")
            Else
                ' Closest to neither
                orderInfo.Discount = 0
                orderInfo.Tax = 0
                orderInfo.HasPwdDiscount = False
                orderInfo.TotalAmount = orderInfo.Subtotal
                Console.WriteLine("Closest match: Neither (diff=" & diffFromNeither.ToString("N2") & ")")
            End If
        End If
    End Sub

    Private Sub DisplayOrderDetails()
        If Not currentOrder.HasValue Then Return

        Dim orderInfo = currentOrder.Value

        ' Clear existing items
        lstOrderItems.Items.Clear()

        ' Add items to list view
        For Each item In orderInfo.Items
            Dim listItem As New ListViewItem(item.ProductName)
            listItem.SubItems.Add(item.Quantity.ToString())
            listItem.SubItems.Add("₱" & item.Price.ToString("N2"))
            listItem.SubItems.Add("₱" & item.Subtotal.ToString("N2"))
            lstOrderItems.Items.Add(listItem)
            Console.WriteLine("Added to ListView: " & item.ProductName & " x" & item.Quantity)
        Next

        ' Update total amount with breakdown
        Dim totalText As String = "Subtotal: ₱" & orderInfo.Subtotal.ToString("N2") & vbCrLf
        If orderInfo.Discount > 0 Then
            totalText &= "Discount (20%): -₱" & orderInfo.Discount.ToString("N2") & vbCrLf
        End If
        If orderInfo.Tax > 0 Then
            totalText &= "Tax VAT (12%): ₱" & orderInfo.Tax.ToString("N2") & vbCrLf
        ElseIf orderInfo.HasPwdDiscount Then
            totalText &= "Tax VAT: ₱0.00 (Exempt)" & vbCrLf
        End If
        totalText &= "Total: ₱" & orderInfo.TotalAmount.ToString("N2")
        lblTotalAmount.Text = totalText
        Console.WriteLine("Updated total label: " & lblTotalAmount.Text)

        ' Update receipt preview
        GenerateReceiptPreview()

        ' Enable payment controls
        btnProcessPayment.Enabled = True

        ' Enable print receipt button for any displayed order
        btnPrintReceipt.Enabled = True

        ' Update payment validation
        ValidatePayment()
    End Sub

    Private Sub GenerateReceiptPreview()
        If Not currentOrder.HasValue Then Return

        ' Use ReceiptPreviewControl to generate preview
        Dim receiptPreview As New ReceiptPreviewControl()
        Dim receiptOrderInfo = ConvertToReceiptPreviewOrderInfo(currentOrder.Value)
        Dim receipt As String = receiptPreview.GenerateReceiptText(receiptOrderInfo)

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

            ' Refresh recent orders list
            LoadRecentOrders()

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
        lblTotalAmount.Text = "Subtotal: ₱0.00" & vbCrLf & "Total: ₱0.00"
        txtReceiptPreview.Clear()
        radCash.Checked = True
        btnProcessPayment.Enabled = False
        btnPrintReceipt.Enabled = False
    End Sub

    Private Sub LoadRecentOrders()
        Try
            lstRecentOrders.Items.Clear()

            ' Get recent orders (last 20 orders)
            Dim query As String = "SELECT TOP 20 o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, " &
                                 "t.TableNumber, " &
                                 "ISNULL(SUM(oi.Subtotal), 0) AS TotalAmount " &
                                 "FROM Orders o " &
                                 "LEFT JOIN Tables t ON o.TableID = t.TableID " &
                                 "LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID " &
                                 "GROUP BY o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, t.TableNumber " &
                                 "ORDER BY o.CreatedAt DESC"

            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    Dim orderNum As String = reader("OrderNumber").ToString()
                    Dim orderDate As DateTime = reader.GetDateTime("CreatedAt")
                    Dim orderType As String = reader("OrderType").ToString()
                    Dim tableNum As String = If(reader.IsDBNull("TableNumber"), "Takeout", reader("TableNumber").ToString())
                    Dim total As Decimal = Convert.ToDecimal(reader("TotalAmount"))
                    Dim status As String = reader("OrderStatus").ToString()

                    ' Calculate actual total with discount/tax if needed
                    Dim orderId As Integer = reader.GetInt32("OrderID")
                    Dim paidAmount As Decimal = GetPaidAmount(orderId)
                    If paidAmount > 0 Then
                        total = paidAmount
                    End If

                    Dim listItem As New ListViewItem(orderNum)
                    listItem.Tag = orderId
                    listItem.SubItems.Add(orderDate.ToString("MM/dd/yyyy HH:mm"))
                    listItem.SubItems.Add(orderType)
                    listItem.SubItems.Add(tableNum)
                    listItem.SubItems.Add("₱" & total.ToString("N2"))
                    listItem.SubItems.Add(status)
                    lstRecentOrders.Items.Add(listItem)
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading recent orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshRecent_Click(sender As Object, e As EventArgs) Handles btnRefreshRecent.Click
        LoadRecentOrders()
    End Sub

    Private Sub lstRecentOrders_DoubleClick(sender As Object, e As EventArgs) Handles lstRecentOrders.DoubleClick
        If lstRecentOrders.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = lstRecentOrders.SelectedItems(0)
            Dim orderId As Integer = Convert.ToInt32(selectedItem.Tag)
            
            ' Get order number from selected item
            Dim orderNumber As String = selectedItem.Text
            
            ' Search for the order
            txtOrderNumber.Text = orderNumber.Split("-"c).Last()
            SearchOrder(txtOrderNumber.Text)
        End If
    End Sub



End Class