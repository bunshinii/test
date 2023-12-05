Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_membership'
    ''' </summary>
    Public Class Membership

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"
        'Each Table Base Class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Table Fields Properties" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier

        Private Shared Function TableName() As String
            Return "my_aspnet_membership"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            userId                                   'Primary Key
            Email                                    'Index
            Comment
            Password
            PasswordKey
            PasswordFormat
            PasswordQuestion
            PasswordAnswer
            IsApproved
            LastActivityDate                        'Index
            LastLoginDate                           'Index
            LastPasswordChangedDate
            CreationDate                            'Index
            IsLockedOut                             'Index : To list locked users
            LastLockedOutDate
            FailedPasswordAttemptCount
            FailedPasswordAttemptWindowStart
            FailedPasswordAnswerAttemptCount
            FailedPasswordAnswerAttemptWindowStart

            '' Multiple Field Index:
            '  userId, LastActivityDate
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional External Function             '<-------------------------------------- Optional
        Private Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.Users.UserId(Username, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "Email"

        Public Shared Property Email(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                ''Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                ''Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Email(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Email(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Email(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Comment"

        Public Shared Property Comment(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Comment)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                ''Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Comment)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                ''Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Comment(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Comment(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Comment(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Password"

        Public Shared Property Password(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Password)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Password)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Password(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Password(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Password(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordKey"

        Public Shared Property PasswordKey(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordKey)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.PasswordKey)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordKey(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return PasswordKey(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordKey(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordFormat"

        ''' <summary>
        ''' Password Format. 0=Clear, 1=SHA1?, 2=MD5?
        ''' </summary>
        Public Shared Property PasswordFormat(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordFormat)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.PasswordFormat)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Password Format. 0=Clear, 1=SHA1?, 2=MD5?
        ''' </summary>
        Public Shared Property PasswordFormat(ByVal UserName As String, ProviderConnectionString As String) As Integer
            Get
                Return PasswordFormat(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                PasswordFormat(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordQuestion"

        Public Shared Property PasswordQuestion(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordQuestion)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.PasswordQuestion)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordQuestion(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return PasswordQuestion(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordQuestion(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "PasswordAnswer"

        Public Shared Property PasswordAnswer(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PasswordAnswer)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.PasswordAnswer)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PasswordAnswer(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return PasswordAnswer(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PasswordAnswer(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "IsApproved"

        Public Shared Property IsApproved(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IsApproved)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.IsApproved)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsApproved(ByVal UserName As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsApproved(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsApproved(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "lastActivityDate"

        Public Shared Property lastActivityDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property lastActivityDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return lastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                lastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastLoginDate"

        Public Shared Property LastLoginDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastLoginDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastLoginDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastLoginDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastLoginDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastLoginDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastPasswordChangedDate"

        Public Shared Property LastPasswordChangedDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastPasswordChangedDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastPasswordChangedDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

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

#Region "CreationDate"

        Public Shared Property CreationDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.CreationDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.CreationDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property CreationDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return CreationDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                CreationDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "IsLockedOut"

        Public Shared Property IsLockedOut(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IsLockedOut)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.IsLockedOut)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsLockedOut(ByVal UserName As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsLockedOut(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsLockedOut(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LastLockedOutDate"

        Public Shared Property LastLockedOutDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastLockedOutDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastLockedOutDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastLockedOutDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastLockedOutDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastLockedOutDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "FailedPasswordAttemptCount"

        Public Shared Property FailedPasswordAttemptCount(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

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

        Public Shared Property FailedPasswordAttemptWindowStart(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

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

        Public Shared Property FailedPasswordAnswerAttemptCount(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptCount)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
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

        Public Shared Property FailedPasswordAnswerAttemptWindowStart(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.FailedPasswordAnswerAttemptWindowStart)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

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

        Public Shared Function IsExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.userId.ToString, UserId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(UserId(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <param name="PasswordFormat">0 = Clear</param>
        Public Shared Function MembershipInsert(UserId As Integer, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, ProviderConnectionString As String) As String

            Dim MyFieldsName As String = FieldNames( _
                FieldName(eFieldName.userId), _
                FieldName(eFieldName.Email), _
                FieldName(eFieldName.Comment), _
                FieldName(eFieldName.Password), _
                FieldName(eFieldName.PasswordKey), _
                FieldName(eFieldName.PasswordFormat), _
                FieldName(eFieldName.PasswordQuestion), _
                FieldName(eFieldName.PasswordAnswer), _
                FieldName(eFieldName.IsApproved), _
                FieldName(eFieldName.LastActivityDate), _
                FieldName(eFieldName.LastLoginDate), _
                FieldName(eFieldName.LastPasswordChangedDate), _
                FieldName(eFieldName.CreationDate), _
                FieldName(eFieldName.IsLockedOut), _
                FieldName(eFieldName.LastLockedOutDate), _
                FieldName(eFieldName.FailedPasswordAttemptCount), _
                FieldName(eFieldName.FailedPasswordAttemptWindowStart), _
                FieldName(eFieldName.FailedPasswordAnswerAttemptCount), _
                FieldName(eFieldName.FailedPasswordAnswerAttemptWindowStart) _
                )

            Dim CurrentDate As Date = Now
            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                Email, _
                Comment, _
                Password, _
                PasswordKey, _
                PasswordFormat, _
                PasswordQuestion, _
                PasswordAnswer, _
                IsApproved, _
                CurrentDate, _
                CurrentDate, _
                CurrentDate, _
                CurrentDate, _
                0, _
                CurrentDate, _
                0, _
                CurrentDate, _
                0, _
                CurrentDate _
                )

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function MembershipDelete(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.userId), UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function MembershipDelete(Username As String, ProviderConnectionString As String) As Boolean
            Return MembershipDelete(UserId(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Users. Column(userId)
        ''' </summary>
        Public Shared Function GetAllUsers(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.userId.ToString _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , , ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(userId)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.userId.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = Limit(RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

#End Region

#Region "Users Online"

        Private Shared ReadOnly Property UserOnlineSpan As TimeSpan
            Get
                Return Database.MySql.GlobalVar.UserOnlineSpan
            End Get
        End Property

        Public Shared Function IsUserOnline(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriasAND( _
                Criteria(eFieldName.userId.ToString, UserId), _
                CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime))

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, _Criteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Geat All Online Users. Column(userId)
        ''' </summary>
        Public Shared Function UsersOnline(ProviderConnectionString) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.userId.ToString _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, _Criteria, , ProviderConnectionString)
        End Function

        Public Shared Function UsersOnlineCount(ProviderConnectionString) As Integer
            Dim _FieldName As String = FieldNames( _
                )

            Dim CompareTime As DateTime = DateTime.UtcNow.Subtract(UserOnlineSpan)
            Dim _Criteria As String = CriteriaGreater(eFieldName.LastActivityDate.ToString, CompareTime)

            Return MyCmd.CmdCount(TableName, _Criteria, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


