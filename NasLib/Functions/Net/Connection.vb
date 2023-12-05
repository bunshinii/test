Imports System.Net.Sockets
Imports System.Net

Namespace Functions.Net
    Public Class Connection

        ''' <summary>
        ''' Test Connection to specified host or ip address
        ''' </summary>
        ''' <param name="Hostname">Ip Address or hostname</param>
        ''' <param name="PortNo">Port No</param>
        Public Shared Function TestConnection(Hostname As String, PortNo As Integer) As Boolean

            Dim success As Boolean = False
            Using mySocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                Try
                    mySocket.Connect(Hostname, PortNo)
                    success = mySocket.Connected
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    success = False
                End Try
            End Using

            Return success
        End Function

        ''' <summary>
        ''' Check if the system is connected to internet
        ''' </summary>
        ''' <param name="WebsiteAddress">Website with http protocol (eg. http://www.microsoft.com)</param>
        ''' <param name="ReqTimeout">Timeout in miliseconds</param>
        Public Shared Function IsConnectedToInternet(WebsiteAddress As String, ReqTimeout As Integer) As Boolean
            Try
                'Try to do the web request.
                Dim hwebRequest As HttpWebRequest = DirectCast(WebRequest.Create(WebsiteAddress), HttpWebRequest)
                'Do the request to the Microsoft website (can be anyone, it need to be online).
                hwebRequest.Timeout = ReqTimeout
                '10 seconds timeout to process the request.
                Dim hWebResponse As HttpWebResponse = DirectCast(hwebRequest.GetResponse(), HttpWebResponse)
                'Process the request.
                If hWebResponse.StatusCode = HttpStatusCode.OK Then
                    'Get the response.
                    'If true, the user is connected to the internet.
                    Return True
                Else
                    Return False
                    'Else it is not.
                End If
            Catch
                Return False
                'If any problem occurs inside the method, stop and return false.
            End Try
        End Function

        Public Shared Function IsConnectedToInternet() As Boolean
            Dim WebAddress As String = "http://www.microsoft.com"
            Dim ReqTimeout As Integer = 10000
            Return IsConnectedToInternet(WebAddress, ReqTimeout)
        End Function



    End Class

End Namespace

