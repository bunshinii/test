Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_stud_mode'
    ''' </summary>
    Public Class StudMode

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_stud_mode"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            mod_desc   'Index: Sort
            mod_code     'Index, Unique
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_ModeCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.mod_code.ToString, _ModeCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "ModDesc"

        ''' <summary>
        ''' Get / Set Study Mode Description by Mod ID
        ''' </summary>
        Public Shared Property ModDesc(ByVal ModId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.mod_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.mod_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Study Mode Description by Mod Code
        ''' </summary>
        Public Shared Property ModDesc(ByVal _ModCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.mod_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.mod_desc)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "ModeCode"

        ''' <summary>
        ''' Get / Set ModeCode by ModeId
        ''' </summary>
        Public Shared Property ModeCode(ByVal ModId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.mod_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.mod_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set ModeCode by ModeId
        ''' </summary>
        Public Shared Property ModeCode(ByVal _ModeCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.mod_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModeCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.mod_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModeCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region


#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(ModId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_ModeCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModeCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function ModeAdd(_ModeCode As String, _ModeDesc As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.mod_desc.ToString, _
                eFieldName.mod_code.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _ModeDesc, _
                _ModeCode _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ModeDelete(ModeId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), ModeId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function ModeDelete(_ModeCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.mod_code), _ModeCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Faculties. Column(3): (id, mod_code, mod_desc)
        ''' </summary>
        Public Shared Function GetAllModes(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.mod_code.ToString, _
                eFieldName.mod_desc.ToString)

            Dim Other As String = OrderBy(eFieldName.mod_desc.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


