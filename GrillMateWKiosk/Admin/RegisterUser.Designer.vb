<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        txtboxUser = New TextBox()
        txtboxPword = New TextBox()
        Panel1 = New Panel()
        btnCancel = New Button()
        btnOK = New Button()
        cmboxRole = New ComboBox()
        txtboxName = New TextBox()
        Label4 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label1.Location = New Point(36, 43)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 20)
        Label1.TabIndex = 0
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label2.Location = New Point(36, 74)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 20)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label3.Location = New Point(37, 105)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 20)
        Label3.TabIndex = 2
        Label3.Text = "Role:"
        ' 
        ' txtboxUser
        ' 
        txtboxUser.Location = New Point(122, 43)
        txtboxUser.Margin = New Padding(2, 2, 2, 2)
        txtboxUser.Name = "txtboxUser"
        txtboxUser.Size = New Size(123, 23)
        txtboxUser.TabIndex = 3
        ' 
        ' txtboxPword
        ' 
        txtboxPword.Location = New Point(122, 74)
        txtboxPword.Margin = New Padding(2, 2, 2, 2)
        txtboxPword.Name = "txtboxPword"
        txtboxPword.Size = New Size(123, 23)
        txtboxPword.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.LightGray
        Panel1.Controls.Add(txtboxName)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(btnCancel)
        Panel1.Controls.Add(btnOK)
        Panel1.Controls.Add(cmboxRole)
        Panel1.Controls.Add(txtboxPword)
        Panel1.Controls.Add(txtboxUser)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(34, 45)
        Panel1.Margin = New Padding(2, 2, 2, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(326, 177)
        Panel1.TabIndex = 6
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(177, 133)
        btnCancel.Margin = New Padding(2, 2, 2, 2)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(62, 22)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(105, 133)
        btnOK.Margin = New Padding(2, 2, 2, 2)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(62, 22)
        btnOK.TabIndex = 6
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' cmboxRole
        ' 
        cmboxRole.FormattingEnabled = True
        cmboxRole.Items.AddRange(New Object() {"Admin", "Staff"})
        cmboxRole.Location = New Point(122, 105)
        cmboxRole.Margin = New Padding(2, 2, 2, 2)
        cmboxRole.Name = "cmboxRole"
        cmboxRole.Size = New Size(124, 23)
        cmboxRole.TabIndex = 5
        ' 
        ' txtboxName
        ' 
        txtboxName.Location = New Point(123, 13)
        txtboxName.Margin = New Padding(2)
        txtboxName.Name = "txtboxName"
        txtboxName.Size = New Size(123, 23)
        txtboxName.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 11F, FontStyle.Bold)
        Label4.Location = New Point(37, 13)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(58, 20)
        Label4.TabIndex = 8
        Label4.Text = "Name: "
        ' 
        ' RegisterUser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightGray
        ClientSize = New Size(405, 261)
        Controls.Add(Panel1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "RegisterUser"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Register "
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtboxUser As TextBox
    Friend WithEvents txtboxPword As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents cmboxRole As ComboBox
    Friend WithEvents txtboxName As TextBox
    Friend WithEvents Label4 As Label
End Class
