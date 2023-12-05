Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class DutyAddProcess
    Inherits System.Web.UI.Page

#Region "Public Property"

    Public ReadOnly Property RequestDate As Date
        Get
            Return MyRequest.GetDate()
        End Get
    End Property

    Public ReadOnly Property RequestSat As String
        Get
            Return MyRequest.GetSatInit()
        End Get
    End Property

    Public ReadOnly Property RequestDutyTypeId As Integer
        Get
            Return MyRequest.GetDutyTypeId()
        End Get
    End Property

    Public ReadOnly Property RequestPatronid As String
        Get
            Return MyRequest.GetPatronId()
        End Get
    End Property

#End Region

#Region "Functions"

    Private Sub CheckAdministrator()
        If Not Page.User.IsInRole("Administrator") Then
            Response.Redirect("~/")
        End If
    End Sub

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckAdministrator()

        Dim PatronId As String = RequestPatronid
        Dim DutyTypeId As Integer = RequestDutyTypeId
        Dim SatInit As String = RequestSat
        Dim TheDate As Date = RequestDate

        Dim SatId As Integer = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Id(SatInit, ProvidersConnectionString)
        Dim BranchId As Integer = NasLib.Database.MySql.Provider.Table.OfficeSatellite.BranchId(SatInit, ProvidersConnectionString)

        MyModules.Database.DutyStaff.DutyAdd(PatronId, DutyTypeId, BranchId, SatId, TheDate)

        Dim VirtualPath As String = "~/Pages/Duty/OnDate.aspx"
        '?sat=ptar&y=2014&m=08&d=22
        Dim MyKeys() As String = {MyRequest._SatelliteInitial, MyRequest._Year, MyRequest._Month, MyRequest._Day}
        Dim MyValues() As String = {SatInit, Year(TheDate), Month(TheDate), Day(TheDate)}
        MyResponse.Redirect(VirtualPath, MyKeys, MyValues)
    End Sub

End Class