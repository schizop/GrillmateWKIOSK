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
        lblTotal = New Label()
        btnCheckout = New Button()
        pnlCategories = New Panel()
        lblCategoriesTitle = New Label()
        flpCategories = New FlowLayoutPanel()
        pnlProducts = New Panel()
        lblProductsTitle = New Label()
        flpProducts = New FlowLayoutPanel()
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
        pnlCart.Controls.Add(lblTotal)
        pnlCart.Controls.Add(btnCheckout)
        pnlCart.Location = New Point(1604, 0)
        pnlCart.Name = "pnlCart"
        pnlCart.Size = New Size(300, 1041)
        pnlCart.TabIndex = 2
        ' 
        ' lblCartTitle
        ' 
        lblCartTitle.AutoSize = True
        lblCartTitle.Font = New Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCartTitle.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblCartTitle.Location = New Point(23, 23)
        lblCartTitle.Name = "lblCartTitle"
        lblCartTitle.Size = New Size(60, 29)
        lblCartTitle.TabIndex = 0
        lblCartTitle.Text = "Cart"
        ' 
        ' pnlCartItems
        ' 
        pnlCartItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCartItems.AutoScroll = True
        pnlCartItems.Location = New Point(23, 69)
        pnlCartItems.Name = "pnlCartItems"
        pnlCartItems.Size = New Size(253, 841)
        pnlCartItems.TabIndex = 1
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = Color.FromArgb(CByte(33), CByte(37), CByte(41))
        lblTotal.Location = New Point(23, 931)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(132, 26)
        lblTotal.TabIndex = 2
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
        btnCheckout.Location = New Point(23, 971)
        btnCheckout.Name = "btnCheckout"
        btnCheckout.Size = New Size(253, 50)
        btnCheckout.TabIndex = 3
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
        pnlCategories.Location = New Point(0, 0)
        pnlCategories.Name = "pnlCategories"
        pnlCategories.Size = New Size(200, 1041)
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
        flpCategories.Size = New Size(154, 949)
        flpCategories.TabIndex = 1
        ' 
        ' pnlProducts
        ' 
        pnlProducts.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlProducts.BackColor = Color.White
        pnlProducts.Controls.Add(lblProductsTitle)
        pnlProducts.Controls.Add(flpProducts)
        pnlProducts.Location = New Point(200, 0)
        pnlProducts.Name = "pnlProducts"
        pnlProducts.Size = New Size(1404, 1041)
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
        ' MenuDashboardForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1904, 1041)
        Controls.Add(pnlCart)
        Controls.Add(pnlCategories)
        Controls.Add(pnlProducts)
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
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnCheckout As Button
    Friend WithEvents pnlCategories As Panel
    Friend WithEvents lblCategoriesTitle As Label
    Friend WithEvents flpCategories As FlowLayoutPanel
    Friend WithEvents pnlProducts As Panel
    Friend WithEvents lblProductsTitle As Label
    Friend WithEvents flpProducts As FlowLayoutPanel
End Class