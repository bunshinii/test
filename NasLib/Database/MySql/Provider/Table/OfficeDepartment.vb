Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_department'
    ''' </summary>
    Public Class OfficeDepartment

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_office_department"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary Key
            department  'Index: sort
            initial     'Index, Unique
            branchId    'Index
            orderrank   'Index: sort
            note
            isDisabled
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(DepartmentInitial As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.initial.ToString, DepartmentInitial)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        Public Shared Function DepartmentId(DepartmentName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.department.ToString, DepartmentName)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "department"

        ''' <summary>
        ''' Get / Set DepartmentName by DepartmentId
        ''' </summary>
        Public Shared Property Department(ByVal DepartmentId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.department)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.department)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DepartmentName by Department Initial
        ''' </summary>
        Public Shared Property Department(ByVal DepartmentInitial As String, ProviderConnectionString As String) As String
            Get
                Return Department(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Department(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "initial"

        ''' <summary>
        ''' Get / Set Initial Name by Department ID
        ''' </summary>
        Public Shared Property Initial(ByVal DepartmentId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Initial Name by Department Initial
        ''' </summary>
        ''' <param name="DepartmentInitial">Short form of Department Name</param>
        Public Shared Property Initial(ByVal DepartmentInitial As String, ProviderConnectionString As String) As String
            Get
                Return Initial(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Initial(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "branchId"

        ''' <summary>
        ''' Get / Set BranchId by Department ID
        ''' </summary>
        Public Shared Property BranchId(ByVal DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Department Initial
        ''' </summary>
        ''' <param name="DepartmentInitial">Short form of Department Name</param>
        Public Shared Property BranchId(ByVal DepartmentInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return BranchId(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                BranchId(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "orderrank"

        ''' <summary>
        ''' Sorting department order.
        ''' </summary>
        Public Shared Property OrderRank(ByVal DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.orderrank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.orderrank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Department Initial
        ''' </summary>
        ''' <param name="DepartmentInitial">Short form of Department Name</param>
        Public Shared Property OrderRank(ByVal DepartmentInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return OrderRank(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                OrderRank(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "note"

        ''' <summary>
        ''' Get / Set Note by Department ID
        ''' </summary>
        Public Shared Property Note(ByVal DepartmentId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Note by Department Initial
        ''' </summary>
        ''' <param name="DepartmentInitial">Short form of Department Name</param>
        Public Shared Property Note(ByVal DepartmentInitial As String, ProviderConnectionString As String) As String
            Get
                Return Note(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Note(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "isDisabled"

        Public Shared Property IsDisabled(ByVal DepatId_ As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepatId_)

                Dim MyInt As Integer = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Dim ReturnValue As Boolean = True
                If MyInt = 0 Then ReturnValue = False
                Return ReturnValue
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepatId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsDisabled(ByVal DeptInit_ As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), DeptInit_)

                Return MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), DeptInit_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function IsExistedInitial(Initial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), Initial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsInitialExistedNotSelf(SelfDeptInit_ As String, TargetDeptInit_ As String, ProviderConnectionString As String) As Boolean
            Dim SelfId_ As Integer = Id(SelfDeptInit_, _ProvidersConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                            CriteriaNot(FieldName(eFieldName.id), SelfId_), _
                            Criteria(eFieldName.initial.ToString, TargetDeptInit_) _
                            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function DepartmentAdd(DepartmentName As String, Initial As String, BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim OrderRank As Integer = MyCmd.CmdMax(TableName, eFieldName.orderrank.ToString, , ProviderConnectionString)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.department.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.orderrank.ToString, _
                eFieldName.note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                DepartmentName, _
                Initial, _
                BranchId, _
                OrderRank + 1, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function DepartmentDelete(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function DepartmentDelete(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return DepartmentDelete(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Hide Disabled"

        ''' <summary>
        ''' Get All Departments. Column(3): (id, initial, department).
        ''' Hide disabled.
        ''' </summary>
        Public Shared Function GetAllDepartments(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.department.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.isDisabled.ToString, False)
            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Departments by BranchId. Column(3): (id, initial, department).
        ''' Hide disabled
        ''' </summary>
        Public Shared Function GetDepartmentsByBranchId(BranchId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.department.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.branchId.ToString, BranchId), _
                Criteria(eFieldName.isDisabled.ToString, False) _
            )

            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetDepartmentsByBranchId(BranchId As Integer, FieldNames_() As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(FieldNames_)

            Dim MyCriteria As String = CriteriasAND(
                Criteria(eFieldName.branchId.ToString, BranchId),
                Criteria(eFieldName.isDisabled.ToString, False)
                )

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, , ProviderConnectionString)
        End Function

#End Region

#Region "Show Disabled"

        ''' <summary>
        ''' Get All Departments. Column(3): (id, initial, department).
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetAllDepartments2(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.department.ToString)

            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Show Disabled
        ''' </summary>
        Public Shared Function GetDepartmentsByBranchId2(BranchId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.department.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, BranchId)
            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = BranchId(DepartmentId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = BranchId(DepartmentId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.department.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function


        Public Shared Function CountSameParentByParentId(BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = BranchId

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = BranchId

            Dim _FieldsName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.initial.ToString,
                eFieldName.department.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.department.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count how many Divisions in this Department
        ''' </summary>
        ''' <param name="DepartmentId"></param>
        Public Shared Function CountDivision(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Return OfficeDivision.CountDivisionsByDepartmentId(DepartmentId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if this Department has any division or not
        ''' </summary>
        Public Shared Function HasDivision(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountDivision(DepartmentId, ProviderConnectionString) > 0 Then ReturnValue = True

            Return ReturnValue
        End Function

#End Region

    End Class

End Namespace


