Namespace Database.MySql.Site.Setting

    Public Class ControlText

        Shared MyCmd As New Sql.Commands
        Private Shared TableName As String = "my_app_lang"
        Private Shared Other As String = "LIMIT 1"


        Public Shared Function GetText(Key As String, Optional ByVal TextLanguage As String = "en", Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = TextLanguage
            Dim Criteria As String = String.Format("langKey = ""{0}""", Key)
            Return MyCmd.CmdSelect2(TableName, FieldName, 0, Criteria, Other, ConnectionString)
        End Function

        Public Shared Function SetText(Key As String, NewText As String, Optional ByVal TextLanguage As String = "en", Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = TextLanguage
            Dim Criteria As String = String.Format("setting_name = ""{0}""", Key)
            Return MyCmd.CmdUpdate3(TableName, FieldName, NewText, Criteria, ConnectionString)
        End Function




    End Class

End Namespace


