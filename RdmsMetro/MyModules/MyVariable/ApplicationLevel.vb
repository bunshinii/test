Imports Rdms_Metro.MyVariable


Namespace MyVariable.ApplicationLevel

    ''' <summary>
    ''' HOW TO USE is in MyVariable.vb
    ''' </summary>
    Module ApplicationLevel

#Region "Static Public Properties"
        'Do NOT modify anything in "Static" Region.

#Region "Base"

        Private _AppData As New Dictionary(Of String, Object)()

        Private ReadOnly Property AppData() As Dictionary(Of String, Object)
            Get
                Return _AppData
            End Get
        End Property

#End Region

#Region "My Type"

        Public Property DataString(AppKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""
                If AppData.ContainsKey(AppKey) Then ReturnValue = AppData(AppKey)
                Return ReturnValue
            End Get
            Set(value As String)
                AppData(AppKey) = value
            End Set
        End Property

        Public Property DataInteger(AppKey As VariableKey) As Integer
            Get
                Dim ReturnValue As String = 0
                If AppData.ContainsKey(AppKey) Then ReturnValue = AppData(AppKey)
                Return ReturnValue
            End Get
            Set(value As Integer)
                AppData(AppKey) = value
            End Set
        End Property

        Public Property DataBoolean(AppKey As VariableKey) As Boolean
            Get
                Dim ReturnValue As Boolean = False

                Boolean.TryParse(AppData(AppKey), ReturnValue)
                Return ReturnValue
            End Get
            Set(value As Boolean)
                AppData(AppKey) = value
            End Set
        End Property

        Public Property DataDate(AppKey As VariableKey) As String
            Get
                Dim ReturnValue As String = ""
                If AppData.ContainsKey(AppKey) Then
                    If IsDate(AppData(AppKey)) Then ReturnValue = Format(CDate(AppData(AppKey)), "yyyy-mm-dd HH:mm:ss")
                End If
                Return ReturnValue
            End Get
            Set(value As String)
                If IsDate(value) Then
                    AppData(AppKey) = Format(CDate(value), "yyyy-mm-dd HH:mm:ss")
                Else
                    AppData(AppKey) = ""
                End If

            End Set
        End Property

#End Region

#End Region

    End Module

End Namespace


