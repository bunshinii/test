Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'TableName'
    ''' </summary>
    Public Class zTemplate

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_aspnet_users"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            name
            applicationId
            isAnonymous
            lastActivityDate
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional                               '<-------------------------------------- Optional
        Private Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.Users.UserId(Username, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(Username As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "String"

        Public Shared Property Username(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Username(ByVal UsrName As String, ProviderConnectionString As String) As String
            Get
                Return Username(UserId(UsrName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Username(UserId(UsrName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Integer"

        Public Shared Property ApplicationID(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.applicationId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ApplicationID(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return ApplicationID(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                ApplicationID(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "DateTime"

        Public Shared Property lastActivityDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.lastActivityDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property lastActivityDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return lastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                lastActivityDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Boolean"

        Public Shared Property IsAnonymous(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return CBool(MyStr)
            End Get
            Set(value As Boolean)

                Dim MyFieldName As String = FieldName(eFieldName.isAnonymous)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As Integer = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsAnonymous(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Return IsAnonymous(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Boolean)
                IsAnonymous(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(Id As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), Id)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_Name As String, ProviderConnectionString As String) As Boolean
            Return IsExisted(UserId(_Name, ProviderConnectionString), ProviderConnectionString)
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Add New User. Will return User ID
        ''' </summary>
        Public Shared Function UserAdd(Username As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = _
                FieldName(eFieldName.applicationId) & "," & _
                FieldName(eFieldName.name) & "," & _
                FieldName(eFieldName.isAnonymous) & "," & _
                FieldName(eFieldName.lastActivityDate)

            Dim MyFieldsValue As String = _
                FieldValue(1) & "," & _
                FieldValue(Username) & "," & _
                FieldValue(False) & "," & _
                FieldValue(Now)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function UserAdd(ApplicationId As Integer, Username As String, IsAnonymous As Boolean, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = _
                FieldName(eFieldName.applicationId) & "," & _
                FieldName(eFieldName.name) & "," & _
                FieldName(eFieldName.isAnonymous) & "," & _
                FieldName(eFieldName.lastActivityDate)

            Dim MyFieldsValue As String = _
                FieldValue(ApplicationId) & "," & _
                FieldValue(Username) & "," & _
                FieldValue(IsAnonymous) & "," & _
                FieldValue(Now)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function UserDelete(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function UserDelete(Username As String, ProviderConnectionString As String) As Boolean
            Return UserDelete(Id(Username, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


