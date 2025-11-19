<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_OrderHistory
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblTitle = New Label()
        pnlSearchFilter = New Panel()
        btnRefresh = New Button()
        btnClearFilters = New Button()
        dtpDateTo = New DateTimePicker()
        lblDateTo = New Label()
        dtpDateFrom = New DateTimePicker()
        lblDateFrom = New Label()
        cmbOrderStatus = New ComboBox()
        lblOrderStatus = New Label()
        cmbOrderType = New ComboBox()
        lblOrderType = New Label()
        cmbPaymentMethod = New ComboBox()
        lblPaymentMethod = New Label()
        btnSearch = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        pnlOrders = New Panel()
        lblOrderCount = New Label()
        dgvOrders = New DataGridView()
        colOrderID = New DataGridViewTextBoxColumn()
        colOrderNumber = New DataGridViewTextBoxColumn()
        colOrderDate = New DataGridViewTextBoxColumn()
        colOrderType = New DataGridViewTextBoxColumn()
        colTableNumber = New DataGridViewTextBoxColumn()
        colPaymentMethod = New DataGridViewTextBoxColumn()
        colSubtotal = New DataGridViewTextBoxColumn()
        colDiscount = New DataGridViewTextBoxColumn()
        colTax = New DataGridViewTextBoxColumn()
        colTotalAmount = New DataGridViewTextBoxColumn()
        colOrderStatus = New DataGridViewTextBoxColumn()
        pnlSearchFilter.SuspendLayout()
        pnlOrders.SuspendLayout()
        CType(dgvOrders, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTitle.Location = New Point(30, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(268, 51)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Order History"
        ' 
        ' pnlSearchFilter
        ' 
        pnlSearchFilter.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlSearchFilter.BorderStyle = BorderStyle.FixedSingle
        pnlSearchFilter.Controls.Add(btnRefresh)
        pnlSearchFilter.Controls.Add(btnClearFilters)
        pnlSearchFilter.Controls.Add(dtpDateTo)
        pnlSearchFilter.Controls.Add(lblDateTo)
        pnlSearchFilter.Controls.Add(dtpDateFrom)
        pnlSearchFilter.Controls.Add(lblDateFrom)
        pnlSearchFilter.Controls.Add(cmbOrderStatus)
        pnlSearchFilter.Controls.Add(lblOrderStatus)
        pnlSearchFilter.Controls.Add(cmbOrderType)
        pnlSearchFilter.Controls.Add(lblOrderType)
        pnlSearchFilter.Controls.Add(cmbPaymentMethod)
        pnlSearchFilter.Controls.Add(lblPaymentMethod)
        pnlSearchFilter.Controls.Add(btnSearch)
        pnlSearchFilter.Controls.Add(txtSearch)
        pnlSearchFilter.Controls.Add(lblSearch)
        pnlSearchFilter.Dock = DockStyle.Top
        pnlSearchFilter.Location = New Point(0, 0)
        pnlSearchFilter.Name = "pnlSearchFilter"
        pnlSearchFilter.Padding = New Padding(20)
        pnlSearchFilter.Size = New Size(1200, 180)
        pnlSearchFilter.TabIndex = 1
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(659, 124)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(120, 30)
        btnRefresh.TabIndex = 14
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnClearFilters
        ' 
        btnClearFilters.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnClearFilters.FlatAppearance.BorderSize = 0
        btnClearFilters.FlatStyle = FlatStyle.Flat
        btnClearFilters.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnClearFilters.ForeColor = Color.White
        btnClearFilters.Location = New Point(529, 124)
        btnClearFilters.Name = "btnClearFilters"
        btnClearFilters.Size = New Size(120, 30)
        btnClearFilters.TabIndex = 13
        btnClearFilters.Text = "Clear Filters"
        btnClearFilters.UseVisualStyleBackColor = False
        ' 
        ' dtpDateTo
        ' 
        dtpDateTo.Font = New Font("Segoe UI", 10F)
        dtpDateTo.Format = DateTimePickerFormat.Short
        dtpDateTo.Location = New Point(349, 126)
        dtpDateTo.Name = "dtpDateTo"
        dtpDateTo.Size = New Size(150, 25)
        dtpDateTo.TabIndex = 12
        ' 
        ' lblDateTo
        ' 
        lblDateTo.AutoSize = True
        lblDateTo.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDateTo.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDateTo.Location = New Point(279, 129)
        lblDateTo.Name = "lblDateTo"
        lblDateTo.Size = New Size(64, 19)
        lblDateTo.TabIndex = 11
        lblDateTo.Text = "Date To:"
        ' 
        ' dtpDateFrom
        ' 
        dtpDateFrom.Font = New Font("Segoe UI", 10F)
        dtpDateFrom.Format = DateTimePickerFormat.Short
        dtpDateFrom.Location = New Point(104, 126)
        dtpDateFrom.Name = "dtpDateFrom"
        dtpDateFrom.Size = New Size(150, 25)
        dtpDateFrom.TabIndex = 10
        ' 
        ' lblDateFrom
        ' 
        lblDateFrom.AutoSize = True
        lblDateFrom.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDateFrom.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDateFrom.Location = New Point(19, 129)
        lblDateFrom.Name = "lblDateFrom"
        lblDateFrom.Size = New Size(83, 19)
        lblDateFrom.TabIndex = 9
        lblDateFrom.Text = "Date From:"
        ' 
        ' cmbOrderStatus
        ' 
        cmbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOrderStatus.Font = New Font("Segoe UI", 10F)
        cmbOrderStatus.FormattingEnabled = True
        cmbOrderStatus.Items.AddRange(New Object() {"All", "Pending", "Paid", "Cancelled"})
        cmbOrderStatus.Location = New Point(689, 86)
        cmbOrderStatus.Name = "cmbOrderStatus"
        cmbOrderStatus.Size = New Size(150, 25)
        cmbOrderStatus.TabIndex = 8
        ' 
        ' lblOrderStatus
        ' 
        lblOrderStatus.AutoSize = True
        lblOrderStatus.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblOrderStatus.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOrderStatus.Location = New Point(589, 89)
        lblOrderStatus.Name = "lblOrderStatus"
        lblOrderStatus.Size = New Size(97, 19)
        lblOrderStatus.TabIndex = 7
        lblOrderStatus.Text = "Order Status:"
        ' 
        ' cmbOrderType
        ' 
        cmbOrderType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOrderType.Font = New Font("Segoe UI", 10F)
        cmbOrderType.FormattingEnabled = True
        cmbOrderType.Items.AddRange(New Object() {"All", "Dine-In", "Takeout"})
        cmbOrderType.Location = New Point(414, 86)
        cmbOrderType.Name = "cmbOrderType"
        cmbOrderType.Size = New Size(150, 25)
        cmbOrderType.TabIndex = 6
        ' 
        ' lblOrderType
        ' 
        lblOrderType.AutoSize = True
        lblOrderType.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblOrderType.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOrderType.Location = New Point(319, 89)
        lblOrderType.Name = "lblOrderType"
        lblOrderType.Size = New Size(89, 19)
        lblOrderType.TabIndex = 5
        lblOrderType.Text = "Order Type:"
        ' 
        ' cmbPaymentMethod
        ' 
        cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPaymentMethod.Font = New Font("Segoe UI", 10F)
        cmbPaymentMethod.FormattingEnabled = True
        cmbPaymentMethod.Items.AddRange(New Object() {"All", "Cash", "GCash"})
        cmbPaymentMethod.Location = New Point(144, 86)
        cmbPaymentMethod.Name = "cmbPaymentMethod"
        cmbPaymentMethod.Size = New Size(150, 25)
        cmbPaymentMethod.TabIndex = 4
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblPaymentMethod.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblPaymentMethod.Location = New Point(19, 89)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(128, 19)
        lblPaymentMethod.TabIndex = 3
        lblPaymentMethod.Text = "Payment Method:"
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSearch.FlatAppearance.BorderSize = 0
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(344, 44)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(100, 30)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(84, 46)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(250, 25)
        txtSearch.TabIndex = 1
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblSearch.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblSearch.Location = New Point(19, 51)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(58, 19)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search:"
        ' 
        ' pnlOrders
        ' 
        pnlOrders.Controls.Add(lblOrderCount)
        pnlOrders.Controls.Add(dgvOrders)
        pnlOrders.Dock = DockStyle.Fill
        pnlOrders.Location = New Point(0, 180)
        pnlOrders.Name = "pnlOrders"
        pnlOrders.Padding = New Padding(20)
        pnlOrders.Size = New Size(1200, 620)
        pnlOrders.TabIndex = 2
        ' 
        ' lblOrderCount
        ' 
        lblOrderCount.AutoSize = True
        lblOrderCount.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblOrderCount.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOrderCount.Location = New Point(20, 0)
        lblOrderCount.Name = "lblOrderCount"
        lblOrderCount.Size = New Size(108, 19)
        lblOrderCount.TabIndex = 1
        lblOrderCount.Text = "Total Orders: 0"
        ' 
        ' dgvOrders
        ' 
        dgvOrders.AllowUserToAddRows = False
        dgvOrders.AllowUserToDeleteRows = False
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOrders.BackgroundColor = Color.White
        dgvOrders.BorderStyle = BorderStyle.Fixed3D
        dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrders.Columns.AddRange(New DataGridViewColumn() {colOrderID, colOrderNumber, colOrderDate, colOrderType, colTableNumber, colPaymentMethod, colSubtotal, colDiscount, colTax, colTotalAmount, colOrderStatus})
        dgvOrders.Dock = DockStyle.Fill
        dgvOrders.Location = New Point(20, 20)
        dgvOrders.MultiSelect = False
        dgvOrders.Name = "dgvOrders"
        dgvOrders.ReadOnly = True
        dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrders.Size = New Size(1160, 580)
        dgvOrders.TabIndex = 0
        ' 
        ' colOrderID
        ' 
        colOrderID.DataPropertyName = "OrderID"
        colOrderID.HeaderText = "Order ID"
        colOrderID.Name = "colOrderID"
        colOrderID.ReadOnly = True
        colOrderID.Visible = False
        ' 
        ' colOrderNumber
        ' 
        colOrderNumber.DataPropertyName = "OrderNumber"
        colOrderNumber.HeaderText = "Order Number"
        colOrderNumber.Name = "colOrderNumber"
        colOrderNumber.ReadOnly = True
        ' 
        ' colOrderDate
        ' 
        colOrderDate.DataPropertyName = "OrderDate"
        colOrderDate.HeaderText = "Date"
        colOrderDate.Name = "colOrderDate"
        colOrderDate.ReadOnly = True
        ' 
        ' colOrderType
        ' 
        colOrderType.DataPropertyName = "OrderType"
        colOrderType.HeaderText = "Type"
        colOrderType.Name = "colOrderType"
        colOrderType.ReadOnly = True
        ' 
        ' colTableNumber
        ' 
        colTableNumber.DataPropertyName = "TableNumber"
        colTableNumber.HeaderText = "Table"
        colTableNumber.Name = "colTableNumber"
        colTableNumber.ReadOnly = True
        ' 
        ' colPaymentMethod
        ' 
        colPaymentMethod.DataPropertyName = "PaymentMethod"
        colPaymentMethod.HeaderText = "Payment Method"
        colPaymentMethod.Name = "colPaymentMethod"
        colPaymentMethod.ReadOnly = True
        ' 
        ' colSubtotal
        ' 
        colSubtotal.DataPropertyName = "Subtotal"
        colSubtotal.HeaderText = "Subtotal"
        colSubtotal.Name = "colSubtotal"
        colSubtotal.ReadOnly = True
        ' 
        ' colDiscount
        ' 
        colDiscount.DataPropertyName = "Discount"
        colDiscount.HeaderText = "Discount"
        colDiscount.Name = "colDiscount"
        colDiscount.ReadOnly = True
        ' 
        ' colTax
        ' 
        colTax.DataPropertyName = "Tax"
        colTax.HeaderText = "Tax"
        colTax.Name = "colTax"
        colTax.ReadOnly = True
        ' 
        ' colTotalAmount
        ' 
        colTotalAmount.DataPropertyName = "TotalAmount"
        colTotalAmount.HeaderText = "Total Amount"
        colTotalAmount.Name = "colTotalAmount"
        colTotalAmount.ReadOnly = True
        ' 
        ' colOrderStatus
        ' 
        colOrderStatus.DataPropertyName = "OrderStatus"
        colOrderStatus.HeaderText = "Status"
        colOrderStatus.Name = "colOrderStatus"
        colOrderStatus.ReadOnly = True
        ' 
        ' UC_OrderHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(pnlOrders)
        Controls.Add(pnlSearchFilter)
        Controls.Add(lblTitle)
        Name = "UC_OrderHistory"
        Size = New Size(1200, 800)
        pnlSearchFilter.ResumeLayout(False)
        pnlSearchFilter.PerformLayout()
        pnlOrders.ResumeLayout(False)
        pnlOrders.PerformLayout()
        CType(dgvOrders, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlSearchFilter As Panel
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents lblOrderType As Label
    Friend WithEvents cmbOrderType As ComboBox
    Friend WithEvents lblOrderStatus As Label
    Friend WithEvents cmbOrderStatus As ComboBox
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents pnlOrders As Panel
    Friend WithEvents dgvOrders As DataGridView
    Friend WithEvents colOrderID As DataGridViewTextBoxColumn
    Friend WithEvents colOrderNumber As DataGridViewTextBoxColumn
    Friend WithEvents colOrderDate As DataGridViewTextBoxColumn
    Friend WithEvents colOrderType As DataGridViewTextBoxColumn
    Friend WithEvents colTableNumber As DataGridViewTextBoxColumn
    Friend WithEvents colPaymentMethod As DataGridViewTextBoxColumn
    Friend WithEvents colSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As DataGridViewTextBoxColumn
    Friend WithEvents colTax As DataGridViewTextBoxColumn
    Friend WithEvents colTotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents colOrderStatus As DataGridViewTextBoxColumn
    Friend WithEvents lblOrderCount As Label
End Class
