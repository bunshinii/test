Namespace MyControls.Rdms.DutyCalendar

    Public Class DutyTypeNotes
        Inherits System.Web.UI.UserControl

        ''' <summary>
        ''' Load
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public WriteOnly Property Initiate As Boolean
            Set(value As Boolean)
                If value Then LoadValues()
            End Set
        End Property

        Private Sub LoadValues()
            'id, duty_type, note, bgColor, foreColor
            Dim DutyTable As DataTable = MyModules.Database.DutyType.GetAllDutyTypes
            Dim DutyCount As Integer = DutyTable.Rows.Count

            If DutyCount > 0 Then
                For i As Integer = 0 To DutyCount - 1
                    Dim MyControl2 As MyControls.Rdms.DutyCalendar.DutyTypeNote.Item = LoadControl("~\MyControls\Rdms\DutyCalendar\DutyTypeNote\Item.ascx")
                    MyControl2.DutyName = DutyTable(i)("duty_type")
                    MyControl2.DutyDescription = DutyTable(i)("note")
                    MyControl2.BackGroundColor = DutyTable(i)("bgColor")
                    MyControl2.ForeGroundColor = DutyTable(i)("foreColor")
                    phDutyType2.Controls.Add(MyControl2)
                Next

            End If

            DutyTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

