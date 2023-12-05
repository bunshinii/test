Namespace MyControls.Rdms.Login

    Public Class Small
        Inherits System.Web.UI.UserControl

        Private Sub Small_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim LoginButtonID As String = Login1.UniqueID & "$LoginButton"
            Panel1.DefaultButton = LoginButtonID
        End Sub
    End Class

End Namespace

