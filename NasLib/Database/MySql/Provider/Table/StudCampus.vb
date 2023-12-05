Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_stud_campus'
    ''' </summary>
    Public Class StudCampus

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_stud_campus"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            campus_name
            campus_code
            branchId    'Index
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(CampusCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.campus_code.ToString, CampusCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "CampusName"

        ''' <summary>
        ''' Get / Set CampusName by Campus ID
        ''' </summary>
        Public Shared Property CampusName(ByVal CampusId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.campus_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.campus_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set CampusName by CampusCode
        ''' </summary>
        Public Shared Property CampusName(ByVal _CampusCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.campus_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.campus_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "CampusCode"

        ''' <summary>
        ''' Get / Set Campus Code by Campus Id
        ''' </summary>
        Public Shared Property CampusCode(ByVal CampusId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.campus_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.campus_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Campus Code by Campus Code
        ''' </summary>
        Public Shared Property CampusCode(ByVal _CampusCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.campus_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.campus_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "branchId"

        ''' <summary>
        ''' Get / Set BranchId by CampusId ID
        ''' </summary>
        Public Shared Property BranchId(ByVal CampusId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by CampusCode
        ''' </summary>
        Public Shared Property BranchId(ByVal _CampusCode As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(CampusId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(CampusCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), CampusCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function CampusAdd(CampusCode As String, _CampusName As String, BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.campus_name.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.branchId.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _CampusName, _
                CampusCode, _
                BranchId _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function CampusDelete(CampusId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), CampusId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function CampusDelete(_CampusCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.campus_code), _CampusCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Campuses. Column(3): (id, campus_code, campus_name)
        ''' </summary>
        Public Shared Function GetAllCampuses(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_name.ToString)

            Dim Other As String = OrderBy(eFieldName.campus_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' 3 Columns(id, campus_code, campus_name)
        ''' </summary>
        Public Shared Function GetCampusesByBranchId(BranchId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, BranchId)
            Dim Other As String = OrderBy(eFieldName.campus_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(_CampusId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = BranchId(_CampusId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(_CampusId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = BranchId(_CampusId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.campus_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function CountSameParentByParentId(BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = BranchId

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = BranchId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.campus_code.ToString, _
                eFieldName.campus_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.campus_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region


    End Class

End Namespace


