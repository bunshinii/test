Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'office_satellite'
    ''' </summary>
    Public Class OfficeSatellite

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "office_satellite"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            SatelliteId
            SatelliteName
            Initial
            BranchId
            Note
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(SatelliteInitial As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.SatelliteId)
            Dim MyCriteria As String = Criteria(eFieldName.Initial.ToString, SatelliteInitial)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "satellite"

        ''' <summary>
        ''' Get / Set SatelliteName by Gender ID
        ''' </summary>
        Public Shared Property Satellite(ByVal SatelliteId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.SatelliteName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.SatelliteName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GenderName by SatelliteName
        ''' </summary>
        Public Shared Property Satellite(ByVal SatelliteInitial As String, ProviderConnectionString As String) As String
            Get
                Return Satellite(Id(SatelliteInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Satellite(Id(SatelliteInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "initial"

        ''' <summary>
        ''' Get / Set SatelliteName by Gender ID
        ''' </summary>
        Public Shared Property SatelliteInitial(ByVal SatelliteId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Initial)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set GenderName by SatelliteName
        ''' </summary>
        Public Shared Property SatelliteInitial(ByVal _SatelliteInitial As String, ProviderConnectionString As String) As String
            Get
                Return Satellite(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                SatelliteInitial(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "BranchId"

        ''' <summary>
        ''' Get / Set BranchID by Satellite ID
        ''' </summary>
        Public Shared Property BranchId(ByVal SatelliteId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return myguid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by SatelliteInitial
        ''' </summary>
        Public Shared Property BranchId(ByVal _SatelliteInitial As String, ProviderConnectionString As String) As Guid
            Get
                Return BranchId(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                BranchId(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region


#Region "Note"

        ''' <summary>
        ''' Get / Set SatelliteName by Satellite ID
        ''' </summary>
        Public Shared Property Note(ByVal SatelliteId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Note)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set BranchId by SatelliteInitial
        ''' </summary>
        Public Shared Property Note(ByVal _SatelliteInitial As String, ProviderConnectionString As String) As String
            Get
                Return Note(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Note(Id(_SatelliteInitial, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(SatelliteId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(SatelliteInitial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Initial), SatelliteInitial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedInitial(Initial As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Initial), Initial)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function SatelliteAdd(_SatelliteName As String, Initial As String, BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim SatelliteId As String = System.Guid.NewGuid.ToString

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.SatelliteId.ToString, _
                eFieldName.SatelliteName.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.BranchId.ToString, _
                eFieldName.Note.ToString)

            Dim MyFieldsValue As String = FieldValues( _
                SatelliteId, _
                _SatelliteName, _
                Initial, _
                BranchId, _
                "")

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function SatelliteDelete(SatelliteId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.SatelliteId), SatelliteId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function SatelliteDelete(_SatelliteName As String, ProviderConnectionString As String) As Boolean
            Return SatelliteDelete(Id(_SatelliteName, ProviderConnectionString), ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

        ''' <summary>
        ''' Get All Satellites. Column(3): (id, initial, satellite)
        ''' </summary>
        Public Shared Function GetAllSatellites(ProviderConnectionString As String) As DataTable

            Dim _FieldsName As String = FieldNames( _
                eFieldName.SatelliteId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.SatelliteName)

            Dim Other As String = OrderBy(eFieldName.SatelliteName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, , Other, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        Public Shared Function CountSameParent(SatelliteId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = BranchId(SatelliteId, ProviderConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParent(SatelliteId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = BranchId(SatelliteId, ProviderConnectionString)

            Dim _FieldsName As String = FieldNames( _
                eFieldName.SatelliteId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.SatelliteName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.SatelliteName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function CountSameParentByParentId(BranchId As Guid, ProviderConnectionString As String) As Integer
            Dim MyParentId As Guid = BranchId

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, MyParentId)

            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        Public Shared Function GetSameParentByParentId(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Dim ParentId As Guid = BranchId

            Dim _FieldsName As String = FieldNames( _
                eFieldName.SatelliteId.ToString, _
                eFieldName.Initial.ToString, _
                eFieldName.SatelliteName.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, ParentId)

            Dim Other As String = OrderBy(eFieldName.SatelliteName.ToString)

            Return MyCmd.CmdSelectTable(TableName, _FieldsName, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

    End Class

End Namespace


