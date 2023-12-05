Namespace Functions.Dates

    Public Class Convert

        ''' <summary>
        ''' Convert Date to Synonim like Today, Tomorrow, Yesterday, nDays Ago, nDays Left
        ''' </summary>
        Public Shared Function ToSynonim(TheDate As Date) As String
            Dim ReturnValue As String = Nothing

            Dim TheDays As Integer = TheDate.Subtract(Now).TotalDays + 1

            Select Case TheDays
                Case Is < -1
                    ReturnValue = String.Format("{0} days ago", TheDays * -1)
                Case -1
                    ReturnValue = "Yesterday"
                Case 0
                    ReturnValue = "Today"
                Case 1
                    ReturnValue = "Tomorrow"
                Case Is > 1
                    ReturnValue = String.Format("{0} days left", TheDays)
                Case Else
                    ReturnValue = String.Format("{0} days", TheDays)
            End Select

            Return ReturnValue
        End Function

    End Class

End Namespace


