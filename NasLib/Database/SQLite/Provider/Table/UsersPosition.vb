Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'users_position'
    ''' </summary>
    Public Class UsersPosition

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users_position"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            PositionId          'Primary
            GradeCode           'Index
            PositionName        'Unique
            RankNo              'Index
            GradeId
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
                Dim MyFieldName As String = FieldName(eFieldName.GradeCode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.GradeCode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "id"

        Public Shared Function PositionId(PositionName As String, ProviderConnectionString As String) As Integer
            Dim MyFields As String = eFieldName.PositionId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.PositionName.ToString, PositionName)

            Return MyCmd.CmdSelect0(TableName, MyFields, 0, MyCriteria, , ProviderConnectionString)
        End Function

#End Region

#Region "position"

        ''' <summary>
        ''' Get / Set Position Name by Position ID
        ''' </summary>
        Public Shared Property Position(ByVal PositionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PositionName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.PositionName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
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
                Dim MyFieldName As String = FieldName(eFieldName.RankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.RankNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "grade_id"

        ''' <summary>
        ''' Get / Set GradeId by Position ID
        ''' </summary>
        Public Shared Property GradeId(ByVal PositionId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GradeId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.GradeId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PositionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(PositionName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionName), PositionName)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function PositionAdd(PositionName As String, Grade As String, RankNo As Integer, GradeId As Integer, ProviderConnectionString As String) As Integer
            Dim OrderRank As Integer = 0
            If Grade.Length > 0 Then OrderRank = Functions.String.Extract.NumbersFromText(Grade)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.GradeCode.ToString, _
                eFieldName.PositionName.ToString, _
                eFieldName.RankNo.ToString, _
                eFieldName.GradeId.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                Grade, _
                PositionName, _
                OrderRank, _
                GradeId)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function PositionDelete(PositionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.PositionId), PositionId)
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
                eFieldName.PositionId.ToString, _
                eFieldName.GradeCode.ToString, _
                eFieldName.PositionName)

            Dim Other As String = OrderBy(eFieldName.RankNo.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


