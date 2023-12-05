

''' <summary>
''' Declare these ConnectionStrings in Global.asax.vb
''' </summary>
''' <remarks></remarks>
Public Class GlobalSetting


    Public Shared Property ProvidersConnectionString As String
        Get
            Return _ProvidersConnectionString
        End Get
        Set(value As String)
            _ProvidersConnectionString = value
        End Set
    End Property

    Public Shared Property DbLibraryConnectionString As String
        Get
            Return _DbLibraryConnectionString
        End Get
        Set(value As String)
            _DbLibraryConnectionString = value
        End Set
    End Property

    Public Shared Property MyAppConnectionString As String
        Get
            Return _MyAppConnectionString
        End Get
        Set(value As String)
            _MyAppConnectionString = value
        End Set
    End Property

End Class

