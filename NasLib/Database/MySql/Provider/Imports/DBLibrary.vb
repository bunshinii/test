Imports NasLib.Database.MySql.CustomProvider.DBLibrary
Imports NasLib.Database.MySql.Provider

Namespace Database.MySql.Provider.Imports

    ''' <summary>
    ''' Import data from 'DBLibrary' database into 'Providers' database
    ''' </summary>
    Public Class DBLibrary

#Region "User"

#Region "Import a User's data"

        ''' <summary>
        ''' Import a User's data from DBLibrary into Provider.
        ''' All related field will be filled automatically according to the data in DBLibrary.
        ''' Will only import registered user in the provider. Replacing existing data.
        ''' </summary>
        Public Shared Function ImportUserData(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            ImportUserData = False

            Dim IsUserExisted As Boolean = Membership.IsUserExisted(PatronId, ProviderConnectionString)

            If IsUserExisted Then

                'Dim Fullname As String = CustomProvider.DBLibrary.Table.StaffActiv.Nama(PatronId, DBLibraryConnectionString).Trim
                Dim Fullname As String = CustomProvider.DBLibrary.Patron.GetPatronName(PatronId, DBLibraryConnectionString).Trim
                Dim NoIC As String = CustomProvider.DBLibrary.Patron.GetPatronIc(PatronId, DBLibraryConnectionString)
                Dim Phone As String = CustomProvider.DBLibrary.Patron.GetPatronPhone(PatronId, DBLibraryConnectionString)
                Dim Email As String = CustomProvider.DBLibrary.Patron.GetPatronEmail(PatronId, DBLibraryConnectionString)
                Dim ExpireDate As String = CustomProvider.DBLibrary.Patron.GetPatronExpiryDate(PatronId, DBLibraryConnectionString)
                Dim RegisterDate As String = CustomProvider.DBLibrary.Patron.GetPatronRegistrationDate(PatronId, DBLibraryConnectionString)
                Dim DOB As String = CustomProvider.DBLibrary.Patron.GetPatronBirthDay(PatronId, DBLibraryConnectionString)

                Table.UsersProfile.FullName(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Fullname).Trim
                Table.UsersProfile.Passport(PatronId, ProviderConnectionString) = NoIC
                Table.UsersProfile.Phone(PatronId, ProviderConnectionString) = Phone
                Table.Membership.Email(PatronId, ProviderConnectionString) = Email

                If IsDate(ExpireDate) Then Table.UsersProfile.ExpireDate(PatronId, ProviderConnectionString) = ExpireDate
                If IsDate(RegisterDate) Then Table.UsersProfile.RegistrationDate(PatronId, ProviderConnectionString) = RegisterDate
                If IsDate(DOB) Then Table.UsersProfile.BirthDate(PatronId, ProviderConnectionString) = DOB

                ImportStaffData(PatronId, ProviderConnectionString, DBLibraryConnectionString)
                ImportStudentData(PatronId, ProviderConnectionString, DBLibraryConnectionString)

                ImportUserData = True
            End If

        End Function

#End Region

#End Region

#Region "Staff"

#Region "Private Property"

        ''' <summary>
        ''' Import and register a user from 'DBLibrary' into 'Providers'. Only unregistered user in 'Providers' will be imported.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' Will return 'Providers' User Id.
        ''' </summary>
        Public Shared Function RegisterUser(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Integer
            Dim DBLibraryPassword As String = Patron.GetPatronIc(PatronId, DBLibraryConnectionString)
            Dim DBLibraryEmail As String = Patron.GetPatronEmail(PatronId, DBLibraryConnectionString)

            Return NasLib.Database.MySql.Provider.Membership.CreateUser(PatronId, DBLibraryPassword, DBLibraryEmail, ProviderConnectionString)
        End Function


        ''' <summary>
        ''' Fill 'my_aspnet_membership' table from DBLibrary's data. Will replace existing data.
        ''' Only works when the user is already existed in 'Providers'
        ''' </summary>
        Private Shared Function FillMembership(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As String
            Return Table.Membership.Comment(PatronId, ProviderConnectionString) = "Import from DBLibrary"
        End Function

        ''' <summary>
        ''' Fill 'my_aspnet_roles' table from DBLibrary's data. Will replace existing data.
        ''' Only works when the user is already existed in 'Providers'
        ''' </summary>
        Private Shared Function FillRoles(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As String
            Dim DBLibraryRole As String = Patron.GetPatronRoles(PatronId, DBLibraryConnectionString)

            If Not Table.Roles.IsExisted(DBLibraryRole, ProviderConnectionString) Then Role.CreateRole(DBLibraryRole, ProviderConnectionString)
            Return Table.UsersInRoles.AssignUserRole(PatronId, DBLibraryRole, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Fill 'my_users_profile' table from DBLibrary's data. Will replace existing data.
        ''' Only works when the user is already existed in 'Providers'
        ''' </summary>
        Private Shared Function FillUsersProfile(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean

            If Not Provider.Table.UsersProfile.IsExisted(PatronId, ProviderConnectionString) Then
                FillUsersProfile = False
                Exit Function
            End If

            Dim DBLibraryFullname As String = Patron.GetPatronName(PatronId, DBLibraryConnectionString)
            Dim DBLibraryPhone As String = Patron.GetPatronPhone(PatronId, DBLibraryConnectionString)
            Dim DBLibraryPassport As String = Patron.GetPatronIc(PatronId, DBLibraryConnectionString)
            Dim DBLibraryBirthDate As String = Patron.GetPatronBirthDay(PatronId, DBLibraryConnectionString)
            Dim DBLibraryRegDate As String = Patron.GetPatronRegistrationDate(PatronId, DBLibraryConnectionString)
            Dim DBLibraryExpDate As String = Patron.GetPatronExpiryDate(PatronId, DBLibraryConnectionString)

            Try
                If Not String.IsNullOrEmpty(DBLibraryFullname) Then Table.UsersProfile.FullName(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(DBLibraryFullname)
                If Not String.IsNullOrEmpty(DBLibraryPhone) Then Table.UsersProfile.Phone(PatronId, ProviderConnectionString) = DBLibraryPhone
                If Not String.IsNullOrEmpty(DBLibraryPassport) Then Table.UsersProfile.Passport(PatronId, ProviderConnectionString) = DBLibraryPassport
                If IsDate(DBLibraryBirthDate) Then Table.UsersProfile.BirthDate(PatronId, ProviderConnectionString) = DBLibraryBirthDate
                If IsDate(DBLibraryRegDate) Then Table.UsersProfile.RegistrationDate(PatronId, ProviderConnectionString) = DBLibraryRegDate
                If IsDate(DBLibraryExpDate) Then Table.UsersProfile.ExpireDate(PatronId, ProviderConnectionString) = DBLibraryExpDate
                FillUsersProfile = True
            Catch ex As Exception
                Dim ExMsg As String = ex.Message
                FillUsersProfile = False
            End Try

        End Function



#End Region

#Region "Import a Staff's data"

        ''' <summary>
        ''' Import a Staff's data from DBLibrary into Provider.
        ''' All related field will be filled automatically according to the data in DBLibrary.
        ''' Will only import registered staff in the provider. Replacing existing data.
        ''' </summary>
        Public Shared Function ImportStaffData(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            ImportStaffData = False

            Dim IsStaff As Boolean = Role.IsUserInRole(PatronId, "Staff", ProviderConnectionString)

            If IsStaff Then

                Dim StaffDepartmentCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JabatanSekarang(PatronId, DBLibraryConnectionString)
                Dim PositionCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JawatanSekarang(PatronId, DBLibraryConnectionString)

                Dim StafDeptId As Integer = Table.StafDepartment.Id(StaffDepartmentCode, ProviderConnectionString)
                Table.UsersProfile.StaffDepartmentId(PatronId, ProviderConnectionString) = StafDeptId
                Table.UsersProfile.BranchId(PatronId, ProviderConnectionString) = Table.StafDepartment.BranchId(StafDeptId, ProviderConnectionString)

                Dim PosId As Integer = Table.UsersPosition.PositionId(PositionCode, ProviderConnectionString)
                Table.UsersProfile.PositionId(PatronId, ProviderConnectionString) = PosId

                Dim GradeCode As String = Table.UsersPosition.Grade(PositionCode, ProviderConnectionString)
                Dim GradeId As Integer = Table.UsersPositionGrade.GradeId(GradeCode.Trim, ProviderConnectionString)
                Table.UsersProfile.GradeId(PatronId, ProviderConnectionString) = GradeId

                Dim Address1 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat1(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.Address1(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Address1)

                Dim Address2 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat2(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.Address2(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Address2)

                Dim Address3 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat3(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.Address3(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Address3)

                Dim Postcode As String = CustomProvider.DBLibrary.Table.StaffActiv.Postkod(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.Postcode(PatronId, ProviderConnectionString) = Postcode

                Dim City As String = CustomProvider.DBLibrary.Table.StaffActiv.Bandar(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.City(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(City)

                Dim State As String = CustomProvider.DBLibrary.Table.StaffActiv.Negara(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.State(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(State)

                Dim Country As String = CustomProvider.DBLibrary.Table.StaffActiv.Negara(PatronId, DBLibraryConnectionString)
                Table.UsersProfile.Country(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Country)

                ImportStaffData = True
            End If

        End Function

        ''' <summary>
        ''' Import a Alternat Staff's data from DBLibrary into Provider.
        ''' All related field will be filled automatically according to the data in DBLibrary.
        ''' Will only import registered alternate staff in the provider. Replacing existing data.
        ''' </summary>
        Public Shared Function ImportStaffDataAlt(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            ImportStaffDataAlt = False

            Dim StaffDepartmentCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JabatanSekarang(PatronId, DBLibraryConnectionString)
            Dim PositionCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JawatanSekarang(PatronId, DBLibraryConnectionString)

            Dim StafDeptId As Integer = Table.StafDepartment.Id(StaffDepartmentCode, ProviderConnectionString)
            Table.AltUsersProfile.StaffDepartmentId(PatronId, ProviderConnectionString) = StafDeptId
            Table.AltUsersProfile.BranchId(PatronId, ProviderConnectionString) = Table.StafDepartment.BranchId(StafDeptId, ProviderConnectionString)

            Dim PosId As Integer = Table.UsersPosition.PositionId(PositionCode, ProviderConnectionString)
            Table.AltUsersProfile.PositionId(PatronId, ProviderConnectionString) = PosId

            Dim GradeCode As String = Table.UsersPosition.Grade(PositionCode, ProviderConnectionString)
            Dim GradeId As Integer = Table.UsersPositionGrade.GradeId(GradeCode.Trim, ProviderConnectionString)
            Table.AltUsersProfile.GradeId(PatronId, ProviderConnectionString) = GradeId

            Dim Address1 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat1(PatronId, DBLibraryConnectionString)
            Dim Address11 As String = Functions.String.Cases.CamelCase(Address1)
            Table.AltUsersProfile.Address1(PatronId, ProviderConnectionString) = Address11

            Dim Address2 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat2(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.Address2(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Address2)

            Dim Address3 As String = CustomProvider.DBLibrary.Table.StaffActiv.Alamat3(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.Address3(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Address3)

            Dim Postcode As String = CustomProvider.DBLibrary.Table.StaffActiv.Postkod(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.Postcode(PatronId, ProviderConnectionString) = Postcode

            Dim City As String = CustomProvider.DBLibrary.Table.StaffActiv.Bandar(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.City(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(City)

            Dim State As String = CustomProvider.DBLibrary.Table.StaffActiv.Negeri(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.State(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(State)

            Dim Country As String = CustomProvider.DBLibrary.Table.StaffActiv.Negara(PatronId, DBLibraryConnectionString)
            Table.AltUsersProfile.Country(PatronId, ProviderConnectionString) = Functions.String.Cases.CamelCase(Country)

            ImportStaffDataAlt = True

        End Function

#End Region

#Region "uDepartment"

        ''' <summary>
        ''' Will import data from DBLIBRARY 'staf_activ' table department data into Provider 'my_staf_department' table.
        ''' Ignored if dept_code already existed.
        ''' BranchId will be automatically assigned.
        ''' </summary>
        Public Shared Function ImportStaffDepartment(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            'Must fill the field 'staf_dept_map' in 'my_users_office_branch' first to relate to the branchId.

            Dim ReturnValue As Boolean = False

            Dim DeptTable As DataTable = StafDepartment.GetAllDepartments(DBLibraryConnectionString)

            If DeptTable.Rows.Count > 0 Then

                For i As Integer = 0 To DeptTable.Rows.Count - 1
                    Dim DeptCode As String = DeptTable(i)(0).ToString.ToUpper
                    Dim DeptName As String = DeptTable(i)(1).ToString.Trim

                    DeptName = Functions.String.Cases.CamelCase(DeptName).Trim
                    DeptName = DeptName.Replace("Uitm", "UiTM")

                    If Not Table.StafDepartment.IsExisted(DeptCode, ProviderConnectionString) Then
                        Dim BranchCode As String = Functions.String.Extract.LetterFromText(DeptCode)
                        Dim BranchId As Integer = Table.OfficeBranch.IdByDeptCode(BranchCode, ProviderConnectionString)
                        Table.StafDepartment.DeptAdd(DeptCode, DeptName, BranchId, ProviderConnectionString)
                    End If

                Next

            End If

            DeptTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Position"

        ''' <summary>
        ''' Will import data from DBLIBRARY 'staf_activ' table department data into Provider 'my_users_position' table.
        ''' Ignored if pos_code already existed.
        ''' grade and rankNo must be manually assigned.
        ''' </summary>
        Public Shared Function ImportStaffPosition(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim PostTable As DataTable = StafPosition.GetAllPositions(DBLibraryConnectionString)

            If PostTable.Rows.Count > 0 Then

                For i As Integer = 0 To PostTable.Rows.Count - 1
                    Dim PostCode As String = PostTable(i)(0).ToString.Trim.ToUpper
                    Dim PostName As String = PostTable(i)(1).ToString.Trim
                    PostName = Functions.String.Cases.CamelCase(PostName)

                    Dim PostType As String = "0"
                    If Not IsDBNull(PostTable(i)(2)) Then PostType = PostTable(i)(2).ToString.Trim.ToUpper



                    If Not Table.UsersPosition.IsExisted(PostCode, ProviderConnectionString) Then
                        Table.UsersPosition.PositionAdd(PostName, PostCode, PostType, ProviderConnectionString)
                    End If

                Next

            End If

            PostTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Grade"

        ''' <summary>
        ''' Will import data from 'provider' 'my_users_position' table grade data into 'Provider' 'my_users_position_grade' table.
        ''' The 'my_users_position' table must be imported first. This function will NOT connect to 'DBLIBRARY' database.
        ''' Ignored if grade_code already existed and only assigned grade in 'my_users_position' will be imported.
        ''' grade_type, grade_rank and grade_order will be automatically assigned but 'grade_order' need to edit accordingly.
        ''' </summary>
        Public Shared Function ImportStaffGrade(ProviderConnectionString As String) As Boolean
            Return Table.UsersPositionGrade.ImportGrade(ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Student"

#Region "Import a Student's data"

        ''' <summary>
        ''' Import a Student's data from DBLibrary into Provider.
        ''' All related field will be filled automatically according to the data in DBLibrary.
        ''' Will only import registered student in the provider. Replacing existing data.
        ''' </summary>
        Private Shared Function ImportStudentData(PatronId As String, ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            ImportStudentData = False

            Dim IsStudent As Boolean = Role.IsUserInRole(PatronId, "Student", ProviderConnectionString)

            If IsStudent Then

                Dim Email As String = CustomProvider.DBLibrary.Table.StudActiv.OfficialEmail(PatronId, DBLibraryConnectionString)
                Dim CampusCode As String = CustomProvider.DBLibrary.Table.StudActiv.CampusCode(PatronId, DBLibraryConnectionString)
                Dim FacultyCode As String = CustomProvider.DBLibrary.Table.StudActiv.FacultyCode(PatronId, DBLibraryConnectionString)
                Dim ProgramCode As String = CustomProvider.DBLibrary.Table.StudActiv.ProgramCode(PatronId, DBLibraryConnectionString)
                Dim ProgLevelCode As String = CustomProvider.DBLibrary.Table.StudActiv.ProgramLevelCode(PatronId, DBLibraryConnectionString)
                Dim StudyModeCode As String = CustomProvider.DBLibrary.Table.StudActiv.StudyModeCode(PatronId, DBLibraryConnectionString)

                Table.UsersProfile.Email(PatronId, ProviderConnectionString) = Email

                Dim CampusId As Integer = Table.StudCampus.Id(CampusCode, ProviderConnectionString)
                Table.UsersProfile.CampusId(PatronId, ProviderConnectionString) = CampusId
                Table.UsersProfile.BranchId(PatronId, ProviderConnectionString) = Table.StudCampus.BranchId(CampusId, ProviderConnectionString)

                Dim FacultyId As Integer = Table.StudFaculty.Id(FacultyCode, ProviderConnectionString)
                Table.UsersProfile.FacultyId(PatronId, ProviderConnectionString) = FacultyId

                Dim ProgramId As Integer = Table.StudProgram.Id(ProgramCode, ProviderConnectionString)
                Table.UsersProfile.ProgramId(PatronId, ProviderConnectionString) = ProgramId

                Dim ProgLevelId As Integer = Table.StudProgramLevel.Id(ProgLevelCode, ProviderConnectionString)
                Table.UsersProfile.LevelId(PatronId, ProviderConnectionString) = ProgLevelId

                Dim ModeId As Integer = Table.StudMode.Id(StudyModeCode, ProviderConnectionString)
                Table.UsersProfile.ModeId(PatronId, ProviderConnectionString) = ModeId

                ImportStudentData = True
            End If

        End Function

#End Region

#Region "Campus"

        ''' <summary>
        ''' Will import data from DBLIBRARY 'stud_activ' table campus data into Provider 'my_stud_campus' table.
        ''' Ignored if campus_code already existed.
        ''' BranchId will be automatically assigned.
        ''' </summary>
        Public Shared Function ImportStudentCampus(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim CampusTable As DataTable = StudCampus.GetAllCampuses(DBLibraryConnectionString)

            If CampusTable.Rows.Count > 0 Then

                For i As Integer = 0 To CampusTable.Rows.Count - 1
                    Dim CampusCode As String = CampusTable(i)("CAMPUS_CODE").ToString.ToUpper
                    Dim CampusDesc As String = CampusTable(i)("CAMPUS_DESC").ToString.Trim

                    CampusDesc = Functions.String.Cases.CamelCase(CampusDesc).Trim
                    CampusDesc = CampusDesc.Replace("Uitm", "UiTM")

                    If Not Table.StudCampus.IsExisted(CampusCode, ProviderConnectionString) Then
                        Dim BranchCode As String = Functions.String.Extract.LetterFromText(CampusCode)
                        Dim BranchId As Integer = Table.OfficeBranch.IdByBranchCode(BranchCode, ProviderConnectionString)
                        Table.StudCampus.CampusAdd(CampusCode, CampusDesc, BranchId, ProviderConnectionString)
                    End If

                Next

            End If

            CampusTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Faculty"

        ''' <summary>
        ''' Will import data from DBLIBRARY 'stud_activ' table faculty data into Provider 'my_stud_faculty' table.
        ''' Ignored if faculty_code already existed.
        ''' </summary>
        Public Shared Function ImportStudentFaculty(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim ImportTable As DataTable = StudFaculty.GetAllFaculties(DBLibraryConnectionString)

            If ImportTable.Rows.Count > 0 Then

                For i As Integer = 0 To ImportTable.Rows.Count - 1
                    Dim _Code As String = ImportTable(i)(0).ToString.ToUpper
                    Dim _Desc As String = ImportTable(i)(1).ToString.Trim

                    _Desc = Functions.String.Cases.CamelCase(_Desc).Trim

                    If Not Table.StudFaculty.IsExisted(_Code, ProviderConnectionString) Then
                        Table.StudFaculty.FacultyAdd(_Code, _Desc, ProviderConnectionString)
                    End If

                Next

            End If

            ImportTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Program"

        ' ''' <summary>
        ' ''' Will import data from DBLIBRARY 'stud_activ' table Program data into Provider 'my_stud_program' table.
        ' ''' Ignored if program_code already existed.
        ' ''' program_letter' and 'program_number' will be automatically filled.
        ' ''' </summary>
        'Public Shared Function ImportStudentProgram(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
        '    Dim ReturnValue As Boolean = False

        '    Dim ProgramTable As DataTable = StudProgram.GetAllPrograms(DBLibraryConnectionString)

        '    If ProgramTable.Rows.Count > 0 Then

        '        For i As Integer = 0 To ProgramTable.Rows.Count - 1
        '            Dim ProgramCode As String = ProgramTable(i)(0).ToString.Trim.ToUpper
        '            Dim ProgramDesc As String = ProgramTable(i)(1).ToString.Trim

        '            ProgramDesc = Functions.String.Cases.CamelCase(ProgramDesc).Trim

        '            If Not Table.StudProgram.IsExisted(ProgramCode, ProviderConnectionString) Then
        '                Table.StudProgram.ProgramAdd(ProgramCode, ProgramDesc, ProviderConnectionString)
        '            End If

        '        Next

        '    End If

        '    ProgramTable.Dispose()

        '    Return ReturnValue
        'End Function

#End Region

#Region "ProgramLevel"

        ''' <summary>
        ''' Will import data from DBLIBRARY 'stud_activ' table ProgramLevel data into Provider 'my_stud_program_level' table.
        ''' Ignored if level_code already existed.
        ''' Level Order must be manually ordered.
        ''' </summary>
        Public Shared Function ImportStudentProgramLevel(ProviderConnectionString As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim ImportTable As DataTable = StudProgramLevel.GetAllLevels(DBLibraryConnectionString)

            If ImportTable.Rows.Count > 0 Then

                For i As Integer = 0 To ImportTable.Rows.Count - 1
                    Dim _Code As String = ImportTable(i)(0)
                    Dim _Desc As String = ImportTable(i)(1)

                    If Not Table.StudProgramLevel.IsExisted(_Code, ProviderConnectionString) Then
                        Table.StudProgramLevel.LevelAdd(_Code, _Desc, ProviderConnectionString)
                    End If

                Next

            End If

            ImportTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#End Region

    End Class
End Namespace

