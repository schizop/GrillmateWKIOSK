<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Reservation
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        DgvReservations = New DataGridView()
        RsvDetails = New Panel()
        CmbTables = New ComboBox()
        LblTable = New Label()
        btnSave = New Button()
        TxtRequests = New TextBox()
        lblRequest = New Label()
        nudGuests = New NumericUpDown()
        LblGuest = New Label()
        cmbTime = New ComboBox()
        lblTime = New Label()
        DtpDate = New DateTimePicker()
        TxtPhone = New TextBox()
        TxtName = New TextBox()
        lblDate = New Label()
        LblPhone = New Label()
        LblName = New Label()
        txtSearch = New TextBox()
        btnSearch = New Button()
        CalendarPanel = New Panel()
        lblCalendarTitle = New Label()
        MonthCalendar1 = New MonthCalendar()
        btnShowAll = New Button()
        TimelinePanel = New Panel()
        lblTimelineTitle = New Label()
        pnlTimeline = New Panel()
        DetailsPanel = New Panel()
        btnCancel = New Button()
        btnClear = New Button()
        txtDetailsRequest = New Label()
        lblDetailsRequest = New Label()
        lblDetailsTitle = New Label()
        CType(DgvReservations, ComponentModel.ISupportInitialize).BeginInit()
        RsvDetails.SuspendLayout()
        CType(nudGuests, ComponentModel.ISupportInitialize).BeginInit()
        CalendarPanel.SuspendLayout()
        TimelinePanel.SuspendLayout()
        DetailsPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Label1.Location = New Point(19, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(234, 51)
        Label1.TabIndex = 0
        Label1.Text = "Reservation"
        ' 
        ' DgvReservations
        ' 
        DgvReservations.BackgroundColor = SystemColors.Window
        DgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvReservations.Location = New Point(405, 117)
        DgvReservations.Name = "DgvReservations"
        DgvReservations.Size = New Size(900, 800)
        DgvReservations.TabIndex = 4
        ' 
        ' RsvDetails
        ' 
        RsvDetails.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        RsvDetails.BorderStyle = BorderStyle.FixedSingle
        RsvDetails.Controls.Add(btnCancel)
        RsvDetails.Controls.Add(btnClear)
        RsvDetails.Controls.Add(CmbTables)
        RsvDetails.Controls.Add(LblTable)
        RsvDetails.Controls.Add(btnSave)
        RsvDetails.Controls.Add(TxtRequests)
        RsvDetails.Controls.Add(lblRequest)
        RsvDetails.Controls.Add(nudGuests)
        RsvDetails.Controls.Add(LblGuest)
        RsvDetails.Controls.Add(cmbTime)
        RsvDetails.Controls.Add(lblTime)
        RsvDetails.Controls.Add(DtpDate)
        RsvDetails.Controls.Add(TxtPhone)
        RsvDetails.Controls.Add(TxtName)
        RsvDetails.Controls.Add(lblDate)
        RsvDetails.Controls.Add(LblPhone)
        RsvDetails.Controls.Add(LblName)
        RsvDetails.Location = New Point(21, 117)
        RsvDetails.Name = "RsvDetails"
        RsvDetails.Size = New Size(360, 800)
        RsvDetails.TabIndex = 5
        ' 
        ' CmbTables
        ' 
        CmbTables.FormattingEnabled = True
        CmbTables.Location = New Point(120, 200)
        CmbTables.Name = "CmbTables"
        CmbTables.Size = New Size(200, 23)
        CmbTables.TabIndex = 14
        ' 
        ' LblTable
        ' 
        LblTable.AutoSize = True
        LblTable.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        LblTable.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        LblTable.Location = New Point(15, 203)
        LblTable.Name = "LblTable"
        LblTable.Size = New Size(93, 17)
        LblTable.TabIndex = 13
        LblTable.Text = "Table number"
        LblTable.TextAlign = ContentAlignment.TopCenter
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnSave.ForeColor = SystemColors.HighlightText
        btnSave.Location = New Point(216, 398)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(90, 40)
        btnSave.TabIndex = 12
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' TxtRequests
        ' 
        TxtRequests.Location = New Point(120, 240)
        TxtRequests.Multiline = True
        TxtRequests.Name = "TxtRequests"
        TxtRequests.Size = New Size(200, 140)
        TxtRequests.TabIndex = 11
        ' 
        ' lblRequest
        ' 
        lblRequest.AutoSize = True
        lblRequest.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblRequest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblRequest.Location = New Point(15, 243)
        lblRequest.Name = "lblRequest"
        lblRequest.Size = New Size(108, 17)
        lblRequest.TabIndex = 10
        lblRequest.Text = "Special Request:"
        lblRequest.TextAlign = ContentAlignment.TopCenter
        ' 
        ' nudGuests
        ' 
        nudGuests.Location = New Point(120, 160)
        nudGuests.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        nudGuests.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudGuests.Name = "nudGuests"
        nudGuests.RightToLeft = RightToLeft.No
        nudGuests.Size = New Size(140, 23)
        nudGuests.TabIndex = 9
        nudGuests.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' LblGuest
        ' 
        LblGuest.AutoSize = True
        LblGuest.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        LblGuest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        LblGuest.Location = New Point(15, 163)
        LblGuest.Name = "LblGuest"
        LblGuest.Size = New Size(96, 17)
        LblGuest.TabIndex = 8
        LblGuest.Text = "No. of Guests:"
        LblGuest.TextAlign = ContentAlignment.TopCenter
        ' 
        ' cmbTime
        ' 
        cmbTime.FormattingEnabled = True
        cmbTime.Items.AddRange(New Object() {"8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "6:00 PM", "7:00 PM", "8:00 PM", "9:00 PM", "10:00 PM", "11:00 PM", "12:00 AM"})
        cmbTime.Location = New Point(120, 130)
        cmbTime.Name = "cmbTime"
        cmbTime.Size = New Size(200, 23)
        cmbTime.TabIndex = 7
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblTime.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTime.Location = New Point(15, 133)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(71, 17)
        lblTime.TabIndex = 6
        lblTime.Text = "Time Slot:"
        lblTime.TextAlign = ContentAlignment.TopCenter
        ' 
        ' DtpDate
        ' 
        DtpDate.Location = New Point(120, 100)
        DtpDate.Name = "DtpDate"
        DtpDate.Size = New Size(200, 23)
        DtpDate.TabIndex = 5
        ' 
        ' TxtPhone
        ' 
        TxtPhone.Location = New Point(120, 70)
        TxtPhone.Name = "TxtPhone"
        TxtPhone.Size = New Size(200, 23)
        TxtPhone.TabIndex = 4
        ' 
        ' TxtName
        ' 
        TxtName.Location = New Point(120, 40)
        TxtName.Name = "TxtName"
        TxtName.Size = New Size(200, 23)
        TxtName.TabIndex = 3
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblDate.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDate.Location = New Point(15, 103)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(101, 17)
        lblDate.TabIndex = 2
        lblDate.Text = "Date Reserved:"
        lblDate.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LblPhone
        ' 
        LblPhone.AutoSize = True
        LblPhone.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        LblPhone.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        LblPhone.Location = New Point(15, 73)
        LblPhone.Name = "LblPhone"
        LblPhone.Size = New Size(106, 17)
        LblPhone.TabIndex = 1
        LblPhone.Text = "Phone Number:"
        ' 
        ' LblName
        ' 
        LblName.AutoSize = True
        LblName.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblName.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        LblName.Location = New Point(15, 43)
        LblName.Name = "LblName"
        LblName.Size = New Size(115, 17)
        LblName.TabIndex = 0
        LblName.Text = "Customer Name: "
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(405, 79)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(450, 23)
        txtSearch.TabIndex = 6
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(865, 79)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(100, 25)
        btnSearch.TabIndex = 7
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' CalendarPanel
        ' 
        CalendarPanel.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        CalendarPanel.BorderStyle = BorderStyle.FixedSingle
        CalendarPanel.Controls.Add(lblCalendarTitle)
        CalendarPanel.Controls.Add(MonthCalendar1)
        CalendarPanel.Controls.Add(btnShowAll)
        CalendarPanel.Location = New Point(1322, 117)
        CalendarPanel.Name = "CalendarPanel"
        CalendarPanel.Size = New Size(330, 261)
        CalendarPanel.TabIndex = 8
        ' 
        ' lblCalendarTitle
        ' 
        lblCalendarTitle.AutoSize = True
        lblCalendarTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblCalendarTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblCalendarTitle.Location = New Point(10, 10)
        lblCalendarTitle.Name = "lblCalendarTitle"
        lblCalendarTitle.Size = New Size(108, 21)
        lblCalendarTitle.TabIndex = 0
        lblCalendarTitle.Text = "Reservations"
        ' 
        ' MonthCalendar1
        ' 
        MonthCalendar1.Location = New Point(41, 43)
        MonthCalendar1.Name = "MonthCalendar1"
        MonthCalendar1.TabIndex = 1
        ' 
        ' btnShowAll
        ' 
        btnShowAll.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnShowAll.FlatStyle = FlatStyle.Flat
        btnShowAll.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnShowAll.ForeColor = Color.White
        btnShowAll.Location = New Point(15, 217)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(300, 35)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "Show All Reservations"
        btnShowAll.UseVisualStyleBackColor = False
        ' 
        ' TimelinePanel
        ' 
        TimelinePanel.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        TimelinePanel.BorderStyle = BorderStyle.FixedSingle
        TimelinePanel.Controls.Add(lblTimelineTitle)
        TimelinePanel.Controls.Add(pnlTimeline)
        TimelinePanel.Location = New Point(1322, 384)
        TimelinePanel.Name = "TimelinePanel"
        TimelinePanel.Size = New Size(330, 533)
        TimelinePanel.TabIndex = 9
        ' 
        ' lblTimelineTitle
        ' 
        lblTimelineTitle.AutoSize = True
        lblTimelineTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTimelineTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTimelineTitle.Location = New Point(10, 10)
        lblTimelineTitle.Name = "lblTimelineTitle"
        lblTimelineTitle.Size = New Size(141, 21)
        lblTimelineTitle.TabIndex = 0
        lblTimelineTitle.Text = "Today's Schedule"
        ' 
        ' pnlTimeline
        ' 
        pnlTimeline.AutoScroll = True
        pnlTimeline.BackColor = Color.White
        pnlTimeline.BorderStyle = BorderStyle.FixedSingle
        pnlTimeline.Location = New Point(10, 34)
        pnlTimeline.Name = "pnlTimeline"
        pnlTimeline.Size = New Size(310, 472)
        pnlTimeline.TabIndex = 1
        ' 
        ' DetailsPanel
        ' 
        DetailsPanel.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        DetailsPanel.BorderStyle = BorderStyle.FixedSingle
        DetailsPanel.Controls.Add(txtDetailsRequest)
        DetailsPanel.Controls.Add(lblDetailsRequest)
        DetailsPanel.Controls.Add(lblDetailsTitle)
        DetailsPanel.Location = New Point(405, 897)
        DetailsPanel.Name = "DetailsPanel"
        DetailsPanel.Size = New Size(900, 80)
        DetailsPanel.TabIndex = 10
        DetailsPanel.Visible = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(216, 480)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(90, 30)
        btnCancel.TabIndex = 16
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(216, 444)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(90, 30)
        btnClear.TabIndex = 15
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblDetailsTitle
        ' 
        lblDetailsTitle.AutoSize = True
        lblDetailsTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblDetailsTitle.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDetailsTitle.Location = New Point(10, 10)
        lblDetailsTitle.Name = "lblDetailsTitle"
        lblDetailsTitle.Size = New Size(127, 21)
        lblDetailsTitle.TabIndex = 0
        lblDetailsTitle.Text = "Special Request"
        ' 
        ' lblDetailsRequest
        ' 
        lblDetailsRequest.AutoSize = True
        lblDetailsRequest.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblDetailsRequest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDetailsRequest.Location = New Point(10, 40)
        lblDetailsRequest.Name = "lblDetailsRequest"
        lblDetailsRequest.Size = New Size(98, 15)
        lblDetailsRequest.TabIndex = 1
        lblDetailsRequest.Text = "Special Request:"
        ' 
        ' txtDetailsRequest
        ' 
        txtDetailsRequest.AutoSize = True
        txtDetailsRequest.Font = New Font("Segoe UI", 9F)
        txtDetailsRequest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        txtDetailsRequest.Location = New Point(115, 40)
        txtDetailsRequest.MaximumSize = New Size(770, 0)
        txtDetailsRequest.Name = "txtDetailsRequest"
        txtDetailsRequest.Size = New Size(0, 15)
        txtDetailsRequest.TabIndex = 2
        ' 
        ' UC_Reservation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DetailsPanel)
        Controls.Add(TimelinePanel)
        Controls.Add(CalendarPanel)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(RsvDetails)
        Controls.Add(DgvReservations)
        Controls.Add(Label1)
        Name = "UC_Reservation"
        Size = New Size(1670, 1020)
        CType(DgvReservations, ComponentModel.ISupportInitialize).EndInit()
        RsvDetails.ResumeLayout(False)
        RsvDetails.PerformLayout()
        CType(nudGuests, ComponentModel.ISupportInitialize).EndInit()
        CalendarPanel.ResumeLayout(False)
        CalendarPanel.PerformLayout()
        TimelinePanel.ResumeLayout(False)
        TimelinePanel.PerformLayout()
        DetailsPanel.ResumeLayout(False)
        DetailsPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DgvReservations As DataGridView
    Friend WithEvents RsvDetails As Panel
    Friend WithEvents LblPhone As Label
    Friend WithEvents LblName As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents DtpDate As DateTimePicker
    Friend WithEvents TxtPhone As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents lblTime As Label
    Friend WithEvents cmbTime As ComboBox
    Friend WithEvents LblGuest As Label
    Friend WithEvents nudGuests As NumericUpDown
    Friend WithEvents lblRequest As Label
    Friend WithEvents TxtRequests As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents LblTable As Label
    Friend WithEvents CmbTables As ComboBox
    Friend WithEvents CalendarPanel As Panel
    Friend WithEvents lblCalendarTitle As Label
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents btnShowAll As Button
    Friend WithEvents TimelinePanel As Panel
    Friend WithEvents lblTimelineTitle As Label
    Friend WithEvents pnlTimeline As Panel
    Friend WithEvents DetailsPanel As Panel
    Friend WithEvents lblDetailsTitle As Label
    Friend WithEvents lblDetailsRequest As Label
    Friend WithEvents txtDetailsRequest As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button

End Class
