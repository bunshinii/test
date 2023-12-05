Namespace Database.MySql.Provider
    Public Class Departments

        Public Shared Function GetDepartmentId(DepartmentName As String, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.DepartmentId(DepartmentName, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchId(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.BranchId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(DepartmentId As Integer, ProviderConnectionString As String) As String
            Dim BranchId As Integer = GetBranchId(DepartmentId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentName(DepartmentId As Integer, ProviderConnectionString As String) As String
            Return Table.OfficeDepartment.Department(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return GetBranchId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParent(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeDepartment.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParent(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblingsByParent(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDepartment.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function CountChild(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeDivision.CountSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasChild(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Return HasDivision(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasDivision(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountChild(DepartmentId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function GetChilds(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDivision.GetSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInDepartment(DepartmentId, ProviderConnectionString)
        End Function


    End Class
End Namespace

