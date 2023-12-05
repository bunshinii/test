Imports NasLib.Database.SQLite.Provider

Namespace Database.SQLite.Provider

    Public Class Role

#Region "Private Functions"

        Private Shared Function Username(UserId As Guid, ProviderConnectionString As String) As String
            Return Table.Users.Username(UserId, ProviderConnectionString)
        End Function

#End Region

#Region "Public Functions"

        ''' <summary>
        ''' Add New Role. Will return RoleId
        ''' </summary>
        ''' <returns>RoleId</returns>
        Public Shared Function CreateRole(RoleName As String, ApplicationId As Guid, ProviderConnectionString As String) As Guid
            Return Table.Roles.RoleAdd(RoleName, ApplicationId, ProviderConnectionString)
        End Function

        Public Shared Sub AddUserToRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String)
            Table.UsersInRoles.AssignUserRole(UserId, RoleId, ProviderConnectionString)
        End Sub

        Public Shared Sub RemoveUserFromRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String)
            Table.UsersInRoles.UnAssignUserRole(UserId, RoleId, ProviderConnectionString)
        End Sub

        Public Shared Sub DeleteRole(RoleId As Guid, ProviderConnectionString As String)
            Table.Roles.RoleDelete(RoleId, ProviderConnectionString)
            Table.UsersInRoles.RoleDelete(RoleId, ProviderConnectionString)
        End Sub

        ''' <summary>
        ''' Get UserId List by RoleId
        ''' </summary>
        Public Shared Function FindUsersInRole(RoleId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersInRoles.UsersInRole(RoleId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get all roles. Fields: 'id, name'
        ''' </summary>
        Public Shared Function GetAllRoles(ProviderConnectionString As String) As DataTable
            Return Table.Roles.GetAllRoles(ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get RoleId list for a User
        ''' </summary>
        Public Shared Function GetRolesForUser(UserId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersInRoles.RolesInUser(UserId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get UserId list for a Role
        ''' </summary>
        Public Shared Function GetUsersInRole(RoleId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersInRoles.UsersInRole(RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserInRole(UserId As Guid, RoleId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersInRoles.IsUserInRole(UserId, RoleId, ProviderConnectionString)
        End Function

        Public Shared Function RoleExists(RoleId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.Roles.IsExisted(RoleId, ProviderConnectionString)
        End Function

        Public Shared Function IsRoleExists(RoleId As Guid, ProviderConnectionString As String) As Boolean
            Return RoleExists(RoleId, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


