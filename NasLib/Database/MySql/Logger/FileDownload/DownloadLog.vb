Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Logger.FileDownload

    ''' <summary>
    ''' This is a table base class base on table 'stat_log'
    ''' </summary>
    Public Class DownloadLog

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "download_log"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            date_time
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
            file_guid
        End Enum

#End Region

#Region "Field Properties"


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
        Public Shared Function InsertLog(FileGuid As Guid, context As System.Web.HttpContext, FileBrowserConnectionString As String) As String
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
                eFieldName.file_guid.ToString
                )

            If String.IsNullOrEmpty(Referer) Then Referer = ""

            Dim MyFieldsValue As String = FieldValues( _
                Now, _
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
                FileGuid
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, FileBrowserConnectionString)
        End Function

        ''' <summary>
        ''' Insert Log. Will return current ID
        ''' </summary>
        Public Shared Function InsertLog(FileGuid As Guid, FileBrowserConnectionString As String) As String
            Dim context As System.Web.HttpContext = Web.HttpContext.Current

            Return InsertLog(FileGuid, context, FileBrowserConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


