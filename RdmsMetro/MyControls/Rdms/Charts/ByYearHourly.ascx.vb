Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyControls.Rdms.Charts

    Public Class ByYearHourly
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

#Region "MySql Table Setting"
        Dim MyCmd As New Sql.Commands

        Private Function TheDate() As Date
            Dim MyDateStr As String = MyRequest.GetDate
            Dim TheDate_ As Date = Now
            If IsDate(MyDateStr) Then TheDate_ = MyDateStr

            Return TheDate_
        End Function

        Private Function TableName() As String
            Return "rdms_questions"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            patronId
            mediumId
            sub_od
            sub_dc
            sub_it
            sub_op
            sub_lrc
            sub_rc
            sub_fs
            sub_vp
            sub_ja
            sub_gt
            sub_etc
            enq_qr
            enq_rr
            enq_st
            enq_ag
            enq_etc
            question
            answer
            timeStart
            timeEnd
            duration
            isKiv
            isFinished
            officer
            branchId
            satelliteId
            departmentId
            divisionId
            unitId
            studFacultyCode
            studProgramCode
            studCampusCode
            studLevelCode
            studModeCode
            stafDeptCode
            stafPosCode
            stafTypeCode
            isCustom
            sessionId
        End Enum

#Region "Criterias Yearly"

        Private Function MyCriteriaMediumHour(MediumId As Integer, Hour As Integer) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(eFieldName.mediumId.ToString, MediumId), _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(FunctionHour(eFieldName.timeStart.ToString), Hour))

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

        Private Function MyCriteriaTotalHour(Hour As Integer) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(FunctionHour(eFieldName.timeStart.ToString), Hour))

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

        Private Function MyCriteriaTotalMedium(MediumId As Integer) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(eFieldName.mediumId.ToString, MediumId))

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

#Region "Subject and Enquiry Criteria"

        Private Function MyCriteriaSubjectEnquiry(FieldName As eFieldName, IsChecked As Boolean) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(FieldName.ToString, IsChecked))

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

#End Region

#End Region

        Private Function CriteriaFromQueryString() As String
            Dim ReturnValue As String = ""

            Select Case CInt(MyRequest.GetListingModeIndex)
                Case 0 'Individual

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.officer.ToString, MyRequest.GetOfficerId)
                    End If

                Case 1 'Branch

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.branchId.ToString, MyRequest.GetBranchId)
                    End If

                Case 2 'Satellite

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.satelliteId.ToString, MyRequest.GetSatelliteId)
                    End If

                Case 3 'Department

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.departmentId.ToString, MyRequest.GetDepartmentId)
                    End If

                Case 4 'Division

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.divisionId.ToString, MyRequest.GetDivisionId)
                    End If

                Case 5 'Unit

                    If CBool(MyRequest.GetFilterModeEnabled) Then

                        Select Case CInt(MyRequest.GetFilterModeIndex)
                            Case 1 'Faculty
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.studFacultyCode.ToString, MyRequest.GetStudFacultyCode) _
                                )

                            Case 2 'Program
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.studProgramCode.ToString, MyRequest.GetStudProgramCode) _
                                )

                            Case 3 'Campus
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.studCampusCode.ToString, MyRequest.GetStudCampusCode) _
                                )

                            Case 4 'Level
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.studLevelCode.ToString, MyRequest.GetStudLevelCode) _
                                )

                            Case 5 'Mode
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.studModeCode.ToString, MyRequest.GetStudModeCode) _
                                )

                            Case 6 'Staff Department
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.stafDeptCode.ToString, MyRequest.GetStafDepartmentCode) _
                                )

                            Case 7 'Staff Type
                                ReturnValue = CriteriasAND( _
                                Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId), _
                                Criteria(eFieldName.stafTypeCode.ToString, MyRequest.GetStafTypeCode) _
                                )

                        End Select

                    Else
                        ReturnValue = Criteria(eFieldName.unitId.ToString, MyRequest.GetUnitId)
                    End If

            End Select

            Return ReturnValue

        End Function

#End Region

        Public ReadOnly Property MediumName(MediumId As Integer) As String
            Get
                Dim TableName_ As String = "rdms_medium"
                Dim FieldName As String = "medium_name"
                Dim MyCriteria As String = Criteria("id", MediumId)
                Return MyCmd.CmdSelect2(TableName_, FieldName, 0, MyCriteria, , MyAppConnectionString)
            End Get
        End Property

