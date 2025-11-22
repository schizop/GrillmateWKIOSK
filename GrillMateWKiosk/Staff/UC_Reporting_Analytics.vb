Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Drawing
Imports System.Diagnostics

Public Class UC_Reporting_Analytics

    Private connectionString As String = "Server=localhost\SQLEXPRESS;Database=POS;Integrated Security=True;TrustServerCertificate=True;"

    Private TotalSalesChart As Chart
    Private OrderCountChart As Chart
    Private AvgCheckSizeChart As Chart
    Private TopSellingItemChart As Chart

    Private Const AvgCheckSizeTarget As Decimal = 35D

    Private WithEvents autoRefreshTimer As New Timer()

    ' Enlarge on click helpers
    Private EnlargedChart As Chart = Nothing
    Private OriginalChartBounds As Rectangle
    Private OriginalChartParent As Control = Nothing
    Private OriginalDockStyle As DockStyle = DockStyle.None
    Private OverlayPanel As Panel = Nothing

    'DATA CLASSES
    Public Class SalesDataPoint
        Public Property DateValue As DateTime
        Public Property SalesAmount As Decimal
        Public Property OrderCount As Integer
        Public Property AvgCheckSize As Decimal

        Public Sub New(dateValue As DateTime, salesAmount As Decimal, orderCount As Integer, avgCheckSize As Decimal)
            Me.DateValue = dateValue
            Me.SalesAmount = salesAmount
            Me.OrderCount = orderCount
            Me.AvgCheckSize = avgCheckSize
        End Sub
    End Class

    Public Class TopItemSale
        Public Property ItemName As String
        Public Property ItemsSold As Integer

        Public Sub New(itemName As String, itemsSold As Integer)
            Me.ItemName = itemName
            Me.ItemsSold = itemsSold
        End Sub
    End Class


    Public Sub New()
        InitializeComponent()
        InitializeChartControls()
        CreateOverlay()
        InitializeFilterComboBox()

        autoRefreshTimer.Interval = 30000
        autoRefreshTimer.Start()
        ApplyFilter()
    End Sub

    ' FILTER COMBOBOX
    Private Sub InitializeFilterComboBox()
        FilterComboBox.Items.Clear()
        FilterComboBox.Items.AddRange({"Current Day", "Last 7 Days", "This Month", "This Year"})
        FilterComboBox.SelectedIndex = 0
        AddHandler FilterComboBox.SelectedIndexChanged, AddressOf FilterComboBox_SelectedIndexChanged
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim startDate As DateTime
        Dim endDate As DateTime = DateTime.Now.Date
        Dim titlePrefix As String = ""

        Select Case FilterComboBox.SelectedItem?.ToString()
            Case "Current Day"
                startDate = DateTime.Today
                endDate = DateTime.Today.AddDays(1)

            Case "Last 7 Days"
                startDate = endDate.AddDays(-6)
                titlePrefix = "Last 7 Days"

            Case "This Month"
                startDate = New Date(endDate.Year, endDate.Month, 1)
                titlePrefix = "This Month"

            Case "This Year"
                startDate = New Date(endDate.Year, 1, 1)
                titlePrefix = "This Year"

            Case Else
                startDate = endDate.AddDays(-6)
                titlePrefix = "Last 7 Days"
        End Select

        LoadAnalyticsData(startDate, endDate, titlePrefix)
    End Sub

    '   LOADING ANALYTICS
    Private Sub LoadAnalyticsData(startDate As DateTime, endDate As DateTime, titlePrefix As String)

        Dim timeSeriesData = GetTimeSeriesData(startDate, endDate)
        Dim totalEarnings As Decimal = GetTotalEarnings(startDate, endDate)
        Dim itemData = GetTopItemData(startDate, endDate)


        Dim totalOrders As Integer = 0
        For Each dp In timeSeriesData
            totalOrders += dp.OrderCount
        Next

        Dim avgCheckSize As Decimal = If(totalOrders > 0, totalEarnings / totalOrders, 0D)

        lblTotalSalesValue.Text = totalEarnings.ToString("C2")
        lblOrderCountValue.Text = totalOrders.ToString()
        lblAvgCheckSizeValue.Text = avgCheckSize.ToString("C2")

        ' Total Sales
        TotalSalesChart.DataSource = timeSeriesData
        TotalSalesChart.Series(0).XValueMember = "DateValue"
        TotalSalesChart.Series(0).YValueMembers = "SalesAmount"
        TotalSalesChart.DataBind()
        TotalSalesChart.Titles(0).Text = $"Total Sales - {titlePrefix}"

        ' Order Count 
        OrderCountChart.DataSource = timeSeriesData
        OrderCountChart.Series(0).XValueMember = "DateValue"
        OrderCountChart.Series(0).YValueMembers = "OrderCount"
        OrderCountChart.DataBind()
        OrderCountChart.Titles(0).Text = $"Order Count - {titlePrefix}"

        ' Avg Check Size 
        AvgCheckSizeChart.Titles(0).Text = "Average Check Size"
        ApplyAvgCheckSizeConditionalColors(timeSeriesData)

        ' Top Selling Items
        TopSellingItemChart.DataSource = itemData
        TopSellingItemChart.Series(0).XValueMember = "ItemName"
        TopSellingItemChart.Series(0).YValueMembers = "ItemsSold"
        TopSellingItemChart.DataBind()
        TopSellingItemChart.Titles(0).Text = $"Top Selling Items - {titlePrefix}"

    End Sub

    ' SQL HELPERS
    Private Function DayStart(d As DateTime) As DateTime
        Return d.Date
    End Function

    Private Function DayEnd(d As DateTime) As DateTime
        Return d.Date.AddDays(1)
    End Function

    Private Function GetTotalEarnings(startDate As DateTime, endDate As DateTime) As Decimal
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query As String = "
            SELECT SUM(O.TotalAmount)
            FROM Orders O
            WHERE O.CreatedAt >= @Start 
              AND O.CreatedAt < @End
              AND (O.OrderStatus='Completed' OR O.OrderStatus='Paid')
        "

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Start", DayStart(startDate))
                cmd.Parameters.AddWithValue("@End", DayEnd(endDate))

                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    Return Convert.ToDecimal(result)
                End If
            End Using
        End Using

        Return 0D
    End Function
    Private Function GetTimeSeriesData(startDate As DateTime, endDate As DateTime) As List(Of SalesDataPoint)
        Dim result As New List(Of SalesDataPoint)

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query As String = "
    SELECT 
        CAST(O.CreatedAt AS DATE) AS SalesDate,
        SUM(O.TotalAmount) AS TotalSales,
        COUNT(DISTINCT O.OrderID) AS OrderCount
    FROM Orders O
    WHERE O.CreatedAt >= @Start AND O.CreatedAt < @End
      AND (O.OrderStatus='Completed' OR O.OrderStatus='Paid')
    GROUP BY CAST(O.CreatedAt AS DATE)
    ORDER BY SalesDate
