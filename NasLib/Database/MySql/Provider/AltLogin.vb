Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider

    ''' <summary>
    ''' Simple Login Form using Cookies and Session.
    ''' This login is not using asp.net built-in authentication.
    ''' </summary>
    Public Class AltLogin

#Region "How to use"

        '=============================================================================================================================================================
        ' HOW TO USE
        ' ==========
        '
        ' 1. Imports NasLib.Database.MySql.Provider.AltLogin
        '
        ' 2. Create a Login Page 'Login.aspx' :
        '
        '       a) Declare Connection String :
        '           Dim ConnString As String = "server=127.0.0.1;User Id=root;database=it_lab;Password=rootwdp;Persist Security Info=True;Pooling=true"
        '
        '       b) Create two textboxes 'txtUsername' and 'txtPassword'
        '
        '       c) Create a button 'btnSubmit' insert this function :
        '           If IsValidUser(txtUsername.Text, txtPassword.Text, ConnString) Then
        '               Session.RemoveAll()
        '               UserLogin(txtUsername.Text)
        '               Response.Redirect("Home.aspx")                  ' Replace "Home.aspx" to any link if successfull login.
        '           Else
        '               Response.Write("Wrong username or password")    ' or any function if wrong username and password.
        '           End If
        '           
        ' 
        ' 3. On every other page that require authentication :
        '
        '       a) On 'Page Load' event insert this code :
        '           LogonHeader("IfNotAuthenticated.aspx")              ' Replace the "IfNotAuthenticated.aspx" to any link if not authenticated user enter this page.
        '
        ' 4. Create 'Logout' button named 'btnLogout':                  ' Can be put on any page that you think required.
        '
        '       a) Put this code in 'btnLogout'
        '           UserLogout("AfterLogout.aspx")                      ' Replace the "AfterLogout.aspx" to any link after user logout successfully.
        '
        '
        '=============================================================================================================================================================

#End Region

#Region "Basic and Mandatory Functions"

        ''' <summary>
        ''' Validate username and password.
        ''' Put on Login Button.
        ''' </summary>
        Public Shared Function IsValidUser(Username As String, Password As String, LoginConnectionString As String) As Boolean
            Return Table.AltUsersProfile.IsValidUser(Username, Password, LoginConnectionString)
        End Function


        ''' <summary>
        ''' Log In the user.
        ''' Put on Login Button after validate the user.
        ''' </summary>
        Public Shared Sub UserLogin(Username As String)
            Dim context As System.Web.HttpContext = Web.HttpContext.Current

            context.Session("x") = Username
            context.Session.Timeout = 10                        'Session Time
            Dim c As New System.Web.HttpCookie("userdetails")
            c("user name") = Username
            c.Expires = DateTime.Now.AddMinutes(1)
            context.Response.Cookies.Add(c)

        End Sub

        Public Shared Function GetUsername() As String
            Dim context As System.Web.HttpContext = Web.HttpContext.Current
            Return context.Session("x")
        End Function

        Public Shared Function IsAuthenticated() As Boolean
            Return Not String.IsNullOrEmpty(GetUsername())
        End Function


        ''' <summary>
        ''' Log Out current user.
        ''' Put on Logout button.
        ''' </summary>
        ''' <param name="RedirectUrl">Redirect to URL after logout</param>
        Public Shared Sub UserLogout(Optional RedirectUrl As String = "")
            Dim context As System.Web.HttpContext = Web.HttpContext.Current

            context.Session.Clear()
            context.Session.RemoveAll()
            context.Session.Abandon()

            If RedirectUrl.Length > 0 Then context.Response.Redirect(RedirectUrl, True)
        End Sub

        ''' <summary>
        ''' Put this function in every pages that requires user authentication.
        ''' Recommended on 'PageLoad' event.
        ''' </summary>
        ''' <param name="RedirectLoginUrl">Url to Login page if user is not authenticated</param>
        Public Shared Sub LogonHeader(Optional RedirectLoginUrl As String = "")
            Dim context As System.Web.HttpContext = Web.HttpContext.Current

            context.Response.ClearHeaders()
            context.Response.AppendHeader("Cache-Control", "no-cache")
            context.Response.AppendHeader("Cache-Control", "private")
            context.Response.AppendHeader("Cache-Control", "no-store")
            context.Response.AppendHeader("Cache-Control", "must-revalidate")
            context.Response.AppendHeader("Cache-Control", "max-stale=0")
            context.Response.AppendHeader("Cache-Control", "post-check=0")
            context.Response.AppendHeader("Cache-Control", "pre-check=0")
            context.Response.AppendHeader("Pragma", "no-cache")
            context.Response.AppendHeader("Keep-Alive", "timeout=3, max=993")
            context.Response.AppendHeader("Expires", "Mon, 26 Jul 1997 05:00:00 GMT")

            If String.IsNullOrEmpty(context.Session("x")) Then
                If RedirectLoginUrl.Length > 0 Then context.Response.Redirect(RedirectLoginUrl)
            Else
                'Dim mc As IEnumerator
                'mc = context.Request.Cookies.AllKeys.GetEnumerator

                'While mc.MoveNext
                '    If context.Request.Cookies(mc.Current.ToString).HasKeys Then
                '        Dim sc As IEnumerator
                '        sc = context.Request.Cookies(mc.Current.ToString).Value.GetEnumerator

                '        While sc.MoveNext
                '            context.Response.Write(sc.Current.ToString & context.Request.Cookies(mc.Current.ToString)(sc.Current.ToString))
                '        End While

                '    End If
                'End While

            End If
        End Sub

#End Region

#Region "User Information"

        Private Shared ReadOnly Property Username As String
            Get
                Dim ReturnValue As String = ""
                Dim Username_ As String = GetUsername()
                If Not String.IsNullOrEmpty(Username_) Then ReturnValue = Username_

                Return ReturnValue
            End Get
        End Property

#Region "Fullname"

        Public Shared Property FullName() As String
            Get
                Return FullName(Username)
            End Get
            Set(value As String)

            End Set
        End Property

        Public Shared Property FullName(Username As String) As String
            Get
                Return Table.AltUsersProfile.FullName(Username, _ProvidersConnectionString)
            End Get
            Set(value As String)

            End Set
        End Property

#End Region

#End Region

#Region "Global Setting"

        Public Shared Property ProvidersConnectionString As String
            Get
                Return _ProvidersConnectionString
            End Get
            Set(value As String)
                _ProvidersConnectionString = value
            End Set
        End Property

#End Region

    End Class

End Namespace



