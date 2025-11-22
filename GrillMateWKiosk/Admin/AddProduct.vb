Imports System.Data.SqlClient

Public Class AddProduct
    Inherits ProductOperation

    Protected Overrides Sub PerformOperation(form As ManageMenu, conn As SqlConnection)

        Dim cmd As New SqlCommand("
            INSERT INTO Products (ProductName, Description, Price, CategoryID, IsAvailable)
            VALUES (@ProductName, @Description, @Price, @CategoryID, @IsAvailable)", conn)

        cmd.Parameters.AddWithValue("@ProductName", form.txtboxProdName.Text)
        cmd.Parameters.AddWithValue("@Description", form.txtboxDescript.Text)
        cmd.Parameters.AddWithValue("@Price", form.txtboxPrice.Text)
        cmd.Parameters.AddWithValue("@CategoryID", form.txtboxCategoryID.Text)
        cmd.Parameters.AddWithValue("@IsAvailable", form.chkboxStatus.Checked)

        If cmd.ExecuteNonQuery() > 0 Then
            MsgBox("Product added successfully!")
        End If

    End Sub
End Class
