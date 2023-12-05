Namespace Database.MySql.Site.Setting

    Public Class Application

        Shared MyCmd As New Sql.Commands
        Private Shared TableName As String = "my_app_setting"
        Private Shared FieldName As String = "setting_value"
        Private Shared Other As String = "LIMIT 1"

#Region "Application"



        Public Shared Function GetSetting(Keyword As String, Optional ByVal ConnectionString As String = "") As String
            Dim Criteria As String = String.Format("setting_name = ""{0}""", Keyword)
            Return MyCmd.CmdSelect2(TableName, FieldName, 0, Criteria, Other, ConnectionString)
        End Function

        Public Shared Function SetSetting(Keyword As String, SettingValue As String, Optional ByVal ConnectionString As String = "") As String
            Dim Criteria As String = String.Format("setting_name = ""{0}""", Keyword)
            Return MyCmd.CmdUpdate3(TableName, FieldName, SettingValue, Criteria, ConnectionString)
        End Function



#End Region



    End Class

End Namespace


