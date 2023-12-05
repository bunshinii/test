Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.MetroUI

    Public Class Header
        Inherits System.Web.UI.UserControl

        Private ReadOnly Property SatelliteInit As String
            Get
                Dim ReturnValue As String = ""

                If Page.User.Identity.IsAuthenticated Then
                    ReturnValue = NasLib.Functions.Web.CurrentUser.SatelliteInitial
                Else
                    ReturnValue = MyRequest.GetSatInit
                End If

                Return ReturnValue
            End Get
        End Property

        Private Sub LoadProfilePicture()
            Dim OfficerId As String = Page.User.Identity.Name
            Image1.ImageUrl = PicProviderLink(OfficerId)
            lblFullname.Text = NasLib.Functions.Web.CurrentUser.Fullname
        End Sub


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim Sat As String = SatelliteInit

            'Calendar Menu Visibility
            If Sat.Length > 0 Then
                'hlToday.NavigateUrl = "~/Pages/Duty/Today.aspx?sat=" & Sat
                'hlMonth.NavigateUrl = "~/Pages/Duty/Calendar.aspx?sat=" & Sat
                hlToday.NavigateUrl = MyResponse.Url("~/Pages/Duty/OnDate.aspx", MyRequest._SatelliteInitial, Sat)
                hlMonth.NavigateUrl = MyResponse.Url("~/Pages/Duty/Calendar.aspx", MyRequest._SatelliteInitial, Sat)
            Else
                hlToday.NavigateUrl = "~/"
                hlMonth.NavigateUrl = "~/"
            End If

            'Profile Picture
            If Page.User.Identity.IsAuthenticated Then
                PanelUser.Visible = True
                LoadProfilePicture()
            Else
                PanelUser.Visible = False
            End If

        End Sub

    End Class

End Namespace