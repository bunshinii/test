Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Functions.Controls.DataTableTo

Public Class Division
    Inherits System.Web.UI.Page

#Region "DropDowns"

    Private Sub FillDdBranch()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
        ToDropDownList(MyTable, ddBranch, 0, 1, " -- Select Branch -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdDepartment()
        Dim BranchId As Integer = ddBranch.SelectedValue
        ddDepartment.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDepartment.GetDepartmentsByBranchId(BranchId, ProvidersConnectionString)
        ToDropDownList(MyTable, ddDepartment, 0, 2, " -- Select Department -- ")
        MyTable.Dispose()
    End Sub

    'Private Sub FillDdDivision()
    '    Dim Department As Integer = ddDepartment.SelectedValue
    '    ddDivision.Items.Clear()

    '    Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDivision.GetDivisionsByDepartmentId(Department, ProvidersConnectionString)
    '    ToDropDownList(MyTable, ddDivision, 0, 2, " -- Select Division -- ")
    '    MyTable.Dispose()
    'End Sub

    'Private Sub FillDdUnit()
    '    Dim DivisionId As Integer = ddDivision.SelectedValue
    '    ddUnit.Items.Clear()

    '    Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeUnit.GetUnitsByDivisionId(DivisionId, ProvidersConnectionString)
    '    ToDropDownList(MyTable, ddUnit, 0, 2, " -- Select Unit -- ")
    '    MyTable.Dispose()
    'End Sub

#End Region

#Region "Load Data"

    Private Sub LoadData()
        Dim BranchId As Integer = MyRequest.GetBranchId
        ddBranch.SelectedValue = BranchId

        FillDdDepartment()
        ddDepartment.SelectedValue = MyRequest.GetDepartmentId

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillDdBranch()

            LoadData()
        End If

        DivisionTable1.BranchId = ddBranch.SelectedValue
        DivisionTable1.DepartmentId = ddDepartment.SelectedValue
    End Sub

    Private Sub ddBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBranch.SelectedIndexChanged
        FillDdDepartment()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim MyKeys() As String = {MyRequest._BranchId, MyRequest._DepartmentId}
        Dim MyValues() As String = {ddBranch.SelectedValue, ddDepartment.SelectedValue}
        MyResponse.Redirect(MyKeys, MyValues)
    End Sub
End Class