<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservationCard
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
        lblCustomerName = New Label()
        lblTableInfo = New Label()
        lblTimeInfo = New Label()
        SuspendLayout()
        ' 
        ' lblCustomerName
        ' 
        lblCustomerName.AutoSize = True
        lblCustomerName.Cursor = Cursors.Hand
        lblCustomerName.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblCustomerName.Location = New Point(10, 8)
        lblCustomerName.Name = "lblCustomerName"
        lblCustomerName.Size = New Size(117, 19)
        lblCustomerName.TabIndex = 0
        lblCustomerName.Text = "Customer Name"
        ' 
        ' lblTableInfo
        ' 
        lblTableInfo.AutoSize = True
        lblTableInfo.Cursor = Cursors.Hand
        lblTableInfo.Font = New Font("Segoe UI", 8.5F)
        lblTableInfo.Location = New Point(10, 30)
        lblTableInfo.Name = "lblTableInfo"
        lblTableInfo.Size = New Size(80, 15)
        lblTableInfo.TabIndex = 1
        lblTableInfo.Text = "Table • Guests"
        ' 
        ' lblTimeInfo
        ' 
        lblTimeInfo.AutoSize = True
        lblTimeInfo.Cursor = Cursors.Hand
        lblTimeInfo.Font = New Font("Segoe UI", 8.5F)
        lblTimeInfo.Location = New Point(10, 48)
        lblTimeInfo.Name = "lblTimeInfo"
        lblTimeInfo.Size = New Size(60, 15)
        lblTimeInfo.TabIndex = 2
        lblTimeInfo.Text = "Date Time"
        ' 
        ' ReservationCard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(lblTimeInfo)
        Controls.Add(lblTableInfo)
        Controls.Add(lblCustomerName)
        Cursor = Cursors.Hand
        Margin = New Padding(5)
        Name = "ReservationCard"
        Size = New Size(195, 75)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblCustomerName As Label
    Friend WithEvents lblTableInfo As Label
    Friend WithEvents lblTimeInfo As Label

End Class
