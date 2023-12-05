Imports NasLib.Database.MySql.Provider

Namespace Functions.Web

    Public Class CurrentUser

#Region "Current User Specific"

        ''' <summary>
        ''' Get username for current user.
        ''' Better use 'Page.User.Identity.Name' if in a webform
        ''' Will return nothing if user is not logged in.
        ''' </summary>
        Public Shared Function Username() As String
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Return context.User.Identity.Name
        End Function

        ''' <summary>
        ''' Get username for current.
        ''' Better use 'Page.User.Identity.IsAuthenticated' if in a webform
        ''' </summary>
        Public Shared Function IsAuthenticated() As Boolean
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Return context.User.Identity.IsAuthenticated
        End Function

        Public Shared Function IsInRole(RoleName As String) As Boolean
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Return context.User.IsInRole(RoleName)
        End Function

        ''' <summary>
        ''' Get User Profile Picture from Picture Provider
        ''' </summary>
        ''' <param name="PicProviderLink">URL of the Picture Provider Site. No need query string. (e.g: http://localhost/Images/Default.ashx) </param>
        Public Shared Function UserImageLink(PicProviderLink As String) As String
            'E.G: http://localhost/Images/Default.ashx?patronid=164496

            Return PicProviderLink & "?patronid=" & Username()
        End Function

#End Region

#Region "From Provider"
        'WARNING: Must declare ProvidersConnectionString first before use. for MySQL only.

        ''' <summary>
        ''' Get Fullname for current user.
        ''' Must declare Providers ProvidersConnectionString first before use. for MySQL only.
        ''' </summary>
        Public Shared Property Fullname() As String
            Get
                Return Table.UsersProfile.FullName(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.FullName(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property UserId() As Integer
            Get
                Return Table.UsersProfile.Id(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property Nick() As String
            Get
                Return Table.UsersProfile.Nick(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Nick(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property NickOrFullname As String
            Get
                Return Table.UsersProfile.NickOrFullname(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property GradeId() As Integer
            Get
                Return Table.UsersProfile.GradeId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.GradeId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property GradeCode() As String
            Get
                Return Table.UsersProfile.GradeCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property PositionId() As Integer
            Get
                Return Table.UsersProfile.PositionId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.PositionId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property PositionName() As String
            Get
                Return Table.UsersProfile.PositionName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property Phone() As String
            Get
                Return Table.UsersProfile.Phone(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Phone(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt() As String
            Get
                Return Table.UsersProfile.PhoneExt(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.PhoneExt(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax() As String
            Get
                Return Table.UsersProfile.Fax(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Fax(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Handphone() As String
            Get
                Return Table.UsersProfile.Handphone(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Handphone(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Website() As String
            Get
                Return Table.UsersProfile.Website(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Website(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot() As String
            Get
                Return Table.UsersProfile.Blogspot(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Blogspot(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Facebook() As String
            Get
                Return Table.UsersProfile.Facebook(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Facebook(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter() As String
            Get
                Return Table.UsersProfile.Twitter(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Twitter(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Picture() As Byte()
            Get
                Return Table.UsersProfile.Picture(Username, _ProvidersConnectionString)
            End Get
            Set(value As Byte())
                Table.UsersProfile.Picture(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property birthDate() As Date
            Get
                Return Table.UsersProfile.BirthDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Table.UsersProfile.BirthDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property RegDate() As String
            Get
                Return Table.UsersProfile.RegistrationDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.RegistrationDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpDate() As String
            Get
                Return Table.UsersProfile.ExpireDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.ExpireDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId() As Integer
            Get
                Return Table.UsersProfile.BranchId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.BranchId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property BranchInitial() As String
            Get
                Return Table.UsersProfile.BranchInitial(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property BranchName() As String
            Get
                Return Table.UsersProfile.BranchName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInBranch(BranchId As Integer) As Boolean
            Get
                Return Table.UsersProfile.IsInBranch(Username, BranchId, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInBranch(BranchCode As String) As Boolean
            Get
                Return Table.UsersProfile.IsInBranch(Username, BranchCode, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property SatelliteId() As Integer
            Get
                Return Table.UsersProfile.SatelliteId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.SatelliteId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property SatelliteInitial() As String
            Get
                Return Table.UsersProfile.SatelliteInitial(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property SatelliteName() As String
            Get
                Return Table.UsersProfile.SatelliteName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInSatellite(SatelliteId As Integer) As Boolean
            Get
                Return Table.UsersProfile.IsInSatellite(Username, SatelliteId, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInSatellite(SatelliteInitial_ As String) As Boolean
            Get
                Return Table.UsersProfile.IsInSatellite(Username, SatelliteInitial_, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property DepartmentId() As Integer
            Get
                Return Table.UsersProfile.DepartmentId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.DepartmentId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DepartmentInitial() As String
            Get
                Return Table.UsersProfile.DepartmentInitial(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DepartmentName() As String
            Get
                Return Table.UsersProfile.DepartmentName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInDepartment(DepartmentId As Integer) As Boolean
            Get
                Return Table.UsersProfile.IsInDepartment(Username, DepartmentId, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInDepartment(DepartmentInitial_ As String) As Boolean
            Get
                Return Table.UsersProfile.IsInDepartment(Username, DepartmentInitial_, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property DivisionId() As Integer
            Get
                Return Table.UsersProfile.DivisionId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.DivisionId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DivisionInitial() As String
            Get
                Return Table.UsersProfile.DivisionInitial(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DivisionName() As String
            Get
                Return Table.UsersProfile.DivisionName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInDivision(DivisionId As Integer) As Boolean
            Get
                Return Table.UsersProfile.IsInDivision(Username, DivisionId, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInDivision(DivisionInitial_ As String) As Boolean
            Get
                Return Table.UsersProfile.IsInDivision(Username, DivisionInitial_, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property UnitId() As Integer
            Get
                Return Table.UsersProfile.UnitId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.UnitId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property UnitInitial() As String
            Get
                Return Table.UsersProfile.UnitInitial(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property UnitName() As String
            Get
                Return Table.UsersProfile.UnitName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInUnit(UnitId As Integer) As Boolean
            Get
                Return Table.UsersProfile.IsInUnit(Username, UnitId, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsInUnit(DivisionInitial_ As String) As Boolean
            Get
                Return Table.UsersProfile.IsInUnit(Username, DivisionInitial_, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StaffDepartmentId() As Integer
            Get
                Return Table.UsersProfile.StaffDepartmentId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.StaffDepartmentId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StaffDepartmentName() As String
            Get
                Return Table.UsersProfile.StaffDepartmentName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StaffDepartmentCode() As String
            Get
                Return Table.UsersProfile.StaffDepartmentCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StudentCampusId() As Integer
            Get
                Return Table.UsersProfile.CampusId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.CampusId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StudentCampusName() As String
            Get
                Return Table.UsersProfile.CampusName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StudentCampusCode() As String
            Get
                Return Table.UsersProfile.CampusCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StudentFacultyId() As Integer
            Get
                Return Table.UsersProfile.FacultyId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.FacultyId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StudentFacultyName() As String
            Get
                Return Table.UsersProfile.FacultyName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StudentFacultyCode() As String
            Get
                Return Table.UsersProfile.FacultyCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StudentProgramId() As Integer
            Get
                Return Table.UsersProfile.ProgramId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.ProgramId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StudentProgramName() As String
            Get
                Return Table.UsersProfile.ProgramName(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StudentProgramCode() As String
            Get
                Return Table.UsersProfile.ProgramCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StudentLevelId() As Integer
            Get
                Return Table.UsersProfile.LevelId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.LevelId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StudentLevelDesc() As String
            Get
                Return Table.UsersProfile.LevelDesc(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StudentLevelCode() As String
            Get
                Return Table.UsersProfile.LevelCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property StudentModeId() As Integer
            Get
                Return Table.UsersProfile.ModeId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.ModeId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StudentModeDesc() As String
            Get
                Return Table.UsersProfile.ModeDesc(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StudentModeCode() As String
            Get
                Return Table.UsersProfile.ModeCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Official Email
        ''' </summary>
        Public Shared Property Email1() As String
            Get
                Return Table.Membership.Email(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.Membership.Email(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Personal Email
        ''' </summary>
        Public Shared Property Email2() As String
            Get
                Return Table.UsersProfile.Email(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Email(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Passport() As String
            Get
                Return Table.UsersProfile.Passport(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Passport(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId() As Integer
            Get
                Return Table.UsersProfile.GenderId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.GenderId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property GenderName() As String
            Get
                Return Table.UsersProfile.GenderDesc(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property MarriageId() As Integer
            Get
                Return Table.UsersProfile.MarriageId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.MarriageId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property MarriageDesc() As String
            Get
                Return Table.UsersProfile.GenderDesc(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared Property SequenceNo() As Integer
            Get
                Return Table.UsersProfile.seq_no(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.seq_no(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Address1() As String
            Get
                Return Table.UsersProfile.Address1(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address1(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2() As String
            Get
                Return Table.UsersProfile.Address1(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address2(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3() As String
            Get
                Return Table.UsersProfile.Address1(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address3(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Postcode() As String
            Get
                Return Table.UsersProfile.Postcode(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Postcode(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property City() As String
            Get
                Return Table.UsersProfile.City(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.City(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property State() As String
            Get
                Return Table.UsersProfile.State(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.State(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property Country() As String
            Get
                Return Table.UsersProfile.Country(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Country(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property IsFirstTimeLogin() As Boolean
            Get
                Return Table.UsersProfile.IsFirstTime(Username, _ProvidersConnectionString)
            End Get
            Set(value As Boolean)
                Table.UsersProfile.IsFirstTime(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate() As Date
            Get
                Return Table.UsersProfile.LastUpdateDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Table.UsersProfile.LastUpdateDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

#End Region


#Region "NOT USED"

        ''' <summary>
        ''' NOT USED! PLEASE USE UserImageLink()
        ''' Get user image url.
        ''' Only use this if UserPic application is running.
        ''' 'patronid' is the query string parameter for obtaining the correct pic.
        ''' </summary>
        ''' <param name="CustomPath">Path to file that will select the user pic</param>
        Public Shared Function ImageUrl(Optional CustomPath As String = "") As String

            Dim Path As String = "/Images/Users/?patronid"
            If CustomPath.Length > 0 Then Path = CustomPath

            If IsAuthenticated() Then
                ImageUrl = String.Format("{0}={1}", Path, Username)
            Else
                ImageUrl = String.Format("{0}=0", Path)
            End If

        End Function

        ''' <summary>
        ''' NOT USED! PLEASE USE UserImageLink()
        ''' Get user image url for student.
        ''' Only use this if UserPic application is running.
        ''' 'patronid' is the query string parameter for obtaining the correct pic.
        ''' </summary>
        Public Shared Function ImageUrlStudent(Optional CustomPath As String = "") As String

            Dim Path As String = "/Images/Patron/?id"
            If CustomPath.Length > 0 Then Path = CustomPath

            If IsAuthenticated() Then
                ImageUrlStudent = String.Format("{0}={1}", Path, Username)
            Else
                ImageUrlStudent = String.Format("{0}=0", Path)
            End If

        End Function

#End Region

    End Class

End Namespace


