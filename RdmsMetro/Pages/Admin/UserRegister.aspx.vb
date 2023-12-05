Imports NasLib.Functions.Controls.DataTableTo
Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.CustomProvider.DBLibrary.Table
Imports NasLib.Database.MySql.Provider

Public Class UserRegister
    Inherits System.Web.UI.Page

#Region "Functions"

    Private Sub BackPathRedirect(Code_ As Integer)
        Dim MyVirtualPath = "~/Pages/Admin/UserSearch.aspx"
        MyResponse.Redirect(MyVirtualPath, MyRequest._Code, Code_)
    End Sub

#Region "DropDowns"

    Private Sub FillDropdowns()
        FillDdGender()
        FillDdMarriage()
        FillDdBranch()
        FillDdGrade()
    End Sub

    Private Sub FillDdGender()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersGender.GetAllGenders(ProvidersConnectionString)
        ToDropDownList(MyTable, ddGender, 0, 1, " -- Select Gender -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdMarriage()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersMarriage.GetAllMarriages(ProvidersConnectionString)
        ToDropDownList(MyTable, ddMarriage, 0, 1, " -- Select Marriage -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdGrade()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPositionGrade.GetAllGrade(ProvidersConnectionString)
        ToDropDownList(MyTable, ddGrade, 0, 1, " -- Select Grade -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdPosition()
        Dim GradeId As Integer = ddGrade.SelectedValue
        Dim GradeCode As String = Table.UsersPositionGrade.Grade(GradeId, ProvidersConnectionString)
        ddPosition.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPosition.GetPositionsByGrade(GradeCode, ProvidersConnectionString)
        ToDropDownList(MyTable, ddPosition, 0, 1, " -- Select Position -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdBranch()
        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
        ToDropDownList(MyTable, ddBranch, 0, 1, " -- Select Branch -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdSatellite()
        Dim BranchId As Integer = ddBranch.SelectedValue
        ddSatellite.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeSatellite.GetSatellitesByBranchId(BranchId, ProvidersConnectionString)
        ToDropDownList(MyTable, ddSatellite, 0, 2, " -- Select Satellite -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdDepartment()
        Dim BranchId As Integer = ddBranch.SelectedValue
        ddDepartment.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDepartment.GetDepartmentsByBranchId(BranchId, ProvidersConnectionString)
        ToDropDownList(MyTable, ddDepartment, 0, 2, " -- Select Department -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdDivision()
        Dim Department As Integer = ddDepartment.SelectedValue
        ddDivision.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDivision.GetDivisionsByDepartmentId(Department, ProvidersConnectionString)
        ToDropDownList(MyTable, ddDivision, 0, 2, " -- Select Division -- ")
        MyTable.Dispose()
    End Sub

    Private Sub FillDdUnit()
        Dim DivisionId As Integer = ddDivision.SelectedValue
        ddUnit.Items.Clear()

        Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeUnit.GetUnitsByDivisionId(DivisionId, ProvidersConnectionString)
        ToDropDownList(MyTable, ddUnit, 0, 2, " -- Select Unit -- ")
        MyTable.Dispose()
    End Sub

#End Region

#Region "Load Default Data"

    Private Sub CheckIsRegistered(PatronId)
        Dim IsExisted_ As Boolean = Table.Users.IsExisted(PatronId, ProvidersConnectionString)

        If IsExisted_ Then
            BackPathRedirect(1)
        End If

    End Sub

    Private Function IsExistedDblibrary(PatronId) As Boolean
        Return StaffActiv.IsExisted(PatronId, DbLibraryConnectionString)
    End Function

    Private Sub LoadStaffData(PatronId)
        'Redirect id already registered
        CheckIsRegistered(PatronId)

        'Load from DBLibrary
        If IsExistedDblibrary(PatronId) Then
            Image1.ImageUrl = PicProviderLink(PatronId)

            txtStaffId.Text = PatronId
            txtStaffId.Enabled = False

            txtFullname.Text = StaffActiv.Nama1(PatronId, DbLibraryConnectionString)
            txtEmail.Text = StaffActiv.Email(PatronId, DbLibraryConnectionString)
            txtPassport.Text = StaffActiv.NoIc(PatronId, DbLibraryConnectionString)
            txtPhone.Text = StaffActiv.Telefon(PatronId, DbLibraryConnectionString)

            'Try Filling Position and Grade dropdown by Patron Data.
            Dim PositionCode As String = StaffActiv.JawatanSekarang(PatronId, DbLibraryConnectionString)
            Dim GradeCode As String = Table.UsersPosition.Grade(PositionCode, ProvidersConnectionString)

            If GradeCode.Length > 0 Then
                Dim PositionId As Integer = Table.UsersPosition.PositionId(PositionCode, ProvidersConnectionString)

                Dim GradeId As Integer = Table.UsersPositionGrade.GradeId(GradeCode, ProvidersConnectionString)
                ddGrade.SelectedValue = GradeId
                FillDdPosition()
                ddPosition.SelectedValue = PositionId
            End If

        Else
            Image1.ImageUrl = PicProviderLink(0)

        End If


    End Sub

#End Region

    Private Sub RegisterUser()

        Dim PatronId As String = txtStaffId.Text
        CheckIsRegistered(PatronId)

        QuickFunctions.QuickRegistration.ProvidersConnectionString = ProvidersConnectionString
        QuickFunctions.QuickRegistration.RegisterBlankLibraryStaff(PatronId, txtPassport.Text)

        Table.UsersProfile.FullName(PatronId, ProvidersConnectionString) = txtFullname.Text
        Table.UsersProfile.Passport(PatronId, ProvidersConnectionString) = txtPassport.Text
        If IsNumeric(ddGender.SelectedValue) Then Table.UsersProfile.GenderId(PatronId, ProvidersConnectionString) = ddGender.SelectedValue
        If IsNumeric(ddMarriage.SelectedValue) Then Table.UsersProfile.MarriageId(PatronId, ProvidersConnectionString) = ddMarriage.SelectedValue
        Table.UsersProfile.Email(PatronId, ProvidersConnectionString) = txtEmail.Text
        Table.Membership.Email(PatronId, ProvidersConnectionString) = txtEmail.Text
        Table.UsersProfile.Phone(PatronId, ProvidersConnectionString) = txtPhone.Text
        Table.UsersProfile.Handphone(PatronId, ProvidersConnectionString) = txtHandPhone.Text

        If IsNumeric(ddGrade.SelectedValue) Then Table.UsersProfile.GradeId(PatronId, ProvidersConnectionString) = ddGrade.SelectedValue
        If IsNumeric(ddPosition.SelectedValue) Then Table.UsersProfile.PositionId(PatronId, ProvidersConnectionString) = ddPosition.SelectedValue

        If IsNumeric(ddBranch.SelectedValue) Then Table.UsersProfile.BranchId(PatronId, ProvidersConnectionString) = ddBranch.SelectedValue
        If IsNumeric(ddSatellite.SelectedValue) Then Table.UsersProfile.SatelliteId(PatronId, ProvidersConnectionString) = ddSatellite.SelectedValue
        If IsNumeric(ddDepartment.SelectedValue) Then Table.UsersProfile.DepartmentId(PatronId, ProvidersConnectionString) = ddDepartment.SelectedValue
        If IsNumeric(ddDivision.SelectedValue) Then Table.UsersProfile.DivisionId(PatronId, ProvidersConnectionString) = ddDivision.SelectedValue
        If IsNumeric(ddUnit.SelectedValue) Then Table.UsersProfile.UnitId(PatronId, ProvidersConnectionString) = ddUnit.SelectedValue

        BackPathRedirect(2)
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PatronId As String = MyRequest.GetPatronId

        If Not IsPostBack Then
            FillDropdowns()

            If PatronId.Length > 0 Then LoadStaffData(PatronId)
        End If

    End Sub

    Protected Sub ddBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBranch.SelectedIndexChanged
        FillDdSatellite()
        FillDdDepartment()
    End Sub

    Protected Sub ddDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDepartment.SelectedIndexChanged
        FillDdDivision()
    End Sub

    Protected Sub ddDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDivision.SelectedIndexChanged
        FillDdUnit()
    End Sub

    Protected Sub ddGrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddGrade.SelectedIndexChanged
        FillDdPosition()
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        RegisterUser()
    End Sub
End Class