Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.DutyCalendar.Monthly

    Public Class Item
        Inherits System.Web.UI.UserControl

        Private ReadOnly Property SatelliteInitial As String
            Get
                Return MyRequest.GetSatInit
            End Get
        End Property

        Public Property TheDate As Date
            Get
                Dim ReturnValue As Date = Now
                If IsDate(gDate.Text) Then ReturnValue = gDate.Text

                Return ReturnValue
            End Get
            Set(value As Date)
                gDate.Text = Format(value, "yyy-MM-dd")

                Dim DayNo As Integer = Format(value, "dd")
                lblDate.Text = DayNo

                If Format(value, "yyy-MM-dd") = Format(Now, "yyy-MM-dd") Then IsTodayFormat()

                Dim VirtualPath As String = "~/Pages/Duty/OnDate.aspx"

                Dim MyKeys() As String = {MyRequest._Day, MyRequest._Month, MyRequest._Year, MyRequest._SatelliteInitial}
                Dim MyValues() As String = {Format(value, "dd"), Format(value, "MM"), Format(value, "yyy"), MyRequest.GetSatInit}
                hlGotoDate.NavigateUrl = MyResponse.Url(VirtualPath, MyKeys, MyValues)
            End Set
        End Property


        Private Sub IsTodayFormat()
            PanelHeader.BackColor = Drawing.Color.BlueViolet
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim StaffDutyTable As DataTable = MyModules.StaffDuty.DutyOnDate(TheDate, SatelliteInitial)
            Dim StaffDutyCount As Integer = StaffDutyTable.Rows.Count

            'id, staff_id, duty_type_id, duty_date, branchId, satelliteId
            If StaffDutyCount > 0 Then
                For i As Integer = 0 To StaffDutyCount - 1
                    Dim Username As String = StaffDutyTable(i)("staff_id")
                    Dim DutyTypeId As Integer = StaffDutyTable(i)("duty_type_id")
                    Dim DutyType As String = MyModules.StaffDuty.DutyType(DutyTypeId)

                    Dim MyControls As MyControls.Rdms.DutyCalendar.Monthly.SubItem = LoadControl("~/MyControls/Rdms/DutyCalendar/Monthly/SubItem.ascx")
                    MyControls.StaffId = Username
                    MyControls.DutyType = DutyType
                    MyControls.ForeColor = MyModules.StaffDuty.ForeColor(DutyTypeId)
                    MyControls.BackColor = MyModules.StaffDuty.BackgroundColor(DutyTypeId)
                    PlaceHolder1.Controls.Add(MyControls)
                Next
            End If

            StaffDutyTable.Dispose()
        End Sub



    End Class

End Namespace

