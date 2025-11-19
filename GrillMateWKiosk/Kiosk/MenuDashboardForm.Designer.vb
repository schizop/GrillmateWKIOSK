<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuDashboardForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        pnlCart = New Panel()
        lblCartTitle = New Label()
        pnlCartItems = New Panel()
        lblSubtotal = New Label()
        chkPwdSeniorDiscount = New CheckBox()
        lblDiscount = New Label()
        lblTax = New Label()
        lblTotal = New Label()
        btnCheckout = New Button()
        pnlCategories = New Panel()
        lblCategoriesTitle = New Label()
        flpCategories = New FlowLayoutPanel()
        pnlProducts = New Panel()
        lblProductsTitle = New Label()
        flpProducts = New FlowLayoutPanel()
        btnCancelOrder = New Button()
        pnlCart.SuspendLayout()
        pnlCategories.SuspendLayout()
        pnlProducts.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlCart
        ' 
        pnlCart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        pnlCart.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlCart.BorderStyle = BorderStyle.FixedSingle
        pnlCart.Controls.Add(lblCartTitle)
        pnlCart.Controls.Add(pnlCartItems)
        pnlCart.Controls.Add(lblSubtotal)
        pnlCart.Controls.Add(chkPwdSeniorDiscount)
        pnlCart.Controls.Add(lblDiscount)
        pnlCart.Controls.Add(lblTax)
        pnlCart.Controls.Add(lblTotal)
        pnlCart.Controls.Add(btnCheckout)
        pnlCart.Location = New Point(1604, 35)
        pnlCart.Name = "pnlCart"
        pnlCart.Size = New Size(300, 1006)
        pnlCart.TabIndex = 2
        ' 
        ' lblCartTitle
        ' 
        lblCartTitle.AutoSize = True
        lblCartTitle.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCartTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCartTitle.Location = New Point(9, 22)
        lblCartTitle.Name = "lblCartTitle"
        lblCartTitle.Size = New Size(60, 29)
        lblCartTitle.TabIndex = 0
        lblCartTitle.Text = "Cart"
        ' 
        ' pnlCartItems
        ' 
        pnlCartItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCartItems.AutoScroll = True
        pnlCartItems.Location = New Point(9, 68)
        pnlCartItems.Name = "pnlCartItems"
        pnlCartItems.Size = New Size(286, 717)
        pnlCartItems.TabIndex = 1
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblSubtotal.AutoSize = True
        lblSubtotal.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtotal.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblSubtotal.Location = New Point(9, 797)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(115, 18)
        lblSubtotal.TabIndex = 2
        lblSubtotal.Text = "Subtotal: ₱0.00"
        ' 
        ' chkPwdSeniorDiscount
        ' 
        chkPwdSeniorDiscount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        chkPwdSeniorDiscount.AutoSize = True
        chkPwdSeniorDiscount.Font = New Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkPwdSeniorDiscount.Location = New Point(9, 821)
        chkPwdSeniorDiscount.Name = "chkPwdSeniorDiscount"
        chkPwdSeniorDiscount.Size = New Size(214, 21)
        chkPwdSeniorDiscount.TabIndex = 3
        chkPwdSeniorDiscount.Text = "PWD/Senior Discount (20%)"
        chkPwdSeniorDiscount.UseVisualStyleBackColor = True
        ' 
        ' lblDiscount
        ' 
        lblDiscount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblDiscount.AutoSize = True
        lblDiscount.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiscount.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        lblDiscount.Location = New Point(9, 847)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(119, 18)
        lblDiscount.TabIndex = 4
        lblDiscount.Text = "Discount: ₱0.00"
        lblDiscount.Visible = False
        ' 
        ' lblTax
        ' 
        lblTax.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTax.AutoSize = True
        lblTax.Font = New Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTax.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblTax.Location = New Point(9, 872)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(112, 18)
        lblTax.TabIndex = 5
        lblTax.Text = "Tax VAT: ₱0.00"
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblTotal.Location = New Point(9, 897)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(132, 26)
        lblTotal.TabIndex = 6
        lblTotal.Text = "Total: ₱0.00"
        ' 
        ' btnCheckout
        ' 
        btnCheckout.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCheckout.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnCheckout.FlatAppearance.BorderSize = 0
        btnCheckout.FlatStyle = FlatStyle.Flat
        btnCheckout.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCheckout.ForeColor = Color.White
        btnCheckout.Location = New Point(9, 937)
        btnCheckout.Name = "btnCheckout"
        btnCheckout.Size = New Size(253, 50)
        btnCheckout.TabIndex = 7
        btnCheckout.Text = "Checkout"
        btnCheckout.UseVisualStyleBackColor = False
        ' 
        ' pnlCategories
        ' 
        pnlCategories.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        pnlCategories.BackColor = Color.FromArgb(CByte(248), CByte(249), CByte(250))
        pnlCategories.BorderStyle = BorderStyle.FixedSingle
        pnlCategories.Controls.Add(lblCategoriesTitle)
        pnlCategories.Controls.Add(flpCategories)
        pnlCategories.Location = New Point(0, 35)
        pnlCategories.Name = "pnlCategories"
        pnlCategories.Size = New Size(200, 1006)
        pnlCategories.TabIndex = 1
        ' 
        ' lblCategoriesTitle
        ' 
        lblCategoriesTitle.AutoSize = True
        lblCategoriesTitle.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategoriesTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCategoriesTitle.Location = New Point(23, 23)
        lblCategoriesTitle.Name = "lblCategoriesTitle"
        lblCategoriesTitle.Size = New Size(136, 29)
        lblCategoriesTitle.TabIndex = 0
        lblCategoriesTitle.Text = "Categories"
        ' 
        ' flpCategories
        ' 
        flpCategories.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        flpCategories.AutoScroll = True
        flpCategories.Location = New Point(23, 69)
        flpCategories.Name = "flpCategories"
        flpCategories.Size = New Size(154, 932)
        flpCategories.TabIndex = 1
        ' 
        ' pnlProducts
        ' 
        pnlProducts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlProducts.BackColor = Color.White
        pnlProducts.Controls.Add(lblProductsTitle)
        pnlProducts.Controls.Add(flpProducts)
        pnlProducts.Location = New Point(200, 35)
        pnlProducts.Name = "pnlProducts"
        pnlProducts.Size = New Size(1404, 1006)
        pnlProducts.TabIndex = 0
        ' 
        ' lblProductsTitle
        ' 
        lblProductsTitle.AutoSize = True
        lblProductsTitle.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProductsTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblProductsTitle.Location = New Point(35, 23)
        lblProductsTitle.Name = "lblProductsTitle"
        lblProductsTitle.Size = New Size(117, 29)
        lblProductsTitle.TabIndex = 0
        lblProductsTitle.Text = "Products"
        ' 
        ' flpProducts
        ' 
        flpProducts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        flpProducts.AutoScroll = True
        flpProducts.Location = New Point(35, 69)
        flpProducts.Name = "flpProducts"
        flpProducts.Size = New Size(1354, 949)
        flpProducts.TabIndex = 1
        ' 
        ' btnCancelOrder
        ' 
        btnCancelOrder.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnCancelOrder.Dock = DockStyle.Top
        btnCancelOrder.FlatAppearance.BorderSize = 0
        btnCancelOrder.FlatStyle = FlatStyle.Flat
        btnCancelOrder.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelOrder.ForeColor = Color.White
        btnCancelOrder.Location = New Point(0, 0)
        btnCancelOrder.Name = "btnCancelOrder"
        btnCancelOrder.Size = New Size(1904, 35)
        btnCancelOrder.TabIndex = 3
        btnCancelOrder.Text = "✕ CANCEL ORDER"
        btnCancelOrder.UseVisualStyleBackColor = False
        ' 
        ' MenuDashboardForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1904, 1041)
        Controls.Add(pnlCart)
        Controls.Add(pnlCategories)
        Controls.Add(pnlProducts)
        Controls.Add(btnCancelOrder)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "MenuDashboardForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate - Menu Dashboard"
        pnlCart.ResumeLayout(False)
        pnlCart.PerformLayout()
        pnlCategories.ResumeLayout(False)
        pnlCategories.PerformLayout()
        pnlProducts.ResumeLayout(False)
        pnlProducts.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlCart As Panel
    Friend WithEvents lblCartTitle As Label
    Friend WithEvents pnlCartItems As Panel
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents chkPwdSeniorDiscount As CheckBox
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnCheckout As Button
    Friend WithEvents pnlCategories As Panel
    Friend WithEvents lblCategoriesTitle As Label
    Friend WithEvents flpCategories As FlowLayoutPanel
    Friend WithEvents pnlProducts As Panel
    Friend WithEvents lblProductsTitle As Label
    Friend WithEvents flpProducts As FlowLayoutPanel
    Friend WithEvents btnCancelOrder As Button
End Class