Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.Organization.SatelliteList

    Public Class Item
        Inherits System.Web.UI.UserControl

        Public Property SatelliteId As Integer
            Get
                Return gSatelliteId.Text
            End Get
            Set(value As Integer)
                gSatelliteId.Text = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim SatelliteId_ As Integer = SatelliteId
            lblSatelliteName.Text = Satellites.GetSatelliteName(SatelliteId_, ProvidersConnectionString)

            Dim Initial As String = Table.OfficeSatellite.Initial(SatelliteId_, ProvidersConnectionString)
            hlSatellite.NavigateUrl = "~/?sat=" & Initial
        End Sub

    End Class

End Namespace

