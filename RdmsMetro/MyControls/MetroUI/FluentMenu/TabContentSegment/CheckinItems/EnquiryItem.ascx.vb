Namespace MyControls.MetroUI.FluentMenu.TabContentSegment.CheckinItems

    Public Class EnquiryItem
        Inherits System.Web.UI.UserControl

        Public Property Checked As Boolean
            Get
                Return CheckBox1.Checked
            End Get
            Set(value As Boolean)
                CheckBox1.Checked = value
            End Set
        End Property

        Public Property Text As String
            Get
                Return Label1.Text
            End Get
            Set(value As String)
                Label1.Text = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return Label1.ToolTip
            End Get
            Set(value As String)
                Label1.ToolTip = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

