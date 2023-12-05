Namespace MyControls.Rdms.User

    Public Class Picture
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property PatronId As String
            Get
                Return gPatronId.Text
            End Get
            Set(value As String)
                gPatronId.Text = value
                Image1.ImageUrl = PicProviderLink(value)
            End Set
        End Property

        Public Property Width As String
            Get
                Return Image1.Width.ToString
            End Get
            Set(value As String)
                Image1.Width = value
            End Set
        End Property

        Public Property Height As String
            Get
                Return Image1.Height.ToString
            End Get
            Set(value As String)
                Image1.Height = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return Image1.ToolTip
            End Get
            Set(value As String)
                Image1.ToolTip = value
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

