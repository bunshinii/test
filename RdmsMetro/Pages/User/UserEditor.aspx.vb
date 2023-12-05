Public Class UserEditor1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserEditor1.PatronId = MyModules.Functions.CurrentUsername
        UserEditor1.VirtualBackPath = "~/"
    End Sub

End Class