Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_staf_department'
    ''' </summary>
    Public Class StafDepartment

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_staf_department"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary
            dept_name
            dept_code
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

        Public Shared Function Id(_DeptCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.dept_code.ToString, _DeptCode)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "DeptName"

        ''' <summary>
        ''' Get / Set Dept Name by Dept ID
        ''' </summary>
        Public Shared Property DeptName(ByVal DeptId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.dept_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.dept_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Dept Name by Dept Code
        ''' </summary>
        Public Shared Property DeptName(ByVal _DeptCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.dept_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.dept_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "DeptCode"

        ''' <summary>
        ''' Get / Set Dept Code by Dept Id
        ''' </summary>
        Public Shared Property DeptCode(ByVal DeptId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.dept_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.dept_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Dept Code by Dept Code
        ''' </summary>
        Public Shared Property DeptCode(ByVal _DeptCode As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.dept_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.dept_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "branchId"

        ''' <summary>
        ''' Get / Set BranchId by CampusId ID
        ''' </summary>
        Public Shared Property BranchId(ByVal DeptId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                If Not IsNumeric(MyStr) Then MyStr = 0
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by CampusCode
        ''' </summary>
        Public Shared Property BranchId(ByVal _DeptCode As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(DeptId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_DeptCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function DeptAdd(_DeptCode As String, _DeptName As String, BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.dept_name.ToString, _
                eFieldName.dept_code.ToString, _
                eFieldName.branchId.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _DeptName, _
                _DeptCode, _
                BranchId _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function DeptDelete(DeptId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DeptId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function DeptDelete(_DeptCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.dept_code), _DeptCode)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Department. Column(3): (id, dept_code, dept_name)
        ''' </summary>
        Public Shared Function GetAllDepts(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.dept_code.ToString, _
                eFieldName.dept_name.ToString)

            Dim Other As String = OrderBy(eFieldName.dept_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Department by Branch ID. Column(3): (id, dept_code, dept_name)
        ''' </summary>
        Public Shared Function GetDeptsByBranchId(BranchId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.dept_code.ToString, _
                eFieldName.dept_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, BranchId)
            Dim Other As String = OrderBy(eFieldName.dept_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(_DeptId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = BranchId(_DeptId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(_DeptId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = BranchId(_DeptId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.dept_code.ToString, _
                eFieldName.dept_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.dept_name.ToString)

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
                eFieldName.dept_code.ToString, _
                eFieldName.dept_name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.dept_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region


    End Class

End Namespace


