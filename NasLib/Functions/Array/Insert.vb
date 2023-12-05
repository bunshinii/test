Namespace Functions.MyArrays

    Public Class Insert

        ''' <summary>
        ''' Insert a value to array
        ''' </summary>
        ''' <param name="Text">Array</param>
        ''' <param name="NewValue">New Value to insert into the array</param>
        Public Shared Function IntoArray(ByVal Text() As String, ParamArray NewValue() As String) As String()
            Dim ReturnValue As String() = Nothing

            Dim MyStr As String = Functions.String.From.Array(Text)

            If NewValue.Count > 0 Then
                For i As Integer = 0 To NewValue.Count - 1

                    If i = 0 Then
                        If MyStr.Length > 0 Then
                            MyStr = MyStr & "," & NewValue(i)
                        Else
                            MyStr = NewValue(i)
                        End If
                    End If

                    MyStr = MyStr & "," & NewValue(i)
                Next
            End If

            ReturnValue = MyStr.Split(",")

            Return ReturnValue

        End Function

    End Class

End Namespace


