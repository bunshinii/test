Imports NasLib.Database.MySql.Provider

Namespace Database.MySql.Provider.QuickFunctions

    ''' <summary>
    ''' Quick Register. Must specify ProvidersConnectionString and DbLibraryConnectionString first
    ''' </summary>
    Public Class QuickRegistration

#Region "Global Set"

        Public Shared Property ProvidersConnectionString As String
            Get
                Return _ProvidersConnectionString
            End Get
            Set(value As String)
                _ProvidersConnectionString = value
            End Set
        End Property

        Public Shared Property DbLibraryConnectionString As String
            Get
                Return _DbLibraryConnectionString
            End Get
            Set(value As String)
                _DbLibraryConnectionString = value
            End Set
        End Property

#End Region

#Region "Quick Registration From DBLibrary"

        ''' <summary>
        ''' Register a user. Profile Data will be taken from DbLibrary.
        ''' No import if password fails.
        ''' </summary>
        Public Shared Function RegisterFromDbLibrary(Username As String, Password As String) As Boolean
            Dim ReturnValue As Boolean = False

            'If already registered then exit function
            Dim IsExisted As Boolean = Provider.Membership.IsUserExisted(Username, ProvidersConnectionString)
            If IsExisted Then
                Return ReturnValue
                Exit Function
            End If

            Dim IsDBLibraryExisted As Boolean = CustomProvider.DBLibrary.Patron.IsExisted(Username, DbLibraryConnectionString)

            If IsDBLibraryExisted Then
                Dim PatronPass As String = CustomProvider.DBLibrary.Patron.GetPatronIc(Username, DbLibraryConnectionString)
                Dim PatronRole As String = CustomProvider.DBLibrary.Patron.GetPatronType(Username, DbLibraryConnectionString)

                'no import if password fails.
                If PatronPass = Password Then
                    RegisterAspNetUser(Username, PatronPass, PatronRole)
                    RegisterCustomData(Username)
                End If

            End If

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Login a user. AutoRegister if not existed. Profile Data will be taken from DbLibrary. User will be Logged In after registered.
        ''' Return Login Message. No import if password fails.
        ''' Will be redirected to "~/Account/FirstTimeLogin.aspx" if register success.
        ''' </summary>
        Public Shared Function LoginRegisterFromDbLibrary(Username As String, Password As String) As String
            Dim ReturnValue As String = "Failed"
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current

            'If already registered then exit function
            Dim IsExisted As Boolean = Provider.Membership.IsUserExisted(Username, ProvidersConnectionString)
            If IsExisted Then
                If System.Web.Security.Membership.ValidateUser(Username, Password) Then
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Username, False)
                Else
                    ReturnValue = "Wrong Username or Password!"
                End If

                Return ReturnValue
                Exit Function
            End If

            Dim IsDBLibraryExisted As Boolean = CustomProvider.DBLibrary.Patron.IsExisted(Username, DbLibraryConnectionString)

            If IsDBLibraryExisted Then
                Dim IsActive As Boolean = CustomProvider.DBLibrary.Patron.IsPatronActive(Username, DbLibraryConnectionString)
                If Not IsActive Then
                    ReturnValue = ("Your status is not active!")
                    Return ReturnValue
                    Exit Function
                End If
            End If

            If System.Web.Security.Membership.ValidateUser(Username, Password) Then
                'Login User
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Username, False)
            Else

                If IsDBLibraryExisted Then
                    Dim PatronPass As String = CustomProvider.DBLibrary.Patron.GetPatronIc(Username, DbLibraryConnectionString)
                    Dim PatronRole As String = CustomProvider.DBLibrary.Patron.GetPatronType(Username, DbLibraryConnectionString)

                    'no import if password fails.
                    If PatronPass = Password Then
                        RegisterAspNetUser(Username, PatronPass, PatronRole)
                        RegisterCustomData(Username)
                    End If

                End If

                If System.Web.Security.Membership.ValidateUser(Username, Password) Then
                    'Redirect to First Time Login Page
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(Username, False)
                    context.Response.Redirect("~/Account/FirstTimeLogin.aspx", True)
                Else
                    ReturnValue = ("Please input correct Username and Password!")
                End If

            End If

            Return ReturnValue
        End Function


#End Region

