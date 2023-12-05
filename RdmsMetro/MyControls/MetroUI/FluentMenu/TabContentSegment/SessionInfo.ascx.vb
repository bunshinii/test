Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class SessionInfo
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property SessionId As String
            Get
                Return lblSessionId.Text
            End Get
            Set(value As String)
                lblSessionId.Text = value
            End Set
        End Property

        Public Property TimeStart As String
            Get
                Return lblTimeStart.Text
            End Get
            Set(value As String)
                lblTimeStart.Text = value
            End Set
        End Property

        Public Property TimeEnd As String
            Get
                Return lblTimeEnd.Text
            End Get
            Set(value As String)
                lblTimeEnd.Text = value
            End Set
        End Property

        Public Property Duration As String
            Get
                Return lblDuration.Text
            End Get
            Set(value As String)
                lblDuration.Text = value
            End Set
        End Property


#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                TimeStart = Format(Now, "dd MMM yyyy HH:mm:ss")
                TimeEnd = Format(Now, "dd MMM yyyy HH:mm:ss")
            Else
                TimeEnd = Format(Now, "dd MMM yyyy HH:mm:ss")
            End If

            Dim StartDate As Date = TimeStart
            Dim EndDate As Date = TimeEnd

            Duration = EndDate.Subtract(StartDate).ToString
        End Sub

        Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

            
        End Sub
    End Class

End Namespace

