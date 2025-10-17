<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrderSummaryConfirmation
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblTableNumber = New Label()
        flpOrderItems = New FlowLayoutPanel()
        lblTotal = New Label()
        btnConfirm = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(50, 30)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(300, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "ORDER SUMMARY"
        ' 
        ' lblTableNumber
        ' 
        lblTableNumber.AutoSize = True
        lblTableNumber.Font = New Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTableNumber.ForeColor = Color.White
        lblTableNumber.Location = New Point(50, 80)
        lblTableNumber.Margin = New Padding(4, 0, 4, 0)
        lblTableNumber.Name = "lblTableNumber"
        lblTableNumber.Size = New Size(120, 27)
        lblTableNumber.TabIndex = 1
        lblTableNumber.Text = "Table: 1"
        ' 
        ' flpOrderItems
        ' 
        flpOrderItems.AutoScroll = True
        flpOrderItems.BackColor = Color.Transparent
        flpOrderItems.Location = New Point(50, 130)
        flpOrderItems.Margin = New Padding(4, 3, 4, 3)
        flpOrderItems.Name = "flpOrderItems"
        flpOrderItems.Size = New Size(420, 300)
        flpOrderItems.TabIndex = 2
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(50, 450)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(200, 32)
        lblTotal.TabIndex = 3
        lblTotal.Text = "TOTAL: ₱0.00"
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnConfirm.FlatAppearance.BorderSize = 0
        btnConfirm.FlatStyle = FlatStyle.Flat
        btnConfirm.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirm.ForeColor = Color.White
        btnConfirm.Location = New Point(50, 520)
        btnConfirm.Margin = New Padding(4, 3, 4, 3)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(150, 60)
        btnConfirm.TabIndex = 4
        btnConfirm.Text = "CONFIRM"
        btnConfirm.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(220, 520)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(150, 60)
        btnCancel.TabIndex = 5
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' OrderSummaryConfirmation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(52), CByte(58), CByte(64))
        Controls.Add(btnCancel)
        Controls.Add(btnConfirm)
        Controls.Add(lblTotal)
        Controls.Add(flpOrderItems)
        Controls.Add(lblTableNumber)
        Controls.Add(lblTitle)
        Margin = New Padding(4, 3, 4, 3)
        Name = "OrderSummaryConfirmation"
        Size = New Size(500, 600)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTableNumber As Label
    Friend WithEvents flpOrderItems As FlowLayoutPanel
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
End Class