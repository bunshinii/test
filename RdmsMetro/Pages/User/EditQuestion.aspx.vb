Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class EditQuestion
    Inherits System.Web.UI.Page

    Private ReadOnly Property SessionId As String
        Get
            Return MyRequest.GetSessionid
        End Get
    End Property

    Private ReadOnly Property QuestionOwnerId As String
        Get
            Return MyModules.Database.RdmsQuestions.Officer(SessionId)
        End Get
    End Property

    Private Sub EditQuestion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim QuestionOwnerId_ As String = QuestionOwnerId
        Dim OwnId As String = MyRequest.OwnerId

        If Not QuestionOwnerId = OwnId Then

        End If

    End Sub
End Class