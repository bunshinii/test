Namespace Functions.String

    Public Class Digits

        Public Shared Function ToSixDigitsId(PatronId As String) As String
            Do While PatronId.Length < 6
                PatronId = "0" & PatronId
            Loop

            Return PatronId
        End Function

        Public Shared Function ToNDigitsId(PatronId As String, nDigits As Integer) As String
            Do While PatronId.Length < nDigits
                PatronId = "0" & PatronId
            Loop

            Return PatronId
        End Function

    End Class

End Namespace


