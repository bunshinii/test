Namespace MyControls.Rdms.DutyCalendar.Monthly

    Public Class Legend
        Inherits System.Web.UI.UserControl

        Public Property DutyTypeId As Integer
            Get
                Return gTypeId.Text
            End Get
            Set(value As Integer)
                gTypeId.Text = value


                LoadData(value)
            End Set
        End Property

        Public ReadOnly Property BackgroundColor As String
            Get
                Return gBackgroundColor.Text
            End Get
        End Property

        Public ReadOnly Property ForegroundColor As String
            Get
                Return gForegroundColor.Text
            End Get
        End Property

        Private Sub LoadData(TypeId As Integer)
            lblDutyType.Text = MyModules.StaffDuty.DutyType(TypeId)

            gBackgroundColor.Text = MyModules.StaffDuty.ForeColor(TypeId)
            gForegroundColor.Text = MyModules.StaffDuty.BackgroundColor(TypeId)

            Dim TypeDesc As String = MyModules.StaffDuty.DutyDesc(TypeId)

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

