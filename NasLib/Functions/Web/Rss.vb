Imports RssToolkit.Rss
Imports NasLib.Database.MySql.Sql.Simplifier
Imports System.Data

Namespace Functions.Web

    Public Class Rss


#Region "Rss to Datatable"

        '===================
        'TABLE COLUMN NAMES
        '===================
        '1. comments
        '2. description	
        '3. link	
        '4. pubDate	
        '5. pubDateParsed	
        '6. title

        ''' <summary>
        ''' Get Rss data from specified URL to DataTable
        ''' </summary>
        ''' <param name="RssURL">Rss URL</param>
        ''' <param name="MaxItem">Max Item</param>
        ''' <param name="ReverseOrder">Reverse Order?</param>
        ''' <returns></returns>
        Public Shared Function RssToDataTable(RssURL As String, MaxItem As Integer, ReverseOrder As Boolean) As System.Data.DataTable

            Dim rss As RssDocument = RssDocument.Load(New System.Uri(RssURL))
            Dim MyRssDataView As DataView

            If MaxItem = 0 Then
                MyRssDataView = rss.SelectItems()
            Else
                If Not ReverseOrder Then
                    MyRssDataView = rss.SelectItems(MaxItem)
                Else
                    MyRssDataView = rss.SelectItems(MaxItem, ReverseOrder)
                End If
            End If

            Dim MyRssTable As System.Data.DataTable = MyRssDataView.ToTable

            MyRssDataView.Dispose()
            Return MyRssTable
        End Function

        ''' <summary>
        ''' Get Rss data from specified URL to DataTable
        ''' </summary>
        ''' <param name="RssURL">Rss URL</param>
        ''' <param name="MaxItem">Max Item</param>
        ''' <returns></returns>
        Public Shared Function RssToDataTable(RssURL As String, MaxItem As Integer) As System.Data.DataTable
            Return RssToDataTable(RssURL, MaxItem, False)
        End Function

        ''' <summary>
        ''' Get Rss data from specified URL to DataTable
        ''' </summary>
        ''' <param name="RssURL">Rss URL</param>
        ''' <returns></returns>
        Public Shared Function RssToDataTable(RssURL As String) As System.Data.DataTable
            Return RssToDataTable(RssURL, 0)
        End Function

#End Region

#Region "Rss Document Info"

        ''' <summary>
        ''' Get Rss Info.
        ''' </summary>
        ''' <param name="RssURL">Rss URL</param>
        ''' <returns>Can get info through Channel</returns>
        ''' <remarks></remarks>
        Public Shared Function RssDocumentInfo(RssURL As String) As RssDocument
            Dim rss As RssDocument = RssDocument.Load(New System.Uri(RssURL))
            Return rss
        End Function

#End Region

#Region "Branch Subscribed Rss"

#Region "MySqlSetting"

        Shared TableSubscribed As String = "rss_subscribed"
        Shared TableRssItems As String = "rss_cache"
        Shared MyCmd As New NasLib.Database.MySql.Sql.Commands

        Public Enum eSubscribedFieldName
            id
            branchId
            topic
            rss_url
            lastUpdated
            enabled
        End Enum

        Public Enum eRssItemFieldName
            branchId
            subId
            title
            link
            pubDate
            pubDateParsed
        End Enum

#End Region

#Region "Table Properties"

