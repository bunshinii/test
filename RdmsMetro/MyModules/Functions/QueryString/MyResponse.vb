Imports NasLib.Functions.Web.QueryString

Namespace MyModules.Functions.QueryString.MyResponse

    Module MyResponse

        ''' <param name="BaseVirtualPath">Base and relative  path only. NO query string</param>
        Public Sub Redirect(BaseVirtualPath As String)
            Dim context As HttpContext = HttpContext.Current
            context.Response.Redirect(BaseVirtualPath, True)
        End Sub

        ''' <summary>
        ''' Redirect to Current URL with modified query string
        ''' </summary>
        Public Sub Redirect(Key As String, Value As String)
            Dim context As HttpContext = HttpContext.Current

            Dim nameValues = HttpUtility.ParseQueryString(context.Request.QueryString.ToString())
            nameValues.Set(Key, Value)
            Dim url As String = context.Request.Url.AbsolutePath
            Dim updatedQueryString As String = "?" & nameValues.ToString()

            context.Response.Redirect(url & updatedQueryString, True)
        End Sub

        ''' <summary>
        ''' Redirect to Current URL with modified query strings
        ''' </summary>
        Public Sub Redirect(Key() As String, Value() As String)
            Dim context As HttpContext = HttpContext.Current

            Dim nameValues = HttpUtility.ParseQueryString(context.Request.QueryString.ToString())

            If Key.Count > 0 Then
                For i As Integer = 0 To Key.Count - 1
                    nameValues.Set(Key(i), Value(i))
                Next
            End If

            Dim url As String = context.Request.Url.AbsolutePath
            Dim updatedQueryString As String = "?" & nameValues.ToString()

            context.Response.Redirect(url & updatedQueryString, True)
        End Sub

        ''' <param name="BaseVirtualPath">Base and relative  path only. NO query string</param>
        ''' <param name="Key">MyRequest._UNDERSCORED Variable. ALWAYS </param>
        ''' <param name="Value">MyRequest.Get..., or other value</param>
        Public Sub Redirect(BaseVirtualPath As String, Key() As String, Value() As String)
            Dim context As HttpContext = HttpContext.Current
            context.Response.Redirect(BaseVirtualPath & GetQueryString(Key, Value), True)
        End Sub

        ''' <param name="BaseVirtualPath">Base and relative  path only. NO query string</param>
        ''' <param name="Key">MyRequest._UNDERSCORED Variable. ALWAYS </param>
        ''' <param name="Value">MyRequest.Get..., or other value</param>
        Public Sub Redirect(BaseVirtualPath As String, Key As String, Value As String)
            Dim context As HttpContext = HttpContext.Current
            context.Response.Redirect(BaseVirtualPath & GetQueryString(Key, Value), True)
        End Sub

        ''' <param name="BaseVirtualPath">Base and relative  path only. NO query string</param>
        ''' <param name="Key">MyRequest._UNDERSCORED Variable. ALWAYS </param>
        ''' <param name="Value">MyRequest.Get..., or other value</param>
        Public Function Url(BaseVirtualPath As String, Key As String(), Value As String()) As String
            Return UpdateQueryString(Key, Value, BaseVirtualPath)
        End Function

        ''' <param name="BaseVirtualPath">Base and relative  path only. NO query string</param>
        ''' <param name="Key">MyRequest._UNDERSCORED Variable. ALWAYS </param>
        ''' <param name="Value">MyRequest.Get..., or other value</param>
        Public Function Url(BaseVirtualPath As String, Key As String, Value As String) As String
            Return UpdateQueryString(Key, Value, BaseVirtualPath)
        End Function



    End Module

End Namespace


