Imports NasLib.Database.MySql.Provider
Imports System.Web
Imports System.Net

Namespace Functions.Web

    Public Class Url

        ''' <summary>
        ''' Get current page url.
        ''' </summary>
        ''' <param name="IncludeQueryString">Include Query String?</param>
        Public Shared Function GetCurrentURL(Optional IncludeQueryString As Boolean = False) As String
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current

            If IncludeQueryString Then
                Return contex.Request.Url.ToString
            Else
                Return contex.Request.Url.GetLeftPart(UriPartial.Path)
            End If
        End Function

        ''' <summary>
        ''' Redirect to current page url.
        ''' </summary>
        ''' <param name="IncludeQueryString">Include Query String?</param>
        Public Shared Sub ReloadPage(Optional IncludeQueryString As Boolean = False)
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current

            If IncludeQueryString Then
                contex.Response.Redirect(contex.Request.Url.ToString, True)
            Else
                contex.Response.Redirect(contex.Request.Url.GetLeftPart(UriPartial.Path), True)
            End If
        End Sub

        ''' <summary>
        ''' Rmove Externel URL Query String
        ''' </summary>
        Public Shared Function GetExternalURL(AbsoluteUrl As String, Optional IncludeQueryString As Boolean = True) As String
            Dim MyUrl As New System.Uri(AbsoluteUrl)

            If IncludeQueryString Then
                Return AbsoluteUrl
            Else
                Return MyUrl.GetLeftPart(UriPartial.Path)
            End If

            Return MyUrl.GetLeftPart(UriPartial.Path)
        End Function

        ''' <summary>
        ''' Update a Query String's value from current URL. the QueryString will be created if not existed.
        ''' Return modified URL.
        ''' </summary>
        ''' <param name="Key">Query String' Key</param>
        ''' <param name="Value">New Value</param>
        Public Shared Function UpdateQueryStringValue(Key As String, Value As String) As String
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current

            Dim MyQueryString As String = contex.Request.QueryString.ToString()
            Dim nameValues = HttpUtility.ParseQueryString(MyQueryString)
            nameValues.Set(Key, Value)
            Dim url As String = contex.Request.Url.AbsolutePath
            Dim updatedQueryString As String = "?" & nameValues.ToString()
            Return (url & updatedQueryString)
        End Function

        ''' <summary>
        ''' Get Current page Query Strings
        ''' </summary>
        Public Shared Function GetCurrentQueryString() As String
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim MyQueryString As String = contex.Request.QueryString.ToString()
            Return MyQueryString
        End Function

        ''' <summary>
        ''' Get Current page Query Strings (Keys only)
        ''' </summary>
        Public Shared Function GetCurrentQueryStringKey() As String()
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current

            Dim MyQueryString As String = contex.Request.QueryString.ToString()
            Dim nameValues = HttpUtility.ParseQueryString(MyQueryString)

            Dim MyArray As String() = nameValues.AllKeys.ToArray
            Return MyArray
        End Function

        

        ''' <summary>
        ''' Check if te URL really existed.
        ''' </summary>
        ''' <param name="AbsoluteUrl">Absolute URL only</param>
        Public Shared Function IsURLExist(AbsoluteUrl As String) As Boolean

            Try
                Dim req As WebRequest = WebRequest.Create(AbsoluteUrl)
                Dim res As WebResponse = req.GetResponse()

                IsURLExist = True
            Catch ex As WebException
                Dim message As String = ex.Message.ToString
                IsURLExist = False

                'If ex.Message.Contains("remote name could not be resolved") Then
                '    Console.WriteLine("Url is Invalid")
                'End If
            End Try
        End Function

        ''' <summary>
        ''' Convert Relative to Absolute URL.
        ''' </summary>
        ''' <param name="RelativeUrl">Relative URL Only</param>
        ''' <param name="Page">Just insert the word "Page".</param>
        Public Shared Function RelativeToAbsolute(RelativeUrl As String, Page As System.Web.UI.Page) As String
            Dim AddS As String = ""
            If HttpContext.Current.Request.IsSecureConnection Then AddS = "s"

            Dim HostUrl As String = HttpContext.Current.Request.Url.Host
            Dim ResolvedUrl As String = Page.ResolveUrl(RelativeUrl)

            Dim AbsoluteUrl As String = String.Format("http{0}://{1}{2}", AddS, HostUrl, ResolvedUrl)
            Return AbsoluteUrl
        End Function

        ''' <summary>
        ''' Get only domain from an absolute URL
        ''' </summary>
        ''' <param name="AbsoluteUrl"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDomain(AbsoluteUrl As String) As String
            Dim uri As New Uri(AbsoluteUrl)

            Dim MyPort As Integer = uri.Port
            Dim MyPortStr As String = ""
            If Not MyPort = 80 Then MyPortStr = ":" & MyPort

            Dim requested As String = uri.Scheme & uri.SchemeDelimiter & uri.Host & MyPortStr

            Return requested
        End Function

        ''' <summary>
        ''' Normal URL String to Encode
        ''' </summary>
        Public Shared Function Encode(UrlString As String) As String
            Return System.Web.HttpUtility.UrlEncode(UrlString)
        End Function

        ''' <summary>
        ''' Encoded URL String to Decode
        ''' </summary>
        Public Shared Function Decode(EncodedUrlString As String) As String
            Return System.Web.HttpUtility.UrlDecode(EncodedUrlString)
        End Function

    End Class

End Namespace


