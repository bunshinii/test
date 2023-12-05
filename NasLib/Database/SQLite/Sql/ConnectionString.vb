Namespace Database.SQLite.Sql

    Public Class ConnectionString

        'Just import the namespace.

#Region "SQLite ConnectionString"

        ''' <summary>
        ''' SQLite ConnectionString by filename. The file must exist in 'App_Data' folder. 
        ''' For version 3 only
        ''' </summary>
        ''' <param name="Filename">SQLite Filename</param>
        Public Shared Function SQLite3Conn(Filename As String) As String
            Dim ReturnValue As String = String.Format("Data Source=|DataDirectory|{0};Version=3;", Filename)
            Return ReturnValue
        End Function


#End Region

    End Class

End Namespace


