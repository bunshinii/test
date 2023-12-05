Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class PatronCheckIn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SessionId As String = MyRequest.GetSessionid

        Dim NewGuid As String = NasLib.Functions.String.Guids.NewStringGuid
        If String.IsNullOrEmpty(SessionId) Then
            Response.Redirect(NasLib.Functions.Web.Url.UpdateQueryStringValue("sessionid", NewGuid)) 'Jangan Kaco
        Else
            If Not SessionId.Length = 36 Or MyModules.Database.RdmsQuestions.IsExisted(SessionId) Then
                Response.Redirect(NasLib.Functions.Web.Url.UpdateQueryStringValue("sessionid", NewGuid)) 'Jangan Kaco
            End If
        End If

        Dim PatronId As String = MyRequest.GetPatronId
        If Not String.IsNullOrEmpty(PatronId) Then
            Dim Fullname_ As String = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronName(PatronId, DbLibraryConnectionString)
            Title = Fullname_
        End If

    End Sub

End Class