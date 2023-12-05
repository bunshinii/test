Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_aspnet_sessioncleanup'
    ''' </summary>
    Public Class SessionCleanup

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_aspnet_sessioncleanup"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            LastRun
            IntervalMinutes
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "LastRun"

        Public Shared Property LastRun(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastRun)
                Dim Other As String = Limit(1)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, , Other, ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.LastRun)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")
                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, , ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "IntervalMinutes"

        Public Shared Property IntervalMinutes(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IntervalMinutes)
                Dim Other As String = Limit(1)
                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, , Other, ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.IntervalMinutes)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, , ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        'No need regular functions in this table

#End Region

    End Class

End Namespace


