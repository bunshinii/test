Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.RdmsSnippets

    Module RdmsSnippets
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "rdms_snippets"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            officer
            snippet
            type
            order_
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"


#Region "officer"

        Public Property Officer(ByVal SnippetId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "snippet"

        Public Property Snippet(ByVal SnippetId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.snippet.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.snippet.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "type"

        Public Property Type(ByVal SnippetId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.type.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.type.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "order"

        Public Property Order(ByVal SnippetId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.order_.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.order_.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(SnippetId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function Count(Officer_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.officer.ToString, Officer_)
            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function MaxOrder(Officer_ As String) As Integer
            Dim MyFieldsName As String = eFieldName.order_.ToString
            Dim MyCriteria As String = Criteria(eFieldName.officer.ToString, Officer_)

            Return MyCmd.CmdMax(TableName, MyFieldsName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function SnippetAdd(Officer_ As String, Snippet_ As String, SnippetType_ As String) As Integer
            Dim MyOrder As Integer = MaxOrder(Officer_) + 1

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.officer.ToString, _
                eFieldName.snippet.ToString, _
                eFieldName.type.ToString, _
                eFieldName.order_.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Officer_, _
                Snippet_, _
                SnippetType_, _
                MyOrder _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function SnippetDelete(SnippetId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SnippetId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function SnippetDelete(Officer_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.officer.ToString, Officer_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 4 columns (id, officer, snippet, order_)
        ''' </summary>
        Public Function GetAllSnippets() As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.officer.ToString, _
                eFieldName.snippet.ToString, _
                eFieldName.order_.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.order_.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' 4 columns (id, officer, snippet, order_)
        ''' </summary>
        Public Function GetAllSnippets(Officer_ As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.officer.ToString, _
                eFieldName.snippet.ToString, _
                eFieldName.order_.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.officer.ToString, Officer_)
            Dim Other As String = OrderBy(eFieldName.order_.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' 4 columns (id, officer, snippet, order_)
        ''' </summary>
        ''' <param name="SnippetType">"question" or "answer"</param>
        Public Function GetAllSnippets(Officer_ As String, SnippetType As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.officer.ToString, _
                eFieldName.snippet.ToString, _
                eFieldName.order_.ToString _
                )

            Dim MyCriteria As String = CriteriasAND(Criteria(eFieldName.officer.ToString, Officer_), Criteria(eFieldName.type.ToString, SnippetType))
            Dim Other As String = OrderBy(eFieldName.order_.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, MyAppConnectionString)
        End Function

        Public Function GetAllSnippets(Officer_ As String, SnippetType As String, _FieldNames() As String) As DataTable
            Dim _FieldName As String = FieldNames(_FieldNames)

            Dim MyCriteria As String = CriteriasAND(Criteria(eFieldName.officer.ToString, Officer_), Criteria(eFieldName.type.ToString, SnippetType))
            Dim Other As String = OrderBy(eFieldName.order_.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, MyAppConnectionString)
        End Function

#End Region


    End Module

End Namespace


