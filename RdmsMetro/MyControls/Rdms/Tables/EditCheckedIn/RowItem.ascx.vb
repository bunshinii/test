Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Tables.EditCheckedIn

    Public Class RowItem
        Inherits System.Web.UI.UserControl

        Public Property No As Integer
            Get
                Return lblNo.Text
            End Get
            Set(value As Integer)
                lblNo.Text = value
            End Set
        End Property

        Private Property Fullname As String
            Get
                Return hlFullname.Text
            End Get
            Set(value As String)
                hlFullname.Text = value
                hlFullname.ToolTip = value
            End Set
        End Property

        Public Property PatronId As String
            Get
                Return lblPatronid.Text
            End Get
            Set(value As String)
                lblPatronid.Text = value

                Dim Fullname_ As String = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronName(value, DbLibraryConnectionString)

                If String.IsNullOrEmpty(Fullname_) Then
                    Dim IsCustom As Boolean = MyModules.Database.CustomPatron.IsExisted(value)
                    If IsCustom Then Fullname = MyModules.Database.CustomPatron.Fullname(value)
                Else
                    Fullname = Fullname_
                End If


            End Set
        End Property

        Public Property SessionId As String
            Get
                Return gSessionId.Text
            End Get
            Set(value As String)
                gSessionId.Text = value

                Dim VirtualPath As String = "~/Pages/User/EditQuestion.aspx"
                Dim MyUrl As String = Nothing


                Dim IsCustom As Boolean = MyModules.Database.CustomPatron.IsExisted(PatronId)
                If IsCustom Then
                    MyUrl = MyResponse.Url(VirtualPath, MyRequest._SessionId, value)
                Else
                    MyUrl = MyResponse.Url(VirtualPath, {MyRequest._PatronId, MyRequest._SessionId}, {PatronId, value})
                End If

                'hlFullname.NavigateUrl = String.Format("~/Pages/User/EditQuestion.aspx?sessionid={0}&patronid={1}", value, PatronId)
                hlFullname.NavigateUrl = MyUrl


            End Set
        End Property

        Public Property MediumId As Integer
            Get
                Return gMediumId.Text
            End Get
            Set(value As Integer)
                gMediumId.Text = value
                lblMedium.Text = MyModules.Database.RdmsMedium.MediumName(value)
            End Set
        End Property

        Public Property TheDate As Date
            Get
                Return lblDate.Text
            End Get
            Set(value As Date)
                lblDate.Text = Format(value, "dd MMM yyyy HH:mm:ss")
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

