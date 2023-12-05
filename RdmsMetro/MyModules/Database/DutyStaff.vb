Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Namespace MyModules.Database.DutyStaff

    Module DutyStaff
        Dim MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Function TableName() As String
            Return "duty_staf"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id              'Primary
            staff_id
            duty_type_id
            duty_date
            branchId
            satelliteId
            add_date
        End Enum

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "staff_id"

        Public Property StaffId(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.staff_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.staff_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "duty_type_id"

        Public Property DutyTypeId(ByVal DutyId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.duty_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.duty_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "duty_date"

        Public Property DutyDate(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.duty_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.duty_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "branchId"

        Public Property BranchId(ByVal DutyId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.branchId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public ReadOnly Property BranchName(ByVal DutyId_ As Integer) As String
            Get
                Dim BranchId_ As Integer = BranchId(DutyId_)
                Dim ReturnValue As String = NasLib.Database.MySql.Provider.Table.OfficeBranch.Branch(BranchId_, ProvidersConnectionString)
                Return ReturnValue
            End Get
        End Property

#End Region

#Region "satelliteId"

        Public Property SatelliteId(ByVal DutyId_ As Integer) As Integer
            Get
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)

                Dim ReturnValue As Integer = 0
                If IsNumeric(MyStr) Then ReturnValue = MyStr
                Return ReturnValue
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.satelliteId.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public ReadOnly Property SatelliteName(ByVal DutyId_ As Integer) As String
            Get
                Dim SatelliteId_ As Integer = SatelliteId(DutyId_)
                Dim ReturnValue As String = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Satellite(SatelliteId_, ProvidersConnectionString)
                Return ReturnValue
            End Get
        End Property

#End Region

#Region "add_date"

        Public Property AddedDate(ByVal DutyId_ As Integer) As String
            Get
                Dim MyFieldName As String = eFieldName.add_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.add_date.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Function IsExisted(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, MyAppConnectionString)
            Return MyBool
        End Function

        Public Function Count() As Integer
            Return MyCmd.CmdCount(TableName, , MyAppConnectionString)
        End Function

        Public Function CountMonth(Month_ As Integer) As Integer
            Dim MyCriteria As String = Criteria(FunctionMonth(eFieldName.duty_date.ToString), Month_)

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function CountYear(Year_ As Integer) As Integer
            Dim MyCriteria As String = Criteria(FunctionYear(eFieldName.duty_date.ToString), Year_)

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function CountMonth(Month_ As Integer, Officer_ As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.duty_date.ToString), Month_), _
                Criteria(eFieldName.staff_id.ToString, Officer_) _
                )
            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function CountYear(Year_ As Integer, Officer_ As String) As Integer
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(FunctionYear(eFieldName.duty_date.ToString), Year_), _
                Criteria(eFieldName.staff_id.ToString, Officer_) _
                )

            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

        Public Function Count(Officer_ As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.staff_id.ToString, Officer_)
            Return MyCmd.CmdCount(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#Region "Table CRUD Operation"

#Region "Insert"

        Public Function DutyAdd(Officer_ As String, DutyTypeId_ As Integer, BranchId As Integer, SatelliteId As Integer, DutyDate As Date) As Integer

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.staff_id.ToString, _
                eFieldName.duty_type_id.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.satelliteId.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.add_date.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                Officer_, _
                DutyTypeId_, _
                BranchId, _
                SatelliteId, _
                DutyDate, _
                Now _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, MyAppConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Function DutyDelete(DutyId_ As Integer) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, DutyId_)
            Return MyCmd.CmdDelete(TableName, MyCriteria, MyAppConnectionString)
        End Function

#End Region

#End Region

#Region "Retrieving DataTables"

        ''' <summary>
        ''' 6 columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        Public Function GetAllDuty() As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.staff_id.ToString, _
                eFieldName.duty_type_id.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.satelliteId.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.duty_date.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, , Other, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' 6 columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        Public Function GetAllDuty(Officer_ As String) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.staff_id.ToString, _
                eFieldName.duty_type_id.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.satelliteId.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.staff_id.ToString, Officer_)

            Dim Other As String = OrderBy(eFieldName.duty_date.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get Duty for specified Days
        ''' 6 columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        ''' <param name="ForDays">How many days to include. Today = 0</param>
        Public Function GetAllDuty(Officer_ As String, ForDays As Integer) As DataTable
            Dim _FieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.staff_id.ToString, _
                eFieldName.duty_type_id.ToString, _
                eFieldName.duty_date.ToString, _
                eFieldName.branchId.ToString, _
                eFieldName.satelliteId.ToString _
                )

            Dim DateStart As Date = Now.ToShortDateString
            Dim DateEnd As Date = DateStart.AddDays(ForDays)

            Dim MyCriteria As String = Nothing

            Select Case ForDays
                Case 0
                    MyCriteria = CriteriasAND( _
                        Criteria(eFieldName.staff_id.ToString, Officer_), _
                        CriteriaDate(eFieldName.duty_date.ToString, DateStart) _
                        )
                Case Is < 0
                    MyCriteria = CriteriasAND( _
                        Criteria(eFieldName.staff_id.ToString, Officer_), _
                        CriteriaBetweenDates(eFieldName.duty_date.ToString, DateStart.AddDays(-1), DateEnd) _
                        )
                Case Else
                    MyCriteria = CriteriasAND( _
                        Criteria(eFieldName.staff_id.ToString, Officer_), _
                        CriteriaBetweenDates(eFieldName.duty_date.ToString, DateStart, DateEnd) _
                        )
            End Select


            Dim Other As String = OrderBy(eFieldName.duty_date.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, _FieldName, MyCriteria, Other, MyAppConnectionString)
        End Function

#End Region


    End Module

End Namespace


