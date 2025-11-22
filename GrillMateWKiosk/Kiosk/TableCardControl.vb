Imports System.Drawing

Public Class TableCardControl
    Inherits UserControl

    Public Event TableSelected As EventHandler(Of TableSelectedEventArgs)

    Private _tableId As Integer
    Private _tableNumber As String = ""
    Private _status As String = ""

    Public Property TableId As Integer
        Get
            Return _tableId
        End Get
        Set(value As Integer)
            _tableId = value
        End Set
    End Property

    Public Property TableNumber As String
        Get
            Return _tableNumber
        End Get
        Set(value As String)
            _tableNumber = value
            UpdateDisplay()
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
            UpdateDisplay()
            UpdateStatusStyling()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        AddHandler btnTable.Click, AddressOf BtnTable_Click
        AddHandler Me.Click, AddressOf TableCardControl_Click
    End Sub

    Private Sub UpdateDisplay()
        If Not String.IsNullOrEmpty(_tableNumber) Then
            btnTable.Text = "TABLE " & _tableNumber
        End If
    End Sub

    Private Sub UpdateStatusStyling()
        Select Case _status.ToLower()
            Case "vacant"
                btnTable.BackColor = Color.FromArgb(46, 204, 113)
                btnTable.ForeColor = Color.White
                btnTable.FlatAppearance.BorderColor = Color.FromArgb(39, 174, 96)
                btnTable.Enabled = True
            Case "occupied"
                btnTable.BackColor = Color.FromArgb(231, 76, 60)
                btnTable.ForeColor = Color.White
                btnTable.FlatAppearance.BorderColor = Color.FromArgb(192, 57, 43)
                btnTable.Enabled = False
            Case "reserved"
                btnTable.BackColor = Color.FromArgb(241, 196, 15)
                btnTable.ForeColor = Color.White
                btnTable.FlatAppearance.BorderColor = Color.FromArgb(230, 126, 34)
                btnTable.Enabled = False
            Case Else
                btnTable.BackColor = Color.FromArgb(149, 165, 166)
                btnTable.ForeColor = Color.White
                btnTable.FlatAppearance.BorderColor = Color.FromArgb(127, 140, 141)
                btnTable.Enabled = False
        End Select
    End Sub

    Private Sub BtnTable_Click(sender As Object, e As EventArgs)
        If _status.ToLower() = "vacant" Then
            RaiseEvent TableSelected(Me, New TableSelectedEventArgs(_tableId))
        End If
    End Sub

    Private Sub TableCardControl_Click(sender As Object, e As EventArgs)
        ' Allow clicking anywhere on the control to select table (only if vacant)
        If _status.ToLower() = "vacant" Then
            RaiseEvent TableSelected(Me, New TableSelectedEventArgs(_tableId))
        End If
    End Sub
End Class

Public Class TableSelectedEventArgs
    Inherits EventArgs
    Public Property TableId As Integer

    Public Sub New(tableId As Integer)
        Me.TableId = tableId
    End Sub
End Class
