Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Functions.Controls.DataTableTo

Public Class Department
    Inherits System.Web.UI.Page

#Region "DropDowns"

    Private Sub FillDdBranch()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
        ToDropDownList(MyTable, ddBranch, 0, 1, " -- Select Branch -- ")
        MyTable.Dispose()
    End Sub

#End Region

#Region "Load Data"

    Private Sub LoadData()
        Dim BranchId As Integer = MyRequest.GetBranchId
        ddBranch.SelectedValue = BranchId

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDdBranch()
            LoadData()
        End If

        DepartmentTable1.BranchId = ddBranch.SelectedValue

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        MyResponse.Redirect(MyRequest._BranchId, ddBranch.SelectedValue)
    End Sub
End Class