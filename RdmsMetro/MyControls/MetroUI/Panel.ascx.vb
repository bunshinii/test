Imports NasLib.Functions.Web

Namespace MyControls.MetroUI

    Public Class Panel
        Inherits System.Web.UI.UserControl

        Public Property BranchId As Integer
            Get
                Return gBranchId.Text
            End Get
            Set(value As Integer)
                gBranchId.Text = value
            End Set
        End Property


        Private Sub UpdateCachedRssFeeds(SubscriptionId As Integer)
            'Updating Rss Cache
            Dim RssTitle As String = Rss.RssTopic(SubscriptionId, MyAppConnectionString)
            Dim RssUrl As String = Rss.RssUrl(SubscriptionId, MyAppConnectionString)

            If Not NasLib.Functions.Web.Url.IsURLExist(RssUrl) Then
                lblMessage.Text = lblMessage.Text & String.Format("<p>{0}: Cant fetch RSS. broken link</p>", RssTitle)
                Exit Sub
            End If

            'Setting
            Dim ExpiredCache As Integer = Rss.RssCacheExpired

            Dim RssLastUpdate As Date = Rss.LastUpdated(SubscriptionId, MyAppConnectionString)
            Dim BranchId_ As Integer = BranchId

            Dim RssItemCount As Integer = Rss.GetCacheCount(SubscriptionId, MyAppConnectionString)

            If RssItemCount = 0 Then
                Rss.AddRssIntoCache(BranchId_, SubscriptionId, RssUrl, MyAppConnectionString)
                Rss.LastUpdated(SubscriptionId, MyAppConnectionString) = Now
            Else
                If Now > RssLastUpdate.AddMinutes(ExpiredCache) Then
                    Rss.ClearRssCachedBySubscribed(SubscriptionId, MyAppConnectionString)
                    Rss.AddRssIntoCache(BranchId_, SubscriptionId, RssUrl, MyAppConnectionString)
                    Rss.LastUpdated(SubscriptionId, MyAppConnectionString) = Now
                End If
            End If

        End Sub

        Private Sub LoadRssItems()
            Dim SubScribedTable As DataTable = Rss.SubscribedTable(BranchId, MyAppConnectionString)

            If SubScribedTable.Rows.Count > 0 Then

                For i As Integer = 0 To SubScribedTable.Rows.Count - 1
                    Dim SubscriptionId As Integer = SubScribedTable(i)("id")
                    UpdateCachedRssFeeds(SubscriptionId)
                Next

            End If

            SubScribedTable.Dispose()

            SimpleContainer.BranchId = BranchId
        End Sub


        Protected Sub btnMore_Click(sender As Object, e As EventArgs) Handles btnMore.Click
            Response.Redirect("~/Pages/Feed.aspx?branch=" & BranchId, True)
        End Sub

        Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            Timer1.Enabled = False
            Timer1.Interval = 999999999

            LoadRssItems()

            PanelWait.Visible = False
        End Sub

        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                MyMasterPage.MasterUpdateProgress.Visible = False
                Timer1.Enabled = True
            End If

        End Sub

        Protected Sub btnRefresh2_Click(sender As Object, e As EventArgs) Handles btnRefresh2.Click
            lblMessage.Text = Nothing
            Rss.ClearRssCachedByBranch(BranchId, MyAppConnectionString)

            LoadRssItems()
        End Sub
    End Class

End Namespace



