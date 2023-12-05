Imports NasLib.Database.SQLite.Provider

Namespace Database.SQLite.Provider

    Public Class Profile

#Region "Public Functions"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Guid
            Return Table.Users.UserId(Username, ProviderConnectionString)
        End Function

#End Region

#Region "Public Properties"

#Region "From Users"

        Public Shared Function IsUserOnline(UserId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsUserOnline(UserId, ProviderConnectionString)
        End Function

        Public Shared Property Username(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.Username(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.Username(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Comment(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.Comment(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.Comment(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property CreationDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.Users.CreateDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Users.CreateDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Email(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.Email(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.Email(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastLoginDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.Users.LastLoginDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Users.LastLoginDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastPasswordChangedDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.Users.LastPasswordChangedDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.Users.LastPasswordChangedDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Password(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.Password(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.Password(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PasswordAnswer(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.PasswordAnswer(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.PasswordAnswer(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PasswordQuestion(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.Users.PasswordQuestion(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.Users.PasswordQuestion(UserId, ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "From UsersProfile"

        Public Shared Property Address1(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Address1(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address1(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address2(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Address2(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address2(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Address3(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Address3(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Address3(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BirthDay(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.BirthDate(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.BirthDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Blogspot(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Blogspot(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Blogspot(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property BranchId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.BranchId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.BranchId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property City(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.City(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.City(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Country(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Country(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Country(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DepartmentId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.DepartmentId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.DepartmentId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property DivisionId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.DivisionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.DivisionId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Email2(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Email(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Email(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property ExpireDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.UsersProfile.ExpireDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.UsersProfile.ExpireDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Facebook(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Facebook(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Facebook(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fax(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Fax(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Fax(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Fullname(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.FullName(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.FullName(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GenderId(UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Return Table.UsersProfile.GenderId(UserId, ProviderConnectionString)
            End Get
            Set(value As Guid)
                Table.UsersProfile.GenderId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property GradeId(UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Return Table.UsersProfile.Grade(UserId, ProviderConnectionString)
            End Get
            Set(value As Guid)
                Table.UsersProfile.Grade(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Handphone(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Handphone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Handphone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property LastUpdateDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.UsersProfile.LastUpdateDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.UsersProfile.LastUpdateDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property MarriageId(UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Return Table.UsersProfile.MarriageId(UserId, ProviderConnectionString)
            End Get
            Set(value As Guid)
                Table.UsersProfile.MarriageId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Nick(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Nick(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Nick(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Passport(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Passport(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Passport(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Phone(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Phone(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Phone(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PhoneExt(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.PhoneExt(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.PhoneExt(UserId, ProviderConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' EXPERIMENTAL
        ''' </summary>
        Public Shared Property Picture(UserId As Guid, ProviderConnectionString As String) As Byte()
            Get
                Return Table.UsersProfile.Picture(UserId, ProviderConnectionString)
            End Get
            Set(value As Byte())
                Table.UsersProfile.Picture(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property PositionId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.PositionId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.PositionId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Postcode(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Postcode(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Postcode(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property RegistrationDate(UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Return Table.UsersProfile.RegistrationDate(UserId, ProviderConnectionString)
            End Get
            Set(value As Date)
                Table.UsersProfile.RegistrationDate(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SatelliteId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.SatelliteId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.SatelliteId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property SequenceNo(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.SequenceNo(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.SequenceNo(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property State(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.State(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.State(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Twitter(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Twitter(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Twitter(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property UnitId(UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Return Table.UsersProfile.UnitId(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.UsersProfile.UnitId(UserId, ProviderConnectionString) = value
            End Set
        End Property

        Public Shared Property Website(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Return Table.UsersProfile.Website(UserId, ProviderConnectionString)
            End Get
            Set(value As String)
                Table.UsersProfile.Website(UserId, ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "From UsersGender"

        ''' <summary>
        ''' Get / Set User Gender by GenderName
        ''' </summary>
        Public Shared Property GenderName(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim _GenderId As Guid = GenderId(UserId, ProviderConnectionString)
                Return Table.UsersGender.GenderName(_GenderId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _GenderId As Guid = Table.UsersGender.Id(value, ProviderConnectionString)
                Table.UsersProfile.GenderId(UserId, ProviderConnectionString) = _GenderId
            End Set
        End Property

#End Region

#Region "From UsersMarriage"

        ''' <summary>
        ''' Get / Set User Gender by GenderName
        ''' </summary>
        Public Shared Property MarriageName(UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim _MarriageId As Guid = GenderId(UserId, ProviderConnectionString)
                Return Table.UsersMarriage.MarriageName(_MarriageId, ProviderConnectionString)
            End Get
            Set(value As String)
                Dim _MarriageId As Guid = Table.UsersMarriage.Id(value, ProviderConnectionString)
                Table.UsersProfile.MarriageId(UserId, ProviderConnectionString) = _MarriageId
            End Set
        End Property

#End Region

#End Region

    End Class

End Namespace

