Namespace Functions.Dates

    Public Class Format

#Region "MySql Format"

        ''' <summary>
        ''' Convert specified DateTime format to MySql DateTime format
        ''' </summary>
        Public Shared Function MySqlDateTime(TheDate As Date) As String
            Return Microsoft.VisualBasic.Strings.Format(TheDate, "yyyy-MM-dd HH:mm:ss")
        End Function

        ''' <summary>
        ''' Convert current DateTime format to MySql DateTime format
        ''' </summary>
        Public Shared Function MySqlDateTime() As String
            Return Microsoft.VisualBasic.Strings.Format(Now, "yyyy-MM-dd HH:mm:ss")
        End Function

#End Region


    End Class

End Namespace


