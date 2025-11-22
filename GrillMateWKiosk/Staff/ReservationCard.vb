Imports System.Drawing

Public Class ReservationCard
    Inherits UserControl

    Public Event ReservationSelected As EventHandler(Of ReservationSelectedEventArgs)

    Private _reservationId As Integer
    Private _customerName As String = ""
    Private _tableNumber As String = ""
    Private _dateReserved As Date
    Private _timeSlot As String = ""
    Private _guests As Integer = 0
    Private _isSelected As Boolean = False

    Public Property ReservationId As Integer
        Get
            Return _reservationId
        End Get
        Set(value As Integer)
            _reservationId = value
        End Set
    End Property

    Public Property CustomerName As String
        Get
            Return _customerName
        End Get
        Set(value As String)
            _customerName = value
            UpdateDisplay()
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

    Public Property DateReserved As Date
        Get
            Return _dateReserved
        End Get
        Set(value As Date)
            _dateReserved = value
            UpdateDisplay()
        End Set
    End Property

    Public Property TimeSlot As String
        Get
            Return _timeSlot
        End Get
        Set(value As String)
            _timeSlot = value
            UpdateDisplay()
        End Set
    End Property

    Public Property Guests As Integer
        Get
            Return _guests
        End Get
        Set(value As Integer)
            _guests = value
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
        AddHandler Me.Click, AddressOf ReservationCard_Click
        AddHandler lblCustomerName.Click, AddressOf ReservationCard_Click
        AddHandler lblTableInfo.Click, AddressOf ReservationCard_Click
        AddHandler lblTimeInfo.Click, AddressOf ReservationCard_Click
    End Sub

    Private Sub UpdateDisplay()
        If Not String.IsNullOrEmpty(_customerName) Then
            lblCustomerName.Text = _customerName
        End If

        Dim dateStr As String = _dateReserved.ToString("MMM dd, yyyy")
        Dim timeStr As String = _timeSlot
        lblTimeInfo.Text = $"{dateStr} at {timeStr}"

        If Not String.IsNullOrEmpty(_tableNumber) Then
            lblTableInfo.Text = $"Table {_tableNumber} • {_guests} Guest(s)"
        End If
    End Sub

    Private Sub UpdateSelectionState()
        If _isSelected Then
            Me.BackColor = Color.FromArgb(40, 167, 69)
            lblCustomerName.ForeColor = Color.White
            lblTableInfo.ForeColor = Color.White
            lblTimeInfo.ForeColor = Color.White
            Me.BorderStyle = BorderStyle.FixedSingle
        Else
            Me.BackColor = Color.White
            lblCustomerName.ForeColor = Color.FromArgb(33, 37, 41)
            lblTableInfo.ForeColor = Color.FromArgb(108, 117, 125)
            lblTimeInfo.ForeColor = Color.FromArgb(108, 117, 125)
            Me.BorderStyle = BorderStyle.FixedSingle
        End If
    End Sub

    Private Sub ReservationCard_Click(sender As Object, e As EventArgs)
        RaiseEvent ReservationSelected(Me, New ReservationSelectedEventArgs(_reservationId))
    End Sub
End Class

Public Class ReservationSelectedEventArgs
    Inherits EventArgs
    Public Property ReservationId As Integer

    Public Sub New(reservationId As Integer)
        Me.ReservationId = reservationId
    End Sub
End Class
