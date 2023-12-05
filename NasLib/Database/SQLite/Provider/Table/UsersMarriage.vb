Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'users_marriage'
    ''' </summary>
    Public Class UsersMarriage

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users_marriage"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            MarriageId
            MarriageName
            LoweredMarriageName
        End Enum

        'Optional                               '<-------------------------------------- Optional
        Private Shared Function MarriageId(Marriage As String, ProviderConnectionString As String) As Guid
            Return Table.Users.UserId(Marriage, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(Marriage As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = eFieldName.MarriageId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.MarriageName.ToString, Marriage)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "marriage"

        Public Shared Property MarriageName(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.MarriageName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.MarriageId.ToString, UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.MarriageName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.MarriageId.ToString, UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property MarriageName(ByVal _Gender As String, ProviderConnectionString As String) As String
            Get
                Return MarriageName(Id(_Gender, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                MarriageName(Id(_Gender, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(Id As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.MarriageId.ToString, Id)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_Name As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.LoweredMarriageName.ToString, _Name.ToLower)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool

            Return IsExisted(MarriageId(_Name, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function MarriageAdd(MarriageName As String, ProviderConnectionString As String) As Integer
            Dim MarriageId As Guid = System.Guid.NewGuid()

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.MarriageId.ToString, _
                eFieldName.MarriageName.ToString, _
                eFieldName.LoweredMarriageName.ToString)


            Dim MyFieldsValue As String = FieldValues( _
                MarriageId, _
                MarriageName, _
                MarriageName.ToLower)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function MarriageDelete(MarriageId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.MarriageId.ToString, MarriageId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function MarriageDelete(MarriageName As String, ProviderConnectionString As String) As Boolean
            Return MarriageDelete(Id(MarriageName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


