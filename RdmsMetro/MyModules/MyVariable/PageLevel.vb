Imports Rdms_Metro.MyVariable
Imports System.Reflection

Namespace MyVariable.PageLevel

    ''' <summary>
    ''' HOW TO USE is in MyVariable.vb
    ''' </summary>
    Module PageLevel

#Region "Static Public Properties"
        'Do NOT modify anything in "Static" Region. Put your own function in "Custom Functions" region

#Region "Base"

        Private Property PageData(PageKey As String) As String
            Get

                Dim Page As Page = DirectCast(HttpContext.Current.CurrentHandler, Page)
                Dim Viewstate As New StateBag()
                Dim MyProperty As PropertyInfo = Page.GetType().GetProperty("ViewState", BindingFlags.Instance Or BindingFlags.NonPublic)
                If MyProperty IsNot Nothing Then
                    Viewstate = DirectCast(MyProperty.GetValue(Page, Nothing), StateBag)
                End If

                Return Viewstate(PageKey)
            End Get
            Set(value As String)
                Dim Page As Page = DirectCast(HttpContext.Current.CurrentHandler, Page)
                Dim Viewstate As New StateBag()
                'Get ViewState
                Dim MyProperty As PropertyInfo = Page.[GetType]().GetProperty("ViewState", BindingFlags.Instance Or BindingFlags.NonPublic)
                'Set Value
                If MyProperty IsNot Nothing Then
                    Viewstate = DirectCast(MyProperty.GetValue(Page, Nothing), StateBag)
                End If
                Viewstate(PageKey) = value
            End Set
        End Property

#End Region

#Region "My type"

#Region "Strict to specified variable"

        Public Property DataString(PageKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then ReturnValue = PageData(PageKey)
                Return ReturnValue
            End Get
            Set(value As String)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataInteger(PageKey As VariableKey) As Integer
            Get
                Dim ReturnValue As String = 0

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then
                    If IsNumeric(PageData(PageKey)) Then ReturnValue = PageData(PageKey)
                End If

                Return ReturnValue
            End Get
            Set(value As Integer)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataBoolean(PageKey As VariableKey) As Boolean
            Get
                Dim ReturnValue As Boolean = False

                Boolean.TryParse(PageData(PageKey), ReturnValue)

                Return ReturnValue
            End Get
            Set(value As Boolean)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataDate(PageKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then
                    If IsDate(PageData(PageKey)) Then ReturnValue = Format(CDate(PageData(PageKey)), "yyyy-MM-dd HH:mm:ss")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                PageData(PageKey) = value
            End Set
        End Property

#End Region

#Region "Not Stricted"

        Public Property DataString(PageKey As String) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then ReturnValue = PageData(PageKey)
                Return ReturnValue
            End Get
            Set(value As String)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataInteger(PageKey As String) As Integer
            Get
                Dim ReturnValue As String = 0

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then
                    If IsNumeric(PageData(PageKey)) Then ReturnValue = PageData(PageKey)
                End If

                Return ReturnValue
            End Get
            Set(value As Integer)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataBoolean(PageKey As String) As Boolean
            Get
                Dim ReturnValue As Boolean = False

                Boolean.TryParse(PageData(PageKey), ReturnValue)

                Return ReturnValue
            End Get
            Set(value As Boolean)
                PageData(PageKey) = value
            End Set
        End Property

        Public Property DataDate(PageKey As String) As String
            Get
                Dim ReturnValue As String = ""

                If Not String.IsNullOrEmpty(PageData(PageKey)) Then
                    If IsDate(PageData(PageKey)) Then ReturnValue = Format(CDate(PageData(PageKey)), "yyyy-MM-dd HH:mm:ss")
                End If

                Return ReturnValue
            End Get
            Set(value As String)
                PageData(PageKey) = value
            End Set
        End Property

#End Region

#End Region

#End Region

    End Module

End Namespace


