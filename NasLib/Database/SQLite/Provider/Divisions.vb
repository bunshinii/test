﻿Namespace Database.SQLite.Provider
    Public Class Divisions
        Public Shared Function GetBranchId(DivisionId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeDivision.BranchId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentId(DivisionId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeDivision.DepartmentId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(DivisionId As Guid, ProviderConnectionString As String) As String
            Dim BranchId As Guid = GetBranchId(DivisionId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentName(DivisionId As Guid, ProviderConnectionString As String) As String
            Dim DepartmentId As Guid = GetDepartmentId(DivisionId, ProviderConnectionString)
            Return Table.OfficeDepartment.Department(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetDivisionName(DivisionId As Guid, ProviderConnectionString As String) As String
            Return Table.OfficeDivision.Division(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetGrandParentId(DivisionId As Guid, ProviderConnectionString As String) As Guid
            Return GetBranchId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(DivisionId As Guid, ProviderConnectionString As String) As Guid
            Return GetDepartmentId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDivision.CountSameParent(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeDivision.CountSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDivision.GetSameParent(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblingsByParent(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeDivision.GetSameParentByParentId(DepartmentId, ProviderConnectionString)
        End Function

        Public Shared Function CountChild(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeUnit.CountSameParentByParentId(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function HasChild(DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Return HasUnit(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function HasUnit(DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountChild(DivisionId, ProviderConnectionString) > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function GetChilds(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeUnit.GetSameParentByParentId(DivisionId, ProviderConnectionString)
        End Function


        Public Shared Function HasStaff(DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInDivision(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInDivision(DivisionId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInDivision(DivisionId, ProviderConnectionString)
        End Function


    End Class
End Namespace

