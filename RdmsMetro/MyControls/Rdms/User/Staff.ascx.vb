Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.User

    Public Class Staff
        Inherits System.Web.UI.UserControl

#Region "Control Requirements"

        ''Must add CSS Link on the page
        ''<link href="<%=ResolveUrl("~/Content/DutyCalendar.min.css")%>" rel="stylesheet" />

#End Region



#Region "Public Properties"

        Public Property StaffId As String
            Get
                Return gStaffId.Text
            End Get
            Set(value As String)
                gStaffId.Text = value
                LoadStaffData()
            End Set
        End Property

        Public Property Link As String
            Get
                Return alink.HRef
            End Get
            Set(value As String)
                alink.HRef = value
            End Set
        End Property

        Public WriteOnly Property DutyTypeId As Integer
            Set(value As Integer)
                Dim MyControl As MyControls.Rdms.User.DutyLegend = LoadControl("~\MyControls\Rdms\User\DutyLegend.ascx")
                MyControl.Text = MyModules.Database.DutyType.DutyTypeName(value)
                MyControl.ToolTip = MyModules.Database.DutyType.DutyNote(value)
                MyControl.BgColor = MyModules.Database.DutyType.BackgroundColor(value)
                MyControl.FgColor = MyModules.Database.DutyType.ForeColor(value)
                phLegend.Controls.Add(MyControl)
            End Set
        End Property

#End Region

#Region "Functions"

        Private Sub LoadStaffData()
            lblName.Text = LineBreaker(Table.UsersProfile.FullName(StaffId, ProvidersConnectionString))
            lblPosition.Text = LineBreaker(Table.UsersProfile.PositionName(StaffId, ProvidersConnectionString))
            lblDepartment.Text = LineBreaker(Table.UsersProfile.DepartmentName(StaffId, ProvidersConnectionString))
            lblDivision.Text = LineBreaker(Table.UsersProfile.DivisionName(StaffId, ProvidersConnectionString))
            lblEmail.Text = EmailBreaker(Table.Membership.Email(StaffId, ProvidersConnectionString))
            lblPhone.Text = PhoneBreaker(Table.UsersProfile.Phone(StaffId, ProvidersConnectionString))

            Dim ImageURL As String = PicProviderLink(StaffId)

            Image1.ImageUrl = ImageURL

            Dim EncryptedStaffId As String = NasLib.Functions.Security.Cryptography.AesEncrypt(StaffId)
            alink.HRef = ResolveUrl("~/Pages/Profile.aspx?id=" & Server.UrlEncode(EncryptedStaffId))
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

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

