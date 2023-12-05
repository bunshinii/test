Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'office_unit'
    ''' </summary>
    Public Class OfficeUnit

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "office_unit"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            UnitId
            UnitName
            Initial
            BranchId
            DepartmentId
            DivisionId
            Note
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(UnitInitial As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.UnitId)
            Dim MyCriteria As String = Criteria(eFieldName.Initial.ToString, UnitInitial)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "unit"

        ''' <summary>
        ''' Get / Set UnitName by UnitId
        ''' </summary>
        Public Shared Property Unit(ByVal UnitId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.UnitName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.UnitName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
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
        Public Shared Property Initial(ByVal UnitId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
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
        Public Shared Property BranchId(ByVal UnitId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Division Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Division Name</param>
        Public Shared Property BranchId(ByVal UnitInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return BranchId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                BranchId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "departmentId"

        ''' <summary>
        ''' Get / Set DepartmentId by UnitId
        ''' </summary>
        Public Shared Property DepartmentId(ByVal UnitId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DepartmentId by Unit Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Unit Name</param>
        Public Shared Property DepartmentId(ByVal UnitInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return DepartmentId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                DepartmentId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "divisionId"

        ''' <summary>
        ''' Get / Set DivisionId by UnitId
        ''' </summary>
        Public Shared Property DivisionId(ByVal UnitId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DivisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.DivisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DivisionId by Unit Initial
        ''' </summary>
        ''' <param name="UnitInitial">Short form of Unit Name</param>
        Public Shared Property DivisionId(ByVal UnitInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return DivisionId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                DivisionId(Id(UnitInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "note"

        ''' <summary>
        ''' Get / Set Note by Division ID
        ''' </summary>
        Public Shared Property Note(ByVal UnitId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
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

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), DepartmentId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Initial), DepartmentInitial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedInitial(Initial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Initial), Initial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function UnitAdd(UnitName As String, Initial As String, BranchId As Integer, DepartmentId As Integer, DivisionId As Integer, ProviderConnectionString As String) As Integer
            Dim UnitId As String = System.Guid.NewGuid.ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.UnitId.ToString, _
                eFieldName.UnitName.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.BranchId.ToString, _
                eFieldName.DepartmentId.ToString, _
                eFieldName.DivisionId.ToString, _
                eFieldName.Note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                UnitId, _
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

        Public Shared Function UnitDelete(UnitId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.UnitId), UnitId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UnitDelete(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return UnitDelete(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Units. Column(3): (id, initial, unit)
        ''' </summary>
        Public Shared Function GetAllUnits(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.UnitId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.UnitName)

            Dim Other As String = OrderBy(eFieldName.UnitName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region


#Region "Special Functions"

        Public Shared Function CountSameParent(UnitId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = DivisionId(UnitId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.DivisionId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(UnitId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = DivisionId(UnitId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.UnitId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.UnitName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.DivisionId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.UnitName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function CountSameParentByParentId(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = DivisionId

            Dim MyCriteria As String = Criteria(eFieldName.DivisionId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = DivisionId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.UnitId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.UnitName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.DivisionId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.UnitName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


