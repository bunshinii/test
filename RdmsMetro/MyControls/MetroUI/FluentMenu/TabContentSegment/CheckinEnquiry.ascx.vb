Namespace MyControls.MetroUI.FluentMenu.TabContentSegment


    Public Class CheckinEnquiry
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property EnquiryQuickReference As Boolean
            Get
                Return enqQr.Checked
            End Get
            Set(value As Boolean)
                enqQr.Checked = value
            End Set
        End Property

        Public Property EnquiryAdvisoryGuidance As Boolean
            Get
                Return enqAg.Checked
            End Get
            Set(value As Boolean)
                enqAg.Checked = value
            End Set
        End Property

        Public Property EnquiryResearchReference As Boolean
            Get
                Return enqRr.Checked
            End Get
            Set(value As Boolean)
                enqRr.Checked = value
            End Set
        End Property

        Public Property EnquirySearchTechnique As Boolean
            Get
                Return enqSt.Checked
            End Get
            Set(value As Boolean)
                enqSt.Checked = value
            End Set
        End Property

        Public Property EnquiryOther As Boolean
            Get
                Return enqEtc.Checked
            End Get
            Set(value As Boolean)
                enqEtc.Checked = value
            End Set
        End Property

#End Region


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

