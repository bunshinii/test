Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.RdmsMedium

    Module RdmsMedium
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "rdms_medium"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            medium_name     'Index
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Function Id(MediumName_ As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.medium_name.ToString, MediumName_)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "MediumName"

        Public Property MediumName(ByVal MediumId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.medium_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, MediumId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.medium_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, MediumId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property MediumName(ByVal MediumName_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.medium_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.medium_name.ToString, MediumName_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.medium_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.medium_name.ToString, MediumName_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(MediumId As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, MediumId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(MediumName_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.medium_name.ToString, MediumName_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function MediumAdd(MediumName_ As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.medium_name.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                MediumName_ _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function MediumDelete(MediumId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, MediumId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function MediumDelete(MediumName_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.medium_name.ToString, MediumName_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 2 columns (id, medium_name)
        ''' </summary>
        Public Function GetAllMediums() As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.medium_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , , MyAppConnectionString)
        End Function

#End Region


    End Module

End Namespace


