Imports NasLib.Database.MySql.Sql.Simplifier

Namespace MyModules.StaffDuty

    Module StaffDuty

#Region "MySql Settings"
        Dim MyCmd As New NasLib.Database.MySql.Sql.Commands

        Dim TableDutyType As String = "duty_type"
        Dim TableDutyStaf As String = "duty_staf"

        Private Enum eDutyType
            id
            duty_type
            note
            bgColor
            foreColor
        End Enum

        Private Enum eDutyStaf
            id
            staff_id
            duty_type_id
            duty_date
            branchId
            satelliteId
        End Enum

#End Region

#Region "Table Properties"

        Public Property BackgroundColor(DutyTypeId As Integer) As String
            Get
                Dim ReturnValue As String = "#FFF"

                Dim MyField As String = FieldNames(eDutyType.bgColor.ToString)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, DutyTypeId)

                Dim MyStr As String = MyCmd.CmdSelect2(TableDutyType, MyField, 0, MyCriteria, , MyAppConnectionString)
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr

                Return ReturnValue
            End Get
            Set(value As String)
                Dim MyField As String = FieldNames(eDutyType.bgColor.ToString)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, DutyTypeId)

                MyCmd.CmdUpdate3(TableDutyType, MyField, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property ForeColor(DutyTypeId As Integer) As String
            Get
                Dim ReturnValue As String = "#000"

                Dim MyField As String = FieldNames(eDutyType.foreColor.ToString)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, DutyTypeId)

                Dim MyStr As String = MyCmd.CmdSelect2(TableDutyType, MyField, 0, MyCriteria, , MyAppConnectionString)
                If Not String.IsNullOrEmpty(MyStr) Then ReturnValue = MyStr

                Return ReturnValue
            End Get
            Set(value As String)
                Dim MyField As String = FieldNames(eDutyType.foreColor.ToString)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, DutyTypeId)

                MyCmd.CmdUpdate3(TableDutyType, MyField, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property


#End Region

#Region "Others"

        ''' <summary>
        ''' Get / Set Duty Type by Type Id from 'duty_type' table
        ''' </summary>
        ''' <param name="TypeId">Duty Type Id</param>
        ''' <value>Integer</value>
        Public Property DutyType(TypeId As Integer) As String
            Get
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, TypeId)
                Dim MyField As String = FieldNames(eDutyType.duty_type.ToString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableDutyType, MyField, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, TypeId)
                Dim MyField As String = FieldNames(eDutyType.duty_type.ToString)

                MyCmd.CmdUpdate3(TableDutyType, MyField, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

        Public Property DutyDesc(TypeId As Integer) As String
            Get
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, TypeId)
                Dim MyField As String = FieldNames(eDutyType.note.ToString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableDutyType, MyField, 0, MyCriteria, , MyAppConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyCriteria As String = Criteria(eDutyType.id.ToString, TypeId)
                Dim MyField As String = FieldNames(eDutyType.note.ToString)

                MyCmd.CmdUpdate3(TableDutyType, MyField, value, MyCriteria, MyAppConnectionString)
            End Set
        End Property

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get Staff on Duty for today as datatable.
        ''' 6 Columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        Public Function DutyToday(SatelliteId As Integer) As DataTable
            Return DutyOnDate(Now, SatelliteId)
        End Function

        ''' <summary>
        ''' Get Staff on Duty for a specified date as datatable.
        ''' 6 Columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        Public Function DutyOnDate(TheDate As Date, SatelliteId As Integer) As DataTable
            Dim MyCriteria As String = CriteriasAND(CriteriaOnDate(eDutyStaf.duty_date.ToString, TheDate), Criteria(eDutyStaf.satelliteId.ToString, SatelliteId))
            Dim MyField As String = FieldNames(eDutyStaf.id.ToString, eDutyStaf.staff_id.ToString, eDutyStaf.duty_type_id.ToString, eDutyStaf.duty_date.ToString, eDutyStaf.branchId.ToString, eDutyStaf.satelliteId.ToString)
            Dim MyOrderBy As String = OrderBy(eDutyStaf.duty_date.ToString)

            Return MyCmd.CmdSelectTable(TableDutyStaf, MyField, MyCriteria, MyOrderBy, MyAppConnectionString)
        End Function

        ''' <summary>
        ''' Get Staff on Duty for a specified date as datatable.
        ''' 6 Columns (id, staff_id, duty_type_id, duty_date, branchId, satelliteId)
        ''' </summary>
        Public Function DutyOnDate(TheDate As Date, SatelliteInitial As String) As DataTable
            Dim SatId As Integer = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Id(SatelliteInitial, ProvidersConnectionString)

            Return DutyOnDate(TheDate, SatId)
        End Function

        ''' <summary>
        ''' Get all Duty Types as Datatable.
        ''' 5 Columns (id, duty_type, note, bgColor, foreColor)
        ''' </summary>
        Public Function DutyTypes() As DataTable
            Dim MyFields As String = FieldNames(eDutyType.id.ToString, eDutyType.duty_type.ToString, eDutyType.note.ToString, eDutyType.foreColor.ToString, eDutyType.bgColor.ToString)
            Return MyCmd.CmdSelectTable(TableDutyType, MyFields, , , MyAppConnectionString)
        End Function

#End Region

    End Module

End Namespace
