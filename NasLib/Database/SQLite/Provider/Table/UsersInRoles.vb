Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_UsersInRoles'
    ''' </summary>
    Public Class UsersInRoles

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "aspnet_UsersInRoles"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            userId
            roleId
        End Enum

#End Region

#Region "Regular Functions"

#Region "IsUserExisted"

        Public Shared Function IsUserExisted(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = Table.Users.IsExisted(UserId, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = Table.Users.IsExisted(Username, ProviderConnectionString)
            Return MyBool
        End Function

#End Region

#Region "IsRoleExisted"

        Public Shared Function IsRoleExisted(RoleId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = Table.Roles.IsExisted(RoleId, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsRoleExisted(RoleName As String, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = Table.Roles.IsExisted(RoleName, ProviderConnectionString)
            Return MyBool
        End Function

#End Region

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function AssignUserRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.userId.ToString, _
                eFieldName.roleId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                RoleId)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserId As Guid, RoleName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.userId.ToString, _
                eFieldName.roleId.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
               UserId, _
                RoleId(RoleName, ProviderConnectionString) _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserName As String, RoleId As Guid, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.userId.ToString, _
                eFieldName.roleId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UserId(UserName, ProviderConnectionString), _
                RoleId)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserName As String, RoleName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.userId.ToString, _
                eFieldName.roleId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UserId(UserName, ProviderConnectionString), _
                RoleId(RoleName, ProviderConnectionString) _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ClearUserRoles(UserId As Guid, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId.ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId.ToString), _
                Criteria(eFieldName.roleId.ToString, RoleId.ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserId As Guid, RoleName As String, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId.ToString), _
                Criteria(eFieldName.roleId.ToString, RoleId(RoleName, ProviderConnectionString).ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserName As String, RoleId As Guid, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId(UserName, ProviderConnectionString).ToString), _
                Criteria(eFieldName.roleId.ToString, RoleId.ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserName As String, RoleName As String, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId(UserName, ProviderConnectionString).ToString), _
                Criteria(eFieldName.roleId.ToString, RoleId(RoleName, ProviderConnectionString).ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Sub RoleDelete(RoleId As Guid, ProviderConnectionString As String)
            Dim _Criteria As String = Criteria(eFieldName.roleId.ToString, RoleId)
            MyCmd.CmdDelete(TableName, _Criteria, ProviderConnectionString)
        End Sub

#End Region

#End Region

#Region "Joined Functions"

        ''' <summary>
        ''' Get UserId by Username
        ''' </summary>
        Private Shared Function UserId(Username As String, ProviderConnectionString As String) As Guid
            Return Table.Users.Id(Username, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get RoleId by RoleName
        ''' </summary>
        Private Shared Function RoleId(RoleName As String, ProviderConnectionString As String) As Guid
            Return Table.Roles.Id(RoleName, ProviderConnectionString)
        End Function

#End Region

#Region "Extra Functions"

#Region "Checkers"

        Public Shared Function IsUserInRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId), _
                Criteria(eFieldName.roleId.ToString, RoleId) _
                )

            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsRoleInUser(UserId As Guid, RoleId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId), _
                Criteria(eFieldName.roleId.ToString, RoleId) _
                )

            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Users in a role"

        ''' <summary>
        ''' Get UserId List by RoleId
        ''' </summary>
        Public Shared Function UsersInRole(RoleId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = eFieldName.userId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.roleId.ToString, RoleId)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, , ProviderConnectionString)
        End Function

        Public Shared Function UsersInRole(RoleName As String, ProviderConnectionString As String) As DataTable
            Return UsersInRole(RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count Users in a role
        ''' </summary>
        Public Shared Function UsersInRoleCount(RoleId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.roleId.ToString, RoleId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UsersInRoleCount(RoleName As String, ProviderConnectionString As String) As Integer
            Return UsersInRoleCount(RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#Region "Roles in a user"

        ''' <summary>
        ''' Get RoleId List by UserId
        ''' </summary>
        Public Shared Function RolesInUser(UserId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = eFieldName.roleId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.userId.ToString, UserId)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, , ProviderConnectionString)
        End Function

        Public Shared Function RolesInUser(UserName As String, ProviderConnectionString As String) As DataTable
            Return RolesInUser(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count Roles in a user
        ''' </summary>
        Public Shared Function RolesInUserCount(UserId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.userId.ToString, UserId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function RolesInUserCount(UserName As String, ProviderConnectionString As String) As Integer
            Return UsersInRoleCount(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