"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Start", DayStart(startDate))
                cmd.Parameters.AddWithValue("@End", DayEnd(endDate))

                Using r = cmd.ExecuteReader()
                    While r.Read()
                        Dim sales = If(IsDBNull(r("TotalSales")), 0D, Convert.ToDecimal(r("TotalSales")))
                        Dim orders = If(IsDBNull(r("OrderCount")), 0, Convert.ToInt32(r("OrderCount")))
                        Dim avgSize As Decimal = If(orders > 0, Decimal.Round(sales / orders, 2), 0D)

                        result.Add(New SalesDataPoint(
                            Convert.ToDateTime(r("SalesDate")),
                            sales,
                            orders,
                            avgSize
                        ))
                    End While
                End Using
            End Using
        End Using

        ' Fill missing dates
        Dim filled As New List(Of SalesDataPoint)
        Dim currentDate = startDate

        While currentDate <= endDate
            Dim found As SalesDataPoint = Nothing
            For Each dp In result
                If dp.DateValue.Date = currentDate.Date Then
                    found = dp
                    Exit For
                End If
            Next

            If found IsNot Nothing Then
                filled.Add(found)
            Else
                filled.Add(New SalesDataPoint(currentDate, 0, 0, 0))
            End If

            currentDate = currentDate.AddDays(1)
        End While

        Return filled
    End Function

    Private Function GetTopItemData(startDate As DateTime, endDate As DateTime) As List(Of TopItemSale)
        Dim result As New List(Of TopItemSale)

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim query As String = "
                SELECT P.ProductName, SUM(OI.Quantity) AS ItemsSold
                FROM OrderItems OI
                INNER JOIN Orders O ON OI.OrderID = O.OrderID
                INNER JOIN Products P ON OI.ProductID = P.ProductID
                WHERE O.CreatedAt >= @Start AND O.CreatedAt < @End
                AND (O.OrderStatus='Completed' OR O.OrderStatus='Paid')
                GROUP BY P.ProductName
                ORDER BY ItemsSold DESC
            "

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Start", DayStart(startDate))
                cmd.Parameters.AddWithValue("@End", DayEnd(endDate))

                Using r = cmd.ExecuteReader()
                    While r.Read()
                        result.Add(New TopItemSale(
                            r("ProductName").ToString(),
                            Convert.ToInt32(r("ItemsSold"))
                        ))
                    End While
                End Using
            End Using
        End Using

        Return result
    End Function

    Private Sub ApplyAvgCheckSizeConditionalColors(data As List(Of SalesDataPoint))
        Dim actualSeries = AvgCheckSizeChart.Series("Average Check Size")

        actualSeries.Points.Clear()

        For Each dp In data
            Dim p As New DataPoint(dp.DateValue.ToOADate(), dp.AvgCheckSize)

            If dp.AvgCheckSize >= AvgCheckSizeTarget Then
                p.Color = Color.Green
            Else
                p.Color = Color.OrangeRed
            End If

            actualSeries.Points.Add(p)
        Next
    End Sub

    ' CHART INITIALIZATION
    Private Sub InitializeChartControls()

        ' TOTAL SALES 
        TotalSalesChart = New Chart() With {.Dock = DockStyle.Fill}
        Dim totalArea As New ChartArea("TotalSalesArea")
        TotalSalesChart.ChartAreas.Add(totalArea)

        TotalSalesChart.Series.Add(New Series("Total Sales") With {
            .ChartType = SeriesChartType.Line,
            .XValueType = ChartValueType.Date,
            .ToolTip = "Date: #VALX{dd MMM yyyy}" & vbCrLf & "Sales: ₱#VALY{N2}",
            .BorderWidth = 3
        })
        TotalSalesChart.Series("Total Sales").Color = Color.FromArgb(52, 152, 219)
        TotalSalesChart.Titles.Add("Total Sales")
        Panel1.Controls.Add(TotalSalesChart)

        AddHandler TotalSalesChart.MouseClick, AddressOf Chart_MouseClick

        ' ORDER COUNT 
        OrderCountChart = New Chart() With {.Dock = DockStyle.Fill}
        Dim orderArea As New ChartArea("OrderCountArea")
        OrderCountChart.ChartAreas.Add(orderArea)

        OrderCountChart.Series.Add(New Series("Order Count") With {
            .ChartType = SeriesChartType.Line,
            .XValueType = ChartValueType.Date,
            .ToolTip = "Date: #VALX{dd MMM yyyy}" & vbCrLf & "Orders: #VALY",
            .BorderWidth = 3
        })
        OrderCountChart.Series("Order Count").Color = Color.Red
        OrderCountChart.Titles.Add("Order Count")
        Panel2.Controls.Add(OrderCountChart)

        AddHandler OrderCountChart.MouseClick, AddressOf Chart_MouseClick

        ' AVG CHECK SIZE (NO TARGET SERIES)
        AvgCheckSizeChart = New Chart() With {.Dock = DockStyle.Fill}
        Dim avgArea As New ChartArea("AvgCheckArea")
        AvgCheckSizeChart.ChartAreas.Add(avgArea)

        AvgCheckSizeChart.Series.Add(New Series("Average Check Size") With {
            .ChartType = SeriesChartType.Line,
            .XValueType = ChartValueType.Date,
            .ToolTip = "Date: #VALX{dd MMM yyyy}" & vbCrLf & "Avg Check: ₱#VALY{N2}",
            .BorderWidth = 3
        })

        AvgCheckSizeChart.Series("Average Check Size").Color = Color.Gold
        AvgCheckSizeChart.Titles.Add("Average Check Size")
        Panel3.Controls.Add(AvgCheckSizeChart)

        AddHandler AvgCheckSizeChart.MouseClick, AddressOf Chart_MouseClick

        ' TOP SELLING ITEMS 
        TopSellingItemChart = New Chart() With {.Dock = DockStyle.Fill}
        Dim topArea As New ChartArea("TopItemArea")

        topArea.AxisX.Title = "Items Sold"
        topArea.AxisY.Title = "Item Name"
        topArea.AxisX.Interval = 1
        topArea.AxisX.MajorGrid.Enabled = False
        topArea.AxisY.MajorGrid.Enabled = False

        TopSellingItemChart.ChartAreas.Add(topArea)

        Dim s As New Series("Top Items")
        With s
            .ChartType = SeriesChartType.Bar
            .ToolTip = "Item: #AXISLABEL" & vbCrLf & "Sold: #VALY"
            .IsValueShownAsLabel = True
            .Label = "#VALY"
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .BorderWidth = 1
        End With

        TopSellingItemChart.Series.Add(s)
        TopSellingItemChart.Series("Top Items").Color = Color.FromArgb(155, 89, 182)

        TopSellingItemChart.Titles.Add("Top Selling Items")
        Panel4.Controls.Add(TopSellingItemChart)

        AddHandler TopSellingItemChart.MouseClick, AddressOf Chart_MouseClick

    End Sub

    ' AUTO REFRESH
    Private Sub autoRefreshTimer_Tick(sender As Object, e As EventArgs) Handles autoRefreshTimer.Tick
        Try
            ApplyFilter()
        Catch ex As Exception
            Debug.WriteLine("Auto-refresh failed: " & ex.Message)
        End Try
    End Sub

    ' ENLARGE & COLLAPSE HANDLERS
    Private Sub CreateOverlay()
        If OverlayPanel IsNot Nothing Then Return

        OverlayPanel = New Panel()
        OverlayPanel.BackColor = Color.FromArgb(140, 0, 0, 0)
        OverlayPanel.Dock = DockStyle.Fill
        OverlayPanel.Visible = False
        OverlayPanel.Cursor = Cursors.Hand
        AddHandler OverlayPanel.Click, AddressOf OverlayPanel_Click

        Me.Controls.Add(OverlayPanel)
        OverlayPanel.BringToFront()
    End Sub

    Private Sub Chart_MouseClick(sender As Object, e As MouseEventArgs)
        Dim chart = TryCast(sender, Chart)
        If chart Is Nothing Then Return

        If EnlargedChart Is Nothing Then
            EnlargeChart(chart)
        Else
            If Object.ReferenceEquals(chart, EnlargedChart) Then
                CollapseChart()
            End If
        End If
    End Sub

    Private Sub OverlayPanel_Click(sender As Object, e As EventArgs)
        CollapseChart()
    End Sub

    Private Sub EnlargeChart(chart As Chart)
        If chart Is Nothing OrElse EnlargedChart IsNot Nothing Then Exit Sub

        Try
            Me.SuspendLayout()

            ' Save state
            OriginalChartParent = chart.Parent
            OriginalChartBounds = chart.Bounds
            OriginalDockStyle = chart.Dock

            ' Prepare overlay
            If OverlayPanel Is Nothing Then CreateOverlay()
            OverlayPanel.Visible = True
            OverlayPanel.BringToFront()

            ' Move chart temporarily invisible to reduce flicker
            chart.Visible = False

            ' Re-parent
            OriginalChartParent.Controls.Remove(chart)
            Me.Controls.Add(chart)

            ' Position target rectangle
            chart.Dock = DockStyle.None
            chart.Bounds = New Rectangle(
            CInt(Me.Width * 0.07),
            CInt(Me.Height * 0.07),
            CInt(Me.Width * 0.86),
            CInt(Me.Height * 0.86)
        )

            EnlargedChart = chart

            Me.ResumeLayout(True)

            ' Show chart AFTER layout settles
            chart.Visible = True
            chart.BringToFront()

        Catch ex As Exception
            Debug.WriteLine("EnlargeChart optimized error: " & ex.Message)
        End Try
    End Sub



    Private Sub CollapseChart()
        Try
            If EnlargedChart Is Nothing Then Return

            Dim chart = EnlargedChart

            Me.Controls.Remove(chart)
            If OriginalChartParent IsNot Nothing Then
                OriginalChartParent.Controls.Add(chart)
            Else
                Me.Controls.Add(chart)
            End If

            chart.Dock = OriginalDockStyle
            chart.Bounds = OriginalChartBounds
            chart.BringToFront()

            OverlayPanel.Visible = False

            EnlargedChart = Nothing
            OriginalChartParent = Nothing
            OriginalDockStyle = DockStyle.None
            OriginalChartBounds = Rectangle.Empty
        Catch ex As Exception
            Debug.WriteLine("CollapseChart error: " & ex.Message)
        End Try
    End Sub

End Class
