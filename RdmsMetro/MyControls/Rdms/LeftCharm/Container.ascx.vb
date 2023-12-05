Imports NasLib.Functions.Web.CurrentUser

Namespace MyControls.Rdms.LeftCharm

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Load PlaceHolders"

        Private Sub LoadLoginForm()
            Dim LoginForm As MyControls.Rdms.Login.Small = LoadControl("~\MyControls\Rdms\Login\Small.ascx")
            phLogin.Controls.Add(LoginForm)
        End Sub

        Private Sub LoadRegisterLink()
            Dim RegisterLink As MyControls.Rdms.Login.Register = LoadControl("~\MyControls\Rdms\Login\Register.ascx")
            phLogin.Controls.Add(RegisterLink)
        End Sub

        Private Sub LoadLoggedInPanel()
            Dim UserMenu As MyControls.Rdms.LeftCharm.UserMenu = LoadControl("~\MyControls\Rdms\LeftCharm\UserMenu.ascx")
            phMenu.Controls.Add(UserMenu)
        End Sub

        Private Sub LoadAdminPanel()
            Dim AdminMenu As MyControls.Rdms.LeftCharm.AdminMenu = LoadControl("~\MyControls\Rdms\LeftCharm\AdminMenu.ascx")
            phMenu.Controls.Add(AdminMenu)
        End Sub

#End Region


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsAuthenticated() Then
                LoadLoginForm()
                LoadRegisterLink()
            Else
                LoadLoggedInPanel()
            End If

            If IsInRole("Administrator") Or IsInRole("Moderator") Then LoadAdminPanel()

        End Sub

    End Class

End Namespace

