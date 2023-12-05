Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.SimpleLogin.Table

    ''' <summary>
    ''' This is a table base class base on table 'users'
    ''' </summary>
    Public Class Users

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            id
            username
            password
            fullname
            program
            passport
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "password"

        Public Shared Property Password(ByVal Username As String, LoginConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.password.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , LoginConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.password.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, LoginConnectionString)
            End Set
        End Property

#End Region

#Region "fullname"

        Public Shared Property Fullname(ByVal Username As String, LoginConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , LoginConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, LoginConnectionString)
            End Set
        End Property

        Public Shared Property Program(ByVal Username As String, LoginConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.program.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , LoginConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.program.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, LoginConnectionString)
            End Set
        End Property

        Public Shared Property Passport(ByVal Username As String, LoginConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.passport.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , LoginConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.passport.ToString
                Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, LoginConnectionString)
            End Set
        End Property

#End Region

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

#Region "Table Operation"

#Region "Insert"

        Public Shared Function UserAdd(Username As String, Passport As String, Fullname As String, Program As String, LoginConnectionString As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.username.ToString, _
                eFieldName.password.ToString, _
                eFieldName.passport.ToString, _
                eFieldName.fullname.ToString, _
                eFieldName.program.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Username, _
                Passport, _
                Passport, _
                Fullname, _
                Program _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, LoginConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function UserDelete(Username As String, LoginConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.username.ToString, Username)
            Return MyCmd.CmdDelete(TableName, MyCriteria, LoginConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Usernames. Column(username)
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
        ''' Geat All Usernames with paging. Column(username)
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

#Region "Special Functions"

        ''' <summary>
        ''' Check if username and password matched
        ''' </summary>
        Public Shared Function IsValidUser(Username As String, Password As String, LoginConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria("username", Username), _
                Criteria("password", Password, True) _
                )

            Return MyCmd.CmdExisted(TableName, MyCriteria, LoginConnectionString)
        End Function


#End Region

    End Class

End Namespace


