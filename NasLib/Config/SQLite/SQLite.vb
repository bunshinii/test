Namespace Config.SQLite

    ''' <summary>
    ''' Read / Write config.db.
    ''' The file must be in 'App_Data' folder.
    ''' Table name must be 'my_config.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Configuration

        Private Shared ReadOnly Property ConfigConnectionString() As String
            Get
                Return "Data Source=|DataDirectory|config.db;Version=3;"
            End Get
        End Property

        Private Enum KeyName
            app_name
            app_version
            copyright
            language
            site_name
            picprovider_link
        End Enum

#Region "Public Properties"

#Region "Reserved Key"

        ''' <summary>
        ''' Application Name including version.
        ''' </summary>
        Public Shared Property ApplicationName As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.app_name.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.app_name.ToString, ConfigConnectionString) = value
            End Set
        End Property

        Public Shared Property ApplicationVersion As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.app_version.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.app_version.ToString, ConfigConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Copyright
        ''' </summary>
        Public Shared Property Copyright As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.copyright.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.copyright.ToString, ConfigConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Language Code (my, sg, uk, etc)
        ''' </summary>
        Public Shared Property LanguageCode As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.language.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.language.ToString, ConfigConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Site Name to Display
        ''' </summary>
        Public Shared Property SiteName As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.site_name.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.site_name.ToString, ConfigConnectionString) = value
            End Set
        End Property

        ''' <summary>
        ''' Full Link for the Picture Provider. dont forget the filename.
        ''' Do NOT add querystring.
        ''' Example "http://online.ptar.uitm.edu.my/Images/Default.ashx"
        ''' </summary>
        Public Shared Property PictureProviderLink As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.picprovider_link.ToString, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(KeyName.picprovider_link.ToString, ConfigConnectionString) = value
            End Set
        End Property

#End Region

#Region "Custom Key"

        ''' <summary>
        ''' Get / Set config from SQLite.
        ''' Get / Set value by keyname.
        ''' Will auto add if key not existed.
        ''' </summary>
        ''' <param name="Keyname">Keyword</param>
        Public Shared Property CustomKey(Keyname As String) As String
            Get
                Return NasLib.Config.SQLite.Table.MyConfig.KeyValue(Keyname, ConfigConnectionString)
            End Get
            Set(value As String)
                NasLib.Config.SQLite.Table.MyConfig.KeyValue(Keyname, ConfigConnectionString) = value
            End Set
        End Property

#End Region

#End Region

#Region "Extra"

        Private Shared Sub AddNewKey(KeyName As String, KeyValue As String)

            Dim IsKeyExisted As Boolean = Table.MyConfig.IsExisted(KeyName, ConfigConnectionString)

            If Not IsKeyExisted Then
                Table.MyConfig.KeyAdd(KeyName, KeyValue, ConfigConnectionString)
            End If

        End Sub

#End Region

    End Class

End Namespace


