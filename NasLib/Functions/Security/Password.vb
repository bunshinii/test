Imports System.Security.Cryptography

Namespace Functions.Security

    Public Class Password

        Public Shared Function GeneratePasswordSalt() As String
            Dim rng As New RNGCryptoServiceProvider()
            Dim buff As Byte() = New Byte(15) {}
            rng.GetBytes(buff)
            Return Convert.ToBase64String(buff)
        End Function

        ''' <summary>
        ''' Generate random password
        ''' </summary>
        ''' <param name="PassLength">Password length</param>
        Public Function GenerateRandomPassword(ByVal PassLength As Integer) As String
            'Get the GUID
            Dim guidResult As String = System.Guid.NewGuid().ToString()

            'Remove the hyphens
            guidResult = guidResult.Replace("-", String.Empty)

            'Make sure length is valid
            If PassLength <= 0 OrElse PassLength > guidResult.Length Then
                Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
            End If

            'Return the first length bytes
            Return guidResult.Substring(0, PassLength)
        End Function
    End Class

End Namespace


