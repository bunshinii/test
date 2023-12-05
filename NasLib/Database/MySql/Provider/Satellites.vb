Namespace Database.MySql.Provider
    Public Class Satellites

        Public Shared Function GetBranchId(SatelliteId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.BranchId(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetBranchName(SatelliteId As Integer, ProviderConnectionString As String) As String
            Dim BranchId As Integer = GetBranchId(SatelliteId, ProviderConnectionString)
            Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSatelliteName(SatelliteId As Integer, ProviderConnectionString As String) As String
            Return Table.OfficeSatellite.Satellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetParentId(SatelliteId As Integer, ProviderConnectionString As String) As Integer
            Return GetBranchId(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblings(SatelliteId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParent(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountSiblingsByParent(BranchId As Integer, ProviderConnectionString As String) As Integer
            Return Table.OfficeSatellite.CountSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function GetSiblings(SatelliteId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParent(SatelliteId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' 3 columns (id, initial, satellite)
        ''' </summary>
        Public Shared Function GetSiblingsByParent(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.OfficeSatellite.GetSameParentByParentId(BranchId, ProviderConnectionString)
        End Function

        Public Shared Function HasStaff(SatelliteId As Integer, ProviderConnectionString As String) As Boolean
            Return Table.UsersProfile.HasUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function CountStaff(SatelliteId As Integer, ProviderConnectionString As String) As Integer
            Return Table.UsersProfile.CountUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

        Public Shared Function GetStaff(SatelliteId As Integer, ProviderConnectionString As String) As DataTable
            Return Table.UsersProfile.GetUsersInSatellite(SatelliteId, ProviderConnectionString)
        End Function

    End Class
End Namespace

