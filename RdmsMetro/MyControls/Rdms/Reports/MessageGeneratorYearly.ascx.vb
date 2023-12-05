Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class MessageGeneratorYearly
    Inherits System.Web.UI.UserControl

#Region "Message Generator Yearly"

    Private Sub Message()
        If String.IsNullOrEmpty(MyRequest.GetDate) Then Exit Sub

        Dim MyDate As String = Format(CDate(MyRequest.GetDate), "yyyy")

        Dim ListTypeIndex As Integer = MyRequest.GetListingModeIndex

        Select Case ListTypeIndex

            Case 0 'Individual

                Dim OfficerName As String = MyRequest.GetOfficerId
                If OfficerName.Length > 0 Then

                    OfficerName = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OfficerName, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, OfficerName)
                End If

            Case 1 'Branch

                Dim BranchId As Integer = MyRequest.GetBranchId
                If BranchId > 0 Then
                    Dim BranchName As String = NasLib.Database.MySql.Provider.Table.OfficeBranch.Branch(BranchId, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, BranchName)
                End If

            Case 2 'Satellite

                Dim SatelliteId As Integer = MyRequest.GetSatelliteId
                If SatelliteId > 0 Then
                    Dim SatelliteName As String = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Satellite(SatelliteId, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, SatelliteName)
                End If

            Case 3 'Department

                Dim DepartmentId As Integer = MyRequest.GetDepartmentId
                If DepartmentId > 0 Then
                    Dim DepartmentName As String = NasLib.Database.MySql.Provider.Table.OfficeDepartment.Department(DepartmentId, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, DepartmentName)
                End If

            Case 4 'Division

                Dim DivisionId As Integer = MyRequest.GetDivisionId
                If DivisionId > 0 Then
                    Dim DivisionName As String = NasLib.Database.MySql.Provider.Table.OfficeDivision.Division(DivisionId, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, DivisionName)
                End If

            Case 5 'Unit

                Dim UnitId As Integer = MyRequest.GetDivisionId
                If UnitId > 0 Then
                    Dim UnitName As String = NasLib.Database.MySql.Provider.Table.OfficeUnit.Unit(UnitId, ProvidersConnectionString)
                    lblMessage.Text = String.Format("Reference Desk session on {0} by {1}", MyDate, UnitName)
                End If

        End Select

        If CBool(MyRequest.GetFilterModeEnabled) Then

            Select Case CInt(MyRequest.GetFilterModeIndex)
                Case 1 'Faculty
                    Dim FacultyCode As String = MyRequest.GetStudFacultyCode
                    If FacultyCode.Length > 0 Then lblFilter.Text = "Filtered by Faculty : " & NasLib.Database.MySql.Provider.Table.StudFaculty.FacultyName(FacultyCode, ProvidersConnectionString)
                Case 2 'Program
                    Dim ProgramCode As String = MyRequest.GetStudProgramCode
                    If ProgramCode.Length > 0 Then lblFilter.Text = "Filtered by Programme : " & NasLib.Database.MySql.Provider.Table.StudProgram.ProgramDesc(ProgramCode, ProvidersConnectionString)
                Case 3 'Campus
                    Dim CampusCode As String = MyRequest.GetStudCampusCode
                    If CampusCode.Length > 0 Then lblFilter.Text = "Filtered by Campus : " & NasLib.Database.MySql.Provider.Table.StudCampus.CampusName(CampusCode, ProvidersConnectionString)
                Case 4 'Level
                    Dim StudLevel As String = MyRequest.GetStudLevelCode
                    If StudLevel.Length > 0 Then lblFilter.Text = "Filtered by Level : " & NasLib.Database.MySql.Provider.Table.StudProgramLevel.LevelDesc(StudLevel, ProvidersConnectionString)
                Case 5 'Mode
                    Dim StudMode As String = MyRequest.GetStudModeCode
                    If StudMode.Length > 0 Then lblFilter.Text = "Filtered by Study Mode : " & NasLib.Database.MySql.Provider.Table.StudMode.ModDesc(StudMode, ProvidersConnectionString)
                Case 6 'Staff Department
                    Dim StafDept As String = MyRequest.GetStafDepartmentCode
                    If StafDept.Length > 0 Then lblFilter.Text = "Filtered by Staff Department : " & NasLib.Database.MySql.Provider.Table.StafDepartment.DeptName(StafDept, ProvidersConnectionString)
                Case 7 'Staff Type
                    Dim StafType As String = MyRequest.GetStafTypeCode
                    If StafType.Length > 0 Then lblFilter.Text = "Filtered by Staff Type : " & NasLib.Database.MySql.Provider.Table.UsersPositionType.Description(StafType, ProvidersConnectionString)

            End Select

        End If
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Message()
    End Sub

End Class