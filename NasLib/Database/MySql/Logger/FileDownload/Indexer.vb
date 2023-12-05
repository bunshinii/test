Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_office_branch'
    ''' </summary>
    Public Class Indexer

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "file_index"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id          'Primary Key
            file_name
            file_path
            file_guid
            file_hits
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        ''' <summary>
        ''' Get File Id by File Guid
        ''' </summary>
        Public Shared Function Id(_FileGuid As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), _FileGuid)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        ''' <summary>
        ''' Get File GUID by File ID
        ''' </summary>
        Public Shared Function Guid(_FileId As Integer, ProviderConnectionString As String) As String
            Dim MyFieldName As String = FieldName(eFieldName.file_guid)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), _FileId)
            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "file_name"

        ''' <summary>
        ''' Get / Set File Name by File ID
        ''' </summary>
        Public Shared Property FileName(ByVal FileId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set File Name by File Guid
        ''' </summary>
        Public Shared Property FileName(ByVal FileGuid As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "file_path"

        ''' <summary>
        ''' Get / Set File Path by File ID (Windows Format)
        ''' </summary>
        Public Shared Property FilePath(ByVal FileId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_path)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_path)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set File Path by File GUID (Windows Format)
        ''' </summary>
        Public Shared Property FilePath(ByVal FileGuid As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_guid)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_guid)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "file_hits"

        ''' <summary>
        ''' Get / Set File Hits by File ID
        ''' </summary>
        Public Shared Property FileHits(ByVal FileId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_hits)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_hits)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), FileId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Get / Set File Hits by File Guid
        ''' </summary>
        Public Shared Property FileHits(ByVal FileGuid As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.file_hits)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.file_hits)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), FileGuid)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region


        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(_FileId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), _FileId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_FileGuid As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), _FileGuid)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function


        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function IndexAdd(_FileName As String, _FilePath As String, ProviderConnectionString As String) As Integer
            Dim MyGuid As Guid = System.Guid.NewGuid

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.file_name.ToString, _
                eFieldName.file_path.ToString, _
                eFieldName.file_guid.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _FileName, _
                _FilePath, _
                MyGuid.ToString
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function IndexDelete(_FileId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), _FileId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IndexDelete(_FileGuid As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.file_guid), _FileGuid)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Special Functions"

        ''' <summary>
        ''' Increment Hits by File ID
        ''' </summary>
        Public Shared Function IncrementHits(_FileId As Integer, ProviderConnectionString As String) As Integer
            Dim FileHits_ As Integer = FileHits(_FileId, ProviderConnectionString)

            FileHits_ = FileHits_ + 1
            FileHits(_FileId, ProviderConnectionString) = FileHits_

            Return FileHits_
        End Function

        ''' <summary>
        ''' Increment Hits by File GUID
        ''' </summary>
        Public Shared Function IncrementHits(_FileGuid As String, ProviderConnectionString As String) As Integer
            Dim FileHits_ As Integer = FileHits(_FileGuid, ProviderConnectionString)

            FileHits_ = FileHits_ + 1
            FileHits(_FileGuid, ProviderConnectionString) = FileHits_

            Return FileHits_
        End Function

#End Region

#End Region

    End Class

End Namespace


