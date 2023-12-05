Imports NasLib.Database.MySql.Provider.Table
Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.User

    Public Class Search
        Inherits System.Web.UI.UserControl


#Region "Properties"

        Private ReadOnly Property MyLink(ReceiverId_ As String) As String
            Get
                Dim VirtualPath_ As String = "~/Pages/User/DutyChangeProcess.aspx"

                Dim MyUrl As String = MyResponse.Url(VirtualPath_, {MyRequest._DutyId, MyRequest._ReceiverId}, {MyRequest.GetDutyId, ReceiverId_})
                Return ResolveUrl(MyUrl)
            End Get
        End Property

#End Region

#Region "Functions"

        Protected Sub btnSearch_Click() Handles btnSearch.ServerClick
            'The result of the seacrh is porposely limit to 100.

            If rbFilterBranch.Checked Then
                SearchBranch()
            ElseIf rbFilterSatellite.Checked Then
                SearchSatellite()
            ElseIf rbFilterDepartment.Checked Then
                SearchDepartment()
            Else
                SearchDivision()
            End If

        End Sub

#Region "Search"

        Private Sub SearchBranch()
            Dim BranchId As Integer = NasLib.Functions.Web.CurrentUser.BranchId()

            Dim StaffTable As DataTable

            If rbPatronId.Checked Then
                StaffTable = UsersProfile.SearchUsersInBranchByPatronId(BranchId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbPassport.Checked Then
                StaffTable = UsersProfile.SearchUsersInBranchByPatronIc(BranchId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbName.Checked Then
                StaffTable = UsersProfile.SearchUsersInBranchByPatronName(BranchId, txtSearch.Text, ProvidersConnectionString)
            Else
                StaffTable = UsersProfile.SearchUsersInBranchByAll(BranchId, txtSearch.Text, ProvidersConnectionString)
            End If

            Dim StaffCount As Integer = StaffTable.Rows.Count
            If StaffCount > 0 Then
                For i As Integer = 0 To StaffCount - 1
                    Dim MyControl As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
                    MyControl.StaffId = StaffTable(i)("name")
                    MyControl.Link = ResolveUrl(MyLink(StaffTable(i)("name")))
                    phItem.Controls.Add(MyControl)
                Next
            End If

            ResultMessage(StaffCount)
            StaffTable.Dispose()
        End Sub

        Private Sub SearchSatellite()
            Dim SatelliteId As Integer = NasLib.Functions.Web.CurrentUser.SatelliteId()

            Dim StaffTable As DataTable

            If rbPatronId.Checked Then
                StaffTable = UsersProfile.SearchUsersInSatelliteByPatronId(SatelliteId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbPassport.Checked Then
                StaffTable = UsersProfile.SearchUsersInSatelliteByPatronIc(SatelliteId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbName.Checked Then
                StaffTable = UsersProfile.SearchUsersInSatelliteByPatronName(SatelliteId, txtSearch.Text, ProvidersConnectionString)
            Else
                StaffTable = UsersProfile.SearchUsersInSatelliteByAll(SatelliteId, txtSearch.Text, ProvidersConnectionString)
            End If

            Dim StaffCount As Integer = StaffTable.Rows.Count
            If StaffCount > 0 Then
                For i As Integer = 0 To StaffCount - 1
                    Dim MyControl As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
                    MyControl.StaffId = StaffTable(i)("name")
                    MyControl.Link = MyControl.Link = ResolveUrl(MyLink(StaffTable(i)("name")))
                    phItem.Controls.Add(MyControl)
                Next
            End If

            ResultMessage(StaffCount)
            StaffTable.Dispose()
        End Sub

        Private Sub SearchDepartment()
            Dim DepartmentId As Integer = NasLib.Functions.Web.CurrentUser.DepartmentId()

            Dim StaffTable As DataTable

            If rbPatronId.Checked Then
                StaffTable = UsersProfile.SearchUsersInDepartmentByPatronId(DepartmentId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbPassport.Checked Then
                StaffTable = UsersProfile.SearchUsersInDepartmentByPatronIc(DepartmentId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbName.Checked Then
                StaffTable = UsersProfile.SearchUsersInDepartmentByPatronName(DepartmentId, txtSearch.Text, ProvidersConnectionString)
            Else
                StaffTable = UsersProfile.SearchUsersInDepartmentByAll(DepartmentId, txtSearch.Text, ProvidersConnectionString)
            End If

            Dim StaffCount As Integer = StaffTable.Rows.Count
            If StaffCount > 0 Then
                For i As Integer = 0 To StaffCount - 1
                    Dim MyControl As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
                    MyControl.StaffId = StaffTable(i)("name")
                    MyControl.Link = MyControl.Link = ResolveUrl(MyLink(StaffTable(i)("name")))
                    phItem.Controls.Add(MyControl)
                Next
            End If

            ResultMessage(StaffCount)
            StaffTable.Dispose()
        End Sub

        Private Sub SearchDivision()
            Dim DivisionId As Integer = NasLib.Functions.Web.CurrentUser.DivisionId()

            Dim StaffTable As DataTable

            If rbPatronId.Checked Then
                StaffTable = UsersProfile.SearchUsersInDivisionByPatronId(DivisionId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbPassport.Checked Then
                StaffTable = UsersProfile.SearchUsersInDivisionByPatronIc(DivisionId, txtSearch.Text, ProvidersConnectionString)
            ElseIf rbName.Checked Then
                StaffTable = UsersProfile.SearchUsersInDivisionByPatronName(DivisionId, txtSearch.Text, ProvidersConnectionString)
            Else
                StaffTable = UsersProfile.SearchUsersInDivisionByAll(DivisionId, txtSearch.Text, ProvidersConnectionString)
            End If

            Dim StaffCount As Integer = StaffTable.Rows.Count
            If StaffCount > 0 Then
                For i As Integer = 0 To StaffCount - 1
                    Dim MyControl As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
                    MyControl.StaffId = StaffTable(i)("name")
                    MyControl.Link = ResolveUrl(MyLink(StaffTable(i)("name")))
                    phItem.Controls.Add(MyControl)
                Next
            End If

            ResultMessage(StaffCount)
            StaffTable.Dispose()
        End Sub

        Private Sub ResultMessage(StaffCount As Integer)

            Select Case StaffCount
                Case 0
                    lblResults.Text = "No result"
                Case 1
                    lblResults.Text = String.Format("{0} staff found. Click on the staff to send request : ", StaffCount)
                Case 1 To 99
                    lblResults.Text = String.Format("{0} staffs found Click on the staff to send request : ", StaffCount)
                Case Is > 100
                    lblResults.Text = String.Format("There may be more than {0} staffs found but only 100 can be displayed Click on the staff to send request : ", StaffCount)
            End Select

        End Sub

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Private Sub lbOption_Click(sender As Object, e As EventArgs) Handles lbOption.Click
            PanelOption.Visible = Not PanelOption.Visible
        End Sub

        Private Sub hiddenButton_Click(sender As Object, e As EventArgs) Handles hiddenButton.Click
            btnSearch_Click()
        End Sub
    End Class

End Namespace

