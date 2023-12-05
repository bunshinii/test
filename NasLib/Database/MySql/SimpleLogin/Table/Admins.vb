Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.SimpleLogin.Table

    ''' <summary>
    ''' This is a table base class base on table 'admins'
    ''' </summary>
    Public Class Admins

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "admins"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            username
        End Enum

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(Username As String, LoginConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, LoginConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(LoginConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , LoginConnectionString)
        End Function

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Admins Column(username)
        ''' </summary>
        Public Shared Function GetAllUsers(LoginConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.username.ToString _
                )

            'Paging
            Dim Other As String = OrderBy(eFieldName.username.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, LoginConnectionString)
        End Function


        ''' <summary>
        ''' Geat All Admins with paging. Column(username)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, LoginConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.username.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.username.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, LoginConnectionString)
        End Function

#End Region

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function AdminAdd(Username As String, LoginConnectionString As String) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.username.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Username _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, LoginConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function AdminDelete(Username As String, LoginConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
            Return MyCmd.CmdDelete(TableName, MyCriteria, LoginConnectionString)
        End Function

#End Region

#End Region

#Region "Special Functions"

        ''' <summary>
        ''' Check if is admin
        ''' </summary>
        Public Shared Function IsAdmin(Username As String, LoginConnectionString As String) As Boolean
            Return IsExisted(Username, LoginConnectionString)
        End Function

#End Region

    End Class

End Namespace


