Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Logger.v1.Table

    ''' <summary>
    ''' This is a table base class base on table 'stat_admin'
    ''' </summary>
    Public Class StatAdmin

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stat_admin"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            app_id
            username
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function AssignUserApp(Username As String, AppGuid As Guid, StatConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.username.ToString, _
                eFieldName.app_id.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                Username, _
                AppGuid)

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, StatConnectionString)
        End Function

        Public Shared Function AssignUserApp(Username As String, AppName As String, StatConnectionString As String) As Integer
            Dim AppGuid As Guid = MySql.Logger.v1.Table.StatApplications.Id(AppName, StatConnectionString)

            Return AssignUserApp(Username, AppGuid, StatConnectionString)
        End Function
#End Region

#Region "Delete"

        Public Shared Function ClearUserApps(Username As String, StatConnectionString As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.username.ToString, Username.ToString) _
                )

            Return MyCmd.CmdDelete(TableName, MyCriteria, StatConnectionString)
        End Function

        Public Shared Function UnAssignUserApp(Username As String, AppGuid As Guid, StatConnectionString As String) As Integer
            Dim MyFieldsName As String = _
                FieldName(eFieldName.app_id) & "," & _
                FieldName(eFieldName.username)

            Dim MyCriteria As String = _
                Criteria(FieldName(eFieldName.app_id), Username) & " AND " & _
                Criteria(FieldName(eFieldName.username), AppGuid)

            Return MyCmd.CmdDelete(TableName, MyCriteria, StatConnectionString)
        End Function


        Public Shared Function UnAssignUserApp(UserName As String, AppName As String, StatConnectionString As String) As Integer
            Dim AppGuid As Guid = MySql.Logger.v1.Table.StatApplications.Id(AppName, StatConnectionString)
            Return UnAssignUserApp(UserName, AppGuid, StatConnectionString)
        End Function


        Public Shared Sub AppDelete(AppGuid As Guid, StatConnectionString As String)
            Dim _Criteria As String = Criteria(eFieldName.app_id.ToString, AppGuid)
            MyCmd.CmdDelete(TableName, _Criteria, StatConnectionString)
        End Sub

#End Region

#End Region

#Region "Extra Functions"

#Region "Checkers"

        Public Shared Function IsUserInApp(Username As String, AppGuid As Guid, StatConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.username), Username) & " AND " & Criteria(eFieldName.app_id.ToString, AppGuid)
            Return MyCmd.CmdExisted(TableName, MyCriteria, StatConnectionString)
        End Function

        Public Shared Function IsUserInApp(Username As String, AppName As String, StatConnectionString As String) As Boolean
            Dim AppGuid As Guid = MySql.Logger.v1.Table.StatApplications.Id(AppName, StatConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username) & " AND " & Criteria(eFieldName.app_id.ToString, AppGuid)
            Return MyCmd.CmdExisted(TableName, MyCriteria, StatConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


