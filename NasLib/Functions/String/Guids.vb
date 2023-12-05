Namespace Functions.String

    Public Class Guids

        ''' <summary>
        ''' Check if the GUID string is in valid format
        ''' </summary>
        Public Shared Function IsValidGuid(ByVal GuidString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Try
                Dim newGuid As Guid = New Guid(GuidString)
                ReturnValue = True
            Catch e As ArgumentNullException
                Dim Mye As String = e.Message
                ReturnValue = False
            Catch e As FormatException
                Dim Mye As String = e.Message
                ReturnValue = False
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Generate New GUID then return it as string
        ''' </summary>
        Public Shared Function NewStringGuid() As String
            Dim MyGuid As Guid = System.Guid.NewGuid

            Return MyGuid.ToString
        End Function

        ''' <summary>
        ''' Convert GUID string to GUID type
        ''' </summary>
        Public Shared Function StringToGuid(GuidString As String) As Guid
            Dim newGuid As Guid = New Guid(GuidString)
            Return newGuid
        End Function

    End Class

End Namespace


