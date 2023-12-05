Public Class WorkLog
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim OfficerId As String = Page.User.Identity.Name
        Dim IpAddress As String = GetClientIPAddress()

        MyModules.Database.RdmsLog.LogAdd(IpAddress, OfficerId, txtLog.Text)
    End Sub

    Private Function GetClientIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim ipAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If Not String.IsNullOrEmpty(ipAddress) Then
            Dim addresses As String() = ipAddress.Split(","c)
            If addresses.Length <> 0 Then
                Return addresses(0)
            End If
        End If

        Return context.Request.ServerVariables("REMOTE_ADDR")
    End Function
End Class