#Region "Load Table"

        Private Sub LoadTables()
            LoadFaceToFace()
            LoadLiveChat()
            LoadPhone()
            LoadEmail()
            LoadSocialMedia()
            LoadInstantMessenger()
            LoadVideoConferencing()
            LoadOthers()
            LoadTotalHour()
            LoadSubjectEnquiry()
        End Sub

        Private Sub LoadFaceToFace()
            Dim MediumId As Integer = 1 'Face to Face

            lblFace00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblFace01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblFace02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblFace03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblFace04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblFace05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblFace06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblFace07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblFace08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblFace09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblFace10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblFace11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblFace12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblFace13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblFace14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblFace15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblFace16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblFace17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblFace18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblFace19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblFace20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblFace21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblFace22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblFace23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)

            lblFaceTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesFaceToFace = Chart1.Series("Face2Face")
            MyChartSeriesFaceToFace.Points.Item(0).SetValueY(CInt(lblFace00.Text))
            MyChartSeriesFaceToFace.Points.Item(1).SetValueY(CInt(lblFace01.Text))
            MyChartSeriesFaceToFace.Points.Item(2).SetValueY(CInt(lblFace02.Text))
            MyChartSeriesFaceToFace.Points.Item(3).SetValueY(CInt(lblFace03.Text))
            MyChartSeriesFaceToFace.Points.Item(4).SetValueY(CInt(lblFace04.Text))
            MyChartSeriesFaceToFace.Points.Item(5).SetValueY(CInt(lblFace05.Text))
            MyChartSeriesFaceToFace.Points.Item(6).SetValueY(CInt(lblFace06.Text))
            MyChartSeriesFaceToFace.Points.Item(7).SetValueY(CInt(lblFace07.Text))
            MyChartSeriesFaceToFace.Points.Item(8).SetValueY(CInt(lblFace08.Text))
            MyChartSeriesFaceToFace.Points.Item(9).SetValueY(CInt(lblFace09.Text))
            MyChartSeriesFaceToFace.Points.Item(10).SetValueY(CInt(lblFace10.Text))
            MyChartSeriesFaceToFace.Points.Item(11).SetValueY(CInt(lblFace11.Text))
            MyChartSeriesFaceToFace.Points.Item(12).SetValueY(CInt(lblFace12.Text))
            MyChartSeriesFaceToFace.Points.Item(13).SetValueY(CInt(lblFace13.Text))
            MyChartSeriesFaceToFace.Points.Item(14).SetValueY(CInt(lblFace14.Text))
            MyChartSeriesFaceToFace.Points.Item(15).SetValueY(CInt(lblFace15.Text))
            MyChartSeriesFaceToFace.Points.Item(16).SetValueY(CInt(lblFace16.Text))
            MyChartSeriesFaceToFace.Points.Item(17).SetValueY(CInt(lblFace17.Text))
            MyChartSeriesFaceToFace.Points.Item(18).SetValueY(CInt(lblFace18.Text))
            MyChartSeriesFaceToFace.Points.Item(19).SetValueY(CInt(lblFace19.Text))
            MyChartSeriesFaceToFace.Points.Item(20).SetValueY(CInt(lblFace20.Text))
            MyChartSeriesFaceToFace.Points.Item(21).SetValueY(CInt(lblFace21.Text))
            MyChartSeriesFaceToFace.Points.Item(22).SetValueY(CInt(lblFace22.Text))
            MyChartSeriesFaceToFace.Points.Item(23).SetValueY(CInt(lblFace23.Text))
        End Sub

        Private Sub LoadLiveChat()
            Dim MediumId As Integer = 2 'Live Chat

            lblChat00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblChat01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblChat02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblChat03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblChat04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblChat05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblChat06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblChat07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblChat08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblChat09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblChat10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblChat11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblChat12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblChat13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblChat14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblChat15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblChat16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblChat17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblChat18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblChat19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblChat20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblChat21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblChat22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblChat23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)

            lblChatTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesChat = Chart1.Series("LiveChat")
            MyChartSeriesChat.Points.Item(0).SetValueY(CInt(lblChat00.Text))
            MyChartSeriesChat.Points.Item(1).SetValueY(CInt(lblChat01.Text))
            MyChartSeriesChat.Points.Item(2).SetValueY(CInt(lblChat02.Text))
            MyChartSeriesChat.Points.Item(3).SetValueY(CInt(lblChat03.Text))
            MyChartSeriesChat.Points.Item(4).SetValueY(CInt(lblChat04.Text))
            MyChartSeriesChat.Points.Item(5).SetValueY(CInt(lblChat05.Text))
            MyChartSeriesChat.Points.Item(6).SetValueY(CInt(lblChat06.Text))
            MyChartSeriesChat.Points.Item(7).SetValueY(CInt(lblChat07.Text))
            MyChartSeriesChat.Points.Item(8).SetValueY(CInt(lblChat08.Text))
            MyChartSeriesChat.Points.Item(9).SetValueY(CInt(lblChat09.Text))
            MyChartSeriesChat.Points.Item(10).SetValueY(CInt(lblChat10.Text))
            MyChartSeriesChat.Points.Item(11).SetValueY(CInt(lblChat11.Text))
            MyChartSeriesChat.Points.Item(12).SetValueY(CInt(lblChat12.Text))
            MyChartSeriesChat.Points.Item(13).SetValueY(CInt(lblChat13.Text))
            MyChartSeriesChat.Points.Item(14).SetValueY(CInt(lblChat14.Text))
            MyChartSeriesChat.Points.Item(15).SetValueY(CInt(lblChat15.Text))
            MyChartSeriesChat.Points.Item(16).SetValueY(CInt(lblChat16.Text))
            MyChartSeriesChat.Points.Item(17).SetValueY(CInt(lblChat17.Text))
            MyChartSeriesChat.Points.Item(18).SetValueY(CInt(lblChat18.Text))
            MyChartSeriesChat.Points.Item(19).SetValueY(CInt(lblChat19.Text))
            MyChartSeriesChat.Points.Item(20).SetValueY(CInt(lblChat20.Text))
            MyChartSeriesChat.Points.Item(21).SetValueY(CInt(lblChat21.Text))
            MyChartSeriesChat.Points.Item(22).SetValueY(CInt(lblChat22.Text))
            MyChartSeriesChat.Points.Item(23).SetValueY(CInt(lblChat23.Text))
        End Sub

        Private Sub LoadPhone()
            Dim MediumId As Integer = 3 'Phone

            lblPhone00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblPhone01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblPhone02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblPhone03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblPhone04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblPhone05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblPhone06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblPhone07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblPhone08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblPhone09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblPhone10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblPhone11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblPhone12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblPhone13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblPhone14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblPhone15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblPhone16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblPhone17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblPhone18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblPhone19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblPhone20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblPhone21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblPhone22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblPhone23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)

            lblPhoneTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesPhone = Chart1.Series("Phone")
            MyChartSeriesPhone.Points.Item(0).SetValueY(CInt(lblPhone00.Text))
            MyChartSeriesPhone.Points.Item(1).SetValueY(CInt(lblPhone01.Text))
            MyChartSeriesPhone.Points.Item(2).SetValueY(CInt(lblPhone02.Text))
            MyChartSeriesPhone.Points.Item(3).SetValueY(CInt(lblPhone03.Text))
            MyChartSeriesPhone.Points.Item(4).SetValueY(CInt(lblPhone04.Text))
            MyChartSeriesPhone.Points.Item(5).SetValueY(CInt(lblPhone05.Text))
            MyChartSeriesPhone.Points.Item(6).SetValueY(CInt(lblPhone06.Text))
            MyChartSeriesPhone.Points.Item(7).SetValueY(CInt(lblPhone07.Text))
            MyChartSeriesPhone.Points.Item(8).SetValueY(CInt(lblPhone08.Text))
            MyChartSeriesPhone.Points.Item(9).SetValueY(CInt(lblPhone09.Text))
            MyChartSeriesPhone.Points.Item(10).SetValueY(CInt(lblPhone10.Text))
            MyChartSeriesPhone.Points.Item(11).SetValueY(CInt(lblPhone11.Text))
            MyChartSeriesPhone.Points.Item(12).SetValueY(CInt(lblPhone12.Text))
            MyChartSeriesPhone.Points.Item(13).SetValueY(CInt(lblPhone13.Text))
            MyChartSeriesPhone.Points.Item(14).SetValueY(CInt(lblPhone14.Text))
            MyChartSeriesPhone.Points.Item(15).SetValueY(CInt(lblPhone15.Text))
            MyChartSeriesPhone.Points.Item(16).SetValueY(CInt(lblPhone16.Text))
            MyChartSeriesPhone.Points.Item(17).SetValueY(CInt(lblPhone17.Text))
            MyChartSeriesPhone.Points.Item(18).SetValueY(CInt(lblPhone18.Text))
            MyChartSeriesPhone.Points.Item(19).SetValueY(CInt(lblPhone19.Text))
            MyChartSeriesPhone.Points.Item(20).SetValueY(CInt(lblPhone20.Text))
            MyChartSeriesPhone.Points.Item(21).SetValueY(CInt(lblPhone21.Text))
            MyChartSeriesPhone.Points.Item(22).SetValueY(CInt(lblPhone22.Text))
            MyChartSeriesPhone.Points.Item(23).SetValueY(CInt(lblPhone23.Text))
        End Sub

        Private Sub LoadEmail()
            Dim MediumId As Integer = 4 'Email

            lblEmail00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblEmail01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblEmail02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblEmail03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblEmail04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblEmail05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblEmail06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblEmail07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblEmail08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblEmail09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblEmail10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblEmail11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblEmail12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblEmail13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblEmail14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblEmail15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblEmail16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblEmail17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblEmail18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblEmail19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblEmail20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblEmail21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblEmail22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblEmail23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)
            lblEmailTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesEmail = Chart1.Series("Email")
            MyChartSeriesEmail.Points.Item(0).SetValueY(CInt(lblEmail00.Text))
            MyChartSeriesEmail.Points.Item(1).SetValueY(CInt(lblEmail01.Text))
            MyChartSeriesEmail.Points.Item(2).SetValueY(CInt(lblEmail02.Text))
            MyChartSeriesEmail.Points.Item(3).SetValueY(CInt(lblEmail03.Text))
            MyChartSeriesEmail.Points.Item(4).SetValueY(CInt(lblEmail04.Text))
            MyChartSeriesEmail.Points.Item(5).SetValueY(CInt(lblEmail05.Text))
            MyChartSeriesEmail.Points.Item(6).SetValueY(CInt(lblEmail06.Text))
            MyChartSeriesEmail.Points.Item(7).SetValueY(CInt(lblEmail07.Text))
            MyChartSeriesEmail.Points.Item(8).SetValueY(CInt(lblEmail08.Text))
            MyChartSeriesEmail.Points.Item(9).SetValueY(CInt(lblEmail09.Text))
            MyChartSeriesEmail.Points.Item(10).SetValueY(CInt(lblEmail10.Text))
            MyChartSeriesEmail.Points.Item(11).SetValueY(CInt(lblEmail11.Text))
            MyChartSeriesEmail.Points.Item(12).SetValueY(CInt(lblEmail12.Text))
            MyChartSeriesEmail.Points.Item(13).SetValueY(CInt(lblEmail13.Text))
            MyChartSeriesEmail.Points.Item(14).SetValueY(CInt(lblEmail14.Text))
            MyChartSeriesEmail.Points.Item(15).SetValueY(CInt(lblEmail15.Text))
            MyChartSeriesEmail.Points.Item(16).SetValueY(CInt(lblEmail16.Text))
            MyChartSeriesEmail.Points.Item(17).SetValueY(CInt(lblEmail17.Text))
            MyChartSeriesEmail.Points.Item(18).SetValueY(CInt(lblEmail18.Text))
            MyChartSeriesEmail.Points.Item(19).SetValueY(CInt(lblEmail19.Text))
            MyChartSeriesEmail.Points.Item(20).SetValueY(CInt(lblEmail20.Text))
            MyChartSeriesEmail.Points.Item(21).SetValueY(CInt(lblEmail21.Text))
            MyChartSeriesEmail.Points.Item(22).SetValueY(CInt(lblEmail22.Text))
            MyChartSeriesEmail.Points.Item(23).SetValueY(CInt(lblEmail23.Text))
        End Sub

        Private Sub LoadSocialMedia()
            Dim MediumId As Integer = 5 'Social Media

            lblSocial00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblSocial01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblSocial02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblSocial03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblSocial04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblSocial05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblSocial06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblSocial07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblSocial08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblSocial09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblSocial10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblSocial11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblSocial12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblSocial13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblSocial14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblSocial15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblSocial16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblSocial17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblSocial18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblSocial19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblSocial20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblSocial21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblSocial22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblSocial23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)
            lblSocialTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesSocialMedia = Chart1.Series("SocialMedia")
            MyChartSeriesSocialMedia.Points.Item(0).SetValueY(CInt(lblSocial00.Text))
            MyChartSeriesSocialMedia.Points.Item(1).SetValueY(CInt(lblSocial01.Text))
            MyChartSeriesSocialMedia.Points.Item(2).SetValueY(CInt(lblSocial02.Text))
            MyChartSeriesSocialMedia.Points.Item(3).SetValueY(CInt(lblSocial03.Text))
            MyChartSeriesSocialMedia.Points.Item(4).SetValueY(CInt(lblSocial04.Text))
            MyChartSeriesSocialMedia.Points.Item(5).SetValueY(CInt(lblSocial05.Text))
            MyChartSeriesSocialMedia.Points.Item(6).SetValueY(CInt(lblSocial06.Text))
            MyChartSeriesSocialMedia.Points.Item(7).SetValueY(CInt(lblSocial07.Text))
            MyChartSeriesSocialMedia.Points.Item(8).SetValueY(CInt(lblSocial08.Text))
            MyChartSeriesSocialMedia.Points.Item(9).SetValueY(CInt(lblSocial09.Text))
            MyChartSeriesSocialMedia.Points.Item(10).SetValueY(CInt(lblSocial10.Text))
            MyChartSeriesSocialMedia.Points.Item(11).SetValueY(CInt(lblSocial11.Text))
            MyChartSeriesSocialMedia.Points.Item(12).SetValueY(CInt(lblSocial12.Text))
            MyChartSeriesSocialMedia.Points.Item(13).SetValueY(CInt(lblSocial13.Text))
            MyChartSeriesSocialMedia.Points.Item(14).SetValueY(CInt(lblSocial14.Text))
            MyChartSeriesSocialMedia.Points.Item(15).SetValueY(CInt(lblSocial15.Text))
            MyChartSeriesSocialMedia.Points.Item(16).SetValueY(CInt(lblSocial16.Text))
            MyChartSeriesSocialMedia.Points.Item(17).SetValueY(CInt(lblSocial17.Text))
            MyChartSeriesSocialMedia.Points.Item(18).SetValueY(CInt(lblSocial18.Text))
            MyChartSeriesSocialMedia.Points.Item(19).SetValueY(CInt(lblSocial19.Text))
            MyChartSeriesSocialMedia.Points.Item(20).SetValueY(CInt(lblSocial20.Text))
            MyChartSeriesSocialMedia.Points.Item(21).SetValueY(CInt(lblSocial21.Text))
            MyChartSeriesSocialMedia.Points.Item(22).SetValueY(CInt(lblSocial22.Text))
            MyChartSeriesSocialMedia.Points.Item(23).SetValueY(CInt(lblSocial23.Text))
        End Sub

        Private Sub LoadInstantMessenger()
            Dim MediumId As Integer = 6 'IM

            lblInMessanger00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblInMessanger01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblInMessanger02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblInMessanger03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblInMessanger04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblInMessanger05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblInMessanger06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblInMessanger07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblInMessanger08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblInMessanger09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblInMessanger10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblInMessanger11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblInMessanger12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblInMessanger13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblInMessanger14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblInMessanger15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblInMessanger16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblInMessanger17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblInMessanger18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblInMessanger19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblInMessanger20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblInMessanger21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblInMessanger22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblInMessanger23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)
            lblInMessangerTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesInstantMessenger = Chart1.Series("InstantMessenger")
            MyChartSeriesInstantMessenger.Points.Item(0).SetValueY(CInt(lblInMessanger00.Text))
            MyChartSeriesInstantMessenger.Points.Item(1).SetValueY(CInt(lblInMessanger01.Text))
            MyChartSeriesInstantMessenger.Points.Item(2).SetValueY(CInt(lblInMessanger02.Text))
            MyChartSeriesInstantMessenger.Points.Item(3).SetValueY(CInt(lblInMessanger03.Text))
            MyChartSeriesInstantMessenger.Points.Item(4).SetValueY(CInt(lblInMessanger04.Text))
            MyChartSeriesInstantMessenger.Points.Item(5).SetValueY(CInt(lblInMessanger05.Text))
            MyChartSeriesInstantMessenger.Points.Item(6).SetValueY(CInt(lblInMessanger06.Text))
            MyChartSeriesInstantMessenger.Points.Item(7).SetValueY(CInt(lblInMessanger07.Text))
            MyChartSeriesInstantMessenger.Points.Item(8).SetValueY(CInt(lblInMessanger08.Text))
            MyChartSeriesInstantMessenger.Points.Item(9).SetValueY(CInt(lblInMessanger09.Text))
            MyChartSeriesInstantMessenger.Points.Item(10).SetValueY(CInt(lblInMessanger10.Text))
            MyChartSeriesInstantMessenger.Points.Item(11).SetValueY(CInt(lblInMessanger11.Text))
            MyChartSeriesInstantMessenger.Points.Item(12).SetValueY(CInt(lblInMessanger12.Text))
            MyChartSeriesInstantMessenger.Points.Item(13).SetValueY(CInt(lblInMessanger13.Text))
            MyChartSeriesInstantMessenger.Points.Item(14).SetValueY(CInt(lblInMessanger14.Text))
            MyChartSeriesInstantMessenger.Points.Item(15).SetValueY(CInt(lblInMessanger15.Text))
            MyChartSeriesInstantMessenger.Points.Item(16).SetValueY(CInt(lblInMessanger16.Text))
            MyChartSeriesInstantMessenger.Points.Item(17).SetValueY(CInt(lblInMessanger17.Text))
            MyChartSeriesInstantMessenger.Points.Item(18).SetValueY(CInt(lblInMessanger18.Text))
            MyChartSeriesInstantMessenger.Points.Item(19).SetValueY(CInt(lblInMessanger19.Text))
            MyChartSeriesInstantMessenger.Points.Item(20).SetValueY(CInt(lblInMessanger20.Text))
            MyChartSeriesInstantMessenger.Points.Item(21).SetValueY(CInt(lblInMessanger21.Text))
            MyChartSeriesInstantMessenger.Points.Item(22).SetValueY(CInt(lblInMessanger22.Text))
            MyChartSeriesInstantMessenger.Points.Item(23).SetValueY(CInt(lblInMessanger23.Text))
        End Sub

        Private Sub LoadVideoConferencing()
            Dim MediumId As Integer = 9 'VC

            lblVc00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblVc01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblVc02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblVc03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblVc04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblVc05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblVc06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblVc07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblVc08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblVc09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblVc10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblVc11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblVc12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblVc13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblVc14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblVc15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblVc16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblVc17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblVc18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblVc19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblVc20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblVc21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblVc22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblVc23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)
            lblVcTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesInstantMessenger = Chart1.Series("VideoConferencing")
            MyChartSeriesInstantMessenger.Points.Item(0).SetValueY(CInt(lblVc00.Text))
            MyChartSeriesInstantMessenger.Points.Item(1).SetValueY(CInt(lblVc01.Text))
            MyChartSeriesInstantMessenger.Points.Item(2).SetValueY(CInt(lblVc02.Text))
            MyChartSeriesInstantMessenger.Points.Item(3).SetValueY(CInt(lblVc03.Text))
            MyChartSeriesInstantMessenger.Points.Item(4).SetValueY(CInt(lblVc04.Text))
            MyChartSeriesInstantMessenger.Points.Item(5).SetValueY(CInt(lblVc05.Text))
            MyChartSeriesInstantMessenger.Points.Item(6).SetValueY(CInt(lblVc06.Text))
            MyChartSeriesInstantMessenger.Points.Item(7).SetValueY(CInt(lblVc07.Text))
            MyChartSeriesInstantMessenger.Points.Item(8).SetValueY(CInt(lblVc08.Text))
            MyChartSeriesInstantMessenger.Points.Item(9).SetValueY(CInt(lblVc09.Text))
            MyChartSeriesInstantMessenger.Points.Item(10).SetValueY(CInt(lblVc10.Text))
            MyChartSeriesInstantMessenger.Points.Item(11).SetValueY(CInt(lblVc11.Text))
            MyChartSeriesInstantMessenger.Points.Item(12).SetValueY(CInt(lblVc12.Text))
            MyChartSeriesInstantMessenger.Points.Item(13).SetValueY(CInt(lblVc13.Text))
            MyChartSeriesInstantMessenger.Points.Item(14).SetValueY(CInt(lblVc14.Text))
            MyChartSeriesInstantMessenger.Points.Item(15).SetValueY(CInt(lblVc15.Text))
            MyChartSeriesInstantMessenger.Points.Item(16).SetValueY(CInt(lblVc16.Text))
            MyChartSeriesInstantMessenger.Points.Item(17).SetValueY(CInt(lblVc17.Text))
            MyChartSeriesInstantMessenger.Points.Item(18).SetValueY(CInt(lblVc18.Text))
            MyChartSeriesInstantMessenger.Points.Item(19).SetValueY(CInt(lblVc19.Text))
            MyChartSeriesInstantMessenger.Points.Item(20).SetValueY(CInt(lblVc20.Text))
            MyChartSeriesInstantMessenger.Points.Item(21).SetValueY(CInt(lblVc21.Text))
            MyChartSeriesInstantMessenger.Points.Item(22).SetValueY(CInt(lblVc22.Text))
            MyChartSeriesInstantMessenger.Points.Item(23).SetValueY(CInt(lblVc23.Text))
        End Sub

        Private Sub LoadOthers()
            Dim MediumId As Integer = 7 'Others

            lblOther00.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 0), MyAppConnectionString)
            lblOther01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 1), MyAppConnectionString)
            lblOther02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 2), MyAppConnectionString)
            lblOther03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 3), MyAppConnectionString)
            lblOther04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 4), MyAppConnectionString)
            lblOther05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 5), MyAppConnectionString)
            lblOther06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 6), MyAppConnectionString)
            lblOther07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 7), MyAppConnectionString)
            lblOther08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 8), MyAppConnectionString)
            lblOther09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 9), MyAppConnectionString)
            lblOther10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 10), MyAppConnectionString)
            lblOther11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 11), MyAppConnectionString)
            lblOther12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 12), MyAppConnectionString)
            lblOther13.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 13), MyAppConnectionString)
            lblOther14.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 14), MyAppConnectionString)
            lblOther15.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 15), MyAppConnectionString)
            lblOther16.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 16), MyAppConnectionString)
            lblOther17.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 17), MyAppConnectionString)
            lblOther18.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 18), MyAppConnectionString)
            lblOther19.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 19), MyAppConnectionString)
            lblOther20.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 20), MyAppConnectionString)
            lblOther21.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 21), MyAppConnectionString)
            lblOther22.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 22), MyAppConnectionString)
            lblOther23.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumHour(MediumId, 23), MyAppConnectionString)
            lblOtherTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesOthers = Chart1.Series("Others")
            MyChartSeriesOthers.Points.Item(0).SetValueY(CInt(lblOther00.Text))
            MyChartSeriesOthers.Points.Item(1).SetValueY(CInt(lblOther01.Text))
            MyChartSeriesOthers.Points.Item(2).SetValueY(CInt(lblOther02.Text))
            MyChartSeriesOthers.Points.Item(3).SetValueY(CInt(lblOther03.Text))
            MyChartSeriesOthers.Points.Item(4).SetValueY(CInt(lblOther04.Text))
            MyChartSeriesOthers.Points.Item(5).SetValueY(CInt(lblOther05.Text))
            MyChartSeriesOthers.Points.Item(6).SetValueY(CInt(lblOther06.Text))
            MyChartSeriesOthers.Points.Item(7).SetValueY(CInt(lblOther07.Text))
            MyChartSeriesOthers.Points.Item(8).SetValueY(CInt(lblOther08.Text))
            MyChartSeriesOthers.Points.Item(9).SetValueY(CInt(lblOther09.Text))
            MyChartSeriesOthers.Points.Item(10).SetValueY(CInt(lblOther10.Text))
            MyChartSeriesOthers.Points.Item(11).SetValueY(CInt(lblOther11.Text))
            MyChartSeriesOthers.Points.Item(12).SetValueY(CInt(lblOther12.Text))
            MyChartSeriesOthers.Points.Item(13).SetValueY(CInt(lblOther13.Text))
            MyChartSeriesOthers.Points.Item(14).SetValueY(CInt(lblOther14.Text))
            MyChartSeriesOthers.Points.Item(15).SetValueY(CInt(lblOther15.Text))
            MyChartSeriesOthers.Points.Item(16).SetValueY(CInt(lblOther16.Text))
            MyChartSeriesOthers.Points.Item(17).SetValueY(CInt(lblOther17.Text))
            MyChartSeriesOthers.Points.Item(18).SetValueY(CInt(lblOther18.Text))
            MyChartSeriesOthers.Points.Item(19).SetValueY(CInt(lblOther19.Text))
            MyChartSeriesOthers.Points.Item(20).SetValueY(CInt(lblOther20.Text))
            MyChartSeriesOthers.Points.Item(21).SetValueY(CInt(lblOther21.Text))
            MyChartSeriesOthers.Points.Item(22).SetValueY(CInt(lblOther22.Text))
            MyChartSeriesOthers.Points.Item(23).SetValueY(CInt(lblOther23.Text))
        End Sub

        Private Sub LoadTotalHour()
            lblTotalHour00.Text = CInt(lblFace00.Text) + CInt(lblChat00.Text) + CInt(lblPhone00.Text) + CInt(lblEmail00.Text) + CInt(lblSocial00.Text) + CInt(lblInMessanger00.Text) + CInt(lblVc00.Text) + CInt(lblOther00.Text)
            lblTotalHour01.Text = CInt(lblFace01.Text) + CInt(lblChat01.Text) + CInt(lblPhone01.Text) + CInt(lblEmail01.Text) + CInt(lblSocial01.Text) + CInt(lblInMessanger01.Text) + CInt(lblVc01.Text) + CInt(lblOther01.Text)
            lblTotalHour02.Text = CInt(lblFace02.Text) + CInt(lblChat02.Text) + CInt(lblPhone02.Text) + CInt(lblEmail02.Text) + CInt(lblSocial02.Text) + CInt(lblInMessanger02.Text) + CInt(lblVc02.Text) + CInt(lblOther02.Text)
            lblTotalHour03.Text = CInt(lblFace03.Text) + CInt(lblChat03.Text) + CInt(lblPhone03.Text) + CInt(lblEmail03.Text) + CInt(lblSocial03.Text) + CInt(lblInMessanger03.Text) + CInt(lblVc03.Text) + CInt(lblOther03.Text)
            lblTotalHour04.Text = CInt(lblFace04.Text) + CInt(lblChat04.Text) + CInt(lblPhone04.Text) + CInt(lblEmail04.Text) + CInt(lblSocial04.Text) + CInt(lblInMessanger04.Text) + CInt(lblVc04.Text) + CInt(lblOther04.Text)
            lblTotalHour05.Text = CInt(lblFace05.Text) + CInt(lblChat05.Text) + CInt(lblPhone05.Text) + CInt(lblEmail05.Text) + CInt(lblSocial05.Text) + CInt(lblInMessanger05.Text) + CInt(lblVc05.Text) + CInt(lblOther05.Text)
            lblTotalHour06.Text = CInt(lblFace06.Text) + CInt(lblChat06.Text) + CInt(lblPhone06.Text) + CInt(lblEmail06.Text) + CInt(lblSocial06.Text) + CInt(lblInMessanger06.Text) + CInt(lblVc06.Text) + CInt(lblOther06.Text)
            lblTotalHour07.Text = CInt(lblFace07.Text) + CInt(lblChat07.Text) + CInt(lblPhone07.Text) + CInt(lblEmail07.Text) + CInt(lblSocial07.Text) + CInt(lblInMessanger07.Text) + CInt(lblVc07.Text) + CInt(lblOther07.Text)
            lblTotalHour08.Text = CInt(lblFace08.Text) + CInt(lblChat08.Text) + CInt(lblPhone08.Text) + CInt(lblEmail08.Text) + CInt(lblSocial08.Text) + CInt(lblInMessanger08.Text) + CInt(lblVc08.Text) + CInt(lblOther08.Text)
            lblTotalHour09.Text = CInt(lblFace09.Text) + CInt(lblChat09.Text) + CInt(lblPhone09.Text) + CInt(lblEmail09.Text) + CInt(lblSocial09.Text) + CInt(lblInMessanger09.Text) + CInt(lblVc09.Text) + CInt(lblOther09.Text)
            lblTotalHour10.Text = CInt(lblFace10.Text) + CInt(lblChat10.Text) + CInt(lblPhone10.Text) + CInt(lblEmail10.Text) + CInt(lblSocial10.Text) + CInt(lblInMessanger10.Text) + CInt(lblVc10.Text) + CInt(lblOther10.Text)
            lblTotalHour11.Text = CInt(lblFace11.Text) + CInt(lblChat11.Text) + CInt(lblPhone11.Text) + CInt(lblEmail11.Text) + CInt(lblSocial11.Text) + CInt(lblInMessanger11.Text) + CInt(lblVc11.Text) + CInt(lblOther11.Text)
            lblTotalHour12.Text = CInt(lblFace12.Text) + CInt(lblChat12.Text) + CInt(lblPhone12.Text) + CInt(lblEmail12.Text) + CInt(lblSocial12.Text) + CInt(lblInMessanger12.Text) + CInt(lblVc12.Text) + CInt(lblOther12.Text)
            lblTotalHour13.Text = CInt(lblFace13.Text) + CInt(lblChat13.Text) + CInt(lblPhone13.Text) + CInt(lblEmail13.Text) + CInt(lblSocial13.Text) + CInt(lblInMessanger13.Text) + CInt(lblVc13.Text) + CInt(lblOther13.Text)
            lblTotalHour14.Text = CInt(lblFace14.Text) + CInt(lblChat14.Text) + CInt(lblPhone14.Text) + CInt(lblEmail14.Text) + CInt(lblSocial14.Text) + CInt(lblInMessanger14.Text) + CInt(lblVc14.Text) + CInt(lblOther14.Text)
            lblTotalHour15.Text = CInt(lblFace15.Text) + CInt(lblChat15.Text) + CInt(lblPhone15.Text) + CInt(lblEmail15.Text) + CInt(lblSocial15.Text) + CInt(lblInMessanger15.Text) + CInt(lblVc15.Text) + CInt(lblOther15.Text)
            lblTotalHour16.Text = CInt(lblFace16.Text) + CInt(lblChat16.Text) + CInt(lblPhone16.Text) + CInt(lblEmail16.Text) + CInt(lblSocial16.Text) + CInt(lblInMessanger16.Text) + CInt(lblVc16.Text) + CInt(lblOther16.Text)
            lblTotalHour17.Text = CInt(lblFace17.Text) + CInt(lblChat17.Text) + CInt(lblPhone17.Text) + CInt(lblEmail17.Text) + CInt(lblSocial17.Text) + CInt(lblInMessanger17.Text) + CInt(lblVc17.Text) + CInt(lblOther17.Text)
            lblTotalHour18.Text = CInt(lblFace18.Text) + CInt(lblChat18.Text) + CInt(lblPhone18.Text) + CInt(lblEmail18.Text) + CInt(lblSocial18.Text) + CInt(lblInMessanger18.Text) + CInt(lblVc18.Text) + CInt(lblOther18.Text)
            lblTotalHour19.Text = CInt(lblFace19.Text) + CInt(lblChat19.Text) + CInt(lblPhone19.Text) + CInt(lblEmail19.Text) + CInt(lblSocial19.Text) + CInt(lblInMessanger19.Text) + CInt(lblVc19.Text) + CInt(lblOther19.Text)
            lblTotalHour20.Text = CInt(lblFace20.Text) + CInt(lblChat20.Text) + CInt(lblPhone20.Text) + CInt(lblEmail20.Text) + CInt(lblSocial20.Text) + CInt(lblInMessanger20.Text) + CInt(lblVc20.Text) + CInt(lblOther20.Text)
            lblTotalHour21.Text = CInt(lblFace21.Text) + CInt(lblChat21.Text) + CInt(lblPhone21.Text) + CInt(lblEmail21.Text) + CInt(lblSocial21.Text) + CInt(lblInMessanger21.Text) + CInt(lblVc21.Text) + CInt(lblOther21.Text)
            lblTotalHour22.Text = CInt(lblFace22.Text) + CInt(lblChat22.Text) + CInt(lblPhone22.Text) + CInt(lblEmail22.Text) + CInt(lblSocial22.Text) + CInt(lblInMessanger22.Text) + CInt(lblVc22.Text) + CInt(lblOther22.Text)
            lblTotalHour23.Text = CInt(lblFace23.Text) + CInt(lblChat23.Text) + CInt(lblPhone23.Text) + CInt(lblEmail23.Text) + CInt(lblSocial23.Text) + CInt(lblInMessanger23.Text) + CInt(lblVc23.Text) + CInt(lblOther23.Text)

            lblTotalHours.Text = CInt(lblFaceTotal.Text) + CInt(lblChatTotal.Text) + CInt(lblPhoneTotal.Text) + CInt(lblEmailTotal.Text) + CInt(lblSocialTotal.Text) + CInt(lblInMessangerTotal.Text) + CInt(lblVcTotal.Text) + CInt(lblOtherTotal.Text)

        End Sub

        Private Sub LoadSubjectEnquiry()
            'Subjects
            lblSubOd.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_od, True), MyAppConnectionString)
            lblSubDc.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_dc, True), MyAppConnectionString)
            lblSubIt.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_it, True), MyAppConnectionString)
            lblSubOp.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_op, True), MyAppConnectionString)
            lblSubLrc.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_lrc, True), MyAppConnectionString)
            lblSubRc.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_rc, True), MyAppConnectionString)
            lblSubFs.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_fs, True), MyAppConnectionString)
            lblSubVp.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_vp, True), MyAppConnectionString)
            lblSubJa.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_ja, True), MyAppConnectionString)
            lblSubGt.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_gt, True), MyAppConnectionString)
            lblSubEt.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.sub_etc, True), MyAppConnectionString)

            lblSubTotal.Text = CInt(CInt(lblSubOd.Text) + CInt(lblSubDc.Text) + CInt(lblSubIt.Text) + CInt(lblSubOp.Text) + CInt(lblSubLrc.Text) + CInt(lblSubRc.Text) + CInt(lblSubFs.Text) + CInt(lblSubVp.Text) + CInt(lblSubJa.Text) + CInt(lblSubGt.Text) + CInt(lblSubEt.Text))

            'Enquiries
            lblEnqQr.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.enq_qr, True), MyAppConnectionString)
            lblEnqRr.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.enq_rr, True), MyAppConnectionString)
            lblEnqSt.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.enq_st, True), MyAppConnectionString)
            lblEnqAg.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.enq_ag, True), MyAppConnectionString)
            lblEnqEtc.Text = MyCmd.CmdCount(TableName, MyCriteriaSubjectEnquiry(eFieldName.enq_etc, True), MyAppConnectionString)

            lblEnqTotal.Text = CInt(CInt(lblEnqQr.Text) + CInt(lblEnqRr.Text) + CInt(lblEnqSt.Text) + CInt(lblEnqAg.Text) + CInt(lblEnqEtc.Text))

        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadTables()
            Message()
        End Sub

    End Class

End Namespace

