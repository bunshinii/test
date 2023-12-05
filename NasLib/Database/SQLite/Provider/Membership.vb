Imports NasLib.Database.SQLite.Provider

Namespace Database.SQLite.Provider

    Public Class Membership

#Region "Private Functions"

        Private Shared Function Username(UserId As Guid, ProviderConnectionString As String) As String
            Return NasLib.Database.SQLite.Provider.Table.Users.Username(UserId, ProviderConnectionString)
        End Function

        Private Shared Function GenerateSalt() As String
            Dim rng As New Security.Cryptography.RNGCryptoServiceProvider()
            Dim buff As Byte() = New Byte(15) {}
            rng.GetBytes(buff)
            Return Convert.ToBase64String(buff)
        End Function

#End Region

#Region "Public Functions"

#Region "IsUserExisted"

        Public Shared Function IsUserExisted(UserId As Guid, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsExisted(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsExisted(Username, ProviderConnectionString)
        End Function

#End Region

#Region "CreateUser"

        ''' <summary>
        ''' Create new user. Will return UserId
        ''' </summary>
        ''' ''' <param name="PasswordFormat">0 = Clear, 1= Encrypted, 3 = Hashed</param>
        Public Shared Function CreateUser(ApplicationID As Guid, Username As String, FullName As String, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, IsAnonymous As Boolean, ProviderConnectionString As String) As Guid
            Dim ReturnValue As Guid = New Guid("00000000-0000-0000-0000-000000000000")

            'if already registered cancel this function
            If Provider.Table.Users.IsExisted(Username, ProviderConnectionString) Then
                Return ReturnValue
                Exit Function
            End If

            If IsNumeric(Username) Then Username = CInt(Username)

            Try
                'Insert into 'my_aspnet_users'
                Dim UserId As Guid = Table.Users.UserInsert(ApplicationID, Username, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, IsAnonymous, ProviderConnectionString)

                'Insert into 'users_profile'
                Table.UsersProfile.ProfileInsert(UserId, Username, FullName, ProviderConnectionString)

                ReturnValue = UserId
            Catch ex As Exception
                ReturnValue = New Guid("00000000-0000-0000-0000-000000000000")
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Create new user. Will return UserId
        ''' </summary>
        ''' <param name="PasswordFormat">0 = Clear, 1= Encrypted, 3 = Hashed</param>
        Public Shared Function CreateUser(ApplicationID As Guid, Username As String, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, IsAnonymous As Boolean, ProviderConnectionString As String) As Guid
            Dim FullName As String = ""
            Return CreateUser(ApplicationID, Username, FullName, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, IsAnonymous, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. Will return UserId
        ''' </summary>
        Public Shared Function CreateUser(ApplicationId As Guid, Username As String, Password As String, Email As String, IsApproved As Boolean, ProviderConnectionString As String) As Guid
            Dim Comment As String = ""
            Dim PasswordKey As String = GenerateSalt()
            Dim PasswordFormat As String = 0 '0 = Clear, 1= Encrypted, 3 = Hashed
            Dim PasswordQuestion As String = "What is you email address"
            Dim PasswordAnswer As String = Email
            Dim IsAnonymous As Boolean = False

            Return CreateUser(ApplicationId, Username, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, IsAnonymous, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. Will return UserId
        ''' </summary>
        Public Shared Function CreateUser(ApplicationId As Guid, Username As String, Password As String, Email As String, ProviderConnectionString As String) As Guid
            Dim IsApproved As Boolean = True

            Return CreateUser(ApplicationId, Username, Password, Email, IsApproved, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. Will return UserId
        ''' </summary>
        Public Shared Function CreateUser(ApplicationId As Guid, Username As String, Password As String, ProviderConnectionString As String) As Guid
            Dim Email As String = "please@update.your.email"

            Return CreateUser(ApplicationId, Username, Password, Email, ProviderConnectionString)
        End Function

#End Region

#Region "ChangePassword"
        Public Shared Function ChangePassword(UserId As Guid, NewPassword As String, ProviderConnectionString As String) As Boolean
            Return Table.Users.Password(UserId, ProviderConnectionString) = NewPassword
        End Function

        Public Shared Function ChangePassword(Username As String, NewPassword As String, ProviderConnectionString As String) As Boolean
            Return Table.Users.Password(Username, ProviderConnectionString) = NewPassword
        End Function

#End Region

#Region "ChangePasswordQuestionAndAnswer"

        Public Shared Sub ChangePasswordQuestionAndAnswer(Username As String, NewPasswordQuestion As String, NewPasswordAnswer As String, ProviderConnectionString As String)
            Table.Users.PasswordQuestion(Username, ProviderConnectionString) = NewPasswordQuestion
            Table.Users.PasswordAnswer(Username, ProviderConnectionString) = NewPasswordAnswer
        End Sub

        Public Shared Sub ChangePasswordQuestionAndAnswer(UserId As Guid, Password As String, NewPasswordQuestion As String, NewPasswordAnswer As String, ProviderConnectionString As String)
            Table.Users.PasswordQuestion(UserId, ProviderConnectionString) = NewPasswordQuestion
            Table.Users.PasswordAnswer(UserId, ProviderConnectionString) = NewPasswordAnswer
        End Sub
#End Region

#Region "DeleteUser"

        Public Shared Sub DeleteUser(Username As String, ProviderConnectionString As String)
            Dim UserId As Guid = Table.Users.UserId(Username, ProviderConnectionString)
            DeleteUser(UserId, ProviderConnectionString)
        End Sub

        Public Shared Sub DeleteUser(UserId As Guid, ProviderConnectionString As String)
            Table.Users.UserDelete(UserId, ProviderConnectionString)
            Table.Profile.ProfileDelete(UserId, ProviderConnectionString)
            Table.UsersProfile.ProfileDelete(UserId, ProviderConnectionString)
            Table.UsersInRoles.ClearUserRoles(UserId, ProviderConnectionString)
        End Sub

#End Region

#Region "GetAllUsers"

        ''' <summary>
        ''' Gat All Users. Column(id,name)
        ''' </summary>
        Public Function GetAllUsers(ProviderConnectionString As String) As DataTable
            Return Table.Users.GetAllUsers(ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Return Table.Users.GetAllUsers(PageIndex, PageSize, ProviderConnectionString)
        End Function

#End Region

#Region "GeNumberOfUsers"

        Public Shared Function GetNumberOfUsers(ProviderConnectionString As String) As Integer
            Return Table.Users.Count(ProviderConnectionString)
        End Function

#End Region

#Region "GetAllUsersOnline"

        ''' <summary>
        ''' Gat All Online Users. Column(id,name)
        ''' </summary>
        Public Function GetAllUsersOnline(ProviderConnectionString As String) As DataTable
            Return Table.Users.GetAllUsersOnline(ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Online Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsersOnline(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Return Table.Users.GetAllUsersOnline(PageIndex, PageSize, ProviderConnectionString)
        End Function

#End Region

#Region "GetNumberOfUsersOnline"

        Public Shared Function GetNumberOfUsersOnline(ProviderConnectionString As String) As Integer
            Return Table.Users.UsersOnlineCount(ProviderConnectionString)
        End Function

#End Region

#Region "GetPassword"

        Public Shared Function GetPassword(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Users.Password(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPassword(Username As String, ProviderConnectionString As String) As String
            Return Table.Users.Password(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordAnswer"

        Public Shared Function GetPasswordAnswer(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Users.PasswordAnswer(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordAnswer(Username As String, ProviderConnectionString As String) As String
            Return Table.Users.PasswordAnswer(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordFormat"

        Public Shared Function GetPasswordFormat(UserId As Integer, ProviderConnectionString As String) As Integer
            Return Table.Users.PasswordFormat(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordFormat(Username As String, ProviderConnectionString As String) As Integer
            Return Table.Users.PasswordFormat(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordKey"

        Public Shared Function GetPasswordKey(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Users.PasswordSalt(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordKey(Username As String, ProviderConnectionString As String) As String
            Return Table.Users.PasswordSalt(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordQuestion"

        Public Shared Function GetPasswordQuestion(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Users.PasswordQuestion(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordQuestion(Username As String, ProviderConnectionString As String) As String
            Return Table.Users.PasswordQuestion(Username, ProviderConnectionString)
        End Function

#End Region

#Region "IsUserOnline"

        Public Shared Function IsUserOnline(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsUserOnline(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserOnline(Username As String, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsUserOnline(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetLastLoginDate"

        Public Shared Function GetLastLoginDate(UserId As Integer, ProviderConnectionString As String) As Date
            Return Table.Users.LastLoginDate(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetLastLoginDate(Username As String, ProviderConnectionString As String) As Date
            Return Table.Users.LastLoginDate(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetLastPasswordChangedDate"

        Public Shared Function GetLastPasswordChangedDate(UserId As Integer, ProviderConnectionString As String) As Date
            Return Table.Users.LastPasswordChangedDate(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetLastPasswordChangedDate(Username As String, ProviderConnectionString As String) As Date
            Return Table.Users.LastPasswordChangedDate(Username, ProviderConnectionString)
        End Function

#End Region

#Region "Lock Unlock User"

        Public Shared Sub UnlockUser(UserId As Integer, ProviderConnectionString As String)
            Table.Users.IsLockedOut(UserId, ProviderConnectionString) = False
        End Sub

        Public Shared Sub LockUser(UserId As Integer, ProviderConnectionString As String)
            Table.Users.IsLockedOut(UserId, ProviderConnectionString) = True
        End Sub

        Public Shared Sub UnlockUser(Username As String, ProviderConnectionString As String)
            Table.Users.IsLockedOut(Username, ProviderConnectionString) = False
        End Sub

        Public Shared Sub LockUser(Username As String, ProviderConnectionString As String)
            Table.Users.IsLockedOut(Username, ProviderConnectionString) = True
        End Sub

#End Region

#Region "Approve Unapprove User"

        Public Shared Sub UnApproveUser(UserId As Integer, ProviderConnectionString As String)
            Table.Users.IsApproved(UserId, ProviderConnectionString) = False
        End Sub

        Public Shared Sub ApproveUser(UserId As Integer, ProviderConnectionString As String)
            Table.Users.IsApproved(UserId, ProviderConnectionString) = True
        End Sub

        Public Shared Sub UnApproveUser(Username As String, ProviderConnectionString As String)
            Table.Users.IsApproved(Username, ProviderConnectionString) = False
        End Sub

        Public Shared Sub ApproveUser(Username As String, ProviderConnectionString As String)
            Table.Users.IsApproved(Username, ProviderConnectionString) = True
        End Sub

#End Region

#End Region

#Region "Public Properties"

        Public Shared Property PasswordFormat(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return Table.Users.PasswordFormat(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.Users.PasswordFormat(UserId, ProviderConnectionString) = value
            End Set
        End Property


#End Region

    End Class

End Namespace


