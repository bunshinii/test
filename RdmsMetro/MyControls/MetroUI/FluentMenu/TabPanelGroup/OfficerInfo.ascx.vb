Imports NasLib.Database.MySql.Provider.Table

Namespace MyControls.MetroUI.FluentMenu.TabPanelGroup

    Public Class OfficerInfo
        Inherits System.Web.UI.UserControl

        Public Property OfficerPatronId As String
            Get
                Return lblPatronId.Text
            End Get
            Set(value As String)
                lblPatronId.Text = value
                LoadData()
            End Set
        End Property

        Public ReadOnly Property BranchId As String
            Get
                Return gBranchId.Text
            End Get
        End Property

        Public ReadOnly Property SatelliteId As String
            Get
                Return gSatelliteId.Text
            End Get
        End Property

        Public ReadOnly Property DivisionId As String
            Get
                Return gDivisionId.Text
            End Get
        End Property

        Public ReadOnly Property DepartmentId As String
            Get
                Return gDepartmentId.Text
            End Get
        End Property

        Public ReadOnly Property UnitId As String
            Get
                Return gUnitId.Text
            End Get
        End Property


        Private Sub LoadData()
            Dim PatronId_ As String = OfficerPatronId
            lblFullname.Text = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(PatronId_, ProvidersConnectionString)

            gBranchId.Text = UsersProfile.BranchId(PatronId_, ProvidersConnectionString)
            gSatelliteId.Text = UsersProfile.SatelliteId(PatronId_, ProvidersConnectionString)
            gDepartmentId.Text = UsersProfile.DepartmentId(PatronId_, ProvidersConnectionString)
            gDivisionId.Text = UsersProfile.DivisionId(PatronId_, ProvidersConnectionString)
            gUnitId.Text = UsersProfile.UnitId(PatronId_, ProvidersConnectionString)

            lblBranch.Text = UsersProfile.BranchName(PatronId_, ProvidersConnectionString)
            lblSatellite.Text = UsersProfile.SatelliteName(PatronId_, ProvidersConnectionString)
            lblDepartmet.Text = UsersProfile.DepartmentName(PatronId_, ProvidersConnectionString)
            lblDivision.Text = UsersProfile.DivisionName(PatronId_, ProvidersConnectionString)
            lblunit.Text = UsersProfile.UnitName(PatronId_, ProvidersConnectionString)

            PatronPhoto1.PatronId = PatronId_
        End Sub


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

