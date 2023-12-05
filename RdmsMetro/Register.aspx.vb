Imports NasLib.Functions.Controls.DataTableTo
Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.CustomProvider.DBLibrary.Table
Imports NasLib.Database.MySql.Provider

Public Class Register
    Inherits System.Web.UI.Page

#Region "Timer Message"
    'INSTRUCTION :
    '1. COPY this whole "Timer Message" region.
    '2. Put a [Timer1 Control (interval=5000, Enabled=false)] and a [lblMessage with AlwaysVisibleControlExtender] inside an [UpdatePanel]. (copy in Template Region)
    '4. Create your own code message in the DisplayMessage(). do NOT put Case 0
    '5. Redirect to this page with "code=n" query string.

    Private Sub DisplayMessage(MessageCode As Integer)
        Timer1.Enabled = True
        Dim ForegroundColor As System.Drawing.Color = Drawing.Color.White
        Dim BackgroundColor As System.Drawing.Color = Nothing

        '#############################################################################
        'Create your own code message here. do NOT put Case 0
        Select Case MessageCode
            Case 1
                lblMessage.Text = String.Format("Staff ID and Patron IC / Passport is not matched")
                BackgroundColor = Drawing.Color.Red
            Case 2
                lblMessage.Text = String.Format("Nothing Happened")
                BackgroundColor = Drawing.Color.Green
            Case 3
                lblMessage.Text = String.Format("Staff ID already registered")
                BackgroundColor = Drawing.Color.Red
            Case 4
                lblMessage.Text = String.Format("Staff registered successfull")
                BackgroundColor = Drawing.Color.Green

        End Select
        '#############################################################################

        lblMessage.Visible = True
        lblMessage.ForeColor = Drawing.Color.White
        lblMessage.BackColor = BackgroundColor
    End Sub

#Region "Functions"

    Private Sub LoadMessage() Handles Me.Load
        Dim MessageCode As Integer = MyModules.Functions.QueryString.MyRequest.GetCode
        DisplayMessage(MessageCode)
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        lblMessage.Visible = Not lblMessage.Visible
    End Sub

#End Region

#Region "Template"

    '<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    '    <ContentTemplate>
    '        <asp:Label ID="lblMessage" runat="server" />
    '        <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
    '        <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
    '    </ContentTemplate>
    '</asp:UpdatePanel>

#End Region

#End Region

#Region "Functions"

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
            Dim MyKey() As String = {MyRequest._Code, MyRequest._PatronId}
            Dim MyValue() As String = {3, txtStaffId.Text}
            MyResponse.Redirect(MyKey, MyValue)
        End If

    End Sub

    Private Function IsExistedDblibrary(PatronId) As Boolean
        Return StaffActiv.IsExisted(PatronId, DbLibraryConnectionString)
    End Function

    Private Sub LoadStaffData(PatronId As String)
        'Redirect id already registered
        CheckIsRegistered(PatronId)

        'Load from DBLibrary
        If IsExistedDblibrary(PatronId) Then
            Image1.ImageUrl = PicProviderLink(PatronId)

            txtFullname.Text = StaffActiv.Nama1(PatronId, DbLibraryConnectionString)
            txtEmail.Text = StaffActiv.Email(PatronId, DbLibraryConnectionString)
            'txtPassport.Text = StaffActiv.NoIc(PatronId, DbLibraryConnectionString)
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

        Dim MyKey() As String = {MyRequest._Code, MyRequest._PatronId}
        Dim MyValue() As String = {4, ""}
        MyResponse.Redirect(MyKey, MyValue)
    End Sub

#End Region


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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            FillDropdowns()

            txtStaffId.Text = MyRequest.GetPatronId
        End If

    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim IsMatched As Boolean = NasLib.Database.MySql.CustomProvider.DBLibrary.Table.StaffActiv.IsMatchCredential(txtStaffId.Text, txtPassport.Text, DbLibraryConnectionString)

        If IsMatched Then
            LoadStaffData(txtStaffId.Text)
            'Panel1.Visible = False
            Panel2.Visible = True
        Else
            Dim MyKey() As String = {MyRequest._Code, MyRequest._PatronId}
            Dim MyValue() As String = {1, txtStaffId.Text}
            MyResponse.Redirect(MyKey, MyValue)
        End If

    End Sub
End Class