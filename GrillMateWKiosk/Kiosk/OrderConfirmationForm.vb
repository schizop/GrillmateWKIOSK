Public Class OrderConfirmationForm
    Inherits UserControl
    Public Event NewOrderRequested As EventHandler

    Private Sub OrderConfirmationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form is ready for customization
    End Sub

    Private Sub OrderConfirmationForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        ' Stop timer when control is disposed
        If timerAutoReturn IsNot Nothing Then
            timerAutoReturn.Stop()
        End If
    End Sub

    Public Sub SetOrderNumber(orderNumber As String)
        ' Extract only the sequence number part for customer display
        ' Full format: ORD-20241215-001 -> Display: ORD-001
        If orderNumber.Contains("-") Then
            Dim parts() As String = orderNumber.Split("-"c)
            If parts.Length >= 3 Then
                lblOrderNumber.Text = "ORD-" & parts(2)
            Else
                lblOrderNumber.Text = orderNumber
            End If
        Else
            lblOrderNumber.Text = orderNumber
        End If

        ' Stop any existing timer and start the auto-return timer (20 seconds)
        timerAutoReturn.Stop()
        timerAutoReturn.Start()
    End Sub

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        ' Stop timer if user clicks manually
        timerAutoReturn.Stop()
        RaiseEvent NewOrderRequested(Me, EventArgs.Empty)
    End Sub

    Private Sub timerAutoReturn_Tick(sender As Object, e As EventArgs) Handles timerAutoReturn.Tick
        ' Stop the timer
        timerAutoReturn.Stop()
        ' Automatically trigger new order event after 20 seconds
        RaiseEvent NewOrderRequested(Me, EventArgs.Empty)
    End Sub
End Class