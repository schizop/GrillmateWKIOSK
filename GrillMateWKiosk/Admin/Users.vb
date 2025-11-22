Imports System.Data.SqlClient

Public Class Users
    Public Sub DGV_load()

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Rows.Clear()
        Dim dr As SqlDataReader

        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Dim cmd As New SqlCommand("SELECT * FROM Users", conn)
                dr = cmd.ExecuteReader()

                Dim totalSum As Decimal = 0

                While dr.Read
                    DataGridView1.Rows.Add(
                        dr("Name"),
                        dr("Users"),
                        dr("Password"),
                        dr("Roles"))
                End While
                dr.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub History_staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_load()
    End Sub

End Class
