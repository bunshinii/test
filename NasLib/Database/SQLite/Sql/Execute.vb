Imports System.Data.SQLite

Namespace Database.SQLite.Sql

    Public Class Execute
        'Private Shared myDr As SQLiteDataReader
        'Private Shared myCmd As SQLiteCommand
        'Private Shared myConnect As SQLiteConnection ' = New SQLiteConnection(GlobalConnectionString)

#Region "Execute Non Query"

        ''' <summary>
        ''' Run Sql Command that not return any results
        ''' </summary>
        ''' <param name="SqlCommand">SQL Command</param>
        Friend Shared Function ExeNonQuery(ByVal SqlCommand As String, ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Command that not return any results (With One Parameters). Use when have commas or other symbols in the value
        ''' </summary>
        ''' <param name="SqlCommand">SQL Command</param>
        ''' <remarks>Only usable with CmdUpdate3()</remarks>
        Friend Shared Function ExeNonQuery2(ByVal SqlCommand As String, ByVal FieldsValue As String, ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                MyCmd.Parameters.Add("@Param1", DbType.String, 4000).Value = FieldsValue

                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Command that not return any results (With Multiple Parameters). Use when have commas or other symbols in the value.
        ''' PLEASE NOTICE the ConnectionString placing.
        ''' </summary>
        ''' <param name="SqlCommand">SQL Command</param>
        ''' <param name="FieldsValue">Multiple Field Values</param>
        ''' <remarks>Only usable with CmdUpdate4()</remarks>
        Friend Shared Function ExeNonQuery4(ByVal SqlCommand As String, FieldsValue() As String, ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)

                For i As Integer = 0 To FieldsValue.Count - 1
                    MyCmd.Parameters.Add("@Param" & i, DbType.String, 4000).Value = FieldsValue(i)
                Next

                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)

            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Command that not return any results (With One Parameters). Use when have commas or other symbols in the value
        ''' </summary>
        ''' <param name="SqlCommand">SQL Command</param>
        ''' <remarks>Only usable with CmdUpdate3()</remarks>
        Friend Shared Function ExeNonQueryDateTime(ByVal SqlCommand As String, ByVal FieldsValue As String, ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                MyCmd.Parameters.Add("@Param1", DbType.String, 50).Value = FieldsValue

                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function


        ''' <summary>
        ''' Run Sql Command that not return any results (With One Parameters). Use when handling binary data
        ''' </summary>
        ''' <param name="SqlCommand">SQL Command</param>
        ''' <remarks>Only usable with CmdUpdateBlob()</remarks>
        Friend Shared Function ExeNonQueryBlob(ByVal SqlCommand As String, ByVal FieldsValue As Byte(), ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                MyCmd.Parameters.Add("@Param1", DbType.Binary).Value = FieldsValue

                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Command that not return any results. (With multiple Parameters). Not supporting comma in a value.
        ''' </summary>
        ''' <param name="SqlCommandWithParams">SQL Command with parameters (e.g. @Param0). Params must started with @Param0</param>
        ''' <param name="FieldsValue">Fields Value (seperated by a comma)</param>
        Friend Shared Function ExeNonQuery3(ByVal SqlCommandWithParams As String, ByVal FieldsValue As String, ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Dim MyFieldsValue() As String = FieldsValue.Split(",")
            Dim CountFieldsValue As Integer = MyFieldsValue.Count - 1

            Try
                MyCmd = New SQLiteCommand(SqlCommandWithParams, myConnect)

                For i As Integer = 0 To CountFieldsValue
                    MyFieldsValue(i) = MyFieldsValue(i).Trim
                    MyCmd.Parameters.Add("@Param" & i, DbType.String, 4000).Value = MyFieldsValue(i)
                Next

                myConnect.Open()
                MyCmd.ExecuteNonQuery()
                ReturnValue = True

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                ReturnValue = False
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
            Finally
                Logger.MySqlCmdWithParamLog(SqlCommandWithParams, FieldsValue)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Execute Query"

        ''' <summary>
        ''' Run Sql Commands that return results as string. (Return only one field)
        ''' </summary>
        ''' <param name="SqlCommand">Sql Command</param>
        ''' <param name="ReturnField">Field value to return</param>
        Friend Shared Function ExeQuery(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As String
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As String = Nothing
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr = MyCmd.ExecuteReader()
                myDr.Read()

                If Not IsDBNull(myDr(ReturnField)) Then ReturnValue = myDr(ReturnField)
                myDr.Close()
                If Not myDr.IsClosed Then myDr.Close()

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = ex.Message
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = ex.Message
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Commands that return results as string. (Return only one field).
        ''' Use for Counting only.
        ''' </summary>
        ''' <param name="SqlCommand">Sql Command</param>
        ''' <param name="ReturnField">Field value to return</param>
        Friend Shared Function ExeQueryCount(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As Integer
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As String = Nothing
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr_ As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr_ = MyCmd.ExecuteReader()
                myDr_.Read()

                If Not IsDBNull(myDr_(ReturnField)) Then ReturnValue = myDr_(ReturnField)

                myDr_.Close()
                If Not myDr_.IsClosed Then myDr_.Close()

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = ex.Message
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = ex.Message
            Finally
                Logger.MySqlCmdLog(SqlCommand)

            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            If Not IsNumeric(ReturnValue) Then ReturnValue = 0
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Commands that return results as string. (Return only one field).
        ''' Use to check if the data existed only.
        ''' The SQL Commad must use to count.
        ''' </summary>
        ''' <param name="SqlCommand">Sql Command (Count Command)</param>
        ''' <param name="ReturnField">Field value to return</param>
        Friend Shared Function ExeQueryExisted(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As Boolean


            Dim ReturnValue As Boolean = False
            Dim MyStr As String = Nothing
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)
            Dim myCmd_ As SQLiteCommand = New SQLiteCommand(SqlCommand, myConnect)

            Try
                myConnect.Open()
                Dim myDr_ As SQLiteDataReader
                myDr_ = myCmd_.ExecuteReader()
                myDr_.Read()

                If Not IsDBNull(myDr_(ReturnField)) Then MyStr = myDr_(ReturnField)
                myDr_.Close()
                If Not myDr_.IsClosed Then myDr_.Close()

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(myCmd_.CommandText, ex.Message, ConnectionString)
                MyStr = ex.Message
            Catch ex As Exception
                Logger.MySqlError(myCmd_.CommandText, ex.Message, ConnectionString)
                MyStr = ex.Message
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try


            myConnect.Dispose()
            myCmd_.Dispose()

            Dim MyCount As Integer = 0

            If IsNumeric(MyStr) Then MyCount = MyStr
            If MyCount > 0 Then ReturnValue = True

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Same as ExeQuery but returns 0 if error. Use when retrieving integer or id
        ''' </summary>
        Friend Shared Function ExeQuery0(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As Integer
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As String = 0
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr = MyCmd.ExecuteReader()
                myDr.Read()

                ReturnValue = myDr(ReturnField)
                If Not IsNumeric(ReturnValue) Then ReturnValue = 0

                myDr.Close()
                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = 0
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = 0
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Same as ExeQuery but returns True or False. Use when retrieving a boolean.
        ''' Only works with 'TINYINT' data type.
        ''' Error will return FALSE'
        ''' </summary>
        Friend Shared Function ExeQueryBool(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As Boolean
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Boolean = False
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr = MyCmd.ExecuteReader()
                myDr.Read()

                ReturnValue = myDr(ReturnField)

                myDr.Close()
                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = False
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Same as ExeQuery but returns empty string if error
        ''' </summary>
        Friend Shared Function ExeQuery2(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As String
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As String = Nothing
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr = MyCmd.ExecuteReader()
                myDr.Read()

                If Not IsDBNull(myDr(ReturnField)) Then ReturnValue = myDr(ReturnField)

                myDr.Close()
                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                Dim MyStr As String = ex.Message
                ReturnValue = String.Empty
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                ReturnValue = String.Empty
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run Sql Commands that return results as binary data. (Return only one field)
        ''' </summary>
        ''' <param name="SqlCommand">Sql Command</param>
        ''' <param name="ReturnField">Field value to return</param>
        Friend Shared Function ExeQueryBlob(ByVal SqlCommand As String, ByVal ReturnField As Integer, ByVal ConnectionString As String) As Byte()
            Dim MyCmd As New SQLiteCommand

            Dim ReturnValue As Byte() = {Nothing}
            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Try
                Dim myDr As SQLiteDataReader
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                myDr = MyCmd.ExecuteReader()
                myDr.Read()
                If Not IsDBNull(myDr(ReturnField)) Then ReturnValue = myDr(ReturnField)

                myDr.Close()
                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                Dim MyStr As String = ex.Message
                'ReturnValue = Nothing
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                'ReturnValue = Nothing
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Return the whole Table as DataTable (For Web Apllication)
        ''' </summary>
        ''' <param name="SqlCommand">Sql Command</param>
        Friend Shared Function ExeQueryTable(ByVal SqlCommand As String, ConnectionString As String) As DataTable
            Dim MyCmd As New SQLiteCommand

            Dim myConnect As SQLiteConnection = New SQLiteConnection(ConnectionString)

            Dim conn As SQLiteConnection = Nothing
            Dim dt As DataTable = New DataTable()
            Try
                MyCmd = New SQLiteCommand(SqlCommand, myConnect)
                myConnect.Open()
                Dim dr As SQLiteDataReader = MyCmd.ExecuteReader(CommandBehavior.CloseConnection)

                dt.Load(dr)

                myConnect.Close()
            Catch ex As SQLiteException
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                Dim MyStr As String = ex.Message
                dt(0)(0) = MyStr
            Catch ex As Exception
                Logger.MySqlError(MyCmd.CommandText, ex.Message, ConnectionString)
                Dim MyStr As String = ex.Message
                dt(0)(0) = MyStr
            Finally
                Logger.MySqlCmdLog(SqlCommand)
            End Try

            myConnect.Dispose()
            MyCmd.Dispose()

            Return dt
        End Function

#End Region

    End Class

End Namespace

