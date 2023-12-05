Imports Rdms_Metro.MyVariable
Namespace MyVariable.RequestLevel

    ''' <summary>
    ''' HOW TO USE is in MyVariable.vb
    ''' </summary>
    Module RequestLevel

#Region "Static Public Properties"
        'Do NOT modify anything in "Static" Region. Put your own function in "Custom Functions" region

#Region "Base"

        Private Property RequestData(RequestKey As String) As String
            Get
                Return System.Web.HttpContext.Current.Items(RequestKey)
            End Get
            Set(value As String)
                System.Web.HttpContext.Current.Items(RequestKey) = value
            End Set
        End Property

#End Region

#Region "My type"


        Public Property DataString(RequestKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(RequestData(RequestKey)) Then ReturnValue = RequestData(RequestKey)
                Return ReturnValue
            End Get
            Set(value As String)
                RequestData(RequestKey) = value
            End Set
        End Property

        Public Property DataInteger(RequestKey As VariableKey) As Integer
            Get
                Dim ReturnValue As String = 0

                If Not String.IsNullOrEmpty(RequestData(RequestKey)) Then
                    If IsNumeric(RequestData(RequestKey)) Then ReturnValue = RequestData(RequestKey)
                End If

                Return ReturnValue
            End Get
            Set(value As Integer)
                RequestData(RequestKey) = value
            End Set
        End Property

        Public Property DataBoolean(RequestKey As VariableKey) As Boolean
            Get
                Dim ReturnValue As Boolean = False

                Boolean.TryParse(RequestData(RequestKey), ReturnValue)

                Return ReturnValue
            End Get
            Set(value As Boolean)
                RequestData(RequestKey) = value
            End Set
        End Property

        Public Property DataDate(RequestKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(RequestData(RequestKey)) Then
                    If IsDate(RequestData(RequestKey)) Then ReturnValue = Format(CDate(RequestData(RequestKey)), "yyyy-MM-dd HH:mm:ss")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                RequestData(RequestKey) = value
            End Set
        End Property

#End Region

#End Region

    End Module

End Namespace


