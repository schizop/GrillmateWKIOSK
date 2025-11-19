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
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        btnLogin = New Button()
        SuspendLayout()
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.ForeColor = Color.FromArgb(CByte(255), CByte(0), CByte(0))
        lblWelcome.Location = New Point(494, 105)
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
        btnStartOrder.Location = New Point(206, 291)
        btnStartOrder.Margin = New Padding(4, 3, 4, 3)
        btnStartOrder.Name = "btnStartOrder"
        btnStartOrder.Size = New Size(324, 87)
        btnStartOrder.TabIndex = 2
        btnStartOrder.Text = "Customer Kiosk"
        btnStartOrder.TextAlign = ContentAlignment.MiddleRight
        btnStartOrder.UseVisualStyleBackColor = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblUsername.Location = New Point(732, 261)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(106, 25)
        lblUsername.TabIndex = 3
        lblUsername.Text = "Username:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(732, 291)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(300, 23)
        txtUsername.TabIndex = 4
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblPassword.Location = New Point(732, 341)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(102, 25)
        lblPassword.TabIndex = 5
        lblPassword.Text = "Password:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(732, 371)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(300, 23)
        txtPassword.TabIndex = 6
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(732, 426)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(300, 55)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1280, 720)
        Controls.Add(btnLogin)
        Controls.Add(txtPassword)
        Controls.Add(lblPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblUsername)
        Controls.Add(btnStartOrder)
        Controls.Add(lblWelcome)
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MaximumSize = New Size(1296, 759)
        MinimumSize = New Size(1296, 759)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "GrillMate Kiosk"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnStartOrder As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
End Class