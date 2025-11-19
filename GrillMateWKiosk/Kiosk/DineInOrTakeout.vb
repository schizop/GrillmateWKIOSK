Public Class DineInOrTakeout

    Private Sub DineInOrTakeout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "GrillMate - Order Type Selection"
    End Sub

    Private Sub btnDineIn_Click(sender As Object, e As EventArgs) Handles btnDineIn.Click
        ' Navigate to TableSelectionForm
        Dim tableForm As New TableSelectionForm()
        tableForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnTakeout_Click(sender As Object, e As EventArgs) Handles btnTakeout.Click
        ' Navigate directly to MenuDashboardForm with SelectedTableID = 0 for takeout
        Dim menuForm As New MenuDashboardForm()
        menuForm.SelectedTableID = 0
        menuForm.OrderType = "Takeout"
        menuForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Return to LoginForm
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub DineInOrTakeout_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class