Imports NasLib.Database.MySql.CustomProvider.DBLibrary

Namespace MyControls.Rdms.User.CheckIn.Search

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Functions"

        Public ReadOnly Property NewSessionId As String
            Get
                Return NasLib.Functions.String.Guids.NewStringGuid
            End Get
        End Property

        ''' <summary>
        ''' Set Background Color for student
        ''' </summary>
        ''' <param name="ProcessStatusCode">Obtained in DBLibrary "PROCESS_STATUS_CODE" from 'stud_activ'</param>
        Private Function StudentBgColor(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "bg-lightOrange"
            If ProcessStatusCode = "-1" Then ReturnValue = "bg-darkRed"

            Return ReturnValue
        End Function

        Private Function StudentActive(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "Active Student"
            If ProcessStatusCode = "-1" Then ReturnValue = "Student Not Active"

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Set Background Color for Staff
        ''' </summary>
        ''' <param name="ProcessStatusCode">Obtained in DBLibrary "BK_REKOD_STATUS" from 'staff_activ'</param>
        Private Function StaffBgColor(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "bg-darkBlue"
            If Not ProcessStatusCode = "1" Then ReturnValue = "bg-darkRed"

            Return ReturnValue
        End Function

        Private Function StaffActive(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "Active Staff"
            If Not ProcessStatusCode = "1" Then ReturnValue = "Staff Not Active"

            Return ReturnValue
        End Function


        Private Function CriteriaIndex() As Integer
            Dim ReturnValue As Integer = 0
            If rbPatronId.Checked Then ReturnValue = 1
            If rbPassport.Checked Then ReturnValue = 2
            If rbName.Checked Then ReturnValue = 3
            If rbAll.Checked Then ReturnValue = 0

            Return ReturnValue
        End Function

#Region "Search"

        Private Sub SearchAll()
            Dim StudentCount As Integer = Table.StudActiv.SearchUsersCount(txtSearch.Text, CriteriaIndex, DbLibraryConnectionString)
            Dim StaffCount As Integer = Table.StaffActiv.SearchUsersCount(txtSearch.Text, CriteriaIndex, DbLibraryConnectionString)
            Dim TotalResult As Integer = StudentCount + StaffCount

            Dim MaxDisplay As Integer = 100
            Dim MaxStudent As Integer = MaxDisplay / 2
            Dim MaxStaff As Integer = MaxDisplay / 2

            If StudentCount > MaxStudent And StaffCount < MaxStaff Then
                MaxStudent = MaxStudent + (MaxStaff - StaffCount)

            ElseIf StudentCount < MaxStudent And StaffCount > MaxStaff Then
                MaxStaff = MaxStaff + (MaxStudent - StudentCount)
            End If

            Dim StudentTable As DataTable = Table.StudActiv.SearchUsers(txtSearch.Text, CriteriaIndex, MaxStudent, DbLibraryConnectionString)
            Dim StaffTable As DataTable = Table.StaffActiv.SearchUsers(txtSearch.Text, CriteriaIndex, MaxStaff, DbLibraryConnectionString)
            Dim AllTable As DataTable = NasLib.Functions.DataTable.Merge.TwoTable(StudentTable, StaffTable)
            NasLib.Functions.DataTable.Row.Sort(AllTable, "NAME")

            
            'NAME, FACULTY_DESC, PROGRAM_DESC, STUDENTID, PROCESS_STATUS_CODE
            For i As Integer = 0 To AllTable.Rows.Count - 1
                Dim MyControl As MyControls.Rdms.User.CheckIn.Search.Item = DirectCast(LoadControl("~\MyControls\Rdms\User\CheckIn\Search\Item.ascx"), MyControls.Rdms.User.CheckIn.Search.Item)

                Dim PatronId As String = AllTable(i)("STUDENTID").ToString
                Dim StatusCode As String = AllTable(i)("PROCESS_STATUS_CODE").ToString

                If AllTable.Rows.Count = 1 Then Response.Redirect(String.Format("~/Pages/User/PatronCheckIn.aspx?patronid={0}&sessionid={1}", PatronId, NewSessionId), True)

                MyControl.PatronName = AllTable(i)("NAME").ToString.Trim
                MyControl.Program = AllTable(i)("PROGRAM_DESC").ToString.Trim
                MyControl.Faculty = AllTable(i)("FACULTY_DESC").ToString.Trim
                MyControl.PatronId = PatronId

                If Patron.IsStudent(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StudentBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StudentActive(StatusCode) & ")"
                ElseIf Patron.IsStaff(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StaffBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StaffActive(StatusCode) & ")"
                Else
                    MyControl.BackgroundColor = "darkCobalt"
                    MyControl.ToolTip = "Other"
                End If

                phItem.Controls.Add(MyControl)

            Next

            'Results
            Dim AllCount As Integer = AllTable.Rows.Count

            If AllCount >= 0 Then

                Dim MyResult As String = Nothing
                Select Case AllCount
                    Case 0
                        MyResult = "No Data"
                        lblResults.Text = MyResult
                    Case 1
                        MyResult = "Found {0} result."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case 2 To (MaxDisplay / 2) - 1
                        MyResult = "Found {0} results."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case Else
                        MyResult = "Displaying {0} results out of {1}."
                        lblResults.Text = String.Format(MyResult, AllCount, TotalResult)
                End Select

            End If

            If AllCount > 0 Then
                PanelLegend.Visible = True
            Else
                PanelLegend.Visible = False
            End If

            StudentTable.Dispose()
            StaffTable.Dispose()
            AllTable.Dispose()
        End Sub

        Private Sub SearchStaff()
            Dim StaffCount As Integer = Table.StaffActiv.SearchUsersCount(txtSearch.Text, CriteriaIndex, DbLibraryConnectionString)
            Dim TotalResult As Integer = StaffCount

            Dim MaxDisplay As Integer = 100

            Dim AllTable As DataTable = Table.StaffActiv.SearchUsers(txtSearch.Text, CriteriaIndex, MaxDisplay, DbLibraryConnectionString)
            NasLib.Functions.DataTable.Row.Sort(AllTable, "BP_NAMA")

            'NAME, FACULTY_DESC, PROGRAM_DESC, STUDENTID, PROCESS_STATUS_CODE
            For i As Integer = 0 To AllTable.Rows.Count - 1
                Dim MyControl As MyControls.Rdms.User.CheckIn.Search.Item = LoadControl("~\MyControls\Rdms\User\CheckIn\Search\Item.ascx")

                Dim PatronId As String = AllTable(i)("BP_NO_PEKERJA")
                Dim StatusCode As String = AllTable(i)("BK_REKOD_STATUS")

                MyControl.PatronName = AllTable(i)("BP_NAMA").ToString.Trim
                MyControl.Program = AllTable(i)("BK_JAW_SEKARANG_DESC").ToString.Trim
                MyControl.Faculty = AllTable(i)("BK_JAB_SEKARANG_DESC").ToString.Trim
                MyControl.PatronId = PatronId

                If Patron.IsStudent(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StudentBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StudentActive(StatusCode) & ")"
                ElseIf Patron.IsStaff(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StaffBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StaffActive(StatusCode) & ")"
                Else
                    MyControl.BackgroundColor = "darkCobalt"
                    MyControl.ToolTip = "Other"
                End If

                phItem.Controls.Add(MyControl)

            Next

            'Results
            Dim AllCount As Integer = AllTable.Rows.Count

            If AllCount >= 0 Then

                Dim MyResult As String = Nothing
                Select Case AllCount
                    Case 0
                        MyResult = "No Data"
                        lblResults.Text = MyResult
                    Case 1
                        MyResult = "Found {0} staff."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case 2 To MaxDisplay - 1
                        MyResult = "Found {0} staffs."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case Else
                        MyResult = "Displaying {0} staffs out of {1}."
                        lblResults.Text = String.Format(MyResult, AllCount, TotalResult)
                End Select

            End If

            If AllCount > 0 Then
                PanelLegend.Visible = True
            Else
                PanelLegend.Visible = False
            End If

            AllTable.Dispose()
        End Sub

        Private Sub SearchStudent()
            Dim StudentCount As Integer = Table.StudActiv.SearchUsersCount(txtSearch.Text, CriteriaIndex, DbLibraryConnectionString)
            Dim TotalResult As Integer = StudentCount

            Dim MaxDisplay As Integer = 100

            Dim AllTable As DataTable = Table.StudActiv.SearchUsers(txtSearch.Text, CriteriaIndex, MaxDisplay, DbLibraryConnectionString)
            NasLib.Functions.DataTable.Row.Sort(AllTable, "NAME")

            'NAME, FACULTY_DESC, PROGRAM_DESC, STUDENTID, PROCESS_STATUS_CODE
            For i As Integer = 0 To AllTable.Rows.Count - 1
                Dim MyControl As MyControls.Rdms.User.CheckIn.Search.Item = LoadControl("~\MyControls\Rdms\User\CheckIn\Search\Item.ascx")

                Dim PatronId As String = AllTable(i)("STUDENTID")
                Dim StatusCode As String = AllTable(i)("PROCESS_STATUS_CODE")

                MyControl.PatronName = AllTable(i)("NAME").ToString.Trim
                MyControl.Program = AllTable(i)("PROGRAM_DESC").ToString.Trim
                MyControl.Faculty = AllTable(i)("FACULTY_DESC").ToString.Trim
                MyControl.PatronId = PatronId

                If Patron.IsStudent(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StudentBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StudentActive(StatusCode) & ")"
                Else
                    MyControl.BackgroundColor = "darkCobalt"
                    MyControl.ToolTip = "Other"
                End If

                phItem.Controls.Add(MyControl)

            Next

            'Results
            Dim AllCount As Integer = AllTable.Rows.Count

            If AllCount >= 0 Then

                Dim MyResult As String = Nothing
                Select Case AllCount
                    Case 0
                        MyResult = "No Data"
                        lblResults.Text = MyResult
                    Case 1
                        MyResult = "Found {0} student."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case 2 To MaxDisplay - 1
                        MyResult = "Found {0} students."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case Else
                        MyResult = "Displaying {0} students out of {1}."
                        lblResults.Text = String.Format(MyResult, AllCount, TotalResult)
                End Select

            End If

            If AllCount > 0 Then
                PanelLegend.Visible = True
            Else
                PanelLegend.Visible = False
            End If

            AllTable.Dispose()
        End Sub

#End Region

#End Region

        Protected Sub btnSearch_Click() Handles btnSearch.ServerClick
            If rbFilterAll.Checked Then
                SearchAll()
                LegOther.Visible = True
                LegStaf.Visible = True
                LegStud.Visible = True
            End If


            If rbFilterStaff.Checked Then
                SearchStaff()
                LegOther.Visible = False
                LegStaf.Visible = True
                LegStud.Visible = False
            End If


            If rbFilterStudent.Checked Then
                SearchStudent()
                LegOther.Visible = False
                LegStaf.Visible = False
                LegStud.Visible = True
            End If

        End Sub

        Protected Sub lbOption_Click(sender As Object, e As EventArgs) Handles lbOption.Click
            PanelOption.Visible = Not PanelOption.Visible
        End Sub

        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            'If IsPostBack And txtSearch.Text.Length > 0 Then
            '    SearchAll()
            'End If

        End Sub

        Private Sub hiddenButton_Click(sender As Object, e As EventArgs) Handles hiddenButton.Click
            btnSearch_Click()
        End Sub
    End Class

End Namespace

