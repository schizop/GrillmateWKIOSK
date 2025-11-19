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
        lblSubtotal = New Label()
        lblDiscount = New Label()
        lblTax = New Label()
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
        lblTitle.Size = New Size(299, 37)
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
        lblTableNumber.Size = New Size(96, 27)
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
        flpOrderItems.Size = New Size(420, 250)
        flpOrderItems.TabIndex = 2
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Font = New Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtotal.ForeColor = Color.White
        lblSubtotal.Location = New Point(50, 400)
        lblSubtotal.Margin = New Padding(4, 0, 4, 0)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(140, 22)
        lblSubtotal.TabIndex = 3
        lblSubtotal.Text = "Subtotal: ₱0.00"
        ' 
        ' lblDiscount
        ' 
        lblDiscount.AutoSize = True
        lblDiscount.Font = New Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiscount.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        lblDiscount.Location = New Point(50, 430)
        lblDiscount.Margin = New Padding(4, 0, 4, 0)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(140, 22)
        lblDiscount.TabIndex = 4
        lblDiscount.Text = "Discount: ₱0.00"
        lblDiscount.Visible = False
        ' 
        ' lblTax
        ' 
        lblTax.AutoSize = True
        lblTax.Font = New Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTax.ForeColor = Color.White
        lblTax.Location = New Point(50, 460)
        lblTax.Margin = New Padding(4, 0, 4, 0)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(140, 22)
        lblTax.TabIndex = 5
        lblTax.Text = "Tax VAT: ₱0.00"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(50, 490)
        lblTotal.Margin = New Padding(4, 0, 4, 0)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(194, 32)
        lblTotal.TabIndex = 6
        lblTotal.Text = "TOTAL: ₱0.00"
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnConfirm.FlatAppearance.BorderSize = 0
        btnConfirm.FlatStyle = FlatStyle.Flat
        btnConfirm.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirm.ForeColor = Color.White
        btnConfirm.Location = New Point(50, 540)
        btnConfirm.Margin = New Padding(4, 3, 4, 3)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(150, 60)
        btnConfirm.TabIndex = 7
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
        btnCancel.Location = New Point(220, 540)
        btnCancel.Margin = New Padding(4, 3, 4, 3)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(150, 60)
        btnCancel.TabIndex = 8
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' OrderSummaryConfirmation
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(52), CByte(58), CByte(64))
        Controls.Add(btnCancel)
        Controls.Add(btnConfirm)
        Controls.Add(lblTotal)
        Controls.Add(lblTax)
        Controls.Add(lblDiscount)
        Controls.Add(lblSubtotal)
        Controls.Add(flpOrderItems)
        Controls.Add(lblTableNumber)
        Controls.Add(lblTitle)
        Margin = New Padding(4, 3, 4, 3)
        Name = "OrderSummaryConfirmation"
        Size = New Size(500, 620)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTableNumber As Label
    Friend WithEvents flpOrderItems As FlowLayoutPanel
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
End Class