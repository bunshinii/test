Imports System.Net

Namespace Functions.Net

    Public Class Port

        ''' <summary>
        ''' Check if port is available to use or already used.
        ''' </summary>
        ''' <param name="Hostname">Ip Addredd or hostname</param>
        ''' <param name="PortNo">Port No</param>
        Public Shared Function IsPortAvailable(Hostname As String, PortNo As Integer) As Boolean
            Dim ipa As System.Net.IPAddress = DirectCast(Dns.GetHostAddresses(Hostname)(0), System.Net.IPAddress)
            Dim ReturnValue As Boolean = False

            Try
                Dim sock As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
                sock.Connect(ipa, PortNo)
                If sock.Connected = True Then
                    ' Port is in use and connection is successful
                    'MessageBox.Show("Port is Not Available")
                    ReturnValue = False
                End If

                sock.Close()
            Catch ex As System.Net.Sockets.SocketException
                If ex.ErrorCode = 10061 Then
                    ' Port is unused and could not establish connection 
                    'MessageBox.Show("Port is Available!")
                    ReturnValue = True
                Else
                    'MessageBox.Show(ex.Message)
                    ReturnValue = False
                End If
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Check if port is open or not by another program.
        ''' </summary>
        ''' <param name="Hostname">Ip Addredd or hostname</param>
        ''' <param name="PortNo">Port No</param>
        Public Shared Function IsPortOpen(Hostname As String, PortNo As Integer) As Boolean
            Dim ipa As System.Net.IPAddress = DirectCast(Dns.GetHostAddresses(Hostname)(0), System.Net.IPAddress)
            Dim ReturnValue As Boolean = False

            Try
                Dim sock As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
                sock.Connect(ipa, PortNo)
                If sock.Connected = True Then
                    ' Port is in use and connection is successful
                    'MessageBox.Show("Port is Not Available")
                    ReturnValue = True
                End If

                sock.Close()
            Catch ex As System.Net.Sockets.SocketException
                If ex.ErrorCode = 10061 Then
                    ' Port is unused and could not establish connection 
                    'MessageBox.Show("Port is Available!")
                    ReturnValue = False
                Else
                    'MessageBox.Show(ex.Message)
                    ReturnValue = True
                End If
            End Try

            Return ReturnValue
        End Function

    End Class

End Namespace

