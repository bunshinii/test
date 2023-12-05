Imports System.IO

Namespace Functions

    Public Class _Files

        Public Shared Function IsExisted(FilePath As String) As Boolean
            Return File.Exists(FilePath)
        End Function

        Public Shared Function GetCurrentDirectory() As String
            Return AppDomain.CurrentDomain.BaseDirectory
        End Function

    End Class

End Namespace



