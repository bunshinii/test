Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyControls.Rdms.Charts

    Public Class ByYearMonthly
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

        Private Function MyCriteriaMediumMonth(MediumId As Integer, MonthNo As Integer) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(eFieldName.mediumId.ToString, MediumId), _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(FunctionMonth(eFieldName.timeStart.ToString), MonthNo))

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

        Private Function MyCriteriaTotalMonth(MonthNo As Integer) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                Criteria(FunctionMonth(eFieldName.timeStart.ToString), MonthNo))

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

            lblFace01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblFace02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblFace03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblFace04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblFace05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblFace06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblFace07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblFace08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblFace09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblFace10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblFace11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblFace12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)

            lblFaceTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesFaceToFace = Chart1.Series("Face2Face")
            MyChartSeriesFaceToFace.Points.Item(1 - 1).SetValueY(CInt(lblFace01.Text))
            MyChartSeriesFaceToFace.Points.Item(2 - 1).SetValueY(CInt(lblFace02.Text))
            MyChartSeriesFaceToFace.Points.Item(3 - 1).SetValueY(CInt(lblFace03.Text))
            MyChartSeriesFaceToFace.Points.Item(4 - 1).SetValueY(CInt(lblFace04.Text))
            MyChartSeriesFaceToFace.Points.Item(5 - 1).SetValueY(CInt(lblFace05.Text))
            MyChartSeriesFaceToFace.Points.Item(6 - 1).SetValueY(CInt(lblFace06.Text))
            MyChartSeriesFaceToFace.Points.Item(7 - 1).SetValueY(CInt(lblFace07.Text))
            MyChartSeriesFaceToFace.Points.Item(8 - 1).SetValueY(CInt(lblFace08.Text))
            MyChartSeriesFaceToFace.Points.Item(9 - 1).SetValueY(CInt(lblFace09.Text))
            MyChartSeriesFaceToFace.Points.Item(10 - 1).SetValueY(CInt(lblFace10.Text))
            MyChartSeriesFaceToFace.Points.Item(11 - 1).SetValueY(CInt(lblFace11.Text))
            MyChartSeriesFaceToFace.Points.Item(12 - 1).SetValueY(CInt(lblFace12.Text))
        End Sub

        Private Sub LoadLiveChat()
            Dim MediumId As Integer = 2 'Live Chat

            lblChat01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblChat02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblChat03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblChat04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblChat05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblChat06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblChat07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblChat08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblChat09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblChat10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblChat11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblChat12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)

            lblChatTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesChat = Chart1.Series("LiveChat")
            MyChartSeriesChat.Points.Item(1 - 1).SetValueY(CInt(lblChat01.Text))
            MyChartSeriesChat.Points.Item(2 - 1).SetValueY(CInt(lblChat02.Text))
            MyChartSeriesChat.Points.Item(3 - 1).SetValueY(CInt(lblChat03.Text))
            MyChartSeriesChat.Points.Item(4 - 1).SetValueY(CInt(lblChat04.Text))
            MyChartSeriesChat.Points.Item(5 - 1).SetValueY(CInt(lblChat05.Text))
            MyChartSeriesChat.Points.Item(6 - 1).SetValueY(CInt(lblChat06.Text))
            MyChartSeriesChat.Points.Item(7 - 1).SetValueY(CInt(lblChat07.Text))
            MyChartSeriesChat.Points.Item(8 - 1).SetValueY(CInt(lblChat08.Text))
            MyChartSeriesChat.Points.Item(9 - 1).SetValueY(CInt(lblChat09.Text))
            MyChartSeriesChat.Points.Item(10 - 1).SetValueY(CInt(lblChat10.Text))
            MyChartSeriesChat.Points.Item(11 - 1).SetValueY(CInt(lblChat11.Text))
            MyChartSeriesChat.Points.Item(12 - 1).SetValueY(CInt(lblChat12.Text))
        End Sub

        Private Sub LoadPhone()
            Dim MediumId As Integer = 3 'Phone

            lblPhone01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblPhone02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblPhone03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblPhone04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblPhone05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblPhone06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblPhone07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblPhone08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblPhone09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblPhone10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblPhone11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblPhone12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)

            lblPhoneTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesPhone = Chart1.Series("Phone")
            MyChartSeriesPhone.Points.Item(1 - 1).SetValueY(CInt(lblPhone01.Text))
            MyChartSeriesPhone.Points.Item(2 - 1).SetValueY(CInt(lblPhone02.Text))
            MyChartSeriesPhone.Points.Item(3 - 1).SetValueY(CInt(lblPhone03.Text))
            MyChartSeriesPhone.Points.Item(4 - 1).SetValueY(CInt(lblPhone04.Text))
            MyChartSeriesPhone.Points.Item(5 - 1).SetValueY(CInt(lblPhone05.Text))
            MyChartSeriesPhone.Points.Item(6 - 1).SetValueY(CInt(lblPhone06.Text))
            MyChartSeriesPhone.Points.Item(7 - 1).SetValueY(CInt(lblPhone07.Text))
            MyChartSeriesPhone.Points.Item(8 - 1).SetValueY(CInt(lblPhone08.Text))
            MyChartSeriesPhone.Points.Item(9 - 1).SetValueY(CInt(lblPhone09.Text))
            MyChartSeriesPhone.Points.Item(10 - 1).SetValueY(CInt(lblPhone10.Text))
            MyChartSeriesPhone.Points.Item(11 - 1).SetValueY(CInt(lblPhone11.Text))
            MyChartSeriesPhone.Points.Item(12 - 1).SetValueY(CInt(lblPhone12.Text))
        End Sub

        Private Sub LoadEmail()
            Dim MediumId As Integer = 4 'Email

            lblEmail01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblEmail02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblEmail03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblEmail04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblEmail05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblEmail06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblEmail07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblEmail08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblEmail09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblEmail10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblEmail11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblEmail12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)
            lblEmailTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesEmail = Chart1.Series("Email")
            MyChartSeriesEmail.Points.Item(1 - 1).SetValueY(CInt(lblEmail01.Text))
            MyChartSeriesEmail.Points.Item(2 - 1).SetValueY(CInt(lblEmail02.Text))
            MyChartSeriesEmail.Points.Item(3 - 1).SetValueY(CInt(lblEmail03.Text))
            MyChartSeriesEmail.Points.Item(4 - 1).SetValueY(CInt(lblEmail04.Text))
            MyChartSeriesEmail.Points.Item(5 - 1).SetValueY(CInt(lblEmail05.Text))
            MyChartSeriesEmail.Points.Item(6 - 1).SetValueY(CInt(lblEmail06.Text))
            MyChartSeriesEmail.Points.Item(7 - 1).SetValueY(CInt(lblEmail07.Text))
            MyChartSeriesEmail.Points.Item(8 - 1).SetValueY(CInt(lblEmail08.Text))
            MyChartSeriesEmail.Points.Item(9 - 1).SetValueY(CInt(lblEmail09.Text))
            MyChartSeriesEmail.Points.Item(10 - 1).SetValueY(CInt(lblEmail10.Text))
            MyChartSeriesEmail.Points.Item(11 - 1).SetValueY(CInt(lblEmail11.Text))
            MyChartSeriesEmail.Points.Item(12 - 1).SetValueY(CInt(lblEmail12.Text))
        End Sub

        Private Sub LoadSocialMedia()
            Dim MediumId As Integer = 5 'Social Media

            lblSocial01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblSocial02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblSocial03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblSocial04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblSocial05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblSocial06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblSocial07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblSocial08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblSocial09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblSocial10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblSocial11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblSocial12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)
            lblSocialTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesSocialMedia = Chart1.Series("SocialMedia")
            MyChartSeriesSocialMedia.Points.Item(1 - 1).SetValueY(CInt(lblSocial01.Text))
            MyChartSeriesSocialMedia.Points.Item(2 - 1).SetValueY(CInt(lblSocial02.Text))
            MyChartSeriesSocialMedia.Points.Item(3 - 1).SetValueY(CInt(lblSocial03.Text))
            MyChartSeriesSocialMedia.Points.Item(4 - 1).SetValueY(CInt(lblSocial04.Text))
            MyChartSeriesSocialMedia.Points.Item(5 - 1).SetValueY(CInt(lblSocial05.Text))
            MyChartSeriesSocialMedia.Points.Item(6 - 1).SetValueY(CInt(lblSocial06.Text))
            MyChartSeriesSocialMedia.Points.Item(7 - 1).SetValueY(CInt(lblSocial07.Text))
            MyChartSeriesSocialMedia.Points.Item(8 - 1).SetValueY(CInt(lblSocial08.Text))
            MyChartSeriesSocialMedia.Points.Item(9 - 1).SetValueY(CInt(lblSocial09.Text))
            MyChartSeriesSocialMedia.Points.Item(10 - 1).SetValueY(CInt(lblSocial10.Text))
            MyChartSeriesSocialMedia.Points.Item(11 - 1).SetValueY(CInt(lblSocial11.Text))
            MyChartSeriesSocialMedia.Points.Item(12 - 1).SetValueY(CInt(lblSocial12.Text))
        End Sub

        Private Sub LoadVideoConferencing()
            Dim MediumId As Integer = 9 'VC

            lblVc01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblVc02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblVc03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblVc04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblVc05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblVc06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblVc07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblVc08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblVc09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblVc10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblVc11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblVc12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)
            lblVcTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesInstantMessenger = Chart1.Series("VideoConferencing")
            MyChartSeriesInstantMessenger.Points.Item(1 - 1).SetValueY(CInt(lblVc01.Text))
            MyChartSeriesInstantMessenger.Points.Item(2 - 1).SetValueY(CInt(lblVc02.Text))
            MyChartSeriesInstantMessenger.Points.Item(3 - 1).SetValueY(CInt(lblVc03.Text))
            MyChartSeriesInstantMessenger.Points.Item(4 - 1).SetValueY(CInt(lblVc04.Text))
            MyChartSeriesInstantMessenger.Points.Item(5 - 1).SetValueY(CInt(lblVc05.Text))
            MyChartSeriesInstantMessenger.Points.Item(6 - 1).SetValueY(CInt(lblVc06.Text))
            MyChartSeriesInstantMessenger.Points.Item(7 - 1).SetValueY(CInt(lblVc07.Text))
            MyChartSeriesInstantMessenger.Points.Item(8 - 1).SetValueY(CInt(lblVc08.Text))
            MyChartSeriesInstantMessenger.Points.Item(9 - 1).SetValueY(CInt(lblVc09.Text))
            MyChartSeriesInstantMessenger.Points.Item(10 - 1).SetValueY(CInt(lblVc10.Text))
            MyChartSeriesInstantMessenger.Points.Item(11 - 1).SetValueY(CInt(lblVc11.Text))
            MyChartSeriesInstantMessenger.Points.Item(12 - 1).SetValueY(CInt(lblVc12.Text))
        End Sub

        Private Sub LoadInstantMessenger()
            Dim MediumId As Integer = 6 'IM

            lblInMessanger01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblInMessanger02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblInMessanger03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblInMessanger04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblInMessanger05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblInMessanger06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblInMessanger07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblInMessanger08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblInMessanger09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblInMessanger10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblInMessanger11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblInMessanger12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)
            lblInMessangerTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesInstantMessenger = Chart1.Series("InstantMessenger")
            MyChartSeriesInstantMessenger.Points.Item(1 - 1).SetValueY(CInt(lblInMessanger01.Text))
            MyChartSeriesInstantMessenger.Points.Item(2 - 1).SetValueY(CInt(lblInMessanger02.Text))
            MyChartSeriesInstantMessenger.Points.Item(3 - 1).SetValueY(CInt(lblInMessanger03.Text))
            MyChartSeriesInstantMessenger.Points.Item(4 - 1).SetValueY(CInt(lblInMessanger04.Text))
            MyChartSeriesInstantMessenger.Points.Item(5 - 1).SetValueY(CInt(lblInMessanger05.Text))
            MyChartSeriesInstantMessenger.Points.Item(6 - 1).SetValueY(CInt(lblInMessanger06.Text))
            MyChartSeriesInstantMessenger.Points.Item(7 - 1).SetValueY(CInt(lblInMessanger07.Text))
            MyChartSeriesInstantMessenger.Points.Item(8 - 1).SetValueY(CInt(lblInMessanger08.Text))
            MyChartSeriesInstantMessenger.Points.Item(9 - 1).SetValueY(CInt(lblInMessanger09.Text))
            MyChartSeriesInstantMessenger.Points.Item(10 - 1).SetValueY(CInt(lblInMessanger10.Text))
            MyChartSeriesInstantMessenger.Points.Item(11 - 1).SetValueY(CInt(lblInMessanger11.Text))
            MyChartSeriesInstantMessenger.Points.Item(12 - 1).SetValueY(CInt(lblInMessanger12.Text))
        End Sub

        Private Sub LoadOthers()
            Dim MediumId As Integer = 7 'Others

            lblOther01.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 1), MyAppConnectionString)
            lblOther02.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 2), MyAppConnectionString)
            lblOther03.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 3), MyAppConnectionString)
            lblOther04.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 4), MyAppConnectionString)
            lblOther05.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 5), MyAppConnectionString)
            lblOther06.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 6), MyAppConnectionString)
            lblOther07.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 7), MyAppConnectionString)
            lblOther08.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 8), MyAppConnectionString)
            lblOther09.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 9), MyAppConnectionString)
            lblOther10.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 10), MyAppConnectionString)
            lblOther11.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 11), MyAppConnectionString)
            lblOther12.Text = MyCmd.CmdCount(TableName, MyCriteriaMediumMonth(MediumId, 12), MyAppConnectionString)
            lblOtherTotal.Text = MyCmd.CmdCount(TableName, MyCriteriaTotalMedium(MediumId), MyAppConnectionString)

            Dim MyChartSeriesOthers = Chart1.Series("Others")
            MyChartSeriesOthers.Points.Item(1 - 1).SetValueY(CInt(lblOther01.Text))
            MyChartSeriesOthers.Points.Item(2 - 1).SetValueY(CInt(lblOther02.Text))
            MyChartSeriesOthers.Points.Item(3 - 1).SetValueY(CInt(lblOther03.Text))
            MyChartSeriesOthers.Points.Item(4 - 1).SetValueY(CInt(lblOther04.Text))
            MyChartSeriesOthers.Points.Item(5 - 1).SetValueY(CInt(lblOther05.Text))
            MyChartSeriesOthers.Points.Item(6 - 1).SetValueY(CInt(lblOther06.Text))
            MyChartSeriesOthers.Points.Item(7 - 1).SetValueY(CInt(lblOther07.Text))
            MyChartSeriesOthers.Points.Item(8 - 1).SetValueY(CInt(lblOther08.Text))
            MyChartSeriesOthers.Points.Item(9 - 1).SetValueY(CInt(lblOther09.Text))
            MyChartSeriesOthers.Points.Item(10 - 1).SetValueY(CInt(lblOther10.Text))
            MyChartSeriesOthers.Points.Item(11 - 1).SetValueY(CInt(lblOther11.Text))
            MyChartSeriesOthers.Points.Item(12 - 1).SetValueY(CInt(lblOther12.Text))
        End Sub

        Private Sub LoadTotalHour()
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

