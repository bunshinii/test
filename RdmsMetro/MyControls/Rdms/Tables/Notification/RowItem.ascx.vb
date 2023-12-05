Namespace MyControls.Rdms.Tables.Notification

    Public Class RowItem
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property NoteId As Integer
            Get
                Return gNoteId.Text
            End Get
            Set(value As Integer)
                gNoteId.Text = value
            End Set
        End Property

        Public Property No As Integer
            Get
                Return lblNo.Text
            End Get
            Set(value As Integer)
                lblNo.Text = value
            End Set
        End Property

        Public Property NoteTitle As String
            Get
                Return lblTitle.Text
            End Get
            Set(value As String)
                lblTitle.Text = value
            End Set
        End Property

        Public Property NoteMessage As String
            Get
                Return lblMessage.Text
            End Get
            Set(value As String)
                lblMessage.Text = value
            End Set
        End Property

        Public Property NoteDate As String
            Get
                
                Return lblDate.Text
            End Get
            Set(value As String)
                Dim ReturnValue As String = ""
                If IsDate(value) Then ReturnValue = Format(CDate(value), "dd-MM-yyyy HH:mm:ss")
                lblDate.Text = ReturnValue
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Private Sub btnRead_ServerClick(sender As Object, e As EventArgs) Handles btnRead.ServerClick
            MyModules.Database.Notification.IsRead(NoteId) = True
            PanelContent.Visible = False
        End Sub
    End Class

End Namespace

