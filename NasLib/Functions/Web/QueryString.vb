Imports System.Web

Namespace Functions.Web

    Public Class QueryString


#Region "Request"

        ''' <summary>
        ''' Mimic Request("key"). Auto filter NULL value.
        ''' Return "" if empty.
        ''' </summary>
        Public Shared Function RequestStr(Key As String) As String
            Dim ReturnValue As String = ""

            Dim MyStr As String = HttpContext.Current.Request(Key)
            If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Mimic Request("key"). Auto filter NULL value.
        ''' Return 0 if empty.
        ''' </summary>
        Public Shared Function RequestInt(Key As String) As Integer
            Dim ReturnValue As Integer = 0

            Dim MyStr As String = HttpContext.Current.Request(Key)
            If Not String.IsNullOrEmpty(MyStr) Then
                If IsNumeric(MyStr) Then ReturnValue = MyStr
            End If

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Mimic Request("key"). Auto filter NULL value.
        ''' Return 0 if empty.
        ''' </summary>
        Public Shared Function RequestDouble(Key As String) As Double
            Dim ReturnValue As Double = 0

            Dim MyStr As String = HttpContext.Current.Request(Key)
            If Not String.IsNullOrEmpty(MyStr) Then
                If IsNumeric(MyStr) Then ReturnValue = MyStr
            End If

            Return ReturnValue
        End Function

        Public Shared Function RequestGuid36(Key As String) As Guid
            Dim ReturnValue As Guid = New Guid("00000000-0000-0000-0000-000000000000")

            Dim MyStr As String = HttpContext.Current.Request(Key)
            If Not String.IsNullOrEmpty(MyStr) Then

                Try
                    ReturnValue = New Guid(MyStr)
                Catch e As ArgumentNullException
                    Dim Mye As String = e.Message
                Catch e As FormatException
                    Dim Mye As String = e.Message
                End Try

            End If

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Mimic Request("key"). Auto filter NULL value.
        ''' Return false if empty.
        ''' </summary>
        Public Shared Function RequestBool(Key As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim MyStr As String = HttpContext.Current.Request(Key)
            If Not String.IsNullOrEmpty(MyStr) Then
                Try
                    ReturnValue = CBool(MyStr)
                Catch ex As Exception
                    ReturnValue = False
                End Try
            End If

            Return ReturnValue
        End Function

#End Region

#Region "Update / Add / Remove"

        ''' <summary>
        ''' Update a Query String's value from specified Virtual Path. the QueryString will be created if not existed.
        ''' Return modified URL.
        ''' </summary>
        ''' <param name="Key">Query String' Key</param>
        ''' <param name="Value">New Value</param>
        Public Shared Function UpdateQueryString(Key As String, Value As String, VirtualPath As String) As String
            Dim nameValues = HttpUtility.ParseQueryString("")
            nameValues.Set(Key, Value)


            Dim updatedQueryString As String = "?" & nameValues.ToString()

            Return (VirtualPath & updatedQueryString)
        End Function

        Public Shared Function UpdateQueryString(Key As String(), Value As String(), VirtualPath As String) As String
            Dim nameValues = HttpUtility.ParseQueryString("")

            For i As Integer = 0 To Key.Count - 1
                nameValues.Set(Key(i), Value(i))
            Next
            Dim updatedQueryString As String = "?" & nameValues.ToString()
            Return (VirtualPath & updatedQueryString)
        End Function

        Public Shared Sub AddQueryString(Key As String, Value As String, ByRef VirtualPath As String)
            Dim nameValues = HttpUtility.ParseQueryString("")
            nameValues.Set(Key, Value)
            Dim url As String = VirtualPath
            Dim updatedQueryString As String = "?" & nameValues.ToString()
            VirtualPath = (url & updatedQueryString)
        End Sub

        ''' <summary>
        ''' Generate QueryString from Keys and Values.
        ''' Number of Keys must Math the number of Values and correct sequence.
        ''' </summary>
        ''' <param name="Key">Key Array</param>
        ''' <param name="Value">Value Array</param>
        Public Shared Function GetQueryString(Key() As String, Value() As String) As String
            Dim nameValues = HttpUtility.ParseQueryString("")

            Dim KeyCount As Integer = Key.Count

            For i As Integer = 0 To KeyCount - 1
                nameValues.Set(Key(i), Value(i))
            Next

            Dim updatedQueryString As String = "?" & nameValues.ToString()
            Return updatedQueryString
        End Function

        Public Shared Function GetQueryString(Key As String, Value As String) As String
            Dim nameValues = HttpUtility.ParseQueryString("")
            nameValues.Set(Key, Value)
            Dim updatedQueryString As String = "?" & nameValues.ToString()
            Return updatedQueryString
        End Function

#End Region


        ''' <summary>
        ''' Get Current page Query Strings
        ''' </summary>
        Public Shared Function GetCurrentQueryString() As String
            Dim contex As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim MyQueryString As String = contex.Request.QueryString.ToString()
            Return MyQueryString
        End Function

        ''' <summary>
        ''' Modify Query String Value. Base URL is not included. Only Query String with no "?"
        ''' </summary>
        Public Shared Sub ModifyQueryStringValue(ByRef QueryString As String, Key As String, Value As String)

            Dim nameValues = HttpUtility.ParseQueryString(QueryString)
            nameValues.Set(Key, Value)

            QueryString = nameValues.ToString()
        End Sub

        ''' <summary>
        ''' Modify Query String Value. Base URL is not included. Only Query String with no "?"
        ''' </summary>
        Public Shared Sub ModifyQueryStringValue(ByRef QueryString As String, Key() As String, Value() As String)

            Dim nameValues = HttpUtility.ParseQueryString(QueryString)

            If Key.Count > 0 Then
                For i As Integer = 0 To Key.Count - 1
                    nameValues.Set(Key(i), Value(i))
                Next
            End If

            QueryString = nameValues.ToString()
        End Sub

        Public Shared Function GenerateQueryString(Key As String, Value As String) As String

            Dim nameValues = HttpUtility.ParseQueryString("")
            nameValues.Set(Key, Value)

            Return nameValues.ToString()
        End Function

        Public Shared Function GenerateQueryString(Key() As String, Value() As String) As String

            Dim nameValues = HttpUtility.ParseQueryString("")

            If Key.Count > 0 Then
                For i As Integer = 0 To Key.Count - 1
                    nameValues.Set(Key(i), Value(i))
                Next
            End If


            Return nameValues.ToString()
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

    End Class

End Namespace


