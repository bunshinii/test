Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.RdmsQuestions

    Module RdmsQuestions
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "rdms_questions"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id
            patronId
            mediumId
            sub_od
            sub_dc
            sub_it
            sub_op
            sub_lrc
            sub_rc
            sub_fs
            sub_vp
            sub_ja
            sub_gt
            sub_etc
            enq_qr
            enq_rr
            enq_st
            enq_ag
            enq_etc
            question
            answer
            timeStart
            timeEnd
            duration
            isKiv
            isFinished
            officer
            branchId
            satelliteId
            departmentId
            divisionId
            unitId
            studFacultyCode
            studProgramCode
            studCampusCode
            studLevelCode
            studModeCode
            stafDeptCode
            stafPosCode
            stafTypeCode
            isCustom
            sessionId
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "Id"

        Public Property Id(SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)

            End Set
        End Property

        Public Property QuestionId(SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)

            End Set
        End Property

#End Region

#Region "PatronId"

        Public Property PatronId(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property PatronId(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "mediumId"

        Public Property MediumId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.mediumId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property MediumId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.mediumId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.patronId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_od"

        Public Property SubjectOnlineDatabase(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_od.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_od.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectOnlineDatabase(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_od.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_od.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_dc"

        Public Property SubjectDigitalCollection(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_dc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_dc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectDigitalCollection(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_dc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_dc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_it"

        Public Property SubjectInternet(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_it.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_it.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectInternet(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_it.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_it.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_op"

        Public Property SubjectOpac(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_op.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_op.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectOpac(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_op.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_op.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_lrc"

        Public Property SubjectLrc(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_lrc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_lrc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectLrc(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_lrc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_lrc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_rc"

        Public Property SubjectRc(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_rc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_rc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectRc(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_rc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_rc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_fs"

        Public Property SubjectFs(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_fs.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_fs.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectFs(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_fs.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_fs.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_vp"

        Public Property SubjectVp(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_vp.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_vp.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectVp(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_vp.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_vp.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region


#Region "sub_ja"

        Public Property SubjectJa(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_ja.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_ja.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectJa(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_ja.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_ja.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_gt"

        Public Property SubjectGt(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_gt.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_gt.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectGt(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_gt.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_gt.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sub_etc"

        Public Property SubjectOther(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SubjectOther(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.sub_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.sub_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "enq_qr"

        Public Property EnquiryQuickReference(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_qr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_qr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property EnquiryQuickReference(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_qr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_qr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "enq_rr"

        Public Property EnquiryResearchReference(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_rr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_rr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property EnquiryResearchReference(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_rr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_rr.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "enq_st"

        Public Property EnquirySearchTechnique(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_st.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_st.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property EnquirySearchTechnique(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_st.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_st.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "enq_ag"

        Public Property EnquiryAdvisoryGuidance(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_ag.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_ag.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property EnquiryAdvisoryGuidance(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_ag.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_ag.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "enq_etc"

        Public Property EnquiryOther(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property EnquiryOther(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.enq_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.enq_etc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "question"

        Public Property Question(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.question.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return HttpUtility.HtmlDecode(MyStr)
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.question.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(HttpUtility.HtmlEncode(value))

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property Question(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.question.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return HttpUtility.HtmlDecode(MyStr)
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.question.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(HttpUtility.HtmlEncode(value))

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "answer"

        Public Property Answer(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.answer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return HttpUtility.HtmlDecode(MyStr)
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.answer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(HttpUtility.HtmlEncode(value))

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property Answer(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.answer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return HttpUtility.HtmlDecode(MyStr)
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.answer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(HttpUtility.HtmlEncode(value))

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "timestart"

        Public Property TimeStart(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.timeStart.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.timeStart.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property TimeStart(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.timeStart.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.timeStart.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "timeEnd"

        Public Property TimeEnd(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.timeEnd.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.timeEnd.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property TimeEnd(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.timeEnd.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.timeEnd.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "duration"

        Public Property Duration(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.duration.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.duration.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property Duration(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.duration.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.duration.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "isKiv"

        Public Property IsKiv(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isKiv.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isKiv.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property IsKiv(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isKiv.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isKiv.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "isFinished"

        Public Property IsFinished(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isFinished.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isFinished.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property IsFinished(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isFinished.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isFinished.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "officer"

        Public Property Officer(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property Officer(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.officer.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "branchId"

        Public Property BranchId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property BranchId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "satelliteId"

        Public Property SatelliteId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SatelliteId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "departmentId"

        Public Property DepartmentId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.departmentId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.departmentId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property DepartmentId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.departmentId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.departmentId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "divisionId"

        Public Property DivisionId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.divisionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.divisionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property DivisionId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.divisionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.divisionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "unitId"

        Public Property UnitId(ByVal QuestionId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.unitId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.unitId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property UnitId(ByVal SessionId_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.unitId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.unitId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "studFacultyCode"

        Public Property StudentFacultyCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.studFacultyCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studFacultyCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StudentFacultyCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.studFacultyCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studFacultyCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "studProgramCode"

        Public Property StudentProgramCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.studProgramCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studProgramCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StudentProgramCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.studProgramCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studProgramCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "studCampusCode"

        Public Property StudentCampusCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.studCampusCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studProgramCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StudentCampusCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.studCampusCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studCampusCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "studLevelCode"

        Public Property StudentLevelCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.studLevelCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studLevelCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StudentLevelCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.studLevelCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studLevelCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "studModeCode"

        Public Property StudentModeCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.studModeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studModeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StudentModeCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.studModeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studModeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "stafDeptCode"

        Public Property StaffDepartmentCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.stafDeptCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.studModeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StaffDepartmentCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.stafDeptCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.stafDeptCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "stafDeptCode"

        Public Property StaffPositionCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.stafPosCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.stafPosCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StaffPositionCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.stafPosCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.stafPosCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "stafDeptCode"

        Public Property StaffTypeCode(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.stafTypeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.stafTypeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property StaffTypeCode(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.stafTypeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.stafTypeCode.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "isCustom"

        Public Property IsCustom(ByVal QuestionId_ As Integer) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isCustom.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isCustom.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property IsCustom(ByVal SessionId_ As String) As Boolean
            Get
                Dim MyFieldName As String = eFieldName.isCustom.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = eFieldName.isCustom.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "sessionId"

        Public Property SessionId(ByVal QuestionId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.sessionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.sessionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property SessionId(ByVal SessionId_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.sessionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.sessionId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(QuestionId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function IsExisted(SessionId_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function GetMaxYear() As Integer
            Dim ReturnValue As Integer = Year(Now.AddYears(1))
            Dim TheDate As String = MyCmd.CmdMax(TableName, eFieldName.timeStart.ToString, , MyAppConnectionString)

            If IsDate(TheDate) Then ReturnValue = Year(CDate(TheDate))
            Return ReturnValue
        End Function

        Public Function GetMinYear() As Integer
            Dim ReturnValue As Integer = Year(Now.AddYears(-5))
            Dim TheYear As String = MyCmd.CmdMin(TableName, FunctionYear(eFieldName.timeStart.ToString), , MyAppConnectionString)

            If IsNumeric(TheYear) Then ReturnValue = TheYear
            Return ReturnValue
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function QuestionAdd(patronId As String, mediumId As Integer, sub_od As Boolean, sub_dc As Boolean, sub_it As Boolean, sub_op As Boolean, sub_lrc As Boolean, sub_rc As Boolean, sub_fs As Boolean, sub_vp As Boolean, sub_ja As Boolean, sub_gt As Boolean, sub_etc As Boolean, enq_qr As Boolean, enq_rr As Boolean, enq_st As Boolean, enq_ag As Boolean, enq_etc As Boolean, question As String, answer As String, timeStart As Date, timeEnd As Date, isKiv As Boolean, isFinished As Boolean, officer As String, branchId As Integer, satelliteId As Integer, departmentId As Integer, divisionId As Integer, unitId As Integer, studFacultyCode As String, studProgramCode As String, studCampusCode As String, studLevelCode As String, studModeCode As String, stafDeptCode As String, stafPosCode As String, stafTypeCode As String, sessionId As String) As Integer
            Dim DurationSec As Integer = timeEnd.Subtract(timeStart).TotalSeconds
            Dim DurationSpan As New TimeSpan(0, 0, DurationSec)
            Dim DurationStr As String = String.Format("{0}:{1}:{2}", CInt(DurationSpan.TotalHours), DurationSpan.Minutes, DurationSpan.Seconds)

            Dim MyFieldsName As String = FieldNames(
                eFieldName.patronId.ToString,
                eFieldName.mediumId.ToString,
                eFieldName.sub_od.ToString,
                eFieldName.sub_dc.ToString,
                eFieldName.sub_it.ToString,
                eFieldName.sub_op.ToString,
                eFieldName.sub_lrc.ToString,
                eFieldName.sub_rc.ToString,
                eFieldName.sub_fs.ToString,
                eFieldName.sub_vp.ToString,
                eFieldName.sub_ja.ToString,
                eFieldName.sub_gt.ToString,
                eFieldName.sub_etc.ToString,
                eFieldName.enq_qr.ToString,
                eFieldName.enq_rr.ToString,
                eFieldName.enq_st.ToString,
                eFieldName.enq_ag.ToString,
                eFieldName.enq_etc.ToString,
                eFieldName.question.ToString,
                eFieldName.answer.ToString,
                eFieldName.timeStart.ToString,
                eFieldName.timeEnd.ToString,
                eFieldName.duration.ToString,
                eFieldName.isKiv.ToString,
                eFieldName.isFinished.ToString,
                eFieldName.officer.ToString,
                eFieldName.branchId.ToString,
                eFieldName.satelliteId.ToString,
                eFieldName.departmentId.ToString,
                eFieldName.divisionId.ToString,
                eFieldName.unitId.ToString,
                eFieldName.studFacultyCode.ToString,
                eFieldName.studProgramCode.ToString,
                eFieldName.studCampusCode.ToString,
                eFieldName.studLevelCode.ToString,
                eFieldName.studModeCode.ToString,
                eFieldName.stafDeptCode.ToString,
                eFieldName.stafPosCode.ToString,
                eFieldName.stafTypeCode.ToString,
                eFieldName.sessionId.ToString
                )

            Dim MyFieldsValue As String = FieldValues(
                patronId,
                mediumId,
                sub_od,
                sub_dc,
                sub_it,
                sub_op,
                sub_lrc,
                sub_rc,
                sub_fs,
                sub_vp,
                sub_ja,
                sub_gt,
                sub_etc,
                enq_qr,
                enq_rr,
                enq_st,
                enq_ag,
                enq_etc,
                NasLib.Functions.Web.Html.Encode(question),
                NasLib.Functions.Web.Html.Encode(answer),
                timeStart,
                timeEnd,
                DurationStr,
                isKiv,
                isFinished,
                officer,
                branchId,
                satelliteId,
                departmentId,
                divisionId,
                unitId,
                studFacultyCode,
                studProgramCode,
                studCampusCode,
                studLevelCode,
                studModeCode,
                stafDeptCode,
                stafPosCode,
                stafTypeCode,
                sessionId
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

        Public Function QuestionAddCustom(patronId As String, mediumId As Integer, sub_od As Boolean, sub_dc As Boolean, sub_it As Boolean, sub_op As Boolean, sub_lrc As Boolean, sub_rc As Boolean, sub_fs As Boolean, sub_vp As Boolean, sub_ja As Boolean, sub_gt As Boolean, sub_etc As Boolean, enq_qr As Boolean, enq_rr As Boolean, enq_st As Boolean, enq_ag As Boolean, enq_etc As Boolean, question As String, answer As String, timeStart As Date, timeEnd As Date, isKiv As Boolean, isFinished As Boolean, officer As String, branchId As Integer, satelliteId As Integer, departmentId As Integer, divisionId As Integer, unitId As Integer, studFacultyCode As String, studProgramCode As String, studCampusCode As String, studLevelCode As String, studModeCode As String, stafDeptCode As String, stafPosCode As String, stafTypeCode As String, sessionId As String) As Integer
            Dim DurationSec As Integer = timeEnd.Subtract(timeStart).TotalSeconds
            Dim DurationSpan As New TimeSpan(0, 0, DurationSec)
            Dim DurationStr As String = String.Format("{0}:{1}:{2}", CInt(DurationSpan.TotalHours), DurationSpan.Minutes, DurationSpan.Seconds)

            Dim MyFieldsName As String = FieldNames(
                eFieldName.patronId.ToString,
                eFieldName.mediumId.ToString,
                eFieldName.sub_od.ToString,
                eFieldName.sub_dc.ToString,
                eFieldName.sub_it.ToString,
                eFieldName.sub_op.ToString,
                eFieldName.sub_lrc.ToString,
                eFieldName.sub_fs.ToString,
                eFieldName.sub_vp.ToString,
                eFieldName.sub_ja.ToString,
                eFieldName.sub_gt.ToString,
                eFieldName.sub_rc.ToString,
                eFieldName.sub_etc.ToString,
                eFieldName.enq_qr.ToString,
                eFieldName.enq_rr.ToString,
                eFieldName.enq_st.ToString,
                eFieldName.enq_ag.ToString,
                eFieldName.enq_etc.ToString,
                eFieldName.question.ToString,
                eFieldName.answer.ToString,
                eFieldName.timeStart.ToString,
                eFieldName.timeEnd.ToString,
                eFieldName.duration.ToString,
                eFieldName.isKiv.ToString,
                eFieldName.isFinished.ToString,
                eFieldName.officer.ToString,
                eFieldName.branchId.ToString,
                eFieldName.satelliteId.ToString,
                eFieldName.departmentId.ToString,
                eFieldName.divisionId.ToString,
                eFieldName.unitId.ToString,
                eFieldName.studFacultyCode.ToString,
                eFieldName.studProgramCode.ToString,
                eFieldName.studCampusCode.ToString,
                eFieldName.studLevelCode.ToString,
                eFieldName.studModeCode.ToString,
                eFieldName.stafDeptCode.ToString,
                eFieldName.stafPosCode.ToString,
                eFieldName.stafTypeCode.ToString,
                eFieldName.isCustom.ToString,
                eFieldName.sessionId.ToString
                )

            Dim MyFieldsValue As String = FieldValues(
                patronId,
                mediumId,
                sub_od,
                sub_dc,
                sub_it,
                sub_op,
                sub_lrc,
                sub_rc,
                sub_fs,
                sub_vp,
                sub_ja,
                sub_gt,
                sub_etc,
                enq_qr,
                enq_rr,
                enq_st,
                enq_ag,
                enq_etc,
                question,
                answer,
                timeStart,
                timeEnd,
                DurationStr,
                isKiv,
                isFinished,
                officer,
                branchId,
                satelliteId,
                departmentId,
                divisionId,
                unitId,
                studFacultyCode,
                studProgramCode,
                studCampusCode,
                studLevelCode,
                studModeCode,
                stafDeptCode,
                stafPosCode,
                stafTypeCode,
                True,
                sessionId
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Update"

        'Public Function QuestionUpdate(patronId As String, mediumId As Integer, sub_od As Boolean, sub_dc As Boolean, sub_it As Boolean, sub_op As Boolean, sub_etc As Boolean, enq_qr As Boolean, enq_rr As Boolean, enq_st As Boolean, enq_ag As Boolean, enq_etc As Boolean, question As String, answer As String, timeStart As Date, timeEnd As Date, isKiv As Boolean, isFinished As Boolean, officer As String, branchId As Integer, satelliteId As Integer, departmentId As Integer, divisionId As Integer, unitId As Integer, studFacultyCode As String, studProgramCode As String, studCampusCode As String, studLevelCode As String, studModeCode As String, stafDeptCode As String, stafPosCode As String, stafTypeCode As String, sessionId As String) As Boolean
        Public Function QuestionUpdate(SessionId_ As String, FieldNames() As String, FieldValues() As String) As Boolean
            'All the fields
            'id, patronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, timeStart, timeEnd, duration, isKiv, isFinished, 
            'officer, branchId, satelliteId, departmentId, divisionId, unitId, studFacultyCode, studProgramCode, studCampusCode, studLevelCode, studModeCode, stafDeptCode, stafPosCode, 
            'stafTypeCode, sessionId

            Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)

            Return MyCmd.CmdUpdate4(TableName, FieldNames, FieldValues, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function QuestionDelete(QuestionId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, QuestionId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function QuestionDelete(SessionId_ As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.sessionId.ToString, SessionId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

#Region "Dedicated Funtions"

        ''' <summary>
        ''' Get a Question in a row as Datatable
        ''' </summary>
        Public Function GetQuestionSession(SessionId_ As String, ParamArray FieldName_() As String) As DataTable
            'All the fields
            'id, patronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, 
            'answer, timeStart, timeEnd, duration, isKiv, isFinished, officer, branchId, satelliteId, departmentId, divisionId, 
            'unitId, studFacultyCode, studProgramCode, studCampusCode, studLevelCode, studModeCode, stafDeptCode, stafPosCode, 
            'stafTypeCode, sessionId

            Dim MyFields As String = FieldNames(FieldName_)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.sessionId.ToString, SessionId_) _
                )

            Dim Other As String = OrderByLimit(eFieldName.timeStart.ToString, False, 1)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, MyAppConnectionString)

        End Function

        ''' <summary>
        ''' Get Questions by officer on specified month and year.
        ''' </summary>
        ''' <param name="FieldName_">FieldName. only support one for each array value. no commma</param>
        Public Function GetQuestionOnMonth(Officer_ As String, TheMonth As Integer, TheYear As Integer, ParamArray FieldName_() As String) As DataTable

            ''All the fields
            'id, patronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, timeStart, timeEnd, duration, isKiv, isFinished, 
            'officer, branchId, satelliteId, departmentId, divisionId, unitId, studFacultyCode, studProgramCode, studCampusCode, studLevelCode, studModeCode, stafDeptCode, stafPosCode, 
            'stafTypeCode, sessionId

            Dim MyFields As String = FieldNames(FieldName_)

            Dim MonthFunction As String = String.Format("MONTH({0})", eFieldName.timeStart.ToString)
            Dim YearFunction As String = String.Format("YEAR({0})", eFieldName.timeStart.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.officer.ToString, Officer_), _
                Criteria(MonthFunction, TheMonth), _
                Criteria(YearFunction, TheYear), _
                Criteria(eFieldName.isFinished.ToString, True) _
                )

            Dim Other As String = OrderBy(eFieldName.timeStart.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, MyAppConnectionString)
        End Function

        Public Function GetQuestionBySql(SqlCommand As String) As DataTable

            Return MyCmd.CmdSelectTableSql(SqlCommand, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get Kiv Questions by Officer
        ''' </summary>
        ''' <param name="FieldName_">FieldName. only support one for each array value. no commma</param>
        Public Function GetQuestionKiv(Officer_ As String, ParamArray FieldName_() As String) As DataTable

            ''All the fields
            'id, patronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, timeStart, timeEnd, duration, isKiv, isFinished, 
            'officer, branchId, satelliteId, departmentId, divisionId, unitId, studFacultyCode, studProgramCode, studCampusCode, studLevelCode, studModeCode, stafDeptCode, stafPosCode, 
            'stafTypeCode, sessionId

            Dim MyFields As String = FieldNames(FieldName_)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.officer.ToString, Officer_), _
                Criteria(eFieldName.isKiv.ToString, True) _
                )

            Dim Other As String = OrderBy(eFieldName.timeStart.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, MyAppConnectionString)
        End Function

        Public Function GetQuestionKivCount() As Integer
            Dim Officer_ As String = HttpContext.Current.User.Identity.Name

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.officer.ToString, Officer_), _
                Criteria(eFieldName.isKiv.ToString, True) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function GetQuestionKivCount(Officer_ As String) As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.officer.ToString, Officer_), _
                Criteria(eFieldName.isKiv.ToString, True) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get All Kiv Questions
        ''' </summary>
        ''' <param name="FieldName_">FieldName. only support one for each array value. no commma</param>
        Public Function GetQuestionKivAll(ParamArray FieldName_() As String) As DataTable

            ''All the fields
            'id, patronId, mediumId, sub_od, sub_dc, sub_it, sub_op, sub_etc, enq_qr, enq_rr, enq_st, enq_ag, enq_etc, question, answer, timeStart, timeEnd, duration, isKiv, isFinished, 
            'officer, branchId, satelliteId, departmentId, divisionId, unitId, studFacultyCode, studProgramCode, studCampusCode, studLevelCode, studModeCode, stafDeptCode, stafPosCode, 
            'stafTypeCode, sessionId

            Dim MyFields As String = FieldNames(FieldName_)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.isKiv.ToString, True) _
                )

            Dim Other As String = OrderBy(eFieldName.timeStart.ToString, False)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, MyAppConnectionString)
        End Function

        Public Function GetQuestionKivAllCount() As Integer

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.isKiv.ToString, True) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "checking"

        Public Function IsValidPatronId(TestPatronId_ As String, SessionId_ As String) As Boolean
            Dim ReturnValue As Boolean = False
            Dim PatronId_ As String = PatronId(SessionId_)

            If PatronId_ = TestPatronId_ Then ReturnValue = True

            Return ReturnValue
        End Function

        Public Function IsValidSessionId(CurrentOfficer_ As String, SessionId_ As String) As Boolean
            Dim ReturnValue As Boolean = False
            Dim Officer_ As String = Officer(SessionId_)

            If CurrentOfficer_ = Officer_ Then ReturnValue = True

            Return ReturnValue
        End Function


#End Region

#Region "Special Functions to retreive special datadatable"
        'None for now

#End Region

    End Module

End Namespace


