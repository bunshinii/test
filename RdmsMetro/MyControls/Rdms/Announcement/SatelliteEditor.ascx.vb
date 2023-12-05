Namespace MyControls.Rdms.Announcement

    Public Class SatelliteEditor
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public ReadOnly Property BroadcastTo As String
            Get
                Return "satellite"
            End Get
        End Property

        Public Property SatteliteId As Integer
            Get
                Return gSatId.Text
            End Get
            Set(value As Integer)
                gSatId.Text = value

                If Not IsPostBack Then LoadData()
            End Set
        End Property

#End Region

#Region "Functions"

        Private Sub LoadData()
            Dim SatId As Integer = SatteliteId
            Dim IsAnnExisted As Boolean = MyModules.Database.Announcement.IsExisted(SatId, BroadcastTo)

            If IsAnnExisted Then
                Dim AnnStr As String = MyModules.Database.Announcement.AnnouncementText(SatId, BroadcastTo)
                Editor1.Content = HttpUtility.HtmlDecode(AnnStr)

                Dim StartDate As Date = MyModules.Database.Announcement.StartDate(SatId, BroadcastTo)
                txtStartDate.Text = Format(StartDate, "dd MMM yyyy")

                Dim EndDate As Date = MyModules.Database.Announcement.EndDate(SatId, BroadcastTo)
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

            Dim SatId As Integer = SatteliteId
            Dim IsAnnExisted As Boolean = MyModules.Database.Announcement.IsExisted(SatId, BroadcastTo)

            Dim AnnouncementText As String = HttpUtility.HtmlEncode(Editor1.Content)
            Dim StartDate As Date = txtStartDate.Text
            Dim EndDate As Date = txtEndDate.Text

            If Not IsAnnExisted Then
                MyModules.Database.Announcement.AnnouncementAdd(SatId, BroadcastTo, AnnouncementText, StartDate, EndDate)
            Else
                MyModules.Database.Announcement.AnnouncementText(SatId, BroadcastTo) = AnnouncementText
                MyModules.Database.Announcement.StartDate(SatId, BroadcastTo) = StartDate
                MyModules.Database.Announcement.EndDate(SatId, BroadcastTo) = EndDate
                MyModules.Database.Announcement.LastUpdated(SatId, BroadcastTo) = Now
            End If

        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            SaveData()
            Response.Redirect("~/Pages/Admin/Application/Announcement/Announcement.aspx")
        End Sub

        Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
            Editor1.Content = ""
        End Sub
    End Class

End Namespace

