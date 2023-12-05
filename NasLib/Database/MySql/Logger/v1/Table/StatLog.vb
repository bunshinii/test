Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Logger.v1.Table

    ''' <summary>
    ''' This is a table base class base on table 'stat_log'
    ''' </summary>
    Public Class StatLog

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stat_log"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            date_time
            method
            uri
            uri_top
            app_file_path
            username
            ip
            version
            user_agent
            referer
            referer_top
            query_string
            browser_name
            browser_version
            platform
            is_mobile
            mobile_manufacturer
            mobile_model
            px_width
            px_height
            size
            app_id
        End Enum

#End Region

#Region "Field Properties"

        Public Shared Property UriTop(ByVal LogId As Integer, StatsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.uri_top.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, LogId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.uri_top.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, LogId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property

        Public Shared Property RefererTop(ByVal LogId As Integer, StatsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.referer_top.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, LogId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.referer_top.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, LogId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property



#End Region


#Region "Examples"
        'Run from actual link : http://localhost:8182/Account/Default.aspx

        'Context.Request.ApplicationPath :							/
        'Context.Request.AppRelativeCurrentExecutionFilePath :		~/Account/Default.aspx
        'Context.Request.ContentEncoding.ToString : 				System.Text.UTF8Encoding
        'Context.Request.ContentLength : 							219
        'Context.Request.ContentType : 								application/x-www-form-urlencoded
        'Context.Request.CurrentExecutionFilePath : 				/Account/Default.aspx
        'Context.Request.CurrentExecutionFilePathExtension : 		.aspx
        'Context.Request.FilePath : 								/Account/Default.aspx
        'Context.Request.HttpMethod : 								POST
        'Context.Request.IsSecureConnection : 						False
        'Context.Request.Path : 									/Account/Default.aspx
        'Context.Request.PhysicalApplicationPath : 					E:\PTAR Projects\LibStats\LibStats\
        'Context.Request.PhysicalPath : 							E:\PTAR Projects\LibStats\LibStats\Account\Default.aspx
        'Context.Request.RawUrl : 									/Account/Default.aspx
        'Context.Request.RequestContext.HttpContext.ToString : 		System.Web.HttpContextWrapper
        'Context.Request.RequestType : 								POST
        'Context.Request.TotalBytes : 								219
        'Context.Request.Url.AbsolutePath : 						/Account/Default.aspx
        'Context.Request.UrlReferrer.AbsolutePath : 				/Account/Default.aspx
        'Context.Request.Url.AbsoluteUri : 							http://localhost:8182/Account/Default.aspx
        'Context.Request.UrlReferrer.AbsoluteUri : 					http://localhost:8182/Account/Default.aspx
        'Context.Request.UserAgent : 								Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36
        'Context.Request.UserHostAddress : 							::1
        'Context.Request.UserHostName : 							::1
#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Insert Log. Will return current ID
        ''' </summary>
        Public Shared Function InsertLog(AppId As Guid, context As System.Web.HttpContext, ProviderConnectionString As String) As String
            Dim Method As String = context.Request.HttpMethod
            Dim Uri As String = context.Request.Url.AbsoluteUri
            Dim AppFilePath As String = context.Request.AppRelativeCurrentExecutionFilePath
            Dim Username As String = context.Request.ServerVariables("AUTH_USER")
            Dim Ip As String = context.Request.ServerVariables("REMOTE_ADDR")
            Dim Version As String = context.Request.ServerVariables("SERVER_PROTOCOL")
            Dim User_Agent As String = context.Request.UserAgent
            Dim Referer As String = context.Request.ServerVariables("HTTP_REFERER")
            Dim Query_String As String = context.Request.ServerVariables("QUERY_STRING")

            Dim Browse As System.Web.HttpBrowserCapabilities = context.Request.Browser

            Dim BrowserName As String = Browse.Browser
            Dim BrowserVersion As String = Browse.Version
            Dim Platform As String = Browse.Platform
            Dim IsMobileDevice As Boolean = Browse.IsMobileDevice
            Dim MobileDeviceManufacturer As String = Browse.MobileDeviceManufacturer
            Dim MobileDeviceModel As String = Browse.MobileDeviceModel
            Dim ScreenPixelsWidth As Integer = Browse.ScreenPixelsWidth
            Dim ScreenPixelsHeight As Integer = Browse.ScreenPixelsHeight
            Dim TotalBytes As Integer = context.Request.TotalBytes

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.date_time.ToString, _
                eFieldName.method.ToString, _
                eFieldName.uri.ToString, _
                eFieldName.app_file_path.ToString, _
                eFieldName.username.ToString, _
                eFieldName.ip.ToString, _
                eFieldName.version.ToString, _
                eFieldName.user_agent.ToString, _
                eFieldName.referer.ToString, _
                eFieldName.query_string.ToString, _
                eFieldName.browser_name.ToString, _
                eFieldName.browser_version.ToString, _
                eFieldName.platform.ToString, _
                eFieldName.is_mobile.ToString, _
                eFieldName.mobile_manufacturer.ToString, _
                eFieldName.mobile_model.ToString, _
                eFieldName.px_width.ToString, _
                eFieldName.px_height.ToString, _
                eFieldName.size.ToString, _
                eFieldName.app_id.ToString _
                )

            If String.IsNullOrEmpty(Referer) Then Referer = ""

            Dim MyFieldsValue As String = FieldValues( _
                Now, _
                Method, _
                Uri, _
                AppFilePath, _
                Username, _
                Ip, _
                Version, _
                User_Agent, _
                Referer, _
                Query_String, _
                BrowserName, _
                BrowserVersion, _
                Platform, _
                IsMobileDevice, _
                MobileDeviceManufacturer, _
                MobileDeviceModel, _
                ScreenPixelsWidth, _
                ScreenPixelsHeight, _
                TotalBytes, _
                AppId _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Insert Log. Will return current ID
        ''' </summary>
        Public Shared Function InsertLog(AppId As Guid, ProviderConnectionString As String) As String
            Dim context As System.Web.HttpContext = Web.HttpContext.Current

            Return InsertLog(AppId, context, ProviderConnectionString)
        End Function

#End Region

#Region "Update"



#End Region

#Region "Delete"

        'Public Shared Function RoleDelete(RoleId As Integer, ProviderConnectionString As String) As Boolean
        '    Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
        '    Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        'End Function

        'Public Shared Function RoleDelete(RoleName As String, ProviderConnectionString As String) As Boolean
        '    Return RoleDelete(Id(RoleName, ProviderConnectionString), ProviderConnectionString)
        'End Function

#End Region

#Region "DataTables"

        'Public Shared Function GetAllRoles(ProviderConnectionString As String) As DataTable
        '    Dim _FieldName As String = FieldNames( _
        '        eFieldName.id.ToString, _
        '        eFieldName.name.ToString)

        '    Dim Other As String = OrderBy(eFieldName.name)

        '    Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, ProviderConnectionString)
        'End Function

        ' ''' <summary>
        ' ''' Get Non Admin Roles.
        ' ''' The query just filterd out words 'admin, moderator, super
        ' ''' </summary>
        'Public Shared Function GetAllNormalRoles(ProviderConnectionString As String) As DataTable
        '    Dim _FieldName As String = FieldNames( _
        '        eFieldName.id.ToString, _
        '        eFieldName.name.ToString)

        '    Dim MyCriteria As String = CriteriasAND( _
        '        CriteriaNotLike(eFieldName.name.ToString, "%admin%"), _
        '        CriteriaNotLike(eFieldName.name.ToString, "%moderator%"), _
        '        CriteriaNotLike(eFieldName.name.ToString, "%super%") _
        '        )

        '    Dim Other As String = OrderBy(eFieldName.name)

        '    Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, ProviderConnectionString)
        'End Function

#End Region

#End Region

    End Class

End Namespace


