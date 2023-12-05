Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Announcement

    Public Class Branch
        Inherits System.Web.UI.UserControl


        Public Property BranchId As Integer
            Get
                Return gBranchId.Text
            End Get
            Set(value As Integer)
                gBranchId.Text = value

                If BranchId > 0 Then
                    Label1.Text = MyModules.Announcement.GetAnnouncement(BranchId, MyModules.Announcement.broadcastTo.branch)
                    If Label1.Text.Length > 1 Then Label1.Text = String.Format("<p>{0}</p>", Label1.Text)
                End If
            End Set
        End Property

        Public ReadOnly Property Text As String
            Get
                Return Label1.Text
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

