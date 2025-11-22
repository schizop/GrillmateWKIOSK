Imports System.Data.SqlClient

Public Class DeleteProduct
    Inherits ProductOperation

    Protected Overrides Sub PerformOperation(form As ManageMenu, conn As SqlConnection)

        Dim cmd As New SqlCommand("DELETE FROM Products WHERE ProductID=@ProductID", conn)
        cmd.Parameters.AddWithValue("@ProductID", form.txtboxProdID.Text)

        If cmd.ExecuteNonQuery() > 0 Then
            MsgBox("Record deleted successfully!")
        Else

            MsgBox("Delete failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'ManageMenu.btnAdd.Enabled = True
        'ManageMenu.txtboxProdID.ReadOnly = False
        'ManageMenu.btnUpdate.Enabled = False
        'ManageMenu.DGV_load()

    End Sub

End Class

