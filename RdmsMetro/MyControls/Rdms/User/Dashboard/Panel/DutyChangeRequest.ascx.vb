Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.User.Dashboard.Panel

    Public Class DutyChangeRequest
        Inherits System.Web.UI.UserControl


#Region "Static Panel Properties"

#Region "Count Show"

        Public Property ShowCountStr As String
            Get
                Dim ReturnValue As String = ""
                Dim MyCount As Integer = ShowCountInt

                If MyCount > 0 Then ReturnValue = String.Format("({0})", ShowCountInt)
                Return ReturnValue
            End Get
            Set(value As String)
                gCount.Text = value
            End Set
        End Property

        Public Property ShowCountInt As Integer
            Get
                Return gCount.Text
            End Get
            Set(value As Integer)
                gCount.Text = value
            End Set
        End Property

#End Region

#Region "Panel Behavior"

        ''' <summary>
        ''' Just use this code rather than the others.
        ''' True = Collapse.
        ''' False = Uncollapse.
        ''' </summary>
        Public WriteOnly Property PanelCollapse As Boolean
            Set(value As Boolean)
                If value Then
                    gPanelCollapse.Text = "collapsed"
                    gPanelCollapseDisplayNone.Text = "style=""display: none;"""
                Else
                    gPanelCollapse.Text = ""
                    gPanelCollapseDisplayNone.Text = ""
                End If
            End Set
        End Property

        ''' <summary>
        ''' Please use PanelCollapse property above to set collapse status.
        ''' This function is for inline code only.
        ''' </summary>
        Public ReadOnly Property PanelCollapse_ As String
            Get
                Return gPanelCollapse.Text
            End Get
        End Property

        ''' <summary>
        ''' Please use PanelCollapse property above to set collapse status.
        ''' This function is for inline code only.
        ''' </summary>
        Public ReadOnly Property PanelCollapseDisplayNone_ As String
            Get
                Return gPanelCollapseDisplayNone.Text
            End Get
        End Property

#End Region

        Public Property StatusText As String
            Get
                Return lblStatus.Text
            End Get
            Set(value As String)
                lblStatus.Text = value
            End Set
        End Property

#End Region

#Region "Custom Functions"

        Private Sub LoadPanelData()
            DutyChangeLegend()

            'id, dutyId, senderId, receiverId, req_date, duty_date, accepted, rejected
            Dim DutyReqTable As DataTable = MyModules.Database.DutyRequest.GetAllRequestReceivedFuture(MyRequest.OwnerId)
            Dim DutyReqCount As Integer = DutyReqTable.Rows.Count
            ShowCountInt = DutyReqCount
            StatusText = String.Format("You have {0} request", DutyReqCount)
            If DutyReqCount > 0 Then
                For i As Integer = 0 To DutyReqCount - 1
                    Dim MyControl As MyControls.Rdms.User.DutyRequest.DutyItem = LoadControl("~/MyControls/Rdms/User/DutyRequest/DutyItem.ascx")

                    MyControl.TheDate = DutyReqTable(i)("duty_date")
                    MyControl.PatronId = DutyReqTable(i)("senderId")
                    MyControl.DutyId = DutyReqTable(i)("dutyId")
                    phRequestRec.Controls.Add(MyControl)
                Next

            Else
                PanelContentItem.Visible = False

                PanelCollapse = True

            End If

            DutyReqTable.Dispose()
        End Sub

        Private Sub DutyChangeLegend()

            'id, duty_type, note, bgColor, foreColor
            Dim DutyLegend As DataTable = MyModules.Database.DutyType.GetAllDutyTypes()
            Dim DutyLegendCount As Integer = DutyLegend.Rows.Count

            If DutyLegendCount > 0 Then
                For i As Integer = 0 To DutyLegendCount - 1
                    Dim MyControls As MyControls.Rdms.User.DutyRequest.Legend = LoadControl("~\MyControls\Rdms\User\DutyRequest\Legend.ascx")
                    MyControls.DutyName = DutyLegend(i)("duty_type")
                    MyControls.DutyTooltip = DutyLegend(i)("note")
                    MyControls.BackGroundColor = DutyLegend(i)("bgColor")
                    MyControls.ForeGroundColor = DutyLegend(i)("foreColor")

                    phDutyType.Controls.Add(MyControls)
                Next

            End If

            DutyLegend.Dispose()

        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadPanelData()
        End Sub

    End Class

End Namespace

