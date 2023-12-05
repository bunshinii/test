Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.Announcement

    Module Announcement
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "announcement"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            broadcastTo     'enum
            announcement
            startDate
            endDate
            lastUpdated
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

        '############# This table has double index field (id and broadcastTo) so must use two parameter

#Region "id"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property Id(ByVal Id_ As Integer, BroadcastTo_ As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.id.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.id.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region


#Region "broadcastTo"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property BroadcastTo(ByVal Id_ As Integer, BroadcastTo_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.broadcastTo.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.broadcastTo.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "announcement"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property AnnouncementText(ByVal Id_ As Integer, BroadcastTo_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.announcement.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.announcement.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "startDate"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property StartDate(ByVal Id_ As Integer, BroadcastTo_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.startDate.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.startDate.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdateDate(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "endDate"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property EndDate(ByVal Id_ As Integer, BroadcastTo_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.endDate.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.endDate.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdateDate(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "lastUpdated"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Property LastUpdated(ByVal Id_ As Integer, BroadcastTo_ As String) As String
            Get
                Dim MyFieldName As String = eFieldName.lastUpdated.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.lastUpdated.ToString
                Dim MyCriteria As String = CriteriasAND( _
                                Criteria(eFieldName.id.ToString, Id_), _
                                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
                            )
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        ''' <summary>
        ''' This table has double index field (id and broadcastTo) so must use two parameter
        ''' </summary>
        ''' <param name="Id_">This ID is NOT unique, it match with broadcastTo to make a uniqe index</param>
        ''' <param name="BroadcastTo_">6 Mandatory Enum Value (branch, satellite, department, division, unit, myself</param>
        Public Function IsExisted(ByVal Id_ As Integer, BroadcastTo_ As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, Id_), _
                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
            )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function AnnouncementAdd(ByVal Id_ As Integer, BroadcastTo_ As String, Announcement_ As String, StartDate_ As Date, EndDate_ As Date) As Integer
            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.broadcastTo.ToString, _
                eFieldName.announcement.ToString, _
                eFieldName.startDate.ToString, _
                eFieldName.endDate.ToString, _
                eFieldName.lastUpdated.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Id_, _
                BroadcastTo_, _
                Announcement_, _
                StartDate_, _
                EndDate_, _
                Now
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function AnnouncementDelete(ByVal Id_ As Integer, BroadcastTo_ As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, Id_), _
                Criteria(eFieldName.broadcastTo.ToString, BroadcastTo_) _
            )

            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ' ''' <summary>
        ' ''' 2 columns (id, medium_name)
        ' ''' </summary>
        'Public Function GetAllMediums() As DataTable
        '    Dim _FieldName As String = FieldNames( _
        '        eFieldName.id.ToString, _
        '        eFieldName.medium_name.ToString)

        '    Return MyCmd.CmdSelectTable(TableName, _FieldName, , , MyAppConnectionString)
        'End Function

#End Region


    End Module

End Namespace


