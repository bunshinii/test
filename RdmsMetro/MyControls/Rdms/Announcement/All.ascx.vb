Namespace MyControls.Rdms.Announcement

    Public Class All
        Inherits System.Web.UI.UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Label1.Text = MyModules.Announcement.GetAnnouncement(0, MyModules.Announcement.broadcastTo.all)
        End Sub

    End Class

End Namespace

