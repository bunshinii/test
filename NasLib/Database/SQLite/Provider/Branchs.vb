Namespace Database.SQLite.Provider
    Public Class Branchs

        Public Shared Function GetBranchName(BranchId As Guid, ProviderConnectionString As String) As String
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountBranch(ProviderConnectionString As String) As Integer
            Return Table.OfficeBranch.Count(ProviderConnectionString)
        End Function

        Public Shared Function GetBranchs(ProviderConnectionString As String) As DataTable
            Return Table.OfficeBranch.GetAllBranchs(ProviderConnectionString)
        End Function

        Public Shared Function CountChild(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountSatellite(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountDepartment(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return CountChild(BranchId, ProviderConnectionString)
        End Function


        Public Shared Function HasChild(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Return HasDepartment(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasDepartment(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountDepartment(BranchId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function HasSatellite(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountSatellite(BranchId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function GetChilds(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartments(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return GetChilds(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSatellites(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInBranch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInBranch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInBranch(BranchId, ProviderConnectionString)
        End Function

    End Class
End Namespace

