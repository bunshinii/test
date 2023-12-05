Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Notification
    Inherits System.Web.UI.UserControl

#Region "Panel Properties"

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


#Region "Functions"

    Private Sub LoadPanelData()

        'id, recieverId, messageTitle, messageText, messageDate
        Dim NoteTable As DataTable = MyModules.Database.Notification.GetAllNotes(MyRequest.OwnerId)
        Dim NoteCount As Integer = NoteTable.Rows.Count
        StatusText = String.Format("You have {0} notification(s)", NoteCount)
        ShowCountInt = NoteCount
        If NoteCount > 0 Then
            For i As Integer = 0 To NoteCount - 1
                Dim MyControl As MyControls.Rdms.User.DutyRequest.DutyItem = LoadControl("~/MyControls/Rdms/User/DutyRequest/DutyItem.ascx")

                'MyControl.TheDate = NoteTable(i)("duty_date")
                'MyControl.PatronId = NoteTable(i)("senderId")
                'MyControl.DutyId = NoteTable(i)("dutyId")
                'phRequestRec.Controls.Add(MyControl)
            Next

        Else
            PanelContentItem.Visible = False
            PanelCollapse = True
        End If

        NoteTable.Dispose()
    End Sub


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPanelData()
    End Sub

End Class