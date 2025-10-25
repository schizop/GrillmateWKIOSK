Public Class StaffMenuDashboard

    Private Sub StaffMenuDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub StaffMenuDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' When the staff dashboard is closed, show the login form
        Dim loginForm As LoginForm = Nothing
        For Each form As Form In Application.OpenForms
            If TypeOf form Is LoginForm Then
                loginForm = DirectCast(form, LoginForm)
                Exit For
            End If
        Next
        
        If loginForm Is Nothing Then
            loginForm = New LoginForm()
        End If
        
        loginForm.Show()
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        ' Handle logout functionality
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' Find existing login form or create new one
            Dim loginForm As LoginForm = Nothing
            For Each form As Form In Application.OpenForms
                If TypeOf form Is LoginForm Then
                    loginForm = DirectCast(form, LoginForm)
                    Exit For
                End If
            Next
            
            If loginForm Is Nothing Then
                loginForm = New LoginForm()
            End If
            
            ' Show login form and close current form
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub TableManagementButton_Click(sender As Object, e As EventArgs) Handles TableManagementButton.Click
        ' Load Table Management control
        LoadTableManagementControl()
    End Sub

    Private Sub LoadTableManagementControl()
        ' Clear existing content
        ContentPanel.Controls.Clear()
        
        ' Create and load table management control
        Dim tableManagementControl As New UC_TableManagement()
        tableManagementControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(tableManagementControl)
    End Sub

    Private Sub BillingButton_Click(sender As Object, e As EventArgs) Handles BillingButton.Click
        ' Handle Billing button click
        LoadBillingControl()
    End Sub

    Private Sub LoadBillingControl()
        ' Clear existing content
        ContentPanel.Controls.Clear()
        
        ' Create and load billing control
        Dim billingControl As New UC_Billing()
        billingControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(billingControl)
    End Sub

    Private Sub OrderHistoryButton_Click(sender As Object, e As EventArgs) Handles OrderHistoryButton.Click
        ' Handle Order History button click
        MessageBox.Show("Order History functionality will be implemented here.", "Order History", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ReportingAnalyticsButton_Click(sender As Object, e As EventArgs) Handles ReportingAnalyticsButton.Click
        ' Handle Reporting & Analytics button click
        MessageBox.Show("Reporting & Analytics functionality will be implemented here.", "Reporting & Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ReservationPageButton_Click(sender As Object, e As EventArgs) Handles ReservationPageButton.Click
        ' Handle Reservation Page button click
        MessageBox.Show("Reservation Page functionality will be implemented here.", "Reservation Page", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeliveryPageButton_Click(sender As Object, e As EventArgs) Handles DeliveryPageButton.Click
        ' Handle Delivery Page button click
        MessageBox.Show("Delivery Page functionality will be implemented here.", "Delivery Page", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class