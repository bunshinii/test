Namespace Functions.Dates

    Public Class IsCheck

        ''' <summary>
        ''' Check if specified date is Today
        ''' </summary>
        Public Shared Function IsToday(TheDate As Date) As Boolean
            Dim ReturnValue As Boolean = False

            Dim TodayString As String = Microsoft.VisualBasic.Strings.Format(Now, "yyyy-MM-dd")
            Dim TheDateString As String = Microsoft.VisualBasic.Strings.Format(TheDate, "yyyy-MM-dd")

            If TodayString = TheDateString Then ReturnValue = True

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Check if specified date is Yesterday
        ''' </summary>
        Public Shared Function IsYesterday(TheDate As Date) As Boolean
            Dim ReturnValue As Boolean = False

            Dim YesterdayString As String = Microsoft.VisualBasic.Strings.Format(Now.AddDays(-1), "yyyy-MM-dd")
            Dim TheDateString As String = Microsoft.VisualBasic.Strings.Format(TheDate, "yyyy-MM-dd")

            If YesterdayString = TheDateString Then ReturnValue = True

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Check if specified date is Tomorrow
        ''' </summary>
        Public Shared Function IsTomorrow(TheDate As Date) As Boolean
            Dim ReturnValue As Boolean = False

            Dim TomorrowString As String = Microsoft.VisualBasic.Strings.Format(Now.AddDays(1), "yyyy-MM-dd")
            Dim TheDateString As String = Microsoft.VisualBasic.Strings.Format(TheDate, "yyyy-MM-dd")

            If TomorrowString = TheDateString Then ReturnValue = True

            Return ReturnValue
        End Function

    End Class

End Namespace


