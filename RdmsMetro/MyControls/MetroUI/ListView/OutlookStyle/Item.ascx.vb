Namespace MyControls.MetroUI.ListView.OutlookStyle

    Public Class Item
        Inherits System.Web.UI.UserControl

        Public Property Title As String
            Get
                Return lblTitle.Text
            End Get
            Set(value As String)
                lblTitle.ToolTip = value
                lblTitle.Text = value
            End Set
        End Property

        Public Property PubDate As String
            Get
                Return lblPubDate.Text
            End Get
            Set(value As String)
                lblPubDate.Text = value
            End Set
        End Property

        Public Property Link As String
            Get
                Return hlLink.NavigateUrl
            End Get
            Set(value As String)
                hlLink.NavigateUrl = value

                imgFavicon.ImageUrl = NasLib.Functions.Web.Favicon.GetFaviconUrl(value)
            End Set
        End Property


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

