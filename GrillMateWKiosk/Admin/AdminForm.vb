Public Class AdminForm
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        RegisterUser.Show()
    End Sub

    Private Sub LoadFormInPanel(frm As Form)

        Panel1.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        Panel1.Controls.Add(frm)
        frm.Show()

    End Sub

    Private Sub ManageMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageMenuToolStripMenuItem.Click
        Dim f As New ManageMenu()
        LoadFormInPanel(f)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            LoginForm.Show()

        End If


    End Sub
    Private Sub LoadUserControlInPanel(ctrl As UserControl)
        Panel1.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        Panel1.Controls.Add(ctrl)
        ctrl.BringToFront()
    End Sub

    Private Sub OrderHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderHistoryToolStripMenuItem.Click
        Dim g As New Admin_OrderHistory()
        LoadUserControlInPanel(g)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim u As New Users()
        LoadFormInPanel(u)
    End Sub
End Class