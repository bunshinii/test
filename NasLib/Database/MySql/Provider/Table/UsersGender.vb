﻿Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_gender'
    ''' </summary>
    Public Class UsersGender

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_gender"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id      'Primary
            gender
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional                               '<-------------------------------------- Optional
        Private Shared Function GenderId(Gender As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.UsersGender.GenderId(Gender, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(Gender As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.gender), Gender)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "gender"

        ''' <summary>
        ''' Get / Set GenderName by Gender ID
        ''' </summary>
        Public Shared Property Gender(ByVal GenderId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.gender)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GenderId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.gender)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GenderId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GenderName by GenderName
        ''' </summary>
        Public Shared Property Gender(ByVal GenderName As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.gender)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.gender), GenderName)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.gender)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.gender), GenderName)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(GenderId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GenderId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(GenderName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.gender), GenderName)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function GenderAdd(GenderName As String, ProviderConnectionString As String) As Integer
            Dim MyFieldsName As String = _
                FieldName(eFieldName.gender)

            Dim MyFieldsValue As String = _
                FieldValue(GenderName)

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function GenderDelete(GenderId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), GenderId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GenderDelete(GenderName As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.gender), GenderName)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Data Table"

        ''' <summary>
        ''' Fields(id,gender)
        ''' </summary>
        Public Shared Function GetAllGenders(ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames("id", "gender")
            Dim Other As String = OrderBy("order_")

            Return MyCmd.CmdSelectTable(TableName, MyFields, , Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


