Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Logger.v1.Table

    ''' <summary>
    ''' This is a table base class base on table 'stat_applications'
    ''' </summary>
    Public Class StatApplications

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stat_applications"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            app_guid    'Primary
            app_name    'Unique
            app_desc
            username
            date_time
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "guid"

        Public Shared Function ApplicationGuid(_ApplicationName As String, StatsConnectionString As String) As Guid
            Dim ReturnValue As Guid = New Guid()

            Dim MyFieldName As String = eFieldName.app_guid.ToString
            Dim MyCriteria As String = Criteria(eFieldName.app_name.ToString, _ApplicationName)

            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)

            Try
                Dim newGuid As Guid = New Guid(MyStr)
                ReturnValue = newGuid
            Catch e As ArgumentNullException
                Dim Mye As String = e.Message
            Catch e As FormatException
                Dim Mye As String = e.Message
            End Try

            Return ReturnValue
        End Function

        Public Shared Function Id(_ApplicationName As String, StatsConnectionString As String) As Guid
            Return ApplicationGuid(_ApplicationName, StatsConnectionString)
        End Function

#End Region

#Region "Name"

        Public Shared Property ApplicationName(ByVal _AppGuid As Guid, StatsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.app_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.app_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationName(ByVal _AppName As String, StatsConnectionString As String) As String
            Get
                Return ApplicationName(Id(_AppName, StatsConnectionString), StatsConnectionString)
            End Get
            Set(value As String)
                ApplicationName(Id(_AppName, StatsConnectionString), StatsConnectionString) = value
            End Set
        End Property

#End Region

#Region "Desc"

        Public Shared Property ApplicationDesc(ByVal _AppGuid As Guid, StatsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.app_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.app_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationDesc(ByVal _AppName As String, StatsConnectionString As String) As String
            Get
                Return ApplicationDesc(Id(_AppName, StatsConnectionString), StatsConnectionString)
            End Get
            Set(value As String)
                ApplicationDesc(Id(_AppName, StatsConnectionString), StatsConnectionString) = value
            End Set
        End Property

#End Region

#Region "username"

        Public Shared Property Username(ByVal _AppGuid As Guid, StatsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.username.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.username.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property

        Public Shared Property Username(ByVal _AppName As String, StatsConnectionString As String) As String
            Get
                Return Username(Id(_AppName, StatsConnectionString), StatsConnectionString)
            End Get
            Set(value As String)
                Username(Id(_AppName, StatsConnectionString), StatsConnectionString) = value
            End Set
        End Property

#End Region

#Region "date_time"

        Public Shared Property RegDate(ByVal _AppGuid As Guid, StatsConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = eFieldName.date_time.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , StatsConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = eFieldName.date_time.ToString
                Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, _AppGuid)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, StatsConnectionString)
            End Set
        End Property

        Public Shared Property RegDate(ByVal AppName As String, StatsConnectionString As String) As DateTime
            Get
                Return RegDate(Id(AppName, StatsConnectionString), StatsConnectionString)
            End Get
            Set(value As DateTime)
                RegDate(Id(AppName, StatsConnectionString), StatsConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(AppGuid As Guid, StatsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, AppGuid)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, StatsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(AppName As String, StatsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.app_name.ToString, AppName)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, StatsConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(StatsConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , StatsConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New Application. Will return Application Guid
        ''' </summary>
        Public Shared Function ApplicationInsert(AppName As String, AppDesc As String, Username As String, StatsConnectionString As String) As Guid
            Dim MyGuid As Guid = System.Guid.NewGuid

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.app_guid.ToString, _
                eFieldName.app_name.ToString, _
                eFieldName.app_desc.ToString, _
                eFieldName.username.ToString, _
                eFieldName.date_time.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                MyGuid, _
                AppName, _
                AppDesc, _
                Username, _
                Now _
                )

            MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, StatsConnectionString)

            Return MyGuid
        End Function

#End Region

#Region "Delete"

        Public Shared Function ApplicationDelete(AppId As Guid, StatsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.app_guid.ToString, AppId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, StatsConnectionString)
        End Function

        Public Shared Function ApplicationDelete(AppName As String, StatsConnectionString As String) As Boolean
            Return ApplicationDelete(Id(AppName, StatsConnectionString), StatsConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Application"

        ''' <summary>
        ''' Geat All Applications. Column(app_guid,app_name)
        ''' </summary>
        Public Shared Function GetAllApplications(StatsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.app_guid.ToString, _
                eFieldName.app_name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.app_name.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, StatsConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllApplications(PageIndex As Integer, PageSize As Integer, StatsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.app_guid.ToString, _
                eFieldName.app_name.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.app_name.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, StatsConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


