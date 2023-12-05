Namespace Database.MySql

    Public Class GlobalVar

        Friend Shared ReadOnly Property UserOnlineSpan As TimeSpan
            Get
                Dim _Hour As Integer = 0
                Dim _Min As Integer = 15
                Dim _Sec As Integer = 0

                Dim OnlineSpan As New TimeSpan(_Hour, _Min, _Sec)
                Return OnlineSpan
            End Get
        End Property

        ''' <summary>
        ''' Check if specific version of MySQL Connector is installed
        ''' </summary>
        ''' <param name="Version">Version No (eg. '6.5.4')</param>
        Public Shared Function IsConnectorInstalled(Version As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim Conn64 As Boolean = False
            Dim Conn32 As Boolean = False

            Dim ConnVersion64 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Connector/Net", "Version", "0")
            If ConnVersion64 = Version Then Conn64 = True

            Dim ConnVersion32 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MySQL Connector/Net", "Version", "0")
            If ConnVersion32 = Version Then Conn32 = True

            If Conn64 Or Conn32 Then ReturnValue = True

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Check if any version of MySQL Connector is installed
        ''' </summary>
        Public Shared Function IsConnectorInstalled() As String
            Dim ReturnValue As Boolean = False

            Dim ConnVersion64 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Connector/Net", "Version", "0")
            Dim ConnVersion32 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MySQL Connector/Net", "Version", "0")

            If Not String.IsNullOrEmpty(ConnVersion64) Then ReturnValue = True
            If Not String.IsNullOrEmpty(ConnVersion32) Then ReturnValue = True

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Get installed version of MySQL Connector
        ''' </summary>
        Public Shared Function GetConnectorVersion() As String
            Dim ReturnValue As String = Nothing

            Dim ConnVersion64 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MySQL AB\MySQL Connector/Net", "Version", "0")
            Dim ConnVersion32 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MySQL Connector/Net", "Version", "0")

            If Not String.IsNullOrEmpty(ConnVersion64) Then ReturnValue = ConnVersion64
            If Not String.IsNullOrEmpty(ConnVersion32) Then ReturnValue = ConnVersion32

            Return ReturnValue
        End Function



    End Class

End Namespace


