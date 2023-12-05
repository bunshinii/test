Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Login

    Public Class Register
        Inherits System.Web.UI.UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim MyVirtualPath As String = HyperLink1.NavigateUrl
                HyperLink1.NavigateUrl = MyResponse.Url(MyVirtualPath, MyRequest._SatelliteInitial, MyRequest.GetSatInit)
            End If

        End Sub

    End Class

End Namespace

