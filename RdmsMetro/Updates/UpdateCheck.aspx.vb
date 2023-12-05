Public Class UpdateCheck
    Inherits System.Web.UI.Page

    Dim SvnUsername As String = "online-updater"
    Dim SvnPassword As String = "update!23"
    Dim CheckOutPath As String = Server.MapPath("~/")
    Dim ConfigDir As String = Server.MapPath("~/Bin/svn/Subversion")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckUpdate()
    End Sub

    Private Sub CheckUpdate()

        Dim SvnInfoCmd As String = String.Format("info {0} --show-item url --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", CheckOutPath, ConfigDir, SvnUsername, SvnPassword)
        Dim RepoUrl As String = SvnExe(SvnInfoCmd, False)
        lblUrl.Text = SvnExe(String.Format("info {0} --show-item relative-url --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", CheckOutPath, ConfigDir, SvnUsername, SvnPassword), False)

        lblRev.Text = SvnExe(String.Format("info {0} --show-item last-changed-revision --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", CheckOutPath, ConfigDir, SvnUsername, SvnPassword), False)
        Dim RevDate As Date = SvnExe(String.Format("info {0} --show-item last-changed-date --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", CheckOutPath, ConfigDir, SvnUsername, SvnPassword), False)
        lblDate.Text = Format(RevDate, "dd/MM/yyy HH:mm")

        lblSvrRev.Text = SvnExe(String.Format("info {0} --show-item last-changed-revision --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", RepoUrl, ConfigDir, SvnUsername, SvnPassword), False)
        Dim SvrDate As Date = SvnExe(String.Format("info {0} --show-item last-changed-date --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", RepoUrl, ConfigDir, SvnUsername, SvnPassword), False)
        lblSvrDate.Text = Format(SvrDate, "dd/MM/yyy HH:mm")

        Dim SvrMsg() As String = SvnExe(String.Format("log {0} --stop-on-copy --incremental -l 1 --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", RepoUrl, ConfigDir, SvnUsername, SvnPassword), False).Split("|")
        Dim SvrMsg2() As String = SvrMsg(3).Replace(vbCrLf & vbCrLf, "").Replace(vbCrLf, "<br />").Replace("lines", "|").Replace("line", "|").Split("|")
        lblSvrMsg.Text = SvrMsg2(1).ToString
        'test

        If Not lblRev.Text = lblSvrRev.Text Then
            lblUpdateStatus.Text = "This app requires an update"
            lblUpdateStatus.ForeColor = Drawing.Color.Red
            btnUpdate.Visible = True
        End If

        Dim UpdateLog As String = SvnExe(String.Format("log {0} --stop-on-copy --incremental --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", RepoUrl, ConfigDir, SvnUsername, SvnPassword), False).Replace("------------------------------------------------------------------------", "<br /><br />").Replace(vbCrLf & vbCrLf, "<br />").Replace(vbCrLf, "<br />").Replace("<br /><br />", "<br />")
        lblUpdateLog.Text = UpdateLog.Replace("<br /><br /><br />", "<br /><br />")
    End Sub

    Public Function SvnExe(Arg As String, UseShellExecute As Boolean) As String

        Dim Psi As New ProcessStartInfo
        Psi.WorkingDirectory = Server.MapPath("~/Bin/svn")
        Psi.FileName = Server.MapPath("~/Bin/svn/svn.exe")
        Psi.Arguments = Arg

        Psi.UseShellExecute = UseShellExecute
        Psi.RedirectStandardError = Not UseShellExecute
        Psi.RedirectStandardOutput = Not UseShellExecute

        Dim Proc As Process = Process.Start(Psi)
        Proc.WaitForExit()

        Dim ErrorOutput As String = String.Empty
        Dim StandardOutput As String = String.Empty

        If Not UseShellExecute Then
            ErrorOutput = Proc.StandardError.ReadToEnd.Trim
            StandardOutput = Proc.StandardOutput.ReadToEnd.Trim
        End If

        If Not Proc.ExitCode = 0 Then
            Throw New Exception(String.Format("Error : {0}, {1}", Proc.ExitCode.ToString(), ErrorOutput))
        End If

        Return StandardOutput
    End Function

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim MyStr As String = SvnExe(String.Format("up {0} -q --force --accept mc --username {2} --password {3} --no-auth-cache --non-interactive --config-dir {1}", CheckOutPath, ConfigDir, SvnUsername, SvnPassword), False)
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        CheckUpdate()
    End Sub


End Class