Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatabaseConnection
    Private Shared ReadOnly _connectionString As String = "Server=localhost;Database=POS;Integrated Security=True;TrustServerCertificate=True;"

    ' Private Shared ReadOnly _connectionString As String = "Server=AEGON;Database=POS;Integrated Security=True;TrustServerCertificate=True;"
    ' Private Shared ReadOnly _connectionString As String = "Data Source=Aegon;Initial Catalog=POS;Integrated Security=True"

    'Public Shared ReadOnly Property ConnectionString As String
    '    Get
    '        Return _connectionString
    '    End Get
    'End Property

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(_connectionString)
    End Function

    Public Shared Function TestConnection() As Boolean
        Try
            Using connection As SqlConnection = GetConnection()
                connection.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Executes a scalar query and returns the result
    ''' </summary>
    ''' <param name="query">SQL query to execute</param>
    ''' <param name="parameters">Optional parameters for the query</param>
    ''' <returns>Result of the scalar query</returns>
    Public Shared Function ExecuteScalar(query As String, Optional parameters As SqlParameter() = Nothing) As Object
        Try
            Using connection As SqlConnection = GetConnection()
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    Return command.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Executes a non-query command (INSERT, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="query">SQL query to execute</param>
    ''' <param name="parameters">Optional parameters for the query</param>
    ''' <returns>Number of rows affected</returns>
    Public Shared Function ExecuteNonQuery(query As String, Optional parameters As SqlParameter() = Nothing) As Integer
        Try
            Using connection As SqlConnection = GetConnection()
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If
                    Return command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Executes a query and returns a SqlDataReader
    ''' </summary>
    ''' <param name="query">SQL query to execute</param>
    ''' <param name="parameters">Optional parameters for the query</param>
    ''' <returns>SqlDataReader for the query results</returns>
    Public Shared Function ExecuteReader(query As String, Optional parameters As SqlParameter() = Nothing) As SqlDataReader
        Try
            Dim connection As SqlConnection = GetConnection()
            connection.Open()
            Dim command As New SqlCommand(query, connection)
            If parameters IsNot Nothing Then
                command.Parameters.AddRange(parameters)
            End If
            Return command.ExecuteReader()
        Catch ex As Exception
            Throw New Exception("Database error: " & ex.Message, ex)
        End Try
    End Function

    ''' <summary>
    ''' Helper method to create SqlParameter
    ''' </summary>
    ''' <param name="parameterName">Parameter name (with @ prefix)</param>
    ''' <param name="value">Parameter value</param>
    ''' <returns>SqlParameter object</returns>
    Public Shared Function CreateParameter(parameterName As String, value As Object) As SqlParameter
        Return New SqlParameter(parameterName, value)
    End Function

    ''' <summary>
    ''' Helper method to create multiple SqlParameters
    ''' </summary>
    ''' <param name="parameters">Array of parameter name-value pairs</param>
    ''' <returns>Array of SqlParameter objects</returns>
    Public Shared Function CreateParameters(ParamArray parameters() As Object) As SqlParameter()
        If parameters.Length Mod 2 <> 0 Then
            Throw New ArgumentException("Parameters must be in name-value pairs")
        End If

        Dim sqlParams As New List(Of SqlParameter)
        For i As Integer = 0 To parameters.Length - 1 Step 2
            sqlParams.Add(New SqlParameter(parameters(i).ToString(), parameters(i + 1)))
        Next
        Return sqlParams.ToArray()
    End Function
End Class
