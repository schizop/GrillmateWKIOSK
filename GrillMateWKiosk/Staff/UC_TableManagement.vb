Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class UC_TableManagement
    Private selectedTableID As Integer = -1
    Private tableButtons As New List(Of Button)
    Private tableData As New List(Of TableInfo)

    Private Structure TableInfo
        Public TableID As Integer
        Public TableNumber As String
        Public Status As String
        Public LastUpdated As DateTime
    End Structure

    Private Sub UC_TableManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTables()
        SetupEventHandlers()
    End Sub

    Private Sub UC_TableManagement_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' Recreate buttons when the control is resized to maintain proper layout
        If tableData.Count > 0 Then
            CreateTableButtons()
        End If
    End Sub

    Private Sub SetupEventHandlers()
        AddHandler btnRefresh.Click, AddressOf BtnRefresh_Click
        AddHandler btnSetVacant.Click, AddressOf BtnSetVacant_Click
        AddHandler btnSetOccupied.Click, AddressOf BtnSetOccupied_Click
        AddHandler btnSetReserved.Click, AddressOf BtnSetReserved_Click
    End Sub

    Private Sub LoadTables()
        Try
            Dim query As String = "SELECT TableID, TableNumber, Status FROM Tables ORDER BY TableNumber"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                tableData.Clear()
                While reader.Read()
                    Dim tableInfo As New TableInfo
                    tableInfo.TableID = reader.GetInt32("TableID")
                    tableInfo.TableNumber = reader.GetString("TableNumber")
                    tableInfo.Status = reader.GetString("Status")
                    tableInfo.LastUpdated = DateTime.Now
                    tableData.Add(tableInfo)
                End While
            End Using

            CreateTableButtons()
        Catch ex As Exception
            MessageBox.Show("Error loading tables: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateTableButtons()
        ' Clear existing buttons
        pnlTableGrid.Controls.Clear()
        tableButtons.Clear()

        ' Calculate button size to fit 4 columns with proper spacing
        Dim panelWidth As Integer = pnlTableGrid.Width - 40 ' Account for padding
        Dim buttonsPerRow As Integer = 4
        Dim spacing As Integer = 20
        Dim buttonWidth As Integer = (panelWidth - (spacing * (buttonsPerRow - 1))) \ buttonsPerRow
        Dim buttonHeight As Integer = 120 ' Fixed height for better appearance
        
        Dim buttonSize As New Size(buttonWidth, buttonHeight)
        Dim currentRow As Integer = 0
        Dim currentCol As Integer = 0

        For Each table As TableInfo In tableData
            Dim btn As New Button()
            btn.Text = table.TableNumber & vbCrLf & table.Status
            btn.Size = buttonSize
            btn.Font = New Font("Segoe UI", 12, FontStyle.Bold)
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 3
            btn.Cursor = Cursors.Hand
            btn.Tag = table.TableID
            btn.TextAlign = ContentAlignment.MiddleCenter

            ' Set colors based on status
            Select Case table.Status.ToLower()
                Case "vacant"
                    btn.BackColor = Color.FromArgb(46, 204, 113) ' Green
                    btn.ForeColor = Color.White
                    btn.FlatAppearance.BorderColor = Color.FromArgb(39, 174, 96)
                Case "occupied"
                    btn.BackColor = Color.FromArgb(231, 76, 60) ' Red
                    btn.ForeColor = Color.White
                    btn.FlatAppearance.BorderColor = Color.FromArgb(192, 57, 43)
                Case "reserved"
                    btn.BackColor = Color.FromArgb(241, 196, 15) ' Yellow
                    btn.ForeColor = Color.White
                    btn.FlatAppearance.BorderColor = Color.FromArgb(211, 84, 0)
            End Select

            ' Position the button with centering
            Dim startX As Integer = 20 + (currentCol * (buttonSize.Width + spacing))
            Dim startY As Integer = 20 + (currentRow * (buttonSize.Height + spacing))
            btn.Location = New Point(startX, startY)

            ' Add click event
            AddHandler btn.Click, AddressOf TableButton_Click

            pnlTableGrid.Controls.Add(btn)
            tableButtons.Add(btn)

            ' Update position for next button
            currentCol += 1
            If currentCol >= buttonsPerRow Then
                currentCol = 0
                currentRow += 1
            End If
        Next
    End Sub

    Private Sub TableButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        selectedTableID = CInt(btn.Tag)

        ' Update visual selection
        For Each tableBtn As Button In tableButtons
            tableBtn.FlatAppearance.BorderSize = 2
        Next
        btn.FlatAppearance.BorderSize = 4

        ' Update table info display
        UpdateTableInfo()
    End Sub

    Private Sub UpdateTableInfo()
        If selectedTableID > 0 Then
            Dim selectedTable = tableData.FirstOrDefault(Function(t) t.TableID = selectedTableID)
            If selectedTable.TableID > 0 Then
                lblTableNumber.Text = selectedTable.TableNumber
                lblTableStatus.Text = selectedTable.Status
                lblTableStatus.ForeColor = GetStatusColor(selectedTable.Status)
                lblLastUpdated.Text = "Last Updated: " & selectedTable.LastUpdated.ToString("MM/dd/yyyy HH:mm")
            End If
        End If
    End Sub

    Private Function GetStatusColor(status As String) As Color
        Select Case status.ToLower()
            Case "vacant"
                Return Color.FromArgb(46, 204, 113)
            Case "occupied"
                Return Color.FromArgb(231, 76, 60)
            Case "reserved"
                Return Color.FromArgb(241, 196, 15)
            Case Else
                Return Color.Gray
        End Select
    End Function

    Private Sub UpdateTableStatus(newStatus As String)
        If selectedTableID <= 0 Then
            MessageBox.Show("Please select a table first.", "No Table Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim query As String = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Status", newStatus),
                DatabaseConnection.CreateParameter("@TableID", selectedTableID)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)

            ' Update local data
            Dim tableIndex = tableData.FindIndex(Function(t) t.TableID = selectedTableID)
            If tableIndex >= 0 Then
                Dim updatedTable = tableData(tableIndex)
                updatedTable.Status = newStatus
                updatedTable.LastUpdated = DateTime.Now
                tableData(tableIndex) = updatedTable
            End If

            ' Refresh the display
            CreateTableButtons()
            UpdateTableInfo()

            MessageBox.Show($"Table status updated to {newStatus}", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error updating table status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        LoadTables()
        selectedTableID = -1
        lblTableNumber.Text = "Table #"
        lblTableStatus.Text = "Vacant"
        lblLastUpdated.Text = "Last Updated:"
    End Sub

    Private Sub BtnSetVacant_Click(sender As Object, e As EventArgs)
        UpdateTableStatus("Vacant")
    End Sub

    Private Sub BtnSetOccupied_Click(sender As Object, e As EventArgs)
        UpdateTableStatus("Occupied")
    End Sub

    Private Sub BtnSetReserved_Click(sender As Object, e As EventArgs)
        UpdateTableStatus("Reserved")
    End Sub

End Class
