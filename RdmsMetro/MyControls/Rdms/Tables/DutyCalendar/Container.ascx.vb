Namespace MyControls.Rdms.Tables.DutyCalendar

    Public Class Container
        Inherits System.Web.UI.UserControl

        Private Sub LoadDutyTable()

            'id, staff_id, duty_type_id, duty_date, branchId, satelliteId
            Dim DutyTable As DataTable = MyModules.Database.DutyStaff.GetAllDuty(MyOwnId, 30)
            Dim DutyCount As Integer = DutyTable.Rows.Count

            If DutyCount > 0 Then

                For i As Integer = 0 To DutyCount - 1
                    Dim MyControl As MyControls.Rdms.Tables.DutyCalendar.RowItem = LoadControl("~\MyControls\Rdms\Tables\DutyCalendar\RowItem.ascx")
                    MyControl.No = i + 1
                    MyControl.DutyId = DutyTable(i)("id")
                    MyControl.TheDate = CDate(DutyTable(i)("duty_date"))
                    MyControl.DutyTypeId = DutyTable(i)("duty_type_id")
                    MyControl.SatelliteId = DutyTable(i)("satelliteId")

                    PlaceHolder1.Controls.Add(MyControl)
                Next

            End If

            DutyTable.Dispose()

        End Sub

        Private Sub LoadLegendTable()
            'id, duty_type, note, bgColor, foreColor
            Dim LegendTable As DataTable = MyModules.Database.DutyType.GetAllDutyTypes
            Dim LegendCount As Integer = LegendTable.Rows.Count

            If LegendCount > 0 Then

                For i As Integer = 0 To LegendCount - 1
                    Dim MyControl As MyControls.Rdms.Tables.DutyCalendar.DutyLegendItem = LoadControl("~\MyControls\Rdms\Tables\DutyCalendar\DutyLegendItem.ascx")
                    MyControl.DutyTypeName = LegendTable(i)("duty_type")
                    MyControl.DutyTypeNote = LegendTable(i)("note")

                    PlaceHolder2.Controls.Add(MyControl)
                Next

            End If

            LegendTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadDutyTable()
            LoadLegendTable()

        End Sub

    End Class

End Namespace

