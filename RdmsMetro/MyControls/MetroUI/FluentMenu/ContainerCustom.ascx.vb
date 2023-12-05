Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.MetroUI.FluentMenu

    Public Class ContainerCustom
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property NewCheckInURL As String
            Get
                Return ResolveUrl("~/")
            End Get
            Set(value As String)

            End Set
        End Property

        Private ReadOnly Property PatronId As String
            Get
                Return PatronInfo1.PatronId
            End Get
        End Property

        Private ReadOnly Property SessionId As String
            Get
                Return NasLib.Functions.String.Guids.NewStringGuid
            End Get
        End Property

#End Region

        Private Sub SaveData(IsFinish_ As Boolean, IsKiv_ As Boolean)
            'Patron
            Dim StudentFacultyCode As String = PatronInfo1.StudentFacultyCode
            Dim StudentCampusCode As String = PatronInfo1.StudentCampusCode
            Dim StudentLevelCode As String = PatronInfo1.StudentLevelCode
            Dim StudentModeCode As String = PatronInfo1.StudentModeCode
            Dim StudentProgramCode As String = PatronInfo1.StudentProgramCode
            Dim StaffDepartmentCode As String = PatronInfo1.StaffDepartmentCode
            Dim StaffPositionCode As String = PatronInfo1.StaffPositionCode
            Dim StaffTypeCode As String = PatronInfo1.StaffTypeCode

            'Officer
            Dim OfficerId As String = Page.User.Identity.Name
            Dim BranchId As Integer = OfficerInfo1.BranchId
            Dim SatelliteId As Integer = OfficerInfo1.SatelliteId
            Dim DepartmentId As Integer = OfficerInfo1.DepartmentId
            Dim DivisionId As Integer = OfficerInfo1.DivisionId
            Dim UnitId As Integer = OfficerInfo1.UnitId

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
            Dim timeStart As String = SessionInfo1.TimeStart
            Dim timeEnd As String = Format(Now, "dd MMM yyyy HH:mm:ss")
            Dim isKiv As String = IsKiv_
            Dim isFinished As String = IsFinish_
            Dim _sessionId As String = SessionId

            If Not String.IsNullOrEmpty(PatronId) Then
                MyModules.Database.RdmsQuestions.QuestionAddCustom(PatronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_lrc, sub_rc, sub_fs, sub_vp, sub_ja, sub_gt, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, timeStart, timeEnd, isKiv, isFinished, OfficerId, BranchId, SatelliteId, DepartmentId, DivisionId, UnitId, StudentFacultyCode, StudentProgramCode, StudentCampusCode, StudentLevelCode, StudentModeCode, StaffDepartmentCode, StaffPositionCode, StaffTypeCode, SessionId)


                Dim MyVirtualPath As String = "~/Pages/User/SuccessCheckIn.aspx"

                Dim MyCode As Integer = 1
                If isKiv Then MyCode = 2
                MyResponse.Redirect(MyVirtualPath, MyRequest._Code, MyCode)
            Else
                lblMessage.Visible = True
            End If

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.User.Identity.IsAuthenticated Then OfficerInfo1.OfficerPatronId = Page.User.Identity.Name
        End Sub

        Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            SaveData(True, False)
        End Sub

        Protected Sub btnKiv_Click(sender As Object, e As EventArgs) Handles btnKiv.Click
            SaveData(False, True)
        End Sub
    End Class

End Namespace

