<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrderConfirmationForm
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If timerAutoReturn IsNot Nothing Then
                    timerAutoReturn.Stop()
                    timerAutoReturn.Dispose()
                End If
                If components IsNot Nothing Then
                    components.Dispose()
                End If
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
        components = New System.ComponentModel.Container()
        lblOrderNumber = New Label()
        lblOrderConfirmationTitle = New Label()
        lblPaymentInstruction = New Label()
        btnNewOrder = New Button()
        timerAutoReturn = New Timer(components)
        SuspendLayout()
        ' 
        ' timerAutoReturn
        ' 
        timerAutoReturn.Interval = 20000
        ' 
        ' lblOrderNumber
        ' 
        lblOrderNumber.AutoSize = True
        lblOrderNumber.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderNumber.ForeColor = Color.White
        lblOrderNumber.Location = New Point(824, 386)
        lblOrderNumber.Margin = New Padding(4, 0, 4, 0)
        lblOrderNumber.Name = "lblOrderNumber"
        lblOrderNumber.Size = New Size(176, 75)
        lblOrderNumber.TabIndex = 3
        lblOrderNumber.Text = "0001"
        lblOrderNumber.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblOrderConfirmationTitle
        ' 
        lblOrderConfirmationTitle.AutoSize = True
        lblOrderConfirmationTitle.Font = New Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderConfirmationTitle.ForeColor = Color.White
        lblOrderConfirmationTitle.Location = New Point(737, 263)
        lblOrderConfirmationTitle.Margin = New Padding(4, 0, 4, 0)
        lblOrderConfirmationTitle.Name = "lblOrderConfirmationTitle"
        lblOrderConfirmationTitle.Size = New Size(423, 56)
        lblOrderConfirmationTitle.TabIndex = 0
        lblOrderConfirmationTitle.Text = "Order Confirmed!"
        ' 
        ' lblPaymentInstruction
        ' 
        lblPaymentInstruction.AutoSize = True
        lblPaymentInstruction.Font = New Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPaymentInstruction.ForeColor = Color.White
        lblPaymentInstruction.Location = New Point(581, 547)
        lblPaymentInstruction.Margin = New Padding(4, 0, 4, 0)
        lblPaymentInstruction.Name = "lblPaymentInstruction"
        lblPaymentInstruction.Size = New Size(726, 36)
        lblPaymentInstruction.TabIndex = 1
        lblPaymentInstruction.Text = "Please give this number to the cashier for payment"
        ' 
        ' btnNewOrder
        ' 
        btnNewOrder.BackColor = Color.White
        btnNewOrder.FlatAppearance.BorderSize = 0
        btnNewOrder.FlatStyle = FlatStyle.Flat
        btnNewOrder.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewOrder.ForeColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        btnNewOrder.Location = New Point(835, 661)
        btnNewOrder.Margin = New Padding(4, 3, 4, 3)
        btnNewOrder.Name = "btnNewOrder"
        btnNewOrder.Size = New Size(233, 92)
        btnNewOrder.TabIndex = 2
        btnNewOrder.Text = "New Order"
        btnNewOrder.UseVisualStyleBackColor = False
        ' 
        ' OrderConfirmationForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.FromArgb(CByte(40), CByte(167), CByte(69))
        Controls.Add(lblOrderNumber)
        Controls.Add(lblOrderConfirmationTitle)
        Controls.Add(lblPaymentInstruction)
        Controls.Add(btnNewOrder)
        Margin = New Padding(4, 3, 4, 3)
        Name = "OrderConfirmationForm"
        Size = New Size(1920, 1080)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblOrderNumber As Label
    Friend WithEvents lblOrderConfirmationTitle As Label
    Friend WithEvents lblPaymentInstruction As Label
    Friend WithEvents btnNewOrder As Button
    Friend WithEvents timerAutoReturn As Timer
End Class