Public Class OrderConfirmationForm
    Inherits UserControl
    Public Event NewOrderRequested As EventHandler

    Private Sub OrderConfirmationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form is ready for customization
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
    End Sub

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        RaiseEvent NewOrderRequested(Me, EventArgs.Empty)
    End Sub
End Class