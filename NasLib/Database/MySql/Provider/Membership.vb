Imports MySql.Web.Security
Imports NasLib.Database.MySql.Provider

Namespace Database.MySql.Provider

    Public Class Membership

        '=====================================================================================================================
        ' NOTE: Every function that has variable 'MyMembership' is using 'MySql.Web.Security.MySQLMembershipProvider' function
        'Shared MyMembership As New MySQLMembershipProvider
        '=====================================================================================================================

#Region "Private Functions"

        Private Shared Function Username(UserId As Integer, ProviderConnectionString As String) As String
            Return NasLib.Database.MySql.Provider.Table.Users.Username(UserId, ProviderConnectionString)
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

        Public Shared Function IsUserExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsExisted(UserId, ProviderConnectionString)
        End Function

        Public Shared Function IsUserExisted(Username As String, ProviderConnectionString As String) As Boolean
            Return Table.Users.IsExisted(Username, ProviderConnectionString)
        End Function

#End Region

#Region "CreateUser"

        ''' <summary>
        ''' Create new user. Will return UserId.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' </summary>
        ''' ''' <param name="PasswordFormat">0 = Clear, 1= Encrypted, 3 = Hashed</param>
        Public Shared Function CreateUser(ApplicationID As Integer, Username As String, FullName As String, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, IsAnonymous As Boolean, ProviderConnectionString As String) As Integer
            Dim ReturnValue As Integer = -1

            'if already registered cancel this function
            If Provider.Table.Users.IsExisted(Username, ProviderConnectionString) Then
                Return ReturnValue
                Exit Function
            End If

            If IsNumeric(Username) Then Username = CInt(Username)

            Try
                'Insert into 'my_aspnet_users'
                Dim UserId As Integer = NasLib.Database.MySql.Provider.Table.Users.UserInsert(ApplicationID, Username, IsAnonymous, ProviderConnectionString)

                'Insert into 'my_aspnet_membership'
                NasLib.Database.MySql.Provider.Table.Membership.MembershipInsert(UserId, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, ProviderConnectionString)

                'Insert into 'my_users_profile'
                NasLib.Database.MySql.Provider.Table.UsersProfile.ProfileInsert(UserId, Username, FullName, ProviderConnectionString)

                ReturnValue = UserId
            Catch ex As Exception
                ReturnValue = -1
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Create new user. The user can login immediately. Will return UserId.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' If error will return '-1'
        ''' </summary>
        ''' <param name="ApplicationID">ApplicationID will always be '1'</param>
        ''' <param name="PasswordFormat">0 = Clear, 1= Encrypted, 3 = Hashed</param>
        Public Shared Function CreateUser(ApplicationID As Integer, Username As String, Email As String, Comment As String, Password As String, PasswordKey As String, PasswordFormat As Integer, PasswordQuestion As String, PasswordAnswer As String, IsApproved As Boolean, IsAnonymous As Boolean, ProviderConnectionString As String) As Integer
            Dim FullName As String = ""
            Return CreateUser(ApplicationID, Username, FullName, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, IsAnonymous, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. The user can login immediately. Will return UserId.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' If error will return '-1'
        ''' </summary>
        Public Shared Function CreateUser(Username As String, Password As String, Email As String, IsApproved As Boolean, ProviderConnectionString As String) As Integer
            Dim ApplicationID As Integer = 1
            Dim Comment As String = ""
            Dim PasswordKey As String = GenerateSalt()
            Dim PasswordFormat As String = 0 '0 = Clear, 1= Encrypted, 3 = Hashed
            Dim PasswordQuestion As String = "What is you email address"
            Dim PasswordAnswer As String = Email
            Dim IsAnonymous As Boolean = False

            Return CreateUser(ApplicationID, Username, Email, Comment, Password, PasswordKey, PasswordFormat, PasswordQuestion, PasswordAnswer, IsApproved, IsAnonymous, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. The user can login immediately. Will return UserId.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' If error will return '-1'
        ''' </summary>
        Public Shared Function CreateUser(Username As String, Password As String, Email As String, ProviderConnectionString As String) As Integer
            Dim IsApproved As Boolean = True

            Return CreateUser(Username, Password, Email, IsApproved, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Create new user. The user can login immediately. Will return UserId.
        ''' Will fill basic user data and blak row in 'my_users_profile' table.
        ''' If error will return '-1'
        ''' </summary>
        Public Shared Function CreateUser(Username As String, Password As String, ProviderConnectionString As String) As Integer
            Dim Email As String = "please@update.your.email"

            Return CreateUser(Username, Password, Email, ProviderConnectionString)
        End Function

#End Region

#Region "ChangePassword"

        ' ''' <summary>
        ' ''' Using .Net Framework Membership Provider 
        ' ''' </summary>
        'Public Shared Function ChangePassword1(UserId As Integer, OldPassword As String, NewPassword As String, ProviderConnectionString As String) As Boolean
        '    Dim _Username As String = Username(UserId, ProviderConnectionString)
        '    Return ChangePassword1(_Username, OldPassword, NewPassword)
        'End Function


        ' ''' <summary>
        ' ''' Using .Net Framework Membership Provider 
        ' ''' </summary>
        'Public Shared Function ChangePassword1(Username As String, OldPassword As String, NewPassword As String) As Boolean
        '    Return MyMembership.ChangePassword(Username, OldPassword, NewPassword)
        'End Function

        Public Shared Function ChangePassword(UserId As Integer, NewPassword As String, ProviderConnectionString As String) As Boolean
            Return Table.Membership.Password(UserId, ProviderConnectionString)
        End Function

        Public Shared Function ChangePassword(Username As String, NewPassword As String, ProviderConnectionString As String) As Boolean
            Return Table.Membership.Password(Username, ProviderConnectionString)
        End Function

#End Region

#Region "ChangePasswordQuestionAndAnswer"

        ' ''' <summary>
        ' ''' Using .Net Framework Membership Provider 
        ' ''' </summary>
        'Public Shared Function ChangePasswordQuestionAndAnswer1(Username As String, Password As String, NewPasswordQuestion As String, NewPasswordAnswer As String) As Boolean
        '    Return MyMembership.ChangePasswordQuestionAndAnswer(Username, Password, NewPasswordQuestion, NewPasswordAnswer)
        'End Function

        ' ''' <summary>
        ' ''' Using .Net Framework Membership Provider 
        ' ''' </summary>
        'Public Shared Function ChangePasswordQuestionAndAnswer1(UserId As Integer, Password As String, NewPasswordQuestion As String, NewPasswordAnswer As String, ProviderConnectionString As String) As Boolean
        '    Dim _Username As String = Username(UserId, ProviderConnectionString)
        '    Return ChangePasswordQuestionAndAnswer1(_Username, Password, NewPasswordQuestion, NewPasswordAnswer)
        'End Function

        Public Shared Function ChangePasswordQuestionAndAnswer(Username As String, NewPasswordQuestion As String, NewPasswordAnswer As String, ProviderConnectionString As String) As Boolean
            Table.Membership.PasswordQuestion(Username, ProviderConnectionString) = NewPasswordQuestion
            Table.Membership.PasswordAnswer(Username, ProviderConnectionString) = NewPasswordAnswer
            Return True
        End Function

        Public Shared Function ChangePasswordQuestionAndAnswer(UserId As Integer, Password As String, NewPasswordQuestion As String, NewPasswordAnswer As String, ProviderConnectionString As String) As Boolean
            Table.Membership.PasswordQuestion(UserId, ProviderConnectionString) = NewPasswordQuestion
            Table.Membership.PasswordAnswer(UserId, ProviderConnectionString) = NewPasswordAnswer
            Return True
        End Function
#End Region

#Region "DeleteUser"

        ' ''' <summary>
        ' ''' Using .Net Framework Membership Provider 
        ' ''' </summary>
        'Public Shared Function DeleteUser1(Username As String, ProviderConnectionString As String) As Boolean
        '    Return MyMembership.DeleteUser(Username, True)
        'End Function

        ''' <summary>
        ''' Using .Net Framework Membership Provider 
        ''' </summary>
        Public Shared Function DeleteUser1(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim _Username As String = Username(UserId, ProviderConnectionString)
            Return DeleteUser1(_Username, ProviderConnectionString)
        End Function

        Public Shared Sub DeleteUser(Username As String, ProviderConnectionString As String)
            Dim UserId As Integer = Table.Users.UserId(Username, ProviderConnectionString)
            DeleteUser(UserId, ProviderConnectionString)
        End Sub

        Public Shared Sub DeleteUser(UserId As Integer, ProviderConnectionString As String)
            Table.Users.UserDelete(UserId, ProviderConnectionString)
            Table.Membership.MembershipDelete(UserId, ProviderConnectionString)
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

        'Public Shared Function GetNumberOfUsersOnline1() As Integer
        '    Return MyMembership.GetNumberOfUsersOnline()
        'End Function

        Public Shared Function GetNumberOfUsersOnline(ProviderConnectionString As String) As Integer
            Return Table.Users.UsersOnlineCount(ProviderConnectionString)
        End Function

#End Region

#Region "GetPassword"

        Public Shared Function GetPassword(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Membership.Password(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPassword(Username As String, ProviderConnectionString As String) As String
            Return Table.Membership.Password(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordAnswer"

        Public Shared Function GetPasswordAnswer(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordAnswer(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordAnswer(Username As String, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordAnswer(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordFormat"

        Public Shared Function GetPasswordFormat(UserId As Integer, ProviderConnectionString As String) As Integer
            Return Table.Membership.PasswordFormat(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordFormat(Username As String, ProviderConnectionString As String) As Integer
            Return Table.Membership.PasswordFormat(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordKey"

        Public Shared Function GetPasswordKey(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordKey(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordKey(Username As String, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordKey(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetPasswordQuestion"

        Public Shared Function GetPasswordQuestion(UserId As Integer, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordQuestion(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetPasswordQuestion(Username As String, ProviderConnectionString As String) As String
            Return Table.Membership.PasswordQuestion(Username, ProviderConnectionString)
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
            Return Table.Membership.LastLoginDate(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetLastLoginDate(Username As String, ProviderConnectionString As String) As Date
            Return Table.Membership.LastLoginDate(Username, ProviderConnectionString)
        End Function

#End Region

#Region "GetLastPasswordChangedDate"

        Public Shared Function GetLastPasswordChangedDate(UserId As Integer, ProviderConnectionString As String) As Date
            Return Table.Membership.LastPasswordChangedDate(UserId, ProviderConnectionString)
        End Function

        Public Shared Function GetLastPasswordChangedDate(Username As String, ProviderConnectionString As String) As Date
            Return Table.Membership.LastPasswordChangedDate(Username, ProviderConnectionString)
        End Function

#End Region

#Region "Lock Unlock User"

        Public Shared Sub UnlockUser(UserId As Integer, ProviderConnectionString As String)
            Table.Membership.IsLockedOut(UserId, ProviderConnectionString) = False
        End Sub

        Public Shared Sub LockUser(UserId As Integer, ProviderConnectionString As String)
            Table.Membership.IsLockedOut(UserId, ProviderConnectionString) = True
        End Sub

        Public Shared Sub UnlockUser(Username As String, ProviderConnectionString As String)
            Table.Membership.IsLockedOut(Username, ProviderConnectionString) = False
        End Sub

        Public Shared Sub LockUser(Username As String, ProviderConnectionString As String)
            Table.Membership.IsLockedOut(Username, ProviderConnectionString) = True
        End Sub

#End Region

#Region "Approve Unapprove User"

        Public Shared Sub UnApproveUser(UserId As Integer, ProviderConnectionString As String)
            Table.Membership.IsApproved(UserId, ProviderConnectionString) = False
        End Sub

        Public Shared Sub ApproveUser(UserId As Integer, ProviderConnectionString As String)
            Table.Membership.IsApproved(UserId, ProviderConnectionString) = True
        End Sub

        Public Shared Sub UnApproveUser(Username As String, ProviderConnectionString As String)
            Table.Membership.IsApproved(Username, ProviderConnectionString) = False
        End Sub

        Public Shared Sub ApproveUser(Username As String, ProviderConnectionString As String)
            Table.Membership.IsApproved(Username, ProviderConnectionString) = True
        End Sub

#End Region

#End Region

#Region "Public Properties"

        Public Shared Property PasswordFormat(UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Return Table.Membership.PasswordFormat(UserId, ProviderConnectionString)
            End Get
            Set(value As Integer)
                Table.Membership.PasswordFormat(UserId, ProviderConnectionString) = value
            End Set
        End Property


#End Region

    End Class

End Namespace


