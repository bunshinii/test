
Namespace Functions.Web

    Public Class Html

        ''' <summary>
        ''' Normal HTML String to Encode
        ''' </summary>
        Public Shared Function Encode(HtmlString As String) As String
            Return System.Web.HttpUtility.HtmlEncode(HtmlString)
        End Function

        ''' <summary>
        ''' Encoded HTML String to Decode
        ''' </summary>
        Public Shared Function Decode(EncodedHtmlString As String) As String
            Return System.Web.HttpUtility.HtmlDecode(EncodedHtmlString)
        End Function

    End Class

End Namespace


