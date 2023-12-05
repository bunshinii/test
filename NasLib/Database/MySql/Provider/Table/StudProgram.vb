Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_stud_program'
    ''' </summary>
    Public Class StudProgram

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_stud_program"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            program_desc
            program_code
            program_letter
            program_number
            faculty_code
            level_code
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_ProgramCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.program_code.ToString, _ProgramCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "ProgramDesc"

        ''' <summary>
        ''' Get / Set Program Description by ProgramID
        ''' </summary>
        Public Shared Property ProgramDesc(ByVal ProgramId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.program_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.program_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Program Description by ProgramCode
        ''' </summary>
        Public Shared Property ProgramDesc(ByVal _ProgramCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.program_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.program_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "LevelCode"

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramId
        ''' </summary>
        Public Shared Property ProgramCode(ByVal ProgramId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.program_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.program_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramCode
        ''' </summary>
        Public Shared Property ProgramCode(ByVal _ProgramCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.program_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.program_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "faculty_code"

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramId
        ''' </summary>
        Public Shared Property FacultyCode(ByVal ProgramId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramCode
        ''' </summary>
        Public Shared Property FacultyCode(ByVal _ProgramCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "level_code"

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramId
        ''' </summary>
        Public Shared Property LevelCode(ByVal ProgramId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.level_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set ProgramCode by ProgramCode
        ''' </summary>
        Public Shared Property LevelCode(ByVal _ProgramCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.level_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(ProgramId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_ProgramCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        'program_letter' and 'program_number' will be automatically filled.
        Public Shared Function ProgramAdd(_ProgramCode As String, _ProgramDesc As String, _FacultyCode As String, ProviderConnectionString As String) As Integer
            Dim ProgLetter As String = Functions.String.Extract.LetterFromText(_ProgramCode)
            Dim ProgNumber As String = Functions.String.Extract.NumbersFromText(_ProgramCode)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.program_desc.ToString, _
                eFieldName.program_code.ToString, _
                eFieldName.program_letter.ToString, _
                eFieldName.program_number.ToString, _
                eFieldName.faculty_code.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _ProgramDesc, _
                _ProgramCode, _
                ProgLetter, _
                ProgNumber, _
                _FacultyCode _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ProgramDelete(ProgramId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ProgramId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function ProgramDelete(_ProgramCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.program_code), _ProgramCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Programs. Column(3): (id, program_code, program_desc)
        ''' </summary>
        Public Shared Function GetAllPrograms(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.program_code.ToString, _
                eFieldName.program_desc.ToString)

            Dim Other As String = OrderBy(eFieldName.program_desc.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Programs. Column(3): (id, program_code, program_desc, level_code)
        ''' </summary>
        Public Shared Function GetAllPrograms(FacultyCode_ As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.program_code.ToString, _
                eFieldName.program_desc.ToString, _
                eFieldName.level_code.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.faculty_code.ToString, FacultyCode_)

            Dim Other As String = OrderBy(eFieldName.program_desc.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)

        End Function

#End Region

    End Class

End Namespace


