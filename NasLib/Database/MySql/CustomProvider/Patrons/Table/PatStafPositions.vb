Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.Patrons.Table

    ''' <summary>
    ''' This is a table base class base on table 'pat_staf_positions'
    ''' </summary>
    Public Class PatStafPositions

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "pat_staf_positions"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            pos_code
            pos_desc
            pos_grade
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_PositionCode As String, PatronsConnectionString As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.pos_code.ToString, _PositionCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
            Return MyStr
        End Function

#End Region

#Region "pos_code"

        ''' <summary>
        ''' Get / Set DepartmentCode by DepartmentId
        ''' </summary>
        Public Shared Property PositionCode(ByVal _PositionId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PositionCode(ByVal _PositionCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "pos_desc"

        ''' <summary>
        ''' Get / Set DepartmentCode by DepartmentId
        ''' </summary>
        Public Shared Property PositionDescription(ByVal _PositionId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PositionDescription(ByVal _PositionCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "pos_grade"

        ''' <summary>
        ''' Get / Set DepartmentCode by DepartmentId
        ''' </summary>
        Public Shared Property PositionGrade(ByVal _PositionId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_grade.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_grade.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PositionGrade(ByVal _PositionCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.pos_grade.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.pos_grade.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(_PositionId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_PositionCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.pos_code.ToString, _PositionCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(PatronsConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , PatronsConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function PositionAdd(_PositionCode As String, _PositionDesc As String, PatronsConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.pos_code.ToString, _
                eFieldName.pos_desc.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _PositionCode, _
                _PositionDesc _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, PatronsConnectionString)
        End Function

        Public Shared Function PositionAdd(_PositionCode As String, _PositionDesc As String, _PositionGrade As String, PatronsConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.pos_code.ToString, _
                eFieldName.pos_desc.ToString, _
                eFieldName.pos_grade.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _PositionCode, _
                _PositionDesc, _
                _PositionGrade _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, PatronsConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function PositionDelete(_PositionId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _PositionId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

        Public Shared Function PositionDelete(_PositionCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.pos_code.ToString, _PositionCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Positions"

        ''' <summary>
        ''' Geat All Department with paging. Column(id,pos_code,pos_desc,pos_grade)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllPositions(PageIndex As Integer, PageSize As Integer, PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.pos_code.ToString, _
                eFieldName.pos_desc.ToString, _
                eFieldName.pos_grade.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.pos_desc.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

        Public Shared Function GetAllPositions(PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.pos_code.ToString, _
                eFieldName.pos_desc.ToString, _
                eFieldName.pos_grade.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.pos_desc.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


