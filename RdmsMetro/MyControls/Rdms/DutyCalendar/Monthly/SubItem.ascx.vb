Namespace MyControls.Rdms.DutyCalendar.Monthly

    Public Class SubItem
        Inherits System.Web.UI.UserControl

        Public Property StaffId As String
            Get
                Return lblStaffId.Text
            End Get
            Set(value As String)
                lblStaffId.Text = value
                LoadData(value)
            End Set
        End Property

        Public WriteOnly Property DutyType As String
            Set(DutyType_ As String)
                hlName.ToolTip = DutyType_ & " : " & hlName.ToolTip
            End Set
        End Property

        Public ReadOnly Property Colors As String
            Get
                Return String.Format(" {0} {1}", ForeColor, BackColor)
            End Get
        End Property

        Public Property ForeColor As String
            Get
                Return gForegroundColor.Text
            End Get
            Set(value As String)
                gForegroundColor.Text = value
            End Set
        End Property

        Public Property BackColor As String
            Get
                Return gBackgroundColor.Text
            End Get
            Set(value As String)
                gBackgroundColor.Text = value
            End Set
        End Property


        Private Sub LoadData(StaffId As String)
            Dim Fullname As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(StaffId, ProvidersConnectionString)
            Dim Nick As String = NasLib.Database.MySql.Provider.Table.UsersProfile.NickOrFullname(StaffId, ProvidersConnectionString)

            If Nick.Length > 15 Then Nick = Nick.Substring(0, 15)

            lblName.Text = Nick
            hlName.ToolTip = Fullname

            Dim EncryptedStaffId As String = NasLib.Functions.Security.Cryptography.AesEncrypt(StaffId)
            hlName.NavigateUrl = "~/Pages/Profile.aspx?id=" & Server.UrlEncode(EncryptedStaffId)

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

