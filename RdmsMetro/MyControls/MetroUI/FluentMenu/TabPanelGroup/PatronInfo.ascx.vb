Imports NasLib.Database.MySql.CustomProvider.DBLibrary.Table
Imports NasLib.Database.MySql.CustomProvider

Namespace MyControls.MetroUI.FluentMenu.TabPanelGroup

    Public Class PatronInfo
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property PatronId As String
            Get
                Return lblPatronId.Text
            End Get
            Set(value As String)
                lblPatronId.Text = value
                LoadData()
            End Set
        End Property

        Public ReadOnly Property StudentFacultyCode As String
            Get
                Return gStudFacultyCode.Text
            End Get
        End Property

        Public ReadOnly Property StudentCampusCode As String
            Get
                Return gStudCampusCode.Text
            End Get
        End Property

        Public ReadOnly Property StudentLevelCode As String
            Get
                Return gStudLevelCode.Text
            End Get
        End Property

        Public ReadOnly Property StudentModeCode As String
            Get
                Return gStudModeCode.Text
            End Get
        End Property

        Public ReadOnly Property StudentProgramCode As String
            Get
                Return gStudProgramCode.Text
            End Get
        End Property

        Public ReadOnly Property StaffDepartmentCode As String
            Get
                Return gStafDeptCode.Text
            End Get
        End Property

        Public ReadOnly Property StaffPositionCode As String
            Get
                Return gStafPosCode.Text
            End Get
        End Property

        Public ReadOnly Property StaffTypeCode As String
            Get
                Return gStafTypeCode.Text
            End Get
        End Property

