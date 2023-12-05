Imports System.IO

Namespace Functions.Files

    Public Class Delete

        ''' <summary>
        ''' Delete a file if existed
        ''' </summary>
        Public Shared Sub aFile(FilePath As String)
            'TextFilePath = AppDomain.CurrentDomain.BaseDirectory

            If File.Exists(FilePath) Then File.Delete(FilePath)
        End Sub

    End Class

End Namespace
