Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_Profile'
    ''' </summary>
    Public Class Profile

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "aspnet_Profile"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            UserId
            LastUpdateDate
            PropertyNames
            PropertyValuesString
            PropertyValueBinary
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"


#Region "LastUpdateDate"

        Public Shared Property LastUpdateDate(ByVal UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Dim MyFieldName As String = eFieldName.LastUpdateDate.ToString
                Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Date)
                Dim MyFieldName As String = eFieldName.LastUpdateDate.ToString
                Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function ProfileAdd(UserId As Guid, ProviderConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.LastUpdateDate.ToString, _
                eFieldName.PropertyNames.ToString, _
                eFieldName.PropertyValuesString.ToString _
                )

            Dim CurrentDate As Date = Now

            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                CurrentDate, _
                "", _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ProfileDelete(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId.ToString)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


