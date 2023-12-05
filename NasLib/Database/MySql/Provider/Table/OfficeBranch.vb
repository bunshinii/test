Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_branch'
    ''' </summary>
    Public Class OfficeBranch

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_office_branch"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary Key
            branch      'Index : sort
            branch_code
            staf_dept_map
            initial
            order_
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

        Public Shared Function Id(_BranchName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.branch), _BranchName)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        Public Shared Function IdByInitial(Init_ As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), Init_)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Mapped table 'my_users_office_branch'.'branch_code' with 'my_stud_campus'.'branchId'.
        ''' The 1st letter of campus_code then converted to branchId.
        ''' </summary>
        Public Shared Function IdByBranchCode(_BranchCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.branch_code), _BranchCode)
            Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Mapped table 'my_users_office_branch'.'staf_dept_map' with 'my_staf_department'.'branchId'.
        ''' The 1st letter of dept_code then converted to branchId.
        ''' </summary>
        ''' <param name="_DeptMapCode">Mapped with the first letter of the Department Code</param>
        Public Shared Function IdByDeptCode(_DeptMapCode As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.staf_dept_map), _DeptMapCode)
            Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function
#End Region

#Region "branch"

        ''' <summary>
        ''' Get / Set BranchName by Branch ID
        ''' </summary>
        Public Shared Property Branch(ByVal BranchId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branch)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.branch)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchName by BranchName
        ''' </summary>
        Public Shared Property Branch(ByVal _BranchName As String, ProviderConnectionString As String) As String
            Get
                Return Branch(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Branch(Id(_BranchName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "branch code"

        ''' <summary>
        ''' Get / Set BranchName by Branch ID
        ''' </summary>
        Public Shared Property BranchCode(ByVal BranchId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branch_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.branch_code)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchCode by BranchName
        ''' </summary>
        Public Shared Property BranchCode(ByVal _BranchName As String, ProviderConnectionString As String) As String
            Get
                Return BranchCode(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                BranchCode(Id(_BranchName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "initial"

        ''' <summary>
        ''' Get / Set BranchName by Branch ID
        ''' </summary>
        Public Shared Property BranchInitial(ByVal BranchId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchCode by BranchName
        ''' </summary>
        Public Shared Property BranchInitial(ByVal _BranchName As String, ProviderConnectionString As String) As String
            Get
                Return BranchInitial(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                BranchInitial(Id(_BranchName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "order_"

        ''' <summary>
        ''' Get / Set BranchName by Branch ID
        ''' </summary>
        Public Shared Property BranchOrder(ByVal BranchId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.order_)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.order_)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchCode by BranchName
        ''' </summary>
        Public Shared Property BranchOrder(ByVal _BranchName As String, ProviderConnectionString As String) As String
            Get
                Return BranchOrder(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                BranchOrder(Id(_BranchName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "isDisabled"

        Public Shared Property IsDisabled(ByVal BranchId_ As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId_)

                Dim MyInt As Integer = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Dim ReturnValue As Boolean = True
                If MyInt = 0 Then ReturnValue = False
                Return ReturnValue
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsDisabled(ByVal BranchInit_ As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), BranchInit_)

                Return MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), BranchInit_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_BranchName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.branch), _BranchName)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedNotSelf(BranchId As Integer, _BranchName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(FieldName(eFieldName.branch), _BranchName), _
                CriteriaNot(FieldName(eFieldName.id), BranchId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsCodeExisted(_BranchCode As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.branch_code), _BranchCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsInitialExisted(_BranchInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), _BranchInitial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsInitialExistedNotSelf(SelfBranchInit_ As String, TargetBranchInit_ As String, ProviderConnectionString As String) As Boolean
            Dim SelfId_ As Integer = IdByInitial(SelfBranchInit_, _ProvidersConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                            CriteriaNot(FieldName(eFieldName.id), SelfId_), _
                            Criteria(eFieldName.initial.ToString, TargetBranchInit_) _
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

        Public Shared Function BranchAdd(_BranchName As String, initial_ As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.branch.ToString, _
                eFieldName.initial.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                _BranchName, _
                initial_)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function BranchAdd(_BranchName As String, ProviderConnectionString As String) As Integer
            Return BranchAdd(_BranchName, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function BranchDelete(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), BranchId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function BranchDelete(_BranchName As String, ProviderConnectionString As String) As Boolean
            Return BranchDelete(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Sub BranchDisable(BranchId As Integer, ProviderConnectionString As String)
            IsDisabled(BranchId, ProviderConnectionString) = True
        End Sub

        Public Shared Sub BranchDisable(_Init As String, ProviderConnectionString As String)
            IsDisabled(_Init, ProviderConnectionString) = True
        End Sub

#End Region

#End Region

#Region "DataTables"

#Region "Hide Disabled"

        ''' <summary>
        ''' Get All Branch. Column(2): (id, branch).
        ''' Hide Disabled.
        ''' </summary>
        Public Shared Function GetAllBranches(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.branch.ToString, _
                eFieldName.initial.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.isDisabled.ToString, False)

            Dim Other As String = OrderBy(eFieldName.order_.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Id,Branch,branch_code,staf_dept_map,initial,order_.
        ''' Hide Disabled.
        ''' </summary>
        Public Shared Function GetAllBranches(FieldNames_() As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(FieldNames_)

            Dim MyCriteria As String = Criteria(eFieldName.isDisabled.ToString, False)
            Dim Other As String = OrderBy(eFieldName.order_.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#Region "Show Disabled"

        ''' <summary>
        ''' Get All Branch. Column(2): (id, branch).
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetAllBranches2(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.branch.ToString, _
                eFieldName.initial.ToString _
                )


            Dim Other As String = OrderBy(eFieldName.order_.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Id,Branch,branch_code,staf_dept_map,initial,order_.
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetAllBranches2(FieldNames_() As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(FieldNames_)

            Dim Other As String = OrderBy(eFieldName.order_.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


