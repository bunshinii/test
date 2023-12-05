Namespace Functions.String

    Public Class RegexCollection

        ''' <summary>
        ''' Validate Username.
        ''' 1. Only contains alphanumeric characters, underscore and dot.
        ''' 2. Underscore and dot can't be at the end or start of a username (e.g _username / username_ / .username / username.).
        ''' 3. Underscore and dot can't be next to each other (e.g user_.name).
        ''' 4. Underscore or dot can't be used multiple times in a row (e.g user__name / user..name).
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Username() As String
            Return "^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*$"
        End Function

        ''' <summary>
        ''' Validates a name. Allows up to 40 uppercase and lowercase characters and a few special characters that are common to some names. You can modify this list.
        ''' </summary>
        Public Shared Function Name() As String
            Return "^[a-zA-Z''-'\s]{1,40}$"
        End Function
    End Class

End Namespace


