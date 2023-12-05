Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.Organization.BranchList

    Public Class Container
        Inherits System.Web.UI.UserControl

        Private Sub LoadBranches()
            Dim BranchTable As DataTable = Branches.GetBranches(ProvidersConnectionString)

            For i As Integer = 0 To BranchTable.Rows.Count - 1
                Dim BranchItem As MyControls.Rdms.Organization.BranchList.Item = LoadControl("~/MyControls/Rdms/Organization/BranchList/Item.ascx")
                BranchItem.BranchId = BranchTable(i)(0)
                PlaceHolder1.Controls.Add(BranchItem)
            Next

            BranchTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadBranches()
        End Sub

    End Class

End Namespace

