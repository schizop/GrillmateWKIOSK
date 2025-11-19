Imports System.Drawing

Public Class CartItemControl
    Inherits UserControl

    Public Event QuantityChanged As EventHandler(Of QuantityChangedEventArgs)
    Public Event ItemRemoved As EventHandler(Of ItemRemovedEventArgs)

    Private _cartItem As MenuDashboardForm.CartItem

    Public Property CartItem As MenuDashboardForm.CartItem
        Get
            Return _cartItem
        End Get
        Set(value As MenuDashboardForm.CartItem)
            _cartItem = value
            UpdateDisplay()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        AddHandler btnDecrease.Click, AddressOf BtnDecrease_Click
        AddHandler btnIncrease.Click, AddressOf BtnIncrease_Click
        AddHandler btnRemove.Click, AddressOf BtnRemove_Click
    End Sub

    Private Sub UpdateDisplay()
        If _cartItem IsNot Nothing Then
            lblItemName.Text = If(_cartItem.ProductName.Length > 15, _cartItem.ProductName.Substring(0, 15) & "...", _cartItem.ProductName)
            lblPrice.Text = "₱" & _cartItem.Price.ToString("N2") & " each"
            lblSubtotal.Text = "₱" & _cartItem.Subtotal.ToString("N2")
            lblQuantity.Text = _cartItem.Quantity.ToString()
        End If
    End Sub

    Private Sub BtnDecrease_Click(sender As Object, e As EventArgs)
        If _cartItem IsNot Nothing AndAlso _cartItem.Quantity > 1 Then
            _cartItem.Quantity -= 1
            UpdateDisplay()
            RaiseEvent QuantityChanged(Me, New QuantityChangedEventArgs(_cartItem.ProductId, _cartItem.Quantity))
        End If
    End Sub

    Private Sub BtnIncrease_Click(sender As Object, e As EventArgs)
        If _cartItem IsNot Nothing Then
            _cartItem.Quantity += 1
            UpdateDisplay()
            RaiseEvent QuantityChanged(Me, New QuantityChangedEventArgs(_cartItem.ProductId, _cartItem.Quantity))
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs)
        If _cartItem IsNot Nothing Then
            RaiseEvent ItemRemoved(Me, New ItemRemovedEventArgs(_cartItem.ProductId))
        End If
    End Sub
End Class

Public Class QuantityChangedEventArgs
    Inherits EventArgs
    Public Property ProductId As Integer
    Public Property NewQuantity As Integer

    Public Sub New(productId As Integer, newQuantity As Integer)
        Me.ProductId = productId
        Me.NewQuantity = newQuantity
    End Sub
End Class

Public Class ItemRemovedEventArgs
    Inherits EventArgs
    Public Property ProductId As Integer

    Public Sub New(productId As Integer)
        Me.ProductId = productId
    End Sub
End Class



