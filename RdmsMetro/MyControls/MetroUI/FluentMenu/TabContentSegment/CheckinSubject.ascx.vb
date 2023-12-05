Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class CheckinSubject
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property SubjectOnlineDatabase As Boolean
            Get
                Return subOd.Checked
            End Get
            Set(value As Boolean)
                subOd.Checked = value
            End Set
        End Property

        Public Property SubjectDigitalCollection As Boolean
            Get
                Dim IsChecked As Boolean = subDc.Checked
                Return IsChecked
            End Get
            Set(value As Boolean)
                subDc.Checked = value
            End Set
        End Property

        Public Property SubjectInternet As Boolean
            Get
                Return subIt.Checked
            End Get
            Set(value As Boolean)
                subIt.Checked = value
            End Set
        End Property

        Public Property SubjectOpac As Boolean
            Get
                Return subOp.Checked
            End Get
            Set(value As Boolean)
                subOp.Checked = value
            End Set
        End Property

        Public Property SubjectLrc As Boolean
            Get
                Return subLrc.Checked
            End Get
            Set(value As Boolean)
                subLrc.Checked = value
            End Set
        End Property

        Public Property SubjectFs As Boolean
            Get
                Return subFs.Checked
            End Get
            Set(value As Boolean)
                subFs.Checked = value
            End Set
        End Property

        Public Property SubjectRc As Boolean
            Get
                Return subRc.Checked
            End Get
            Set(value As Boolean)
                subRc.Checked = value
            End Set
        End Property

        Public Property SubjectVp As Boolean
            Get
                Return subVp.Checked
            End Get
            Set(value As Boolean)
                subVp.Checked = value
            End Set
        End Property

        Public Property SubjectJa As Boolean
            Get
                Return subJa.Checked
            End Get
            Set(value As Boolean)
                subJa.Checked = value
            End Set
        End Property

        Public Property SubjectGt As Boolean
            Get
                Return subGt.Checked
            End Get
            Set(value As Boolean)
                subGt.Checked = value
            End Set
        End Property

        Public Property SubjectOther As Boolean
            Get
                Return subEtc.Checked
            End Get
            Set(value As Boolean)
                subEtc.Checked = value
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace
