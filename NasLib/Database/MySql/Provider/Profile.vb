Imports NasLib.Database.MySql.Provider.Table

Namespace Database.MySql.Provider

    Public Class Profile

#Region "Public Functions"

#Region "By UserId"

        Public Shared Function Username(UserId As Integer, ProviderConnectionString As String) As String
            Return Users.Username(UserId, ProviderConnectionString)
        End Function


        Public Shared Function IsPicExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return UsersProfile.IsPictureExisted(UserId, ProviderConnectionString)
        End Function

        Public Shared Function PicSize(UserId As Integer, ProviderConnectionString As String) As Long
            Return UsersProfile.PictureSize(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return Users.IsExisted(UserId, ProviderConnectionString)
        End Function

#End Region

#Region "By Username"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Return Users.UserId(Username, ProviderConnectionString)
        End Function

        Public Shared Function IsPicExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return UsersProfile.IsPictureExisted(Username, ProviderConnectionString)
        End Function

        Public Shared Function PicSize(Username As String, ProviderConnectionString As String) As Long
            Return UsersProfile.PictureSize(Username, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return Users.IsExisted(Username, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Public Properties"

#Region "From Users"

        Public Shared Function IsUserOnline(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return Users.IsUserOnline(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserOnline(Username As String, ProviderConnectionString As String) As Boolean
            Return Users.IsUserOnline(Username, ProviderConnectionString)
        End Function

#End Region

#Region "From Membership"
        'NOTE: Membership Table doesn't have name or username field
        ' Just UserId field

        Public Shared Property Comment(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.Membership.Comment(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Membership.Comment(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property CreationDate(UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Return Table.Membership.CreationDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Membership.CreationDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Email(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.Membership.Email(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Membership.Email(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastLoginDate(UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Return Table.Membership.LastLoginDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Membership.LastLoginDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastPasswordChangedDate(UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Return Table.Membership.LastPasswordChangedDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Membership.LastPasswordChangedDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Password(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.Membership.Password(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Membership.Password(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PasswordAnswer(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.Membership.PasswordAnswer(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Membership.PasswordAnswer(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PasswordQuestion(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.Membership.PasswordQuestion(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Membership.PasswordQuestion(UserId, ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "From UsersProfile"

#Region "By UserId"

        Public Shared Property Address1(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address1(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address1(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address2(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address2(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address3(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address3(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BirthDay(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim ReturnValue As String = Nothing

                If UsersProfile.IsBirthDateAvailable(UserId, ProviderConnectionString) Then
                    ReturnValue = Format(UsersProfile.BirthDate(UserId, ProviderConnectionString), "dd MMMM yyy")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                UsersProfile.BirthDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Blogspot(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Blogspot(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.BranchId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.BranchId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property City(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.City(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.City(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Country(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Country(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Country(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DepartmentId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.DepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.DepartmentId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DepartmentName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim DeptId As Integer = DepartmentId(UserId, ProviderConnectionString)
                Return Table.OfficeDepartment.Department(DeptId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property DivisionId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.DivisionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.DivisionId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DivisionName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim DivId As Integer = DivisionId(UserId, ProviderConnectionString)
                Return Table.OfficeDivision.Division(DivId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Email2(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Email(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Email(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpireDate(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.ExpireDate(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.ExpireDate(UserId, ProviderConnectionString) = CDate(value)
            End Set
        End Property

        Public Shared Property Facebook(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Facebook(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Facebook(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Fax(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Fax(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fullname(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.FullName(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.FullName(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.GenderId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.GenderId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GradeId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.GradeId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.GradeId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Handphone(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Handphone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Handphone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate(UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Return UsersProfile.LastUpdateDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                UsersProfile.LastUpdateDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property MarriageId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.MarriageId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.MarriageId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Nick(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Nick(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Nick(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Passport(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Passport(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Passport(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Phone(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Phone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Phone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.PhoneExt(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.PhoneExt(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' EXPERIMENTAL
        ''' </summary>
        Public Shared Property Picture(UserId As Integer, ProviderConnectionString As String) As Byte()
            Get
                Return UsersProfile.Picture(UserId, ProviderConnectionString)
            End Get
            Set(value As Byte())
                UsersProfile.Picture(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PositionId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.PositionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.PositionId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Postcode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Postcode(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Postcode(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property RegistrationDate(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.RegistrationDate(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.RegistrationDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SatelliteId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.SatelliteId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.SatelliteId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SequenceNo(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.SequenceNo(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.SequenceNo(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property State(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.State(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.State(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Twitter(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Twitter(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property UnitId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.UnitId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.UnitId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property UnitName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _UnitId As Integer = UnitId(UserId, ProviderConnectionString)
                Return Table.OfficeUnit.Unit(_UnitId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Website(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Website(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Website(UserId, ProviderConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get / Set Student Campus Id.
        ''' </summary>
        Public Shared Property CampusId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.CampusId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.CampusId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Campus Id. READONLY.
        ''' to edit please use CampusId()
        ''' </summary>
        Public Shared ReadOnly Property CampusName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _CampusId As Integer = CampusId(UserId, ProviderConnectionString)
                Return Table.StudCampus.CampusName(_CampusId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Faculty Id.
        ''' </summary>
        Public Shared Property FacultyId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.FacultyId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.FacultyId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Faculty Id. READONLY.
        ''' to edit please use FacultyId()
        ''' </summary>
        Public Shared ReadOnly Property FacultyName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(UserId, ProviderConnectionString)
                Return Table.StudFaculty.FacultyName(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Program Id.
        ''' </summary>
        Public Shared Property ProgramId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.ProgramId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.ProgramId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Id. READONLY.
        ''' to edit please use ProgramId()
        ''' </summary>
        Public Shared ReadOnly Property ProgramName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(UserId, ProviderConnectionString)
                Return Table.StudProgram.ProgramDesc(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Program Level Id.
        ''' </summary>
        Public Shared Property ProgLevelId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.LevelId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.LevelId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Level Description. READONLY.
        ''' to edit please use ProgLevelId()
        ''' </summary>
        Public Shared ReadOnly Property ProgLevelName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ProgLevelId As Integer = ProgLevelId(UserId, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelDesc(_ProgLevelId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Study Mode Id.
        ''' </summary>
        Public Shared Property ModeId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.ModeId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.ModeId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Study Mode Description. READONLY.
        ''' to edit please use ModeId()
        ''' </summary>
        Public Shared ReadOnly Property ModeName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(UserId, ProviderConnectionString)
                Return Table.StudMode.ModDesc(_ModeId, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "Organization"
        Public Shared Property OrganizationId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.StaffDepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.StaffDepartmentId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property OrganizationName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim OrgId As Integer = OrganizationId(UserId, ProviderConnectionString)
                Return Table.StafDepartment.DeptName(OrgId, ProviderConnectionString)
            End Get
        End Property

#End Region

#End Region

#Region "By Username"

        Public Shared Property Address1(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address1(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address1(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address2(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address2(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Address3(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Address3(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BirthDay(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.BirthDate(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.BirthDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Blogspot(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Blogspot(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.BranchId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.BranchId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property BranchName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _BranchId As Integer = BranchId(Username, ProviderConnectionString)
                Return Table.OfficeBranch.Branch(_BranchId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property BranchName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _BranchId As Integer = BranchId(UserId, ProviderConnectionString)
                Return Table.OfficeBranch.Branch(_BranchId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property City(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.City(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.City(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Country(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Country(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Country(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DepartmentId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.DepartmentId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.DepartmentId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DepartmentName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim DeptId As Integer = DepartmentId(Username, ProviderConnectionString)
                Return Table.OfficeDepartment.Department(DeptId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property DivisionId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.DivisionId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.DivisionId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DivisionName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim DivId As Integer = DivisionId(Username, ProviderConnectionString)
                Return Table.OfficeDivision.Division(DivId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Email2(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Email(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Email(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpireDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return UsersProfile.ExpireDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                UsersProfile.ExpireDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Facebook(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Facebook(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Facebook(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Fax(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Fax(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property IsFirstTime(Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return UsersProfile.IsFirstTime(Username, ProviderConnectionString)
            End Get
            Set(value As Boolean)
                UsersProfile.IsFirstTime(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fullname(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.FullName(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.FullName(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.GenderId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.GenderId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property GenderName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _GenderId As Integer = GenderId(Username, ProviderConnectionString)
                Return Table.UsersGender.Gender(_GenderId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property GradeId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.GradeId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.GradeId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Grade by Username
        ''' </summary>
        Public Shared ReadOnly Property GradeCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(Username, ProviderConnectionString)
                Return UsersPositionGrade.Grade(_GradeId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Grade by UserId
        ''' </summary>
        Public Shared ReadOnly Property GradeCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(UserId, ProviderConnectionString)
                Return UsersPositionGrade.Grade(_GradeId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Grade Type by UserId
        ''' </summary>
        Public Shared ReadOnly Property GradeType(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(UserId, ProviderConnectionString)
                Return UsersPositionGrade.GradeType(_GradeId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Grade Rank by UserId
        ''' </summary>
        Public Shared ReadOnly Property GradeRank(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(UserId, ProviderConnectionString)
                Return UsersPositionGrade.GradeRank(_GradeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Handphone(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Handphone(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Handphone(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return UsersProfile.LastUpdateDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                UsersProfile.LastUpdateDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property MarriageId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.MarriageId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.MarriageId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Nick(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Nick(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Nick(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property IsNickAvailable(_Nick As String, ProviderConnectionString As String) As Boolean
            Get
                Return UsersProfile.IsNickAvailable(_Nick, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Passport(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Passport(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Passport(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Phone(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Phone(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Phone(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.PhoneExt(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.PhoneExt(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' EXPERIMENTAL
        ''' </summary>
        Public Shared Property Picture(Username As String, ProviderConnectionString As String) As Byte()
            Get
                Return UsersProfile.Picture(Username, ProviderConnectionString)
            End Get
            Set(value As Byte())
                UsersProfile.Picture(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PositionId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.PositionId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.PositionId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property PositionName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _PositionId As Integer = PositionId(Username, ProviderConnectionString)

                Return UsersPosition.Position(_PositionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property PositionName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _PositionId As Integer = PositionId(UserId, ProviderConnectionString)

                Return UsersPosition.Position(_PositionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Postcode(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Postcode(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Postcode(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property RegistrationDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return UsersProfile.RegistrationDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                UsersProfile.RegistrationDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SatelliteId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.SatelliteId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.SatelliteId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property SatelliteName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _SatelliteId As Integer = SatelliteId(Username, ProviderConnectionString)
                Return OfficeSatellite.Satellite(_SatelliteId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property SatelliteName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _SatelliteId As Integer = SatelliteId(UserId, ProviderConnectionString)
                Return OfficeSatellite.Satellite(_SatelliteId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property SequenceNo(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.SequenceNo(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.SequenceNo(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property State(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.State(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.State(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Twitter(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Twitter(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property UnitId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.UnitId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.UnitId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property UnitName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _UnitId As Integer = UnitId(Username, ProviderConnectionString)
                Return Table.OfficeUnit.Unit(_UnitId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Website(Username As String, ProviderConnectionString As String) As String
            Get
                Return UsersProfile.Website(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                UsersProfile.Website(Username, ProviderConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get / Set Student Campus Id.
        ''' </summary>
        Public Shared Property CampusId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.CampusId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.CampusId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Campus Id. READONLY.
        ''' to edit please use CampusId()
        ''' </summary>
        Public Shared ReadOnly Property CampusName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _CampusId As Integer = CampusId(Username, ProviderConnectionString)
                Return Table.StudCampus.CampusName(_CampusId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Faculty Id.
        ''' </summary>
        Public Shared Property FacultyId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.FacultyId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.FacultyId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Faculty Id. READONLY.
        ''' to edit please use FacultyId()
        ''' </summary>
        Public Shared ReadOnly Property FacultyName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(Username, ProviderConnectionString)
                Return Table.StudFaculty.FacultyName(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Program Id.
        ''' </summary>
        Public Shared Property ProgramId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.ProgramId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.ProgramId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Id. READONLY.
        ''' to edit please use ProgramId()
        ''' </summary>
        Public Shared ReadOnly Property ProgramName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(Username, ProviderConnectionString)
                Return Table.StudProgram.ProgramDesc(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Program Level Id.
        ''' </summary>
        Public Shared Property ProgLevelId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.LevelId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.LevelId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Level Description. READONLY.
        ''' to edit please use ProgLevelId()
        ''' </summary>
        Public Shared ReadOnly Property ProgLevelName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ProgLevelId As Integer = ProgLevelId(Username, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelDesc(_ProgLevelId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get / Set Student Study Mode Id.
        ''' </summary>
        Public Shared Property ModeId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.ModeId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.ModeId(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Study Mode Description. READONLY.
        ''' to edit please use ModeId()
        ''' </summary>
        Public Shared ReadOnly Property ModeName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(Username, ProviderConnectionString)
                Return Table.StudMode.ModDesc(_ModeId, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "Organization"
        Public Shared Property OrganizationId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UsersProfile.StaffDepartmentId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                UsersProfile.StaffDepartmentId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property OrganizationName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim OrgId As Integer = OrganizationId(Username, ProviderConnectionString)
                Return Table.StafDepartment.DeptName(OrgId, ProviderConnectionString)
            End Get
        End Property

#End Region

#End Region

#End Region

#Region "From UsersGender"

        ''' <summary>
        ''' Get / Set User Gender by GenderName
        ''' </summary>
        Public Shared Property GenderName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _GenderId As Integer = GenderId(UserId, ProviderConnectionString)
                Return UsersGender.Gender(_GenderId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _GenderId As Integer = UsersGender.Id(value, ProviderConnectionString)
                UsersProfile.GenderId(UserId, ProviderConnectionString) = _GenderId
            End Set
        End Property

#End Region

#Region "From UsersMarriage"

        ''' <summary>
        ''' Get / Set User Gender by GenderName
        ''' </summary>
        Public Shared Property MarriageName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _MarriageId As Integer = MarriageId(UserId, ProviderConnectionString)
                Return UsersMarriage.Marriage(_MarriageId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _MarriageId As Integer = UsersMarriage.Id(value, ProviderConnectionString)
                UsersProfile.MarriageId(UserId, ProviderConnectionString) = _MarriageId
            End Set
        End Property

        Public Shared Property MarriageName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _MarriageId As Integer = MarriageId(Username, ProviderConnectionString)
                Return UsersMarriage.Marriage(_MarriageId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _MarriageId As Integer = UsersMarriage.Id(value, ProviderConnectionString)
                UsersProfile.MarriageId(Username, ProviderConnectionString) = _MarriageId
            End Set
        End Property

#End Region

#End Region

    End Class

End Namespace

