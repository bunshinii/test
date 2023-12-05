Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary

    ''' <summary>
    ''' This is a table base class base on table 'stud_activ' then filtered to Faculty only using Group By.
    ''' The operation may be very slow. Use to generate temporary data only.
    ''' </summary>
    Public Class StudFaculty

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
            FACULTY_CODE
            FACULTY_DESC
        End Enum

#End Region

#Region "Regular Functions"

        Public Shared Function IsExisted(FacultyCode As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.FACULTY_CODE.ToString, FacultyCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' This function is very slow.
        ''' </summary>
        Public Shared Function Count(DBLibraryConnectionString) As Integer
            Dim MyTable As DataTable = GetAllFaculties(DBLibraryConnectionString)
            Dim ReturnValue As Integer = MyTable.Rows.Count
            MyTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Datatable"

        ''' <summary>
        ''' Get all Faculties as datatable with two columns. (FACULTY_CODE, FACULTY_DESC)
        ''' </summary>
        Public Shared Function GetAllFaculties(DBLibraryConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.FACULTY_CODE.ToString, _
                eFieldName.FACULTY_DESC.ToString _
                )

            Dim GroupedBy As String = eFieldName.FACULTY_CODE.ToString
            Dim MyCriteria As String = CriteriaNotNull(eFieldName.FACULTY_CODE.ToString)

            Return MyCmd.CmdSelectGroup(TableName, MyFields, GroupedBy, MyCriteria, , DBLibraryConnectionString)
        End Function

#End Region

    End Class

End Namespace


