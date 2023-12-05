Namespace MyControls.Rdms.User

    Public Class DutyLegend
        Inherits System.Web.UI.UserControl

        Public Property Text As String
            Get
                Return lblLegend.Text
            End Get
            Set(value As String)
                lblLegend.Text = value
            End Set
        End Property

        Public Property BgColor As String
            Get
                Return gBgColor.Text
            End Get
            Set(value As String)
                gBgColor.Text = value
            End Set
        End Property

        Public ReadOnly Property Colors As String
            Get
                Return FgColor & " " & BgColor
            End Get
        End Property

        Public Property FgColor As String
            Get
                Return gFgColor.Text
            End Get
            Set(value As String)
                gFgColor.Text = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return lblLegend.ToolTip
            End Get
            Set(value As String)
                lblLegend.ToolTip = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace