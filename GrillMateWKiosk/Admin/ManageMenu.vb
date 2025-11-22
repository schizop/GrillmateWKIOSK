Imports System.Data.SqlClient

Public Class ManageMenu

    Dim i As Integer
    Dim dr As SqlDataReader


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim op As ProductOperation = New AddProduct()
        op.Execute(Me)
        clear()

        DGV_load()

    End Sub


    'Public Sub add()

    '    Try
    '        If conn.State = ConnectionState.Closed Then conn.Open()

    '        Dim cmd As New SqlCommand("
    '        INSERT INTO Products (ProductName, Description, Price, CategoryID, IsAvailable)
    '        VALUES (@ProductName, @Description, @Price, @CategoryID, @IsAvailable)", conn)

    '        cmd.Parameters.AddWithValue("@ProductName", txtboxProdName.Text)
    '        cmd.Parameters.AddWithValue("@Description", txtboxDescript.Text)
    '        cmd.Parameters.AddWithValue("@Price", txtboxPrice.Text)
    '        cmd.Parameters.AddWithValue("@CategoryID", txtboxCategoryID.Text) ' uses your textbox value
    '        cmd.Parameters.AddWithValue("@IsAvailable", chkboxStatus.Checked)

    '        Dim result As Integer = cmd.ExecuteNonQuery()
    '        If result > 0 Then
    '            MsgBox("Product added successfully!", MsgBoxStyle.Information, "Success")
    '        Else
    '            MsgBox("Failed to add product.", MsgBoxStyle.Exclamation, "Error")
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message)
    '    Finally
    '        If conn.State = ConnectionState.Open Then conn.Close()
    '    End Try

    '    clear()
    '    DGV_load()

    'End Sub


    Public Sub clear()
        txtboxProdID.Clear()
        txtboxProdName.Clear()
        txtboxPrice.Clear()
        txtboxDescript.Clear()
        txtboxCategoryID.Clear()
        chkboxStatus.Checked = False
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        txtboxProdID.ReadOnly = True
    End Sub


    Public Sub DGV_load()

        Try
            Dim query As String = "
            SELECT p.ProductID, 
                   p.ProductName, 
                   p.Description, 
                   p.Price,
                   c.CategoryName AS Category, 
                   p.CategoryID, 
                   p.IsAvailable
            FROM Products p
            JOIN MenuCategories c ON p.CategoryID = c.CategoryID"

            Using conn As SqlConnection = DatabaseConnection.GetConnection()
                conn.Open()
                Dim cmd As New SqlCommand(query, conn)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                DataGridView1.DataSource = dt   ' ✅ Correct spelling
            End Using

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub ManageMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV_load()
        btnUpdate.Enabled = False
        txtboxProdID.ReadOnly = True
        txtboxProdName.Focus()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim op As ProductOperation = New UpdateProduct()
        op.Execute(Me)
        DGV_load()
        clear()
        'txtboxProdID.ReadOnly = False
        'btnAdd.Enabled = True
        'btnUpdate.Enabled = False
    End Sub



    'Public Sub update()

    'Try
    '    If conn.State = ConnectionState.Closed Then
    '        conn.Open()
    '    End If

    '    ' ✅ Correct SQL: only use columns that exist in your Products table
    '    Dim cmd As New SqlCommand("
    '    UPDATE Products
    '    SET ProductName = @ProductName,
    '        Description = @Description,
    '        Price = @Price,
    '        CategoryID = @CategoryID,
    '        IsAvailable = @IsAvailable
    '    WHERE ProductID = @ProductID", conn)

    '    ' ✅ Add parameters
    '    cmd.Parameters.Clear()
    '    cmd.Parameters.AddWithValue("@ProductID", txtboxProdID.Text)
    '    cmd.Parameters.AddWithValue("@ProductName", txtboxProdName.Text)
    '    cmd.Parameters.AddWithValue("@Description", txtboxDescript.Text)
    '    cmd.Parameters.AddWithValue("@Price", txtboxPrice.Text)
    '    cmd.Parameters.AddWithValue("@CategoryID", txtboxCategoryID.Text)
    '    cmd.Parameters.AddWithValue("@IsAvailable", chkboxStatus.Checked)

    '    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

    '    If rowsAffected > 0 Then
    '        MsgBox("Record Updated Successfully!", MsgBoxStyle.Information, "Update")
    '    Else
    '        MsgBox("No record was updated. Check the Product ID.", MsgBoxStyle.Exclamation, "Update Failed")
    '    End If

    'Catch ex As Exception
    '    MsgBox("Error updating record: " & ex.Message)
    'Finally
    '    If conn.State = ConnectionState.Open Then
    '        conn.Close()
    '    End If
    'End Try

    'clear()
    'DGV_load()
    'txtboxProdID.ReadOnly = False
    'btnUpdate.Enabled = False
    'End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

                txtboxProdID.Text = row.Cells("ProductID").Value.ToString()
                txtboxProdName.Text = row.Cells("ProductName").Value.ToString()
                txtboxDescript.Text = row.Cells("Description").Value.ToString()
                txtboxPrice.Text = row.Cells("Price").Value.ToString()
                txtboxCategoryID.Text = row.Cells("CategoryID").Value.ToString()

                ' ✅ Correct way to set checkbox value
                If Not IsDBNull(row.Cells("IsAvailable").Value) Then
                    chkboxStatus.Checked = Convert.ToBoolean(row.Cells("IsAvailable").Value)
                Else
                    chkboxStatus.Checked = False
                End If

                ' (Optional) Always keep checkbox text constant
                chkboxStatus.Text = "Available"

                txtboxProdID.ReadOnly = True
            End If
        Catch ex As Exception
            MsgBox("Error loading record: " & ex.Message)
        End Try
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim op As ProductOperation = New DeleteProduct()
        op.Execute(Me)
        clear()
        DGV_load()
        'btnAdd.Enabled = True
        'txtboxProdID.ReadOnly = False
        'btnUpdate.Enabled = False

    End Sub



    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        'btnAdd.Enabled = True
        'txtboxProdID.ReadOnly = True
        'btnUpdate.Enabled = False
    End Sub



    'Public Sub delete()
    '    If MsgBox("You sure you want to delete this record?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
    '        Try
    '            If conn.State = ConnectionState.Closed Then
    '                conn.Open()
    '            End If

    '            Dim cmd As New SqlCommand("DELETE FROM   Products WHERE [ProductID] = @ProductID", conn)
    '            cmd.Parameters.Clear()
    '            cmd.Parameters.AddWithValue("@ProductID", txtboxProdID.Text)

    '            i = cmd.ExecuteNonQuery()

    '            If i > 0 Then
    '                MsgBox("Record Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                MsgBox("Delete failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        Finally
    '            If conn.State = ConnectionState.Open Then
    '                conn.Close()
    '            End If
    '        End Try
    '        clear()
    '        DGV_load()


    '    End If
    'End Sub


End Class