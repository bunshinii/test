Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Provider

Public Class _Default
    Inherits System.Web.UI.Page

#Region "Public Properties"

    Public ReadOnly Property SatelliteInitial As String
        Get
            Return MyModules.Functions.QueryString.MyRequest.GetSatInit
        End Get
    End Property

    Public ReadOnly Property BranchId As Integer
        Get
            Dim ReturnValue As String = Table.OfficeSatellite.BranchId(SatelliteInitial, ProvidersConnectionString)

            If Not IsNumeric(ReturnValue) Then ReturnValue = 0
            Return ReturnValue
        End Get
    End Property

    Public ReadOnly Property SatelliteId As Integer
        Get
            Dim ReturnValue As String = Table.OfficeSatellite.Id(SatelliteInitial, ProvidersConnectionString)

            If Not IsNumeric(ReturnValue) Then ReturnValue = 0
            Return ReturnValue
        End Get
    End Property

#End Region

#Region "Functions"

    Private Sub LoadBranches()

        Dim BranchContainer As MyControls.Rdms.Organization.BranchList.Container = LoadControl("~/MyControls/Rdms/Organization/BranchList/Container.ascx")
        PlaceHolder1.Controls.Add(BranchContainer)

    End Sub

    Private Sub LoadActivePanel()
        Dim Initial As String = SatelliteInitial

        lblSatelliteName.Text = Table.OfficeSatellite.Satellite(Initial, ProvidersConnectionString)
    End Sub

    Private Sub LoadStaffDuty()
        'id, staff_id, duty_type_id, duty_date, branchId, satelliteId
        Dim MyControl As MyControls.Rdms.DutyCalendar.TodayContainer = LoadControl("~/MyControls/Rdms/DutyCalendar/TodayContainer.ascx")
        MyControl.SatelliteId = SatelliteId
        phDuty.Controls.Add(MyControl)
    End Sub

    Private Sub LoadRss()
        Dim MyRssControl As MyControls.MetroUI.Panel = LoadControl("~/MyControls/MetroUI/Panel.ascx")
        MyRssControl.BranchId = BranchId
        phRss.Controls.Add(MyRssControl)
    End Sub

    Private Sub LoadAnnouncements()
        Satellite1.SatelliteId = SatelliteId
        Branch1.BranchId = BranchId
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Initial As String = SatelliteInitial
        If Initial.Length = 0 Then

            If Page.User.Identity.IsAuthenticated Then
                Dim SatInitial As String = NasLib.Functions.Web.CurrentUser.SatelliteInitial

                Dim CurrentURL As String = NasLib.Functions.Web.Url.GetCurrentURL(True)
                Dim RedirectURL As String = NasLib.Functions.Web.Url.UpdateQueryStringValue("sat", SatInitial)
                Response.Redirect(RedirectURL, True)
            End If

            LoadBranches()

            PanelSelectSatellite.Visible = True
            PanelSatelliteView.Visible = False

        Else
            'To ByPass RSS double postback
            Dim MyTimer As Boolean = MyMasterPage.AsyncPostBackSourceElementID.Contains("Timer")
            If MyTimer Then
                LoadRss()
                Exit Sub
            End If

            LoadAnnouncements()
            LoadActivePanel()
            LoadRss()
            LoadStaffDuty()

            PanelSelectSatellite.Visible = False
            PanelSatelliteView.Visible = True

            Dim MyVirtualPath As String = "~/Pages/Duty/Calendar.aspx"
            'MyModules.Functions.QueryString.MyRequest.SatInit(MyVirtualPath, Initial)
            'hlCalendar.NavigateUrl = MyVirtualPath
            hlCalendar.NavigateUrl = MyResponse.Url(MyVirtualPath, MyRequest._SatelliteInitial, MyRequest.GetSatInit)

        End If
    End Sub

End Class