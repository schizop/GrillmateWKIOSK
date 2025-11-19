Public Class OrderSummaryConfirmation
    Inherits UserControl
    Public Event OrderConfirmed As EventHandler
    Public Event OrderCancelled As EventHandler

    Private Sub OrderSummaryConfirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Form is ready for customization
    End Sub

    Public Sub SetOrderSummary(tableId As Integer, cartItems As List(Of MenuDashboardForm.CartItem), total As Decimal, subtotal As Decimal, discount As Decimal, tax As Decimal, hasPwdDiscount As Boolean)
        If tableId > 0 Then
            lblTableNumber.Text = "Table: " & tableId.ToString()
        Else
            lblTableNumber.Text = "Takeout Order"
        End If
        
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
            Dim lblItemSubtotal As New Label()
            lblItemSubtotal.Text = "₱" & item.Subtotal.ToString("N2")
            lblItemSubtotal.Font = New Font("Arial", 12, FontStyle.Bold)
            lblItemSubtotal.Location = New Point(270, 10)
            lblItemSubtotal.Size = New Size(120, 20)
            lblItemSubtotal.ForeColor = Color.FromArgb(40, 167, 69)
            lblItemSubtotal.TextAlign = ContentAlignment.MiddleRight
            
            itemPanel.Controls.AddRange({lblItem, lblItemSubtotal})
            flpOrderItems.Controls.Add(itemPanel)
        Next
        
        ' Set breakdown
        lblSubtotal.Text = "Subtotal: ₱" & subtotal.ToString("N2")
        
        If discount > 0 Then
            lblDiscount.Text = "Discount (20%): -₱" & discount.ToString("N2")
            lblDiscount.Visible = True
        Else
            lblDiscount.Visible = False
        End If
        
        If tax > 0 Then
            lblTax.Text = "Tax VAT (12%): ₱" & tax.ToString("N2")
        ElseIf hasPwdDiscount Then
            lblTax.Text = "Tax VAT: ₱0.00 (Exempt)"
        Else
            lblTax.Text = "Tax VAT: ₱0.00"
        End If
        
        lblTotal.Text = "TOTAL: ₱" & total.ToString("N2")
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        RaiseEvent OrderConfirmed(Me, EventArgs.Empty)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent OrderCancelled(Me, EventArgs.Empty)
    End Sub
End Class