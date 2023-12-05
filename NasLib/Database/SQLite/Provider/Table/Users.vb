Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_Users'
    ''' </summary>
    Public Class Users

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "aspnet_Users"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            UserId
            Username
            LoweredUsername
            ApplicationId
            Email
            LoweredEmail
            Comment
            Password
            PasswordFormat
            PasswordSalt
            PasswordQuestion
            PasswordAnswer
            IsApproved
            IsAnonymous
            LastActivityDate
            LastLoginDate
            LastPasswordChangedDate
            CreateDate
            IsLockedOut
            LastLockoutDate
            FailedPasswordAttemptCount
            FailedPasswordAttemptWindowStart
            FailedPasswordAnswerAttemptCount
            FailedPasswordAnswerAttemptWindowStart
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

#Region "Table Fields Properties"

#Region "UserId"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.UserId)

            Username = Username.ToLower 'NOTE: Because SQLite is case sensitive

            Dim MyCriteria As String = Criteria(FieldName(eFieldName.LoweredUsername), Username)

            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

        Public Shared Function Id(Username As String, ProviderConnectionString As String) As Guid
            Return UserId(Username, ProviderConnectionString)
        End Function

#End Region

#Region "Username"

        Public Shared Property Username(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Username)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.Username)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Username(ByVal _Username As String, ProviderConnectionString As String) As String
            Get
                Return Username(Id(_Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Username(Id(_Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LoweredUsername"

        Public Shared Property LoweredUsername(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LoweredUsername)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.LoweredUsername)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LoweredUsername(ByVal _Username As String, ProviderConnectionString As String) As String
            Get
                Return LoweredUsername(Id(_Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                LoweredUsername(Id(_Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "ApplicationId"

        Public Shared Property ApplicationID(ByVal UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.ApplicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.ApplicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationID(ByVal Username As String, ProviderConnectionString As String) As Guid
            Get
                Return ApplicationID(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                ApplicationID(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Email"

        Public Shared Property Email(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Email(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return Email(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Email(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LoweredEmail"

        Public Shared Property LoweredEmail(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LoweredEmail)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.LoweredEmail)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LoweredEmail(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return LoweredEmail(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                LoweredEmail(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Comment"

        Public Shared Property Comment(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Comment)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.Comment)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Comment(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return Comment(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Comment(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Password"

        Public Shared Property Password(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Password)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.Password)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Password(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return Password(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Password(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordFormat"

        Public Shared Property PasswordFormat(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordFormat)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.PasswordFormat)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordFormat(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return PasswordFormat(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordFormat(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordSalt"

        Public Shared Property PasswordSalt(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordSalt)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.PasswordSalt)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordSalt(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return PasswordSalt(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordSalt(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordQuestion"

        Public Shared Property PasswordQuestion(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordQuestion)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.PasswordQuestion)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordQuestion(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return PasswordQuestion(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordQuestion(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordAnswer"

        Public Shared Property PasswordAnswer(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordAnswer)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.PasswordAnswer)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordAnswer(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Return PasswordAnswer(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordAnswer(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "IsApproved"

        Public Shared Property IsApproved(ByVal UserId As Guid, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IsApproved)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.IsApproved)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsApproved(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsApproved(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsApproved(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "IsAnonymous"

        Public Shared Property IsAnonymous(ByVal UserId As Guid, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IsAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.IsAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsAnonymous(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsAnonymous(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsAnonymous(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastActivityDate"

        Public Shared Property LastActivityDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastActivityDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastLoginDate"

        Public Shared Property LastLoginDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastLoginDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastLoginDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastLoginDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastLoginDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastPasswordChangedDate"

        Public Shared Property LastPasswordChangedDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastPasswordChangedDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastPasswordChangedDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastPasswordChangedDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastPasswordChangedDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastPasswordChangedDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "CreateDate"

        Public Shared Property CreateDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.CreateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.CreateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property CreateDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return CreateDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                CreateDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "IsLockedOut"

        Public Shared Property IsLockedOut(ByVal UserId As Guid, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IsLockedOut)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.IsLockedOut)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsLockedOut(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsLockedOut(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsLockedOut(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastLockoutDate"

        Public Shared Property LastLockoutDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastLockoutDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastLockoutDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastLockoutDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastLockoutDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastLockoutDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "FailedPasswordAttemptCount"

        Public Shared Property FailedPasswordAttemptCount(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FailedPasswordAttemptCount(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return FailedPasswordAttemptCount(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                FailedPasswordAttemptCount(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "FailedPasswordAttemptWindowStart"

        Public Shared Property FailedPasswordAttemptWindowStart(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FailedPasswordAttemptWindowStart(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return FailedPasswordAttemptWindowStart(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                FailedPasswordAttemptWindowStart(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "FailedPasswordAnswerAttemptCount"

        Public Shared Property FailedPasswordAnswerAttemptCount(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FailedPasswordAnswerAttemptCount(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return FailedPasswordAnswerAttemptCount(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                FailedPasswordAnswerAttemptCount(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "FailedPasswordAnswerAttemptWindowStart"

        Public Shared Property FailedPasswordAnswerAttemptWindowStart(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId.ToString)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FailedPasswordAnswerAttemptWindowStart(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return FailedPasswordAnswerAttemptWindowStart(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                FailedPasswordAnswerAttemptWindowStart(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId.ToString)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Username As String, ProviderConnectionString As String) As Boolean
            'NOTE: Cannot use 'IsExisted(Id(Username, ProviderConnectionString), ProviderConnectionString)' because it wont work
            Dim MyCriteria As String = Criteria(eFieldName.LoweredUsername.ToString, Username)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New User. Will return User ID
        ''' </summary>
        Public Shared Function UserInsert(ApplicationID As Guid, Username As String, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, IsAnonymous As Boolean, ProviderConnectionString As String) As Guid

            Dim UserId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString, _
                eFieldName.LoweredUsername.ToString, _
                eFieldName.ApplicationId.ToString, _
                eFieldName.Email.ToString, _
                eFieldName.LoweredEmail.ToString, _
                eFieldName.Comment.ToString, _
                eFieldName.Password.ToString, _
                eFieldName.PasswordFormat.ToString, _
                eFieldName.PasswordSalt.ToString, _
                eFieldName.PasswordQuestion.ToString, _
                eFieldName.PasswordAnswer.ToString, _
                eFieldName.IsApproved.ToString, _
                eFieldName.IsAnonymous.ToString, _
                eFieldName.LastActivityDate.ToString, _
                eFieldName.LastLoginDate.ToString, _
                eFieldName.LastPasswordChangedDate.ToString, _
                eFieldName.CreateDate.ToString, _
                eFieldName.IsLockedOut.ToString, _
                eFieldName.LastLockoutDate.ToString, _
                eFieldName.FailedPasswordAttemptCount.ToString, _
                eFieldName.FailedPasswordAttemptWindowStart.ToString, _
                eFieldName.FailedPasswordAnswerAttemptCount.ToString, _
                eFieldName.FailedPasswordAnswerAttemptWindowStart.ToString)

            Dim CurrentDate As Date = Now
            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                Username, _
                Username.ToLower, _
                ApplicationID, _
                Email, _
                Email.ToLower, _
                Comment, _
                Password, _
                PasswordFormat, _
                PasswordKey, _
                PasswordQuestion, _
                PasswordAnswer, _
                IsApproved, _
                IsAnonymous, _
                CurrentDate, _
                CurrentDate, _
                CurrentDate, _
                CurrentDate, _
                False, _
                CurrentDate, _
                0, _
                CurrentDate, _
                0, _
                CurrentDate)

            MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)

            Return New Guid(UserId)
        End Function

