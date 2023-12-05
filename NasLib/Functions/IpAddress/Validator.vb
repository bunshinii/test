Namespace Functions.IpAddress

    ''' <summary>
    ''' Methods to validate an IP addresses
    ''' </summary>
    Public Class Validator

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

    End Class

End Namespace


