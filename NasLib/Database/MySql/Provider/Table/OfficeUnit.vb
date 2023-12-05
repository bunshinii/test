Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_unit'
    ''' </summary>
    Public Class OfficeUnit

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_office_unit"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            unit            'Index: sort
            initial         'Index, Unique
            branchId        'Index
            departmentId    'Index
            divisionId      'Index
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

        Public Shared Function Id(UnitInitial As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.initial.ToString, UnitInitial)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "unit"

        ''' <summary>
        ''' Get / Set UnitName by UnitId
        ''' </summary>
        Public Shared Property Unit(ByVal UnitId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.unit)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.unit)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set UnitName by Unit Initial
        ''' </summary>
        Public Shared Property Unit(ByVal UnitInitial As String, ProviderConnectionString As String) As String
            Get
                Return Unit(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Unit(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "initial"

        ''' <summary>
        ''' Get / Set Initial Name by Unit ID
        ''' </summary>
        Public Shared Property Initial(ByVal UnitId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Initial Name by Unit Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Unit Name</param>
        Public Shared Property Initial(ByVal UnitInitial As String, ProviderConnectionString As String) As String
            Get
                Return Initial(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Initial(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "branchId"

        ''' <summary>
        ''' Get / Set BranchId by UnitId
        ''' </summary>
        Public Shared Property BranchId(ByVal UnitId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Division Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Division Name</param>
        Public Shared Property BranchId(ByVal UnitInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return BranchId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                BranchId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "departmentId"

        ''' <summary>
        ''' Get / Set DepartmentId by UnitId
        ''' </summary>
        Public Shared Property DepartmentId(ByVal UnitId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.departmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.departmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DepartmentId by Unit Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Unit Name</param>
        Public Shared Property DepartmentId(ByVal UnitInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return DepartmentId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                DepartmentId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "divisionId"

        ''' <summary>
        ''' Get / Set DivisionId by UnitId
        ''' </summary>
        Public Shared Property DivisionId(ByVal UnitId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.divisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.divisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DivisionId by Unit Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Unit Name</param>
        Public Shared Property DivisionId(ByVal UnitInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return DivisionId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                DivisionId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "note"

        ''' <summary>
        ''' Get / Set Note by Division ID
        ''' </summary>
        Public Shared Property Note(ByVal UnitId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Note by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Department Name</param>
        Public Shared Property Note(ByVal DivisionInitial As String, ProviderConnectionString As String) As String
            Get
                Return Note(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Note(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "isDisabled"

        Public Shared Property IsDisabled(ByVal UnitId_ As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId_)

                Dim MyInt As Integer = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Dim ReturnValue As Boolean = True
                If MyInt = 0 Then ReturnValue = False
                Return ReturnValue
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsDisabled(ByVal UnitInit_ As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), UnitInit_)

                Return MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), UnitInit_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(UnitInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), UnitInitial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedInitial(Initial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), Initial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function IsInitialExistedNotSelf(SelfUnitInit_ As String, TargetUnitInit_ As String, ProviderConnectionString As String) As Boolean
            Dim SelfId_ As Integer = Id(SelfUnitInit_, _ProvidersConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                            CriteriaNot(FieldName(eFieldName.id), SelfId_), _
                            Criteria(eFieldName.initial.ToString, TargetUnitInit_) _
                            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function UnitAdd(UnitName As String, Initial As String, BranchId As Integer, DepartmentId As Integer, DivisionId As Integer, ProviderConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.unit.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.departmentId.ToString, _
                eFieldName.divisionId.ToString, _
                eFieldName.note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UnitName, _
                Initial, _
                BranchId, _
                DepartmentId, _
                DivisionId, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function UnitDelete(UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UnitId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnitDelete(UnitInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), UnitInitial)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Hide Disabled"

        ''' <summary>
        ''' Hide disabled.
        ''' </summary>
        Public Shared Function GetUnitsByDivisionId(DivisionId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.unit.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.divisionId.ToString, DivisionId), _
                Criteria(eFieldName.isDisabled.ToString, False) _
                )

            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUnitsByDivisionId(DivisionId_ As Integer, FieldNames_() As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(FieldNames_)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.divisionId.ToString, DivisionId_), _
                Criteria(eFieldName.isDisabled.ToString, False) _
            )

            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Units. Column(3): (id, initial, unit).
        ''' Hide Disabled.
        ''' </summary>
        Public Shared Function GetAllUnits(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.initial.ToString,
                eFieldName.unit.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.isDisabled.ToString, False)
            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count All Units by Division ID. Column(3): (id, initial, department).
        ''' Hide Disabled
        ''' </summary>
        Public Shared Function CountUnitsByDivisionId(DivisionId As Integer, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND(
                Criteria(eFieldName.divisionId.ToString, DivisionId),
                Criteria(eFieldName.isDisabled.ToString, False)
            )

            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count how many Staffs in this Unit
        ''' </summary>
        Public Shared Function CountStaffInUnit(UnitId As Integer, ProviderConnectionString As String) As Integer
            Return OfficeUnit.CountUnitsByDivisionId(UnitId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if this Unit has any Staff or not
        ''' </summary>
        Public Shared Function HasStaff(UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountStaffInUnit(UnitId, ProviderConnectionString) > 0 Then ReturnValue = True

            Return ReturnValue
        End Function

#End Region

#Region "Show Disabled"

        ''' <summary>
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetUnitsByDivisionId2(DivisionId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.unit.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.divisionId.ToString, DivisionId)
            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Units. Column(3): (id, initial, unit).
        ''' Show Disabled.
        ''' </summary>
        Public Shared Function GetAllUnits2(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.unit.ToString)

            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(UnitId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = DivisionId(UnitId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.divisionId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(UnitId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = DivisionId(UnitId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.unit.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.divisionId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function CountSameParentByParentId(DivisionId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = DivisionId

            Dim MyCriteria As String = Criteria(eFieldName.divisionId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(DivisionId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = DivisionId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.unit.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.divisionId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.unit.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


