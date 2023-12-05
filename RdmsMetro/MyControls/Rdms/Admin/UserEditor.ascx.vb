Imports NasLib.Functions.Controls.DataTableTo
Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Provider

Namespace MyControls.Rdms.Admin

    Public Class UserEditor
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property PatronId As String
            Get
                Return txtStaffId.Text
            End Get
            Set(value As String)
                txtStaffId.Text = value
            End Set
        End Property

        Public Property VirtualBackPath As String
            Get
                Return gVirtualBackPath.Text
            End Get
            Set(value As String)
                gVirtualBackPath.Text = value
            End Set
        End Property

#End Region

#Region "Administrator"

        Private Sub AdminVisibility() Handles Me.Load
            PanelAdmin.Visible = Page.User.IsInRole("Administrator")
        End Sub


#End Region

#Region "Functions"

        Private Sub BackPathRedirect(Code_ As Integer)
            'Dim MyVirtualPath = "~/Pages/Admin/UserSearchInternal.aspx"
            MyResponse.Redirect(VirtualBackPath, MyRequest._Code, Code_)
        End Sub

#Region "DropDowns"

        Private Sub FillDropdowns()
            FillDdGender()
            FillDdMarriage()
            FillDdBranch()
            FillDdGrade()
        End Sub

        Private Sub FillDdGender()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersGender.GetAllGenders(ProvidersConnectionString)
            ToDropDownList(MyTable, ddGender, 0, 1, " -- Select Gender -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdMarriage()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersMarriage.GetAllMarriages(ProvidersConnectionString)
            ToDropDownList(MyTable, ddMarriage, 0, 1, " -- Select Marriage -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdGrade()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPositionGrade.GetAllGrade(ProvidersConnectionString)
            ToDropDownList(MyTable, ddGrade, 0, 1, " -- Select Grade -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdPosition()
            Dim GradeId As Integer = ddGrade.SelectedValue
            Dim GradeCode As String = Table.UsersPositionGrade.Grade(GradeId, ProvidersConnectionString)
            ddPosition.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPosition.GetPositionsByGrade(GradeCode, ProvidersConnectionString)
            ToDropDownList(MyTable, ddPosition, 0, 1, " -- Select Position -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdBranch()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
            ToDropDownList(MyTable, ddBranch, 0, 1, " -- Select Branch -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdSatellite()
            Dim BranchId As Integer = ddBranch.SelectedValue
            ddSatellite.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeSatellite.GetSatellitesByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddSatellite, 0, 2, " -- Select Satellite -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdDepartment()
            Dim BranchId As Integer = ddBranch.SelectedValue
            ddDepartment.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDepartment.GetDepartmentsByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddDepartment, 0, 2, " -- Select Department -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdDivision()
            Dim Department As Integer = ddDepartment.SelectedValue
            ddDivision.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDivision.GetDivisionsByDepartmentId(Department, ProvidersConnectionString)
            ToDropDownList(MyTable, ddDivision, 0, 2, " -- Select Division -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdUnit()
            Dim DivisionId As Integer = ddDivision.SelectedValue
            ddUnit.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeUnit.GetUnitsByDivisionId(DivisionId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddUnit, 0, 2, " -- Select Unit -- ")
            MyTable.Dispose()
        End Sub

#End Region

#Region "Load Default Data"

        Private Sub LoadStaffData(PatronId)

            Image1.ImageUrl = PicProviderLink(PatronId)

            txtStaffId.Text = PatronId
            txtStaffId.Enabled = False

            'Fill Textboxes
            txtFullname.Text = Table.UsersProfile.FullName(PatronId, ProvidersConnectionString)
            txtEmail.Text = Table.Membership.Email(PatronId, ProvidersConnectionString)
            txtPassport.Text = Table.UsersProfile.Passport(PatronId, ProvidersConnectionString)
            txtPhone.Text = Table.UsersProfile.Phone(PatronId, ProvidersConnectionString)
            txtHandPhone.Text = Table.UsersProfile.Handphone(PatronId, ProvidersConnectionString)
            txtNick.Text = Table.UsersProfile.Nick(PatronId, ProvidersConnectionString)

            'Fill and Select Grade and Position
            ddGrade.SelectedValue = Table.UsersProfile.GradeId(PatronId, ProvidersConnectionString)
            FillDdPosition()
            ddPosition.SelectedValue = Table.UsersProfile.PositionId(PatronId, ProvidersConnectionString)

            'Fill and Select Gender and Marriage
            ddGender.SelectedValue = Table.UsersProfile.GenderId(PatronId, ProvidersConnectionString)
            ddMarriage.SelectedValue = Table.UsersProfile.MarriageId(PatronId, ProvidersConnectionString)

            'Fill and Select Branch, Satellite, Department, Division, Unit
            ddBranch.SelectedValue = Table.UsersProfile.BranchId(PatronId, ProvidersConnectionString)
            If IsNumeric(ddBranch.SelectedValue) Then

                FillDdSatellite()
                ddSatellite.SelectedValue = Table.UsersProfile.SatelliteId(PatronId, ProvidersConnectionString)

                FillDdDepartment()
                ddDepartment.SelectedValue = Table.UsersProfile.DepartmentId(PatronId, ProvidersConnectionString)
                If IsNumeric(ddDepartment.SelectedValue) Then

                    FillDdDivision()
                    ddDivision.SelectedValue = Table.UsersProfile.DivisionId(PatronId, ProvidersConnectionString)
                    If IsNumeric(ddDivision.SelectedValue) Then

                        FillDdUnit()
                        ddUnit.SelectedValue = Table.UsersProfile.UnitId(PatronId, ProvidersConnectionString)

                    End If
                End If
            End If

            chkAdmin.Checked = Table.UsersInRoles.IsUserInRole(PatronId, "Administrator", ProvidersConnectionString)
            chkLibStaf.Checked = Table.UsersInRoles.IsUserInRole(PatronId, "Library Staff", ProvidersConnectionString)
            chkStaf.Checked = Table.UsersInRoles.IsUserInRole(PatronId, "Staff", ProvidersConnectionString)
            chkStud.Checked = Table.UsersInRoles.IsUserInRole(PatronId, "Student", ProvidersConnectionString)

        End Sub

#End Region

        Private Sub EditUser()

            Dim PatronId As String = txtStaffId.Text

            Table.UsersProfile.FullName(PatronId, ProvidersConnectionString) = txtFullname.Text
            Table.UsersProfile.Passport(PatronId, ProvidersConnectionString) = txtPassport.Text
            If IsNumeric(ddGender.SelectedValue) Then Table.UsersProfile.GenderId(PatronId, ProvidersConnectionString) = ddGender.SelectedValue
            If IsNumeric(ddMarriage.SelectedValue) Then Table.UsersProfile.MarriageId(PatronId, ProvidersConnectionString) = ddMarriage.SelectedValue
            Table.Membership.Email(PatronId, ProvidersConnectionString) = txtEmail.Text
            Table.UsersProfile.Phone(PatronId, ProvidersConnectionString) = txtPhone.Text
            Table.UsersProfile.Handphone(PatronId, ProvidersConnectionString) = txtHandPhone.Text
            Table.UsersProfile.Nick(PatronId, ProvidersConnectionString) = txtNick.Text

            If IsNumeric(ddGrade.SelectedValue) Then Table.UsersProfile.GradeId(PatronId, ProvidersConnectionString) = ddGrade.SelectedValue
            If IsNumeric(ddPosition.SelectedValue) Then Table.UsersProfile.PositionId(PatronId, ProvidersConnectionString) = ddPosition.SelectedValue

            If IsNumeric(ddBranch.SelectedValue) Then Table.UsersProfile.BranchId(PatronId, ProvidersConnectionString) = ddBranch.SelectedValue
            If IsNumeric(ddSatellite.SelectedValue) Then Table.UsersProfile.SatelliteId(PatronId, ProvidersConnectionString) = ddSatellite.SelectedValue
            If IsNumeric(ddDepartment.SelectedValue) Then Table.UsersProfile.DepartmentId(PatronId, ProvidersConnectionString) = ddDepartment.SelectedValue
            If IsNumeric(ddDivision.SelectedValue) Then Table.UsersProfile.DivisionId(PatronId, ProvidersConnectionString) = ddDivision.SelectedValue
            If IsNumeric(ddUnit.SelectedValue) Then Table.UsersProfile.UnitId(PatronId, ProvidersConnectionString) = ddUnit.SelectedValue

            If PanelAdmin.Visible Then

                If chkAdmin.Checked Then
                    Table.UsersInRoles.AssignUserRole(PatronId, "Administrator", ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(PatronId, "Administrator", ProvidersConnectionString)
                End If

                If chkLibStaf.Checked Then
                    Table.UsersInRoles.AssignUserRole(PatronId, "Library Staff", ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(PatronId, "Library Staff", ProvidersConnectionString)
                End If

                If chkStaf.Checked Then
                    Table.UsersInRoles.AssignUserRole(PatronId, "Staff", ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(PatronId, "Staff", ProvidersConnectionString)
                End If

                If chkStud.Checked Then
                    Table.UsersInRoles.AssignUserRole(PatronId, "Student", ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(PatronId, "Student", ProvidersConnectionString)
                End If

            End If

            SendNotification(PatronId)

            BackPathRedirect(2)
        End Sub

#End Region

#Region "Notification"

        Private Sub SendNotification(ReceiverId_ As String)

            Dim OwnerId As String = MyModules.Functions.QueryString.MyRequest.OwnerId
            Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)
            Dim ReceiverId As String = ReceiverId_
            'Dim ReceiverName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(ReceiverId, ProvidersConnectionString)

            Dim MessageTitle As String = "Information Changed"
            Dim MessageText As String = String.Format("Your profile information has been changed by '{0}'.", OwnerName)

            '### Custom ###
            If OwnerId = ReceiverId Then MessageText = String.Format("You have modified your own profile information .")
            '##############

            MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim PatronId_ As String = PatronId

            If Not IsPostBack Then
                FillDropdowns()

                If PatronId_.Length > 0 Then LoadStaffData(PatronId_)
            End If

        End Sub

        Protected Sub ddBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBranch.SelectedIndexChanged
            FillDdSatellite()
            FillDdDepartment()
            FillDdDivision()
            FillDdUnit()
        End Sub

        Protected Sub ddDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDepartment.SelectedIndexChanged
            FillDdDivision()
            FillDdUnit()
        End Sub

        Protected Sub ddDivision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddDivision.SelectedIndexChanged
            FillDdUnit()
        End Sub

        Protected Sub ddGrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddGrade.SelectedIndexChanged
            FillDdPosition()
        End Sub

        Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
            EditUser()
        End Sub

    End Class

End Namespace

