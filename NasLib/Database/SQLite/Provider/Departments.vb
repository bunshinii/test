Namespace Database.SQLite.Provider
    Public Class Departments

        Public Shared Function GetBranchId(DepartmentId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeDepartment.BranchId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(DepartmentId As Guid, ProviderConnectionString As String) As String
            Dim BranchId As Guid = GetBranchId(DepartmentId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentName(DepartmentId As Guid, ProviderConnectionString As String) As String
            Return Table.OfficeDepartment.Department(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(DepartmentId As Guid, ProviderConnectionString As String) As Guid
            Return GetBranchId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParent(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParent(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblingsByParent(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountChild(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDivision.CountSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasChild(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Return HasDivision(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasDivision(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountChild(DepartmentId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function GetChilds(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDivision.GetSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function


    End Class
End Namespace

