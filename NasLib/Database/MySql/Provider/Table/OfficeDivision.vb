Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_division'
    ''' </summary>
    Public Class OfficeDivision

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_office_division"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            division        'Index: Sort
            initial         'Index, Unique
            branchId        'Index
            departmentId    'Index
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

        Public Shared Function Id(DivisionInitial As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(eFieldName.initial.ToString, DivisionInitial)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "department"

        ''' <summary>
        ''' Get / Set DivisionName by DivisionId
        ''' </summary>
        Public Shared Property Division(ByVal DivisionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.division)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.division)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DivisionName by Division Initial
        ''' </summary>
        Public Shared Property Division(ByVal DivisionInitial As String, ProviderConnectionString As String) As String
            Get
                Return Division(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Division(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "initial"

        ''' <summary>
        ''' Get / Set Initial Name by Department ID
        ''' </summary>
        Public Shared Property Initial(ByVal DivisionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set Initial Name by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Division Name</param>
        Public Shared Property Initial(ByVal DivisionInitial As String, ProviderConnectionString As String) As String
            Get
                Return Initial(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Initial(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "branchId"

        ''' <summary>
        ''' Get / Set BranchId by DivisionId
        ''' </summary>
        Public Shared Property BranchId(ByVal DivisionId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Division Name</param>
        Public Shared Property BranchId(ByVal DivisionInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return BranchId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                BranchId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "departmentId"

        ''' <summary>
        ''' Get / Set DepartmentId by DivisionId
        ''' </summary>
        Public Shared Property DepartmentId(ByVal DivisionId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.departmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.departmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DepartmentId by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Division Name</param>
        Public Shared Property DepartmentId(ByVal DivisionInitial As String, ProviderConnectionString As String) As Integer
            Get
                Return DepartmentId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                DepartmentId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "note"

        ''' <summary>
        ''' Get / Set Note by Division ID
        ''' </summary>
        Public Shared Property Note(ByVal DivisionId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId)
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

        Public Shared Property IsDisabled(ByVal DivisionId_ As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId_)

                Dim MyInt As Integer = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Dim ReturnValue As Boolean = True
                If MyInt = 0 Then ReturnValue = False
                Return ReturnValue
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DivisionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsDisabled(ByVal DivisionInit_ As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), DivisionInit_)

                Return MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isDisabled)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.initial), DivisionInit_)
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

        Public Shared Function IsInitialExistedNotSelf(SelfDivInit_ As String, TargetDivInit_ As String, ProviderConnectionString As String) As Boolean
            Dim SelfId_ As Integer = Id(SelfDivInit_, _ProvidersConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                            CriteriaNot(FieldName(eFieldName.id), SelfId_), _
                            Criteria(eFieldName.initial.ToString, TargetDivInit_) _
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

        Public Shared Function DivisionAdd(DivisionName As String, Initial As String, BranchId As Integer, DepartmentId As Integer, ProviderConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.division.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.departmentId.ToString, _
                eFieldName.note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                DivisionName, _
                Initial, _
                BranchId, _
                DepartmentId, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function DivisionDelete(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), DepartmentId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function DivisionDelete(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return DivisionDelete(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Hide Disabled"

        ''' <summary>
        ''' Get All Divisions. Column(3): (id, initial, department).
        ''' Hide Disabled.
        ''' </summary>
        Public Shared Function GetAllDivisions(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.division.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.isDisabled.ToString, False)
            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Divisions by Department ID. Column(3): (id, initial, department).
        ''' Hide Disabled
        ''' </summary>
        Public Shared Function GetDivisionsByDepartmentId(DepartmentId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.division.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.departmentId.ToString, DepartmentId), _
                Criteria(eFieldName.isDisabled.ToString, False) _
            )

            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetDivisionsByDepartmentId(DepartmentId As Integer, FieldNames_() As String, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames(FieldNames_)

            Dim MyCriteria As String = CriteriasAND(
                Criteria(eFieldName.departmentId.ToString, DepartmentId),
                Criteria(eFieldName.isDisabled.ToString, False)
            )

            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count All Divisions by Department ID. Column(3): (id, initial, department).
        ''' Hide Disabled
        ''' </summary>
        Public Shared Function CountDivisionsByDepartmentId(DepartmentId As Integer, ProviderConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND(
                Criteria(eFieldName.departmentId.ToString, DepartmentId),
                Criteria(eFieldName.isDisabled.ToString, False)
            )

            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Show Disabled"

        ''' <summary>
        ''' Get All Divisions. Column(3): (id, initial, department).
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetAllDivisions2(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.division.ToString)

            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Show disabled.
        ''' </summary>
        Public Shared Function GetDivisionsByDepartmentId2(DepartmentId As Integer, ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.division.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.departmentId.ToString, DepartmentId)
            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(DivisionId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = DepartmentId(DivisionId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.departmentId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(DivisionId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = DepartmentId(DivisionId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.initial.ToString, _
                eFieldName.division.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.departmentId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function


        Public Shared Function CountSameParentByParentId(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Dim MyParentId As Integer = DepartmentId

            Dim MyCriteria As String = Criteria(eFieldName.departmentId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            Dim ParentId As Integer = DepartmentId

            Dim _FieldsName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.initial.ToString,
                eFieldName.division.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.departmentId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.division.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count how many Units in this Division
        ''' </summary>
        Public Shared Function CountUnit(DivisionId As Integer, ProviderConnectionString As String) As Integer
            Return OfficeUnit.CountUnitsByDivisionId(DivisionId, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if this Division has any Unit or not
        ''' </summary>
        Public Shared Function HasUnit(DivisionId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If CountUnit(DivisionId, ProviderConnectionString) > 0 Then ReturnValue = True

            Return ReturnValue
        End Function

#End Region

    End Class

End Namespace


