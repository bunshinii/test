Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.Notification

    Module Notification
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "notification"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            recieverId
            messageTitle
            messageText
            messageDate
            isRead
        End Enum


#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "recieverId"

        Public Property SenderId(ByVal NoteId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.recieverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.recieverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "MessageTitle"

        Public Property MessageTitle(ByVal NoteId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.messageTitle.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.messageTitle.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "Message"

        Public Property MessageText(ByVal NoteId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.messageText.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.messageText.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "messageDate"

        Public Property MessageDate(ByVal NoteId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.messageDate.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.messageDate.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "isRead"

        Public Property IsRead(ByVal NoteId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isRead.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isRead.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(NoteId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(ReceiverId As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.recieverId.ToString, ReceiverId), _
                Criteria(eFieldName.isRead.ToString, False)
            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function Count(ReceiverId_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.recieverId.ToString, ReceiverId_)

            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function CountUnread() As Integer
            Dim MyCriteria As String = Criteria(eFieldName.isRead.ToString, False)

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function CountUnread(ReceiverId_ As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.recieverId.ToString, ReceiverId_), _
                Criteria(eFieldName.isRead.ToString, False) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function MarkAllAsRead(ReceiverId_ As String) As Boolean
            Dim MyFieldName As String = FieldNames(eFieldName.isRead.ToString)
            Dim MyFieldValue As String = FieldValue(1)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.recieverId.ToString, ReceiverId_), _
                Criteria(eFieldName.isRead.ToString, False) _
                )

            Return MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function NoteAdd(RecieverId_ As String, MessageTitle As String, MessageText As String) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.recieverId.ToString, _
                eFieldName.messageTitle.ToString, _
                eFieldName.messageText.ToString, _
                eFieldName.messageDate.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                RecieverId_, _
                MessageTitle, _
                MessageText, _
                Now _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function NoteDelete(NoteId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, NoteId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 5 columns (id, recieverId, messageTitle, messageText, messageDate)
        ''' </summary>
        Public Function GetAllNotes(ReceiverId_ As String) As DataTable
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.recieverId.ToString, _
                eFieldName.messageTitle.ToString, _
                eFieldName.messageText.ToString, _
                eFieldName.messageDate.ToString _
                )

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.recieverId.ToString, ReceiverId_), _
                Criteria(eFieldName.isRead.ToString, False) _
                )

            Dim Other As String = OrderByLimit(eFieldName.messageDate.ToString, False, 100)

            Return MyCmd.CmdSelectTable(TableName, MyFieldsName, MyCriteria, Other, MyAppConnectionString)
        End Function

#End Region




    End Module

End Namespace


