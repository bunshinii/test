Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Provider

Public Class OnDate
    Inherits System.Web.UI.Page

#Region "Public Properties"

    Public ReadOnly Property SatelliteInitial As String
        Get
            Return MyRequest.GetSatInit
        End Get
    End Property

    Public ReadOnly Property TheDate As String
        Get
            Dim theDate_ As String = MyRequest.GetDate

            Return theDate_
        End Get
    End Property

    Private Sub RedirectUnproper()
        If Not User.Identity.IsAuthenticated And SatelliteInitial.Length = 0 Then Response.Redirect("~/", True)

        Dim theDate_ As String = MyRequest.GetDate

        If theDate_.Length = 0 Then
            Dim MyUrl As String = NasLib.Functions.Web.Url.GetCurrentURL()

            Dim SatInit As String = SatelliteInitial
            If SatInit.Length = 0 Then
                SatInit = NasLib.Database.MySql.Provider.Table.UsersProfile.SatelliteInitial(MyRequest.OwnerId, ProvidersConnectionString)
            End If

            Dim MyKeys() As String = {MyRequest._Year, MyRequest._Month, MyRequest._Day, MyRequest._SatelliteInitial}
            Dim MyValues() As String = {Year(Now), Month(Now), Day(Now), SatInit}
            Dim MyQueryString As String = ""
            NasLib.Functions.Web.QueryString.ModifyQueryStringValue(MyQueryString, MyKeys, MyValues)

            Response.Redirect(MyUrl & "?" & MyQueryString, True)
        End If
    End Sub

    Public ReadOnly Property SatelliteId As Integer
        Get
            Dim ReturnValue As String = Table.OfficeSatellite.Id(SatelliteInitial, ProvidersConnectionString)

            If Not IsNumeric(ReturnValue) Then ReturnValue = 0
            Return ReturnValue
        End Get
    End Property

#End Region

#Region "Functions"

    Private Sub LoadStaffDuty()

        Dim StaffDutyTable As DataTable = MyModules.StaffDuty.DutyOnDate(CDate(TheDate), SatelliteInitial)
        Dim StaffDutyCount As Integer = StaffDutyTable.Rows.Count

        Dim QueryString As String = NasLib.Functions.Web.QueryString.GetCurrentQueryString

        'id, staff_id, duty_type_id, duty_date, branchId, satelliteId
        If StaffDutyCount > 0 Then
            For i As Integer = 0 To StaffDutyCount - 1
                Dim Username As String = StaffDutyTable(i)("staff_id")

                'Dim MyControls As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
                Dim MyControls As MyControls.Rdms.DutyCalendar.Staff = LoadControl("~\MyControls\Rdms\DutyCalendar\Staff.ascx")
                MyControls.DutyId = StaffDutyTable(i)("id")
                MyControls.StaffId = Username

                MyControls.ButtonVisible = Page.User.IsInRole("Administrator")
                MyControls.VirtualPathRemoveButton = "~/Pages/Admin/DutyRemoveProcess.aspx"
                MyControls.QueryStringRemoveButton = QueryString
                MyControls.DutyTypeId = StaffDutyTable(i)("duty_type_id")
                phDuty.Controls.Add(MyControls)
            Next

        End If

        StaffDutyTable.Dispose()

        Dim HasDuty As Boolean = phDuty.HasControls()
        If HasDuty Then
            lblMessage.Visible = False
            PanelNotes.Visible = True

            DutyTypeNotes.Initiate = True
        Else
            lblMessage.Visible = True
            PanelNotes.Visible = False
        End If


    End Sub

    Private Function IsPastDate() As Boolean
        Dim ReturnValue As Boolean = False
        Dim TheDate_ As Date = Now
        Dim DateStr As String = TheDate
        If IsDate(DateStr) Then TheDate_ = DateStr

        If CDate(TheDate_).AddDays(1) < CDate(Now) Then ReturnValue = True
        Return ReturnValue
    End Function

#End Region

#Region "Admin Views"

    Private Sub AdminPanelVisibility() Handles Me.Load
        If IsPastDate() Or Not User.IsInRole("Administrator") Then
            PanelAdmin.Visible = False
        Else
            PanelAdmin.Visible = True
        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RedirectUnproper()

        lblSatellite.Text = Table.OfficeSatellite.Satellite(SatelliteInitial, ProvidersConnectionString)
        lblDate.Text = Format(CDate(TheDate), "dd MMMM yyyy")
        LoadStaffDuty()
    End Sub

    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev1.ServerClick
        Dim TheDate_ As Date = MyRequest.GetDate
        Dim PrevDate = TheDate_.AddDays(-1)

        Dim MyKeys() As String = {MyRequest._Year, MyRequest._Month, MyRequest._Day}
        Dim MyValues() As String = {Format(PrevDate, "yyy"), Format(PrevDate, "MM"), Format(PrevDate, "dd")}

        MyResponse.Redirect(MyKeys, MyValues)
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext1.ServerClick
        Dim TheDate_ As Date = MyRequest.GetDate
        Dim NextDate = TheDate_.AddDays(1)

        Dim MyKeys() As String = {MyRequest._Year, MyRequest._Month, MyRequest._Day}
        Dim MyValues() As String = {Format(NextDate, "yyy"), Format(NextDate, "MM"), Format(NextDate, "dd")}

        MyResponse.Redirect(MyKeys, MyValues)
    End Sub

    Private Sub btnAdd_ServerClick(sender As Object, e As EventArgs) Handles btnAdd.ServerClick
        Dim MyVirtualPath As String = "~/Pages/Admin/DutySearch.aspx"

        Dim MyKeys() As String = {MyRequest._Year, MyRequest._Month, MyRequest._Day, MyRequest._SatelliteInitial}
        Dim MyValues() As String = {MyRequest.GetYear, MyRequest.GetMonth, MyRequest.GetDay, MyRequest.GetSatInit}

        MyResponse.Redirect(MyVirtualPath, MyKeys, MyValues)
    End Sub

    Private Sub btnMonthly_ServerClick(sender As Object, e As EventArgs) Handles btnMonthly.ServerClick
        Dim MyVirtualPath As String = "~\Pages\Duty\Calendar.aspx"

        Dim MyKeys() As String = {MyRequest._Year, MyRequest._Month, MyRequest._SatelliteInitial}
        Dim MyValues() As String = {MyRequest.GetYear, MyRequest.GetMonth, MyRequest.GetSatInit}
        MyResponse.Redirect(MyVirtualPath, MyKeys, MyValues)
    End Sub
End Class