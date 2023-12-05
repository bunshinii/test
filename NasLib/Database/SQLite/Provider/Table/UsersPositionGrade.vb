Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'users_position_grade'
    ''' </summary>
    Public Class UsersPositionGrade

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users_position_grade"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            GradeId         'PK
            GradeCode       'Unique
            GradeType
            GradeRank       'Index
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
            Dim MyFieldName As String = FieldName(eFieldName.GradeId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeCode), Grade)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "grade"

        ''' <summary>
        ''' Get / Set Grade by GradeID
        ''' </summary>
        Public Shared Property Grade(ByVal GradeId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GradeCode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.GradeCode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
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
                Dim MyFieldName As String = FieldName(eFieldName.GradeType)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.GradeType)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
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
        Public Shared Property GradeRank(ByVal GradeId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GradeRank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.GradeRank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GradeType by Grade
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
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_Grade As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(Id(_Grade, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New GradeCode. (e.g. S17, S41 etc)
        ''' </summary>
        ''' <param name="GradeCode">GradeCode. (e.g. S17, S41 etc)</param>
        Public Shared Function GradeAdd(GradeCode As String, ProviderConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.GradeCode.ToString, _
                eFieldName.GradeType.ToString, _
                eFieldName.GradeRank.ToString)

            Dim GradeType As String = NasLib.Functions.String.Extract.LetterFromText(GradeCode).ToUpper
            Dim GradeRank As Integer = NasLib.Functions.String.Extract.NumbersFromText(GradeCode)

            Dim MyFieldsValue As String = FieldValues( _
                GradeCode, _
                GradeType, _
                GradeRank)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function GradeDelete(GradeId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.GradeId), GradeId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GradeDelete(_Grade As String, ProviderConnectionString As String) As Boolean
            Return GradeDelete(Id(_Grade, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


