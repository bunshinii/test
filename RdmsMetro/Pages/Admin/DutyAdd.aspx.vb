Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class DutyAdd
    Inherits System.Web.UI.Page

#Region "Properties"

    Private ReadOnly Property RequestPatronId As String
        Get
            Return MyRequest.GetPatronId
        End Get
    End Property

    Public ReadOnly Property RequestDate As Date
        Get
            Return CDate(MyRequest.GetDate)
        End Get
    End Property

    Public ReadOnly Property GetQueryString As String
        Get
            Return NasLib.Functions.Web.QueryString.GetCurrentQueryString
        End Get
    End Property

#End Region

    Private Sub LoadDutyTypes()
        Dim QueryString As String = GetQueryString

        'id, duty_type, note, bgColor, foreColor
        Dim DutyTable As DataTable = MyModules.Database.DutyType.GetAllDutyTypes
        Dim DutyCount As Integer = DutyTable.Rows.Count

        If DutyCount > 0 Then
            For i As Integer = 0 To DutyCount - 1
                Dim MyControl As MyControls.Rdms.DutyCalendar.DutyTypeButton = LoadControl("~\MyControls\Rdms\DutyCalendar\DutyTypeButton.ascx")
                MyControl.DutyTypeId = DutyTable(i)("id")
                MyControl.DutyName = DutyTable(i)("duty_type")
                MyControl.ToolTip = DutyTable(i)("note")
                MyControl.BackGroundColor = DutyTable(i)("bgColor")
                MyControl.ForeGroundColor = DutyTable(i)("foreColor")

                MyControl.VirtualPath = "~/Pages/Admin/DutyAddProcess.aspx"
                MyControl.QueryString = QueryString
                phDutyType.Controls.Add(MyControl)
            Next

        End If

        DutyTable.Dispose()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PatronId As String = RequestPatronId
        Staff.StaffId = PatronId

        LoadDutyTypes()
    End Sub

End Class