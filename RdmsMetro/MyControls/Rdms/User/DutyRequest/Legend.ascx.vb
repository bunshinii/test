Namespace MyControls.Rdms.User.DutyRequest

    Public Class Legend
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property DutyName As String
            Get
                Return lblDutyName.Text
            End Get
            Set(value As String)
                lblDutyName.Text = value
            End Set
        End Property

        Public Property DutyTooltip As String
            Get
                Return lblDutyName.ToolTip
            End Get
            Set(value As String)
                lblDutyName.ToolTip = value
            End Set
        End Property

#Region "Color"

        Public Property BackGroundColor As String
            Get
                Return gBackgroundColor.Text
            End Get
            Set(value As String)
                gBackgroundColor.Text = value
            End Set
        End Property

        Public Property ForeGroundColor As String
            Get
                Return gForgroundColor.Text
            End Get
            Set(value As String)
                gForgroundColor.Text = value
            End Set
        End Property

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

