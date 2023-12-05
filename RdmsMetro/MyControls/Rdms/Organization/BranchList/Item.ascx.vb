Namespace MyControls.Rdms.Organization.BranchList

    Public Class Item
        Inherits System.Web.UI.UserControl

        Public Property BranchId As Integer
            Get
                Return gBranchId.Text
            End Get
            Set(value As Integer)
                gBranchId.Text = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim BranchName As String = NasLib.Database.MySql.Provider.Branches.GetBranchName(BranchId, ProvidersConnectionString)
            lblBranchName.Text = BranchName

            Dim SatelliteTable As DataTable = NasLib.Database.MySql.Provider.Satellites.GetSiblingsByParent(BranchId, ProvidersConnectionString)

            For i As Integer = 0 To SatelliteTable.Rows.Count - 1
                Dim SatelliteItem As MyControls.Rdms.Organization.SatelliteList.Item = LoadControl("~/MyControls/Rdms/Organization/SatelliteList/Item.ascx")
                SatelliteItem.SatelliteId = SatelliteTable(i)(0)
                PlaceHolder1.Controls.Add(SatelliteItem)
            Next

            SatelliteTable.Dispose()
        End Sub

    End Class

End Namespace