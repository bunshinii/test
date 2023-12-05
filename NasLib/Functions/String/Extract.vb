Namespace Functions.String

    Public Class Extract

        ''' <summary>
        ''' Extract Number from Text.
        ''' Only get numbers from provided text.
        ''' </summary>
        Public Shared Function NumbersFromText(ByVal TextExpr As String) As String
            Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(TextExpr, "[^\d]"))
        End Function

        ''' <summary>
        ''' Extract Letter from Text.
        ''' Only get letters from provided text.
        ''' </summary>
        Public Shared Function LetterFromText(ByVal TextExpr As String) As String
            Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(TextExpr, "[^a-zA-Z]"))
        End Function

    End Class

End Namespace


