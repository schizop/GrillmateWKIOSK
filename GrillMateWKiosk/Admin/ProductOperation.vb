Imports System.Data.SqlClient

Public MustInherit Class ProductOperation

    ' Base template method
    Public Sub Execute(form As ManageMenu)
        Try
            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                PerformOperation(form, conn)
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    ' Polymorphic method (Overridden by subclasses)
    Protected MustOverride Sub PerformOperation(form As ManageMenu, conn As SqlConnection)



End Class
