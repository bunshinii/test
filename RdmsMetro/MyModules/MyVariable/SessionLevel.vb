
Namespace MyVariable.SessionLevel

    ''' <summary>
    ''' HOW TO USE is in MyVariable.vb
    ''' </summary>
    Module SessionLevel

#Region "Static Public Properties"
        'Do NOT modify anything in "Static" Region. Put your own function in "Custom Functions" region

#Region "Base"

        '' How to get data: Dim MyVar as string = SessionData("SessionKey")
        '' How to set data: SessionData("SessionKey") = "something"

        Private Property SessionData(SessionKey As String) As String
            Get
                Return System.Web.HttpContext.Current.Session(SessionKey)
            End Get
            Set(value As String)
                System.Web.HttpContext.Current.Session(SessionKey) = value
            End Set
        End Property

#End Region

#Region "My type"

        Public Property DataString(SessionKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(SessionData(SessionKey)) Then ReturnValue = SessionData(SessionKey)
                Return ReturnValue
            End Get
            Set(value As String)
                SessionData(SessionKey) = value
            End Set
        End Property

        Public Property DataInteger(SessionKey As VariableKey) As Integer
            Get
                Dim ReturnValue As String = 0

                If Not String.IsNullOrEmpty(SessionData(SessionKey)) Then
                    If IsNumeric(SessionData(SessionKey)) Then ReturnValue = SessionData(SessionKey)
                End If

                Return ReturnValue
            End Get
            Set(value As Integer)
                SessionData(SessionKey) = value
            End Set
        End Property

        Public Property DataBoolean(SessionKey As VariableKey) As Boolean
            Get
                Dim ReturnValue As Boolean = False

                Boolean.TryParse(SessionData(SessionKey), ReturnValue)

                Return ReturnValue
            End Get
            Set(value As Boolean)
                SessionData(SessionKey) = value
            End Set
        End Property

        Public Property DataDate(SessionKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(SessionData(SessionKey)) Then
                    If IsDate(SessionData(SessionKey)) Then ReturnValue = Format(CDate(SessionData(SessionKey)), "yyyy-MM-dd HH:mm:ss")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                If IsDate(value) Then
                    SessionData(SessionKey) = Format(CDate(value), "yyyy-MM-dd HH:mm:ss")
                Else
                    SessionData(SessionKey) = ""
                End If

            End Set
        End Property

#End Region

#End Region

    End Module

End Namespace


