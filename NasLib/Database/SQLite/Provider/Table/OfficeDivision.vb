Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'office_division'
    ''' </summary>
    Public Class OfficeDivision

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "office_division"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            DivisionId
            DivisionName
            Initial
            BranchId
            DepartmentId
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

        Public Shared Function Id(DivisionInitial As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.DivisionId)
            Dim MyCriteria As String = Criteria(eFieldName.Initial.ToString, DivisionInitial)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "DivisionName"

        ''' <summary>
        ''' Get / Set DivisionName by DivisionId
        ''' </summary>
        Public Shared Property Division(ByVal DivisionId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DivisionName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.DivisionName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
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
        Public Shared Property Initial(ByVal DivisionId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
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
        Public Shared Property BranchId(ByVal DivisionId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Division Name</param>
        Public Shared Property BranchId(ByVal DivisionInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return BranchId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                BranchId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "departmentId"

        ''' <summary>
        ''' Get / Set DepartmentId by DivisionId
        ''' </summary>
        Public Shared Property DepartmentId(ByVal DivisionId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set DepartmentId by Division Initial
        ''' </summary>
        ''' <param name="DivisionInitial">Short form of Division Name</param>
        Public Shared Property DepartmentId(ByVal DivisionInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return DepartmentId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                DepartmentId(Id(DivisionInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "note"

        ''' <summary>
        ''' Get / Set Note by Division ID
        ''' </summary>
        Public Shared Property Note(ByVal DivisionId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
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
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DepartmentId)
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

        Public Shared Function DivisionAdd(DivisionName As String, Initial As String, BranchId As Integer, DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Dim DivsionId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.BranchId.ToString, _
                eFieldName.DivisionName.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.BranchId.ToString, _
                eFieldName.DepartmentId.ToString, _
                eFieldName.Note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                BranchId, _
                DivisionName, _
                Initial, _
                BranchId, _
                DepartmentId, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function DivisionDelete(DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.DivisionId), DivisionId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function DivisionDelete(DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Return DivisionDelete(Id(DepartmentInitial, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Divisions. Column(3): (id, initial, department)
        ''' </summary>
        Public Shared Function GetAllDivisions(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DivisionId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DivisionName)

            Dim Other As String = OrderBy(eFieldName.DivisionName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = DepartmentId(DivisionId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = DepartmentId(DivisionId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DivisionId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DivisionName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.DivisionName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function


        Public Shared Function CountSameParentByParentId(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = DepartmentId

            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = DepartmentId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.DivisionId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.DivisionName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.DivisionName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


