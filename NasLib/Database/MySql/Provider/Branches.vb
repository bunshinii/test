Namespace Database.MySql.Provider
    Public Class Branches

        Public Shared Function GetBranchName(BranchId As Integer, ProviderConnectionString As String) As String
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountBranch(ProviderConnectionString As String) As Integer
            Return Table.OfficeBranch.Count(ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Branch. Column(2): (id, branch)
        ''' </summary>
        Public Shared Function GetBranches(ProviderConnectionString As String) As DataTable
            Return Table.OfficeBranch.GetAllBranches(ProviderConnectionString)
        End Function

        Public Shared Function CountChild(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountSatellite(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountDepartment(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return CountChild(BranchId, ProviderConnectionString)
        End Function


        Public Shared Function HasChild(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Return HasDepartment(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasDepartment(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountDepartment(BranchId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function HasSatellite(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountSatellite(BranchId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function GetChilds(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartments(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return GetChilds(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSatellites(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInBranch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInBranch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInBranch(BranchId, ProviderConnectionString)
        End Function

    End Class
End Namespace

