<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CartItemControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        lblItemName = New Label()
        lblPrice = New Label()
        lblSubtotal = New Label()
        btnDecrease = New Button()
        lblQuantity = New Label()
        btnIncrease = New Button()
        btnRemove = New Button()
        SuspendLayout()
        ' 
        ' lblItemName
        ' 
        lblItemName.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemName.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblItemName.Location = New Point(6, 6)
        lblItemName.Margin = New Padding(4, 0, 4, 0)
        lblItemName.Name = "lblItemName"
        lblItemName.Size = New Size(140, 23)
        lblItemName.TabIndex = 0
        lblItemName.Text = "Item Name"
        ' 
        ' lblPrice
        ' 
        lblPrice.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPrice.ForeColor = Color.Gray
        lblPrice.Location = New Point(6, 29)
        lblPrice.Margin = New Padding(4, 0, 4, 0)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(70, 17)
        lblPrice.TabIndex = 1
        lblPrice.Text = "₱0.00 each"
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSubtotal.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        lblSubtotal.Location = New Point(82, 29)
        lblSubtotal.Margin = New Padding(4, 0, 4, 0)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(70, 17)
        lblSubtotal.TabIndex = 2
        lblSubtotal.Text = "₱0.00"
        ' 
        ' btnDecrease
        ' 
        btnDecrease.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnDecrease.Cursor = Cursors.Hand
        btnDecrease.FlatAppearance.BorderSize = 0
        btnDecrease.FlatStyle = FlatStyle.Flat
        btnDecrease.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDecrease.ForeColor = Color.White
        btnDecrease.Location = New Point(163, 23)
        btnDecrease.Margin = New Padding(4, 3, 4, 3)
        btnDecrease.Name = "btnDecrease"
        btnDecrease.Size = New Size(29, 29)
        btnDecrease.TabIndex = 3
        btnDecrease.Text = "-"
        btnDecrease.UseVisualStyleBackColor = False
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQuantity.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblQuantity.Location = New Point(198, 23)
        lblQuantity.Margin = New Padding(4, 0, 4, 0)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(35, 29)
        lblQuantity.TabIndex = 4
        lblQuantity.Text = "1"
        lblQuantity.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnIncrease
        ' 
        btnIncrease.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnIncrease.Cursor = Cursors.Hand
        btnIncrease.FlatAppearance.BorderSize = 0
        btnIncrease.FlatStyle = FlatStyle.Flat
        btnIncrease.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIncrease.ForeColor = Color.White
        btnIncrease.Location = New Point(239, 23)
        btnIncrease.Margin = New Padding(4, 3, 4, 3)
        btnIncrease.Name = "btnIncrease"
        btnIncrease.Size = New Size(29, 29)
        btnIncrease.TabIndex = 5
        btnIncrease.Text = "+"
        btnIncrease.UseVisualStyleBackColor = False
        ' 
        ' btnRemove
        ' 
        btnRemove.BackColor = Color.Transparent
        btnRemove.Cursor = Cursors.Hand
        btnRemove.FlatAppearance.BorderSize = 0
        btnRemove.FlatStyle = FlatStyle.Flat
        btnRemove.Font = New Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRemove.ForeColor = Color.Red
        btnRemove.Location = New Point(245, -6)
        btnRemove.Margin = New Padding(4, 3, 4, 3)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(23, 35)
        btnRemove.TabIndex = 6
        btnRemove.Text = "×"
        btnRemove.UseVisualStyleBackColor = False
        ' 
        ' CartItemControl
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(lblItemName)
        Controls.Add(lblPrice)
        Controls.Add(lblSubtotal)
        Controls.Add(btnDecrease)
        Controls.Add(lblQuantity)
        Controls.Add(btnIncrease)
        Controls.Add(btnRemove)
        Margin = New Padding(2)
        Name = "CartItemControl"
        Size = New Size(275, 67)
        ResumeLayout(False)

    End Sub

    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents btnDecrease As System.Windows.Forms.Button
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents btnIncrease As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button

End Class


