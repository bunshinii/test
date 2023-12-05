Namespace Functions.String

    Public Class Cases

        Public Shared Function CamelCase(ByVal Text As String) As String
            Dim i As Long

            ' convert all non-alphanumeric chars to spaces
            For i = Len(Text) To 1 Step -1

                If InStr(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", Mid$(Text, i, 1), _
                    vbTextCompare) = 0 Then
                    Mid$(Text, i, 1) = " "
                End If
            Next
            ' convert the string to proper case, and filter out all spaces
            Return StrConv(Text, vbProperCase)

        End Function

    End Class

End Namespace


