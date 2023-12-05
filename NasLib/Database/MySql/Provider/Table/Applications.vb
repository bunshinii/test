Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_applications'
    ''' </summary>
    Public Class Applications

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"
        'Each Table Base Class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Table Fields Properties" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier

        Private Shared Function TableName() As String
            Return "my_aspnet_applications"            '<-------------------------------------- 1 ' Modify TableName
        End Function

        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary Key
            name            'Index (sort)
            description

            '' Multiple Field Index:
            '  NONE
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(AppName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), AppName)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "name"

        Public Shared Property ApplicationName(ByVal AppId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), AppId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), AppId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationName(ByVal AppName As String, ProviderConnectionString As String) As String
            Get
                Return ApplicationName(Id(AppName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                ApplicationName(Id(AppName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "description"

        Public Shared Property Description(ByVal AppId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), AppId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.description)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), AppId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Description(ByVal AppName As String, ProviderConnectionString As String) As String
            Get
                Return Description(Id(AppName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Description(Id(AppName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(AppId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, AppId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(AppName As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(Id(AppName, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New Application. Will return Application ID
        ''' </summary>
        Public Shared Function ApplicationAdd(AppName As String, AppDesc As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.name.ToString, _
                eFieldName.description.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                AppName,
                AppDesc)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ApplicationDelete(AppId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), AppId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function ApplicationDelete(AppName As String, ProviderConnectionString As String) As Boolean
            Return ApplicationDelete(Id(AppName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Extra Functions"

        Public Shared Function ApplicationCount(ProviderConnectionString As String) As Integer
            Dim MyStr As String = MyCmd.CmdCount(TableName, , ProviderConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Related Fields (id,name,description)
        ''' </summary>
        Public Shared Function ApplicationList(ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldName(eFieldName.id) & "," & FieldName(eFieldName.name) & "," & FieldName(eFieldName.description)
            Dim Other As String = OrderBy(FieldName(eFieldName.name), True)
            Return MyCmd.CmdSelectTable(TableName, MyFields, , Other, ProviderConnectionString)
        End Function

#End Region
    End Class

End Namespace


