Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'office_department'
    ''' </summary>
    Public Class OfficeDepartment

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "office_department"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            DepartmentId
            DepartmentName
            Initial
            BranchId
            OrderRank
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

        Public Shared Function Id(DepartmentInitial As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
            Dim MyCriteria As String = Criteria(eFieldName.Initial.ToString, DepartmentInitial)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "department"

        ''' <summary>
        ''' Get / Set DepartmentName by DepartmentId
        ''' </summary>
        Public Shared Property Department(ByVal DepartmentId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
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
        Public Shared Property Initial(ByVal DepartmentId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
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
        Public Shared Property BranchId(ByVal DepartmentId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Department Initial
        ''' </summary>
        ''' <param name="DepartmentInitial">Short form of Department Name</param>
        Public Shared Property BranchId(ByVal DepartmentInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return BranchId(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                BranchId(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "orderrank"

        ''' <summary>
        ''' Sorting department order.
        ''' </summary>
        Public Shared Property OrderRank(ByVal DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.OrderRank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.OrderRank)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
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
        Public Shared Property Note(ByVal DepartmentId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
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

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentInitial)
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

        Public Shared Function DepartmentAdd(DepartmentName As String, Initial As String, BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim DepartmentId As String = System.Guid.NewGuid.ToString

            Dim GetRank As String = MyCmd.CmdMax(TableName, eFieldName.OrderRank.ToString, , ProviderConnectionString)
            Dim OrderRank As Integer = 0
            If IsNumeric(GetRank) Then OrderRank = GetRank

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.DepartmentId.ToString, _
                eFieldName.DepartmentName.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.BranchId.ToString, _
                eFieldName.OrderRank.ToString, _
                eFieldName.Note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                DepartmentId, _
                DepartmentName, _
                Initial, _
                BranchId, _
                OrderRank + 1, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function DepartmentDelete(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.DepartmentId), DepartmentId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function DepartmentDelete(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return DepartmentDelete(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Departments. Column(3): (id, initial, department)
        ''' </summary>
        Public Shared Function GetAllDepartments(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DepartmentId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DepartmentName)

            Dim Other As String = OrderBy(eFieldName.DepartmentName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = BranchId(DepartmentId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = BranchId(DepartmentId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DepartmentId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DepartmentName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.DepartmentName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function


        Public Shared Function CountSameParentByParentId(BranchId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = BranchId

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = BranchId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DepartmentId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DepartmentName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.DepartmentName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


