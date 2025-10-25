﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_Billing
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        lblTitle = New Label()
        pnlOrderInput = New Panel()
        btnSearchOrder = New Button()
        txtOrderNumber = New TextBox()
        lblOrderNumber = New Label()
        pnlOrderDetails = New Panel()
        lstOrderItems = New ListView()
        colItem = New ColumnHeader()
        colQuantity = New ColumnHeader()
        colPrice = New ColumnHeader()
        colSubtotal = New ColumnHeader()
        lblOrderInfo = New Label()
        lblTotalAmount = New Label()
        pnlPayment = New Panel()
        btnProcessPayment = New Button()
        radGCash = New RadioButton()
        radCash = New RadioButton()
        lblPaymentMethod = New Label()
        pnlReceiptPreview = New Panel()
        btnPrintReceipt = New Button()
        txtReceiptPreview = New TextBox()
        lblReceiptPreview = New Label()
        pnlOrderInput.SuspendLayout()
        pnlOrderDetails.SuspendLayout()
        pnlPayment.SuspendLayout()
        pnlReceiptPreview.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTitle.Location = New Point(168, 108)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(137, 51)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Billing"
        ' 
        ' pnlOrderInput
        ' 
        pnlOrderInput.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlOrderInput.BorderStyle = BorderStyle.FixedSingle
        pnlOrderInput.Controls.Add(btnSearchOrder)
        pnlOrderInput.Controls.Add(txtOrderNumber)
        pnlOrderInput.Controls.Add(lblOrderNumber)
        pnlOrderInput.Location = New Point(168, 178)
        pnlOrderInput.Name = "pnlOrderInput"
        pnlOrderInput.Size = New Size(800, 120)
        pnlOrderInput.TabIndex = 1
        ' 
        ' btnSearchOrder
        ' 
        btnSearchOrder.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSearchOrder.FlatAppearance.BorderSize = 0
        btnSearchOrder.FlatStyle = FlatStyle.Flat
        btnSearchOrder.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearchOrder.ForeColor = Color.White
        btnSearchOrder.Location = New Point(600, 40)
        btnSearchOrder.Name = "btnSearchOrder"
        btnSearchOrder.Size = New Size(150, 45)
        btnSearchOrder.TabIndex = 2
        btnSearchOrder.Text = "Search Order"
        btnSearchOrder.UseVisualStyleBackColor = False
        ' 
        ' txtOrderNumber
        ' 
        txtOrderNumber.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtOrderNumber.Location = New Point(200, 45)
        txtOrderNumber.Name = "txtOrderNumber"
        txtOrderNumber.PlaceholderText = "e.g., 001"
        txtOrderNumber.Size = New Size(350, 29)
        txtOrderNumber.TabIndex = 1
        ' 
        ' lblOrderNumber
        ' 
        lblOrderNumber.AutoSize = True
        lblOrderNumber.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderNumber.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOrderNumber.Location = New Point(30, 48)
        lblOrderNumber.Name = "lblOrderNumber"
        lblOrderNumber.Size = New Size(149, 25)
        lblOrderNumber.TabIndex = 0
        lblOrderNumber.Text = "Order Number:"
        ' 
        ' pnlOrderDetails
        ' 
        pnlOrderDetails.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlOrderDetails.BorderStyle = BorderStyle.FixedSingle
        pnlOrderDetails.Controls.Add(lstOrderItems)
        pnlOrderDetails.Controls.Add(lblOrderInfo)
        pnlOrderDetails.Controls.Add(lblTotalAmount)
        pnlOrderDetails.Location = New Point(168, 318)
        pnlOrderDetails.Name = "pnlOrderDetails"
        pnlOrderDetails.Size = New Size(800, 500)
        pnlOrderDetails.TabIndex = 2
        ' 
        ' lstOrderItems
        ' 
        lstOrderItems.Columns.AddRange(New ColumnHeader() {colItem, colQuantity, colPrice, colSubtotal})
        lstOrderItems.FullRowSelect = True
        lstOrderItems.GridLines = True
        lstOrderItems.Location = New Point(30, 80)
        lstOrderItems.Name = "lstOrderItems"
        lstOrderItems.Size = New Size(740, 350)
        lstOrderItems.TabIndex = 2
        lstOrderItems.UseCompatibleStateImageBehavior = False
        lstOrderItems.View = View.Details
        ' 
        ' colItem
        ' 
        colItem.Text = "Item"
        colItem.Width = 350
        ' 
        ' colQuantity
        ' 
        colQuantity.Text = "Qty"
        colQuantity.Width = 80
        ' 
        ' colPrice
        ' 
        colPrice.Text = "Price"
        colPrice.Width = 120
        ' 
        ' colSubtotal
        ' 
        colSubtotal.Text = "Subtotal"
        colSubtotal.Width = 150
        ' 
        ' lblOrderInfo
        ' 
        lblOrderInfo.AutoSize = True
        lblOrderInfo.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderInfo.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblOrderInfo.Location = New Point(30, 30)
        lblOrderInfo.Name = "lblOrderInfo"
        lblOrderInfo.Size = New Size(133, 25)
        lblOrderInfo.TabIndex = 1
        lblOrderInfo.Text = "Order Details:"
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalAmount.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        lblTotalAmount.Location = New Point(30, 450)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(148, 32)
        lblTotalAmount.TabIndex = 0
        lblTotalAmount.Text = "Total: ₱0.00"
        ' 
        ' pnlPayment
        ' 
        pnlPayment.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlPayment.BorderStyle = BorderStyle.FixedSingle
        pnlPayment.Controls.Add(btnProcessPayment)
        pnlPayment.Controls.Add(radGCash)
        pnlPayment.Controls.Add(radCash)
        pnlPayment.Controls.Add(lblPaymentMethod)
        pnlPayment.Location = New Point(1018, 178)
        pnlPayment.Name = "pnlPayment"
        pnlPayment.Size = New Size(500, 250)
        pnlPayment.TabIndex = 3
        ' 
        ' btnProcessPayment
        ' 
        btnProcessPayment.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnProcessPayment.Enabled = False
        btnProcessPayment.FlatAppearance.BorderSize = 0
        btnProcessPayment.FlatStyle = FlatStyle.Flat
        btnProcessPayment.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnProcessPayment.ForeColor = Color.White
        btnProcessPayment.Location = New Point(30, 150)
        btnProcessPayment.Name = "btnProcessPayment"
        btnProcessPayment.Size = New Size(440, 50)
        btnProcessPayment.TabIndex = 3
        btnProcessPayment.Text = "Process Payment"
        btnProcessPayment.UseVisualStyleBackColor = False
        ' 
        ' radGCash
        ' 
        radGCash.AutoSize = True
        radGCash.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        radGCash.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        radGCash.Location = New Point(200, 100)
        radGCash.Name = "radGCash"
        radGCash.Size = New Size(73, 25)
        radGCash.TabIndex = 2
        radGCash.Text = "GCash"
        radGCash.UseVisualStyleBackColor = True
        ' 
        ' radCash
        ' 
        radCash.AutoSize = True
        radCash.Checked = True
        radCash.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        radCash.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        radCash.Location = New Point(30, 100)
        radCash.Name = "radCash"
        radCash.Size = New Size(62, 25)
        radCash.TabIndex = 1
        radCash.TabStop = True
        radCash.Text = "Cash"
        radCash.UseVisualStyleBackColor = True
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPaymentMethod.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblPaymentMethod.Location = New Point(30, 30)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(170, 25)
        lblPaymentMethod.TabIndex = 0
        lblPaymentMethod.Text = "Payment Method:"
        ' 
        ' pnlReceiptPreview
        ' 
        pnlReceiptPreview.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        pnlReceiptPreview.BorderStyle = BorderStyle.FixedSingle
        pnlReceiptPreview.Controls.Add(btnPrintReceipt)
        pnlReceiptPreview.Controls.Add(txtReceiptPreview)
        pnlReceiptPreview.Controls.Add(lblReceiptPreview)
        pnlReceiptPreview.Location = New Point(1018, 458)
        pnlReceiptPreview.Name = "pnlReceiptPreview"
        pnlReceiptPreview.Size = New Size(500, 360)
        pnlReceiptPreview.TabIndex = 4
        ' 
        ' btnPrintReceipt
        ' 
        btnPrintReceipt.BackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        btnPrintReceipt.Enabled = False
        btnPrintReceipt.FlatAppearance.BorderSize = 0
        btnPrintReceipt.FlatStyle = FlatStyle.Flat
        btnPrintReceipt.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintReceipt.ForeColor = Color.White
        btnPrintReceipt.Location = New Point(30, 300)
        btnPrintReceipt.Name = "btnPrintReceipt"
        btnPrintReceipt.Size = New Size(440, 40)
        btnPrintReceipt.TabIndex = 2
        btnPrintReceipt.Text = "Print Receipt"
        btnPrintReceipt.UseVisualStyleBackColor = False
        ' 
        ' txtReceiptPreview
        ' 
        txtReceiptPreview.BackColor = Color.White
        txtReceiptPreview.Font = New Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtReceiptPreview.Location = New Point(30, 70)
        txtReceiptPreview.Multiline = True
        txtReceiptPreview.Name = "txtReceiptPreview"
        txtReceiptPreview.ReadOnly = True
        txtReceiptPreview.ScrollBars = ScrollBars.Vertical
        txtReceiptPreview.Size = New Size(440, 220)
        txtReceiptPreview.TabIndex = 1
        ' 
        ' lblReceiptPreview
        ' 
        lblReceiptPreview.AutoSize = True
        lblReceiptPreview.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblReceiptPreview.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblReceiptPreview.Location = New Point(30, 30)
        lblReceiptPreview.Name = "lblReceiptPreview"
        lblReceiptPreview.Size = New Size(157, 25)
        lblReceiptPreview.TabIndex = 0
        lblReceiptPreview.Text = "Receipt Preview:"
        ' 
        ' UC_Billing
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(pnlReceiptPreview)
        Controls.Add(pnlPayment)
        Controls.Add(pnlOrderDetails)
        Controls.Add(pnlOrderInput)
        Controls.Add(lblTitle)
        Name = "UC_Billing"
        Size = New Size(1450, 800)
        pnlOrderInput.ResumeLayout(False)
        pnlOrderInput.PerformLayout()
        pnlOrderDetails.ResumeLayout(False)
        pnlOrderDetails.PerformLayout()
        pnlPayment.ResumeLayout(False)
        pnlPayment.PerformLayout()
        pnlReceiptPreview.ResumeLayout(False)
        pnlReceiptPreview.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlOrderInput As System.Windows.Forms.Panel
    Friend WithEvents btnSearchOrder As System.Windows.Forms.Button
    Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderNumber As System.Windows.Forms.Label
    Friend WithEvents pnlOrderDetails As System.Windows.Forms.Panel
    Friend WithEvents lstOrderItems As System.Windows.Forms.ListView
    Friend WithEvents colItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colQuantity As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSubtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblOrderInfo As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents pnlPayment As System.Windows.Forms.Panel
    Friend WithEvents btnProcessPayment As System.Windows.Forms.Button
    Friend WithEvents radGCash As System.Windows.Forms.RadioButton
    Friend WithEvents radCash As System.Windows.Forms.RadioButton
    Friend WithEvents lblPaymentMethod As System.Windows.Forms.Label
    Friend WithEvents pnlReceiptPreview As System.Windows.Forms.Panel
    Friend WithEvents btnPrintReceipt As System.Windows.Forms.Button
    Friend WithEvents txtReceiptPreview As System.Windows.Forms.TextBox
    Friend WithEvents lblReceiptPreview As System.Windows.Forms.Label
End Class