Public Class SatelliteEdit
    Inherits System.Web.UI.Page

    Public ReadOnly Property SatelliteId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.SatelliteId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SatId As Integer = SatelliteId
        SatelliteEditor1.SatteliteId = SatId
    End Sub

End Class