Imports System.Drawing

Public Class ProductCardControl
    Inherits UserControl

    Public Event AddToCartClicked As EventHandler(Of ProductCardEventArgs)

    Private _productId As Integer
    Private _productName As String = ""
    Private _description As String = ""
    Private _price As Decimal = 0
    Private _productImage As Image = Nothing

    Public Property ProductId As Integer
        Get
            Return _productId
        End Get
        Set(value As Integer)
            _productId = value
        End Set
    End Property

    Public Property ProductName As String
        Get
            Return _productName
        End Get
        Set(value As String)
            _productName = value
            UpdateDisplay()
        End Set
    End Property

    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
            UpdateDisplay()
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return _price
        End Get
        Set(value As Decimal)
            _price = value
            UpdateDisplay()
        End Set
    End Property

    Public Property ProductImage As Image
        Get
            Return _productImage
        End Get
        Set(value As Image)
            _productImage = value
            UpdateDisplay()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        AddHandler Me.Click, AddressOf ProductCardControl_Click
    End Sub

    Private Sub UpdateDisplay()
        If Not String.IsNullOrEmpty(_productName) Then
            lblName.Text = _productName
            lblDescription.Text = If(String.IsNullOrEmpty(_description),
                                    "",
                                    If(_description.Length > 40, _description.Substring(0, 40) & "...", _description))
            lblPrice.Text = "₱" & _price.ToString("N2")
            
            ' Update product image
            If _productImage IsNot Nothing Then
                picProduct.Image = _productImage
                picProduct.Visible = True
            Else
                picProduct.Image = Nothing
                picProduct.Visible = True ' Keep visible as placeholder
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        RaiseEvent AddToCartClicked(Me, New ProductCardEventArgs(_productId))
    End Sub

    Private Sub ProductCardControl_Click(sender As Object, e As EventArgs)
        ' Allow clicking anywhere on the card to add to cart
        RaiseEvent AddToCartClicked(Me, New ProductCardEventArgs(_productId))
    End Sub
End Class

Public Class ProductCardEventArgs
    Inherits EventArgs
    Public Property ProductId As Integer

    Public Sub New(productId As Integer)
        Me.ProductId = productId
    End Sub
End Class

