Public Class UserEditor
    Inherits System.Web.UI.Page

    Private Sub UserEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim PatronId As String = MyModules.Functions.QueryString.MyRequest.GetPatronId
        UserEditor1.PatronId = PatronId
        UserEditor1.VirtualBackPath = "~/Pages/Admin/UserSearchInternal.aspx"
    End Sub
End Class