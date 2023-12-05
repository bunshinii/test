Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary

    ''' <summary>
    ''' This is a table base class base on table 'staff_activ' then filtered to Department only using Group By.
    ''' The operation may be very slow. Use to generate temporary data only.
    ''' </summary>
    Public Class StafDepartment

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "staff_activ"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            BK_JAB_SEKARANG     'Primary Key
            BK_JAB_SEKARANG_DESC
        End Enum

#End Region

#Region "Regular Functions"

        Public Shared Function IsExisted(DepartmentCode As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BK_JAB_SEKARANG.ToString, DepartmentCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' This function is very slow.
        ''' </summary>
        Public Shared Function Count(DBLibraryConnectionString) As Integer
            Dim MyTable As DataTable = GetAllDepartments(DBLibraryConnectionString)
            Dim ReturnValue As Integer = MyTable.Rows.Count
            MyTable.Dispose()

            Return ReturnValue
        End Function

#End Region

#Region "Datatable"

        ''' <summary>
        ''' Get all Departments as datatable with two columns. (BK_JAB_SEKARANG, BK_JAB_SEKARANG_DESC)
        ''' </summary>
        Public Shared Function GetAllDepartments(DBLibraryConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.BK_JAB_SEKARANG.ToString, _
                eFieldName.BK_JAB_SEKARANG_DESC.ToString _
                )

            Dim GroupedBy As String = eFieldName.BK_JAB_SEKARANG.ToString
            Dim MyCriteria As String = CriteriaNotNull(eFieldName.BK_JAB_SEKARANG.ToString)

            Return MyCmd.CmdSelectGroup(TableName, MyFields, GroupedBy, MyCriteria, , DBLibraryConnectionString)
        End Function

#End Region

    End Class

End Namespace


