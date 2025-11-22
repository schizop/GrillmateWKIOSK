Imports System.Data.SqlClient

Public Class LoginForm

    Private Sub btnStartOrder_Click(sender As Object, e As EventArgs) Handles btnStartOrder.Click
        Dim dineInOrTakeoutForm As New DineInOrTakeout()
        dineInOrTakeoutForm.Show()
        Me.Hide()
    End Sub

    Private Sub LoginForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Only exit the application if this is the main login form
        ' If it's being closed to show another form, don't exit
        If Application.OpenForms.Count <= 1 Then
            Application.Exit()
        End If
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Clear the form when it's shown again (after logout)
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Database authentication logic
        If AuthenticateUser(txtUsername.Text, txtPassword.Text) Then
            Dim userRole As String = GetUserRole(txtUsername.Text)
            
            If userRole = "staff" Then
                ' Navigate to Staff Dashboard
                Dim staffDashboard As New StaffMenuDashboard()
                staffDashboard.Show()
                Me.Hide()
            ElseIf userRole = "admin" Then
                ' Navigate to Admin Dashboard
                Dim adminForm As New AdminForm()
                adminForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid user role: " & userRole, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        ' Allow login on Enter key press
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        ' Allow login on Enter key press
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPassword.Focus()
        End If
    End Sub

    ' Database authentication method
    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM Users WHERE Users = @Username AND Password = @Password"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Username", username),
                DatabaseConnection.CreateParameter("@Password", password)
            }
            Dim count As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters))
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Get user role from database
    Private Function GetUserRole(username As String) As String
        Try
            Dim query As String = "SELECT Roles FROM Users WHERE Users = @Username"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Username", username)
            }
            Dim result As Object = DatabaseConnection.ExecuteScalar(query, parameters)
            If result IsNot Nothing Then
                Return result.ToString().ToLower()
            End If
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return "invalid"
    End Function

End Class