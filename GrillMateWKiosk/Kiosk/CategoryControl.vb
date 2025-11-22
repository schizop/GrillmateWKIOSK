Imports System.Drawing

Public Class CategoryControl
    Inherits UserControl

    Public Event CategorySelected As EventHandler(Of CategorySelectedEventArgs)

    Private _categoryId As Integer
    Private _categoryName As String = ""
    Private _isSelected As Boolean = False

    Public Property CategoryId As Integer
        Get
            Return _categoryId
        End Get
        Set(value As Integer)
            _categoryId = value
        End Set
    End Property

    Public Property CategoryName As String
        Get
            Return _categoryName
        End Get
        Set(value As String)
            _categoryName = value
            UpdateDisplay()
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
            UpdateSelectionState()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        AddHandler btnCategory.Click, AddressOf BtnCategory_Click
        AddHandler Me.Click, AddressOf CategoryControl_Click
    End Sub

    Private Sub UpdateDisplay()
        If Not String.IsNullOrEmpty(_categoryName) Then
            btnCategory.Text = _categoryName
        End If
    End Sub

    Private Sub UpdateSelectionState()
        If _isSelected Then
            btnCategory.BackColor = Color.FromArgb(255, 193, 7)
            btnCategory.ForeColor = Color.White
        Else
            btnCategory.BackColor = Color.White
            btnCategory.ForeColor = Color.FromArgb(33, 37, 41)
        End If
    End Sub

    Private Sub BtnCategory_Click(sender As Object, e As EventArgs)
        RaiseEvent CategorySelected(Me, New CategorySelectedEventArgs(_categoryId))
    End Sub

    Private Sub CategoryControl_Click(sender As Object, e As EventArgs)
        ' Allow clicking anywhere on the control to select category
        RaiseEvent CategorySelected(Me, New CategorySelectedEventArgs(_categoryId))
    End Sub
End Class

Public Class CategorySelectedEventArgs
    Inherits EventArgs
    Public Property CategoryId As Integer

    Public Sub New(categoryId As Integer)
        Me.CategoryId = categoryId
    End Sub
End Class
