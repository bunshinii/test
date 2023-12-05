Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Functions.Web.QueryString

Namespace MyControls.Rdms.Admin.UserSearchDBLibrary

    Public Class Item
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

#Region "Virtual Path"

        ''' <summary>
        ''' Link for this button to redirect.
        ''' </summary>
        Public ReadOnly Property AbsolutePath As String
            Get
                MyRequest.GetDate()
                Dim MyQueryString As String = QueryString
                ModifyQueryStringValue(QueryString, MyRequest._PatronId, PatronId)

                Return ResolveUrl(VirtualPath & "?" & QueryString)
            End Get
        End Property

        ''' <summary>
        ''' VirtualPath for this button to redirect
        ''' </summary>
        Public Property VirtualPath As String
            Get
                Return gVirtualPath.Text
            End Get
            Set(value As String)
                gVirtualPath.Text = value
            End Set
        End Property

        Public Property QueryString As String
            Get
                Return gQueryString.Text
            End Get
            Set(value As String)
                gQueryString.Text = value
            End Set
        End Property

#End Region

#Region "Color"

        Public Property BackgroundColor As String
            Get
                Return gBgColor.Text
            End Get
            Set(value As String)
                gBgColor.Text = value
            End Set
        End Property

#End Region

#Region "Normal"

        Public Property PatronId As String
            Get
                Return lblPatronId.Text
            End Get
            Set(value As String)
                lblPatronId.Text = value
            End Set
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

        Public Property ToolTip As String
            Get
                Return gToolTip.Text
            End Get
            Set(value As String)
                gToolTip.Text = value
            End Set
        End Property

#End Region

#End Region


        

        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Image1.ImageUrl = PicProviderLink(PatronId)
        End Sub
    End Class

End Namespace

