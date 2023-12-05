Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Announcement

    Public Class Satellite
        Inherits System.Web.UI.UserControl

        Public Property SatelliteId As Integer
            Get
                Return gSatId.Text
            End Get
            Set(value As Integer)
                gSatId.Text = value

                If SatelliteId > 0 Then
                    Label1.Text = MyModules.Announcement.GetAnnouncement(SatelliteId, MyModules.Announcement.broadcastTo.satellite)
                    If Label1.Text.Length > 1 Then Label1.Text = String.Format("<p>{0}</p>", Label1.Text)
                End If
            End Set
        End Property

        Public ReadOnly Property Text As String
            Get
                Return Label1.Text.Trim
            End Get
        End Property

        Public ReadOnly Property LetterCount As Integer
            Get
                Return Label1.Text.Trim.Length
            End Get
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            
        End Sub

    End Class

End Namespace

