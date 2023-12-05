Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.Profile

    Public Class Container
        Inherits System.Web.UI.UserControl

        Public Property StaffId As String
            Get
                Return gStaffId.Text
            End Get
            Set(value As String)
                gStaffId.Text = value
                LoadStaffData()
            End Set
        End Property

        Private Sub LoadStaffData()
            lblName.Text = LineBreaker(Table.UsersProfile.FullName(StaffId, ProvidersConnectionString))
            lblPosition.Text = LineBreaker(Table.UsersProfile.PositionName(StaffId, ProvidersConnectionString))
            lblDepartment.Text = LineBreaker(Table.UsersProfile.DepartmentName(StaffId, ProvidersConnectionString))
            lblDivision.Text = LineBreaker(Table.UsersProfile.DivisionName(StaffId, ProvidersConnectionString))
            lblUnit.Text = LineBreaker(Table.UsersProfile.UnitName(StaffId, ProvidersConnectionString))
            lblEmail.Text = EmailBreaker(Table.Membership.Email(StaffId, ProvidersConnectionString))
            lblPhone.Text = PhoneBreaker(Table.UsersProfile.Phone(StaffId, ProvidersConnectionString))

            Dim ImageURL As String = PicProviderLink & "?patronid=" & StaffId

            'If NasLib.Functions.Web.Url.IsURLExist(NasLib.Functions.Web.Url.RelativeToAbsolute(ImageURL, Page)) Then Image1.ImageUrl = ImageURL
            Image1.ImageUrl = ImageURL
        End Sub

        Private Function LineBreaker(Str As String) As String
            If String.IsNullOrEmpty(Str) Then Str = ""

            If Str.Length > 0 Then Str = Str & "<br />"
            Return Str
        End Function

        Private Function EmailBreaker(Str As String) As String
            If String.IsNullOrEmpty(Str) Then Str = ""

            If Str.Length > 0 Then Str = "<span class='icon-mail'></span> " & Str & "<br />"
            Return Str
        End Function

        Private Function PhoneBreaker(Str As String) As String
            If String.IsNullOrEmpty(Str) Then Str = ""

            If Str.Length > 0 Then Str = "<span class='icon-phone'></span> " & Str
            Return Str
        End Function


    End Class

End Namespace

