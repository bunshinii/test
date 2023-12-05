Imports NasLib.Database.MySql.Provider

Namespace Database.MySql.Provider.QuickFunctions

    ''' <summary>
    ''' Get or Set User Data. Must specify ProvidersConnectionString first
    ''' </summary>
    Public Class UserData

        Public Shared Property ProvidersConnectionString As String
            Get
                Return _ProvidersConnectionString
            End Get
            Set(value As String)
                _ProvidersConnectionString = value
            End Set
        End Property

#Region "Current User Profile"

        Private Shared ReadOnly Property _Username As String
            Get
                Return Functions.Web.CurrentUser.Username
            End Get
        End Property

        ''' <summary>
        ''' Check if the user is loggged in for the first time.
        ''' </summary>
        Public Shared Property IsFirtsTime() As Boolean
            Get
                Return Profile.IsFirstTime(_Username, _ProvidersConnectionString)
            End Get
            Set(value As Boolean)
                Profile.IsFirstTime(_Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property IsStaff() As Boolean
            Get
                Return IsStaff(_Username)
            End Get
        End Property

        Public Shared Property IsLibraryStaff() As Boolean
            Set(value As Boolean)
                IsLibraryStaff(_Username) = value
            End Set
            Get
                Return IsLibraryStaff(_Username)
            End Get
        End Property

        Public Shared ReadOnly Property IsStudent() As Boolean
            Get
                Return IsStudent(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User Fullname.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Fullname As String
            Get
                Return Fullname(_Username)
            End Get
            Set(value As String)
                Fullname(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Address1.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Address1 As String
            Get
                Return Address1(_Username)
            End Get
            Set(value As String)
                Address1(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Address2.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Address2 As String
            Get
                Return Address2(_Username)
            End Get
            Set(value As String)
                Address2(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Address3.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Address3 As String
            Get
                Return Address3(_Username)
            End Get
            Set(value As String)
                Address3(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User BirthDay.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property BirthDay As String
            Get
                Return BirthDay(_Username)
            End Get
            Set(value As String)
                BirthDay(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Blogspot.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Blogspot As String
            Get
                Return Blogspot(_Username)
            End Get
            Set(value As String)
                Blogspot(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User BranchId.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property BranchId As Integer
            Get
                Return BranchId(_Username)
            End Get
            Set(value As Integer)
                BranchId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User BranchName.
        ''' Make sure running in 'If IsAuthenticated Then'
        ''' To edit please use BranchId
        ''' </summary>
        Public Shared ReadOnly Property BranchName As String
            Get
                Return BranchName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User City.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property City As String
            Get
                Return City(_Username)
            End Get
            Set(value As String)
                City(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Comment.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Comment As String
            Get
                Return Comment(_Username)
            End Get
            Set(value As String)
                Comment(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Country.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property Country As String
            Get
                Return Country(_Username)
            End Get
            Set(value As String)
                Country(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User CreationDate.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property CreationDate As Date
            Get
                Return CreationDate(_Username)
            End Get
            Set(value As Date)
                CreationDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User DepartmentId.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property DepartmentId As Integer
            Get
                Return DepartmentId(_Username)
            End Get
            Set(value As Integer)
                DepartmentId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User DepartmentName.
        ''' Make sure running in 'If IsAuthenticated Then'
        ''' To edit please use DepartmentId
        ''' </summary>
        Public Shared ReadOnly Property DepartmentName As String
            Get
                Return DepartmentName(_Username)

            End Get
        End Property

        ''' <summary>
        ''' Get Current User DivisionId.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property DivisionId As Integer
            Get
                Return DivisionId(_Username)
            End Get
            Set(value As Integer)
                DivisionId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User DivisionName.
        ''' Make sure running in 'If IsAuthenticated Then'
        ''' To edit please use DivisionId
        ''' </summary>
        Public Shared ReadOnly Property DivisionName As String
            Get
                Return DivisionName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User Email (Official). 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' Avoid using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared Property Email As String
            Get
                Return Email(_Username)
            End Get
            Set(value As String)
                Email(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Email2 (Personal).
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Email2 As String
            Get
                Return Email2(_Username)
            End Get
            Set(value As String)
                Email2(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User ExpireDate.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property ExpireDate As Date
            Get
                Return ExpireDate(_Username)
            End Get
            Set(value As Date)
                ExpireDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Facebook.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Facebook As String
            Get
                Return Facebook(_Username)
            End Get
            Set(value As String)
                Facebook(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Fax.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Fax As String
            Get
                Return Fax(_Username)
            End Get
            Set(value As String)
                Fax(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User GenderId.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property GenderId As Integer
            Get
                Return GenderId(_Username)
            End Get
            Set(value As Integer)
                GenderId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User GenderName.
        ''' Make sure running in 'If IsAuthenticated Then'
        ''' To edit please use GenderId
        ''' </summary>
        Public Shared ReadOnly Property GenderName() As String
            Get
                Return GenderName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User GradeId.
        ''' Make sure running in 'If IsAuthenticated Then' 
        ''' </summary>
        Public Shared Property GradeId As Integer
            Get
                Return GradeId(_Username)
            End Get
            Set(value As Integer)
                GradeId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User GradeCode.
        ''' Make sure running in 'If IsAuthenticated Then'
        ''' To edit please use GradeId
        ''' </summary>
        Public Shared ReadOnly Property GradeCode() As String
            Get
                Return GradeCode(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User Handphone.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Handphone As String
            Get
                Return Handphone(_Username)
            End Get
            Set(value As String)
                Handphone(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User LastLoginDate.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property LastLoginDate As Date
            Get
                Return LastLoginDate(_Username)
            End Get
            Set(value As Date)
                LastLoginDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User LastPasswordChangedDate.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property LastPasswordChangedDate As Date
            Get
                Return LastPasswordChangedDate(_Username)
            End Get
            Set(value As Date)
                LastPasswordChangedDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User LastUpdateDate.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property LastUpdateDate As Date
            Get
                Return LastUpdateDate(_Username)
            End Get
            Set(value As Date)
                LastUpdateDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User MarriageId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property MarriageId As Integer
            Get
                Return MarriageId(_Username)
            End Get
            Set(value As Integer)
                MarriageId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User MarriageId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Marriage As String
            Get
                Return Marriage(_Username)
            End Get
            Set(value As String)
                Marriage(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Nick.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Nick As String
            Get
                Return Nick(_Username)
            End Get
            Set(value As String)
                Nick(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Passport.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Passport As String
            Get
                Return Passport(_Username)
            End Get
            Set(value As String)
                Passport(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Password.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Password As String
            Get
                Return Password(_Username)
            End Get
            Set(value As String)
                Password(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User PasswordAnswer.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property PasswordAnswer As String
            Get
                Return PasswordAnswer(_Username)
            End Get
            Set(value As String)
                PasswordAnswer(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User PasswordQuestion.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property PasswordQuestion As String
            Get
                Return PasswordQuestion(_Username)
            End Get
            Set(value As String)
                PasswordQuestion(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Phone.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Phone As String
            Get
                Return Phone(_Username)
            End Get
            Set(value As String)
                Phone(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User PhoneExt.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property PhoneExt As String
            Get
                Return PhoneExt(_Username)
            End Get
            Set(value As String)
                PhoneExt(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User PositionId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property PositionId As String
            Get
                Return PositionId(_Username)
            End Get
            Set(value As String)
                PositionId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User PositionName.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property PositionName As String
            Get
                Return PositionName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User Postcode.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Postcode As String
            Get
                Return Postcode(_Username)
            End Get
            Set(value As String)
                Postcode(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User RegistrationDate.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property RegistrationDate As Date
            Get
                Return RegistrationDate(_Username)
            End Get
            Set(value As Date)
                RegistrationDate(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User SatelliteId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property SatelliteId As Integer
            Get
                Return SatelliteId(_Username)
            End Get
            Set(value As Integer)
                SatelliteId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User SatelliteId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property SatelliteName As String
            Get
                Return SatelliteName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User SequenceNo.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property SequenceNo As Integer
            Get
                Return SequenceNo(_Username)
            End Get
            Set(value As Integer)
                SequenceNo(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User State.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property State As Integer
            Get
                Return State(_Username)
            End Get
            Set(value As Integer)
                State(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User Twitter.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Twitter As Integer
            Get
                Return Twitter(_Username)
            End Get
            Set(value As Integer)
                Twitter(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User UnitId.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property UnitId As Integer
            Get
                Return UnitId(_Username)
            End Get
            Set(value As Integer)
                UnitId(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Current User UnitName.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property UnitName As String
            Get
                Return UnitName(_Username)
            End Get
        End Property

        ''' <summary>
        ''' Get Current User Website.
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' </summary>
        Public Shared Property Website As Integer
            Get
                Return Website(_Username)
            End Get
            Set(value As Integer)
                Website(_Username) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User OrganizationId.
        ''' </summary>
        Public Shared Property OrganizationId() As Integer
            Get
                Return Profile.OrganizationId(_Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.OrganizationId(_Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User OrganizationName.
        ''' To edit please use OrganizationId
        ''' </summary>
        Public Shared ReadOnly Property OrganizationName() As String
            Get
                Return Profile.OrganizationName(_Username, _ProvidersConnectionString)
            End Get
        End Property

#End Region

#Region "Other User Profile"

#Region "By Username"

        ''' <summary>
        ''' Get UserId from Username. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared ReadOnly Property UserId(Username As String) As Integer
            Get
                Return Table.UsersProfile.Id(Username, _ProvidersConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property IsExisted(Username As String) As Boolean
            Get
                Return Table.UsersProfile.IsExisted(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Staff. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared ReadOnly Property IsStaff(Username As String) As Boolean
            Get
                Return Role.IsUserInRole(Username, "Staff", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Staff. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared ReadOnly Property IsStaff(UserId As Integer) As Boolean
            Get
                Return Role.IsUserInRole(UserId, "Staff", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Library Staff. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared Property IsLibraryStaff(Username As String) As Boolean
            Set(value As Boolean)
                If value Then
                    Table.UsersInRoles.AssignUserRole(Username, "Library Staff", _ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(Username, "Library Staff", _ProvidersConnectionString)
                End If
            End Set
            Get
                Return Role.IsUserInRole(Username, "Library Staff", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Library Staff. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared Property IsLibraryStaff(UserId As Integer) As Boolean
            Set(value As Boolean)
                If value Then
                    Table.UsersInRoles.AssignUserRole(UserId, "Library Staff", _ProvidersConnectionString)
                Else
                    Table.UsersInRoles.UnAssignUserRole(UserId, "Library Staff", _ProvidersConnectionString)
                End If
            End Set
            Get
                Return Role.IsUserInRole(UserId, "Library Staff", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Student. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared ReadOnly Property IsStudent(Username As String) As Boolean
            Get
                Return Role.IsUserInRole(Username, "Student", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get If User is a Student. 
        ''' Make sure running in 'If IsAuthenticated Then'.
        ''' AVOID using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared ReadOnly Property IsStudent(UserId As Integer) As Boolean
            Get
                Return Role.IsUserInRole(UserId, "Student", _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Check if the user is loggged in for the first time.
        ''' </summary>
        Public Shared Property IsFirtsTime(Username As String) As Boolean
            Get
                Return Profile.IsFirstTime(Username, _ProvidersConnectionString)
            End Get
            Set(value As Boolean)
                Profile.IsFirstTime(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Fullname.
        ''' </summary>
        Public Shared Property Fullname(Username As String) As String
            Get
                Return Profile.Fullname(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Fullname(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address1.
        ''' </summary>
        Public Shared Property Address1(Username As String) As String
            Get
                Return Profile.Address1(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address1(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address2.
        ''' </summary>
        Public Shared Property Address2(Username As String) As String
            Get
                Return Profile.Address2(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address2(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address3.
        ''' </summary>
        Public Shared Property Address3(Username As String) As String
            Get
                Return Profile.Address3(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address3(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BirthDay.
        ''' </summary>
        Public Shared Property BirthDay(Username As String) As String
            Get
                Return Profile.BirthDay(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.BirthDay(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Blogspot.
        ''' </summary>
        Public Shared Property Blogspot(Username As String) As String
            Get
                Return Profile.Blogspot(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Blogspot(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BranchId.
        ''' </summary>
        Public Shared Property BranchId(Username As String) As Integer
            Get
                Return Profile.BranchId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.BranchId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BranchName.
        ''' To edit please use BranchId
        ''' </summary>
        Public Shared ReadOnly Property BranchName(Username As String) As String
            Get
                Return Profile.BranchName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User City.
        ''' </summary>
        Public Shared Property City(Username As String) As String
            Get
                Return Profile.City(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.City(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Comment.
        ''' </summary>
        Public Shared Property Comment(Username As String) As String
            Get
                Return Profile.Comment(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Comment(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Country.
        ''' </summary>
        Public Shared Property Country(Username As String) As String
            Get
                Return Profile.Country(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Country(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User CreationDate.
        ''' </summary>
        Public Shared Property CreationDate(Username As String) As Date
            Get
                Return Profile.CreationDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.CreationDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DepartmentId.
        ''' </summary>
        Public Shared Property DepartmentId(Username As String) As Integer
            Get
                Return Profile.DepartmentId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.DepartmentId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DepartmentName.
        ''' To edit please use DepartmentId
        ''' </summary>
        Public Shared ReadOnly Property DepartmentName(Username As String) As String
            Get
                Return Profile.DepartmentName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User DivisionId.
        ''' </summary>
        Public Shared Property DivisionId(Username As String) As Integer
            Get
                Return Profile.DivisionId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.DivisionId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DivisionName.
        ''' To edit please use DivisionId
        ''' </summary>
        Public Shared ReadOnly Property DivisionName(Username As String) As String
            Get
                Return Profile.DivisionName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Email.
        ''' Avoid using this function many times to avoid multiple queries on database.
        ''' Just call it once and better keep this functions value in a variable.
        ''' </summary>
        Public Shared Property Email(Username As String) As String
            Get
                Dim UserId As Integer = Profile.UserId(Username, _ProvidersConnectionString)
                Return Profile.Email(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Dim UserId As Integer = Profile.UserId(Username, _ProvidersConnectionString)
                Profile.Email(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Email2.
        ''' </summary>
        Public Shared Property Email2(Username As String) As String
            Get
                Return Profile.Email2(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Email2(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User ExpireDate.
        ''' </summary>
        Public Shared Property ExpireDate(Username As String) As Date
            Get
                Return Profile.ExpireDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.ExpireDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Facebook.
        ''' </summary>
        Public Shared Property Facebook(Username As String) As String
            Get
                Return Profile.Facebook(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Facebook(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Fax.
        ''' </summary>
        Public Shared Property Fax(Username As String) As String
            Get
                Return Profile.Fax(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Fax(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GenderId.
        ''' </summary>
        Public Shared Property GenderId(Username As String) As Integer
            Get
                Return Profile.GenderId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.GenderId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GenderName.
        ''' To edit please use GenderId
        ''' </summary>
        Public Shared ReadOnly Property GenderName(Username As String) As String
            Get
                Return Profile.GenderName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User GradeId.
        ''' </summary>
        Public Shared Property GradeId(Username As String) As Integer
            Get
                Return Profile.GradeId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.GradeId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GradeCode.
        ''' To edit please use GradeId
        ''' </summary>
        Public Shared ReadOnly Property GradeCode(Username As String) As String
            Get
                Return Profile.GradeCode(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Handphone.
        ''' </summary>
        Public Shared Property Handphone(Username As String) As String
            Get
                Return Profile.Handphone(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Handphone(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastLoginDate.
        ''' </summary>
        Public Shared Property LastLoginDate(Username As String) As Date
            Get
                Return Profile.LastLoginDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastLoginDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastPasswordChangedDate.
        ''' </summary>
        Public Shared Property LastPasswordChangedDate(Username As String) As Date
            Get
                Return Profile.LastPasswordChangedDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastPasswordChangedDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastUpdateDate.
        ''' </summary>
        Public Shared Property LastUpdateDate(Username As String) As Date
            Get
                Return Profile.LastUpdateDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastUpdateDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User MarriageId.
        ''' </summary>
        Public Shared Property MarriageId(Username As String) As Integer
            Get
                Return Profile.MarriageId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.MarriageId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User MarriageId.
        ''' </summary>
        Public Shared Property Marriage(Username As String) As String
            Get
                Return Profile.MarriageName(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.MarriageId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Nick.
        ''' </summary>
        Public Shared Property Nick(Username As String) As String
            Get
                Return Profile.Nick(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Nick(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        Public Shared ReadOnly Property IsNickAvailable(_Nick As String) As Boolean
            Get
                Return Profile.IsNickAvailable(_Nick, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Passport.
        ''' </summary>
        Public Shared Property Passport(Username As String) As String
            Get
                Return Profile.Passport(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Passport(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Password.
        ''' </summary>
        Public Shared Property Password(Username As String) As String
            Get
                Return Profile.Password(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Password(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PasswordAnswer.
        ''' </summary>
        Public Shared Property PasswordAnswer(Username As String) As String
            Get
                Return Profile.PasswordAnswer(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PasswordAnswer(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PasswordQuestion.
        ''' </summary>
        Public Shared Property PasswordQuestion(Username As String) As String
            Get
                Return Profile.PasswordQuestion(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PasswordQuestion(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Phone.
        ''' </summary>
        Public Shared Property Phone(Username As String) As String
            Get
                Return Profile.Phone(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Phone(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PhoneExt.
        ''' </summary>
        Public Shared Property PhoneExt(Username As String) As String
            Get
                Return Profile.PhoneExt(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PhoneExt(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PositionId.
        ''' </summary>
        Public Shared Property PositionId(Username As String) As String
            Get
                Return Profile.PositionId(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PositionId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PositionName.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property PositionName(Username As String) As String
            Get
                Return Profile.PositionName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Postcode.
        ''' </summary>
        Public Shared Property Postcode(Username As String) As String
            Get
                Return Profile.Postcode(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Postcode(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User RegistrationDate.
        ''' </summary>
        Public Shared Property RegistrationDate(Username As String) As Date
            Get
                Return Profile.RegistrationDate(Username, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.RegistrationDate(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User SatelliteId.
        ''' </summary>
        Public Shared Property SatelliteId(Username As String) As Integer
            Get
                Return Profile.SatelliteId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.SatelliteId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User SatelliteId.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property SatelliteName(Username As String) As String
            Get
                Return Profile.SatelliteName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User SequenceNo.
        ''' </summary>
        Public Shared Property SequenceNo(Username As String) As Integer
            Get
                Return Profile.SequenceNo(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.SequenceNo(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User State.
        ''' </summary>
        Public Shared Property State(Username As String) As Integer
            Get
                Return Profile.State(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.State(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Twitter.
        ''' </summary>
        Public Shared Property Twitter(Username As String) As Integer
            Get
                Return Profile.Twitter(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.Twitter(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User UnitId.
        ''' </summary>
        Public Shared Property UnitId(Username As String) As Integer
            Get
                Return Profile.UnitId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.UnitId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User UnitName.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property UnitName(Username As String) As String
            Get
                Return Profile.UnitName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Website.
        ''' </summary>
        Public Shared Property Website(Username As String) As Integer
            Get
                Return Profile.Website(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.Website(Username, _ProvidersConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get Student CampusId.
        ''' </summary>
        Public Shared Property CampusId(Username As String) As Integer
            Get
                Return Profile.CampusId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.CampusId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Campus Name.
        ''' To edit please use CampusId()
        ''' </summary>
        Public Shared ReadOnly Property CampusName(Username As String) As String
            Get
                Return Profile.CampusName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student FacultyId.
        ''' </summary>
        Public Shared Property FacultyId(Username As String) As Integer
            Get
                Return Profile.FacultyId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.FacultyId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Faculty Name.
        ''' To edit please use FacultyId()
        ''' </summary>
        Public Shared ReadOnly Property FacultyName(Username As String) As String
            Get
                Return Profile.FacultyName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student ProgramId.
        ''' </summary>
        Public Shared Property ProgramId(Username As String) As Integer
            Get
                Return Profile.ProgramId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ProgramId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Name.
        ''' To edit please use ProgramId()
        ''' </summary>
        Public Shared ReadOnly Property ProgramName(Username As String) As String
            Get
                Return Profile.ProgramName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student Program Level Id.
        ''' </summary>
        Public Shared Property ProgLevelId(Username As String) As Integer
            Get
                Return Profile.ProgLevelId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ProgLevelId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Level Name.
        ''' To edit please use ProgLevelId()
        ''' </summary>
        Public Shared ReadOnly Property ProgLevelName(Username As String) As String
            Get
                Return Profile.ProgLevelName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student Study Mode Id.
        ''' </summary>
        Public Shared Property ModeId(Username As String) As Integer
            Get
                Return Profile.ModeId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ModeId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Study Mode Description.
        ''' To edit please use ModeId()
        ''' </summary>
        Public Shared ReadOnly Property ModeName(Username As String) As String
            Get
                Return Profile.ModeName(Username, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User OrganizationId.
        ''' </summary>
        Public Shared Property OrganizationId(Username As String) As Integer
            Get
                Return Profile.OrganizationId(Username, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.OrganizationId(Username, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User OrganizationName.
        ''' To edit please use OrganizationId
        ''' </summary>
        Public Shared ReadOnly Property OrganizationName(Username As String) As String
            Get
                Return Profile.OrganizationName(Username, _ProvidersConnectionString)
            End Get
        End Property

#End Region

#End Region

#Region "By UserId"

        ''' <summary>
        ''' Get Username.
        ''' </summary>
        Public Shared Property Username(UserId As Integer) As String
            Get
                Return Table.UsersProfile.Username(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Username(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Fullname.
        ''' </summary>
        Public Shared Property Fullname(UserId As Integer) As String
            Get
                Return Profile.Fullname(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Fullname(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address1.
        ''' </summary>
        Public Shared Property Address1(UserId As Integer) As String
            Get
                Return Profile.Address1(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address1(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address2.
        ''' </summary>
        Public Shared Property Address2(UserId As Integer) As String
            Get
                Return Profile.Address2(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address2(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Address3.
        ''' </summary>
        Public Shared Property Address3(UserId As Integer) As String
            Get
                Return Profile.Address3(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Address3(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BirthDay.
        ''' </summary>
        Public Shared Property BirthDay(UserId As Integer) As String
            Get
                Return Profile.BirthDay(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.BirthDay(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Blogspot.
        ''' </summary>
        Public Shared Property Blogspot(UserId As Integer) As String
            Get
                Return Profile.Blogspot(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Blogspot(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BranchId.
        ''' </summary>
        Public Shared Property BranchId(UserId As Integer) As Integer
            Get
                Return Profile.BranchId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.BranchId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User BranchName.
        ''' To edit please use BranchId
        ''' </summary>
        Public Shared ReadOnly Property BranchName(UserId As Integer) As String
            Get
                Return Profile.BranchName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User City.
        ''' </summary>
        Public Shared Property City(UserId As Integer) As String
            Get
                Return Profile.City(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.City(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Comment.
        ''' </summary>
        Public Shared Property Comment(UserId As Integer) As String
            Get
                Return Profile.Comment(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Comment(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Country.
        ''' </summary>
        Public Shared Property Country(UserId As Integer) As String
            Get
                Return Profile.Country(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Country(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User CreationDate.
        ''' </summary>
        Public Shared Property CreationDate(UserId As Integer) As Date
            Get
                Return Profile.CreationDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.CreationDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DepartmentId.
        ''' </summary>
        Public Shared Property DepartmentId(UserId As Integer) As Integer
            Get
                Return Profile.DepartmentId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.DepartmentId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DepartmentName.
        ''' To edit please use DepartmentId
        ''' </summary>
        Public Shared ReadOnly Property DepartmentName(UserId As Integer) As String
            Get
                Return Profile.DepartmentName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User DivisionId.
        ''' </summary>
        Public Shared Property DivisionId(UserId As Integer) As Integer
            Get
                Return Profile.DivisionId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.DivisionId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User DivisionName.
        ''' To edit please use DivisionId
        ''' </summary>
        Public Shared ReadOnly Property DivisionName(UserId As Integer) As String
            Get
                Return Profile.DivisionName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Email.
        ''' (Official)
        ''' </summary>
        Public Shared Property Email(UserId As Integer) As String
            Get
                Return Profile.Email(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Email(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Email2.
        ''' (Personal)
        ''' </summary>
        Public Shared Property Email2(UserId As Integer) As String
            Get
                Return Profile.Email2(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Email2(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User ExpireDate.
        ''' </summary>
        Public Shared Property ExpireDate(UserId As Integer) As String
            Get
                Return Profile.ExpireDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.ExpireDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Facebook.
        ''' </summary>
        Public Shared Property Facebook(UserId As Integer) As String
            Get
                Return Profile.Facebook(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Facebook(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Fax.
        ''' </summary>
        Public Shared Property Fax(UserId As Integer) As String
            Get
                Return Profile.Fax(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Fax(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GenderId.
        ''' </summary>
        Public Shared Property GenderId(UserId As Integer) As Integer
            Get
                Return Profile.GenderId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.GenderId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GenderName.
        ''' To edit please use GenderId
        ''' </summary>
        Public Shared ReadOnly Property GenderName(UserId As Integer) As String
            Get
                Return Profile.GenderName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User GradeId.
        ''' </summary>
        Public Shared Property GradeId(UserId As Integer) As Integer
            Get
                Return Profile.GradeId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.GradeId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User GradeCode.
        ''' To edit please use GradeId
        ''' </summary>
        Public Shared ReadOnly Property GradeCode(UserId As Integer) As String
            Get
                Return Profile.GradeCode(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User GradeType.
        ''' To edit please use GradeId
        ''' </summary>
        Public Shared ReadOnly Property GradeType(UserId As Integer) As String
            Get
                Return Profile.GradeType(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User GradeRank.
        ''' To edit please use GradeId
        ''' </summary>
        Public Shared ReadOnly Property GradeRank(UserId As Integer) As String
            Get
                Return Profile.GradeRank(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Handphone.
        ''' </summary>
        Public Shared Property Handphone(UserId As Integer) As String
            Get
                Return Profile.Handphone(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Handphone(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastLoginDate.
        ''' </summary>
        Public Shared Property LastLoginDate(UserId As Integer) As Date
            Get
                Return Profile.LastLoginDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastLoginDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastPasswordChangedDate.
        ''' </summary>
        Public Shared Property LastPasswordChangedDate(UserId As Integer) As Date
            Get
                Return Profile.LastPasswordChangedDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastPasswordChangedDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User LastUpdateDate.
        ''' </summary>
        Public Shared Property LastUpdateDate(UserId As Integer) As Date
            Get
                Return Profile.LastUpdateDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Date)
                Profile.LastUpdateDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User MarriageId.
        ''' </summary>
        Public Shared Property MarriageId(UserId As Integer) As Integer
            Get
                Return Profile.MarriageId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.MarriageId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User MarriageId.
        ''' </summary>
        Public Shared Property Marriage(UserId As Integer) As String
            Get
                Return Profile.MarriageName(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.MarriageId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Nick.
        ''' </summary>
        Public Shared Property Nick(UserId As Integer) As String
            Get
                Return Profile.Nick(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Nick(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Passport.
        ''' </summary>
        Public Shared Property Passport(UserId As Integer) As String
            Get
                Return Profile.Passport(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Passport(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Password.
        ''' </summary>
        Public Shared Property Password(UserId As Integer) As String
            Get
                Return Profile.Password(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Password(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PasswordAnswer.
        ''' </summary>
        Public Shared Property PasswordAnswer(UserId As Integer) As String
            Get
                Return Profile.PasswordAnswer(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PasswordAnswer(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PasswordQuestion.
        ''' </summary>
        Public Shared Property PasswordQuestion(UserId As Integer) As String
            Get
                Return Profile.PasswordQuestion(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PasswordQuestion(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Phone.
        ''' </summary>
        Public Shared Property Phone(UserId As Integer) As String
            Get
                Return Profile.Phone(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Phone(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PhoneExt.
        ''' </summary>
        Public Shared Property PhoneExt(UserId As Integer) As String
            Get
                Return Profile.PhoneExt(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PhoneExt(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PositionId.
        ''' </summary>
        Public Shared Property PositionId(UserId As Integer) As String
            Get
                Return Profile.PositionId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.PositionId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User PositionName.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property PositionName(UserId As Integer) As String
            Get
                Return Profile.PositionName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Postcode.
        ''' </summary>
        Public Shared Property Postcode(UserId As Integer) As String
            Get
                Return Profile.Postcode(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.Postcode(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User RegistrationDate.
        ''' </summary>
        Public Shared Property RegistrationDate(UserId As Integer) As String
            Get
                Return Profile.RegistrationDate(UserId, _ProvidersConnectionString)
            End Get
            Set(value As String)
                Profile.RegistrationDate(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User SatelliteId.
        ''' </summary>
        Public Shared Property SatelliteId(UserId As Integer) As Integer
            Get
                Return Profile.SatelliteId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.SatelliteId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User SatelliteId.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property SatelliteName(UserId As Integer) As String
            Get
                Return Profile.SatelliteName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User SequenceNo.
        ''' </summary>
        Public Shared Property SequenceNo(UserId As Integer) As Integer
            Get
                Return Profile.SequenceNo(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.SequenceNo(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User State.
        ''' </summary>
        Public Shared Property State(UserId As Integer) As Integer
            Get
                Return Profile.State(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.State(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User Twitter.
        ''' </summary>
        Public Shared Property Twitter(UserId As Integer) As Integer
            Get
                Return Profile.Twitter(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.Twitter(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User UnitId.
        ''' </summary>
        Public Shared Property UnitId(UserId As Integer) As Integer
            Get
                Return Profile.UnitId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.UnitId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User UnitName.
        ''' To edit please use PositionId
        ''' </summary>
        Public Shared ReadOnly Property UnitName(UserId As Integer) As String
            Get
                Return Profile.UnitName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User Website.
        ''' </summary>
        Public Shared Property Website(UserId As Integer) As Integer
            Get
                Return Profile.Website(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.Website(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

#Region "Stud"

        ''' <summary>
        ''' Get Student CampusId.
        ''' </summary>
        Public Shared Property CampusId(UserId As Integer) As Integer
            Get
                Return Profile.CampusId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.CampusId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Campus Name.
        ''' To edit please use CampusId()
        ''' </summary>
        Public Shared ReadOnly Property CampusName(UserId As Integer) As String
            Get
                Return Profile.CampusName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student FacultyId.
        ''' </summary>
        Public Shared Property FacultyId(UserId As Integer) As Integer
            Get
                Return Profile.FacultyId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.FacultyId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Faculty Name.
        ''' To edit please use FacultyId()
        ''' </summary>
        Public Shared ReadOnly Property FacultyName(UserId As Integer) As String
            Get
                Return Profile.FacultyName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student ProgramId.
        ''' </summary>
        Public Shared Property ProgramId(UserId As Integer) As Integer
            Get
                Return Profile.ProgramId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ProgramId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Name.
        ''' To edit please use ProgramId()
        ''' </summary>
        Public Shared ReadOnly Property ProgramName(UserId As Integer) As String
            Get
                Return Profile.ProgramName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student Program Level Id.
        ''' </summary>
        Public Shared Property ProgLevelId(UserId As Integer) As Integer
            Get
                Return Profile.ProgLevelId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ProgLevelId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Program Level Name.
        ''' To edit please use ProgLevelId()
        ''' </summary>
        Public Shared ReadOnly Property ProgLevelName(UserId As Integer) As String
            Get
                Return Profile.ProgLevelName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get Student Study Mode Id.
        ''' </summary>
        Public Shared Property ModeId(UserId As Integer) As Integer
            Get
                Return Profile.ModeId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.ModeId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get Student Study Mode Description.
        ''' To edit please use ModeId()
        ''' </summary>
        Public Shared ReadOnly Property ModeName(UserId As Integer) As String
            Get
                Return Profile.ModeName(UserId, _ProvidersConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' Get User OrganizationId.
        ''' </summary>
        Public Shared Property OrganizationId(UserId As Integer) As Integer
            Get
                Return Profile.OrganizationId(UserId, _ProvidersConnectionString)
            End Get
            Set(value As Integer)
                Profile.OrganizationId(UserId, _ProvidersConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Get User OrganizationName.
        ''' To edit please use OrganizationId
        ''' </summary>
        Public Shared ReadOnly Property OrganizationName(UserId As Integer) As String
            Get
                Return Profile.OrganizationName(UserId, _ProvidersConnectionString)
            End Get
        End Property

#End Region

#End Region

#End Region

    End Class

End Namespace



