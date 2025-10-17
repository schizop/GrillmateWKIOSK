<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        lblWelcome = New Label()
        btnStartOrder = New Button()
        SuspendLayout()
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.ForeColor = Color.FromArgb(CByte(255), CByte(0), CByte(0))
        lblWelcome.Location = New Point(13, 9)
        lblWelcome.Margin = New Padding(4, 0, 4, 0)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(307, 75)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "GrillMate"
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnStartOrder
        ' 
        btnStartOrder.BackColor = Color.FromArgb(CByte(255), CByte(0), CByte(0))
        btnStartOrder.FlatAppearance.BorderSize = 0
        btnStartOrder.FlatStyle = FlatStyle.Flat
        btnStartOrder.Font = New Font("Arial", 28F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStartOrder.ForeColor = Color.White
        btnStartOrder.Location = New Point(137, 239)
        btnStartOrder.Margin = New Padding(4, 3, 4, 3)
        btnStartOrder.Name = "btnStartOrder"
        btnStartOrder.Size = New Size(320, 80)
        btnStartOrder.TabIndex = 2
        btnStartOrder.Text = "Customer Kiosk"
        btnStartOrder.UseVisualStyleBackColor = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1920, 1080)
        Controls.Add(btnStartOrder)
        Controls.Add(lblWelcome)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 3, 4, 3)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate Kiosk"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnStartOrder As Button
End Class