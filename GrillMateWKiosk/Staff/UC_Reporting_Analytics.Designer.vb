<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Reporting_Analytics
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
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        FilterComboBox = New ComboBox()
        SumPanelTotalSales = New Panel()
        lblTotalSalesValue = New Label()
        lblTotalSalesTitle = New Label()
        SumOrderCountPanel = New Panel()
        lblOrderCountValue = New Label()
        lblOrderCountTitle = New Label()
        SumAvgCheckSizePanel = New Panel()
        lblAvgCheckSizeValue = New Label()
        lblAvgCheckSizeTitle = New Label()
        AnalDashboardLabel = New Label()
        TableLayoutPanel1.SuspendLayout()
        SumPanelTotalSales.SuspendLayout()
        SumOrderCountPanel.SuspendLayout()
        SumAvgCheckSizePanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = SystemColors.Control
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Controls.Add(Panel2, 1, 0)
        TableLayoutPanel1.Controls.Add(Panel3, 0, 1)
        TableLayoutPanel1.Controls.Add(Panel4, 1, 1)
        TableLayoutPanel1.Location = New Point(3, 284)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1018, 481)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(503, 234)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(512, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(503, 234)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(3, 243)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(503, 235)
        Panel3.TabIndex = 2
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(512, 243)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(503, 235)
        Panel4.TabIndex = 3
        ' 
        ' FilterComboBox
        ' 
        FilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FilterComboBox.FlatStyle = FlatStyle.Flat
        FilterComboBox.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FilterComboBox.FormattingEnabled = True
        FilterComboBox.IntegralHeight = False
        FilterComboBox.ItemHeight = 20
        FilterComboBox.Items.AddRange(New Object() {"Current", "Last 7 Days", "This Month", "This Year"})
        FilterComboBox.Location = New Point(825, 250)
        FilterComboBox.Name = "FilterComboBox"
        FilterComboBox.Size = New Size(196, 28)
        FilterComboBox.TabIndex = 3
        ' 
        ' SumPanelTotalSales
        ' 
        SumPanelTotalSales.BackColor = Color.White
        SumPanelTotalSales.BorderStyle = BorderStyle.FixedSingle
        SumPanelTotalSales.Controls.Add(lblTotalSalesValue)
        SumPanelTotalSales.Controls.Add(lblTotalSalesTitle)
        SumPanelTotalSales.Location = New Point(565, 110)
        SumPanelTotalSales.Name = "SumPanelTotalSales"
        SumPanelTotalSales.Size = New Size(233, 150)
        SumPanelTotalSales.TabIndex = 4
        ' 
        ' lblTotalSalesValue
        ' 
        lblTotalSalesValue.AutoSize = True
        lblTotalSalesValue.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblTotalSalesValue.ForeColor = Color.Green
        lblTotalSalesValue.Location = New Point(71, 67)
        lblTotalSalesValue.Name = "lblTotalSalesValue"
        lblTotalSalesValue.Size = New Size(72, 37)
        lblTotalSalesValue.TabIndex = 1
        lblTotalSalesValue.Text = "0.00"
        ' 
        ' lblTotalSalesTitle
        ' 
        lblTotalSalesTitle.AutoSize = True
        lblTotalSalesTitle.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalSalesTitle.ForeColor = Color.Black
        lblTotalSalesTitle.Location = New Point(12, 12)
        lblTotalSalesTitle.Name = "lblTotalSalesTitle"
        lblTotalSalesTitle.Size = New Size(100, 25)
        lblTotalSalesTitle.TabIndex = 0
        lblTotalSalesTitle.Text = "Total Sales"
        ' 
        ' SumOrderCountPanel
        ' 
        SumOrderCountPanel.BackColor = Color.White
        SumOrderCountPanel.BorderStyle = BorderStyle.FixedSingle
        SumOrderCountPanel.Controls.Add(lblOrderCountValue)
        SumOrderCountPanel.Controls.Add(lblOrderCountTitle)
        SumOrderCountPanel.Location = New Point(285, 110)
        SumOrderCountPanel.Name = "SumOrderCountPanel"
        SumOrderCountPanel.Size = New Size(233, 150)
        SumOrderCountPanel.TabIndex = 5
        ' 
        ' lblOrderCountValue
        ' 
        lblOrderCountValue.AutoSize = True
        lblOrderCountValue.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblOrderCountValue.ForeColor = Color.Green
        lblOrderCountValue.Location = New Point(98, 67)
        lblOrderCountValue.Name = "lblOrderCountValue"
        lblOrderCountValue.Size = New Size(33, 37)
        lblOrderCountValue.TabIndex = 1
        lblOrderCountValue.Text = "0"
        ' 
        ' lblOrderCountTitle
        ' 
        lblOrderCountTitle.AutoSize = True
        lblOrderCountTitle.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOrderCountTitle.ForeColor = Color.Black
        lblOrderCountTitle.Location = New Point(14, 12)
        lblOrderCountTitle.Name = "lblOrderCountTitle"
        lblOrderCountTitle.Size = New Size(117, 25)
        lblOrderCountTitle.TabIndex = 0
        lblOrderCountTitle.Text = "Order Count"
        ' 
        ' SumAvgCheckSizePanel
        ' 
        SumAvgCheckSizePanel.BackColor = Color.White
        SumAvgCheckSizePanel.BorderStyle = BorderStyle.FixedSingle
        SumAvgCheckSizePanel.Controls.Add(lblAvgCheckSizeValue)
        SumAvgCheckSizePanel.Controls.Add(lblAvgCheckSizeTitle)
        SumAvgCheckSizePanel.Location = New Point(6, 110)
        SumAvgCheckSizePanel.Name = "SumAvgCheckSizePanel"
        SumAvgCheckSizePanel.Size = New Size(233, 150)
        SumAvgCheckSizePanel.TabIndex = 6
        ' 
        ' lblAvgCheckSizeValue
        ' 
        lblAvgCheckSizeValue.AutoSize = True
        lblAvgCheckSizeValue.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblAvgCheckSizeValue.ForeColor = Color.Green
        lblAvgCheckSizeValue.Location = New Point(69, 67)
        lblAvgCheckSizeValue.Name = "lblAvgCheckSizeValue"
        lblAvgCheckSizeValue.Size = New Size(72, 37)
        lblAvgCheckSizeValue.TabIndex = 1
        lblAvgCheckSizeValue.Text = "0.00"
        ' 
        ' lblAvgCheckSizeTitle
        ' 
        lblAvgCheckSizeTitle.AutoSize = True
        lblAvgCheckSizeTitle.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAvgCheckSizeTitle.ForeColor = Color.Black
        lblAvgCheckSizeTitle.Location = New Point(21, 12)
        lblAvgCheckSizeTitle.Name = "lblAvgCheckSizeTitle"
        lblAvgCheckSizeTitle.Size = New Size(139, 25)
        lblAvgCheckSizeTitle.TabIndex = 0
        lblAvgCheckSizeTitle.Text = "Avg Check Size"
        ' 
        ' AnalDashboardLabel
        ' 
        AnalDashboardLabel.AutoSize = True
        AnalDashboardLabel.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        AnalDashboardLabel.Location = New Point(3, 15)
        AnalDashboardLabel.Name = "AnalDashboardLabel"
        AnalDashboardLabel.Size = New Size(380, 50)
        AnalDashboardLabel.TabIndex = 7
        AnalDashboardLabel.Text = "Analytics DashBoard"
        ' 
        ' UC_Reporting_Analytics
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        Controls.Add(AnalDashboardLabel)
        Controls.Add(SumOrderCountPanel)
        Controls.Add(SumAvgCheckSizePanel)
        Controls.Add(SumPanelTotalSales)
        Controls.Add(FilterComboBox)
        Controls.Add(TableLayoutPanel1)
        Name = "UC_Reporting_Analytics"
        Size = New Size(1300, 768)
        TableLayoutPanel1.ResumeLayout(False)
        SumPanelTotalSales.ResumeLayout(False)
        SumPanelTotalSales.PerformLayout()
        SumOrderCountPanel.ResumeLayout(False)
        SumOrderCountPanel.PerformLayout()
        SumAvgCheckSizePanel.ResumeLayout(False)
        SumAvgCheckSizePanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents FilterComboBox As ComboBox
    Friend WithEvents SumPanelTotalSales As Panel
    Friend WithEvents SumOrderCountPanel As Panel
    Friend WithEvents SumAvgCheckSizePanel As Panel
    Friend WithEvents lblTotalSalesValue As Label
    Friend WithEvents lblTotalSalesTitle As Label
    Friend WithEvents lblOrderCountValue As Label
    Friend WithEvents lblOrderCountTitle As Label
    Friend WithEvents lblAvgCheckSizeValue As Label
    Friend WithEvents lblAvgCheckSizeTitle As Label
    Friend WithEvents AnalDashboardLabel As Label

End Class
