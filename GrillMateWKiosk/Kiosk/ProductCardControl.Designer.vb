<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductCardControl
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
        picProduct = New PictureBox()
        lblName = New Label()
        lblDescription = New Label()
        lblPrice = New Label()
        btnAdd = New Button()
        CType(picProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picProduct
        ' 
        picProduct.BackColor = Color.LightGray
        picProduct.BorderStyle = BorderStyle.FixedSingle
        picProduct.Location = New Point(10, 10)
        picProduct.Name = "picProduct"
        picProduct.Size = New Size(160, 100)
        picProduct.SizeMode = PictureBoxSizeMode.StretchImage
        picProduct.TabIndex = 0
        picProduct.TabStop = False
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblName.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblName.Location = New Point(10, 120)
        lblName.Name = "lblName"
        lblName.Size = New Size(160, 20)
        lblName.TabIndex = 1
        lblName.Text = "Product Name"
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDescription.ForeColor = Color.Gray
        lblDescription.Location = New Point(10, 145)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(160, 30)
        lblDescription.TabIndex = 2
        lblDescription.Text = "Product description"
        ' 
        ' lblPrice
        ' 
        lblPrice.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPrice.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        lblPrice.Location = New Point(10, 180)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(90, 25)
        lblPrice.TabIndex = 3
        lblPrice.Text = "₱0.00"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(110, 180)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(60, 30)
        btnAdd.TabIndex = 4
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' ProductCardControl
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(picProduct)
        Controls.Add(lblName)
        Controls.Add(lblDescription)
        Controls.Add(lblPrice)
        Controls.Add(btnAdd)
        Cursor = Cursors.Hand
        Margin = New Padding(8)
        Name = "ProductCardControl"
        Size = New Size(180, 220)
        CType(picProduct, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents picProduct As System.Windows.Forms.PictureBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button

End Class

