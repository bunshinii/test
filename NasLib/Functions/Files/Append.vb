Imports System.IO

Namespace Functions.Files

    Public Class Append

        ''' <summary>
        ''' Append Text into already existed Text File. Auto crete if not existed
        ''' </summary>
        ''' <param name="TextFilePath">Absolute File Path</param>
        ''' <param name="Text">Text to append</param>
        ''' <param name="NewLineAfter">Add new line after this text?</param>
        Public Shared Sub Text(TextFilePath As String, Text As String, Optional NewLineAfter As Boolean = False)
            'TextFilePath = AppDomain.CurrentDomain.BaseDirectory

            Dim MyText As String = Text
            If NewLineAfter Then MyText = MyText & Environment.NewLine

            File.AppendAllText(TextFilePath, MyText)
        End Sub


    End Class

End Namespace
