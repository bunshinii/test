Imports System.Net

Namespace Functions.Net

    Public Class IpAddress

#Region "Get Ip Address"

        ''' <summary>
        ''' Get IP Address for current machine (IPv4 only).
        ''' </summary>
        ''' <param name="JustOne">Just get the first IP Address if the machine have many. If False, all IP Addresses will be seperated by a coma. </param>
        Public Shared Function GetIpAddress(Optional JustOne As Boolean = True) As String
            Dim IpCount As Integer = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(Function(a As System.Net.IPAddress) Not a.IsIPv6LinkLocal AndAlso Not a.IsIPv6Multicast AndAlso Not a.IsIPv6SiteLocal).ToList.Count

            Dim MyAddress As String = Nothing

            If IpCount > 0 Then

                For Each s In Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(Function(a As System.Net.IPAddress) Not a.IsIPv6LinkLocal AndAlso Not a.IsIPv6Multicast AndAlso Not a.IsIPv6SiteLocal).ToList

                    If IsValidIP(s.ToString) Then
                        If MyAddress = Nothing Then
                            MyAddress = s.ToString
                        Else
                            MyAddress = MyAddress & ", " & s.ToString
                        End If
                    End If

                Next

            End If

            Return MyAddress
        End Function

        Public Shared Function GetHostName() As String
            Return Dns.GetHostName()
        End Function

#End Region

#Region "Validator"

        ''' <summary>
        ''' Method to validate an IP address
        ''' using regular expressions. The pattern
        ''' being used will validate an ip address
        ''' with the range of 1.0.0.0 to 255.255.255.255
        ''' </summary>
        ''' <param name="IpAddress">IP Address to validate</param>
        Public Shared Function IsValidIP(ByVal IpAddress As String) As Boolean
            'create our match pattern
            Dim pattern As String = "^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\." & _
            "([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$"
            'create our Regular Expression object
            Dim check As New Text.RegularExpressions.Regex(pattern)
            'boolean variable to hold the status
            Dim valid As Boolean = False
            'check to make sure an ip address was provided
            If IpAddress = "" Then
                'no address provided so return false
                valid = False
            Else
                'address provided so use the IsMatch Method
                'of the Regular Expression object
                valid = check.IsMatch(IpAddress, 0)
            End If
            'return the results
            Return valid
        End Function

        ''' <summary>
        ''' Method to validate an Internal IP address
        ''' using regular expressions. The pattern
        ''' being used will validate an ip address
        ''' with the range of 10.0.0.0 to 10.255.255.255
        ''' </summary>
        ''' <param name="IpAddress">IP Address to validate</param>
        Public Shared Function IsValidInternalIp(ByVal IpAddress As String) As Boolean
            'create our match pattern
            Dim pattern As String = "^10\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))$"
            'create our Regular Expression object
            Dim check As New Text.RegularExpressions.Regex(pattern)
            'boolean variable to hold the status
            Dim valid As Boolean = False
            'check to make sure an ip address was provided
            If IpAddress = "" Then
                'no address provided so return false
                valid = False
            Else
                'address provided so use the IsMatch Method
                'of the Regular Expression object
                valid = check.IsMatch(IpAddress, 0)
            End If
            'return the results
            Return valid
        End Function

        ''' <summary>
        ''' Method to validate an Internal Class C IP address
        ''' using regular expressions. The pattern
        ''' being used will validate an ip address
        ''' with the range of 192.168.0.0 to 192.168.255.255
        ''' </summary>
        ''' <param name="IpAddress">IP Address to validate</param>
        Public Shared Function IsValidInternalIpC(ByVal IpAddress As String) As Boolean
            'create our match pattern
            Dim pattern As String = "^192\.168\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))$"
            'create our Regular Expression object
            Dim check As New Text.RegularExpressions.Regex(pattern)
            'boolean variable to hold the status
            Dim valid As Boolean = False
            'check to make sure an ip address was provided
            If IpAddress = "" Then
                'no address provided so return false
                valid = False
            Else
                'address provided so use the IsMatch Method
                'of the Regular Expression object
                valid = check.IsMatch(IpAddress, 0)
            End If
            'return the results
            Return valid
        End Function

#End Region

    End Class

End Namespace
