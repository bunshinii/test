Imports System.Data.OleDb


Namespace Database.Excel.Sql

    Public Class Execute

        'ConnectionString
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:\test.xlsx;Extended Properties=Excel 12.0"    '<-- For *.xlsx
        '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\test.xls;Extended Properties=Excel 8.0"       '<-- For *.xls

        'Dim SqlCommand As String = String.Format("SELECT * FROM [{0}${1}{2}:{1}{2}]", WorkSheetName, MyColumn, MyRow)
        'Dim SqlCommand As String = "Select * from [Sheet1$]"

        '"UPDATE [Sheet1$A5:A5] set F1=999"
        'INSERT INTO [NameOfExcelSheet] VALUES('firsttextcol', 2, '4/11/2009');
        'DELETE FROM [NameOfExcelSheet] Where secondintcol=2;
        'UPDATE [NameOfExcelSheet] SET secondintcol = 3 where firsttextcol = ‘firsttextcol’;

        Private Shared myConnect As OleDbConnection '= New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\test.xls;Extended Properties=Excel 8.0")

        ''' <summary>
        ''' Return the whole Table as DataTable (For Web Apllication)
        ''' </summary>
        ''' <param name="SqlCommand">Excel Sql Command</param>
        Public Shared Function ExeQueryTable(ByVal SqlCommand As String, ConnectionString As String) As DataTable
            myConnect = New OleDbConnection(ConnectionString)

            Dim dt As DataTable = New DataTable()
            Try
                Dim cmd As OleDbCommand = New OleDbCommand(SqlCommand, myConnect)
                myConnect.Open()
                Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                dt.Load(dr)

            Catch ex As OleDb.OleDbException
                Dim MyStr As String = ex.Message
                dt(0)(0) = MyStr
            Catch ex As Exception
                Dim MyStr As String = ex.Message
                dt(0)(0) = MyStr
            Finally
                myConnect.Close()
            End Try

            Return dt
        End Function

    End Class

End Namespace


