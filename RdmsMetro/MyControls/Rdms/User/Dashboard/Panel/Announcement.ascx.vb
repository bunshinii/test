Namespace MyControls.Rdms.User.Dashboard.Panel

    Public Class Announcement1
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

        Private Sub LoadAnnouncement()
            Dim BranchId As Integer = NasLib.Database.MySql.Provider.Table.UsersProfile.BranchId(MyOwnId, ProvidersConnectionString)
            Branch1.BranchId = BranchId

            Dim SatId As Integer = NasLib.Database.MySql.Provider.Table.UsersProfile.SatelliteId(MyOwnId, ProvidersConnectionString)
            Satellite1.SatelliteId = SatId

        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadAnnouncement()

            Dim LetterCount As Integer = Satellite1.LetterCount + Branch1.LetterCount

            If LetterCount > 0 Then
                PanelCollapse = False
                StatusText = "You have an Announcement"
            Else
                PanelCollapse = True
                StatusText = "No Announcement"
            End If



        End Sub

    End Class

End Namespace

