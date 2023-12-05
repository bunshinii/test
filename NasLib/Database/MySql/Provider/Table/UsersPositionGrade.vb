Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_position_grade'
    ''' </summary>
    Public Class UsersPositionGrade

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_position_grade"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'PK
            grade       'Unique
            grade_type
            grade_rank  'Index
            grade_order
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(Grade As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.grade), Grade)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

        Public Shared Function GradeId(Grade As String, ProviderConnectionString As String) As Integer
            Return Id(Grade, ProviderConnectionString)
        End Function

#End Region

#Region "grade"

        ''' <summary>
        ''' Get / Set Grade by GradeID
        ''' </summary>
        Public Shared Property Grade(ByVal GradeId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Grade by Grade
        ''' </summary>
        Public Shared Property Grade(ByVal _Grade As String, ProviderConnectionString As String) As String
            Get
                Return Grade(Id(_Grade, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Grade(Id(_Grade, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "grade_type"

        ''' <summary>
        ''' Get / Set GradeType by GradeID
        ''' </summary>
        Public Shared Property GradeType(ByVal GradeId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.grade_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GradeType by Grade
        ''' </summary>
        Public Shared Property GradeType(ByVal _Grade As String, ProviderConnectionString As String) As String
            Get
                Return GradeType(Id(_Grade, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                GradeType(Id(_Grade, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "grade_rank"

        ''' <summary>
        ''' Get / Set GradeRank by GradeID.
        ''' For sorting purpose. Greater value to the top.
        ''' </summary>
        Public Shared Property GradeRank(ByVal GradeId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade_rank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.grade_rank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GradeRank by Grade
        ''' </summary>
        Public Shared Property GradeRank(ByVal _Grade As String, ProviderConnectionString As String) As String
            Get
                Return GradeRank(Id(_Grade, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                GradeRank(Id(_Grade, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(GradeId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_Grade As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.grade), _Grade)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New GradeCode. (e.g. S17, S41 etc).
        ''' ' grade_type, grade_rank and grade_order will be automatically assigned but 'grade_order' need to edit accordingly.
        ''' </summary>
        ''' <param name="GradeCode">GradeCode. (e.g. S17, S41 etc)</param>
        Public Shared Function GradeAdd(GradeCode As String, ProviderConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.grade.ToString, _
                eFieldName.grade_type.ToString, _
                eFieldName.grade_rank.ToString,
                eFieldName.grade_order.ToString _
                )

            Dim GradeType As String = NasLib.Functions.String.Extract.LetterFromText(GradeCode).ToUpper
            Dim GradeRank As Integer = NasLib.Functions.String.Extract.NumbersFromText(GradeCode)
            Dim GradeOrder As Integer = GradeRank

            Dim MyFieldsValue As String = FieldValues( _
                GradeCode, _
                GradeType, _
                GradeRank, _
                GradeOrder _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function GradeDelete(GradeId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GradeId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GradeDelete(_Grade As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.grade), _Grade)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        Public Shared Function GetAllGrade(ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.grade.ToString)

            Dim Other As String = OrderBy(eFieldName.grade_rank.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, MyFields, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get all grade type. (Grouped By).
        ''' Represent the letter of the grade.
        ''' Unique.
        ''' 1 Column (grade_type).
        ''' </summary>
        Public Shared Function GetAllGradeType(ProviderConnectionString As String) As DataTable
            Dim MyField As String = eFieldName.grade_type.ToString

            Dim Other As String = OrderBy(eFieldName.grade_type.ToString)

            Return MyCmd.CmdSelectGroup(TableName, MyField, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get all grade rank. (Grouped By).
        ''' Represent the rank of the grade.
        ''' Unique.
        ''' 1 Column (grade_rank).
        ''' </summary>
        Public Shared Function GetAllGradeRank(ProviderConnectionString As String) As DataTable
            Dim MyField As String = eFieldName.grade_rank.ToString

            Dim Other As String = OrderBy(eFieldName.grade_rank.ToString, False)

            Return MyCmd.CmdSelectGroup(TableName, MyField, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get list of grade rank by a grade type. Column(grade_type)
        ''' </summary>
        Public Shared Function GetGradeRank(GradeType As String, ProviderConnectionString As String) As DataTable
            Dim MyField As String = eFieldName.grade_rank.ToString
            Dim MyCriteria As String = Criteria(eFieldName.grade_type.ToString, GradeType)
            Dim Other As String = OrderBy(eFieldName.grade_rank.ToString, False)

            Return MyCmd.CmdSelectGroup(TableName, MyField, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Will import data from 'provider' 'my_users_position' table grade data into 'Provider' 'my_users_position_grade' table.
        ''' The 'my_users_position' table must be imported first. This function will NOT connect to 'DBLIBRARY' database.
        ''' Ignored if grade_code already existed and only assigned grade in 'my_users_position' will be imported.
        ''' grade_type, grade_rank and grade_order will be automatically assigned but 'grade_order' need to edit accordingly.
        ''' </summary>
        Public Shared Function ImportGrade(ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim GradeTable As DataTable = Table.UsersPosition.GetAssignedGrade(ProviderConnectionString)

            If GradeTable.Rows.Count > 0 Then

                For i As Integer = 0 To GradeTable.Rows.Count - 1
                    Dim GradeCode As String = GradeTable(i)(0).ToString.Trim.ToUpper

                    If Not Table.UsersPositionGrade.IsExisted(GradeCode, ProviderConnectionString) Then
                        Table.UsersPositionGrade.GradeAdd(GradeCode, ProviderConnectionString)
                    End If

                Next

            End If

            GradeTable.Dispose()

            Return ReturnValue
        End Function

#End Region
    End Class

End Namespace


