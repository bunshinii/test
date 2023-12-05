Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_users'
    ''' </summary>
    Public Class Users

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_aspnet_users"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            id                  'Primary
            applicationId
            name                'Index, Unique
            isAnonymous
            lastActivityDate    'Index

            ''  Multiple field
            '   id, lastActivityDate
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

#Region "Table Fields Properties"

#Region "id"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

        Public Shared Function Id(Username As String, ProviderConnectionString As String) As Integer
            Return UserId(Username, ProviderConnectionString)
        End Function

#End Region

#Region "Name"

        Public Shared Property Username(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "ApplicationID"

        Public Shared Property ApplicationID(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationID(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "IsAnonymous"

        Public Shared Property IsAnonymous(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsAnonymous(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "lastActivityDate"

        Public Shared Property lastActivityDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property lastActivityDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, UserId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.name.ToString, Username)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Filtered Count
        ''' </summary>
        ''' <param name="Keyword">Search Keyword</param>
        Public Shared Function Count(Keyword As String, ProviderConnectionString As String) As Integer
            Dim MyCriterias As String = CriteriaLike(eFieldName.name.ToString, String.Format("%{0}%", Keyword))

            Return MyCmd.CmdCount(TableName, MyCriterias, ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New User. Will return User ID
        ''' </summary>
        Public Shared Function UserInsert(ApplicationId As Integer, Username As String, IsAnonymous As Boolean, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = _
                FieldName(eFieldName.applicationId) & "," & _
                FieldName(eFieldName.name) & "," & _
                FieldName(eFieldName.isAnonymous) & "," & _
                FieldName(eFieldName.lastActivityDate)

            Dim MyFieldsValue As String = FieldValues( _
                ApplicationId, _
                Username, _
                IsAnonymous, _
                Now _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Add New User. Will return User ID
        ''' </summary>
        Public Shared Function UserInsert(Username As String, ProviderConnectionString As String) As Integer
            Dim ApplicationId As Integer = 1
            Dim IsAnonymous As Boolean = False

            Return UserInsert(ApplicationId, Username, IsAnonymous, ProviderConnectionString)
        End Function



#End Region

#Region "Delete"

        Public Shared Function UserDelete(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UserDelete(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Users. Column(id,name)
        ''' </summary>
        Public Shared Function GetAllUsers(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging and filter. Column(id,name)
        ''' </summary>
        ''' <param name="Keyword">Search Keyword</param>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(Keyword As String, PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim MyCriterias As String = CriteriaLike(eFieldName.name.ToString, String.Format("%{0}%", Keyword))

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriterias, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Get All Users Online"

        ''' <summary>
        ''' Geat All OnlineUsers. Column(id,name)
        ''' </summary>
        Public Shared Function GetAllUsersOnline(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime)

            Dim Other As String = OrderBy(eFieldName.name.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, _Criteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Online Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsersOnline(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, RowCount, StartRowIndex)

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, _Criteria, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Users Online"


        Private Shared ReadOnly Property UserOnlineSpan As TimeSpan
            Get
                Return MySql.GlobalVar.UserOnlineSpan
            End Get
        End Property

        Public Shared Function IsUserOnline(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime))

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, _Criteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsUserOnline(Username As String, ProviderConnectionString As String) As Boolean
            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime))

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, _Criteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Geat All Online Users. Column(id,name)
        ''' </summary>
        Public Shared Function UsersOnline(ProviderConnectionString) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, _Criteria, OrderBy(eFieldName.name.ToString), ProviderConnectionString)
        End Function

        Public Shared Function UsersOnlineCount(ProviderConnectionString) As Integer
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.lastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdCount(TableName, _Criteria, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


