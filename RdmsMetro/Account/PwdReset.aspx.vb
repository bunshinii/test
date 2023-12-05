Public Class PwdReset
    Inherits System.Web.UI.Page


    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim Username As String = txtPatronId.Text.Trim

        If Username.Length > 0 Then

            Dim PatronIc As String = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronIc(Username, DbLibraryConnectionString)
            If Not String.IsNullOrEmpty(PatronIc) Then
                Dim PatronName As String = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronName(Username, DbLibraryConnectionString)
                Dim UserId As Integer = NasLib.Database.MySql.Provider.Table.Users.UserId(Username, ProvidersConnectionString)
                NasLib.Database.MySql.Provider.Table.Membership.Password(UserId, ProvidersConnectionString) = PatronIc

                lblMessage.Text = $"The user {Username} : {PatronName}'s password has been reset to IC : {PatronIc}"
                lblMessage.ForeColor = Drawing.Color.DarkGreen
            Else
                lblMessage.Text = $"The user {Username} does not existed"
                lblMessage.ForeColor = Drawing.Color.Red
            End If

        Else
            lblMessage.Text = $"Please enter Staff ID"
            lblMessage.ForeColor = Drawing.Color.Red

        End If

    End Sub
End Class