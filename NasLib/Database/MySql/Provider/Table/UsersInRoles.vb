Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_usersinroles'
    ''' </summary>
    Public Class UsersInRoles

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_aspnet_usersinroles"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            userId
            roleId
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

#Region "Regular Functions"

#Region "IsUserExisted"

        Public Shared Function IsUserExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = NasLib.Database.MySql.Provider.Table.Users.IsExisted(UserId, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return IsUserExisted(UserId(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#Region "IsRoleExisted"

        Public Shared Function IsRoleExisted(RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyBool As Boolean = NasLib.Database.MySql.Provider.Table.Roles.IsExisted(RoleId, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsRoleExisted(RoleName As String, ProviderConnectionString As String) As Boolean
            Return IsRoleExisted(RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Assign a user in a role. Auto exit if the user is already in the role.
        ''' </summary>
        Public Shared Function AssignUserRole(UserId As Integer, RoleId As Integer, ProviderConnectionString As String) As Boolean
            If IsUserInRole(UserId, RoleId, ProviderConnectionString) Then
                'Exit and return false if user is already assigned in the role
                AssignUserRole = False
                Exit Function
            End If

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.userId.ToString, _
                eFieldName.roleId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                RoleId)

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserId As Integer, RoleName As String, ProviderConnectionString As String) As Boolean
            Return AssignUserRole(UserId, RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserName As String, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return AssignUserRole(UserId(UserName, ProviderConnectionString), RoleId, ProviderConnectionString)
        End Function

        Public Shared Function AssignUserRole(UserName As String, RoleName As String, ProviderConnectionString As String) As Boolean
            Return AssignUserRole(UserId(UserName, ProviderConnectionString), RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ClearUserRoles(UserId As Integer, ProviderConnectionString As String) As Boolean

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId.ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserId As Integer, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyFieldsName As String = _
                FieldName(eFieldName.userId) & "," & _
                FieldName(eFieldName.roleId)

            Dim MyCriteria As String = _
                Criteria(FieldName(eFieldName.userId), UserId) & " AND " & _
                Criteria(FieldName(eFieldName.roleId), RoleId)

            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserId As Integer, RoleName As String, ProviderConnectionString As String) As Boolean
            Return UnAssignUserRole(UserId, RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserName As String, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return UnAssignUserRole(UserId(UserName, ProviderConnectionString), RoleId, ProviderConnectionString)
        End Function

        Public Shared Function UnAssignUserRole(UserName As String, RoleName As String, ProviderConnectionString As String) As Boolean
            Return UnAssignUserRole(UserId(UserName, ProviderConnectionString), RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Sub DeleteAllRolesInUser(UserId As Integer, ProviderConnectionString As String)
            Dim _Criteria As String = Criteria(eFieldName.userId.ToString, UserId)
            MyCmd.CmdDelete(TableName, _Criteria, ProviderConnectionString)
        End Sub

        Public Shared Sub DeleteAllRolesInUser(Username As String, ProviderConnectionString As String)
            DeleteAllRolesInUser(UserId(Username, ProviderConnectionString), ProviderConnectionString)
        End Sub

        Public Shared Sub RoleDelete(RoleId As Integer, ProviderConnectionString As String)
            Dim _Criteria As String = Criteria(eFieldName.roleId.ToString, RoleId)
            MyCmd.CmdDelete(TableName, _Criteria, ProviderConnectionString)
        End Sub

#End Region

#End Region

#Region "Joined Functions"

        ''' <summary>
        ''' Get UserId by Username
        ''' </summary>
        Private Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.Users.Id(Username, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get RoleId by RoleName
        ''' </summary>
        Private Shared Function RoleId(RoleName As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.Roles.Id(RoleName, ProviderConnectionString)
        End Function

#End Region

#Region "Extra Functions"

#Region "Checkers"

        Public Shared Function IsUserInRole(UserId As Integer, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId) & " AND " & Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(UserId As Integer, RoleName As String, ProviderConnectionString As String) As Boolean
            Dim RoleId As Integer = Table.Roles.Id(RoleName, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId) & " AND " & Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(Username As String, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim UserId As Integer = Table.Users.Id(Username, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId) & " AND " & Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(Username As String, RoleName As String, ProviderConnectionString As String) As Boolean
            Dim UserId As Integer = Table.Users.Id(Username, ProviderConnectionString)
            Dim RoleId As Integer = Table.Roles.Id(RoleName, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId) & " AND " & Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsRoleInUser(UserId As Integer, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId) & " AND " & Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Users in a role"

        ''' <summary>
        ''' Get UserId List by RoleId
        ''' </summary>
        Public Shared Function UsersInRole(RoleId As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldName(eFieldName.userId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.roleId), RoleId)
            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, , ProviderConnectionString)
        End Function

        Public Shared Function UsersInRole(RoleName As String, ProviderConnectionString As String) As DataTable
            Return UsersInRole(RoleId(RoleName, ProviderConnectionString), ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count Users in a role
        ''' </summary>
        Public Shared Function UsersInRoleCount(RoleId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.roleId), RoleId)
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
        Public Shared Function RolesInUser(UserId As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldName(eFieldName.roleId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, , ProviderConnectionString)
        End Function

        Public Shared Function RolesInUser(UserName As String, ProviderConnectionString As String) As DataTable
            Return RolesInUser(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count Roles in a user
        ''' </summary>
        Public Shared Function RolesInUserCount(UserId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function RolesInUserCount(UserName As String, ProviderConnectionString As String) As Integer
            Return UsersInRoleCount(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


