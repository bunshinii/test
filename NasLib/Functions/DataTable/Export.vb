Imports System.IO

Namespace Functions.DataTable

    Public Class Export

        ''' <summary>
        ''' Export DataTable to Microsoft Word 2003 (doc).
        ''' In HTML format.
        ''' </summary>
        ''' <param name="Title">Title (in H2 tag)</param>
        ''' <param name="FilePath">Physical Full Path including Filename and Extension</param>
        ''' <param name="StyleString">CSS Style string (eg '.foo{color:#000}'). must use HEX colorcode</param>
        ''' <remarks></remarks>
        Public Shared Sub MSWord2003(DataTableName As System.Data.DataTable, Title As String, FilePath As String, Optional StyleString As String = "")
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current

            Dim w As StreamWriter
            w = File.CreateText(FilePath)

            Dim MyStr As String = Convert.DataTableToHTMLWord(DataTableName, Title, StyleString)
            w.WriteLine(MyStr)

            DataTableName.Dispose()
            w.Flush()
            w.Close()



        End Sub



    End Class

End Namespace


