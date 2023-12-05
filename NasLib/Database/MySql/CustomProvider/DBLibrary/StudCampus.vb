Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary

    ''' <summary>
    ''' This is a table base class base on table 'stud_activ' then filtered to campus only using Group By.
    ''' The operation may be very slow. Use to generate temporary data only.
    ''' </summary>
    Public Class StudCampus

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stud_activ"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            CAMPUS_CODE     'Primary Key
            CAMPUS_DESC
        End Enum

#End Region

#Region "Regular Functions"

        Public Shared Function IsExisted(CampusCode As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.CAMPUS_CODE.ToString, CampusCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' This function is very slow.
        ''' </summary>
        Public Shared Function Count(DBLibraryConnectionString) As Integer
            Dim MyTable As DataTable = GetAllCampuses(DBLibraryConnectionString)
            Dim ReturnValue As Integer = MyTable.Rows.Count
            MyTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Datatable"

        ''' <summary>
        ''' Get all Campuses as datatable with two columns. (CAMPUS_CODE, CAMPUS_DESC)
        ''' </summary>
        Public Shared Function GetAllCampuses(DBLibraryConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.CAMPUS_CODE.ToString, _
                eFieldName.CAMPUS_DESC.ToString _
                )

            Dim GroupedBy As String = eFieldName.CAMPUS_CODE.ToString
            Dim MyCriteria As String = CriteriaNotNull(eFieldName.CAMPUS_CODE.ToString)

            Return MyCmd.CmdSelectGroup(TableName, MyFields, GroupedBy, MyCriteria, , DBLibraryConnectionString)
        End Function

#End Region

    End Class

End Namespace


