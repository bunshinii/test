Namespace MyControls.MetroUI.Buttons.Breadcrumbs

    Public Class Breadcrumb
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        ''' <summary>
        ''' Item Names seperated by comma.
        ''' The number of NameArray and UrlArray must match.
        ''' </summary>
        Public Property NameArray As String
            Get
                Return gNameArray.Text
            End Get
            Set(value As String)
                gNameArray.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Item Links seperated by comma.
        ''' The number of NameArray and UrlArray must match.
        ''' </summary>
        Public Property UrlArray As String
            Get
                Return gUrlArray.Text
            End Get
            Set(value As String)
                gUrlArray.Text = value
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim MyNames() As String = NameArray.Trim.Split(",")
            Dim MyUrls() As String = UrlArray.Trim.Split(",")


            If MyNames.Count > 0 Then

                For i As Integer = 0 To MyNames.Count - 1
                    Dim MyControl As MyControls.MetroUI.Buttons.Breadcrumbs.Item = LoadControl("~\MyControls\MetroUI\Buttons\Breadcrumbs\Item.ascx")
                    MyControl.Text = MyNames(i)
                    If i = MyNames.Count - 1 Then MyControl.IsActive = True
                    If i < MyUrls.Count Then MyControl.NavigateUrl = MyUrls(i)
                    phItem.Controls.Add(MyControl)
                Next

            End If

        End Sub

    End Class

End Namespace

