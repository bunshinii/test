Imports NasLib.Functions.Web

Namespace MyControls.MetroUI.ListView.OutlookStyle

    Public Class SimpleContainer
        Inherits System.Web.UI.UserControl

        Public Property BranchId As Integer
            Get
                Return gBranchId.Text
            End Get
            Set(value As Integer)
                gBranchId.Text = value
                LoadRssItem()
            End Set
        End Property

        ''' <summary>
        ''' Must be called before BranchId
        ''' </summary>
        Public Property IsFullView As Boolean
            Get
                Return gFullPage.Checked
            End Get
            Set(value As Boolean)
                gFullPage.Checked = value
            End Set
        End Property

        Private Sub LoadRssItem()
            Dim MaxRssView As Integer = 30
            If Not IsFullView Then MaxRssView = Rss.RssMaxView()

            Dim RssTable As DataTable = Rss.GetRssCacheTableByBranch(BranchId, MaxRssView, MyAppConnectionString)

            If RssTable.Rows.Count > 0 Then
                For i As Integer = 0 To RssTable.Rows.Count - 1

                    Dim MyControls As MyControls.MetroUI.ListView.OutlookStyle.Item = LoadControl("~/MyControls/MetroUI/ListView/OutlookStyle/Item.ascx")
                    MyControls.Title = NasLib.Functions.Web.Html.Decode(RssTable(i)("title"))
                    MyControls.PubDate = RssTable(i)("pubDate")

                    Dim mylink As String = NasLib.Functions.Web.Url.Decode(RssTable(i)("link"))
                    MyControls.Link = mylink
                    phListItem.Controls.Add(MyControls)
                Next
            End If

            RssTable.Dispose()

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

