Namespace MyControls.MetroUI.FluentMenu.TabContentSegment.SegmentItems

    Public Class Link
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property Text As String
            Get
                Return Label1.Text
            End Get
            Set(value As String)
                Label1.Text = value
            End Set
        End Property

        Public Property Tooltip As String
            Get
                Return link1.ToolTip
            End Get
            Set(value As String)
                link1.ToolTip = value
            End Set
        End Property

        Public Property NavigateUrl As String
            Get
                Return link1.NavigateUrl
            End Get
            Set(value As String)
                link1.NavigateUrl = value
            End Set
        End Property

        Public Property Icon As String
            Get
                Return gIcon.Text
            End Get
            Set(value As String)
                gIcon.Text = value
            End Set
        End Property

#End Region

    End Class

End Namespace