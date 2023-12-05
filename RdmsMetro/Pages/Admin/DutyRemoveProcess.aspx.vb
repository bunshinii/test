Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class DutyRemoveProcess
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

    Public ReadOnly Property RequestDutyId As Integer
        Get
            Return MyRequest.GetDutyId()
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
        Dim DutyId As Integer = RequestDutyId
        Dim SatInit As String = RequestSat
        Dim TheDate As Date = RequestDate

        MyModules.Database.DutyStaff.DutyDelete(DutyId)

        Dim VirtualPath As String = "~/Pages/Duty/OnDate.aspx"
        '?sat=ptar&y=2014&m=08&d=22
        Dim MyKeys() As String = {MyRequest._SatelliteInitial, MyRequest._Year, MyRequest._Month, MyRequest._Day}
        Dim MyValues() As String = {SatInit, Year(TheDate), Month(TheDate), Day(TheDate)}
        MyResponse.Redirect(VirtualPath, MyKeys, MyValues)
    End Sub

End Class