#Region "rss_subscribed"

        ''' <summary>
        ''' Get BracnhId by Rss Id
        ''' </summary>
        ''' <param name="SubscriptionId">Rss ID</param>
        Public Shared Property XmlBranchId(SubscriptionId As Integer, MyAppConnectionString As String) As Integer
            Get
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                Return MyCmd.CmdSelect0(TableSubscribed, eSubscribedFieldName.branchId.ToString, 0, MyCriteria, , MyAppConnectionString)
            End Get
            Set(value As Integer)
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                MyCmd.CmdUpdate3(TableSubscribed, eSubscribedFieldName.branchId.ToString, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Rss Topic for the XML file
        ''' </summary>
        Public Shared Property RssTopic(SubscriptionId As Integer, MyAppConnectionString As String) As String
            Get
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                Return MyCmd.CmdSelect2(TableSubscribed, eSubscribedFieldName.topic.ToString, 0, MyCriteria, , MyAppConnectionString)
            End Get
            Set(value As String)
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                MyCmd.CmdUpdate3(TableSubscribed, eSubscribedFieldName.topic.ToString, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Url for the XML file
        ''' </summary>
        Public Shared Property RssUrl(SubscriptionId As Integer, MyAppConnectionString As String) As String
            Get
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                Return MyCmd.CmdSelect2(TableSubscribed, eSubscribedFieldName.rss_url.ToString, 0, MyCriteria, , MyAppConnectionString)
            End Get
            Set(value As String)
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                MyCmd.CmdUpdate3(TableSubscribed, eSubscribedFieldName.rss_url.ToString, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Shared Property LastUpdated(SubscriptionId As Integer, MyAppConnectionString As String) As String
            Get
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)

                Dim MyStr As String = MyCmd.CmdSelect2(TableSubscribed, eSubscribedFieldName.lastUpdated.ToString, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, SubscriptionId)
                MyCmd.CmdUpdate3(TableSubscribed, eSubscribedFieldName.lastUpdated.ToString, FieldValue(CDate(value)), MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Shared Property XmlEnabled(id As Integer, MyAppConnectionString As String) As Boolean
            Get
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, id)
                Return MyCmd.CmdSelectBool(TableSubscribed, eSubscribedFieldName.enabled.ToString, 0, MyCriteria, , MyAppConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyCriteria As String = Criteria(eSubscribedFieldName.id.ToString, id)
                MyCmd.CmdUpdate3(TableSubscribed, eSubscribedFieldName.enabled.ToString, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        Public Shared Function SubscribedCount(BranchId As Integer, MyAppConnectionString As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eSubscribedFieldName.branchId.ToString, BranchId), _
                Criteria(eSubscribedFieldName.enabled.ToString, True) _
                )

            Dim MyStr As String = MyCmd.CmdCount(TableSubscribed, MyCriteria, MyAppConnectionString)

            Dim ReturnValue As Integer = 0
            If IsNumeric(MyStr) Then ReturnValue = CInt(MyStr)

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Get subscription list as DataTable.
        ''' 4 columns (id, topic, rss_url, lastUpdated)
        ''' </summary>
        ''' <param name="BranchId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function SubscribedTable(BranchId As Integer, MyAppConnectionString As String) As System.Data.DataTable
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eSubscribedFieldName.branchId.ToString, BranchId), _
                Criteria(eSubscribedFieldName.enabled.ToString, True) _
                )

            Dim MyFields As String = FieldNames(eSubscribedFieldName.id.ToString, eSubscribedFieldName.topic.ToString, eSubscribedFieldName.rss_url.ToString, eSubscribedFieldName.lastUpdated.ToString)

            Return MyCmd.CmdSelectTable(TableSubscribed, MyFields, MyCriteria, , MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get count of Rss cached by subscription Id
        ''' </summary>
        Public Shared Function GetCacheCount(SubscriptiodId As Integer, MyAppConnectionString As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eRssItemFieldName.subId.ToString, SubscriptiodId) _
                )

            Dim MyStr As String = MyCmd.CmdCount(TableRssItems, MyCriteria, MyAppConnectionString)

            Dim ReturnValue As Integer = 0
            If IsNumeric(MyStr) Then ReturnValue = CInt(MyStr)

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Get Cached Rss Items for a Branch order by latest date as Datatable
        ''' 3 columns (title, link, pubDate)
        ''' </summary>
        Public Shared Function GetRssCacheTableByBranch(BranchId As Integer, MyAppConnectionString As String) As System.Data.DataTable
            Dim MyCriteria As String = Criteria(eRssItemFieldName.branchId.ToString, BranchId)
            Dim MyFields As String = FieldNames(eRssItemFieldName.title.ToString, eRssItemFieldName.link.ToString, eRssItemFieldName.pubDate.ToString)
            Dim MyOrderBy As String = OrderBy(eRssItemFieldName.pubDate.ToString, False)

            Return MyCmd.CmdSelectTable(TableRssItems, MyFields, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get Cached Rss Items for a Branch order by latest date as Datatable.
        ''' Title and link is encoded. please decode
        ''' 3 columns (title, link, pubDate)
        ''' </summary>
        Public Shared Function GetRssCacheTableByBranch(BranchId As Integer, MaxItem As Integer, MyAppConnectionString As String) As System.Data.DataTable
            Dim MyCriteria As String = Criteria(eRssItemFieldName.branchId.ToString, BranchId)
            Dim MyFields As String = FieldNames(eRssItemFieldName.title.ToString, eRssItemFieldName.link.ToString, eRssItemFieldName.pubDate.ToString)
            Dim MyOrderBy As String = OrderByLimit(eRssItemFieldName.pubDate.ToString, False, MaxItem)

            Return MyCmd.CmdSelectTable(TableRssItems, MyFields, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get Cached Rss Items for a Subscription ID as Datatable.
        ''' 3 columns (title, link, pubDate)
        ''' Title and link is encoded. please decode
        ''' </summary>
        Public Shared Function GetRssCacheTableBySubscribed(SubscribedId As Integer, MyAppConnectionString As String) As System.Data.DataTable
            Dim MyCriteria As String = Criteria(eRssItemFieldName.subId.ToString, SubscribedId)
            Dim MyFields As String = FieldNames(eRssItemFieldName.title.ToString, eRssItemFieldName.link.ToString, eRssItemFieldName.pubDate.ToString)
            Dim MyOrderBy As String = OrderBy(eRssItemFieldName.pubDate.ToString, False)

            Return MyCmd.CmdSelectTable(TableRssItems, MyFields, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Cache Rss into database for specified branch
        ''' Title and link is encoded. please decode later
        ''' </summary>
        Public Shared Sub AddRssIntoCache(BranchId As Integer, SubscriptionId As Integer, RssURL As String, MyAppConnectionString As String)

            Dim MyFieldsName As String = FieldNames( _
                eRssItemFieldName.branchId.ToString, _
                eRssItemFieldName.subId.ToString, _
                eRssItemFieldName.title.ToString, _
                eRssItemFieldName.link.ToString, _
                eRssItemFieldName.pubDate.ToString _
                )

            Dim RssTable As System.Data.DataTable = RssToDataTable(RssURL)

            If RssTable.Rows.Count = 0 Then Exit Sub

            For i As Integer = 0 To RssTable.Rows.Count - 1

                Dim pubDate As String = RssTable(i)("pubDate")

                pubDate = NasLib.Functions.Dates.Correction.RssToMySql(pubDate)


                Dim MyFieldsValue As String = FieldValues(
                    FieldValue(BranchId),
                    FieldValue(SubscriptionId),
                    NasLib.Functions.Web.Html.Encode(FieldValue(RssTable(i)("title"))),
                    NasLib.Functions.Web.Url.Encode(FieldValue(RssTable(i)("link"))),
                    FieldValue(CDate(pubDate))
                    )

                MyCmd.CmdInsert2(TableRssItems, MyFieldsName, MyFieldsValue, MyAppConnectionString)
            Next

            RssTable.Dispose()

        End Sub

        ''' <summary>
        ''' Clear cached RSS items from database by branch
        ''' </summary>
        Public Shared Sub ClearRssCachedByBranch(BranchId As Integer, MyAppConnectionString As String)
            Dim MyCriteria As String = Criteria(eRssItemFieldName.branchId.ToString, BranchId)

            MyCmd.CmdDelete(TableRssItems, MyCriteria, MyAppConnectionString)
        End Sub

        ''' <summary>
        ''' Clear cached RSS items from database by SubscribedId
        ''' </summary>
        Public Shared Sub ClearRssCachedBySubscribed(Subscribedid As Integer, MyAppConnectionString As String)
            Dim MyCriteria As String = Criteria(eRssItemFieldName.subId.ToString, Subscribedid)

            MyCmd.CmdDelete(TableRssItems, MyCriteria, MyAppConnectionString)
        End Sub

#End Region

#Region "Rss Setting in database"

        ''' <summary>
        ''' Maximum number of Rss items to view
        ''' </summary>
        Public Shared Property RssMaxView As Integer
            Get
                Return NasLib.Config.SQLite.Configuration.CustomKey("rss_max_view")
            End Get
            Set(value As Integer)
                NasLib.Config.SQLite.Configuration.CustomKey("rss_max_view") = value
            End Set
        End Property

        ''' <summary>
        ''' Rss will be refetched after specified time. (in minutes)
        ''' </summary>
        ''' <value>Value in Minutes</value>
        Public Shared Property RssCacheExpired As Integer
            Get
                Return NasLib.Config.SQLite.Configuration.CustomKey("rss_cache_expired")
            End Get
            Set(value As Integer)
                NasLib.Config.SQLite.Configuration.CustomKey("rss_cache_expired") = value
            End Set
        End Property

#End Region


    End Class

End Namespace


