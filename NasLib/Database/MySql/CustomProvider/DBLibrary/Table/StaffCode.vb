Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary.Table

    ''' <summary>
    ''' This is a table base class base on table 'staffcode'.
    ''' </summary>
    Public Class StaffCode

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "staffcode"
        End Function



        'List all field in the table here
        Private Enum eFieldName
            position_code
            position_desc
            position_type
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "BK_JAW_HAKIKI"

        Public Shared ReadOnly Property PositionCode(ByVal _PositionCode As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.position_code.ToString
                Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        Public Shared ReadOnly Property PositionDesc(ByVal _PositionCode As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.position_desc.ToString
                Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        Public Shared ReadOnly Property PositionType(ByVal _PositionCode As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.position_type.ToString
                Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region


#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(_PositionCode As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsLibraryStaff(_PositionCode As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsLibraryStaff2(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim _PositionCode As String = Table.StaffActiv.Jawatan(PatronId, DBLibraryConnectionString)

            Dim MyCriteria As String = Criteria(eFieldName.position_code.ToString, _PositionCode)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(DBLibraryConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , DBLibraryConnectionString)
        End Function

#End Region

#Region "DataTables"

#Region "Get All Codes"

        ''' <summary>
        ''' Geat All Codes. Column(position_code)
        ''' </summary>
        Public Shared Function GetAllUsersActive(DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.position_code.ToString _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , , DBLibraryConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


