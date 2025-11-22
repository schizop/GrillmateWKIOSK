Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization

Public Class UC_Reservation
    Private reservationDates As New HashSet(Of DateTime)
    Private selectedCalendarDate As DateTime? = Nothing
    Private selectedReservationID As Integer = -1

    Private Sub UC_Reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
        LoadTables()
        LoadReservations()
        SetupCalendar()
        LoadTimeline()
        AddHandler MonthCalendar1.DateSelected, AddressOf MonthCalendar1_DateSelected
        AddHandler btnShowAll.Click, AddressOf btnShowAll_Click
        AddHandler DgvReservations.SelectionChanged, AddressOf DgvReservations_SelectionChanged
        AddHandler DgvReservations.CellClick, AddressOf DgvReservations_CellClick
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler btnCancel.Click, AddressOf btnCancel_Click

        ' Check and release expired reservations
        CheckAndReleaseExpiredReservations()
    End Sub

    Private Sub UC_Reservation_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        ' Refresh timeline and check expired reservations when control becomes visible
        If Me.Visible Then
            CheckAndReleaseExpiredReservations()
            LoadTimeline()
            LoadCalendarDates()
        End If
    End Sub

    Private Sub CheckAndReleaseExpiredReservations()
        ' Check and update table statuses based on reservation times with 20-minute buffer
        ' Sets tables to Reserved 20 minutes before reservation time
        ' Releases tables to Vacant 20 minutes after reservation time
        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                ' Get all reservations for today or future dates
                Using cmd As New SqlCommand("SELECT r.ReservationID, r.TableID, r.DateReserved, r.TimeSlot, t.Status " &
                                           "FROM Reservations r " &
                                           "INNER JOIN Tables t ON r.TableID = t.TableID " &
                                           "WHERE CAST(r.DateReserved AS date) >= @Today", conn)
                    cmd.Parameters.Add("@Today", SqlDbType.Date).Value = DateTime.Today
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim resDate As Date = reader.GetDateTime("DateReserved")
                            Dim timeSlot As String = reader.GetString("TimeSlot")
                            Dim tableId As Integer = reader.GetInt32("TableID")
                            Dim currentStatus As String = reader.GetString("Status")

                            Dim reservationTime As DateTime = ParseTimeSlot(resDate, timeSlot)
                            Dim bufferStart As DateTime = reservationTime.AddMinutes(-20)
                            Dim bufferEnd As DateTime = reservationTime.AddMinutes(20)
                            Dim now As DateTime = DateTime.Now

                            ' If we're within 20 minutes before reservation (buffer window), set table to Reserved
                            If now >= bufferStart AndAlso now <= bufferEnd Then
                                If currentStatus <> "Reserved" Then
                                    UpdateTableStatus(tableId, "Reserved")
                                End If
                            ' If buffer time has passed, release the table to Vacant
                            ElseIf now > bufferEnd Then
                                If currentStatus = "Reserved" Then
                                    UpdateTableStatus(tableId, "Vacant")
                                End If
                            ' If reservation is more than 20 minutes away, ensure table is Vacant (not Reserved yet)
                            ElseIf now < bufferStart Then
                                If currentStatus = "Reserved" Then
                                    UpdateTableStatus(tableId, "Vacant")
                                End If
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't interrupt user
            System.Diagnostics.Debug.WriteLine("Error checking expired reservations: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTables()
        Dim dt As New DataTable()
        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using da As New SqlDataAdapter("SELECT TableID, TableNumber FROM Tables ORDER BY TableNumber", conn)
                    da.Fill(dt)
                End Using
            End Using

            CmbTables.DataSource = dt
            CmbTables.DisplayMember = "TableNumber"
            CmbTables.ValueMember = "TableID"
            CmbTables.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Failed to load tables: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigureGrid()
        DgvReservations.AutoGenerateColumns = True
        DgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvReservations.ReadOnly = True
        DgvReservations.AllowUserToAddRows = False
        DgvReservations.AllowUserToDeleteRows = False
        DgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvReservations.AllowUserToResizeColumns = False
        DgvReservations.MultiSelect = False

        ' Add tooltip for special request column
        AddHandler DgvReservations.CellFormatting, AddressOf DgvReservations_CellFormatting
        AddHandler DgvReservations.CellToolTipTextNeeded, AddressOf DgvReservations_CellToolTipTextNeeded
    End Sub

    ' When fromTodayOnly = True the grid shows rows with DateReserved >= today (ignores time-of-day).
    Private Sub LoadReservations(Optional fromTodayOnly As Boolean = True)
        Dim sql As String
        If fromTodayOnly Then
            sql = "SELECT * FROM Reservations WHERE CAST(DateReserved AS date) >= @Date ORDER BY DateReserved, TimeSlot"
        Else
            sql = "SELECT * FROM Reservations ORDER BY DateReserved, TimeSlot"
        End If

        Dim dt As New DataTable()

        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If fromTodayOnly Then
                        cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Today
                    End If

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            DgvReservations.DataSource = dt

            ' Refresh calendar dates
            LoadCalendarDates()
        Catch ex As Exception
            MessageBox.Show("Failed to load data: " & ex.Message, "Load error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Basic required field validation
        If String.IsNullOrWhiteSpace(TxtName.Text) OrElse String.IsNullOrWhiteSpace(TxtPhone.Text) OrElse String.IsNullOrWhiteSpace(cmbTime.Text) Then
            MessageBox.Show("Please complete all required fields before saving.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CmbTables.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a table.", "Missing Table", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedTableId As Integer
        Try
            selectedTableId = Convert.ToInt32(CmbTables.SelectedValue)
        Catch
            MessageBox.Show("Invalid table selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim reservedDate As Date = DtpDate.Value.Date
        Dim timeSlot As String = cmbTime.Text.Trim()

        ' If updating existing reservation, skip conflict check for the same reservation
        Dim isUpdate As Boolean = selectedReservationID > 0

        ' Parse time slot to get actual time
        Dim reservationTime As DateTime = ParseTimeSlot(reservedDate, timeSlot)
        Dim bufferStart As DateTime = reservationTime.AddMinutes(-20)
        Dim bufferEnd As DateTime = reservationTime.AddMinutes(20)

        ' Check for conflicts with 20-minute buffer: same table, overlapping time slots
        Dim checkSql As String = "SELECT COUNT(*) FROM Reservations WHERE TableID=@TableID AND CAST(DateReserved AS date)=@Date " &
                                  "AND (CAST(DateReserved AS datetime) + CAST(TimeSlot AS datetime)) BETWEEN @BufferStart AND @BufferEnd"

        ' Better approach: check all reservations for the same table/date and compare time slots
        Dim checkSql2 As String = "SELECT ReservationID, TimeSlot FROM Reservations WHERE TableID=@TableID AND CAST(DateReserved AS date)=@Date"
        Try
            Dim conflictingReservations As New List(Of String)
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(checkSql2, conn)
                    cmd.Parameters.Add("@TableID", SqlDbType.Int).Value = selectedTableId
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = reservedDate
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim existingReservationID As Integer = reader.GetInt32("ReservationID")
                            ' Skip conflict check for the same reservation when updating
                            If isUpdate AndAlso existingReservationID = selectedReservationID Then
                                Continue While
                            End If

                            Dim existingTimeSlot As String = reader.GetString("TimeSlot")
                            Dim existingTime As DateTime = ParseTimeSlot(reservedDate, existingTimeSlot)
                            Dim existingBufferStart As DateTime = existingTime.AddMinutes(-20)
                            Dim existingBufferEnd As DateTime = existingTime.AddMinutes(20)

                            ' Check if time slots overlap (with buffers)
                            If (reservationTime >= existingBufferStart AndAlso reservationTime <= existingBufferEnd) OrElse
                               (bufferStart >= existingBufferStart AndAlso bufferStart <= existingBufferEnd) OrElse
                               (bufferEnd >= existingBufferStart AndAlso bufferEnd <= existingBufferEnd) Then
                                conflictingReservations.Add(existingTimeSlot)
                            End If
                        End While
                    End Using
                End Using
            End Using

            If conflictingReservations.Count > 0 Then
                MessageBox.Show("That table is already reserved with a 20-minute buffer around the selected time. " &
                              "Please choose another table or time slot.", "Time Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking existing reservation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Insert or Update reservation
        Try
            Dim parameters As SqlParameter()
            Dim sql As String

            If isUpdate Then
                ' Update existing reservation
                sql = "UPDATE Reservations SET CustomerName=@Name, PhoneNumber=@Phone, DateReserved=@Date, " &
                      "TimeSlot=@Time, TableID=@TableID, Guests=@Guests, SpecialRequest=@Request WHERE ReservationID=@ReservationID"
                parameters = DatabaseConnection.CreateParameters("@Name", TxtName.Text.Trim(),
                                                                 "@Phone", TxtPhone.Text.Trim(),
                                                                 "@Date", DtpDate.Value,
                                                                 "@Time", timeSlot,
                                                                 "@TableID", selectedTableId,
                                                                 "@Guests", Convert.ToInt32(nudGuests.Value),
                                                                 "@Request", TxtRequests.Text.Trim(),
                                                                 "@ReservationID", selectedReservationID)
            Else
                ' Insert new reservation
                sql = "INSERT INTO Reservations (CustomerName, PhoneNumber, DateReserved, TimeSlot, TableID, Guests, SpecialRequest) " &
                      "VALUES (@Name, @Phone, @Date, @Time, @TableID, @Guests, @Request)"
                parameters = DatabaseConnection.CreateParameters("@Name", TxtName.Text.Trim(),
                                                                 "@Phone", TxtPhone.Text.Trim(),
                                                                 "@Date", DtpDate.Value,
                                                                 "@Time", timeSlot,
                                                                 "@TableID", selectedTableId,
                                                                 "@Guests", Convert.ToInt32(nudGuests.Value),
                                                                 "@Request", TxtRequests.Text.Trim())
            End If

            DatabaseConnection.ExecuteNonQuery(sql, parameters)

            ' Update table status to Reserved only if we're within 20 minutes before the reservation time
            ' Otherwise, CheckAndReleaseExpiredReservations will handle it when the time comes
            Dim reservationTime As DateTime = ParseTimeSlot(reservedDate, timeSlot)
            Dim bufferStart As DateTime = reservationTime.AddMinutes(-20)
            Dim now As DateTime = DateTime.Now
            
            If reservedDate >= DateTime.Today Then
                ' Only set to Reserved if we're within the 20-minute buffer window
                If now >= bufferStart AndAlso now <= reservationTime.AddMinutes(20) Then
                    UpdateTableStatus(selectedTableId, "Reserved")
                End If
            End If

            Dim message As String = If(isUpdate, "Reservation updated successfully!", "Reservation saved successfully!")
            If reservedDate >= DateTime.Today AndAlso now >= bufferStart AndAlso now <= reservationTime.AddMinutes(20) Then
                message &= " Table status updated to Reserved."
            End If
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh grid, calendar, and timeline
            If selectedCalendarDate Is Nothing Then
                LoadReservations(fromTodayOnly:=False)
            Else
                LoadReservations(fromTodayOnly:=True)
            End If
            LoadCalendarDates()
            If DateTime.Today = reservedDate Then
                LoadTimeline()
            End If

            ' Clear inputs and selection
            ClearForm()
            DetailsPanel.Visible = False
        Catch ex As Exception
            MessageBox.Show("Error saving reservation: " & ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ParseTimeSlot(dateValue As Date, timeSlot As String) As DateTime
        ' Parse time slot string (e.g., "8:00 AM", "1:00 PM") to DateTime
        Try
            Dim timeStr As String = timeSlot.Trim()
            Dim timeOnly As DateTime = DateTime.ParseExact(timeStr, "h:mm tt", CultureInfo.InvariantCulture)
            Return dateValue.Date.Add(timeOnly.TimeOfDay)
        Catch
            ' Fallback: try to parse as standard time
            Try
                Return DateTime.Parse(dateValue.ToString("yyyy-MM-dd") & " " & timeSlot)
            Catch
                Return dateValue.Date.AddHours(12) ' Default to noon if parsing fails
            End Try
        End Try
    End Function

    Private Sub UpdateTableStatus(tableId As Integer, status As String)
        Try
            Dim updateSql As String = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID"
            Dim params = DatabaseConnection.CreateParameters("@Status", status, "@TableID", tableId)
            DatabaseConnection.ExecuteNonQuery(updateSql, params)
        Catch ex As Exception
            ' Log error but don't stop the reservation process
            System.Diagnostics.Debug.WriteLine("Error updating table status: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = If(txtSearch IsNot Nothing, txtSearch.Text.Trim(), String.Empty)

        Dim sql As String
        Dim dt As New DataTable()
        If String.IsNullOrEmpty(searchText) Then
            LoadReservations(fromTodayOnly:=True)
            Return
        Else
            sql = "SELECT * FROM Reservations WHERE CAST(DateReserved AS date) >= @Date AND CustomerName LIKE @Name ORDER BY DateReserved, TimeSlot"
        End If

        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Today
                    cmd.Parameters.AddWithValue("@Name", "%" & searchText & "%")
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            DgvReservations.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message, "Search error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Calendar functionality
    Private Sub SetupCalendar()
        MonthCalendar1.ShowToday = True
        MonthCalendar1.ShowTodayCircle = True
        LoadCalendarDates()
    End Sub

    Private Sub LoadCalendarDates()
        reservationDates.Clear()
        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand("SELECT DISTINCT CAST(DateReserved AS date) AS ReservationDate FROM Reservations WHERE CAST(DateReserved AS date) >= @Today ORDER BY ReservationDate", conn)
                    cmd.Parameters.Add("@Today", SqlDbType.Date).Value = DateTime.Today
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            reservationDates.Add(reader.GetDateTime("ReservationDate"))
                        End While
                    End Using
                End Using
            End Using

            ' Update bolded dates in calendar
            If reservationDates.Count > 0 Then
                MonthCalendar1.BoldedDates = reservationDates.ToArray()
            Else
                MonthCalendar1.BoldedDates = New DateTime() {}
            End If
            MonthCalendar1.UpdateBoldedDates()
        Catch ex As Exception
            MessageBox.Show("Error loading calendar dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        selectedCalendarDate = MonthCalendar1.SelectionStart.Date
        LoadReservationsByDate(selectedCalendarDate.Value)
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
        selectedCalendarDate = Nothing
        LoadReservations(fromTodayOnly:=False)
    End Sub

    Private Sub LoadReservationsByDate(filterDate As Date)
        Dim sql As String = "SELECT * FROM Reservations WHERE CAST(DateReserved AS date) = @Date ORDER BY TimeSlot"
        Dim dt As New DataTable()

        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = filterDate
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            DgvReservations.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Failed to load reservations: " & ex.Message, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Timeline functionality
    Private Sub LoadTimeline()
        pnlTimeline.Controls.Clear()

        ' Create hourly slots from 8 AM to 11 PM
        Dim startHour As Integer = 8
        Dim endHour As Integer = 23
        Dim slotHeight As Integer = 30
        Dim currentY As Integer = 5

        ' Load today's reservations
        Dim todayReservations As New List(Of ReservationInfo)
        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Using cmd As New SqlCommand("SELECT r.*, t.TableNumber FROM Reservations r INNER JOIN Tables t ON r.TableID = t.TableID WHERE CAST(DateReserved AS date) = @Today ORDER BY TimeSlot", conn)
                    cmd.Parameters.Add("@Today", SqlDbType.Date).Value = DateTime.Today
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim info As New ReservationInfo
                            info.ReservationID = reader.GetInt32("ReservationID")
                            info.TimeSlot = reader.GetString("TimeSlot")
                            info.TableNumber = reader.GetString("TableNumber")
                            info.CustomerName = reader.GetString("CustomerName")
                            info.Guests = reader.GetInt32("Guests")
                            info.ReservationHour = ParseTimeSlot(DateTime.Today, info.TimeSlot).Hour
                            todayReservations.Add(info)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading timeline: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Create time slot labels and reservation blocks
        For hour As Integer = startHour To endHour
            ' Convert to 12-hour format for display
            Dim displayHour As Integer = hour
            Dim period As String = "AM"
            If hour = 0 Then
                displayHour = 12
            ElseIf hour = 12 Then
                period = "PM"
            ElseIf hour > 12 Then
                displayHour = hour - 12
                period = "PM"
            End If

            ' Time label
            Dim timeLabel As New Label()
            timeLabel.Text = String.Format("{0}:00 {1}", displayHour, period)
            timeLabel.Location = New Point(5, currentY)
            timeLabel.Size = New Size(60, slotHeight)
            timeLabel.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            timeLabel.ForeColor = Color.FromArgb(52, 73, 94)
            pnlTimeline.Controls.Add(timeLabel)

            ' Slot background
            Dim slotPanel As New Panel()
            slotPanel.Location = New Point(65, currentY)
            slotPanel.Size = New Size(235, slotHeight - 2)
            slotPanel.BackColor = Color.White
            slotPanel.BorderStyle = BorderStyle.FixedSingle
            pnlTimeline.Controls.Add(slotPanel)

            ' Check for reservations in this hour
            Dim hourReservations = todayReservations.Where(Function(r) r.ReservationHour = hour).ToList()
            Dim reservationCount As Integer = hourReservations.Count

            If reservationCount > 0 Then
                Dim slotInnerWidth As Integer = slotPanel.Width - 4
                Dim slotInnerHeight As Integer = slotHeight - 6
                Dim baseX As Integer = slotPanel.Location.X + 2
                Dim baseY As Integer = currentY + 2

                Dim layoutSideBySide As Boolean = reservationCount <= 2

                For i As Integer = 0 To reservationCount - 1
                    Dim res As ReservationInfo = hourReservations(i)
                    Dim resBlock As New Panel()
                    resBlock.BackColor = Color.FromArgb(231, 76, 60) ' Red color
                    resBlock.BorderStyle = BorderStyle.FixedSingle

                    If layoutSideBySide Then
                        Dim blockWidth As Integer = CInt(Math.Floor(slotInnerWidth / reservationCount))
                        Dim blockHeight As Integer = slotInnerHeight
                        Dim xOffset As Integer = baseX + (i * blockWidth)
                        Dim width As Integer = blockWidth - 2
                        If i = reservationCount - 1 Then
                            width = (slotPanel.Location.X + slotPanel.Width) - 2 - xOffset
                        End If
                        resBlock.Location = New Point(xOffset, baseY)
                        resBlock.Size = New Size(Math.Max(60, width), blockHeight)
                    Else
                        Dim blockHeight As Integer = CInt(Math.Floor(slotInnerHeight / reservationCount))
                        Dim blockWidth As Integer = slotInnerWidth
                        Dim yOffset As Integer = baseY + (i * blockHeight)
                        Dim height As Integer = blockHeight - 2
                        If i = reservationCount - 1 Then
                            height = (currentY + slotHeight - 2) - yOffset
                        End If
                        resBlock.Location = New Point(baseX, yOffset)
                        resBlock.Size = New Size(blockWidth, Math.Max(16, height))
                    End If

                    ' Reservation info label
                    Dim resLabel As New Label()
                    resLabel.Text = String.Format("{0} - {1} ({2})", res.TableNumber, res.CustomerName, res.Guests)
                    resLabel.Location = New Point(3, 3)
                    resLabel.Size = New Size(resBlock.Width - 6, resBlock.Height - 6)
                    resLabel.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
                    resLabel.ForeColor = Color.White
                    resLabel.AutoSize = False
                    resLabel.TextAlign = ContentAlignment.MiddleLeft
                    resLabel.MaximumSize = resLabel.Size
                    resLabel.AutoEllipsis = True
                    resBlock.Controls.Add(resLabel)

                    ' Tooltip
                    Dim tooltip As New ToolTip()
                    tooltip.SetToolTip(resBlock, String.Format("Table: {0}" & vbCrLf & "Customer: {1}" & vbCrLf & "Guests: {2}" & vbCrLf & "Time: {3}", res.TableNumber, res.CustomerName, res.Guests, res.TimeSlot))

                    pnlTimeline.Controls.Add(resBlock)
                    resBlock.BringToFront()
                Next
            End If

            ' Change slot background to red tint if there's a reservation
            If reservationCount > 0 Then
                slotPanel.BackColor = Color.FromArgb(255, 200, 200) ' Light red background
            End If

            currentY += slotHeight
        Next

        ' Set panel height
        pnlTimeline.Height = Math.Min((endHour - startHour + 1) * slotHeight + 10, 472)
    End Sub

    Private Structure ReservationInfo
        Public ReservationID As Integer
        Public TimeSlot As String
        Public TableNumber As String
        Public CustomerName As String
        Public Guests As Integer
        Public ReservationHour As Integer
    End Structure

    ' Event handlers for DataGridView
    Private Sub DgvReservations_SelectionChanged(sender As Object, e As EventArgs)
        LoadSelectedReservation()
    End Sub

    Private Sub DgvReservations_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Handle cell click to ensure selection works even with single row
        If e.RowIndex >= 0 Then
            DgvReservations.ClearSelection()
            DgvReservations.Rows(e.RowIndex).Selected = True
            LoadSelectedReservation()
        End If
    End Sub

    Private Sub LoadSelectedReservation()
        If DgvReservations.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DgvReservations.SelectedRows(0)
            ' Get data from the DataTable bound to the grid
            If DgvReservations.DataSource IsNot Nothing Then
                Dim dt As DataTable = DirectCast(DgvReservations.DataSource, DataTable)
                If selectedRow.Index < dt.Rows.Count Then
                    Dim row As DataRow = dt.Rows(selectedRow.Index)
                    LoadReservationDetailsFromRow(row)
                End If
            End If
        Else
            DetailsPanel.Visible = False
            selectedReservationID = -1
        End If
    End Sub

    Private Sub LoadReservationDetailsFromRow(row As DataRow)
        Try
            selectedReservationID = Convert.ToInt32(row("ReservationID"))
            
            ' Populate form fields
            TxtName.Text = If(row("CustomerName") IsNot Nothing AndAlso Not IsDBNull(row("CustomerName")), row("CustomerName").ToString(), "")
            TxtPhone.Text = If(row("PhoneNumber") IsNot Nothing AndAlso Not IsDBNull(row("PhoneNumber")), row("PhoneNumber").ToString(), "")
            DtpDate.Value = If(row("DateReserved") IsNot Nothing AndAlso Not IsDBNull(row("DateReserved")), Convert.ToDateTime(row("DateReserved")), DateTime.Today)
            
            Dim timeSlot As String = If(row("TimeSlot") IsNot Nothing AndAlso Not IsDBNull(row("TimeSlot")), row("TimeSlot").ToString(), "")
            If Not String.IsNullOrEmpty(timeSlot) Then
                cmbTime.Text = timeSlot
            End If
            
            Dim tableId As Integer = If(row("TableID") IsNot Nothing AndAlso Not IsDBNull(row("TableID")), Convert.ToInt32(row("TableID")), -1)
            If tableId > 0 Then
                CmbTables.SelectedValue = tableId
            End If
            
            nudGuests.Value = If(row("Guests") IsNot Nothing AndAlso Not IsDBNull(row("Guests")), Convert.ToInt32(row("Guests")), 1)
            TxtRequests.Text = If(row("SpecialRequest") IsNot Nothing AndAlso Not IsDBNull(row("SpecialRequest")), row("SpecialRequest").ToString(), "")
            
            ' Populate details panel with special request only
            txtDetailsRequest.Text = TxtRequests.Text
            If String.IsNullOrWhiteSpace(TxtRequests.Text) Then
                txtDetailsRequest.Text = "(No special request)"
            End If
            
            ' Update Save button text
            btnSave.Text = "Update"
            
            ' Show details panel
            DetailsPanel.Visible = True
        Catch ex As Exception
            MessageBox.Show("Error loading reservation details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvReservations_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Truncate long text in SpecialRequest column
        If DgvReservations.Columns(e.ColumnIndex).Name = "SpecialRequest" AndAlso e.Value IsNot Nothing Then
            Dim text As String = e.Value.ToString()
            If text.Length > 30 Then
                e.Value = text.Substring(0, 27) & "..."
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub DgvReservations_CellToolTipTextNeeded(sender As Object, e As DataGridViewCellToolTipTextNeededEventArgs)
        ' Show full text in tooltip for SpecialRequest column
        ' Guard against invalid column index (e.g., header cells where ColumnIndex = -1)
        If e.ColumnIndex >= 0 AndAlso e.ColumnIndex < DgvReservations.Columns.Count AndAlso
           DgvReservations.Columns(e.ColumnIndex).Name = "SpecialRequest" Then
            If DgvReservations.DataSource IsNot Nothing Then
                Dim dt As DataTable = DirectCast(DgvReservations.DataSource, DataTable)
                If e.RowIndex >= 0 AndAlso e.RowIndex < dt.Rows.Count Then
                    Dim row As DataRow = dt.Rows(e.RowIndex)
                    If row("SpecialRequest") IsNot Nothing AndAlso Not IsDBNull(row("SpecialRequest")) Then
                        e.ToolTipText = row("SpecialRequest").ToString()
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearForm()
        DgvReservations.ClearSelection()
        DetailsPanel.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        If selectedReservationID <= 0 Then
            MessageBox.Show("Please select a reservation to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this reservation? This action cannot be undone.", 
                                                     "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                ' Get table ID before deleting
                Dim tableId As Integer = -1
                Using conn As SqlConnection = DatabaseConnection.GetConnection()
                    conn.Open()
                    Using cmd As New SqlCommand("SELECT TableID FROM Reservations WHERE ReservationID=@ReservationID", conn)
                        cmd.Parameters.Add("@ReservationID", SqlDbType.Int).Value = selectedReservationID
                        Dim resultObj As Object = cmd.ExecuteScalar()
                        If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                            tableId = Convert.ToInt32(resultObj)
                        End If
                    End Using
                End Using

                ' Delete reservation
                Dim deleteSql As String = "DELETE FROM Reservations WHERE ReservationID=@ReservationID"
                Dim parameters = DatabaseConnection.CreateParameters("@ReservationID", selectedReservationID)
                DatabaseConnection.ExecuteNonQuery(deleteSql, parameters)

                ' Release table if reservation was for today or future
                If tableId > 0 Then
                    UpdateTableStatus(tableId, "Vacant")
                End If

                MessageBox.Show("Reservation cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh data
                If selectedCalendarDate Is Nothing Then
                    LoadReservations(fromTodayOnly:=False)
                Else
                    LoadReservations(fromTodayOnly:=True)
                End If
                LoadCalendarDates()
                LoadTimeline()

                ' Clear form
                ClearForm()
                DetailsPanel.Visible = False
            Catch ex As Exception
                MessageBox.Show("Error cancelling reservation: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearForm()
        selectedReservationID = -1
        TxtName.Clear()
        TxtPhone.Clear()
        TxtRequests.Clear()
        nudGuests.Value = 1
        cmbTime.SelectedIndex = -1
        CmbTables.SelectedIndex = -1
        DtpDate.Value = DateTime.Today
        btnSave.Text = "Save"
    End Sub

End Class