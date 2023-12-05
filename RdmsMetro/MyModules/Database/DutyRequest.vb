Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.DutyRequest

    Module DutyRequest
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "duty_request"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            dutyId
            senderId
            receiverId
            req_date
            duty_date
            accepted
            rejected
            message
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"


#Region "dutyId"

        Public Property MediumId(ByVal RequestId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.dutyId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.dutyId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "requestedId"

        Public Property SenderId(ByVal RequestId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.senderId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.senderId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SenderIdByDutyId(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.senderId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.senderId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sendToId"

        Public Property ReceiverId(ByVal RequestId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.receiverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.receiverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property ReceiverIdByDutyId(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.receiverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.receiverId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "req_date"

        Public Property RequestDate(ByVal RequestId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.req_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.req_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property RequestDateByDutyId(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.req_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.req_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(CDate(value))

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "duty_date"

        Public Property DutyDate(ByVal RequestId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.duty_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.duty_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "accepted"

        Public Property Accepted(ByVal RequestId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.accepted.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.accepted.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "rejected"

        Public Property Rejected(ByVal RequestId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.rejected.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.rejected.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property RejectedByDutyId(ByVal DutyId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.rejected.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.rejected.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "Message"

        Public Property Message(ByVal RequestId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.message.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.message.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property MessageByDutyId(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.message.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.message.ToString
                Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(RequestId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(ReceiverId As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.receiverId.ToString, ReceiverId), _
                CriteriaGreaterDate(eFieldName.duty_date.ToString, Now.AddDays(-1)), _
                Criteria(eFieldName.rejected.ToString, False) _
                 )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(ReceiverId As String, DutyId As Integer) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.dutyId.ToString, DutyId), _
                Criteria(eFieldName.receiverId.ToString, ReceiverId) _
            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsDutyExisted(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsDutyRequested(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.dutyId.ToString, DutyId_))
            'Criteria(eFieldName.rejected.ToString, False) _
            ')

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsDutyRejected(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.dutyId.ToString, DutyId_), _
                Criteria(eFieldName.rejected.ToString, True) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function CountRequest(RequestOfficer_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.senderId.ToString, RequestOfficer_)

            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function CountSend(SentOfficer_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.receiverId.ToString, SentOfficer_)

            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function RequestAdd(DutyId_ As Integer, RequestorId_ As String, RecieverId_ As String, DutyDate_ As Date) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.dutyId.ToString, _
                eFieldName.senderId.ToString, _
                eFieldName.receiverId.ToString, _
                eFieldName.req_date.ToString, _
                eFieldName.duty_date.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                DutyId_, _
                RequestorId_, _
                RecieverId_, _
                Now, _
                DutyDate_
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function RequestDelete(RequestId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, RequestId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function RequestDeleteByDutyId(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.dutyId.ToString, DutyId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 5 columns (id, dutyId, requestedId, sendToId, req_date, duty_date, accepted, rejected)
        ''' </summary>
        Public Function GetAllRequest() As DataTable
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.dutyId.ToString, _
                eFieldName.senderId.ToString, _
                eFieldName.receiverId.ToString, _
                eFieldName.req_date.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.accepted.ToString, _
                eFieldName.rejected.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.duty_date.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, MyFieldsName, , Other, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' 5 columns ('id, dutyId, senderId, receiverId, req_date, duty_date, accepted, rejected)
        ''' </summary>
        Public Function GetAllRequestReceivedFuture(RecieverId_ As String) As DataTable
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.dutyId.ToString, _
                eFieldName.senderId.ToString, _
                eFieldName.receiverId.ToString, _
                eFieldName.req_date.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.accepted.ToString, _
                eFieldName.rejected.ToString _
                )

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.receiverId.ToString, RecieverId_), _
                CriteriaGreaterDate(eFieldName.duty_date.ToString, Now), _
                Criteria(eFieldName.rejected.ToString, False) _
                )

            Dim Other As String = OrderByLimit(eFieldName.duty_date.ToString, True, 50)

            Return MyCmd.CmdSelectTable(TableName, MyFieldsName, MyCriteria, Other, MyAppConnectionString)
        End Function

        Public Function CountAllRequestReceivedFuture(RecieverId_ As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.receiverId.ToString, RecieverId_), _
                CriteriaGreaterDate(eFieldName.duty_date.ToString, Now), _
                Criteria(eFieldName.rejected.ToString, False) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

    End Module

End Namespace


