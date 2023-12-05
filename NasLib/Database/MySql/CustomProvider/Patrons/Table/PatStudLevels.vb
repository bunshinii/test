Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.Patrons.Table

    ''' <summary>
    ''' This is a table base class base on table 'pat_stud_levels'
    ''' </summary>
    Public Class PatStudLevels

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "pat_stud_levels"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            level_code
            level_desc
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_LevelCode As String, PatronsConnectionString As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.level_code.ToString, _LevelCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
            Return MyStr
        End Function

#End Region

#Region "code"

        ''' <summary>
        ''' Get / Set LevelCode by LevelId
        ''' </summary>
        Public Shared Property LevelCode(ByVal _LevelId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.level_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.level_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property LevelCode(ByVal _LevelCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.level_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.level_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "desc"

        ''' <summary>
        ''' Get / Set LevelCode by LevelId
        ''' </summary>
        Public Shared Property LevelDescription(ByVal _LevelId As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.level_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.level_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property LevelDescription(ByVal _LevelCode As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.level_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.level_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(_LevelId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_LevelCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.level_code.ToString, _LevelCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(PatronsConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , PatronsConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function LevelAdd(_LevelCode As String, _LevelDesc As String, PatronsConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.level_code.ToString, _
                eFieldName.level_desc.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _LevelCode, _
                _LevelDesc _
                )


            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, PatronsConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function LevelDelete(_LevelId As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _LevelId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

        Public Shared Function LevelDelete(_LevelCode As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.level_code.ToString, _LevelCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, PatronsConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Levels"

        ''' <summary>
        ''' Geat All Levels with paging. Column(id,type_code,type_desc)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllLevels(PageIndex As Integer, PageSize As Integer, PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.level_code.ToString, _
                eFieldName.level_desc.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.level_desc.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

        Public Shared Function GetAllLevels(PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.level_code.ToString, _
                eFieldName.level_desc.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.level_desc.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


