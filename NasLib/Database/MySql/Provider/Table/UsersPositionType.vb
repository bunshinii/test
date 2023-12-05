Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_position'
    ''' </summary>
    Public Class UsersPositionType

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_position_type"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            position_type       'Index
            description    'Unique
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "position_type"

#Region "id"

        Public Shared Function PositionId(PositionTypeCode_ As String, ProviderConnectionString As String) As Integer
            Dim MyFields As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.description.ToString, PositionTypeCode_)

            Return MyCmd.CmdSelect0(TableName, MyFields, 0, MyCriteria, , ProviderConnectionString)
        End Function

#End Region

        ''' <summary>
        ''' Get / Set Position Type Code by Position Type ID
        ''' </summary>
        Public Shared Property PositionType(ByVal PositionTypeId_ As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If MyStr.Length = 0 Then MyStr = ""
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.position_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Position Type Code by Position Type Code.
        ''' Return '' if no value.
        ''' </summary>
        Public Shared Property PositionType(ByVal PositionTypeCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If String.IsNullOrEmpty(MyStr) Then MyStr = ""
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.position_type)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "description"

        ''' <summary>
        ''' Get / Set Position Type Description by Position Type ID
        ''' </summary>
        Public Shared Property Description(ByVal PositionTypeId_ As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Position Type Description by Position Type Code.
        ''' Return '' if no value.
        ''' </summary>
        Public Shared Property Description(ByVal PositionTypeCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If String.IsNullOrEmpty(MyStr) Then MyStr = ""
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region


#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PositionTypeId_ As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(PositionTypeCode_ As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"


        Public Shared Function PositionTypeAdd(PositionTypeCode_ As String, PositionTypeDescription As String, ProviderConnectionString As String) As Integer


            Dim MyFieldsName As String = FieldNames( _
                eFieldName.position_type.ToString, _
                eFieldName.description.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                PositionTypeCode_, _
                PositionTypeDescription _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function PositionTypeDelete(PositionTypeId_ As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), PositionTypeId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function PositionTypeDelete(PositionTypeCode_ As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.position_type), PositionTypeCode_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Positions. Column(3): (id, position_type, description)
        ''' </summary>
        Public Shared Function GetAllPositionTypes(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.position_type.ToString, _
                eFieldName.description.ToString)

            Dim Other As String = OrderBy(eFieldName.description.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


