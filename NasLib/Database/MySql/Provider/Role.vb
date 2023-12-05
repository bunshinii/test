Imports NasLib.Database.MySql.Provider.Table

Namespace Database.MySql.Provider

    Public Class Role

#Region "Private Functions"

        Private Shared Function Username(UserId As Integer, ProviderConnectionString As String) As String
            Return NasLib.Database.MySql.Provider.Table.Users.Username(UserId, ProviderConnectionString)
        End Function

#End Region

#Region "Public Functions"

        ''' <summary>
        ''' Add New Role. Will return RoleId
        ''' </summary>
        ''' <returns>RoleId</returns>
        Public Shared Function CreateRole(RoleName As String, ProviderConnectionString As String) As Integer
            Return Roles.RoleAdd(RoleName, ProviderConnectionString)
        End Function

        Public Shared Sub AddUserToRole(UserId As Integer, RoleId As Integer, ProviderConnectionString As String)
            UsersInRoles.AssignUserRole(UserId, RoleId, ProviderConnectionString)
        End Sub

        Public Shared Sub AddUserToRole(Username As String, RoleId As Integer, ProviderConnectionString As String)
            UsersInRoles.AssignUserRole(Username, RoleId, ProviderConnectionString)
        End Sub

        Public Shared Sub AddUserToRole(UserId As Integer, RoleName As String, ProviderConnectionString As String)
            UsersInRoles.AssignUserRole(UserId, RoleName, ProviderConnectionString)
        End Sub

        Public Shared Sub AddUserToRole(Username As String, RoleName As String, ProviderConnectionString As String)
            UsersInRoles.AssignUserRole(Username, RoleName, ProviderConnectionString)
        End Sub

        Public Shared Sub RemoveUserFromRole(UserId As String, RoleId As String, ProviderConnectionString As String)
            UsersInRoles.UnAssignUserRole(UserId, RoleId, ProviderConnectionString)
        End Sub

        Public Shared Sub DeleteRole(RoleId As Integer, ProviderConnectionString As String)
            Roles.RoleDelete(RoleId, ProviderConnectionString)
            UsersInRoles.RoleDelete(RoleId, ProviderConnectionString)
        End Sub

        ''' <summary>
        ''' Get UserId List by RoleId
        ''' </summary>
        Public Shared Function FindUsersInRole(RoleId As Integer, ProviderConnectionString As String) As DataTable
            Return UsersInRoles.UsersInRole(RoleId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get all roles. Fields: 'id, name'
        ''' </summary>
        Public Shared Function GetAllRoles(ProviderConnectionString As String) As DataTable
            Return Roles.GetAllRoles(ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get RoleId list for a User
        ''' </summary>
        Public Shared Function GetRolesForUser(UserId As Integer, ProviderConnectionString As String) As DataTable
            Return UsersInRoles.RolesInUser(UserId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get UserId list for a Role
        ''' </summary>
        Public Shared Function GetUsersInRole(RoleId As Integer, ProviderConnectionString As String) As DataTable
            Return UsersInRoles.UsersInRole(RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(UserId As Integer, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return UsersInRoles.IsUserInRole(UserId, RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(UserId As Integer, RoleName As String, ProviderConnectionString As String) As Boolean
            Return UsersInRoles.IsUserInRole(UserId, RoleName, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(Username As String, RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return UsersInRoles.IsUserInRole(Username, RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(Username As String, RoleName As String, ProviderConnectionString As String) As Boolean
            Return UsersInRoles.IsUserInRole(Username, RoleName, ProviderConnectionString)
        End Function

        Public Shared Function RoleExists(RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return Roles.IsExisted(RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsRoleExists(RoleId As Integer, ProviderConnectionString As String) As Boolean
            Return RoleExists(RoleId, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


