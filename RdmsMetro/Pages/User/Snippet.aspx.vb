Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Snippet
    Inherits System.Web.UI.Page

#Region "Load Data"

    Private Sub LoadData()
        Dim SnippetType As String = MyRequest.GetSnippetType
        ddSnippetType.SelectedValue = SnippetType

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
        End If


        SnippetTable1.SnippetType = ddSnippetType.SelectedValue

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        MyResponse.Redirect(MyRequest._SnippetType, ddSnippetType.SelectedValue)
    End Sub


End Class