Namespace Functions.String

    Public Class Convert

        Public Shared Function ToMySqlDateTime(TheDateTime As String) As String

            If IsDate(TheDateTime) Then
                Return Format(CDate(TheDateTime), "yyy-MM-dd HH:mm:ss")
            Else
                Return "0000-00-00 00:00:00"
            End If

        End Function

    End Class

End Namespace


