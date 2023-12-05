Namespace Database.SQLite.Provider
    Public Class Units

        Public Shared Function GetBranchId(UnitId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeUnit.BranchId(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentId(UnitId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeUnit.DepartmentId(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetDivisionId(UnitId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeUnit.DivisionId(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(UnitId As Guid, ProviderConnectionString As String) As String
            Dim BranchId As Guid = GetBranchId(UnitId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentName(UnitId As Guid, ProviderConnectionString As String) As String
            Dim DepartmentId As Guid = GetDepartmentId(UnitId, ProviderConnectionString)
            Return Table.OfficeDepartment.Department(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetDivisionName(UnitId As Guid, ProviderConnectionString As String) As String
            Dim DivisionId As Guid = GetDivisionId(UnitId, ProviderConnectionString)
            Return Table.OfficeDivision.Division(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetUnitName(UnitId As Guid, ProviderConnectionString As String) As String
            Return Table.OfficeUnit.Unit(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetGrandParentId(UnitId As Guid, ProviderConnectionString As String) As Guid
            Return GetDepartmentId(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(UnitId As Guid, ProviderConnectionString As String) As Guid
            Return GetDivisionId(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeUnit.CountSameParentByParentId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(UnitId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeUnit.CountSameParent(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblingsByParent(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeUnit.getSameParentByParentId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(UnitId As Guid, ProviderConnectionString As String) As DataTable
            Dim DivisionId As Guid = GetParentId(UnitId, ProviderConnectionString)
            Return Table.OfficeUnit.GetSameParent(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(UnitId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInUnit(UnitId, ProviderConnectionString)
        End Function


        Public Shared Function CountStaff(UnitId As Guid, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInUnit(UnitId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(UnitId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInUnit(UnitId, ProviderConnectionString)
        End Function

    End Class
End Namespace

