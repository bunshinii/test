Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.RdmsLog

    Module RdmsLog
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "rdms_log"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            ip_address      'Index
            officerId
            logText
            date_
            isRead
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(id_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(IpAddress As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.ip_address.ToString, IpAddress)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function LogAdd(ip_address As String, officerId As String, logText As String) As Integer
            Dim MyFieldsName As String = FieldNames(
                eFieldName.ip_address.ToString,
                eFieldName.officerId.ToString,
                eFieldName.logText.ToString,
                eFieldName.date_.ToString
                )

            Dim MyFieldsValue As String = FieldValues(
                ip_address,
                officerId,
                logText,
                Format(Now, "yyy-MM-dd HH:mm:ss")
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function LogDelete(MediumId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, MediumId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        Public Function GetAllLogs() As DataTable
            Dim _FieldName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.ip_address.ToString,
                eFieldName.officerId.ToString,
                eFieldName.logText.ToString,
                eFieldName.date_.ToString,
                eFieldName.isRead.ToString)

            Dim MyOrderBy As String = OrderBy(eFieldName.date_.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , MyOrderBy, MyAppConnectionString)
        End Function

        Public Function GetLogsByIP(IpAddress As String) As DataTable
            Dim _FieldName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.ip_address.ToString,
                eFieldName.officerId.ToString,
                eFieldName.logText.ToString,
                eFieldName.date_.ToString,
                eFieldName.isRead.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.ip_address.ToString, IpAddress)
            Dim MyOrderBy As String = OrderBy(eFieldName.date_.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

        Public Function GetLogsOfficerId(Officerid As String) As DataTable
            Dim _FieldName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.ip_address.ToString,
                eFieldName.officerId.ToString,
                eFieldName.logText.ToString,
                eFieldName.date_.ToString,
                eFieldName.isRead.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.officerId.ToString, Officerid)
            Dim MyOrderBy As String = OrderBy(eFieldName.date_.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

#End Region


    End Module

End Namespace


