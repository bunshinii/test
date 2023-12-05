Namespace Functions.String

    Public Class From

        ''' <summary>
        ''' Convert an array of strings into a string with each item seperated by a comma
        ''' </summary>
        ''' <param name="Text">Array</param>
        Public Shared Function Array(ByVal Text() As String) As String
            Dim ReturnValue As String = ""

            Dim ItemCount As Integer = Text.Count
            If ItemCount > 0 Then

                Dim MyStr As String = ""
                For i As Integer = 0 To ItemCount - 1
                    If i = 0 Then
                        MyStr = MyStr & Text(i)
                    Else
                        MyStr = MyStr & "," & Text(i)
                    End If
                Next

                ReturnValue = MyStr

            End If

            Return ReturnValue

        End Function

    End Class

End Namespace


