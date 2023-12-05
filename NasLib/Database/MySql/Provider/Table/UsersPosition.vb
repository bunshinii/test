Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_position'
    ''' </summary>
    Public Class UsersPosition

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_position"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            grade       'Index
            pos_code    'Unique
            position
            pos_type    'Index
            rankNo      'Index
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "grade"

        ''' <summary>
        ''' Get / Set Grade by Position ID
        ''' </summary>
        Public Shared Property Grade(ByVal PositionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If MyStr.Length = 0 Then MyStr = ""
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Grade by Position Code.
        ''' Return '' if no value.
        ''' </summary>
        Public Shared Property Grade(ByVal PositionCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If String.IsNullOrEmpty(MyStr) Then MyStr = ""
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "id"

        Public Shared Function PositionId(PositionCode As String, ProviderConnectionString As String) As Integer
            Dim MyFields As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.pos_code.ToString, PositionCode)

            Return MyCmd.CmdSelect0(TableName, MyFields, 0, MyCriteria, , ProviderConnectionString)
        End Function

#End Region

#Region "position"

        ''' <summary>
        ''' Get / Set Position Name by Position ID
        ''' </summary>
        Public Shared Property Position(ByVal PositionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.position)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Position Name by Position Code
        ''' </summary>
        Public Shared Property Position(ByVal PositionCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.position)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "position code"

        ''' <summary>
        ''' Get / Set Position Code by Position ID
        ''' </summary>
        Public Shared Property PositionCode(ByVal PositionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.pos_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.pos_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "position type"

        ''' <summary>
        ''' Get / Set Position Code by Position ID
        ''' </summary>
        Public Shared Property PositionType(ByVal PositionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.pos_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.pos_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Position Code by Position Code
        ''' </summary>
        Public Shared Property PositionType(ByVal PositionCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.pos_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.pos_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "rankNo"

        ''' <summary>
        ''' Get / Set RankNo by Position ID
        ''' </summary>
        Public Shared Property rankNo(ByVal PositionId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.rankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.rankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set RankNo by Position Code
        ''' </summary>
        Public Shared Property rankNo(ByVal PositionCode As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.rankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.rankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.pos_code), PositionCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PositionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(PositionCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.position), PositionCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function PositionAdd(PositionName As String, PositionCode As String, PositionType As String, ProviderConnectionString As String) As Integer
            Return PositionAdd(PositionName, PositionCode, PositionType, "", 0, ProviderConnectionString)
        End Function

        Public Shared Function PositionAdd(PositionName As String, PositionCode As String, PositionType As String, Grade As String, RankNo As Integer, ProviderConnectionString As String) As Integer
            Dim OrderRank As Integer = 0
            If Grade.Length > 0 Then OrderRank = Functions.String.Extract.NumbersFromText(Grade)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.position.ToString, _
                eFieldName.pos_code.ToString, _
                eFieldName.pos_type.ToString, _
                eFieldName.grade.ToString, _
                eFieldName.rankNo.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                PositionName, _
                PositionCode, _
                PositionType, _
                Grade, _
                RankNo _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function PositionAdd(PositionName As String, Grade As String, RankNo As Integer, ProviderConnectionString As String) As Integer
            Dim OrderRank As Integer = 0
            If Grade.Length > 0 Then OrderRank = Functions.String.Extract.NumbersFromText(Grade)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.grade.ToString, _
                eFieldName.position.ToString, _
                eFieldName.rankNo.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Grade, _
                PositionName, _
                OrderRank _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function PositionDelete(PositionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function PositionDelete(Position As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.position), Position)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Positions. Column(3): (id, grade, position)
        ''' </summary>
        Public Shared Function GetAllPositions(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.grade.ToString, _
                eFieldName.position.ToString)

            Dim Other As String = OrderBy(eFieldName.position.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get Positions By Grade. Column(id, position)
        ''' </summary>
        Public Shared Function GetPositionsByGrade(GradeCode As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.position.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.grade.ToString, GradeCode)
            Dim Other As String = OrderBy(eFieldName.position.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get a list of assigned grade.
        ''' Will not get empty or null grade.
        ''' </summary>
        Public Shared Function GetAssignedGrade(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.grade.ToString _
                )

            Dim MyCriteria As String = CriteriasAND(CriteriaNot(eFieldName.grade.ToString, ""), CriteriaNotNull(eFieldName.grade.ToString))

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, , ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


