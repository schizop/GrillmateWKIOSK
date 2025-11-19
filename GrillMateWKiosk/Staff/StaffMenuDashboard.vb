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
        ' Load Order History control
        LoadOrderHistoryControl()
    End Sub

    Private Sub LoadOrderHistoryControl()
        ' Clear existing content
        ContentPanel.Controls.Clear()
        
        ' Create and load order history control
        Dim orderHistoryControl As New UC_OrderHistory()
        orderHistoryControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(orderHistoryControl)
    End Sub

    Private Sub ReportingAnalyticsButton_Click(sender As Object, e As EventArgs) Handles ReportingAnalyticsButton.Click
        ' Handle Reporting & Analytics button click
        MessageBox.Show("Reporting & Analytics functionality will be implemented here.", "Reporting & Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ReservationPageButton_Click(sender As Object, e As EventArgs) Handles ReservationPageButton.Click
        ' Load Reservation control
        LoadReservationControl()
    End Sub

    Private Sub LoadReservationControl()
        ' Clear existing content
        ContentPanel.Controls.Clear()
        
        ' Create and load reservation control
        Dim reservationControl As New UC_Reservation()
        reservationControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(reservationControl)
    End Sub

    Private Sub DeliveryPageButton_Click(sender As Object, e As EventArgs) Handles DeliveryPageButton.Click
        ' Load Delivery control
        LoadDeliveryControl()
    End Sub

    Private Sub LoadDeliveryControl()
        ' Clear existing content
        ContentPanel.Controls.Clear()
        
        ' Create and load delivery control
        Dim deliveryControl As New UC_Delivery()
        deliveryControl.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(deliveryControl)
    End Sub

End Class