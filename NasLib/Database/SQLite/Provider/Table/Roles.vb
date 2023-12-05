Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_Roles'
    ''' </summary>
    Public Class Roles

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "aspnet_Roles"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            RoleId
            RoleName
            LoweredRoleName
            ApplicationId
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "RoleId"

        ''' <summary>
        ''' Get RoleId by Role Name
        ''' </summary>
        Public Shared Function Id(RoleName As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = eFieldName.RoleId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.LoweredRoleName.ToString, RoleName.ToLower)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "RoleName"

        Public Shared Property RoleName(ByVal RoleId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.RoleName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.RoleName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property RoleName(ByVal TheRoleName As String, ProviderConnectionString As String) As String
            Get
                Return RoleName(Id(TheRoleName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                RoleName(Id(TheRoleName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LoweredRoleName"

        Public Shared Property LoweredRoleName(ByVal RoleId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.LoweredRoleName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.LoweredRoleName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LoweredRoleName(ByVal TheRoleName As String, ProviderConnectionString As String) As String
            Get
                Return LoweredRoleName(Id(TheRoleName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                LoweredRoleName(Id(TheRoleName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "ApplicationId"

        Public Shared Property ApplicationID(ByVal RoleId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = eFieldName.ApplicationId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = eFieldName.ApplicationId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationID(ByVal RoleName As String, ProviderConnectionString As String) As Guid
            Get
                Return ApplicationID(Id(RoleName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                ApplicationID(Id(RoleName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region


#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(RoleId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(RoleName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.LoweredRoleName.ToString, RoleName.ToLower)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function RoleAdd(RoleName As String, ApplicationId As Guid, ProviderConnectionString As String) As Guid
            Dim RoleId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.RoleId.ToString, _
                eFieldName.RoleName.ToString, _
                eFieldName.LoweredRoleName.ToString, _
                eFieldName.ApplicationId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                RoleId, _
                RoleName, _
                RoleName.ToLower, _
                ApplicationId.ToString)

            Return New Guid(MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString))
        End Function

#End Region

#Region "Delete"

        Public Shared Function RoleDelete(RoleId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.RoleId.ToString, RoleId.ToString)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function RoleDelete(RoleName As String, ProviderConnectionString As String) As Boolean
            Return RoleDelete(Id(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        Public Shared Function GetAllRoles(ProviderConnectionString As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.RoleId.ToString, _
                eFieldName.RoleName.ToString)

            Dim Other As String = OrderBy(eFieldName.LoweredRoleName)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


