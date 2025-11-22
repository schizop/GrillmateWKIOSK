<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_ManualOrderEntry

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlLeft = New Panel()
        pnlReservationList = New Panel()
        lblReservations = New Label()
        flpReservations = New FlowLayoutPanel()
        pnlDeliveryNote = New Panel()
        lblDeliveryNote = New Label()
        lblTable = New Label()
        cmbTable = New ComboBox()
        pnlReservationContext = New Panel()
        lblReservationInfo = New Label()
        grpOrderType = New GroupBox()
        rdoTakeout = New RadioButton()
        rdoDineIn = New RadioButton()
        rdoDelivery = New RadioButton()
        rdoReservation = New RadioButton()
        pnlCenter = New Panel()
        flpProducts = New FlowLayoutPanel()
        flpCategories = New FlowLayoutPanel()
        lblCategories = New Label()
        pnlRight = New Panel()
        grpPayment = New GroupBox()
        radGCash = New RadioButton()
        radCash = New RadioButton()
        btnCreateOrderAndPay = New Button()
        grpCart = New GroupBox()
        lblTotal = New Label()
        lblTax = New Label()
        lblDiscount = New Label()
        lblSubtotal = New Label()
        chkPwdSeniorDiscount = New CheckBox()
        pnlCartItems = New Panel()
        pnlLeft.SuspendLayout()
        pnlReservationList.SuspendLayout()
        pnlDeliveryNote.SuspendLayout()
        pnlReservationContext.SuspendLayout()
        grpOrderType.SuspendLayout()
        pnlCenter.SuspendLayout()
        pnlRight.SuspendLayout()
        grpPayment.SuspendLayout()
        grpCart.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.WhiteSmoke
        pnlLeft.Controls.Add(pnlDeliveryNote)
        pnlLeft.Controls.Add(pnlReservationList)
        pnlLeft.Controls.Add(lblTable)
        pnlLeft.Controls.Add(cmbTable)
        pnlLeft.Controls.Add(pnlReservationContext)
        pnlLeft.Controls.Add(grpOrderType)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Padding = New Padding(15)
        pnlLeft.Size = New Size(280, 1020)
        pnlLeft.TabIndex = 0
        ' 
        ' pnlReservationList
        ' 
        pnlReservationList.Controls.Add(flpReservations)
        pnlReservationList.Controls.Add(lblReservations)
        pnlReservationList.Dock = DockStyle.Top
        pnlReservationList.Location = New Point(15, 290)
        pnlReservationList.Name = "pnlReservationList"
        pnlReservationList.Size = New Size(250, 300)
        pnlReservationList.TabIndex = 5
        pnlReservationList.Visible = False
        ' 
        ' flpReservations
        ' 
        flpReservations.AutoScroll = True
        flpReservations.BackColor = Color.White
        flpReservations.Dock = DockStyle.Fill
        flpReservations.FlowDirection = FlowDirection.TopDown
        flpReservations.Location = New Point(0, 25)
        flpReservations.Name = "flpReservations"
        flpReservations.Padding = New Padding(5)
        flpReservations.Size = New Size(250, 275)
        flpReservations.TabIndex = 1
        ' 
        ' lblReservations
        ' 
        lblReservations.AutoSize = True
        lblReservations.Dock = DockStyle.Top
        lblReservations.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblReservations.Location = New Point(0, 0)
        lblReservations.Name = "lblReservations"
        lblReservations.Size = New Size(82, 15)
        lblReservations.TabIndex = 0
        lblReservations.Text = "Reservations:"
        ' 
        ' pnlDeliveryNote
        ' 
        pnlDeliveryNote.Controls.Add(lblDeliveryNote)
        pnlDeliveryNote.Dock = DockStyle.Top
        pnlDeliveryNote.Location = New Point(15, 210)
        pnlDeliveryNote.Name = "pnlDeliveryNote"
        pnlDeliveryNote.Padding = New Padding(0, 15, 0, 0)
        pnlDeliveryNote.Size = New Size(250, 80)
        pnlDeliveryNote.TabIndex = 4
        ' 
        ' lblDeliveryNote
        ' 
        lblDeliveryNote.AutoSize = True
        lblDeliveryNote.ForeColor = Color.DimGray
        lblDeliveryNote.Location = New Point(3, 15)
        lblDeliveryNote.Name = "lblDeliveryNote"
        lblDeliveryNote.Size = New Size(197, 45)
        lblDeliveryNote.TabIndex = 0
        lblDeliveryNote.Text = "For Delivery orders, customer name," & vbLf & "address and contact will be filled in" & vbLf & "the Delivery page after payment."
        ' 
        ' lblTable
        ' 
        lblTable.AutoSize = True
        lblTable.Location = New Point(18, 225)
        lblTable.Name = "lblTable"
        lblTable.Size = New Size(37, 15)
        lblTable.TabIndex = 2
        lblTable.Text = "Table:"
        ' 
        ' cmbTable
        ' 
        cmbTable.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTable.FormattingEnabled = True
        cmbTable.Location = New Point(18, 245)
        cmbTable.Name = "cmbTable"
        cmbTable.Size = New Size(230, 23)
        cmbTable.TabIndex = 3
        ' 
        ' pnlReservationContext
        ' 
        pnlReservationContext.Controls.Add(lblReservationInfo)
        pnlReservationContext.Dock = DockStyle.Top
        pnlReservationContext.Location = New Point(15, 150)
        pnlReservationContext.Name = "pnlReservationContext"
        pnlReservationContext.Padding = New Padding(0, 10, 0, 10)
        pnlReservationContext.Size = New Size(250, 60)
        pnlReservationContext.TabIndex = 1
        ' 
        ' lblReservationInfo
        ' 
        lblReservationInfo.AutoSize = True
        lblReservationInfo.ForeColor = Color.DimGray
        lblReservationInfo.Location = New Point(3, 10)
        lblReservationInfo.Name = "lblReservationInfo"
        lblReservationInfo.Size = New Size(241, 45)
        lblReservationInfo.TabIndex = 0
        lblReservationInfo.Text = "Reservation context (e.g. selected" & vbLf & "reservation info) can be shown here." & vbLf & "Customer info itself stays in UC_Reservation."
        ' 
        ' grpOrderType
        ' 
        grpOrderType.Controls.Add(rdoTakeout)
        grpOrderType.Controls.Add(rdoDineIn)
        grpOrderType.Controls.Add(rdoDelivery)
        grpOrderType.Controls.Add(rdoReservation)
        grpOrderType.Dock = DockStyle.Top
        grpOrderType.Location = New Point(15, 15)
        grpOrderType.Name = "grpOrderType"
        grpOrderType.Size = New Size(250, 135)
        grpOrderType.TabIndex = 0
        grpOrderType.TabStop = False
        grpOrderType.Text = "Order Type"
        ' 
        ' rdoTakeout
        ' 
        rdoTakeout.AutoSize = True
        rdoTakeout.Location = New Point(18, 100)
        rdoTakeout.Name = "rdoTakeout"
        rdoTakeout.Size = New Size(66, 19)
        rdoTakeout.TabIndex = 3
        rdoTakeout.TabStop = True
        rdoTakeout.Text = "Takeout"
        rdoTakeout.UseVisualStyleBackColor = True
        ' 
        ' rdoDineIn
        ' 
        rdoDineIn.AutoSize = True
        rdoDineIn.Location = New Point(18, 75)
        rdoDineIn.Name = "rdoDineIn"
        rdoDineIn.Size = New Size(64, 19)
        rdoDineIn.TabIndex = 2
        rdoDineIn.TabStop = True
        rdoDineIn.Text = "Dine-In"
        rdoDineIn.UseVisualStyleBackColor = True
        ' 
        ' rdoDelivery
        ' 
        rdoDelivery.AutoSize = True
        rdoDelivery.Location = New Point(18, 50)
        rdoDelivery.Name = "rdoDelivery"
        rdoDelivery.Size = New Size(67, 19)
        rdoDelivery.TabIndex = 1
        rdoDelivery.TabStop = True
        rdoDelivery.Text = "Delivery"
        rdoDelivery.UseVisualStyleBackColor = True
        ' 
        ' rdoReservation
        ' 
        rdoReservation.AutoSize = True
        rdoReservation.Location = New Point(18, 25)
        rdoReservation.Name = "rdoReservation"
        rdoReservation.Size = New Size(86, 19)
        rdoReservation.TabIndex = 0
        rdoReservation.TabStop = True
        rdoReservation.Text = "Reservation"
        rdoReservation.UseVisualStyleBackColor = True
        ' 
        ' pnlCenter
        ' 
        pnlCenter.BackColor = Color.White
        pnlCenter.Controls.Add(flpProducts)
        pnlCenter.Controls.Add(flpCategories)
        pnlCenter.Controls.Add(lblCategories)
        pnlCenter.Dock = DockStyle.Fill
        pnlCenter.Location = New Point(280, 0)
        pnlCenter.Name = "pnlCenter"
        pnlCenter.Padding = New Padding(15)
        pnlCenter.Size = New Size(1040, 1020)
        pnlCenter.TabIndex = 1
        ' 
        ' flpProducts
        ' 
        flpProducts.AutoScroll = True
        flpProducts.BackColor = Color.White
        flpProducts.Dock = DockStyle.Fill
        flpProducts.Location = New Point(15, 99)
        flpProducts.Name = "flpProducts"
        flpProducts.Padding = New Padding(5)
        flpProducts.Size = New Size(1010, 906)
        flpProducts.TabIndex = 2
        ' 
        ' flpCategories
        ' 
        flpCategories.AutoScroll = True
        flpCategories.BackColor = Color.WhiteSmoke
        flpCategories.Dock = DockStyle.Top
        flpCategories.Location = New Point(15, 34)
        flpCategories.Name = "flpCategories"
        flpCategories.Padding = New Padding(5)
        flpCategories.Size = New Size(1010, 65)
        flpCategories.TabIndex = 1
        ' 
        ' lblCategories
        ' 
        lblCategories.AutoSize = True
        lblCategories.Dock = DockStyle.Top
        lblCategories.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblCategories.Location = New Point(15, 15)
        lblCategories.Name = "lblCategories"
        lblCategories.Size = New Size(81, 19)
        lblCategories.TabIndex = 0
        lblCategories.Text = "Categories"
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.WhiteSmoke
        pnlRight.Controls.Add(grpPayment)
        pnlRight.Controls.Add(grpCart)
        pnlRight.Dock = DockStyle.Right
        pnlRight.Location = New Point(1320, 0)
        pnlRight.Name = "pnlRight"
        pnlRight.Padding = New Padding(15)
        pnlRight.Size = New Size(350, 1020)
        pnlRight.TabIndex = 2
        ' 
        ' grpPayment
        ' 
        grpPayment.Controls.Add(radGCash)
        grpPayment.Controls.Add(radCash)
        grpPayment.Controls.Add(btnCreateOrderAndPay)
        grpPayment.Dock = DockStyle.Bottom
        grpPayment.Location = New Point(15, 855)
        grpPayment.Name = "grpPayment"
        grpPayment.Size = New Size(320, 150)
        grpPayment.TabIndex = 1
        grpPayment.TabStop = False
        grpPayment.Text = "Payment"
        ' 
        ' radGCash
        ' 
        radGCash.AutoSize = True
        radGCash.Location = New Point(102, 25)
        radGCash.Name = "radGCash"
        radGCash.Size = New Size(59, 19)
        radGCash.TabIndex = 2
        radGCash.TabStop = True
        radGCash.Text = "GCash"
        radGCash.UseVisualStyleBackColor = True
        ' 
        ' radCash
        ' 
        radCash.AutoSize = True
        radCash.Location = New Point(23, 25)
        radCash.Name = "radCash"
        radCash.Size = New Size(51, 19)
        radCash.TabIndex = 1
        radCash.TabStop = True
        radCash.Text = "Cash"
        radCash.UseVisualStyleBackColor = True
        ' 
        ' btnCreateOrderAndPay
        ' 
        btnCreateOrderAndPay.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnCreateOrderAndPay.BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnCreateOrderAndPay.FlatAppearance.BorderSize = 0
        btnCreateOrderAndPay.FlatStyle = FlatStyle.Flat
        btnCreateOrderAndPay.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnCreateOrderAndPay.ForeColor = Color.White
        btnCreateOrderAndPay.Location = New Point(23, 70)
        btnCreateOrderAndPay.Name = "btnCreateOrderAndPay"
        btnCreateOrderAndPay.Size = New Size(274, 50)
        btnCreateOrderAndPay.TabIndex = 0
        btnCreateOrderAndPay.Text = "Create Order && Process Payment"
        btnCreateOrderAndPay.UseVisualStyleBackColor = False
        ' 
        ' grpCart
        ' 
        grpCart.Controls.Add(lblTotal)
        grpCart.Controls.Add(lblTax)
        grpCart.Controls.Add(lblDiscount)
        grpCart.Controls.Add(lblSubtotal)
        grpCart.Controls.Add(chkPwdSeniorDiscount)
        grpCart.Controls.Add(pnlCartItems)
        grpCart.Dock = DockStyle.Fill
        grpCart.Location = New Point(15, 15)
        grpCart.Name = "grpCart"
        grpCart.Size = New Size(320, 990)
        grpCart.TabIndex = 0
        grpCart.TabStop = False
        grpCart.Text = "Cart"
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblTotal.Location = New Point(18, 808)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(93, 20)
        lblTotal.TabIndex = 5
        lblTotal.Text = "Total: ₱0.00"
        ' 
        ' lblTax
        ' 
        lblTax.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTax.AutoSize = True
        lblTax.Location = New Point(18, 783)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(58, 15)
        lblTax.TabIndex = 4
        lblTax.Text = "Tax: ₱0.00"
        ' 
        ' lblDiscount
        ' 
        lblDiscount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblDiscount.AutoSize = True
        lblDiscount.Location = New Point(18, 783)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(88, 15)
        lblDiscount.TabIndex = 3
        lblDiscount.Text = "Discount: ₱0.00"
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(18, 733)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(85, 15)
        lblSubtotal.TabIndex = 2
        lblSubtotal.Text = "Subtotal: ₱0.00"
        ' 
        ' chkPwdSeniorDiscount
        ' 
        chkPwdSeniorDiscount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        chkPwdSeniorDiscount.AutoSize = True
        chkPwdSeniorDiscount.Location = New Point(18, 758)
        chkPwdSeniorDiscount.Name = "chkPwdSeniorDiscount"
        chkPwdSeniorDiscount.Size = New Size(165, 19)
        chkPwdSeniorDiscount.TabIndex = 1
        chkPwdSeniorDiscount.Text = "PWD/Senior 20% Discount"
        chkPwdSeniorDiscount.UseVisualStyleBackColor = True
        ' 
        ' pnlCartItems
        ' 
        pnlCartItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCartItems.AutoScroll = True
        pnlCartItems.BackColor = Color.White
        pnlCartItems.BorderStyle = BorderStyle.FixedSingle
        pnlCartItems.Location = New Point(18, 25)
        pnlCartItems.Name = "pnlCartItems"
        pnlCartItems.Size = New Size(284, 697)
        pnlCartItems.TabIndex = 0
        ' 
        ' UC_ManualOrderEntry
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlCenter)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        MaximumSize = New Size(1670, 1020)
        MinimumSize = New Size(1670, 1020)
        Name = "UC_ManualOrderEntry"
        Size = New Size(1670, 1020)
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlReservationList.ResumeLayout(False)
        pnlReservationList.PerformLayout()
        pnlDeliveryNote.ResumeLayout(False)
        pnlDeliveryNote.PerformLayout()
        pnlReservationContext.ResumeLayout(False)
        pnlReservationContext.PerformLayout()
        grpOrderType.ResumeLayout(False)
        grpOrderType.PerformLayout()
        pnlCenter.ResumeLayout(False)
        pnlCenter.PerformLayout()
        pnlRight.ResumeLayout(False)
        grpPayment.ResumeLayout(False)
        grpPayment.PerformLayout()
        grpCart.ResumeLayout(False)
        grpCart.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlReservationList As Panel
    Friend WithEvents flpReservations As FlowLayoutPanel
    Friend WithEvents lblReservations As Label
    Friend WithEvents grpOrderType As GroupBox
    Friend WithEvents rdoTakeout As RadioButton
    Friend WithEvents rdoDineIn As RadioButton
    Friend WithEvents rdoDelivery As RadioButton
    Friend WithEvents rdoReservation As RadioButton
    Friend WithEvents pnlReservationContext As Panel
    Friend WithEvents lblReservationInfo As Label
    Friend WithEvents lblTable As Label
    Friend WithEvents cmbTable As ComboBox
    Friend WithEvents pnlDeliveryNote As Panel
    Friend WithEvents lblDeliveryNote As Label
    Friend WithEvents pnlCenter As Panel
    Friend WithEvents flpProducts As FlowLayoutPanel
    Friend WithEvents flpCategories As FlowLayoutPanel
    Friend WithEvents lblCategories As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents grpPayment As GroupBox
    Friend WithEvents radGCash As RadioButton
    Friend WithEvents radCash As RadioButton
    Friend WithEvents btnCreateOrderAndPay As Button
    Friend WithEvents grpCart As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTax As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents chkPwdSeniorDiscount As CheckBox
    Friend WithEvents pnlCartItems As Panel

End Class

