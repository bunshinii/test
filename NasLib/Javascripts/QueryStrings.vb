'Imports System.Web
'Imports System.Web.UI

Namespace JavaScripts

    Public Class QueryStrings

        Public Shared Function RegisterFunction() As String
            Dim GetQueryStrings As String = _
                "function getQueryStrings() {" & _
                    "var vars = [], hash;" & _
                    "var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');" & _
                    "for (var i = 0; i < hashes.length; i++) {" & _
                    "     hash = hashes[i].split('=');" & _
                    "      vars.push(hash[0]);" & _
                    "      vars[hash[0]] = hash[1];" & _
                    "  }" & _
                    " return vars;" & _
                    "}"

            Dim GetQueryString As String = _
                "function GetQueryString(keyName) {" & _
                "   return getQueryStrings()[keyName]" & _
                "}"

            Return GetQueryStrings & GetQueryString
        End Function

    End Class

End Namespace


