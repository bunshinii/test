Namespace MyControls.Rdms.Tables.EditCheckedIn

    Public Class Container
        Inherits System.Web.UI.UserControl

        Public Property IsKiv As Boolean
            Get
                Return gIsKiv.Checked
            End Get
            Set(value As Boolean)
                gIsKiv.Checked = value
            End Set
        End Property

        Public Property IsFinished As Boolean
            Get
                Return gIsFinished.Checked
            End Get
            Set(value As Boolean)
                gIsFinished.Checked = value
            End Set
        End Property



        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim OfficerId As String = Page.User.Identity.Name
            Dim CurrentMonth As String = Month(Now)
            Dim CurrentYear As String = Year(Now)

            Dim MyFieldname As String() = {"patronId", "mediumId", "sessionId", "timeStart"}

            Dim QuestionTable As DataTable = Nothing
            If IsFinished Then QuestionTable = MyModules.Database.RdmsQuestions.GetQuestionOnMonth(OfficerId, CurrentMonth, CurrentYear, MyFieldname)
            If IsKiv Then QuestionTable = MyModules.Database.RdmsQuestions.GetQuestionKiv(OfficerId, MyFieldname)

            Dim QuestionCount As Integer = QuestionTable.Rows.Count

            If QuestionCount > 0 Then
                For i As Integer = 0 To QuestionCount - 1
                    Dim MyControls As MyControls.Rdms.Tables.EditCheckedIn.RowItem = LoadControl("~\MyControls\Rdms\Tables\EditCheckedIn\RowItem.ascx")
                    MyControls.No = i + 1
                    MyControls.PatronId = QuestionTable(i)("patronId")
                    MyControls.MediumId = QuestionTable(i)("mediumId")
                    MyControls.SessionId = QuestionTable(i)("sessionId")
                    MyControls.TheDate = QuestionTable(i)("timeStart")

                    PlaceHolder1.Controls.Add(MyControls)
                Next
            End If

            QuestionTable.Dispose()
        End Sub

    End Class

End Namespace

