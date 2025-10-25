' ===============================================
' CENTRALIZED DATABASE CONNECTION - USAGE EXAMPLES
' ===============================================
' This file shows examples of how to use the centralized DatabaseConnection class
' in your GrillMate POS application. You can delete this file after reviewing the examples.

Imports System.Data.SqlClient

Public Class DatabaseConnectionExamples

    ' ===============================================
    ' EXAMPLE 1: Simple SELECT query
    ' ===============================================
    Public Sub Example1_SimpleSelect()
        Try
            ' Get all categories
            Dim query As String = "SELECT CategoryID, CategoryName FROM MenuCategories ORDER BY CategoryName"
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query)
                While reader.Read()
                    Dim categoryId As Integer = reader("CategoryID")
                    Dim categoryName As String = reader("CategoryName").ToString()
                    ' Process the data...
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 2: SELECT with parameters
    ' ===============================================
    Public Sub Example2_SelectWithParameters()
        Try
            ' Get products by category
            Dim query As String = "SELECT ProductName, Price FROM Products WHERE CategoryID = @CategoryID AND IsAvailable = 1"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@CategoryID", 1)
            }
            Using reader As SqlDataReader = DatabaseConnection.ExecuteReader(query, parameters)
                While reader.Read()
                    Dim productName As String = reader("ProductName").ToString()
                    Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                    ' Process the data...
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 3: INSERT with parameters
    ' ===============================================
    Public Sub Example3_InsertWithParameters()
        Try
            ' Insert a new order
            Dim query As String = "INSERT INTO Orders (TableID, OrderNumber, OrderType, OrderStatus) VALUES (@TableID, @OrderNumber, @OrderType, @OrderStatus)"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@TableID", 1),
                DatabaseConnection.CreateParameter("@OrderNumber", "ORD-001"),
                DatabaseConnection.CreateParameter("@OrderType", "Dine-In"),
                DatabaseConnection.CreateParameter("@OrderStatus", "Pending")
            }
            Dim rowsAffected As Integer = DatabaseConnection.ExecuteNonQuery(query, parameters)
            MessageBox.Show($"Order inserted successfully. Rows affected: {rowsAffected}")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 4: UPDATE with parameters
    ' ===============================================
    Public Sub Example4_UpdateWithParameters()
        Try
            ' Update table status
            Dim query As String = "UPDATE Tables SET Status = @Status WHERE TableID = @TableID"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Status", "Occupied"),
                DatabaseConnection.CreateParameter("@TableID", 1)
            }
            Dim rowsAffected As Integer = DatabaseConnection.ExecuteNonQuery(query, parameters)
            MessageBox.Show($"Table updated successfully. Rows affected: {rowsAffected}")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 5: Scalar query (single value)
    ' ===============================================
    Public Sub Example5_ScalarQuery()
        Try
            ' Get count of products
            Dim query As String = "SELECT COUNT(*) FROM Products WHERE IsAvailable = 1"
            Dim count As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query))
            MessageBox.Show($"Total available products: {count}")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 6: Scalar query with parameters
    ' ===============================================
    Public Sub Example6_ScalarWithParameters()
        Try
            ' Check if user exists
            Dim query As String = "SELECT COUNT(*) FROM Users WHERE Users = @Username AND Password = @Password"
            Dim parameters() As SqlParameter = {
                DatabaseConnection.CreateParameter("@Username", "staff"),
                DatabaseConnection.CreateParameter("@Password", "staff123")
            }
            Dim count As Integer = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters))
            If count > 0 Then
                MessageBox.Show("User authentication successful!")
            Else
                MessageBox.Show("Invalid credentials.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================================
    ' EXAMPLE 7: Test database connection
    ' ===============================================
    Public Sub Example7_TestConnection()
        If DatabaseConnection.TestConnection() Then
            MessageBox.Show("Database connection successful!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Database connection failed!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ===============================================
    ' EXAMPLE 8: Get connection string
    ' ===============================================
    Public Sub Example8_GetConnectionString()
        Dim connectionString As String = DatabaseConnection.ConnectionString
        MessageBox.Show($"Current connection string: {connectionString}", "Connection String", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ===============================================
    ' EXAMPLE 9: Using multiple parameters helper
    ' ===============================================
    Public Sub Example9_MultipleParametersHelper()
        Try
            ' Using the CreateParameters helper for multiple parameters
            Dim query As String = "INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price) VALUES (@OrderID, @ProductID, @Quantity, @Price)"
            Dim parameters() As SqlParameter = DatabaseConnection.CreateParameters(
                "@OrderID", 1,
                "@ProductID", 5,
                "@Quantity", 2,
                "@Price", 25.50
            )
            Dim rowsAffected As Integer = DatabaseConnection.ExecuteNonQuery(query, parameters)
            MessageBox.Show($"Order item inserted successfully. Rows affected: {rowsAffected}")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

' ===============================================
' BENEFITS OF CENTRALIZED DATABASE CONNECTION
' ===============================================
'
' 1. CONSISTENCY: All forms use the same connection string
' 2. MAINTAINABILITY: Change connection string in one place
' 3. ERROR HANDLING: Centralized error handling
' 4. SECURITY: Connection string is not scattered across forms
' 5. TESTING: Easy to test database connectivity
' 6. PERFORMANCE: Reusable connection logic
' 7. PARAMETERIZED QUERIES: Built-in SQL injection protection
'
' ===============================================
' HOW TO CHANGE CONNECTION STRING
' ===============================================
'
' To change the database connection string, simply modify the 
' _connectionString variable in DatabaseConnection.vb:
'
' Private Shared ReadOnly _connectionString As String = "Your_New_Connection_String_Here"
'
' ===============================================
' AVAILABLE METHODS IN DatabaseConnection CLASS
' ===============================================
'
' - GetConnection() : Returns a new SqlConnection
' - TestConnection() : Tests if database is accessible
' - ExecuteScalar(query, parameters) : Returns single value
' - ExecuteNonQuery(query, parameters) : Executes INSERT/UPDATE/DELETE
' - ExecuteReader(query, parameters) : Returns SqlDataReader
' - CreateParameter(name, value) : Creates SqlParameter
' - CreateParameters(...) : Creates multiple SqlParameters
' - ConnectionString : Gets the current connection string
