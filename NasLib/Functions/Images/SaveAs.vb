Imports System.IO

Namespace Functions.Images

    Public Class SaveAs

        ''' <summary>
        ''' Save Image from Byte type to sistem file into current server directory.
        ''' Must be used to save within the working / current application path only
        ''' </summary>
        ''' <param name="UrlPath">URL to save the file into including filename and extension. Must use "~/". Will automatically mapped with the server physical path</param>
        ''' <remarks></remarks>
        Public Shared Sub ByteToDisk(Bytes As Byte(), UrlPath As String, Optional Overwrite As Boolean = False)
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim ServerPath As String = context.Server.MapPath(UrlPath)

            If Not File.Exists(ServerPath) Then
                File.WriteAllBytes(ServerPath, Bytes)
            Else
                If Overwrite Then File.WriteAllBytes(ServerPath, Bytes)
            End If

        End Sub

        ''' <summary>
        ''' Check if the file already existed in the server. only usable within the current server.
        ''' </summary>
        ''' <param name="UrlPath">URL to save the file into including filename and extension. Must use "~/". Will automatically mapped with the server physical path</param>
        Public Shared Function IsExisted(UrlPath As String) As Boolean
            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
            Dim ServerPath As String = context.Server.MapPath(UrlPath)

            Return File.Exists(ServerPath)
        End Function


    End Class

End Namespace


