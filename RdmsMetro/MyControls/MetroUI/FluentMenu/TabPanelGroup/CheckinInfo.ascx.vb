Namespace MyControls.MetroUI.FluentMenu.TabPanelGroup

    Public Class CheckinInfo
        Inherits System.Web.UI.UserControl

#Region "public Properties"

        Public Property PatronId As String
            Get
                Return gPatronId.Text
            End Get
            Set(value As String)
                gPatronId.Text = value
                LoadData()
            End Set
        End Property

        Public ReadOnly Property MediumId As Integer
            Get
                Return CheckinMedium1.MediumId
            End Get
        End Property

#Region "Subject"

        Public Property SubjectOnlineDatabase As Boolean
            Get
                Return CheckinSubject1.SubjectOnlineDatabase
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectOnlineDatabase = value
            End Set
        End Property

        Public Property SubjectDigitalCollection As Boolean
            Get
                Return CheckinSubject1.SubjectDigitalCollection
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectDigitalCollection = value
            End Set
        End Property

        Public Property SubjectInternet As Boolean
            Get
                Return CheckinSubject1.SubjectInternet
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectInternet = value
            End Set
        End Property

        Public Property SubjectOpac As Boolean
            Get
                Return CheckinSubject1.SubjectOpac
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectOpac = value
            End Set
        End Property

        Public Property SubjectLrc As Boolean
            Get
                Return CheckinSubject1.SubjectLrc
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectLrc = value
            End Set
        End Property

        Public Property SubjectRc As Boolean
            Get
                Return CheckinSubject1.SubjectRc
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectRc = value
            End Set
        End Property

        Public Property SubjectFs As Boolean
            Get
                Return CheckinSubject1.SubjectFs
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectFs = value
            End Set
        End Property

        Public Property SubjectVp As Boolean
            Get
                Return CheckinSubject1.SubjectVp
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectVp = value
            End Set
        End Property

        Public Property SubjectJa As Boolean
            Get
                Return CheckinSubject1.SubjectJa
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectJa = value
            End Set
        End Property

        Public Property SubjectGt As Boolean
            Get
                Return CheckinSubject1.SubjectGt
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectGt = value
            End Set
        End Property

        Public Property SubjectOther As Boolean
            Get
                Return CheckinSubject1.SubjectOther
            End Get
            Set(value As Boolean)
                CheckinSubject1.SubjectOther = value
            End Set
        End Property

#End Region

#Region "Enquiry type"

        Public Property EnquiryQuickReference As Boolean
            Get
                Return CheckinEnquiry1.EnquiryQuickReference
            End Get
            Set(value As Boolean)
                CheckinEnquiry1.EnquiryQuickReference = value
            End Set
        End Property

        Public Property EnquiryResearchReference As Boolean
            Get
                Return CheckinEnquiry1.EnquiryResearchReference
            End Get
            Set(value As Boolean)
                CheckinEnquiry1.EnquiryResearchReference = value
            End Set
        End Property

        Public Property EnquiryAdvisoryGuidance As Boolean
            Get
                Return CheckinEnquiry1.EnquiryAdvisoryGuidance
            End Get
            Set(value As Boolean)
                CheckinEnquiry1.EnquiryAdvisoryGuidance = value
            End Set
        End Property

        Public Property EnquirySearchTechnique As Boolean
            Get
                Return CheckinEnquiry1.EnquirySearchTechnique
            End Get
            Set(value As Boolean)
                CheckinEnquiry1.EnquirySearchTechnique = value
            End Set
        End Property

        Public Property EnquiryOther As Boolean
            Get
                Return CheckinEnquiry1.EnquiryOther
            End Get
            Set(value As Boolean)
                CheckinEnquiry1.EnquiryOther = value
            End Set
        End Property

#End Region

#End Region

#Region "Session Reload for Editor"

        Public Sub LoadSessionData(SessionId_ As String)

            Dim MyFields As String() = {"patronId", "mediumId", "sub_od", "sub_dc", "sub_it", "sub_op", "sub_lrc", "sub_rc", "sub_fs", "sub_vp", "sub_ja", "sub_gt", "sub_etc",
                                        "enq_qr", "enq_rr", "enq_st", "enq_ag", "enq_etc"}
            Dim SessionTable As DataTable = MyModules.Database.RdmsQuestions.GetQuestionSession(SessionId_, MyFields)

            'Medium
            CheckinMedium1.MediumId = SessionTable(0)("mediumId")

            'Subject
            CheckinSubject1.SubjectDigitalCollection = SessionTable(0)("sub_dc")
            CheckinSubject1.SubjectInternet = SessionTable(0)("sub_it")
            CheckinSubject1.SubjectOnlineDatabase = SessionTable(0)("sub_od")
            CheckinSubject1.SubjectOpac = SessionTable(0)("sub_op")
            CheckinSubject1.SubjectLrc = SessionTable(0)("sub_lrc")
            CheckinSubject1.SubjectRc = SessionTable(0)("sub_rc")
            CheckinSubject1.SubjectFs = SessionTable(0)("sub_fs")
            CheckinSubject1.SubjectVp = SessionTable(0)("sub_vp")
            CheckinSubject1.SubjectJa = SessionTable(0)("sub_ja")
            CheckinSubject1.SubjectGt = SessionTable(0)("sub_gt")
            CheckinSubject1.SubjectOther = SessionTable(0)("sub_etc")

            'Enquiries
            CheckinEnquiry1.EnquiryAdvisoryGuidance = SessionTable(0)("enq_ag")
            CheckinEnquiry1.EnquiryOther = SessionTable(0)("enq_etc")
            CheckinEnquiry1.EnquiryQuickReference = SessionTable(0)("enq_qr")
            CheckinEnquiry1.EnquiryResearchReference = SessionTable(0)("enq_rr")
            CheckinEnquiry1.EnquirySearchTechnique = SessionTable(0)("enq_st")

            SessionTable.Dispose()
        End Sub

#End Region


        Private Sub LoadData()
            Dim PatronId_ As String = PatronId

            PatronPhoto1.PatronId = PatronId_
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

