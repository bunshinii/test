Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.User.DutyRequest

    Public Class DutyItem
        Inherits System.Web.UI.UserControl

        Public Property PatronId As String
            Get
                Return gPatronid.Text
            End Get
            Set(value As String)
                gPatronid.Text = value

                lblName.Text = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(value, ProvidersConnectionString)
                lblPhone.Text = NasLib.Database.MySql.Provider.Table.UsersProfile.Phone(value, ProvidersConnectionString)
            End Set
        End Property

        Public Property DutyId As Integer
            Get
                Return gDutyId.Text
            End Get
            Set(value As Integer)
                gDutyId.Text = value
                lblSatellite.Text = MyModules.Database.DutyStaff.SatelliteName(value)

                If value > 0 Then
                    Dim DutyTypeId As Integer = MyModules.Database.DutyStaff.DutyTypeId(DutyId)
                    gDutyTypeId.Text = DutyTypeId

                    If DutyTypeId > 0 Then
                        gBgColor.Text = MyModules.Database.DutyType.BackgroundColor(DutyTypeId)
                        gFgColor.Text = MyModules.Database.DutyType.ForeColor(DutyTypeId)
                        gToolTip.Text = MyModules.Database.DutyType.DutyTypeName(DutyTypeId) & " : " & MyModules.Database.DutyType.DutyNote(DutyTypeId)
                    End If

                End If

                Dim VirtualPath As String = "~/Pages/User/DutyAccept.aspx"
                gAlink.Text = MyResponse.Url(VirtualPath, MyRequest._DutyId, value)

            End Set
        End Property

        Public Property RequestId As Integer
            Get
                Return gReqId.Text
            End Get
            Set(value As Integer)
                gReqId.Text = value
            End Set
        End Property

        Public Property TheDate As String
            Get
                Return lblDate.Text
            End Get
            Set(value As String)
                lblDate.Text = value
            End Set
        End Property

        Public ReadOnly Property Location As String
            Get
                Return lblSatellite.Text
            End Get
        End Property

        Public ReadOnly Property Phone As String
            Get
                Return lblPhone.Text
            End Get
        End Property


        Public ReadOnly Property BackGroundColor As String
            Get
                Return gBgColor.Text
            End Get
        End Property

        Public ReadOnly Property ForeGroundColor As String
            Get
                Return gFgColor.Text
            End Get
        End Property

        Public ReadOnly Property alink As String
            Get
                Return ResolveUrl(gAlink.Text)
            End Get
        End Property

        Public ReadOnly Property ToolTip As String
            Get
                Return gToolTip.Text
            End Get
        End Property

        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Image1.ImageUrl = PicProviderLink(PatronId)
        End Sub
    End Class

End Namespace

