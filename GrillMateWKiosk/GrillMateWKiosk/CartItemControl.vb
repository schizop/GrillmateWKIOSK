Imports System.Drawing

Public Class CartItemControl
    Inherits UserControl

    Public Event QuantityChanged As EventHandler(Of QuantityChangedEventArgs)
    Public Event ItemRemoved As EventHandler(Of ItemRemovedEventArgs)

    Private _cartItem As MenuDashboardForm.CartItem
    Private lblItemName As Label
    Private lblPrice As Label
    Private lblSubtotal As Label
    Private btnDecrease As Button
    Private btnIncrease As Button
    Private lblQuantity As Label
    Private btnRemove As Button

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
    End Sub

    Private Sub InitializeComponent()
        Me.Size = New Size(250, 60)
        Me.BackColor = Color.White
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Margin = New Padding(2)

        ' Item Name Label
        lblItemName = New Label()
        lblItemName.Location = New Point(5, 5)
        lblItemName.Size = New Size(120, 20)
        lblItemName.Font = New Font("Arial", 10, FontStyle.Bold)
        lblItemName.ForeColor = Color.FromArgb(33, 37, 41)

        ' Price Label
        lblPrice = New Label()
        lblPrice.Location = New Point(5, 25)
        lblPrice.Size = New Size(60, 15)
        lblPrice.Font = New Font("Arial", 9)
        lblPrice.ForeColor = Color.Gray

        ' Subtotal Label
        lblSubtotal = New Label()
        lblSubtotal.Location = New Point(70, 25)
        lblSubtotal.Size = New Size(60, 15)
        lblSubtotal.Font = New Font("Arial", 9, FontStyle.Bold)
        lblSubtotal.ForeColor = Color.FromArgb(40, 167, 69)

        ' Decrease Button
        btnDecrease = New Button()
        btnDecrease.Text = "-"
        btnDecrease.Size = New Size(25, 25)
        btnDecrease.Location = New Point(140, 20)
        btnDecrease.Font = New Font("Arial", 12, FontStyle.Bold)
        btnDecrease.BackColor = Color.FromArgb(220, 53, 69)
        btnDecrease.ForeColor = Color.White
        btnDecrease.FlatStyle = FlatStyle.Flat
        btnDecrease.FlatAppearance.BorderSize = 0
        btnDecrease.Cursor = Cursors.Hand

        ' Quantity Label
        lblQuantity = New Label()
        lblQuantity.Text = "1"
        lblQuantity.Size = New Size(30, 25)
        lblQuantity.Location = New Point(170, 20)
        lblQuantity.Font = New Font("Arial", 12, FontStyle.Bold)
        lblQuantity.TextAlign = ContentAlignment.MiddleCenter
        lblQuantity.ForeColor = Color.FromArgb(33, 37, 41)

        ' Increase Button
        btnIncrease = New Button()
        btnIncrease.Text = "+"
        btnIncrease.Size = New Size(25, 25)
        btnIncrease.Location = New Point(205, 20)
        btnIncrease.Font = New Font("Arial", 12, FontStyle.Bold)
        btnIncrease.BackColor = Color.FromArgb(40, 167, 69)
        btnIncrease.ForeColor = Color.White
        btnIncrease.FlatStyle = FlatStyle.Flat
        btnIncrease.FlatAppearance.BorderSize = 0
        btnIncrease.Cursor = Cursors.Hand

        ' Remove Button
        btnRemove = New Button()
        btnRemove.Text = "×"
        btnRemove.Size = New Size(20, 20)
        btnRemove.Location = New Point(225, 5)
        btnRemove.Font = New Font("Arial", 14, FontStyle.Bold)
        btnRemove.BackColor = Color.Transparent
        btnRemove.ForeColor = Color.Red
        btnRemove.FlatStyle = FlatStyle.Flat
        btnRemove.FlatAppearance.BorderSize = 0
        btnRemove.Cursor = Cursors.Hand

        ' Add event handlers
        AddHandler btnDecrease.Click, AddressOf BtnDecrease_Click
        AddHandler btnIncrease.Click, AddressOf BtnIncrease_Click
        AddHandler btnRemove.Click, AddressOf BtnRemove_Click

        ' Add controls to the user control
        Me.Controls.AddRange({lblItemName, lblPrice, lblSubtotal, btnDecrease, lblQuantity, btnIncrease, btnRemove})
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



