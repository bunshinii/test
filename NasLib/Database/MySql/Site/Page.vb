Namespace Database.MySql.Site

    Public Class Page

        Shared MyCmd As New Sql.Commands
        Private Shared TableName As String = "my_app_pages"


#Region "Database"

#Region "Schema Check"

        Private Shared Function IsPageExisted(PageName As String, Optional ByVal ConnectionString As String = "") As Boolean
            Dim ReturnValue As Boolean = False

            'MySql Setting
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            ReturnValue = MyCmd.CmdExisted(TableName, Criteria, ConnectionString)

            Return ReturnValue
        End Function

        Private Shared Function IsPageExisted(PageId As Integer, Optional ByVal ConnectionString As String = "") As Boolean
            Dim ReturnValue As Boolean = False

            'MySql Setting
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            ReturnValue = MyCmd.CmdExisted(TableName, Criteria, ConnectionString)

            Return ReturnValue
        End Function

        Private Shared Function CreatePage(PageName As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_name"
            Dim FieldValue As String = String.Format("""{0}""", PageName)

            Dim MyStr As String = MyCmd.CmdInsert2(TableName, FieldName, FieldValue, ConnectionString)
            Return MyStr
        End Function

#End Region

#Region "Get"

        Public Shared Function GetPageId(PageName As String, Optional ByVal ConnectionString As String = "") As Integer
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            Dim MyStr As String = Nothing

            If IsPageExisted(PageName, ConnectionString) Then
                MyStr = MyCmd.CmdSelectId(TableName, Criteria, ConnectionString)
            Else
                MyStr = "Page name not existed"
            End If

            Return MyStr
        End Function

        Public Shared Function GetPageName(PageId As Integer, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_name"
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = Nothing

            If IsPageExisted(PageId, ConnectionString) Then
                MyStr = MyCmd.CmdSelect(TableName, FieldName, 0, Criteria, , ConnectionString)
            Else
                MyStr = "Page ID not existed"
            End If

            Return MyStr
        End Function

        Public Shared Function GetPageTitle(PageId As Integer, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_title"
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = Nothing

            If IsPageExisted(PageId, ConnectionString) Then
                MyStr = MyCmd.CmdSelect(TableName, FieldName, 0, Criteria, , ConnectionString)
            Else
                MyStr = "Page ID not existed"
            End If

            Return MyStr
        End Function

        Public Shared Function GetPageTitle(PageName As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_title"
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            Dim MyStr As String = Nothing

            If IsPageExisted(PageName, ConnectionString) Then
                MyStr = MyCmd.CmdSelect(TableName, FieldName, 0, Criteria, , ConnectionString)
            Else
                MyStr = "Page name not existed"
            End If

            Return MyStr
        End Function

        Public Shared Function GetPageContent(PageId As Integer, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_content"
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = Nothing

            If IsPageExisted(PageId, ConnectionString) Then
                MyStr = MyCmd.CmdSelect(TableName, FieldName, 0, Criteria, , ConnectionString)
            Else
                MyStr = "Page ID not existed"
            End If

            Return MyStr
        End Function

        Public Shared Function GetPageContent(PageName As String, Optional ByVal ConnectionString As String = "") As String
            If Not IsPageExisted(PageName, ConnectionString) Then CreatePage(PageName, ConnectionString)

            Dim FieldName As String = "page_content"
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            Dim MyStr As String = MyCmd.CmdSelect2(TableName, FieldName, 0, Criteria, , ConnectionString)
            Return MyStr
        End Function

#End Region

#Region "Set"

        ''' <param name="NewPageName">No spaces</param>
        Public Shared Function SetPageName(PageId As Integer, NewPageName As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_name"
            Dim FieldValue As String = String.Format("""{0}""", NewPageName)
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = MyCmd.CmdUpdate3(TableName, FieldName, FieldValue, Criteria, ConnectionString)
            Return MyStr
        End Function

        Public Shared Function SetPageTitle(PageId As Integer, NewPageTitle As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_title"
            Dim FieldValue As String = String.Format("""{0}""", NewPageTitle)
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = MyCmd.CmdUpdate3(TableName, FieldName, FieldValue, Criteria, ConnectionString)
            Return MyStr
        End Function

        Public Shared Function SetPageTitle(PageName As String, NewPageTitle As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_title"
            Dim FieldValue As String = String.Format("""{0}""", NewPageTitle)
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            Dim MyStr As String = MyCmd.CmdUpdate3(TableName, FieldName, FieldValue, Criteria, ConnectionString)
            Return MyStr
        End Function

        Public Shared Function SetPageContent(PageId As Integer, NewPageContent As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_content"
            Dim FieldValue As String = String.Format("{0}", NewPageContent)
            Dim Criteria As String = String.Format("id = '{0}'", PageId)

            Dim MyStr As String = MyCmd.CmdUpdate3(TableName, FieldName, FieldValue, Criteria, ConnectionString)
            Return MyStr
        End Function

        Public Shared Function SetPageContent(PageName As String, NewPageContent As String, Optional ByVal ConnectionString As String = "") As String
            Dim FieldName As String = "page_content"
            Dim FieldValue As String = String.Format("{0}", NewPageContent)
            Dim Criteria As String = String.Format("page_name = ""{0}""", PageName)

            Dim MyStr As String = MyCmd.CmdUpdate3(TableName, FieldName, FieldValue, Criteria, ConnectionString)
            Return MyStr
        End Function

#End Region

#End Region

#Region "Local Drive"



#End Region

    End Class

End Namespace



