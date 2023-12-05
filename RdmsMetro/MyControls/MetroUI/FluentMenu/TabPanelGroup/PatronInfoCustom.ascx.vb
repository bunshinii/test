Imports NasLib.Functions.Controls.DataTableTo

Namespace MyControls.MetroUI.FluentMenu.TabPanelGroup

    Public Class PatronInfoCustom
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public ReadOnly Property PatronId As String
            Get
                Dim ReturnValue As String = ""

                'If Not String.IsNullOrEmpty(ddPatronStaf.SelectedValue) Then ReturnValue = ddPatronStaf.SelectedValue
                'If Not String.IsNullOrEmpty(ddPatronStudent.SelectedValue) Then ReturnValue = ddPatronStudent.SelectedValue

                Return gPatronId.Text
            End Get
        End Property

#Region "Student"

        Public ReadOnly Property StudentFacultyCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddFaculty.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StudentCampusCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddCampus.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StudentLevelCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = gStudLevelCode.Text
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StudentModeCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddMode.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StudentProgramCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddProgram.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Private Sub ResetDdStudent()
            ddPatronStudent.SelectedIndex = 0
            ddFaculty.Items.Clear()
            ddProgram.Items.Clear()
            ddBranchStud.Items.Clear()
            ddCampus.Items.Clear()
            ddMode.Items.Clear()
        End Sub

#End Region

#Region "Staff"

        Public ReadOnly Property StaffDepartmentCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddDepartment.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StaffPositionCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = gStafPosCode.Text
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property StaffTypeCode As String
            Get
                Dim ReturnValue As String = "0"
                Dim MyStr As String = ddStafType.SelectedValue
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
        End Property

        Private Sub ResetDdStaff()
            ddPatronStaf.SelectedIndex = 0
            ddBranchStaf.Items.Clear()
            ddDepartment.Items.Clear()
            ddStafType.Items.Clear()
        End Sub

#End Region

#End Region

#Region "Dropdowns"

        Private Sub LoadDropDowns()

            'Student
            FillDdPatronStudent()
            'FillDdFaculty()
            'FillDdProgram()
            'FillDdBranchStudent()
            'FillDdCampus()
            'FillDdMode()

            'Staff
            FillDdPatronStaff()
            'FillDdBranchStaff()
            'FillDdDepartment()
            'FillDdType()
        End Sub

#Region "Student"

        Private Sub FillDdPatronStudent()
            Dim MyTable As DataTable = MyModules.Database.CustomPatron.GetAllPatrons()
            ToDropDownList(MyTable, ddPatronStudent, 1, 2, " -- Select Patron Type -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdFaculty()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudFaculty.GetAllFaculties(ProvidersConnectionString)
            ToDropDownList(MyTable, ddFaculty, 1, 2, " -- Select Faculty -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdProgram()
            Dim FacultyCode As String = ddFaculty.SelectedValue
            ddProgram.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudProgram.GetAllPrograms(FacultyCode, ProvidersConnectionString)
            ToDropDownList2(MyTable, ddProgram, 1, 2, " -- Select Programme -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillProgramLevel()
            Dim ProgramCode As String = ddProgram.SelectedValue
            gStudLevelCode.Text = NasLib.Database.MySql.Provider.Table.StudProgram.LevelCode(ProgramCode, ProvidersConnectionString)
        End Sub

        Private Sub FillDdBranchStudent()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
            ToDropDownList(MyTable, ddBranchStud, 0, 1, " -- Select Branch -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdCampus()
            Dim BranchId As Integer = ddBranchStud.SelectedValue
            ddCampus.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudCampus.GetCampusesByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddCampus, 1, 2, " -- Select Campus -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdMode()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudMode.GetAllModes(ProvidersConnectionString)
            ToDropDownList(MyTable, ddMode, 1, 2, " -- Select Study Mode -- ")
            MyTable.Dispose()
        End Sub

#End Region

#Region "Staff"

        Private Sub FillDdPatronStaff()
            Dim MyTable As DataTable = MyModules.Database.CustomPatron.GetAllPatrons()
            ToDropDownList(MyTable, ddPatronStaf, 1, 2, " -- Select Patron Type -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdBranchStaff()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
            ToDropDownList(MyTable, ddBranchStaf, 0, 1, " -- Select Branch -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdDepartment()
            Dim BranchId As Integer = ddBranchStaf.SelectedValue
            ddDepartment.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StafDepartment.GetDeptsByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddDepartment, 1, 2, " -- Select Department -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdType()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPositionType.GetAllPositionTypes(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStafType, 1, 2, " -- Select Staff Type -- ")
            MyTable.Dispose()
        End Sub

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                LoadDropDowns()
            End If
        End Sub

        Protected Sub ddFaculty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddFaculty.SelectedIndexChanged
            FillDdProgram()
        End Sub

        Protected Sub ddProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddProgram.SelectedIndexChanged
            FillProgramLevel()
        End Sub

        Protected Sub ddBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBranchStud.SelectedIndexChanged
            FillDdCampus()
        End Sub

        Protected Sub ddBranchStaf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddBranchStaf.SelectedIndexChanged
            FillDdDepartment()
        End Sub

        Protected Sub ddPatronStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPatronStudent.SelectedIndexChanged
            If ddPatronStudent.SelectedIndex > 0 Then
                'lblPatronId.Text = ddPatronStudent.SelectedValue

                FillDdFaculty()
                FillDdProgram()
                FillDdBranchStudent()
                FillDdCampus()
                FillDdMode()

                ResetDdStaff()
                UpdatePanel2.Update()
                gPatronId.Text = ddPatronStudent.SelectedValue
            Else
                'lblPatronId.Text = ""
            End If

        End Sub

        Protected Sub ddPatronStaf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPatronStaf.SelectedIndexChanged
            If ddPatronStaf.SelectedIndex > 0 Then
                'lblPatronId.Text = ddPatronStaf.SelectedValue

                FillDdPatronStaff()
                FillDdBranchStaff()
                FillDdDepartment()
                FillDdType()

                ResetDdStudent()
                UpdatePanel1.Update()
                gPatronId.Text = ddPatronStaf.SelectedValue
            Else
                'lblPatronId.Text = ""
            End If


        End Sub
    End Class

End Namespace