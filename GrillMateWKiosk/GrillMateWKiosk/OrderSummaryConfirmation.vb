Public Class OrderSummaryConfirmation
    Inherits UserControl
    Public Event OrderConfirmed As EventHandler
    Public Event OrderCancelled As EventHandler

    Private Sub OrderSummaryConfirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form is ready for customization
    End Sub

    Public Sub SetOrderSummary(tableId As Integer, cartItems As List(Of MenuDashboardForm.CartItem), total As Decimal)
        lblTableNumber.Text = "Table: " & tableId.ToString()
        
        ' Clear existing items
        flpOrderItems.Controls.Clear()
        
        ' Add order items
        For Each item As MenuDashboardForm.CartItem In cartItems
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(400, 40)
            itemPanel.BackColor = Color.White
            itemPanel.BorderStyle = BorderStyle.FixedSingle
            itemPanel.Margin = New Padding(2)
            
            ' Item name and quantity
            Dim lblItem As New Label()
            lblItem.Text = item.ProductName & " x" & item.Quantity.ToString()
            lblItem.Font = New Font("Arial", 12, FontStyle.Regular)
            lblItem.Location = New Point(10, 10)
            lblItem.Size = New Size(250, 20)
            lblItem.ForeColor = Color.Black
            
            ' Item subtotal
            Dim lblSubtotal As New Label()
            lblSubtotal.Text = "₱" & item.Subtotal.ToString("N2")
            lblSubtotal.Font = New Font("Arial", 12, FontStyle.Bold)
            lblSubtotal.Location = New Point(270, 10)
            lblSubtotal.Size = New Size(120, 20)
            lblSubtotal.ForeColor = Color.FromArgb(40, 167, 69)
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight
            
            itemPanel.Controls.AddRange({lblItem, lblSubtotal})
            flpOrderItems.Controls.Add(itemPanel)
        Next
        
        ' Set total
        lblTotal.Text = "TOTAL: ₱" & total.ToString("N2")
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        RaiseEvent OrderConfirmed(Me, EventArgs.Empty)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent OrderCancelled(Me, EventArgs.Empty)
    End Sub
End Class