#End Region


        Private Sub LoadData()
            Dim PatronId_ As String = PatronId

            Dim IsStudent As Boolean = DBLibrary.Patron.IsStudent(PatronId_, DbLibraryConnectionString)
            Dim IsStaff As Boolean = False

            If IsStudent Then
                LoadStudentData()
            Else
                IsStaff = DBLibrary.Patron.IsStaff(PatronId_, DbLibraryConnectionString)
                If IsStaff Then LoadStaffData()
            End If

            PatronPhoto1.PatronId = PatronId_

        End Sub

        Private Sub LoadStudentData()

            'STUDENTID, NAME, FACULTY_CODE, FACULTY_DESC, PROGRAM_CODE, PROGRAM_DESC, CAMPUS_CODE, CAMPUS_DESC, PROGRAMLEVEL_CODE, 
            'PROGRAMLEVEL_DESC, STUDYMODE_CODE, STUDYMODE_DESC, PROCESS_STATUS_CODE, PROCESS_STATUS_DESC
            'HANDPHONE_NO, OFFICIAL_EMAIL
            Dim PatronTable As DataTable = StudActiv.GetSinglePatronInfo(PatronId, DbLibraryConnectionString)

            If PatronTable.Rows.Count > 0 Then

                If PatronTable(0)("FACULTY_CODE") IsNot System.DBNull.Value Then gStudFacultyCode.Text = PatronTable(0)("FACULTY_CODE")
                If PatronTable(0)("PROGRAM_CODE") IsNot System.DBNull.Value Then gStudProgramCode.Text = PatronTable(0)("PROGRAM_CODE")
                If PatronTable(0)("CAMPUS_CODE") IsNot System.DBNull.Value Then gStudCampusCode.Text = PatronTable(0)("CAMPUS_CODE")
                If PatronTable(0)("PROGRAMLEVEL_CODE") IsNot System.DBNull.Value Then gStudLevelCode.Text = PatronTable(0)("PROGRAMLEVEL_CODE")
                If PatronTable(0)("STUDYMODE_CODE") IsNot System.DBNull.Value Then gStudModeCode.Text = PatronTable(0)("STUDYMODE_CODE")
                gStafDeptCode.Text = "0"
                gStafPosCode.Text = "0"
                gStafTypeCode.Text = "0" '0 =Student, Empty = pengguna luar

                'Basic
                If PatronTable(0)("NAME") IsNot System.DBNull.Value Then lblFullname.Text = PatronTable(0)("NAME")
                If PatronTable(0)("PROGRAMLEVEL_DESC") IsNot System.DBNull.Value Then lblLevel.Text = PatronTable(0)("PROGRAMLEVEL_DESC")
                If PatronTable(0)("HANDPHONE_NO") IsNot System.DBNull.Value Then lblPhone.Text = PatronTable(0)("HANDPHONE_NO")
                If PatronTable(0)("OFFICIAL_EMAIL") IsNot System.DBNull.Value Then lblEmail.Text = PatronTable(0)("OFFICIAL_EMAIL")

                'Faculty
                If PatronTable(0)("FACULTY_DESC") IsNot System.DBNull.Value Then lblFaculty.Text = PatronTable(0)("FACULTY_DESC")
                If PatronTable(0)("PROGRAM_DESC") IsNot System.DBNull.Value Then lblProgram.Text = PatronTable(0)("PROGRAM_DESC")
                If PatronTable(0)("CAMPUS_DESC") IsNot System.DBNull.Value Then lblCampus.Text = PatronTable(0)("CAMPUS_DESC")
                If PatronTable(0)("STUDYMODE_DESC") IsNot System.DBNull.Value Then lblMode.Text = PatronTable(0)("STUDYMODE_DESC")

                If PatronTable(0)("PROCESS_STATUS_DESC") IsNot System.DBNull.Value Then lblStatus.Text = PatronTable(0)("PROCESS_STATUS_DESC")
            End If

            PatronTable.Dispose()

        End Sub

        Private Sub LoadStaffData()

            'BP_NO_PEKERJA, BP_NAMA, BP_NO_KP, BK_TELEFON, BP_EMAIL, BK_JAW_JENIS, BK_JAB_SEKARANG, BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG, BK_JAW_SEKARANG_DESC, BK_REKOD_STATUS, BK_REKOD_STATUS_DESC
            Dim PatronTable As DataTable = StaffActiv.GetSinglePatronInfo(PatronId, DbLibraryConnectionString)

            If PatronTable.Rows.Count > 0 Then
                gStudFacultyCode.Text = "0"
                gStudProgramCode.Text = "0"
                gStudCampusCode.Text = "0"
                gStudLevelCode.Text = "0"
                gStudModeCode.Text = "0"
                If PatronTable(0)("BK_JAB_SEKARANG") IsNot System.DBNull.Value Then gStafDeptCode.Text = PatronTable(0)("BK_JAB_SEKARANG")
                If PatronTable(0)("BK_JAW_SEKARANG") IsNot System.DBNull.Value Then gStafPosCode.Text = PatronTable(0)("BK_JAW_SEKARANG")
                If PatronTable(0)("BK_JAW_JENIS") IsNot System.DBNull.Value Then gStafTypeCode.Text = PatronTable(0)("BK_JAW_JENIS") '0 = Student, Empty = pengguna luar

                'Basic

                If PatronTable(0)("BP_NAMA") IsNot System.DBNull.Value Then lblFullname.Text = PatronTable(0)("BP_NAMA").ToString.Trim
                If PatronTable(0)("BK_JAW_JENIS") IsNot System.DBNull.Value Then lblLevel.Text = PatronTable(0)("BK_JAW_JENIS")
                If PatronTable(0)("BK_TELEFON") IsNot System.DBNull.Value Then lblPhone.Text = PatronTable(0)("BK_TELEFON")
                If PatronTable(0)("BP_EMAIL") IsNot System.DBNull.Value Then lblEmail.Text = PatronTable(0)("BP_EMAIL")

                'Faculty
                If PatronTable(0)("BK_JAB_SEKARANG_DESC") IsNot System.DBNull.Value Then lblFaculty.Text = PatronTable(0)("BK_JAB_SEKARANG_DESC")
                If PatronTable(0)("BK_JAW_SEKARANG_DESC") IsNot System.DBNull.Value Then lblProgram.Text = PatronTable(0)("BK_JAW_SEKARANG_DESC")
                lblCampus.Text = Nothing
                lblMode.Text = Nothing

                If PatronTable(0)("BK_REKOD_STATUS_DESC") IsNot System.DBNull.Value Then lblStatus.Text = PatronTable(0)("BK_REKOD_STATUS_DESC")

            End If

            PatronTable.Dispose()

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

