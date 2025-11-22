Imports System.Data.SqlClient
Imports System.Data

Public Class UC_OrderHistory
    Private orderData As New DataTable()
    Private isInitializing As Boolean = True
    Private useDateFilter As Boolean = False

    Private Sub UC_OrderHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize filter defaults
            If cmbPaymentMethod.Items.Count > 0 Then
                cmbPaymentMethod.SelectedIndex = 0
            End If
            If cmbOrderType.Items.Count > 0 Then
                cmbOrderType.SelectedIndex = 0
            End If
            If cmbOrderStatus.Items.Count > 0 Then
                cmbOrderStatus.SelectedIndex = 0
            End If
            
            ' Set default date range (not applied until user filters)
            dtpDateFrom.Value = DateTime.Now
            dtpDateTo.Value = DateTime.Now
            
            ' Configure DataGridViews
            ConfigureDataGridView()
            ConfigureOrderDetailsGridView()
            
            ' Mark initialization as complete
            isInitializing = False
            
            ' Load all orders
            LoadOrders()
        Catch ex As Exception
            MessageBox.Show("Error initializing Order History: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isInitializing = False
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        ' Set up column formatting
        dgvOrders.AutoGenerateColumns = False
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrders.ReadOnly = True
        dgvOrders.AllowUserToAddRows = False
        dgvOrders.AllowUserToDeleteRows = False
        dgvOrders.AllowUserToResizeColumns = False
        dgvOrders.AllowUserToResizeRows = False
        dgvOrders.MultiSelect = False
        dgvOrders.RowHeadersVisible = False
        
        ' Format currency columns
        colSubtotal.DefaultCellStyle.Format = "₱#,##0.00"
        colDiscount.DefaultCellStyle.Format = "₱#,##0.00"
        colTax.DefaultCellStyle.Format = "₱#,##0.00"
        colTotalAmount.DefaultCellStyle.Format = "₱#,##0.00"
        colTotalAmount.DefaultCellStyle.Font = New Font(dgvOrders.Font, FontStyle.Bold)
        
        ' Format date column
        colOrderDate.DefaultCellStyle.Format = "MM/dd/yyyy HH:mm"
        
        ' Set column widths
        colOrderNumber.Width = 150
        colOrderDate.Width = 150
        colOrderType.Width = 100
        colTableNumber.Width = 100
        colPaymentMethod.Width = 120
        colSubtotal.Width = 100
        colDiscount.Width = 100
        colTax.Width = 100
        colTotalAmount.Width = 120
        colOrderStatus.Width = 100
    End Sub

    Private Sub ConfigureOrderDetailsGridView()
        ' Set up order details DataGridView
        dgvOrderDetails.AutoGenerateColumns = False
        dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrderDetails.ReadOnly = True
        dgvOrderDetails.AllowUserToAddRows = False
        dgvOrderDetails.AllowUserToDeleteRows = False
        dgvOrderDetails.AllowUserToResizeColumns = False
        dgvOrderDetails.AllowUserToResizeRows = False
        dgvOrderDetails.MultiSelect = False
        dgvOrderDetails.RowHeadersVisible = False
        
        ' Format currency columns
        colDetailPrice.DefaultCellStyle.Format = "P#,##0.00"
        colDetailSubtotal.DefaultCellStyle.Format = "P#,##0.00"
        colDetailSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        
        ' Set column widths - Product Name takes most space
        colDetailProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDetailQuantity.Width = 80
        colDetailQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colDetailPrice.Width = 100
        colDetailPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colDetailSubtotal.Width = 120
    End Sub

    Private Sub LoadOrders()
        Try
            ' Build the query with filters
            Dim query As String = BuildQuery()
            Dim parameters As New List(Of SqlParameter)

            ' Add search parameter if provided
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                parameters.Add(DatabaseConnection.CreateParameter("@SearchTerm", "%" & txtSearch.Text.Trim() & "%"))
            End If

            ' Add payment method filter
            If cmbPaymentMethod.SelectedIndex > 0 Then
                parameters.Add(DatabaseConnection.CreateParameter("@PaymentMethod", cmbPaymentMethod.SelectedItem.ToString()))
            End If

            ' Add order type filter
            If cmbOrderType.SelectedIndex > 0 Then
                parameters.Add(DatabaseConnection.CreateParameter("@OrderType", cmbOrderType.SelectedItem.ToString()))
            End If

            ' Add order status filter
            If cmbOrderStatus.SelectedIndex > 0 Then
                parameters.Add(DatabaseConnection.CreateParameter("@OrderStatus", cmbOrderStatus.SelectedItem.ToString()))
            End If

            ' Add date range filters if enabled
            If useDateFilter Then
                parameters.Add(DatabaseConnection.CreateParameter("@DateFrom", dtpDateFrom.Value.Date))
                parameters.Add(DatabaseConnection.CreateParameter("@DateTo", dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If

            ' Execute query
            Dim sqlParams As SqlParameter() = Nothing
            If parameters.Count > 0 Then
                sqlParams = parameters.ToArray()
            End If
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query, sqlParams)
                ' Create DataTable structure
                orderData = New DataTable()
                orderData.Columns.Add("OrderID", GetType(Integer))
                orderData.Columns.Add("OrderNumber", GetType(String))
                orderData.Columns.Add("OrderDate", GetType(DateTime))
                orderData.Columns.Add("OrderType", GetType(String))
                orderData.Columns.Add("TableNumber", GetType(String))
                orderData.Columns.Add("PaymentMethod", GetType(String))
                orderData.Columns.Add("Subtotal", GetType(Decimal))
                orderData.Columns.Add("Discount", GetType(Decimal))
                orderData.Columns.Add("Tax", GetType(Decimal))
                orderData.Columns.Add("TotalAmount", GetType(Decimal))
                orderData.Columns.Add("OrderStatus", GetType(String))

                ' Load data
                While reader.Read()
                    Dim row As DataRow = orderData.NewRow()
                    row("OrderID") = reader.GetInt32("OrderID")
                    row("OrderNumber") = reader.GetString("OrderNumber")
                    row("OrderDate") = reader.GetDateTime("CreatedAt")
                    row("OrderType") = reader.GetString("OrderType")
                    row("TableNumber") = If(reader.IsDBNull("TableNumber"), "Takeout", reader.GetString("TableNumber"))
                    
                    ' Get payment method from Payments table
                    Dim paymentMethod As String = GetPaymentMethod(reader.GetInt32("OrderID"))
                    row("PaymentMethod") = If(String.IsNullOrEmpty(paymentMethod), "Not Paid", paymentMethod)
                    
                    ' Get financial data (with fallback for old orders)
                    Try
                        row("Subtotal") = If(reader.IsDBNull("Subtotal"), 0, reader.GetDecimal("Subtotal"))
                        row("Discount") = If(reader.IsDBNull("Discount"), 0, reader.GetDecimal("Discount"))
                        row("Tax") = If(reader.IsDBNull("Tax"), 0, reader.GetDecimal("Tax"))
                        row("TotalAmount") = If(reader.IsDBNull("TotalAmount"), 0, reader.GetDecimal("TotalAmount"))
                    Catch
                        ' If columns don't exist, calculate from items
                        Dim orderId As Integer = reader.GetInt32("OrderID")
                        Dim totals As Dictionary(Of String, Decimal) = CalculateOrderTotals(orderId)
                        row("Subtotal") = totals("Subtotal")
                        row("Discount") = totals("Discount")
                        row("Tax") = totals("Tax")
                        row("TotalAmount") = totals("TotalAmount")
                    End Try
                    
                    row("OrderStatus") = reader.GetString("OrderStatus")
                    orderData.Rows.Add(row)
                End While
            End Using

            ' Bind to DataGridView
            dgvOrders.DataSource = orderData
            
            ' Update order count
            lblOrderCount.Text = "Total Orders: " & orderData.Rows.Count.ToString()
            
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuildQuery() As String
        Dim query As String = "SELECT DISTINCT o.OrderID, o.OrderNumber, o.OrderType, o.OrderStatus, o.CreatedAt, " &
                             "t.TableNumber, " &
                             "ISNULL(o.Subtotal, 0) AS Subtotal, " &
                             "ISNULL(o.Discount, 0) AS Discount, " &
                             "ISNULL(o.Tax, 0) AS Tax, " &
                             "ISNULL(o.TotalAmount, 0) AS TotalAmount " &
                             "FROM Orders o " &
                             "LEFT JOIN Tables t ON o.TableID = t.TableID " &
                             "WHERE 1 = 1"

        ' Add date filters only when requested
        If useDateFilter Then
            query &= " AND o.CreatedAt >= @DateFrom AND o.CreatedAt <= @DateTo"
        End If

        ' Add search filter
        If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            query &= " AND o.OrderNumber LIKE @SearchTerm"
        End If

        ' Add order type filter
        If cmbOrderType.SelectedIndex > 0 Then
            query &= " AND o.OrderType = @OrderType"
        End If

        ' Add order status filter
        If cmbOrderStatus.SelectedIndex > 0 Then
            query &= " AND o.OrderStatus = @OrderStatus"
        End If

        ' Add payment method filter (requires join with Payments table)
        If cmbPaymentMethod.SelectedIndex > 0 Then
            query &= " AND EXISTS (SELECT 1 FROM Payments p WHERE p.OrderID = o.OrderID AND p.PaymentMethod = @PaymentMethod)"
        End If

        query &= " ORDER BY o.CreatedAt DESC"

        Return query
    End Function

    Private Function GetPaymentMethod(orderId As Integer) As String
        Try
            Dim query As String = "SELECT TOP 1 PaymentMethod FROM Payments WHERE OrderID = @OrderID ORDER BY PaymentDate DESC"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderId)
            }
            Dim result As Object = DatabaseConnection.ExecuteScalar(query, parameters)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return result.ToString()
            End If
        Catch
        End Try
        Return ""
    End Function

    Private Function CalculateOrderTotals(orderId As Integer) As Dictionary(Of String, Decimal)
        Dim totals As New Dictionary(Of String, Decimal)
        totals("Subtotal") = 0
        totals("Discount") = 0
        totals("Tax") = 0
        totals("TotalAmount") = 0

        Try
            ' Get subtotal from order items
            Dim itemsQuery As String = "SELECT SUM(Subtotal) AS Subtotal FROM OrderItems WHERE OrderID = @OrderID"
            Dim itemsParams() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderId)
            }
            Dim subtotalResult As Object = DatabaseConnection.ExecuteScalar(itemsQuery, itemsParams)
            If subtotalResult IsNot Nothing AndAlso Not IsDBNull(subtotalResult) Then
                totals("Subtotal") = Convert.ToDecimal(subtotalResult)
            End If

            ' Try to get paid amount to determine discount/tax
            Dim paidQuery As String = "SELECT AmountPaid FROM Payments WHERE OrderID = @OrderID"
            Dim paidResult As Object = DatabaseConnection.ExecuteScalar(paidQuery, itemsParams)
            If paidResult IsNot Nothing AndAlso Not IsDBNull(paidResult) Then
                Dim paidAmount As Decimal = Convert.ToDecimal(paidResult)
                totals("TotalAmount") = paidAmount
                
                ' Calculate discount and tax based on pattern
                Dim subtotal As Decimal = totals("Subtotal")
                If subtotal > 0 Then
                    Dim withDiscount As Decimal = subtotal * 0.8D
                    Dim withTax As Decimal = subtotal * 1.12D
                    Dim diffFromDiscount As Decimal = Math.Abs(paidAmount - withDiscount)
                    Dim diffFromTax As Decimal = Math.Abs(paidAmount - withTax)
                    
                    If diffFromDiscount < diffFromTax AndAlso diffFromDiscount < 0.5D Then
                        ' PWD discount (20% off, no tax)
                        totals("Discount") = subtotal * 0.2D
                        totals("Tax") = 0
                    ElseIf diffFromTax < 0.5D Then
                        ' Tax applied (12%)
                        totals("Discount") = 0
                        totals("Tax") = subtotal * 0.12D
                    Else
                        ' Neither
                        totals("Discount") = 0
                        totals("Tax") = 0
                        totals("TotalAmount") = subtotal
                    End If
                End If
            Else
                ' No payment yet, calculate with standard tax
                Dim subtotal As Decimal = totals("Subtotal")
                totals("Tax") = subtotal * 0.12D
                totals("TotalAmount") = subtotal + totals("Tax")
            End If
        Catch
        End Try

        Return totals
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadOrders()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearch_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub cmbPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaymentMethod.SelectedIndexChanged
        If Not isInitializing Then
            LoadOrders()
        End If
    End Sub

    Private Sub cmbOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrderType.SelectedIndexChanged
        If Not isInitializing Then
            LoadOrders()
        End If
    End Sub

    Private Sub cmbOrderStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrderStatus.SelectedIndexChanged
        If Not isInitializing Then
            LoadOrders()
        End If
    End Sub

    Private Sub dtpDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateFrom.ValueChanged
        If Not isInitializing Then
            useDateFilter = True
            LoadOrders()
        End If
    End Sub

    Private Sub dtpDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateTo.ValueChanged
        If Not isInitializing Then
            useDateFilter = True
            LoadOrders()
        End If
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Reset all filters to show all orders
        isInitializing = True
        txtSearch.Clear()
        If cmbPaymentMethod.Items.Count > 0 Then
            cmbPaymentMethod.SelectedIndex = 0
        End If
        If cmbOrderType.Items.Count > 0 Then
            cmbOrderType.SelectedIndex = 0
        End If
        If cmbOrderStatus.Items.Count > 0 Then
            cmbOrderStatus.SelectedIndex = 0
        End If
        ' Set date range back to defaults (not applied until filter enabled)
        dtpDateFrom.Value = DateTime.Now
        dtpDateTo.Value = DateTime.Now
        isInitializing = False
        useDateFilter = False

        ' Reload orders
        LoadOrders()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadOrders()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        useDateFilter = False
        LoadOrders()
    End Sub

    Private Sub dgvOrders_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOrders.SelectionChanged
        If dgvOrders.SelectedRows.Count > 0 AndAlso orderData IsNot Nothing AndAlso orderData.Rows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvOrders.SelectedRows(0)
            Dim rowIndex As Integer = selectedRow.Index
            If rowIndex >= 0 AndAlso rowIndex < orderData.Rows.Count Then
                Dim orderId As Integer = Convert.ToInt32(orderData.Rows(rowIndex)("OrderID"))
                LoadOrderDetails(orderId)
            End If
        Else
            ' Clear order details if no row is selected
            dgvOrderDetails.DataSource = Nothing
            lblOrderDetails.Text = "Order Details (Select an order)"
        End If
    End Sub

    Private Sub LoadOrderDetails(orderId As Integer)
        Try
            Dim detailsData As New DataTable()
            detailsData.Columns.Add("ProductName", GetType(String))
            detailsData.Columns.Add("Quantity", GetType(Integer))
            detailsData.Columns.Add("Price", GetType(Decimal))
            detailsData.Columns.Add("Subtotal", GetType(Decimal))

            Dim query As String = "SELECT p.ProductName, oi.Quantity, oi.Price, oi.Subtotal " &
                                 "FROM OrderItems oi " &
                                 "INNER JOIN Products p ON oi.ProductID = p.ProductID " &
                                 "WHERE oi.OrderID = @OrderID " &
                                 "ORDER BY oi.OrderItemID"

            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@OrderID", orderId)
            }

            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query, parameters)
                While reader.Read()
                    Dim row As DataRow = detailsData.NewRow()
                    row("ProductName") = reader.GetString("ProductName")
                    row("Quantity") = reader.GetInt32("Quantity")
                    row("Price") = reader.GetDecimal("Price")
                    row("Subtotal") = reader.GetDecimal("Subtotal")
                    detailsData.Rows.Add(row)
                End While
            End Using

            ' Bind to DataGridView
            dgvOrderDetails.DataSource = detailsData

            ' Update label with order number
            Dim orderNumber As String = ""
            If dgvOrders.SelectedRows.Count > 0 AndAlso orderData IsNot Nothing Then
                Dim selectedRow As DataGridViewRow = dgvOrders.SelectedRows(0)
                Dim rowIndex As Integer = selectedRow.Index
                If rowIndex >= 0 AndAlso rowIndex < orderData.Rows.Count Then
                    orderNumber = orderData.Rows(rowIndex)("OrderNumber").ToString()
                End If
            End If
            lblOrderDetails.Text = "Order Details - " & orderNumber & " (" & detailsData.Rows.Count & " items)"

        Catch ex As Exception
            MessageBox.Show("Error loading order details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgvOrderDetails.DataSource = Nothing
            lblOrderDetails.Text = "Order Details (Error loading)"
        End Try
    End Sub

End Class
