Imports System.IO

Namespace Functions.Images

    Public Class Converter

        ''' <summary>
        ''' Convert an image to byte array
        ''' </summary>
        ''' <param name="ImageFileName">Image physical fullname including extension</param>
        Public Shared Function ToBytes(ImageFileName As String) As Byte()
            Dim FileTypes As String() = New String() {".gif", ".jpg", ".bmp"}

            Dim isValidFileType As Boolean = False
            Try
                Dim file As New FileInfo(ImageFileName)

                For Each strExtensionType As String In FileTypes
                    If strExtensionType = file.Extension Then
                        isValidFileType = True
                        Exit For
                    End If
                Next
                If isValidFileType Then
                    Dim fs As New FileStream(ImageFileName, FileMode.Open, FileAccess.Read)

                    Dim br As New BinaryReader(fs)

                    Dim image As Byte() = br.ReadBytes(CInt(fs.Length))

                    br.Close()

                    fs.Close()

                    Return image
                End If
                Return Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace
