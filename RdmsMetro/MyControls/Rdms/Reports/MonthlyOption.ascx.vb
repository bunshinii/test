Imports NasLib.Functions.Controls.DataTableTo
Imports NasLib.Functions.Web.QueryString
Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyControls.Rdms.Reports

    Public Class MonthlyOption
        Inherits System.Web.UI.UserControl


#Region "Public Properties"

        Public Property VirtualRedirectPath As String
            Get
                Return gVirtualRedirectPath.Text
            End Get
            Set(value As String)
                gVirtualRedirectPath.Text = value
            End Set
        End Property

        Public Property IsHourly As Boolean
            Get
                Return chkHourDislplay.Checked
            End Get
            Set(value As Boolean)
                chkHourDislplay.Checked = value
            End Set
        End Property

        Public Property DisplayHourlyOption As Boolean
            Get
                Return PanelHourlyDisplay.Visible
            End Get
            Set(value As Boolean)
                PanelHourlyDisplay.Visible = value
            End Set
        End Property

        Public Property DisplayStatisticOption As Boolean
            Get
                Return PanelDisplay.Visible
            End Get
            Set(value As Boolean)
                PanelDisplay.Visible = value
            End Set
        End Property

#End Region

#Region "Statistic Option Query String"

        Private Function GenerateStatsOptionQueryString() As String
            Dim ReturnValue As String = ""

            'Controls
            Dim MyKeys() As String = { _
                  MyRequest._chkPatron, _
                  MyRequest._chkStudFaculty, _
                  MyRequest._chkStudProgram, _
                  MyRequest._chkStudCampus, _
                  MyRequest._chkStudLevel, _
                  MyRequest._chkStudMode, _
                  MyRequest._chkStafDept, _
                  MyRequest._chkStafType, _
                  MyRequest._chkOfficer, _
                  MyRequest._chkBranch, _
                  MyRequest._chkSatellite, _
                  MyRequest._chkDepartment, _
                  MyRequest._chkDivision, _
                  MyRequest._chkUnit _
                }

            Dim MyValues() As String = { _
                chkPatron.Checked, _
                chkStudFaculty.Checked, _
                chkStudProgram.Checked, _
                chkStudCampus.Checked, _
                chkStudLevel.Checked, _
                chkStudMode.Checked, _
                chkStafDept.Checked, _
                chkStafType.Checked, _
                chkOfficer.Checked, _
                chkBranch.Checked, _
                chkSatellite.Checked, _
                chkDepartment.Checked, _
                chkDivision.Checked, _
                chkUnit.Checked _
                }

            ModifyQueryStringValue(ReturnValue, MyKeys, MyValues)

            Return ReturnValue
        End Function


#End Region


#Region "Functions"

        Private Sub LoadNonPostBackData()
            FillDdMonth()
            FillDdYear()

            lblFullname.Text = MyFullName
            FillDdBranch()
            FillDdSatellite()
            FillDdDepartment()
            FillDdDivision()
            FillDdUnit()

            FillDdStudBranch()
            FillDdStudFaculty()
            FillDdStudLevel()
            FillDdStudMode()
            FillDdStafType()
        End Sub

