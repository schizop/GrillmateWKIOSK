Imports System.Data.SqlClient

Public Class TableSelectionForm
    Private selectedTableID As Integer = 0

    Private Sub TableSelectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "GrillMate - Table Selection"
        LoadTables()
    End Sub

    Private Sub LoadTables()
        ' Clear existing buttons
        pnlTableGrid.Controls.Clear()

        Try
            Dim query As String = "SELECT TableID, TableNumber, Status FROM Tables ORDER BY TableNumber"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                        Dim buttonCount As Integer = 0
                        Dim buttonsPerRow As Integer = 4
                        Dim buttonWidth As Integer = 300
                        Dim buttonHeight As Integer = 200
                        Dim buttonSpacing As Integer = 15
                        
                        ' Calculate panel dimensions
                        Dim panelWidth As Integer = pnlTableGrid.Width - pnlTableGrid.Padding.Left - pnlTableGrid.Padding.Right
                        
                        ' Calculate total width needed for all buttons in a row
                        Dim totalButtonWidth As Integer = (buttonsPerRow * buttonWidth) + ((buttonsPerRow - 1) * buttonSpacing)
                        
                        ' Calculate starting X position to center the buttons
                        Dim startX As Integer = Math.Max(20, (panelWidth - totalButtonWidth) \ 2)

                ' Calculate starting Y position 
                Dim startY As Integer = 20

                        While reader.Read()
                            Dim tableID As Integer = reader("TableID")
                            Dim tableNumber As String = reader("TableNumber").ToString()
                            Dim status As String = reader("Status").ToString()

                            ' Create button
                            Dim btnTable As New Button()
                            btnTable.Text = "TABLE " & tableNumber
                            btnTable.Tag = tableID
                            btnTable.Size = New Size(buttonWidth, buttonHeight)
                            btnTable.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                            btnTable.FlatStyle = FlatStyle.Flat
                            btnTable.FlatAppearance.BorderSize = 2
                            btnTable.Cursor = Cursors.Hand

                            ' Calculate position
                            Dim row As Integer = buttonCount \ buttonsPerRow
                            Dim col As Integer = buttonCount Mod buttonsPerRow
                            btnTable.Location = New Point(
                                startX + col * (buttonWidth + buttonSpacing),
                                startY + row * (buttonHeight + buttonSpacing)
                            )


                    Select Case status.ToLower()
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


                    If status.ToLower() = "vacant" Then
                                AddHandler btnTable.Click, AddressOf TableButton_Click
                            End If

                            pnlTableGrid.Controls.Add(btnTable)
                            buttonCount += 1
                        End While
                        
                        ' Now center all buttons vertically
                        Dim totalRows As Integer = Math.Ceiling(buttonCount / buttonsPerRow)
                        Dim totalButtonHeight As Integer = (totalRows * buttonHeight) + ((totalRows - 1) * buttonSpacing)
                        Dim panelHeight As Integer = pnlTableGrid.Height - pnlTableGrid.Padding.Top - pnlTableGrid.Padding.Bottom
                        Dim centeredStartY As Integer = Math.Max(20, (panelHeight - totalButtonHeight) \ 2)
                        
                        ' Adjust all button positions vertically
                        For Each ctrl As Control In pnlTableGrid.Controls
                            If TypeOf ctrl Is Button Then
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

    Private Sub TableButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = DirectCast(sender, Button)
        selectedTableID = Convert.ToInt32(clickedButton.Tag)

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