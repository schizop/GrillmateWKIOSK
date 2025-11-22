<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        MenuStrip1 = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ManageMenuToolStripMenuItem = New ToolStripMenuItem()
        OrderHistoryToolStripMenuItem = New ToolStripMenuItem()
        Panel1 = New Panel()
        btnLogout = New Button()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.Transparent
        MenuStrip1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, ManageMenuToolStripMenuItem, OrderHistoryToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(4, 1, 0, 1)
        MenuStrip1.Size = New Size(1904, 27)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.BackColor = Color.Transparent
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem2})
        ToolStripMenuItem1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(62, 25)
        ToolStripMenuItem1.Text = "Users"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(215, 26)
        ToolStripMenuItem2.Text = "Register New User"
        ' 
        ' ManageMenuToolStripMenuItem
        ' 
        ManageMenuToolStripMenuItem.BackColor = Color.Transparent
        ManageMenuToolStripMenuItem.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        ManageMenuToolStripMenuItem.Name = "ManageMenuToolStripMenuItem"
        ManageMenuToolStripMenuItem.Size = New Size(68, 25)
        ManageMenuToolStripMenuItem.Text = " Menu"
        ' 
        ' OrderHistoryToolStripMenuItem
        ' 
        OrderHistoryToolStripMenuItem.BackColor = Color.Transparent
        OrderHistoryToolStripMenuItem.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        OrderHistoryToolStripMenuItem.Name = "OrderHistoryToolStripMenuItem"
        OrderHistoryToolStripMenuItem.Size = New Size(76, 25)
        OrderHistoryToolStripMenuItem.Text = "History"
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(20, 40)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1613, 874)
        Panel1.TabIndex = 1
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(0, 938)
        btnLogout.Margin = New Padding(2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(75, 32)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' AdminForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1904, 981)
        Controls.Add(btnLogout)
        Controls.Add(Panel1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(2)
        Name = "AdminForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ManageMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents OrderHistoryToolStripMenuItem As ToolStripMenuItem
End Class
