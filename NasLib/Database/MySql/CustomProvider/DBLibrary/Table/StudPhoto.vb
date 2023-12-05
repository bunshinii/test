Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary.Table

    ''' <summary>
    ''' This is a table base class base on table 'stud_photo'
    ''' </summary>
    Public Class StudPhoto

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stud_photo"
        End Function

        Private Shared Function TempTableName() As String
            Return "student_temp"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            STUDENTID     'Primary Key
            PHOTO
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "PHOTO"

        Public Shared ReadOnly Property Photo(ByVal PatronId As String, DBLibraryConnectionString As String) As Byte()
            Get
                Dim MyFieldName As String = eFieldName.PHOTO.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Return MyCmd.CmdSelectBlob(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
            End Get
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(DBLibraryConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , DBLibraryConnectionString)
        End Function

        ''' <summary>
        ''' Count Students on Temporary Table. Should work with SaveAllPhotosToDisk()
        ''' </summary>
        Public Shared Function CountTemp(DBLibraryConnectionString As String) As Integer
            If MyCmd.IsTableExisted(TempTableName, "DBLibrary", DBLibraryConnectionString) Then
                Return MyCmd.CmdCount(TempTableName, , DBLibraryConnectionString)
            Else
                Return 0
            End If
        End Function

#End Region

#Region "Extra Functions"

        Public Shared Function PhotoSize(ByVal PatronId As String, Optional ByVal DBLibraryConnectionString As String = "") As Integer
            Dim MyFieldName As String = eFieldName.PHOTO.ToString
            Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

            Return MyCmd.CmdSelectBlobSize(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
        End Function

#End Region

#Region "DataTable"

        ''' <summary>
        ''' Get all student as a datatable.
        ''' 1 column (STUDENTID)
        ''' </summary>
        ''' <param name="DbLibraryConnectionString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetAllStudent(DbLibraryConnectionString As String) As DataTable
            Dim MyField As String = FieldNames(eFieldName.STUDENTID.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyField, , , DbLibraryConnectionString)
        End Function

#End Region

#Region "Save Photo To Disk"

        ''' <summary>
        ''' Save all the Photos to Server Disk.
        ''' Require mysql.exe in root folder
        ''' </summary>
        ''' <param name="SavePath">Absolute server physical path. Must put the last backslash "/". not support "~/". Do NOT include Filename</param>
        Public Shared Sub SaveAllPhotosToDisk(SavePath As String, DBLibraryConnectionString As String)

            Dim StudentTable As DataTable = MyCmd.CmdSelectTable(TempTableName, "STUDENTID", , , DBLibraryConnectionString)
            Dim StudentCount As Integer = StudentTable.Rows.Count

            Dim MySqlExePath As String = Functions._Files.GetCurrentDirectory & "mysql.exe"
            Dim MySqlScriptPath As String = Functions._Files.GetCurrentDirectory & "TempSql.txt"

            If Functions._Files.IsExisted(MySqlScriptPath) Then Functions.Files.Delete.aFile(MySqlScriptPath)
            Dim MyQuery As New Sql.CommandString

            Dim MyTextString As String = Nothing
            For i As Integer = 0 To 100 'StudentCount - 1
                Dim StudentId As String = StudentTable(i)("STUDENTID")

                Dim MySavePath = SavePath & StudentId & ".jpg"
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, StudentId)

                Dim SqlCommandString1 As String = MyQuery.CmdSaveBlob(MySavePath.Replace("\", "/"), TableName, eFieldName.PHOTO.ToString, MyCriteria) & Environment.NewLine

                MyTextString = MyTextString & SqlCommandString1
            Next
            StudentTable.Dispose()

            Functions.Files.Append.Text(MySqlScriptPath, MyTextString)

            
            Shell(String.Format("cmd /c ""{0}"" --force --user=root --password=rootwdp dblibrary < ""{1}""", MySqlExePath, MySqlScriptPath), AppWinStyle.Hide)

        End Sub

        ''' <summary>
        ''' Generate Msql Save Script to save photos to Server Disk. The Script then can be run on other mysql client like mysql.exe
        ''' </summary>
        ''' <param name="ScriptPath">The Path and the filename to put the Script File </param>
        ''' <param name="ImageFolder">The Folder to save the images. please put the last slash "/". no need filename</param>
        Public Shared Sub GenerateSaveScript(ScriptPath As String, ImageFolder As String)
            Dim DBLibraryConnectionString As String = "server=127.0.0.1;User Id=root;database=dblibrary;Password=rootwdp;Persist Security Info=True;Pooling=true"
            If Functions._Files.IsExisted(ScriptPath) Then Functions.Files.Delete.aFile(ScriptPath)

            Dim ScriptPath_ As String = ScriptPath.Replace("\", "/").Trim
            Dim SaveFolder_ As String = ImageFolder.Replace("\", "/").Trim
            Dim SqlCommand As String = String.Format("SELECT CONCAT(""SELECT PHOTO INTO DUMPFILE '{1}"", STUDENTID, "".jpg' FROM stud_photo WHERE (STUDENTID = '"", STUDENTID, ""');"") FROM stud_photo INTO OUTFILE ""{0}"" LINES TERMINATED BY '\n';", _
                                                     ScriptPath_, SaveFolder_)

            MyCmd.SqlCmd(SqlCommand, DBLibraryConnectionString)



        End Sub

#End Region
    End Class

End Namespace


