Namespace Database.MySql.Provider
    Public Class Positions

        Public Shared Function PositionId(PositionCode As String, ProviderConnectionString As String) As String
            Return Table.UsersPosition.PositionId(PositionCode, ProviderConnectionString)
        End Function

        Public Shared Function PositionName(PositionId As Integer, ProviderConnectionString As String) As String
            Return Table.UsersPosition.Position(PositionId, ProviderConnectionString)
        End Function

        Public Shared Function PositionCode(PositionId As Integer, ProviderConnectionString As String) As String
            Return Table.UsersPosition.PositionCode(PositionId, ProviderConnectionString)
        End Function

        Public Shared Function PositionType(PositionId As Integer, ProviderConnectionString As String) As String
            Return Table.UsersPosition.PositionType(PositionId, ProviderConnectionString)
        End Function

#Region "Automation"

        ''' <summary>
        ''' Assign a user to grade
        ''' </summary>
        Public Function AutoUserAssignGrade(ByVal UserId As Integer, ByVal PositionName As String, ProviderConnectionString As String) As Boolean
            Dim PositionId As Integer = Table.UsersPosition.PositionId(PositionName, ProviderConnectionString)
            Dim GradeName As String = Table.UsersPosition.Grade(PositionId, ProviderConnectionString)

            Dim GradeId As Integer = 0

            If Table.UsersPositionGrade.IsExisted(GradeName, ProviderConnectionString) Then
                GradeId = Table.UsersPositionGrade.GradeId(GradeName, ProviderConnectionString)
                Table.UsersProfile.GradeId(UserId, ProviderConnectionString) = GradeId
            End If

            Return Nothing
        End Function

        Public Function ImportPatronPosition(ByVal PatronId As String, DbLibraryConnectionString As String, ProviderConnectionString As String) As String
            Dim PositionName As String = Functions.String.Cases.CamelCase(CustomProvider.DBLibrary.Patron.GetPatronPosition(PatronId, DbLibraryConnectionString))

            Dim IsPositionExisted As Boolean = Table.UsersPosition.IsExisted(PositionName, ProviderConnectionString)
            If Not IsPositionExisted Then Table.UsersPosition.PositionAdd(PositionName, "", 0, ProviderConnectionString)

            Return PositionName
        End Function

#End Region

    End Class
End Namespace

