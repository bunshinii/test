Namespace MyControls.MetroUI.FluentMenu.TabPanelGroup

    Public Class Snippet
        Inherits System.Web.UI.UserControl

#Region "Javascripts"

        Private Sub LoadJavascripts()
            CopyTextBetweenCountrols()
        End Sub

        Private Sub CopyTextBetweenCountrols()
            Dim CopyQuestionSnippetScript As String = String.Format( _
                "function CopyQuestionText() {{" & _
                "   myControl1 = document.getElementById('{0}');" & _
                "   myControl2 = document.getElementById('{1}');" & _
                "   myControl2.value = myControl2.value + myControl1.value;" & _
                "   document.getElementById('{0}').selectedIndex = 0;" & _
                "}}" _
                , ddQuestionID, "txtQuestion")

            ScriptManager.RegisterStartupScript(Page, Me.GetType, "copyQuestionText", CopyQuestionSnippetScript, True)
            ddQuestion.Attributes.Add("onclick", "CopyQuestionText()")

            Dim CopyAnswerSnippetScript As String = String.Format( _
                "function CopyAnswerText() {{" & _
                "   myControl1 = document.getElementById('{0}');" & _
                "   myControl2 = document.getElementById('{1}');" & _
                "   myControl2.value = myControl2.value + myControl1.value;" & _
                "   document.getElementById('{0}').selectedIndex = 0;" & _
                "}}" _
                , ddAnswerID, "txtAnswer")

            ScriptManager.RegisterStartupScript(Page, Me.GetType, "copyAnswerText", CopyAnswerSnippetScript, True)
            ddAnswer.Attributes.Add("onclick", "CopyAnswerText()")
        End Sub

#End Region


#Region "Public Properties"

        Private ReadOnly Property Officer As String
            Get
                Return Page.User.Identity.Name
            End Get
        End Property

        Private ReadOnly Property ddQuestionID As String
            Get
                Return ddQuestion.ClientID
            End Get
        End Property

        Private ReadOnly Property ddAnswerID As String
            Get
                Return ddAnswer.ClientID
            End Get
        End Property

#End Region


        Private Sub LoadDropdowns()
            LoadDdQuestion()
            LoadDdAnswer()
        End Sub

        Private Sub LoadDdQuestion()

            Dim MyListItem0 As New ListItem
            MyListItem0.Text = " -- Select Snippet -- "
            MyListItem0.Value = ""
            ddQuestion.Items.Add(MyListItem0)

            'id, officer, snippet, order_
            Dim SnippetTable As DataTable = MyModules.Database.RdmsSnippets.GetAllSnippets(Officer, "question")

            If SnippetTable.Rows.Count > 0 Then
                For i As Integer = 0 To SnippetTable.Rows.Count - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Text = SnippetTable(i)("snippet")
                    MyListItem.Value = SnippetTable(i)("snippet")
                    ddQuestion.Items.Add(MyListItem)
                Next
            End If

            SnippetTable.Dispose()
        End Sub

        Private Sub LoadDdAnswer()

            Dim MyListItem0 As New ListItem
            MyListItem0.Text = " -- Select Snippet -- "
            MyListItem0.Value = ""
            ddAnswer.Items.Add(MyListItem0)

            'id, officer, snippet, order_
            Dim SnippetTable As DataTable = MyModules.Database.RdmsSnippets.GetAllSnippets(Officer, "answer")

            If SnippetTable.Rows.Count > 0 Then
                For i As Integer = 0 To SnippetTable.Rows.Count - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Text = SnippetTable(i)("snippet")
                    MyListItem.Value = SnippetTable(i)("snippet")
                    ddAnswer.Items.Add(MyListItem)
                Next
            End If

            SnippetTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                LoadJavascripts()
                LoadDropdowns()

            End If
        End Sub

    End Class

End Namespace

