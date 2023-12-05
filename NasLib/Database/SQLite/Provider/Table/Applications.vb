Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_Applications'
    ''' </summary>
    Public Class Applications

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"
        'Each Table Base Class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Table Fields Properties" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier

        Private Shared Function TableName() As String
            Return "aspnet_Applications"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            ApplicationId
            ApplicationName
            Description
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "ApplicationId"

        ''' <summary>
        ''' Get Application Guid by Application Name (Case Sensitive)
        ''' </summary>
        ''' <param name="AppName">Application Name (Case Sensitive)</param>
        Public Shared Function Id(AppName As String, ProviderConnectionString As String) As String
            Dim MyFieldName As String = eFieldName.ApplicationId.ToString
            Dim MyCriteria As String = Criteria(eFieldName.ApplicationName.ToString, AppName)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "ApplicationName"

        Public Shared Property ApplicationName(ByVal AppId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.ApplicationName.ToString
                Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldNames( _
                    eFieldName.ApplicationName.ToString)

                Dim MyFieldValue As String = FieldValues( _
                    value)

                Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "description"

        Public Shared Property Description(ByVal AppId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.Description.ToString
                Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.Description.ToString
                Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(AppId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if Application Name is existed. Case Sensitive
        ''' </summary>
        ''' <param name="AppName">Application Name. Case Sensitive</param>
        Public Shared Function IsExisted(AppName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.ApplicationName.ToString, AppName.ToString)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
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
        Public Shared Function ApplicationAdd(AppName As String, AppDesc As String, ProviderConnectionString As String) As Boolean
            Dim AppId As String = System.Guid.NewGuid().ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.ApplicationId.ToString, _
                eFieldName.ApplicationName.ToString, _
                eFieldName.Description.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                AppId, _
                AppName, _
                AppDesc)

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ApplicationDelete(AppId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.ApplicationId.ToString, AppId.ToString)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Extra Functions"

        Public Shared Function ApplicationCount(ProviderConnectionString As String) As Integer
            Dim MyStr As String = MyCmd.CmdCount(TableName, , ProviderConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Related Fields (ApplicationId,ApplicationName,Description)
        ''' </summary>
        Public Shared Function ApplicationList(ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.ApplicationId.ToString, _
                eFieldName.ApplicationName.ToString, _
                eFieldName.Description.ToString)

            Dim Other As String = OrderBy(eFieldName.ApplicationName.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFields, , Other, ProviderConnectionString)
        End Function

#End Region
    End Class

End Namespace


