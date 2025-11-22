Imports System.Data.SqlClient
Imports System.Drawing

Public Class TableSelectionForm
    Private selectedTableID As Integer = 0

    Private Sub TableSelectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "GrillMate - Table Selection"
        LoadTables()
    End Sub

    Private Sub LoadTables()
        ' Clear existing controls
        pnlTableGrid.Controls.Clear()

        Try
            Dim query As String = "SELECT TableID, TableNumber, Status FROM Tables ORDER BY TableNumber"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                Dim controlCount As Integer = 0
                Dim controlsPerRow As Integer = 4
                Dim controlWidth As Integer = 300
                Dim controlHeight As Integer = 200
                Dim controlSpacing As Integer = 15

                ' Calculate panel dimensions
                Dim panelWidth As Integer = pnlTableGrid.Width - pnlTableGrid.Padding.Left - pnlTableGrid.Padding.Right

                ' Calculate total width needed for all controls in a row
                Dim totalControlWidth As Integer = (controlsPerRow * controlWidth) + ((controlsPerRow - 1) * controlSpacing)

                ' Calculate starting X position to center the controls
                Dim startX As Integer = Math.Max(20, (panelWidth - totalControlWidth) \ 2)

                ' Calculate starting Y position 
                Dim startY As Integer = 20

                While reader.Read()
                    Dim tableID As Integer = reader("TableID")
                    Dim tableNumber As String = reader("TableNumber").ToString()
                    Dim status As String = reader("Status").ToString()

                    ' Create table card control
                    Dim tableCard As New TableCardControl()
                    tableCard.TableId = tableID
                    tableCard.TableNumber = tableNumber
                    tableCard.Status = status
                    tableCard.Size = New Size(controlWidth, controlHeight)
                    tableCard.Cursor = Cursors.Hand

                    ' Calculate position
                    Dim row As Integer = controlCount \ controlsPerRow
                    Dim col As Integer = controlCount Mod controlsPerRow
                    tableCard.Location = New Point(
                                startX + col * (controlWidth + controlSpacing),
                                startY + row * (controlHeight + controlSpacing)
                            )

                    ' Add event handler
                    AddHandler tableCard.TableSelected, AddressOf TableCard_TableSelected

                    pnlTableGrid.Controls.Add(tableCard)
                    controlCount += 1
                End While

                ' Now center all controls vertically
                Dim totalRows As Integer = Math.Ceiling(controlCount / controlsPerRow)
                Dim totalControlHeight As Integer = (totalRows * controlHeight) + ((totalRows - 1) * controlSpacing)
                Dim panelHeight As Integer = pnlTableGrid.Height - pnlTableGrid.Padding.Top - pnlTableGrid.Padding.Bottom
                Dim centeredStartY As Integer = Math.Max(20, (panelHeight - totalControlHeight) \ 2)

                ' Adjust all control positions vertically
                For Each ctrl As Control In pnlTableGrid.Controls
                    If TypeOf ctrl Is TableCardControl Then
                        ctrl.Location = New Point(ctrl.Location.X, ctrl.Location.Y - startY + centeredStartY)
                    End If
                Next

            End Using
        Catch ex As SqlException
            If ex.Number = 2 Then
                MessageBox.Show("Cannot connect to database. Please make sure SQL Server is running and accessible.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf ex.Number = 4060 Then
                MessageBox.Show("Database 'POS' does not exist. Please run the Database_Schema.sql script first.", "Database Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Database error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading tables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableCard_TableSelected(sender As Object, e As TableSelectedEventArgs)
        selectedTableID = e.TableId

        ' Navigate to MenuDashboardForm
        Dim menuForm As New MenuDashboardForm()
        menuForm.SelectedTableID = selectedTableID
        menuForm.OrderType = "Dine-In"
        menuForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Return to DineInOrTakeout
        Dim dineInOrTakeoutForm As New DineInOrTakeout()
        dineInOrTakeoutForm.Show()
        Me.Hide()
    End Sub

    Private Sub TableSelectionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub


End Class