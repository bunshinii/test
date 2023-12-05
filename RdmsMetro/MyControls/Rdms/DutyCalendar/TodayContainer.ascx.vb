Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.DutyCalendar

    Public Class TodayContainer
        Inherits System.Web.UI.UserControl


        Public Property SatelliteId As Integer
            Get
                Return gSatelliteId.Text
            End Get
            Set(value As Integer)
                gSatelliteId.Text = value
                LoadStaff()
            End Set
        End Property

        Private Sub LoadStaff()
            Dim DutyTodayTable As DataTable = MyModules.StaffDuty.DutyToday(SatelliteId)

            Dim DutyCount As Integer = DutyTodayTable.Rows.Count

            'id, staff_id, duty_type_id, duty_date, branchId, satelliteId
            If DutyCount > 0 Then
                For i As Integer = 0 To DutyCount - 1
                    Dim MyControls As MyControls.Rdms.DutyCalendar.Staff = LoadControl("~/MyControls/Rdms/DutyCalendar/Staff.ascx")

                    Dim StaffId As String = DutyTodayTable(i)("staff_id")
                    Dim DutyTypeId As Integer = DutyTodayTable(i)("duty_type_id")
                    MyControls.StaffId = StaffId
                    MyControls.DutyTypeId = DutyTypeId
                    MyControls.ButtonVisible = False
                    phStaff.Controls.Add(MyControls)
                Next
            Else
                lblMessage.Text = "No staff in duty."
            End If


            DutyTodayTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            
        End Sub

    End Class

End Namespace

