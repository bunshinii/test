Namespace MyControls.MetroUI.Buttons.Breadcrumbs


    Public Class Item
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public WriteOnly Property IsActive As Boolean
            Set(value As Boolean)
                If value Then
                    gActive.Text = " class=""active"""
                Else
                    gActive.Text = ""
                End If
            End Set
        End Property

        Public ReadOnly Property Active_ As String
            Get
                Return gActive.Text
            End Get
        End Property

        Public Property NavigateUrl As String
            Get
                Return hlItem.NavigateUrl
            End Get
            Set(value As String)
                hlItem.NavigateUrl = value
            End Set
        End Property

        Public Property Text As String
            Get
                Return hlItem.Text
            End Get
            Set(value As String)
                hlItem.Text = value
            End Set
        End Property

        Public Property Tooltip As String
            Get
                Return hlItem.ToolTip
            End Get
            Set(value As String)
                hlItem.Text = Tooltip
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

