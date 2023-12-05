Imports NasLib.Database.MySql.Provider

Namespace Functions.Web

    Public Class User

        ''' <summary>
        ''' Get user image url.
        ''' Only use this if UserPic application is running.
        ''' 'patronid' is the query string parameter for obtaining the correct pic.
        ''' </summary>
        ''' <param name="CustomPath">Path to file that will select the user pic</param>
        Public Shared Function ImageUrl(Username As String, Optional CustomPath As String = "") As String

            Dim Path As String = "/Images/Users/?patronid"
            If CustomPath.Length > 0 Then Path = CustomPath

            ImageUrl = String.Format("{0}={1}", Path, Username)
        End Function

        ''' <summary>
        ''' Get user image url for student.
        ''' Only use this if UserPic application is running.
        ''' 'patronid' is the query string parameter for obtaining the correct pic.
        ''' </summary>
        ''' <param name="CustomPath">Path to file that will select the user pic</param>
        Public Shared Function ImageUrlStudent(Username As String, Optional CustomPath As String = "") As String

            Dim Path As String = "/Images/Patron/?id"
            If CustomPath.Length > 0 Then Path = CustomPath

            ImageUrlStudent = String.Format("{0}={1}", Path, Username)
        End Function

    End Class

End Namespace


