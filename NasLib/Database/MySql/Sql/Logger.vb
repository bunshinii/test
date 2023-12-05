Imports System.IO
Imports MySql.Data.MySqlClient


Namespace Database.MySql.Sql
    Friend Class Logger

#Region "Enable / Disable Log"
        Private Shared EnableMySqlErrorLog As Boolean = True
        Private Shared EnableMySqlCmdLog As Boolean = False
#End Region

#Region "EnableMySqlErrorLog"

        Friend Shared Sub MySqlError(SqlString As String, ErrorString As String, ConnectionString As String)
            If Not EnableMySqlErrorLog Then Exit Sub

            If ErrorString = "Invalid attempt to access a field before calling Read()" Or ErrorString = "Index was outside the bounds of the array." Then Exit Sub

            Dim MyConnectionString As New MySqlConnectionStringBuilder(ConnectionString)

            Dim LogStr As String = _
                "Date           :  " & DateTime.Now & Environment.NewLine & _
                "MySQL Server   :  " & MyConnectionString.Server & Environment.NewLine & _
                "MySQL Database :  " & MyConnectionString.Database & Environment.NewLine & _
                "Sql Command    :  " & SqlString & Environment.NewLine & _
                "Error Message  :  " & ErrorString & Environment.NewLine

            Dim sPath As String = AppDomain.CurrentDomain.BaseDirectory & "Errors\"
            If Not Directory.Exists(sPath) Then Directory.CreateDirectory(sPath)

            Dim strFile As String = String.Format("{0}MySqlError_{1}.txt", sPath, DateTime.Today.ToString("yyyyMMdd"))
            File.AppendAllText(strFile, LogStr & Environment.NewLine & Environment.NewLine)
        End Sub

#End Region

#Region "EnableMySqlCmdLog"

        Friend Shared Sub MySqlCmdLog(SqlString As String)
            If Not EnableMySqlCmdLog Then Exit Sub

            Dim LogStr As String = _
                Format(Now, "HH:mm:ss : ") & _
                SqlString & Environment.NewLine

            Dim sPath As String = AppDomain.CurrentDomain.BaseDirectory & "Logs\"
            If Not Directory.Exists(sPath) Then Directory.CreateDirectory(sPath)

            Dim strFile As String = String.Format("{0}MySqlCmdLog_{1}.txt", sPath, DateTime.Today.ToString("yyyyMMdd"))
            File.AppendAllText(strFile, LogStr)
        End Sub

        Friend Shared Sub MySqlCmdWithParamLog(SqlString As String, Param As String)
            If Not EnableMySqlCmdLog Then Exit Sub

            Dim LogStr As String = _
                Format(Now, "HH:mm:ss : ") & _
                SqlString & " - PARAM : " & Param & Environment.NewLine

            Dim sPath As String = AppDomain.CurrentDomain.BaseDirectory & "Logs\"
            If Not Directory.Exists(sPath) Then Directory.CreateDirectory(sPath)

            Dim strFile As String = String.Format("{0}MySqlCmdLog_{1}.txt", sPath, DateTime.Today.ToString("yyyyMMdd"))
            File.AppendAllText(strFile, LogStr)
        End Sub

#End Region

    End Class

End Namespace

