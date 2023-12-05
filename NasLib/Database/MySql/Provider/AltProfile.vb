Imports NasLib.Database.MySql.Provider.Table

Namespace Database.MySql.Provider

    Public Class AltProfile

#Region "Public Functions"

#Region "By UserId"

        Public Shared Function Username(UserId As Integer, ProviderConnectionString As String) As String
            Return AltUsersProfile.Username(UserId, ProviderConnectionString)
        End Function


        Public Shared Function IsPicExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return AltUsersProfile.IsPictureExisted(UserId, ProviderConnectionString)
        End Function

        Public Shared Function PicSize(UserId As Integer, ProviderConnectionString As String) As Long
            Return AltUsersProfile.PictureSize(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return AltUsersProfile.IsExisted(UserId, ProviderConnectionString)
        End Function

#End Region

#Region "By Username"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Return AltUsersProfile.UserId(Username, ProviderConnectionString)
        End Function

        Public Shared Function IsPicExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return AltUsersProfile.IsPictureExisted(Username, ProviderConnectionString)
        End Function

        Public Shared Function PicSize(Username As String, ProviderConnectionString As String) As Long
            Return AltUsersProfile.PictureSize(Username, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return AltUsersProfile.IsExisted(Username, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Public Properties"

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
                Return AltUsersProfile.Address1(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address1(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Address2(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address2(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Address3(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address3(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BirthDay(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim ReturnValue As String = Nothing

                If AltUsersProfile.IsBirthDateAvailable(UserId, ProviderConnectionString) Then
                    ReturnValue = Format(UsersProfile.BirthDate(UserId, ProviderConnectionString), "dd MMMM yyy")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                AltUsersProfile.BirthDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Blogspot(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Blogspot(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.BranchId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.BranchId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property City(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.City(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.City(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Country(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Country(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Country(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DepartmentId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.DepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.DepartmentId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property DepartmentName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim DeptId As Integer = DepartmentId(UserId, ProviderConnectionString)
                Return Table.OfficeDepartment.Department(DeptId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property StafDepartmentId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.StaffDepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.DepartmentId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property StafDepartmentName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return Table.AltUsersProfile.StaffDepartmentName(UserId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property DivisionId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.DivisionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.DivisionId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.Email(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Email(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpireDate(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.ExpireDate(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.ExpireDate(UserId, ProviderConnectionString) = CDate(value)
            End Set
        End Property

        Public Shared Property Facebook(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Facebook(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Facebook(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Fax(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Fax(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fullname(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.FullName(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.FullName(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.GenderId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.GenderId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GradeId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.GradeId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.GradeId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Handphone(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Handphone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Handphone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate(UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Return AltUsersProfile.LastUpdateDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                AltUsersProfile.LastUpdateDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property MarriageId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.MarriageId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.MarriageId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Nick(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Nick(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Nick(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Passport(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Passport(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Passport(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Phone(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Phone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Phone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.PhoneExt(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.PhoneExt(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' EXPERIMENTAL
        ''' </summary>
        Public Shared Property Picture(UserId As Integer, ProviderConnectionString As String) As Byte()
            Get
                Return AltUsersProfile.Picture(UserId, ProviderConnectionString)
            End Get
            Set(value As Byte())
                AltUsersProfile.Picture(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PositionId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.PositionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.PositionId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Postcode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Postcode(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Postcode(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property RegistrationDate(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.RegistrationDate(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.RegistrationDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SatelliteId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.SatelliteId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.SatelliteId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SequenceNo(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.SequenceNo(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.SequenceNo(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property State(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.State(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.State(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Twitter(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Twitter(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property UnitId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.UnitId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.UnitId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.Website(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Website(UserId, ProviderConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get / Set Student Campus Id.
        ''' </summary>
        Public Shared Property CampusId(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.CampusId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.CampusId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.FacultyId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.FacultyId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.ProgramId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.ProgramId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.LevelId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.LevelId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.ModeId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.ModeId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.StaffDepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.StaffDepartmentId(UserId, ProviderConnectionString) = value
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
                Return AltUsersProfile.Address1(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address1(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Address2(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address2(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Address3(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Address3(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BirthDay(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.BirthDate(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.BirthDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Blogspot(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Blogspot(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.BranchId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.BranchId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.City(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.City(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Country(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Country(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Country(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DepartmentId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.DepartmentId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.DepartmentId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.DivisionId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.DivisionId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.Email(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Email(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpireDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return AltUsersProfile.ExpireDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                AltUsersProfile.ExpireDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Facebook(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Facebook(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Facebook(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Fax(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Fax(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property IsFirstTime(Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return AltUsersProfile.IsFirstTime(Username, ProviderConnectionString)
            End Get
            Set(value As Boolean)
                AltUsersProfile.IsFirstTime(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fullname(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.FullName(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.FullName(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.GenderId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.GenderId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.GradeId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.GradeId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.Handphone(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Handphone(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return AltUsersProfile.LastUpdateDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                AltUsersProfile.LastUpdateDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property MarriageId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.MarriageId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.MarriageId(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Nick(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Nick(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Nick(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property IsNickAvailable(_Nick As String, ProviderConnectionString As String) As Boolean
            Get
                Return AltUsersProfile.IsNickAvailable(_Nick, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property Passport(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Passport(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Passport(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Phone(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Phone(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Phone(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.PhoneExt(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.PhoneExt(Username, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' EXPERIMENTAL
        ''' </summary>
        Public Shared Property Picture(Username As String, ProviderConnectionString As String) As Byte()
            Get
                Return AltUsersProfile.Picture(Username, ProviderConnectionString)
            End Get
            Set(value As Byte())
                AltUsersProfile.Picture(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PositionId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.PositionId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.PositionId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.Postcode(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Postcode(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property RegistrationDate(Username As String, ProviderConnectionString As String) As Date
            Get
                Return AltUsersProfile.RegistrationDate(Username, ProviderConnectionString)
            End Get
            Set(value As Date)
                AltUsersProfile.RegistrationDate(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SatelliteId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.SatelliteId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.SatelliteId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.SequenceNo(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.SequenceNo(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property State(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.State(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.State(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter(Username As String, ProviderConnectionString As String) As String
            Get
                Return AltUsersProfile.Twitter(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Twitter(Username, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property UnitId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.UnitId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.UnitId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.Website(Username, ProviderConnectionString)
            End Get
            Set(value As String)
                AltUsersProfile.Website(Username, ProviderConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get / Set Student Campus Id.
        ''' </summary>
        Public Shared Property CampusId(Username As String, ProviderConnectionString As String) As Integer
            Get
                Return AltUsersProfile.CampusId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.CampusId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.FacultyId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.FacultyId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.ProgramId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.ProgramId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.LevelId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.LevelId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.ModeId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.ModeId(Username, ProviderConnectionString) = value
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
                Return AltUsersProfile.StaffDepartmentId(Username, ProviderConnectionString)
            End Get
            Set(value As Integer)
                AltUsersProfile.StaffDepartmentId(Username, ProviderConnectionString) = value
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
                AltUsersProfile.GenderId(UserId, ProviderConnectionString) = _GenderId
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
                AltUsersProfile.MarriageId(UserId, ProviderConnectionString) = _MarriageId
            End Set
        End Property

        Public Shared Property MarriageName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _MarriageId As Integer = MarriageId(Username, ProviderConnectionString)
                Return UsersMarriage.Marriage(_MarriageId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _MarriageId As Integer = UsersMarriage.Id(value, ProviderConnectionString)
                AltUsersProfile.MarriageId(Username, ProviderConnectionString) = _MarriageId
            End Set
        End Property

#End Region

#End Region

    End Class

End Namespace

