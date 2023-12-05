Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_roles'
    ''' </summary>
    Public Class Roles

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_aspnet_roles"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            applicationId   'Index
            name            'Index
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(RoleName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), RoleName)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "applicationId"

        Public Shared Property ApplicationID(ByVal RoleId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationID(ByVal RoleName As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), RoleName)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), RoleName)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "name"

        Public Shared Property RoleName(ByVal RoleId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property RoleName(ByVal TheRoleName As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), TheRoleName)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), TheRoleName)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RoleId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(RoleName As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(Id(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function RoleAdd(RoleName As String, ProviderConnectionString As String) As Integer
            Dim ApplicationId As Integer = 1
            Return RoleAdd(RoleName, ApplicationId, ProviderConnectionString)
        End Function

        Public Shared Function RoleAdd(RoleName As String, ApplicationId As Integer, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.name.ToString, _
                eFieldName.applicationId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                RoleName, _
                ApplicationId)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function RoleDelete(RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), RoleId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function RoleDelete(RoleName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), RoleName)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "DataTables"

        Public Shared Function GetAllRoles(ProviderConnectionString As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString)

            Dim Other As String = OrderBy(eFieldName.name)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get Non Admin Roles.
        ''' The query just filterd out words 'admin, moderator, super
        ''' </summary>
        Public Shared Function GetAllNormalRoles(ProviderConnectionString As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaNotLike(eFieldName.name.ToString, "%admin%"), _
                CriteriaNotLike(eFieldName.name.ToString, "%moderator%"), _
                CriteriaNotLike(eFieldName.name.ToString, "%super%") _
                )

            Dim Other As String = OrderBy(eFieldName.name)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