#Region "Quick Blank Registration"

        ''' <summary>
        ''' Register a blank user with 'Staff' role with only Username and Passport as password
        ''' </summary>
        Public Shared Function RegisterBlankStaff(Username As String, Passport As String) As Boolean
            Dim ReturnValue As Boolean = False

            'If already registered then exit function
            Dim IsExisted As Boolean = Provider.Membership.IsUserExisted(Username, ProvidersConnectionString)
            If IsExisted Then
                Return ReturnValue
                Exit Function
            End If

            Dim PatronRole As String = "Staff"

            Dim UserId As Integer = RegisterAspNetUser(Username, Passport, PatronRole)
            Provider.Table.UsersProfile.ProfileInsert(UserId, Username, ProvidersConnectionString)
            Provider.Table.UsersProfile.Passport(UserId, ProvidersConnectionString) = Passport

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Register a blank user with 'Staff' role with only Username and Passport as password
        ''' </summary>
        Public Shared Function RegisterBlankLibraryStaff(Username As String, Passport As String) As Boolean
            Dim ReturnValue As Boolean = False

            'If already registered then exit function
            Dim IsExisted As Boolean = Provider.Membership.IsUserExisted(Username, ProvidersConnectionString)
            If IsExisted Then
                Return ReturnValue
                Exit Function
            End If

            Dim PatronRole() As String = {"Staff", "Library Staff"}

            Dim UserId As Integer = RegisterAspNetUser(Username, Passport, PatronRole)
            Provider.Table.UsersProfile.ProfileInsert(UserId, Username, ProvidersConnectionString)
            Provider.Table.UsersProfile.Passport(UserId, ProvidersConnectionString) = Passport

            Return ReturnValue
        End Function

#End Region

