Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_branch'
    ''' </summary>
    Public Class OfficeBranch

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "office_branch"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            BranchId
            BranchName
            Note
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(_BranchName As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = eFieldName.BranchId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.BranchName.ToString, _BranchName)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "branch"

        ''' <summary>
        ''' Get / Set BranchName by Gender ID
        ''' </summary>
        Public Shared Property Branch(ByVal BranchId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BranchName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.BranchName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
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

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_BranchName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BranchName.ToString, _BranchName)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function BranchAdd(_BranchName As String, ProviderConnectionString As String) As Integer
            Dim BranchId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.BranchId.ToString, _
                eFieldName.BranchName.ToString, _
                eFieldName.Note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                BranchId, _
                _BranchName, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function BranchDelete(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function BranchDelete(_BranchName As String, ProviderConnectionString As String) As Boolean
            Return BranchDelete(Id(_BranchName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Branch. Column(2): (BranchId, BranchName)
        ''' </summary>
        Public Shared Function GetAllBranchs(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.BranchId.ToString, _
                eFieldName.BranchName.ToString)

            Dim Other As String = OrderBy(eFieldName.BranchName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


