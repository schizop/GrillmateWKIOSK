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
        DgvResrvations = New DataGridView()
        RsvDetails = New Panel()
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
        CType(DgvResrvations, ComponentModel.ISupportInitialize).BeginInit()
        RsvDetails.SuspendLayout()
        CType(nudGuests, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        Label1.Location = New Point(15, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(234, 51)
        Label1.TabIndex = 0
        Label1.Text = "Reservation"
        ' 
        ' DgvResrvations
        ' 
        DgvResrvations.BackgroundColor = SystemColors.Window
        DgvResrvations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvResrvations.Location = New Point(360, 81)
        DgvResrvations.Name = "DgvResrvations"
        DgvResrvations.Size = New Size(740, 558)
        DgvResrvations.TabIndex = 4
        ' 
        ' RsvDetails
        ' 
        RsvDetails.BackColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
        RsvDetails.BorderStyle = BorderStyle.FixedSingle
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
        RsvDetails.Location = New Point(15, 81)
        RsvDetails.Name = "RsvDetails"
        RsvDetails.Size = New Size(330, 407)
        RsvDetails.TabIndex = 5
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        btnSave.ForeColor = SystemColors.HighlightText
        btnSave.Location = New Point(198, 322)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(110, 44)
        btnSave.TabIndex = 12
        btnSave.Text = "Save Reservation"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' TxtRequests
        ' 
        TxtRequests.Location = New Point(111, 180)
        TxtRequests.Multiline = True
        TxtRequests.Name = "TxtRequests"
        TxtRequests.Size = New Size(206, 117)
        TxtRequests.TabIndex = 11
        ' 
        ' lblRequest
        ' 
        lblRequest.AutoSize = True
        lblRequest.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblRequest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblRequest.Location = New Point(4, 180)
        lblRequest.Name = "lblRequest"
        lblRequest.Size = New Size(108, 17)
        lblRequest.TabIndex = 10
        lblRequest.Text = "Special Request:"
        lblRequest.TextAlign = ContentAlignment.TopCenter
        ' 
        ' nudGuests
        ' 
        nudGuests.Location = New Point(110, 144)
        nudGuests.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        nudGuests.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudGuests.Name = "nudGuests"
        nudGuests.RightToLeft = RightToLeft.No
        nudGuests.Size = New Size(120, 23)
        nudGuests.TabIndex = 9
        nudGuests.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' LblGuest
        ' 
        LblGuest.AutoSize = True
        LblGuest.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        LblGuest.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        LblGuest.Location = New Point(8, 144)
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
        cmbTime.Location = New Point(110, 115)
        cmbTime.Name = "cmbTime"
        cmbTime.Size = New Size(206, 23)
        cmbTime.TabIndex = 7
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblTime.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblTime.Location = New Point(25, 116)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(71, 17)
        lblTime.TabIndex = 6
        lblTime.Text = "Time Slot:"
        lblTime.TextAlign = ContentAlignment.TopCenter
        ' 
        ' DtpDate
        ' 
        DtpDate.Location = New Point(110, 86)
        DtpDate.Name = "DtpDate"
        DtpDate.Size = New Size(206, 23)
        DtpDate.TabIndex = 5
        ' 
        ' TxtPhone
        ' 
        TxtPhone.Location = New Point(111, 57)
        TxtPhone.Name = "TxtPhone"
        TxtPhone.Size = New Size(181, 23)
        TxtPhone.TabIndex = 4
        ' 
        ' TxtName
        ' 
        TxtName.Location = New Point(111, 22)
        TxtName.Name = "TxtName"
        TxtName.Size = New Size(181, 23)
        TxtName.TabIndex = 3
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblDate.ForeColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
        lblDate.Location = New Point(3, 90)
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
        LblPhone.Location = New Point(3, 62)
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
        LblName.Location = New Point(4, 28)
        LblName.Name = "LblName"
        LblName.Size = New Size(115, 17)
        LblName.TabIndex = 0
        LblName.Text = "Customer Name: "
        ' 
        ' UC_Reservation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(RsvDetails)
        Controls.Add(DgvResrvations)
        Controls.Add(Label1)
        Name = "UC_Reservation"
        Size = New Size(1138, 678)
        CType(DgvResrvations, ComponentModel.ISupportInitialize).EndInit()
        RsvDetails.ResumeLayout(False)
        RsvDetails.PerformLayout()
        CType(nudGuests, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DgvResrvations As DataGridView
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

End Class
