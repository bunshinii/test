Namespace MyVariable

    ''' <summary>
    ''' HOW TO USE: 
    ''' To Set Data: MyVariable.SessionLevel.DataString(SatelliteId) = "689"
    ''' To Get Data: Dim MyStr as String = MyVariable.SessionLevel.DataString(SatelliteId)
    ''' 
    ''' Choose to keep the data in Application Level, Seesion Level, Page Level or Request Level after typing "MyVariable".
    ''' Don't forget to "Imports Rdms_Metro.MyVariable.VariableKey" to simpify enum namespace.
    ''' </summary>
    ''' <remarks></remarks>
    Module MyVariable

#Region "Variable Names"
        '1. List of of possible Variable Names in this here. This is for standardization of the key names.

        Public Enum VariableKey
            Id
            DutyId
            DutyTypeId
            SenderId
            ReceiverId
            PatronId
            Success
            Code
            SatelliteInitial
            SessionId
            Day
            Month
            Year
            BranchId
            SatelliteId
            DepartmentId
            DivisionId
            UnitId
            Url
            SnippetType
        End Enum

#End Region

    End Module

End Namespace


