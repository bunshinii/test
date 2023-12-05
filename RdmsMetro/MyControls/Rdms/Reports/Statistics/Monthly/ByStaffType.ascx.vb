
Imports NasLib.Database.MySql.Sql.Simplifier
Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Reports.Statistics.Monthly
    Public Class ByStaffType
        Inherits System.Web.UI.UserControl

        Private Function TheDate() As Date
            Dim MyDateStr As String = MyRequest.GetDate
            Dim TheDate_ As Date = Now
            If IsDate(MyDateStr) Then TheDate_ = MyDateStr

            Return TheDate_
        End Function

#Region "MySql Table Setting"
        Dim MyCmd As New NasLib.Database.MySql.Sql.Commands
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

#End Region

#Region "Criterias"

        Private Function MyCriteria(TheDate As Date) As String
            Dim ReturnValue As String = CriteriasAND( _
                Criteria(FunctionMonth(eFieldName.timeStart.ToString), Month(TheDate)), _
                Criteria(FunctionYear(eFieldName.timeStart.ToString), Year(TheDate)), _
                CriteriaNot(eFieldName.stafTypeCode.ToString, "0")
                )

            If CriteriaFromQueryString.Length > 0 Then ReturnValue = ReturnValue & " AND " & CriteriaFromQueryString()
            Return ReturnValue
        End Function

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

        Private Sub LoadTable()
            Dim MyFields As String = FieldNames( _
                eFieldName.stafTypeCode.ToString, _
                FunctionCount(eFieldName.id.ToString, "'total'") _
                )

            Dim MyOther As String = GroupBy(eFieldName.stafTypeCode.ToString) & OrderBy("'total'", False)

            Dim MyTable As DataTable = MyCmd.CmdSelectTable2(TableName, MyFields, MyCriteria(TheDate), MyOther, MyAppConnectionString)

            GridView1.DataSource = MyTable
            GridView1.DataBind()
            If GridView1.Rows.Count > 0 Then
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader

                'Total Footer
                GridView1.FooterRow.BackColor = System.Drawing.Color.Beige
                GridView1.FooterRow.Cells(0).Text = "Total"
                GridView1.FooterRow.Cells(0).Font.Bold = True
                GridView1.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
                GridView1.FooterRow.Cells(0).Attributes.Add("colspan", 2)
                GridView1.FooterRow.Attributes.Add("style", "border-top:2px solid black")
                GridView1.FooterRow.Cells(1).Visible = False
                GridView1.FooterRow.Cells(2).Visible = False
                GridView1.FooterRow.Cells(3).Font.Bold = True
                GridView1.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Right

                Dim TotalValue As Integer = 0

                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim lblTotal As Label = GridView1.Rows(i).Cells(3).FindControl("total")

                    If IsNumeric(lblTotal.Text) Then
                        TotalValue += CInt(lblTotal.Text)
                    End If
                Next

                GridView1.FooterRow.Cells(3).Text = TotalValue
            End If

        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadTable()
        End Sub

        Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim RowIndex As Integer = e.Row.RowIndex
                Dim lblCode As Label = e.Row.FindControl("stafTypeCode")

                'Patron Name
                Dim lblFullName As Label = e.Row.FindControl("fullname")
                lblFullName.Text = NasLib.Database.MySql.Provider.Table.UsersPositionType.Description(lblCode.Text, ProvidersConnectionString)

            End If
        End Sub

    End Class

End Namespace
