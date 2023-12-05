Namespace Database.SQLite.Provider
    Public Class Satellites

        Public Shared Function GetBranchId(SatelliteId As Guid, ProviderConnectionString As String) As Guid
            Return Table.OfficeSatellite.BranchId(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(SatelliteId As Guid, ProviderConnectionString As String) As String
            Dim BranchId As Guid = GetBranchId(SatelliteId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSatelliteName(SatelliteId As Guid, ProviderConnectionString As String) As String
            Return Table.OfficeSatellite.Satellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(SatelliteId As Guid, ProviderConnectionString As String) As Guid
            Return GetBranchId(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(SatelliteId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParent(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(BranchId As Guid, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(SatelliteId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParent(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblingsByParent(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(SatelliteId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(SatelliteId As Guid, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(SatelliteId As Guid, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

    End Class
End Namespace