#Region "Fill Data"

        Private Sub FillData()

            'Date
            Dim MyDateStr As String = MyRequest.GetDate
            If MyDateStr.Length = 0 Then Exit Sub

            chkHourDislplay.Checked = MyRequest.GetHourlyDisplayEnabled

            Dim TheDate As Date = MyDateStr
            'txtDate.Text = Format(TheDate, "MMMM yyyy")
            ddMonth.SelectedValue = Month(TheDate)
            ddYear.SelectedValue = Year(TheDate)

            'Listing Mode
            'No need autopostback load becoz the dropdown here are preload
            ddListType.SelectedIndex = MyRequest.GetListingModeIndex
            ddBranch.SelectedValue = MyRequest.GetBranchId
            ddSatellite.SelectedValue = MyRequest.GetSatelliteId
            ddDepartment.SelectedValue = MyRequest.GetDepartmentId
            ddDivision.SelectedValue = MyRequest.GetDivisionId
            ddUnit.SelectedValue = MyRequest.GetUnitId

            ListingTypeVisibility()


            'Filter Type Enabled
            chkType.Checked = MyRequest.GetFilterModeEnabled
            ddFilter.Enabled = chkType.Checked

            'Filter Type
            If chkType.Checked Then
                ddFilter.SelectedIndex = MyRequest.GetFilterModeIndex

                Select Case ddFilter.SelectedValue

                    Case "Student Faculty"
                        FillDdStudFaculty()
                        ddStudFaculty.SelectedValue = MyRequest.GetStudFacultyCode
                    Case "Student Programme"

                        ddStudFaculty.SelectedValue = MyRequest.GetStudFacultyCode
                        FillDdStudProgram()
                        ddStudProgram.SelectedValue = MyRequest.GetStudProgramCode

                    Case "Student Campus"
                        ddStudBranch.SelectedValue = MyRequest.GetStudBranchId
                        FillDdStudCampus()
                        ddStudCampus.SelectedValue = MyRequest.GetStudCampusCode

                    Case "Student Level"
                        FillDdStudLevel()
                        ddStudLevel.SelectedValue = MyRequest.GetStudLevelCode
                    Case "Student Mode"
                        ddStudMode.SelectedValue = MyRequest.GetStudModeCode
                    Case "Staff Department"
                        ddStudBranch.SelectedValue = MyRequest.GetStudBranchId
                        FillDdStafDepartment()
                        ddStafDepartment.SelectedValue = MyRequest.GetStafDepartmentCode
                    Case "Staff Type"
                        ddStafType.SelectedValue = MyRequest.GetStafTypeCode
                End Select

            End If

            FilterTypeVisibility()
            SqlCommand = GenerateSqlCommands()

            FillStatsOption()
        End Sub

        Private Sub FillStatsOption()
            chkPatron.Checked = MyRequest.GetChkPatron
            chkStudFaculty.Checked = MyRequest.GetChkStudFaculty
            chkStudProgram.Checked = MyRequest.GetChkStudProgram
            chkStudCampus.Checked = MyRequest.GetChkStudCampus
            chkStudLevel.Checked = MyRequest.GetChkStudLevel
            chkStudMode.Checked = MyRequest.GetChkStudMode
            chkStafDept.Checked = MyRequest.GetChkStafDept
            chkStafType.Checked = MyRequest.GetChkStafType
            chkOfficer.Checked = MyRequest.GetChkOfficer
            chkBranch.Checked = MyRequest.GetChkBranch
            chkSatellite.Checked = MyRequest.GetChkSatellite
            chkDepartment.Checked = MyRequest.GetChkDepartment
            chkDivision.Checked = MyRequest.GetChkDivision
            chkUnit.Checked = MyRequest.GetChkUnit
        End Sub

#End Region

#Region "Visibility"

        Private Sub ListingTypeVisibility()
            If Not IsPostBack Then ddListType.SelectedIndex = MyRequest.GetListingModeIndex

            Select Case ddListType.SelectedValue
                Case "Individual"
                    'lblFullname.Text = MyFullName

                    lblFullname.Visible = True
                    ddBranch.Visible = False
                    ddSatellite.Visible = False
                    ddDepartment.Visible = False
                    ddDivision.Visible = False
                    ddUnit.Visible = False
                Case "Branch"
                    'FillDdBranch()

                    lblFullname.Visible = False
                    ddBranch.Visible = True
                    ddSatellite.Visible = False
                    ddDepartment.Visible = False
                    ddDivision.Visible = False
                    ddUnit.Visible = False


                Case "Satellite"
                    'FillDdSatellite()

                    lblFullname.Visible = False
                    ddBranch.Visible = False
                    ddSatellite.Visible = True
                    ddDepartment.Visible = False
                    ddDivision.Visible = False
                    ddUnit.Visible = False


                Case "Department"
                    'FillDdDepartment()

                    lblFullname.Visible = False
                    ddBranch.Visible = False
                    ddSatellite.Visible = False
                    ddDepartment.Visible = True
                    ddDivision.Visible = False
                    ddUnit.Visible = False


                Case "Division"
                    'FillDdDivision()

                    lblFullname.Visible = False
                    ddBranch.Visible = False
                    ddSatellite.Visible = False
                    ddDepartment.Visible = False
                    ddDivision.Visible = True
                    ddUnit.Visible = False


                Case "Unit"
                    'FillDdUnit()

                    lblFullname.Visible = False
                    ddBranch.Visible = False
                    ddSatellite.Visible = False
                    ddDepartment.Visible = False
                    ddDivision.Visible = False
                    ddUnit.Visible = True

            End Select
        End Sub

        Private Sub FilterTypeVisibility()

            Select Case ddFilter.SelectedValue
                Case "0"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                Case "Student Faculty"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = True
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                    ddStudFaculty.AutoPostBack = False

                Case "Student Programme"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = True
                    ddStudProgram.Visible = True
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                    ddStudFaculty.AutoPostBack = True
                    'FillDdStudProgram()

                Case "Student Campus"
                    ddStudBranch.Visible = True

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = True
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                    'FillDdStudCampus()

                Case "Student Level"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = True
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                Case "Student Mode"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = True
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = False

                Case "Staff Department"
                    ddStudBranch.Visible = True

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = True
                    ddStafType.Visible = False

                    'FillDdStafDepartment()

                Case "Staff Type"
                    ddStudBranch.Visible = False

                    ddStudFaculty.Visible = False
                    ddStudProgram.Visible = False
                    ddStudCampus.Visible = False
                    ddStudLevel.Visible = False
                    ddStudMode.Visible = False
                    ddStafDepartment.Visible = False
                    ddStafType.Visible = True

            End Select
        End Sub

