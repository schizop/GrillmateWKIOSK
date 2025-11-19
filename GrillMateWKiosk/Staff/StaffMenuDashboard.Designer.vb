<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StaffMenuDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    Friend WithEvents TopPanel As System.Windows.Forms.Panel
    Friend WithEvents LogoLabel As System.Windows.Forms.Label
    Friend WithEvents LogoutButton As System.Windows.Forms.Button
    Friend WithEvents NavigationPanel As System.Windows.Forms.Panel
    Friend WithEvents TableManagementButton As System.Windows.Forms.Button
    Friend WithEvents BillingButton As System.Windows.Forms.Button
    Friend WithEvents OrderHistoryButton As System.Windows.Forms.Button
    Friend WithEvents ReportingAnalyticsButton As System.Windows.Forms.Button
    Friend WithEvents ReservationPageButton As System.Windows.Forms.Button
    Friend WithEvents DeliveryPageButton As System.Windows.Forms.Button
    Friend WithEvents ContentPanel As System.Windows.Forms.Panel

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TopPanel = New Panel()
        LogoLabel = New Label()
        LogoutButton = New Button()
        NavigationPanel = New Panel()
        DeliveryPageButton = New Button()
        ReservationPageButton = New Button()
        ReportingAnalyticsButton = New Button()
        OrderHistoryButton = New Button()
        BillingButton = New Button()
        TableManagementButton = New Button()
        ContentPanel = New Panel()
        TopPanel.SuspendLayout()
        NavigationPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' TopPanel
        ' 
        TopPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TopPanel.BackColor = SystemColors.ActiveCaption
        TopPanel.Controls.Add(LogoLabel)
        TopPanel.Controls.Add(LogoutButton)
        TopPanel.Location = New Point(0, 0)
        TopPanel.Name = "TopPanel"
        TopPanel.Size = New Size(1920, 60)
        TopPanel.TabIndex = 0
        ' 
        ' LogoLabel
        ' 
        LogoLabel.Anchor = AnchorStyles.None
        LogoLabel.AutoSize = True
        LogoLabel.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        LogoLabel.ForeColor = Color.White
        LogoLabel.Location = New Point(860, 15)
        LogoLabel.Name = "LogoLabel"
        LogoLabel.Size = New Size(116, 30)
        LogoLabel.TabIndex = 1
        LogoLabel.Text = "Grill Mate"
        LogoLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LogoutButton
        ' 
        LogoutButton.Anchor = AnchorStyles.Left
        LogoutButton.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        LogoutButton.FlatAppearance.BorderSize = 0
        LogoutButton.FlatStyle = FlatStyle.Flat
        LogoutButton.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        LogoutButton.ForeColor = Color.White
        LogoutButton.Location = New Point(22, 15)
        LogoutButton.Name = "LogoutButton"
        LogoutButton.Size = New Size(100, 30)
        LogoutButton.TabIndex = 0
        LogoutButton.Text = "Logout"
        LogoutButton.UseVisualStyleBackColor = False
        ' 
        ' NavigationPanel
        ' 
        NavigationPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        NavigationPanel.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        NavigationPanel.Controls.Add(DeliveryPageButton)
        NavigationPanel.Controls.Add(ReservationPageButton)
        NavigationPanel.Controls.Add(ReportingAnalyticsButton)
        NavigationPanel.Controls.Add(OrderHistoryButton)
        NavigationPanel.Controls.Add(BillingButton)
        NavigationPanel.Controls.Add(TableManagementButton)
        NavigationPanel.Location = New Point(0, 60)
        NavigationPanel.Name = "NavigationPanel"
        NavigationPanel.Size = New Size(250, 1020)
        NavigationPanel.TabIndex = 1
        ' 
        ' DeliveryPageButton
        ' 
        DeliveryPageButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        DeliveryPageButton.FlatAppearance.BorderSize = 0
        DeliveryPageButton.FlatStyle = FlatStyle.Flat
        DeliveryPageButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        DeliveryPageButton.ForeColor = Color.White
        DeliveryPageButton.Location = New Point(12, 295)
        DeliveryPageButton.Name = "DeliveryPageButton"
        DeliveryPageButton.Size = New Size(230, 50)
        DeliveryPageButton.TabIndex = 5
        DeliveryPageButton.Text = "Delivery Page"
        DeliveryPageButton.UseVisualStyleBackColor = False
        ' 
        ' ReservationPageButton
        ' 
        ReservationPageButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        ReservationPageButton.FlatAppearance.BorderSize = 0
        ReservationPageButton.FlatStyle = FlatStyle.Flat
        ReservationPageButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        ReservationPageButton.ForeColor = Color.White
        ReservationPageButton.Location = New Point(12, 239)
        ReservationPageButton.Name = "ReservationPageButton"
        ReservationPageButton.Size = New Size(230, 50)
        ReservationPageButton.TabIndex = 4
        ReservationPageButton.Text = "Reservation Page"
        ReservationPageButton.UseVisualStyleBackColor = False
        ' 
        ' ReportingAnalyticsButton
        ' 
        ReportingAnalyticsButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        ReportingAnalyticsButton.FlatAppearance.BorderSize = 0
        ReportingAnalyticsButton.FlatStyle = FlatStyle.Flat
        ReportingAnalyticsButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        ReportingAnalyticsButton.ForeColor = Color.White
        ReportingAnalyticsButton.Location = New Point(12, 183)
        ReportingAnalyticsButton.Name = "ReportingAnalyticsButton"
        ReportingAnalyticsButton.Size = New Size(230, 50)
        ReportingAnalyticsButton.TabIndex = 3
        ReportingAnalyticsButton.Text = "Reporting & Analytics"
        ReportingAnalyticsButton.UseVisualStyleBackColor = False
        ' 
        ' OrderHistoryButton
        ' 
        OrderHistoryButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        OrderHistoryButton.FlatAppearance.BorderSize = 0
        OrderHistoryButton.FlatStyle = FlatStyle.Flat
        OrderHistoryButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        OrderHistoryButton.ForeColor = Color.White
        OrderHistoryButton.Location = New Point(12, 127)
        OrderHistoryButton.Name = "OrderHistoryButton"
        OrderHistoryButton.Size = New Size(230, 50)
        OrderHistoryButton.TabIndex = 2
        OrderHistoryButton.Text = "Order History"
        OrderHistoryButton.UseVisualStyleBackColor = False
        ' 
        ' BillingButton
        ' 
        BillingButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        BillingButton.FlatAppearance.BorderSize = 0
        BillingButton.FlatStyle = FlatStyle.Flat
        BillingButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        BillingButton.ForeColor = Color.White
        BillingButton.Location = New Point(12, 71)
        BillingButton.Name = "BillingButton"
        BillingButton.Size = New Size(230, 50)
        BillingButton.TabIndex = 1
        BillingButton.Text = "Billing"
        BillingButton.UseVisualStyleBackColor = False
        ' 
        ' TableManagementButton
        ' 
        TableManagementButton.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        TableManagementButton.FlatAppearance.BorderSize = 0
        TableManagementButton.FlatStyle = FlatStyle.Flat
        TableManagementButton.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        TableManagementButton.ForeColor = Color.White
        TableManagementButton.Location = New Point(12, 15)
        TableManagementButton.Name = "TableManagementButton"
        TableManagementButton.Size = New Size(230, 50)
        TableManagementButton.TabIndex = 0
        TableManagementButton.Text = "Table Management"
        TableManagementButton.UseVisualStyleBackColor = False
        ' 
        ' ContentPanel
        ' 
        ContentPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ContentPanel.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        ContentPanel.Location = New Point(250, 60)
        ContentPanel.Name = "ContentPanel"
        ContentPanel.Size = New Size(1670, 1020)
        ContentPanel.TabIndex = 2
        ' 
        ' StaffMenuDashboard
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(1920, 1080)
        Controls.Add(ContentPanel)
        Controls.Add(NavigationPanel)
        Controls.Add(TopPanel)
        FormBorderStyle = FormBorderStyle.None
        Name = "StaffMenuDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Grill Mate - Staff Dashboard"
        WindowState = FormWindowState.Maximized
        TopPanel.ResumeLayout(False)
        TopPanel.PerformLayout()
        NavigationPanel.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
End Class
