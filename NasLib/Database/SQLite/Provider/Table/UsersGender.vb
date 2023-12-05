Imports NasLib.Database.SQLite.Sql.Simplifier
Imports NasLib.Database.SQLite.Provider

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'users_gender'
    ''' </summary>
    Public Class UsersGender

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users_gender"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            GenderId
            GenderName
            LoweredGenderName
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional                               '<-------------------------------------- Optional
        Private Shared Function GenderId(Gender As String, ProviderConnectionString As String) As Guid
            Return Table.UsersGender.GenderId(Gender, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(Gender As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.GenderId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.LoweredGenderName), Gender)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "GenderName"

        Public Shared Property GenderName(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GenderName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.GenderName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property GenderName(ByVal _Gender As String, ProviderConnectionString As String) As String
            Get
                Return GenderName(Id(_Gender, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                GenderName(Id(_Gender, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "LoweredGenderName"

        Public Shared Property LoweredGenderName(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LoweredGenderName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.LoweredGenderName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LoweredGenderName(ByVal _Gender As String, ProviderConnectionString As String) As String
            Get
                Return LoweredGenderName(Id(_Gender, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                LoweredGenderName(Id(_Gender, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(GenderId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), GenderId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Gender As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.LoweredGenderName), Gender.ToLower)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)

            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function GenderAdd(GenderName As String, ProviderConnectionString As String) As Boolean
            Dim GenderId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.GenderId.ToString, _
                eFieldName.GenderName.ToString, _
                eFieldName.LoweredGenderName.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                GenderId, _
                GenderName, _
                GenderName.ToLower)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function GenderDelete(GenderId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.GenderId), GenderId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GenderDelete(GenderName As String, ProviderConnectionString As String) As Boolean
            Return GenderDelete(Id(GenderName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


