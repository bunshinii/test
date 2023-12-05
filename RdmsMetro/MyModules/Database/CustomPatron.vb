Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.CustomPatron

    Module CustomPatron
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "custom_patron"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            patronId
            fullname
        End Enum


#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Function Id(PatronId_ As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, PatronId_)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "patronId"

        Public Property PatronId(ByVal id_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property PatronId(ByVal PatronId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, PatronId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, PatronId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "fullname"

        Public Property Fullname(ByVal id_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property Fullname(ByVal PatronId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, PatronId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.fullname.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, PatronId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(id_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, id_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(PatronId_ As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.patronId.ToString, PatronId_) _
            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function Count(Patronid_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.patronId.ToString, Patronid_)

            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function PatronAdd(PatronId_ As String, Fullname_ As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.patronId.ToString, _
                eFieldName.fullname.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                PatronId_, _
                Fullname_ _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function PatronDelete(Id_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, Id_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function PatronDelete(PatronId_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, PatronId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 3 columns (id, patronId, fullname)
        ''' </summary>
        Public Function GetAllPatrons() As DataTable
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.patronId.ToString, _
                eFieldName.fullname.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.fullname.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFieldsName, , Other, MyAppConnectionString)
        End Function

#End Region




    End Module

End Namespace


