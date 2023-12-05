Namespace JavaScripts

    Public Class Favicon

        ''' <summary>
        ''' Get favicon url by any url by using Google S2 service
        ''' </summary>
        ''' <param name="AnyUrl">Any URL. Must have 'http://' or 'https://'</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetFaviconUrl(AnyUrl As String) As String
            Return "http://www.google.com/s2/favicons?domain=" & AnyUrl
        End Function

    End Class

End Namespace