#Region "Private Functions"

        ''' <summary>
        ''' Register Asp.Net Membership using built-in provider.
        ''' Return UserId
        ''' </summary>
        Private Shared Function RegisterAspNetUser(Username As String, Password As String, ParamArray RoleName As String()) As Integer
            Dim UserRoleName() As String = RoleName
            Dim UserPassword As String = Password
            Dim _UserName As String = Username

            If System.Web.Security.Membership.GetUser(_UserName) Is Nothing Then
                System.Web.Security.Membership.CreateUser(_UserName, UserPassword)
            End If

            If UserRoleName.Count > 0 Then

                For i As Integer = 0 To UserRoleName.Count - 1

                    If Not System.Web.Security.Roles.RoleExists(UserRoleName(i)) Then
                        System.Web.Security.Roles.CreateRole(UserRoleName(i))
                    End If

                    If Not System.Web.Security.Roles.IsUserInRole(_UserName, UserRoleName(i)) Then
                        System.Web.Security.Roles.AddUserToRole(_UserName, UserRoleName(i))
                    End If

                Next

            End If

            Dim UserId As Integer = Provider.Table.Users.UserId(Username, ProvidersConnectionString)
            Return UserId
        End Function

        ''' <summary>
        ''' Get Batch Data from DBLibrary into Provider
        ''' </summary>
        Private Shared Sub RegisterCustomData(PatronId As String)
            Dim UserId As Integer = Provider.Table.Users.UserId(PatronId, ProvidersConnectionString)
            Dim PatronFullName As String = CustomProvider.DBLibrary.Patron.GetPatronName(PatronId, DbLibraryConnectionString).Trim
            PatronFullName = NasLib.Functions.String.Cases.CamelCase(PatronFullName).Trim

            Provider.Table.UsersProfile.ProfileInsert(UserId, PatronId, PatronFullName, ProvidersConnectionString)

            'Personal Data
            Dim Passport As String = CustomProvider.DBLibrary.Patron.GetPatronIc(PatronId, DbLibraryConnectionString)
            Dim Birthday As String = CustomProvider.DBLibrary.Patron.GetPatronBirthDay(PatronId, DbLibraryConnectionString)
            Dim MobilePhone As String = CustomProvider.DBLibrary.Patron.GetPatronPhone(PatronId, DbLibraryConnectionString)
            Dim Email As String = CustomProvider.DBLibrary.Patron.GetPatronEmail(PatronId, DbLibraryConnectionString)

            Provider.Table.UsersProfile.Passport(UserId, ProvidersConnectionString) = Passport
            Provider.Table.UsersProfile.BirthDate(UserId, ProvidersConnectionString) = Birthday
            Provider.Table.UsersProfile.Phone(UserId, ProvidersConnectionString) = MobilePhone
            Provider.Table.Membership.Email(UserId, ProvidersConnectionString) = Email

            'Student Data
            If UserData.IsStudent(UserId) Then
                Dim StudyModeCode As String = CustomProvider.DBLibrary.Table.StudActiv.StudyModeCode(PatronId, DbLibraryConnectionString)
                Dim StudyModeId As Integer = Provider.Table.StudMode.Id(StudyModeCode, ProvidersConnectionString)

                Dim CampusCode As String = CustomProvider.DBLibrary.Table.StudActiv.CampusCode(PatronId, DbLibraryConnectionString)
                Dim CampusId As Integer = Provider.Table.StudCampus.Id(CampusCode, ProvidersConnectionString)
                Dim BranchId As String = Provider.Table.StudCampus.BranchId(CampusId, ProvidersConnectionString)

                Dim FacultyCode As String = CustomProvider.DBLibrary.Table.StudActiv.FacultyCode(PatronId, DbLibraryConnectionString)
                Dim FacultyId As Integer = Provider.Table.StudFaculty.Id(FacultyCode, ProvidersConnectionString)

                Dim ProgramCode As String = CustomProvider.DBLibrary.Table.StudActiv.ProgramCode(PatronId, DbLibraryConnectionString)
                Dim ProgramId As Integer = Provider.Table.StudProgram.Id(ProgramCode, ProvidersConnectionString)

                Dim ProgramLevelCode As String = CustomProvider.DBLibrary.Table.StudActiv.ProgramLevelCode(PatronId, DbLibraryConnectionString)
                Dim ProgramLvlId As Integer = Provider.Table.StudProgramLevel.Id(ProgramLevelCode, ProvidersConnectionString)

                Provider.Table.UsersProfile.ModeId(UserId, ProvidersConnectionString) = StudyModeId
                Provider.Table.UsersProfile.CampusId(UserId, ProvidersConnectionString) = CampusId
                Provider.Table.UsersProfile.BranchId(UserId, ProvidersConnectionString) = BranchId
                Provider.Table.UsersProfile.FacultyId(UserId, ProvidersConnectionString) = FacultyId
                Provider.Table.UsersProfile.ProgramId(UserId, ProvidersConnectionString) = ProgramId
                Provider.Table.UsersProfile.LevelId(UserId, ProvidersConnectionString) = ProgramLvlId
                Provider.Table.UsersProfile.Email(UserId, ProvidersConnectionString) = Email
            End If

            'Staff Data 'A0401
            If UserData.IsStaff(UserId) Then
                Dim PositionCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JawatanSekarang(PatronId, DbLibraryConnectionString)
                Dim PositionId As Integer = Provider.Table.UsersPosition.PositionId(PositionCode, ProvidersConnectionString)

                Dim OfficialEmail As String = Email
                Dim Phone As String = CustomProvider.DBLibrary.Table.StaffActiv.Telefon(PatronId, DbLibraryConnectionString)
                Dim RegDate As String = CustomProvider.DBLibrary.Table.StaffActiv.TarikhMasuk(PatronId, DbLibraryConnectionString)
                Dim ExpDate As String = CustomProvider.DBLibrary.Table.StaffActiv.TarikhJangkaBersara(PatronId, DbLibraryConnectionString)

                Dim StafDeptCode As String = CustomProvider.DBLibrary.Table.StaffActiv.JabatanSekarang(PatronId, DbLibraryConnectionString)
                Dim StafDeptId As Integer = Provider.Table.StafDepartment.Id(StafDeptCode, ProvidersConnectionString)
                Dim BranchId As Integer = Provider.Table.StafDepartment.BranchId(StafDeptId, ProvidersConnectionString)

                Provider.Table.UsersProfile.PositionId(UserId, ProvidersConnectionString) = PositionId
                Provider.Table.UsersProfile.Phone(UserId, ProvidersConnectionString) = Phone
                Provider.Table.UsersProfile.RegistrationDate(UserId, ProvidersConnectionString) = RegDate
                Provider.Table.UsersProfile.ExpireDate(UserId, ProvidersConnectionString) = ExpDate
                Provider.Table.UsersProfile.StaffDepartmentId(UserId, ProvidersConnectionString) = StafDeptId
                Provider.Table.UsersProfile.BranchId(UserId, ProvidersConnectionString) = BranchId

                'Library Staff Data
                Dim DbLibStaff As Boolean = CustomProvider.DBLibrary.Table.LibStaffCode.IsLibraryStaff(PositionCode, DbLibraryConnectionString)
                If StafDeptCode = "A0401" Or DbLibStaff Then
                    UserData.IsLibraryStaff(UserId) = True
                End If

            End If

        End Sub

#End Region

    End Class

End Namespace



