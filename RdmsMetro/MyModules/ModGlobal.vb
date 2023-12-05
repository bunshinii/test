
Module ModGlobal

#Region "Connection Strings"

    ''' <summary>
    ''' Get ConnectionString
    ''' </summary>
    Public ReadOnly Property ProvidersConnectionString As String
        Get
            Dim ConnectionString As String = "ProvidersConnectionString"
            Return ConfigurationManager.ConnectionStrings(ConnectionString).ConnectionString
        End Get
    End Property

    ''' <summary>
    ''' Get ConnectionString
    ''' </summary>
    Public ReadOnly Property DbLibraryConnectionString As String
        Get
            Dim ConnectionString As String = "DbLibraryConnectionString"
            Return ConfigurationManager.ConnectionStrings(ConnectionString).ConnectionString
        End Get
    End Property

    ''' <summary>
    ''' Get ConnectionString
    ''' </summary>
    Public ReadOnly Property MyAppConnectionString As String
        Get
            Dim ConnectionString As String = "MyAppConnectionString"
            Return ConfigurationManager.ConnectionStrings(ConnectionString).ConnectionString
        End Get
    End Property

#End Region

#Region "Custom Image URL"

    ''' <summary>
    ''' Just provide PatronId to get the patron image
    ''' </summary>
    Public ReadOnly Property PicProviderLink As String
        Get
            'configuration/AppSetting in Web.config
            Return System.Configuration.ConfigurationManager.AppSettings("PicProviderLink")
        End Get
    End Property

    ''' <summary>
    ''' Just provide PatronId to get the patron image
    ''' </summary>
    Public ReadOnly Property PicProviderLink(PatronId As String) As String
        Get
            Return PicProviderLink() & "?patronid=" & PatronId
        End Get
    End Property

#End Region

#Region "CurrentUser"

    Public ReadOnly Property MyOwnId As String
        Get
            Return HttpContext.Current.User.Identity.Name
        End Get
    End Property

    Public ReadOnly Property MyFullName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyNick As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.Nick(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyNickOrFullname As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.NickOrFullname(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyPosition As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.PositionName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyBranchId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.BranchId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyBranchName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.BranchName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MySatelliteId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.SatelliteId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MySatelliteName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.SatelliteName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyDepartmentId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.DepartmentId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyDepartmentName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.DepartmentName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyDivisionId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.DivisionId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyDivisionName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.DivisionName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyUnitId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.UnitId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Public ReadOnly Property MyUnitName As String
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.UnitName(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

#End Region

#Region "Other Quick Functions"

    Public ReadOnly Property CurrentURL(Optional IncludeQueryString As Boolean = False) As String
        Get
            Return NasLib.Functions.Web.Url.GetCurrentURL(IncludeQueryString)
        End Get
    End Property

    Public ReadOnly Property CurrentQueryString() As String
        Get
            Return NasLib.Functions.Web.Url.GetCurrentQueryString()
        End Get
    End Property

#End Region


End Module




