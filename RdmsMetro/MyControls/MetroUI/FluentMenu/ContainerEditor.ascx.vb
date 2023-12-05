Imports NasLib.Database.MySql.Sql.Simplifier
Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.MetroUI.FluentMenu

    Public Class ContainerEditor
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property NewCheckInURL As String
            Get
                Return ResolveUrl("~/")
            End Get
            Set(value As String)

            End Set
        End Property

        Private ReadOnly Property PatronIdQs As String
            Get
                Return MyRequest.GetPatronId
            End Get
        End Property

        Private ReadOnly Property PatronIdDb As String
            Get
                Return MyModules.Database.RdmsQuestions.PatronId(SessionId)
            End Get
        End Property

        Private ReadOnly Property SessionId As String
            Get
                Return MyRequest.GetSessionid
            End Get
        End Property

        Private Property TimeStart As Date
            Get
                Return SessionInfo1.TimeStart
            End Get
            Set(value As Date)
                SessionInfo1.TimeStart = value
            End Set
        End Property

        Private Property TimeEnd As Date
            Get
                Return SessionInfo1.TimeEnd
            End Get
            Set(value As Date)
                SessionInfo1.TimeEnd = value
            End Set
        End Property

        Public Property IsReadOnly As Boolean
            Get
                Return gIsReadOnly.Checked
            End Get
            Set(value As Boolean)
                gIsReadOnly.Checked = value
            End Set
        End Property

        Public ReadOnly Property OfficerId As String
            Get
                Dim OfficerId_ As String = MyModules.Database.RdmsQuestions.Officer(SessionId)
                Return OfficerId_
            End Get
        End Property

#End Region

#Region "Functions"

        Private Sub EnforceReadOnly()
            btnKiv.Visible = False
            btnSave.Visible = False

            li_snippet.Style.Add("display", "none")

        End Sub

#End Region

        Private Sub LoadSessionData()
            Dim SessionId_ As String = SessionId

            CheckinInfo1.LoadSessionData(SessionId_)
            SessionInfo1.LoadSessionData(SessionId_)

            txtQuestion.Text = MyModules.Database.RdmsQuestions.Question(SessionId_)
            txtAnswer.Text = MyModules.Database.RdmsQuestions.Answer(SessionId_)

        End Sub

        Private Sub UpdateData(IsFinish_ As Boolean, IsKiv_ As Boolean)

            If Not SessionInfo1.ValidateTimeStartText Then
                lblMessage.Text = "Session Date in Session Info is not a valid time."
                Exit Sub
            End If

            'Question
            Dim mediumId As String = CheckinInfo1.MediumId
            Dim sub_od As Boolean = CheckinInfo1.SubjectOnlineDatabase
            Dim sub_dc As Boolean = CheckinInfo1.SubjectDigitalCollection
            Dim sub_it As Boolean = CheckinInfo1.SubjectInternet
            Dim sub_op As Boolean = CheckinInfo1.SubjectOpac
            Dim sub_lrc As Boolean = CheckinInfo1.SubjectLrc
            Dim sub_rc As Boolean = CheckinInfo1.SubjectRc
            Dim sub_fs As Boolean = CheckinInfo1.SubjectFs
            Dim sub_vp As Boolean = CheckinInfo1.SubjectVp
            Dim sub_ja As Boolean = CheckinInfo1.SubjectJa
            Dim sub_gt As Boolean = CheckinInfo1.SubjectGt
            Dim sub_etc As Boolean = CheckinInfo1.SubjectOther
            Dim enq_qr As Boolean = CheckinInfo1.EnquiryQuickReference
            Dim enq_rr As Boolean = CheckinInfo1.EnquiryResearchReference
            Dim enq_st As Boolean = CheckinInfo1.EnquirySearchTechnique
            Dim enq_ag As Boolean = CheckinInfo1.EnquiryAdvisoryGuidance
            Dim enq_etc As Boolean = CheckinInfo1.EnquiryOther
            Dim question As String = txtQuestion.Text
            Dim answer As String = txtAnswer.Text
            Dim TimeStart_ As Date = TimeStart
            Dim TimeEnd_ As Date = TimeEnd

            Dim duration As TimeSpan = TimeEnd_.Subtract(TimeStart_)

            Dim MyFieldNames() As String = FieldNamesToArray("mediumId", "sub_od", "sub_dc", "sub_it", "sub_op", "sub_lrc", "sub_rc", "sub_fs", "sub_vp", "sub_ja", "sub_gt", "sub_etc", "enq_qr", "enq_rr", "enq_st", "enq_ag", "enq_etc", "question", "answer", "timeStart", "timeEnd", "duration", "isKiv", "isFinished")
            Dim MyFieldValues() As String = FieldValuesToArray(mediumId, sub_od, sub_dc, sub_it, sub_op, sub_lrc, sub_rc, sub_fs, sub_vp, sub_ja, sub_gt, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, TimeStart, TimeEnd, duration.ToString, IsKiv_, IsFinish_)

            MyModules.Database.RdmsQuestions.QuestionUpdate(SessionId, MyFieldNames, MyFieldValues)


            Dim MyVirtualPath As String = "~/Pages/User/SuccessCheckIn.aspx"

            Dim MyCode As Integer = 3
            If IsKiv_ Then MyCode = 4
            MyResponse.Redirect(MyVirtualPath, MyRequest._Code, MyCode)

            Response.Redirect("~/Pages/User/SuccessCheckIn.aspx")
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim OfficerId_ As String = OfficerId

            If PatronIdQs.Length > 0 Then   'Considering CustomId that has No ID
                If Not PatronIdDb = PatronIdQs Then Response.Redirect("~/")
            End If


            If Not IsPostBack Then
                Dim _PatronId As String = PatronIdQs

                PatronInfo1.PatronId = _PatronId
                CheckinInfo1.PatronId = _PatronId

                OfficerInfo1.OfficerPatronId = OfficerId_

                LoadSessionData()
            End If



            If IsReadOnly Or Not MyRequest.OwnerId = OfficerId Then EnforceReadOnly()

        End Sub


        Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            UpdateData(True, False)
        End Sub

        Protected Sub btnKiv_Click(sender As Object, e As EventArgs) Handles btnKiv.Click
            UpdateData(False, True)
        End Sub

    End Class

End Namespace

