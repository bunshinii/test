Public Class AllEditor
    Inherits System.Web.UI.UserControl


#Region "Public Properties"

    Public ReadOnly Property BroadcastTo As String
        Get
            Return "all"
        End Get
    End Property

#End Region

#Region "Functions"

    Private Sub LoadData()
        Dim AllId As Integer = 0
        Dim IsAnnExisted As Boolean = MyModules.Database.Announcement.IsExisted(AllId, BroadcastTo)

        If IsAnnExisted Then
            Dim AnnStr As String = MyModules.Database.Announcement.AnnouncementText(AllId, BroadcastTo)
            Editor1.Content = HttpUtility.HtmlDecode(AnnStr)

            Dim StartDate As Date = MyModules.Database.Announcement.StartDate(AllId, BroadcastTo)
            txtStartDate.Text = Format(StartDate, "dd MMM yyyy")

            Dim EndDate As Date = MyModules.Database.Announcement.EndDate(AllId, BroadcastTo)
            txtEndDate.Text = Format(EndDate, "dd MMM yyyy")
        End If

    End Sub

    Private Sub SaveData()

        If Not IsDate(txtStartDate.Text) Then
            lblMessage.Text = "You has not put a valid date in Start Date"
            Exit Sub
        End If

        If Not IsDate(txtEndDate.Text) Then
            lblMessage.Text = "You has not put a valid date in End Date"
            Exit Sub
        End If

        Dim AllId As Integer = 0
        Dim IsAnnExisted As Boolean = MyModules.Database.Announcement.IsExisted(AllId, BroadcastTo)

        Dim AnnouncementText As String = HttpUtility.HtmlEncode(Editor1.Content)
        Dim StartDate As Date = txtStartDate.Text
        Dim EndDate As Date = txtEndDate.Text

        If Not IsAnnExisted Then
            MyModules.Database.Announcement.AnnouncementAdd(AllId, BroadcastTo, AnnouncementText, StartDate, EndDate)
        Else
            MyModules.Database.Announcement.AnnouncementText(AllId, BroadcastTo) = AnnouncementText
            MyModules.Database.Announcement.StartDate(AllId, BroadcastTo) = StartDate
            MyModules.Database.Announcement.EndDate(AllId, BroadcastTo) = EndDate
            MyModules.Database.Announcement.LastUpdated(AllId, BroadcastTo) = Now
        End If

    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then LoadData()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
        Response.Redirect("~/Pages/Admin/Application/Announcement/Announcement.aspx")
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Editor1.Content = ""
    End Sub
End Class