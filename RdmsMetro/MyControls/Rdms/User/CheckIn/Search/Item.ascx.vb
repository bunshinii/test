Namespace MyControls.Rdms.User.CheckIn.Search

    Public Class Item
        Inherits System.Web.UI.UserControl

        Public Property PatronId As String
            Get
                Return lblPatronId.Text
            End Get
            Set(value As String)
                lblPatronId.Text = value
            End Set
        End Property

        Public ReadOnly Property NewSessionId As String
            Get
                Return NasLib.Functions.String.Guids.NewStringGuid
            End Get
        End Property

        Public Property PatronName As String
            Get
                Return lblName.Text
            End Get
            Set(value As String)
                lblName.Text = value
            End Set
        End Property

        Public Property Faculty As String
            Get
                Return lblFaculty.Text
            End Get
            Set(value As String)
                lblFaculty.Text = value
            End Set
        End Property

        Public Property Program As String
            Get
                Return lblProgram.Text
            End Get
            Set(value As String)
                lblProgram.Text = value
            End Set
        End Property


        Public Property BackgroundColor As String
            Get
                Return gBgColor.Text
            End Get
            Set(value As String)
                gBgColor.Text = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return gToolTip.Text
            End Get
            Set(value As String)
                gToolTip.Text = value
            End Set
        End Property

        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Image1.ImageUrl = PicProviderLink(PatronId)
        End Sub
    End Class

End Namespace

