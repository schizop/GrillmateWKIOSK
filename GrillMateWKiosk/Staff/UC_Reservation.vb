Imports System.Data
Imports System.Data.SqlClient

Public Class UC_Reservation

    ' Example connection string for LocalDB. Change to match your server/database.
    Private ReadOnly connectionString As String =
        "Server=DESKTOP-060GL7S\SQLEXPRESS;Database=POS;Integrated Security=True;TrustServerCertificate=True;"

    Private Sub UC_Reservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
        LoadReservations()
    End Sub

    Private Sub ConfigureGrid()
        DgvResrvations.AutoGenerateColumns = True
        DgvResrvations.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvResrvations.ReadOnly = True
        DgvResrvations.AllowUserToAddRows = False
        DgvResrvations.AllowUserToDeleteRows = False
        DgvResrvations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvResrvations.AllowUserToResizeColumns = False
    End Sub

    Private Sub LoadReservations()
        Dim sql As String = "SELECT * FROM Reservations" ' adjust table name as needed
        Dim dt As New DataTable()

        Try
            Using conn As New SqlConnection(connectionString)
                Using da As New SqlDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using
            End Using

            DgvResrvations.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Failed to load data: " & ex.Message, "Load error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Basic validation
        If String.IsNullOrWhiteSpace(TxtName.Text) OrElse String.IsNullOrWhiteSpace(TxtPhone.Text) OrElse String.IsNullOrWhiteSpace(cmbTime.Text) Then
            MessageBox.Show("Please fill in all required fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim insertSql As String = "INSERT INTO Reservations (CustomerName, PhoneNumber, DateReserved, TimeSlot, Guests, SpecialRequest) " &
                                  "VALUES (@Name, @Phone, @Date, @Time, @Guests, @Request)"

        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(insertSql, conn)
                    cmd.Parameters.AddWithValue("@Name", TxtName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", TxtPhone.Text.Trim())
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = DtpDate.Value.Date
                    cmd.Parameters.AddWithValue("@Time", cmbTime.Text)
                    cmd.Parameters.Add("@Guests", SqlDbType.Int).Value = Convert.ToInt32(nudGuests.Value)
                    cmd.Parameters.AddWithValue("@Request", TxtRequests.Text.Trim())

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh the grid so newly inserted row appears immediately
            LoadReservations()

            ' Optional: clear form inputs after save
            TxtName.Clear()
            TxtPhone.Clear()
            TxtRequests.Clear()
            nudGuests.Value = 1
            cmbTime.SelectedIndex = -1
            DtpDate.Value = DateTime.Today

        Catch ex As Exception
            MessageBox.Show("Error saving reservation: " & ex.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class