#End Region

#Region "Delete"

        Public Shared Function UserDelete(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UserDelete(Username As String, ProviderConnectionString As String) As Boolean
            Return UserDelete(Id(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Users. Column(UserId,Username)
        ''' </summary>
        Public Shared Function GetAllUsers(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(UserId,Username)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.Username.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

#End Region

#Region "Get All Users Online"

        ''' <summary>
        ''' Geat All OnlineUsers. Column(UserId,Username)
        ''' </summary>
        Public Shared Function GetAllUsersOnline(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Dim Other As String = OrderBy(eFieldName.LoweredEmail.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, _Criteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Online Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsersOnline(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.LoweredUsername.ToString, True, RowCount, StartRowIndex)

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, _Criteria, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Users Online"


        Private Shared ReadOnly Property UserOnlineSpan As TimeSpan
            Get
                Return SQLite.GlobalVar.UserOnlineSpan
            End Get
        End Property

        Public Shared Function IsUserOnline(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime))

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, _Criteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsUserOnline(Username As String, ProviderConnectionString As String) As Boolean
            Return IsUserOnline(UserId(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Online Users. Column(UserId,Username)
        ''' </summary>
        Public Shared Function UsersOnline(ProviderConnectionString) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, _Criteria, OrderBy(eFieldName.LoweredUsername.ToString), ProviderConnectionString)
        End Function

        Public Shared Function UsersOnlineCount(ProviderConnectionString) As Integer
            Dim _FieldName As String = FieldNames( _
                eFieldName.UserId.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdCount(TableName, _Criteria, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


