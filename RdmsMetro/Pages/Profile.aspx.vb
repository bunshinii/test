Public Class Profile
    Inherits System.Web.UI.Page

    Private Function StaffId() As String
        Dim EncryptedStaffId As String = Request("id") 'Jangan Kaco

        Dim ReturnValue As String = ""
        If Not String.IsNullOrEmpty(EncryptedStaffId) Then
            ReturnValue = NasLib.Functions.Security.Cryptography.AesDecrypt(EncryptedStaffId)
        End If

        Return ReturnValue
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Container1.StaffId = StaffId()
    End Sub

End Class