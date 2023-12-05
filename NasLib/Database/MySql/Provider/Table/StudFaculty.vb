Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_stud_faculty'
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
            Return "my_stud_faculty"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            faculty_name   'Index: Sort
            faculty_code     'Index, Unique
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(FacultyCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.faculty_code.ToString, FacultyCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "FacultyName"

        ''' <summary>
        ''' Get / Set FacultyName by FacultyID
        ''' </summary>
        Public Shared Property FacultyName(ByVal FacultyId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set FacultyName by FacultyCode
        ''' </summary>
        Public Shared Property FacultyName(ByVal _FacultyCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), _FacultyCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), _FacultyCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "FacultyCode"

        ''' <summary>
        ''' Get / Set FacultyCode by FacultyId
        ''' </summary>
        Public Shared Property FacultyCode(ByVal FacultyId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set FacultyCode by FacultyCode
        ''' </summary>
        Public Shared Property FacultyCode(ByVal _FacultyCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), _FacultyCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.faculty_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), _FacultyCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region


#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(FacultyId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(FacultyCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), FacultyCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function FacultyAdd(_FacultyCode As String, _FacultyName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.faculty_name.ToString, _
                eFieldName.faculty_code.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _FacultyName, _
                _FacultyCode _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function FacultyDelete(FacultyId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FacultyId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function FacultyDelete(_FacultyCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.faculty_code), _FacultyCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Faculties. Column(3): (id, faculty_code, faculty_name)
        ''' </summary>
        Public Shared Function GetAllFaculties(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.faculty_code.ToString, _
                eFieldName.faculty_name.ToString)

            Dim Other As String = OrderBy(eFieldName.faculty_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