#End Region

#Region "Dropdowns"

#Region "Month Year"

        Private Sub FillDdMonth()
            For i As Integer = 1 To 12
                Dim MyListItem As New ListItem
                MyListItem.Text = MonthName(i)
                MyListItem.Value = i

                ddMonth.Items.Add(MyListItem)
            Next
        End Sub

        Private Sub FillDdYear()
            Dim MinYear As Integer = MyModules.Database.RdmsQuestions.GetMinYear
            Dim MaxYear As Integer = Year(Now)

            For i As Integer = MinYear To MaxYear
                ddYear.Items.Add(i)
            Next

        End Sub

#End Region

#Region "Listing Type"

        Private Sub FillDdBranch()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
            ToDropDownList(MyTable, ddBranch, 0, 1, " -- Select Branch -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdSatellite()
            Dim BranchId As Integer = MyBranchId
            ddSatellite.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeSatellite.GetSatellitesByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddSatellite, 0, 2, " -- Select Satellite -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdDepartment()
            Dim BranchId As Integer = MyBranchId
            ddDepartment.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDepartment.GetDepartmentsByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddDepartment, 0, 2, " -- Select Department -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdDivision()
            Dim DepartmentId As Integer = MyDepartmentId
            ddDivision.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDivision.GetDivisionsByDepartmentId(DepartmentId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddDivision, 0, 2, " -- Select Division -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdUnit()
            Dim DivisionId As Integer = MyDivisionId
            ddUnit.Items.Clear()

            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeUnit.GetUnitsByDivisionId(DivisionId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddUnit, 0, 2, " -- Select Unit -- ")
            MyTable.Dispose()
        End Sub

#End Region

#Region "Filter Type"

        Private Sub FillDdStudFaculty()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudFaculty.GetAllFaculties(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudFaculty, 1, 2, " -- Select Faculty -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStudProgram()
            Dim FacultyCode As String = ddStudFaculty.SelectedValue
            ddStudProgram.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudProgram.GetAllPrograms(ddStudFaculty.SelectedValue, ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudProgram, 1, 2, " -- Select Programme -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStudBranch()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudBranch, 0, 1, " -- Select Branch -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStudCampus()
            Dim BranchId As String = ddStudBranch.SelectedValue
            ddStudCampus.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudCampus.GetCampusesByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudCampus, 1, 2, " -- Select Campus -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStudLevel()
            ddStudLevel.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudProgramLevel.GetAllLevels(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudLevel, 1, 2, " -- Select Programme Level -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStudMode()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StudMode.GetAllModes(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStudMode, 1, 2, " -- Select Study Mode -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStafDepartment()
            Dim BranchId As Integer = ddStudBranch.SelectedValue 'Share the Student Dropdown
            ddStafDepartment.Items.Clear()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.StafDepartment.GetDeptsByBranchId(BranchId, ProvidersConnectionString)
            ToDropDownList(MyTable, ddStafDepartment, 1, 2, " -- Select Staff Department -- ")
            MyTable.Dispose()
        End Sub

        Private Sub FillDdStafType()
            Dim MyTable As DataTable = NasLib.Database.MySql.Provider.Table.UsersPositionType.GetAllPositionTypes(ProvidersConnectionString)
            ToDropDownList(MyTable, ddStafType, 1, 2, " -- Select Staff Type -- ")
            MyTable.Dispose()
        End Sub

#End Region

#End Region

#Region "Generate Query Strings"

        ''' <summary>
        ''' Add / Get additional query string
        ''' </summary>
        Public Property QueryString As String
            Get
                Return gQueryString.Text
            End Get
            Set(value As String)
                gQueryString.Text = value
            End Set
        End Property

        Private Function GenerateQueryString() As String
            Dim ReturnValue As String = QueryString & GenerateStatsOptionQueryString()

            'Basic
            Dim MyDate As Date = String.Format("{0}-{1}-{2}", "01", ddMonth.SelectedItem.Text, ddYear.SelectedValue)
            Dim MyKeys2() As String = {MyRequest._Year, MyRequest._Month, MyRequest._Day, MyRequest._ListingMode, MyRequest._FilterMode, MyRequest._FilterModeEnabled, MyRequest._HourlyDisplayEnabled}
            Dim MyValues2() As String = {Year(MyDate), Month(MyDate), Day(MyDate), ddListType.SelectedIndex, ddFilter.SelectedIndex, chkType.Checked, chkHourDislplay.Checked}
            ModifyQueryStringValue(ReturnValue, MyKeys2, MyValues2)

            'Controls
            Dim MyKeys() As String = { _
                MyRequest._ListingMode, _
                MyRequest._OfficerId, _
                MyRequest._BranchId, _
                MyRequest._SatelliteId, _
                MyRequest._DepartmentId, _
                MyRequest._DivisionId, _
                MyRequest._UnitId, _
                MyRequest._FilterModeEnabled, _
                MyRequest._FilterMode, _
                MyRequest._StudBranchId, _
                MyRequest._StudFacultyCode, _
                MyRequest._StudProgramCode, _
                MyRequest._StudCampusCode, _
                MyRequest._StudLevelCode, _
                MyRequest._StudModeCode, _
                MyRequest._StafDepartmentCode, _
                MyRequest._StafTypeCode _
                }

            Dim MyValues() As String = { _
                ddListType.SelectedIndex, _
                MyOwnId,
                ddBranch.SelectedValue, _
                ddSatellite.SelectedValue, _
                ddDepartment.SelectedValue, _
                ddDivision.SelectedValue, _
                ddUnit.SelectedValue, _
                chkType.Checked, _
                ddFilter.SelectedIndex, _
                ddStudBranch.SelectedValue, _
                ddStudFaculty.SelectedValue, _
                ddStudProgram.SelectedValue, _
                ddStudCampus.SelectedValue, _
                ddStudLevel.SelectedValue, _
                ddStudMode.SelectedValue, _
                ddStafDepartment.SelectedValue, _
                ddStafType.SelectedValue _
                }

            ModifyQueryStringValue(ReturnValue, MyKeys, MyValues)

            Return ReturnValue
        End Function

#End Region

#Region "Generate MySQL Commands"

        Public Property SqlCommand As String
            Get
                Return gSqlCommand.Text
            End Get
            Set(value As String)
                gSqlCommand.Text = value
            End Set
        End Property

        Private Function GenerateSqlCommands() As String
            Dim MyCmd As New Sql.CommandString

            Dim MyFieldName As String = FieldNames(
                "sessionId", "patronId", "mediumId", "sub_od", "sub_dc", "sub_it", "sub_op", "sub_lrc", "sub_rc", "sub_fs", "sub_vp", "sub_ja", "sub_gt", "sub_etc", "enq_qr", "enq_rr",
                "enq_st", "enq_ag", "enq_etc", "timeStart", "duration", "officer")

            Dim MyCriteria As String = ""

            Select Case ddListType.SelectedValue
                Case "Individual"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("officer", MyRequest.GetOfficerId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria("officer", MyRequest.GetOfficerId), _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth) _
                            )
                    End If


                Case "Branch"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("branchId", MyRequest.GetBranchId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                            Criteria("branchId", MyRequest.GetBranchId)
                            )
                    End If

                Case "Satellite"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("satelliteId", MyRequest.GetSatelliteId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                            Criteria("satelliteId", MyRequest.GetSatelliteId)
                            )
                    End If

                Case "Department"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("departmentId", MyRequest.GetDepartmentId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                            Criteria("departmentId", MyRequest.GetDepartmentId)
                            )
                    End If

                Case "Division"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("divisionid", MyRequest.GetDivisionId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                            Criteria("divisionid", MyRequest.GetDivisionId)
                            )
                    End If

                Case "Unit"

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studFacultyCode", MyRequest.GetStudFacultyCode)
                                    )

                            Case "Student Programme"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studProgramCode", MyRequest.GetStudProgramCode)
                                    )

                            Case "Student Campus"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studCampusCode", MyRequest.GetStudCampusCode)
                                    )

                            Case "Student Level"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studLevelCode", MyRequest.GetStudLevelCode)
                                    )

                            Case "Student Mode"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("studModeCode", MyRequest.GetStudModeCode)
                                    )

                            Case "Staff Department"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafDeptCode", MyRequest.GetStafDepartmentCode)
                                    )

                            Case "Staff Type"
                                MyCriteria = CriteriasAND( _
                                    Criteria("unitId", MyRequest.GetUnitId), _
                                    Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                                    Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                                    Criteria("stafTypeCode", MyRequest.GetStafTypeCode)
                                    )

                        End Select

                    Else
                        MyCriteria = CriteriasAND( _
                            Criteria(FunctionYear("timeStart"), MyRequest.GetYear), _
                            Criteria(FunctionMonth("timeStart"), MyRequest.GetMonth), _
                            Criteria("unitId", MyRequest.GetUnitId)
                            )
                    End If

            End Select

            Return MyCmd.CmdSelectTable("rdms_questions", MyFieldName, MyCriteria)

        End Function


#End Region

#Region "Generate Message"

        Public Property Message As String
            Get
                Return gMessage.Text
            End Get
            Set(value As String)
                gMessage.Text = value
            End Set
        End Property

        Private Function GenerateMessage() As String
            Dim ReturnValue As String = ""
            Dim TheDate As String = MyRequest.GetDate
            Dim OfficerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(MyRequest.GetOfficerId, ProvidersConnectionString)

            Select Case ddListType.SelectedValue
                Case "Individual"
                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} by {1}", Format(CDate(TheDate), "MMMM yyyy"), OfficerName)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.SelectedItem.Text)
                        End Select

                    End If


                Case "Branch"

                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} in {1}", Format(CDate(TheDate), "MMMM yyyy"), ddBranch.SelectedItem.Text)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.Text)
                        End Select

                    End If

                Case "Satellite"


                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} in {1}", Format(CDate(TheDate), "MMMM yyyy"), ddSatellite.SelectedItem.Text)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.Text)
                        End Select

                    End If

                Case "Department"

                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} in {1}", Format(CDate(TheDate), "MMMM yyyy"), ddDepartment.SelectedItem.Text)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.SelectedItem.Text)
                        End Select

                    End If

                Case "Division"

                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} in {1}", Format(CDate(TheDate), "MMMM yyyy"), ddDivision.SelectedItem.Text)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.SelectedItem.Text)
                        End Select

                    End If

                Case "Unit"

                    If Not String.IsNullOrEmpty(TheDate) Then ReturnValue = String.Format("Reference Desk sessions on {0} in {1}", Format(CDate(TheDate), "MMMM yyyy"), ddUnit.SelectedItem.Text)

                    If chkType.Checked Then

                        Select Case ddFilter.SelectedValue

                            Case "Student Faculty"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Faculty : {0}", ddStudFaculty.SelectedItem.Text)
                            Case "Student Programme"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Programme : {0}", ddStudProgram.SelectedItem.Text)
                            Case "Student Campus"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Campus : {0}", ddStudCampus.SelectedItem.Text)
                            Case "Student Level"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Level : {0}", ddStudLevel.SelectedItem.Text)
                            Case "Student Mode"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Study Mode : {0}", ddStudMode.SelectedItem.Text)
                            Case "Staff Department"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Department : {0}", ddStafDepartment.SelectedItem.Text)
                            Case "Staff Type"
                                ReturnValue = ReturnValue & String.Format("<br>Filtered By Staff Type : {0}", ddStafType.SelectedItem.Text)
                        End Select

                    End If

            End Select

            Return ReturnValue
        End Function



#End Region

#End Region

#Region "Events"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then
                LoadNonPostBackData()
                ddMonth.SelectedValue = Month(Now)
                ddYear.SelectedValue = Year(Now)


                FillData()
                Message = GenerateMessage()
            End If

            'Print
            Dim MyUrl As String = NasLib.Functions.Web.Url.UpdateQueryStringValue(MyRequest._PrinterFriendly, True)
            a1.HRef = MyUrl
        End Sub

        Protected Sub chkType_CheckedChanged(sender As Object, e As EventArgs) Handles chkType.CheckedChanged
            If chkType.Checked Then
                ddFilter.Enabled = True
            Else
                ddFilter.SelectedIndex = 0
                FilterTypeVisibility()
                ddFilter.Enabled = False
            End If
        End Sub

        Private Sub ddListType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddListType.SelectedIndexChanged
            ListingTypeVisibility()
        End Sub

        Protected Sub ddFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddFilter.SelectedIndexChanged
            FilterTypeVisibility()
        End Sub

        Protected Sub ddStudFaculty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddStudFaculty.SelectedIndexChanged
            FillDdStudProgram()
        End Sub

        Protected Sub ddStudBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddStudBranch.SelectedIndexChanged
            If ddFilter.SelectedValue = "Student Campus" Then FillDdStudCampus()
            If ddFilter.SelectedValue = "Staff Department" Then FillDdStafDepartment()
        End Sub



        Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
            Response.Redirect(VirtualRedirectPath & "?" & GenerateQueryString(), True)
        End Sub

#End Region

    End Class

End Namespace