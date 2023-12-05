Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.Patrons.Table

    ''' <summary>
    ''' This is a table base class base on table 'pat_stud_campus'
    ''' </summary>
    Public Class PatStudCampus

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "pat_stud_campus"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            campus_code
            campus_desc
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_CampusCode As String, PatronsConnectionString As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.campus_code.ToString, _CampusCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
            Return MyStr
        End Function

#End Region

#Region "code"

        ''' <summary>
        ''' Get / Set CampusCode by CampusId
        ''' </summary>
        Public Shared Property CampusCode(ByVal _CampusId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.campus_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.campus_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property CampusCode(ByVal _CampusCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.campus_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.campus_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "desc"

        ''' <summary>
        ''' Get / Set CampusCode by CampusId
        ''' </summary>
        Public Shared Property CampusDescription(ByVal _CampusId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.campus_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.campus_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property CampusDescription(ByVal _CampusCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.campus_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.campus_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(_CampusId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_CampusCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.campus_code.ToString, _CampusCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(PatronsConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , PatronsConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function CampusAdd(_CampusCode As String, _CampusDesc As String, PatronsConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_desc.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _CampusCode, _
                _CampusDesc _
                )


            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, PatronsConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function CampusDelete(_CampusId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _CampusId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

        Public Shared Function CampusDelete(_CampusCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.campus_code.ToString, _CampusCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Types"

        ''' <summary>
        ''' Geat All Types with paging. Column(id,campus_code,campus_desc)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllCampuses(PageIndex As Integer, PageSize As Integer, PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_desc.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.campus_desc.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

        Public Shared Function GetAllCampuses(PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_desc.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.campus_desc.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


