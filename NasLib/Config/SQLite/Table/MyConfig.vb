Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Config.SQLite.Table

    ''' <summary>
    ''' This is a table base class base on table 'aspnet_Applications'
    ''' </summary>
    Public Class MyConfig

        Private Shared MyCmd As New Database.SQLite.Sql.Commands

#Region "SQLite Table Setting"
        'Each Table Base Class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Table Fields Properties" Region according to Table Fields

        'Dont forget to Imports NasLib.SQLite.Sql.Simplifier

        Private Shared Function TableName() As String
            Return "my_config"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            my_key
            my_value
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "my_value"

        ''' <summary>
        ''' Get / Set KeyValue by Keyname
        ''' </summary>
        Public Shared Property KeyValue(ByVal Keyname As String, SQLiteConfigConnectionString As String) As String
            Get
                If Not IsExisted(Keyname, SQLiteConfigConnectionString) Then KeyAdd(Keyname, "", SQLiteConfigConnectionString)

                Dim MyFieldName As String = eFieldName.my_value.ToString
                Dim MyCriteria As String = Criteria(eFieldName.my_key.ToString, Keyname)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , SQLiteConfigConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                If Not IsExisted(Keyname, SQLiteConfigConnectionString) Then
                    KeyAdd(Keyname, value, SQLiteConfigConnectionString)
                Else

                    Dim MyFieldName As String = FieldNames( _
                                        eFieldName.my_value.ToString)

                    Dim MyFieldValue As String = FieldValues( _
                        value)

                    Dim MyCriteria As String = Criteria(eFieldName.my_key.ToString, Keyname)

                    MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, SQLiteConfigConnectionString)

                End If
            End Set
        End Property

#End Region


#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(KeyName As String, SQLiteConfigConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.my_key.ToString, KeyName.ToString)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, SQLiteConfigConnectionString)
            Return MyBool
        End Function


        Public Shared Function Count(SQLiteConfigConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , SQLiteConfigConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New Application. Will return Application ID
        ''' </summary>
        Public Shared Function KeyAdd(KeyName As String, KeyValue As String, SQLiteConfigConnectionString As String) As Boolean

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.my_key.ToString, _
                eFieldName.my_value.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                KeyName, _
                KeyValue _
                )

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, SQLiteConfigConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function KeyDelete(KeyName As String, SQLiteConfigConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.my_key.ToString, KeyName)
            Return MyCmd.CmdDelete(TableName, MyCriteria, SQLiteConfigConnectionString)
        End Function

#End Region

#End Region

#Region "Extra Functions"

        Public Shared Function KeyCount(SQLiteConfigConnectionString As String) As Integer
            Dim MyStr As String = MyCmd.CmdCount(TableName, , SQLiteConfigConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Related Fields (my_key,my_value)
        ''' </summary>
        Public Shared Function KeyList(SQLiteConfigConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.my_key.ToString, _
                eFieldName.my_value.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.my_key.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFields, , Other, SQLiteConfigConnectionString)
        End Function

#End Region
    End Class

End Namespace


