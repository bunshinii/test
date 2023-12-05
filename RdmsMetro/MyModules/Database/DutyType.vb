Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.DutyType

    Module DutyType
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "duty_type"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            duty_type
            note
            bgColor
            foreColor
            order_
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Function Id(DutyType_ As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.duty_type.ToString, DutyType_)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "duty_type"

        Public Property DutyTypeName(ByVal DutyTypeId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.duty_type.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.duty_type.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "note"

        Public Property DutyNote(ByVal DutyTypeId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.note.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.note.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "bgColor"

        ''' <summary>
        ''' Get Set Background Color As HTML Code
        ''' </summary>
        Public Property BackgroundColor(ByVal DutyTypeId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.bgColor.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.bgColor.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "bgColor"

        ''' <summary>
        ''' Get Set Fore Color As HTML Code
        ''' </summary>
        Public Property ForeColor(ByVal DutyTypeId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.foreColor.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.foreColor.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "order_"

        Public Property TypeOrder(ByVal DutyTypeId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.order_.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.order_.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region


#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(DutyTypeId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(TypeName_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.duty_type.ToString, TypeName_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function DutyTypeAdd(TypeName_ As String, Note As String, BgColor_ As String, ForeColor_ As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.duty_type.ToString, _
                eFieldName.note.ToString, _
                eFieldName.bgColor.ToString, _
                eFieldName.foreColor.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                TypeName_, _
                Note, _
                BgColor_, _
                ForeColor_ _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function DutyTypeDelete(DutyTypeId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyTypeId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function DutyTypeDelete(DutyTypeName_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.duty_type.ToString, DutyTypeName_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 5 columns (id, duty_type, note, bgColor, foreColor)
        ''' </summary>
        Public Function GetAllDutyTypes() As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.duty_type.ToString, _
                eFieldName.note.ToString, _
                eFieldName.bgColor.ToString, _
                eFieldName.foreColor.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.order_.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, MyAppConnectionString)
        End Function

#End Region

    End Module

End Namespace


