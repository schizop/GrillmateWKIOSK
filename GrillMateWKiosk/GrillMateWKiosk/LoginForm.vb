Public Class LoginForm
    Private Sub btnStartOrder_Click(sender As Object, e As EventArgs) Handles btnStartOrder.Click
        ' Navigate to TableSelectionForm
        Dim tableForm As New TableSelectionForm()
        tableForm.Show()
        Me.Hide()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form content
        CenterContent()
    End Sub

    Private Sub CenterContent()
        ' Center the welcome label
        lblWelcome.Location = New Point((Me.ClientSize.Width - lblWelcome.Width) \ 2, 200)
        
        ' Center the start button
        btnStartOrder.Location = New Point((Me.ClientSize.Width - btnStartOrder.Width) \ 2, 450)
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterContent()
    End Sub

    Private Sub LoginForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Ensure the application exits when the LoginForm is closed
        Application.Exit()
    End Sub
End Class