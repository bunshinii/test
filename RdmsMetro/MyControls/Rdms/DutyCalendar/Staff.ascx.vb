Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.DutyCalendar

    Public Class Staff
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

        Public Property ButtonVisible As Boolean
            Get
                Return gButtonVisible.Checked
            End Get
            Set(value As Boolean)
                gButtonVisible.Checked = value
            End Set
        End Property

        ''' <summary>
        ''' Must put value on DutyId first before putting on this value. to enable DELETE button.
        ''' Dont forget to set the VirtualPath and QueryString.
        ''' Simply put this function LAST.
        ''' </summary>
        Public Property DutyTypeId As Integer
            Get
                Return gDutyTypeId.Text
            End Get
            Set(value As Integer)

                gDutyTypeId.Text = value

                Dim MyControl As MyControls.Rdms.DutyCalendar.DutyLegend = LoadControl("~\MyControls\Rdms\DutyCalendar\DutyLegend.ascx")

                MyControl.Text = MyModules.Database.DutyType.DutyTypeName(value)
                MyControl.ToolTip = MyModules.Database.DutyType.DutyNote(value)
                MyControl.BgColor = MyModules.Database.DutyType.BackgroundColor(value)
                MyControl.FgColor = MyModules.Database.DutyType.ForeColor(value)

                'Only Run this if admin
                If Page.User.IsInRole("Administrator") Then
                    MyControl.DutyId = DutyId
                    MyControl.VirtualPathRemoveButton = VirtualPathRemoveButton
                    MyControl.QueryStringRemoveButton = QueryStringRemoveButton
                End If

                MyControl.ButtonVisible = ButtonVisible

                phLegend.Controls.Add(MyControl)

            End Set
        End Property

#Region "Remove Button"

        Public ReadOnly Property VirtualPathRemoveStaff As String
            Get
                Dim ReturnValue As String = "#"
                If DutyId > 0 And QueryStringRemoveButton.Length > 0 Then
                    ReturnValue = VirtualPathRemoveButton & "?" & QueryStringRemoveButton
                End If

                Return ReturnValue
            End Get
        End Property

        Public Property VirtualPathRemoveButton As String
            Get
                Return gVirtualPathRemoveButton.Text
            End Get
            Set(value As String)
                gVirtualPathRemoveButton.Text = value
            End Set
        End Property

        Public Property QueryStringRemoveButton As String
            Get
                Return gQueryStringRemoveButton.Text
            End Get
            Set(value As String)
                gQueryStringRemoveButton.Text = value
            End Set
        End Property

        Public Property DutyId As Integer
            Get
                Return gDutyId.Text
            End Get
            Set(value As Integer)
                gDutyId.Text = value
            End Set
        End Property

#End Region

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

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

