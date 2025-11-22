Imports System.Data.SqlClient

Public Class UpdateProduct
    Inherits ProductOperation

    Protected Overrides Sub PerformOperation(form As ManageMenu, conn As SqlConnection)

        Dim cmd As New SqlCommand("
            UPDATE Products
            SET ProductName=@ProductName, Description=@Description, Price=@Price,
                CategoryID=@CategoryID, IsAvailable=@IsAvailable
            WHERE ProductID=@ProductID", conn)

        cmd.Parameters.AddWithValue("@ProductID", form.txtboxProdID.Text)
        cmd.Parameters.AddWithValue("@ProductName", form.txtboxProdName.Text)
        cmd.Parameters.AddWithValue("@Description", form.txtboxDescript.Text)
        cmd.Parameters.AddWithValue("@Price", form.txtboxPrice.Text)
        cmd.Parameters.AddWithValue("@CategoryID", form.txtboxCategoryID.Text)
        cmd.Parameters.AddWithValue("@IsAvailable", form.chkboxStatus.Checked)

        If cmd.ExecuteNonQuery() > 0 Then
            MsgBox("Product updated successfully!")
        End If
        ManageMenu.btnAdd.Enabled = True
        ManageMenu.txtboxProdID.ReadOnly = True
        ManageMenu.btnUpdate.Enabled = False
        ManageMenu.DGV_load()
    End Sub

End Class