﻿Imports System.Data.SQLite
Imports NasLib.Database.SQLite.Sql.Execute

Namespace Database.SQLite.Sql

    Public Class Commands

        Dim myConnect As SQLiteConnection


#Region "Command Select"
        ''' <summary>
        ''' Select a data from database using select statement
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="Fields">One or more field names seperated by comma</param>
        ''' <param name="ReturnColumn">Return a field data specified by column index</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Function CmdSelect(ByVal TableName As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As String

            'ExeNonQuery("sa", "sa")

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)
            Return ExeQuery(SqlCommand, ReturnColumn, ConnectionString)

        End Function

        ''' <summary>
        ''' Same as CmdSelect but returns 0 if error. Use when retrieving integer or id
        ''' </summary>
        Public Function CmdSelect0(ByVal TableName As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As Integer

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)
            Return ExeQuery0(SqlCommand, ReturnColumn, ConnectionString)

        End Function

        ''' <summary>
        ''' Same as CmdSelect but returns True or False. Use when retrieving a boolean.
        ''' Only works with 'TINYINT' data type.
        ''' Error will return FALSE'
        ''' </summary>
        Public Function CmdSelectBool(ByVal TableName As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As Boolean

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)
            Return ExeQueryBool(SqlCommand, ReturnColumn, ConnectionString)

        End Function

        ''' <summary>
        ''' Same as CmdSelect but returns empty string if error
        ''' </summary>
        Public Function CmdSelect2(ByVal TableName As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)
            Return ExeQuery2(SqlCommand, ReturnColumn, ConnectionString)

        End Function


        ''' <summary>
        ''' Same as CmdSelect but returns nothing if error. DO NOT put LIMIT 1 because already LIMIT 1
        ''' </summary>
        ''' <param name="OtherSet">Order By. (DO NOT put LIMIT 1)</param>
        Public Function CmdSelectLimit(ByVal TableName As String, ByVal Fields As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet & " LIMIT 1")
            Return ExeQuery2(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Selecting ID fields only by provided criteria. The ID field name must be 'id'. Only output 1 result
        ''' </summary>
        Public Function CmdSelectId(ByVal TableName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("SELECT id FROM {0}{1} LIMIT 1;", TableName, Criteria)
            Return ExeQuery(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Return Query String from select command. Debuging purpose only
        ''' </summary>
        Public Function CmdQuerySelect(ByVal TableName As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)
            Return SqlCommand

        End Function

        ''' <summary>
        ''' Select a data from multiple table with same structure using select statement
        ''' </summary>
        ''' <param name="TableNames">Table Name (seperated by a comma)</param>
        ''' <param name="Fields">One or more field names seperated by comma</param>
        ''' <param name="ReturnColumn">Return a field data specified by column index</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Function CmdSelectUnion(ByVal TableNames As String, ByVal Fields As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim MyTable() As String = TableNames.Split(",")
            Dim TableCount As Integer = MyTable.Count - 1

            Dim SqlCommand As String = Nothing
            For i As Integer = 0 To TableCount
                MyTable(i) = MyTable(i).Trim

                SqlCommand = SqlCommand & String.Format("SELECT {0} FROM {1}{2}{3}", Fields, MyTable(i), Criteria, OtherSet)
                If i < TableCount Then
                    SqlCommand = SqlCommand & " UNION "
                Else
                    SqlCommand = SqlCommand & ";"
                End If
            Next

            Return ExeQuery(SqlCommand, ReturnColumn, ConnectionString)

        End Function

        ''' <summary>
        ''' Select a binary data from database using select statement
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldName">One field only</param>
        ''' <param name="ReturnColumn">Return a field data specified by column index (Just enter '0')</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        Public Function CmdSelectBlob(ByVal TableName As String, ByVal FieldName As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As Byte()

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", FieldName, TableName, Criteria, OtherSet)
            Return ExeQueryBlob(SqlCommand, ReturnColumn, ConnectionString)

        End Function

        ''' <summary>
        ''' Get blob size as integer in Bytes. Only Support 1 row.
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldName">One field only</param>
        ''' <param name="ReturnColumn">Return a field data specified by column index (Just enter '0')</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        Public Function CmdSelectBlobSize(ByVal TableName As String, ByVal FieldName As String, ByVal ReturnColumn As Integer, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As Integer

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT OCTET_LENGTH({0}) FROM {1}{2}{3};", FieldName, TableName, Criteria, OtherSet)
            Return ExeQuery0(SqlCommand, ReturnColumn, ConnectionString)

        End Function


        ''' <summary>
        ''' Count data from a table
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = '1'".</param>
        Public Function CmdCount(ByVal TableName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("SELECT COUNT(*) AS MyCount FROM {0}{1};", TableName, Criteria)
            Return ExeQueryCount(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Check is data existed. [LIMIT 1].
        ''' </summary>
        Public Function CmdExisted(ByVal TableName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As Boolean

            If Criteria.Length > 0 Then Criteria = " WHERE " & Criteria

            Dim SqlCommand As String = String.Format("SELECT COUNT(*) AS MyCountExisted FROM {0}{1};", TableName, Criteria)
            Return ExeQueryExisted(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Check is table existed. [LIMIT 1].
        ''' </summary>
        Public Function CmdTableExisted(ByVal TableName As String, Optional ByVal ConnectionString As String = "") As Boolean

            Dim SqlCommand As String = String.Format("select count(*) from sqlite_master where tbl_name='{0}';", TableName)
            Return ExeQueryExisted(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Sum Data from a field in a table
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldName">Field Name to Sum</param>
        Public Function CmdSum(ByVal TableName As String, FieldName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("SELECT SUM({0}) AS MySum FROM {1}{2};", FieldName, TableName, Criteria)
            Return ExeQuery(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Select Minimum value frm a field
        ''' </summary>
        Public Function CmdMin(ByVal TableName As String, FieldName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("SELECT MIN({0}) AS MyMin FROM {1}{2};", FieldName, TableName, Criteria)
            Return ExeQuery(SqlCommand, 0, ConnectionString)

        End Function

        ''' <summary>
        ''' Select Maximum value from a field
        ''' </summary>
        Public Function CmdMax(ByVal TableName As String, FieldName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("SELECT MAX({0}) AS MyMin FROM {1}{2};", FieldName, TableName, Criteria)
            Return ExeQuery(SqlCommand, 0, ConnectionString)

        End Function
#End Region

#Region "Command Insert"
        ''' <summary>
        ''' Insert data into table. Will return the current ID from id field. Remember to quote the values
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldsName">Fields Name (seperated by a comma)</param>
        ''' <param name="FieldsValue">Fields Value (seperated by a comma). Remember to quote the values</param>
        ''' <remarks>Make sure count of fields is the same between Fields Name and Fields Value</remarks>
        Public Function CmdInsert(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As String, Optional ByVal ConnectionString As String = "") As String
            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) VALUES ({2});", TableName, FieldsName, FieldsValue)
            ExeNonQuery3(SqlCommand, FieldsValue, ConnectionString)

            Dim LastId As String = ExeQuery("SELECT LAST_INSERT_ID();", 0, ConnectionString)
            Return LastId

        End Function

        ''' <summary>
        ''' Insert data into database. Remember to quote the values
        ''' </summary>
        Public Function CmdInsert2(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As String, Optional ByVal ConnectionString As String = "") As Boolean

            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) VALUES ({2});", TableName, FieldsName, FieldsValue)
            Return ExeNonQuery3(SqlCommand, FieldsValue, ConnectionString)

        End Function

        ''' <summary>
        ''' Same as CmdInsert2 but dont have to close the FieldValue with quotes. Treat the FieldValue as string. Only support 1 value
        ''' </summary>
        ''' <param name="FieldsValue">Dont close with quotes, will treat the value as string</param>
        Public Function CmdInsertString(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As String, Optional ByVal ConnectionString As String = "") As String

            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) VALUES (""{2}"");", TableName, FieldsName, FieldsValue)
            Return ExeNonQuery3(SqlCommand, FieldsValue, ConnectionString)

        End Function

        ''' <summary>
        ''' Same as CmdInsert2 but dont have to close the FieldValue with quotes. Treat the FieldValue as Integer o datetime.  Only support 1 value
        ''' </summary>
        ''' <param name="FieldsValue">Dont close with quotes, will treat the value as Interger or datetime</param>
        Public Function CmdInsertInt(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As String, Optional ByVal ConnectionString As String = "") As String

            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) VALUES ('{2}');", TableName, FieldsName, FieldsValue)
            Return ExeNonQuery3(SqlCommand, FieldsValue, ConnectionString)

        End Function

        ''' <summary>
        ''' EXPERIMENTAL: Insert BLOB data into table (Only one data at a time only)
        ''' </summary>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldsName">Fields Name (seperated by a comma)</param>
        ''' <param name="FieldsValue">File to upload</param>
        ''' <returns>Last Id</returns>
        Public Function CmdInsertBlob(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As Byte(), Optional ByVal ConnectionString As String = "") As String

            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) VALUES (@Param1);", TableName, FieldsName)
            ExeNonQueryBlob(SqlCommand, FieldsValue, ConnectionString)

            Dim LastId As String = ExeQuery("SELECT LAST_INSERT_ID();", 0, ConnectionString)
            Return LastId
        End Function

#End Region

#Region "Command Update"
        ''' <summary>
        ''' Update a data. (Only one data at a time). BETTER USE CmdUpdate3
        ''' </summary>
        Public Function CmdUpdate(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1} = ""{2}""{3}", TableName, FieldName, FieldValue, Criteria)
            Return ExeNonQuery(SqlCommand, ConnectionString)
        End Function


        ''' <summary>
        ''' Update a datas (Multiple column). Not Supporting comma in a string
        ''' </summary>
        Public Function CmdUpdate2(ByVal TableName As String, ByVal FieldsName As String, ByVal FieldsValue As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim FieldCollection() As String = FieldsName.Split(",")

            Dim FieldNparam As String = Nothing

            Dim FieldsCount As Integer = FieldCollection.Length - 1
            For i As Integer = 0 To FieldsCount
                FieldCollection(i) = FieldCollection(i).Trim()

                FieldNparam = FieldNparam & FieldCollection(i) & " = @Param" & i
                If i < FieldsCount Then
                    FieldNparam = FieldNparam & ", "
                End If
            Next

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1}{2}", TableName, FieldNparam, Criteria)
            Return ExeNonQuery3(SqlCommand, FieldsValue, ConnectionString)
        End Function

        ''' <summary>
        ''' Update a data using SQL Parameter. (Only one data at a time). Use when have commas or quotes in the value.
        ''' </summary>
        ''' <param name="FieldName">Field Name to update the value for</param>
        ''' <param name="FieldValue">New value. Must put in quote(')</param>
        Public Function CmdUpdate3(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1} = @Param1{2};", TableName, FieldName, Criteria)
            Return ExeNonQuery2(SqlCommand, FieldValue, ConnectionString)
        End Function

        ''' <summary>
        ''' Update a data using SQL Parameter. (Multiple Values). Use when have commas or quotes in some of the values.
        ''' The number of FieldNames must match the number of FieldValues.
        ''' </summary>
        ''' <param name="FieldNames_">Field Name to update the value for (in array NOT seperated by comma)</param>
        ''' <param name="FieldValues">New value. Each must put in quote(')</param>
        Public Function CmdUpdate4(ByVal TableName As String, ByVal FieldNames_() As String, ByVal FieldValues() As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim StrFieldNames As String = Simplifier.UpdsateSet(FieldNames_)

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1}{2}", TableName, StrFieldNames, Criteria)
            Return ExeNonQuery4(SqlCommand, FieldValues, ConnectionString)
        End Function


        ''' <summary>
        ''' Update Date only. (Only one data at a time)
        ''' </summary>
        Public Function CmdUpdateDate(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If IsDate(FieldValue) Then FieldValue = Format(CDate(FieldValue), "yyy-MM-dd 00:00:00")

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1} = @Param1{2}", TableName, FieldName, Criteria)
            Return ExeNonQueryDateTime(SqlCommand, FieldValue, ConnectionString)
        End Function

        ''' <summary>
        ''' Update Date and Time. (Only one data at a time)
        ''' </summary>
        Public Function CmdUpdateDateTime(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If IsDate(FieldValue) Then FieldValue = Format(CDate(FieldValue), "yyy-MM-dd HH:mm:ss")

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1} = @Param1{2}", TableName, FieldName, Criteria)
            Return ExeNonQuery2(SqlCommand, FieldValue, ConnectionString)
        End Function


        ''' <summary>
        ''' Update a data using SQL Parameter. (Only one data at a time)
        ''' </summary>
        Public Function CmdUpdateBlob(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As Byte(), Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As String

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("UPDATE {0} SET {1} = @Param1{2}", TableName, FieldName, Criteria)
            Return ExeNonQueryBlob(SqlCommand, FieldValue, ConnectionString)
        End Function
#End Region

#Region "Command Delete"

        Public Function CmdDelete(ByVal TableName As String, Optional ByVal Criteria As String = "", Optional ByVal ConnectionString As String = "") As Boolean

            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            Dim SqlCommand As String = String.Format("DELETE FROM {0}{1};", TableName, Criteria)
            Return ExeNonQuery(SqlCommand, ConnectionString)

        End Function
#End Region

#Region "Commad Select Table"

        ''' <summary>
        ''' Select a table (Web Application). ColumnName is automatically included. if fields was set to '*' then the column name will never set.
        ''' </summary>
        ''' <param name="Fields">Fieldname to get the value for seerated by a comma. Never practice the "*" but it will work in certain cases</param>
        Public Function CmdSelectTable(ByVal TableName As String, Optional ByVal Fields As String = "*", Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)

            Dim ReturnTable As DataTable = ExeQueryTable(SqlCommand, ConnectionString)

            'Naming the column
            If Not Fields = "*" Then
                Dim ColumnName() As String = Fields.Split(",")
                For i As Integer = 0 To ColumnName.Count - 1
                    ReturnTable.Columns(i).ColumnName = ColumnName(i)
                Next
            End If

            Return ReturnTable
        End Function

        ''' <summary>
        ''' Not naming the column. leave it by default
        ''' </summary>
        ''' <param name="Fields">Fieldname to get the value for seerated by a comma. Never practice the "*" but it will work in certain cases</param>
        Public Function CmdSelectTable2(ByVal TableName As String, Optional ByVal Fields As String = "*", Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, TableName, Criteria, OtherSet)

            Dim ReturnTable As DataTable = ExeQueryTable(SqlCommand, ConnectionString)

            Return ReturnTable
        End Function

        ''' <summary>
        ''' Select a group (group by) as datatable. Only support one field.
        ''' </summary>
        ''' <param name="Field">Fieldname to get the value for. Only support 1 field. grouped by this field</param>
        Public Function CmdSelectGroup(ByVal TableName As String, ByVal Field As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2} GROUP BY {0}{3};", Field, TableName, Criteria, OtherSet)

            Dim ReturnTable As DataTable = ExeQueryTable(SqlCommand, ConnectionString)

            Return ReturnTable
        End Function

        ''' <summary>
        ''' Select a group (group by) as datatable. Support many fields by only one field to be grouped.
        ''' </summary>
        ''' <param name="Fields">Fieldnames to get the value for.</param>
        ''' <param name="GroupByField">Fieldname to be grouped. Only support 1 field</param>
        Public Function CmdSelectGroup(ByVal TableName As String, ByVal Fields As String, ByVal GroupByField As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {0} FROM {1}{2} GROUP BY {3}{4};", Fields, TableName, Criteria, GroupByField, OtherSet)

            Dim ReturnTable As DataTable = ExeQueryTable(SqlCommand, ConnectionString)

            Return ReturnTable
        End Function

        Public Function CmdSelectTableSql(ByVal SqlCommand As String, Optional ByVal ConnectionString As String = "") As DataTable
            Dim dt As DataTable = New DataTable()

            If SqlCommand.Length > 0 Then

                If ConnectionString.Length > 0 Then myConnect = New SQLiteConnection(ConnectionString)

                Dim conn As SQLiteConnection = Nothing

                Try
                    Dim cmd As SQLiteCommand = New SQLiteCommand(SqlCommand, myConnect)
                    myConnect.Open()
                    Dim dr As SQLiteDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                    dt.Load(dr)

                Catch ex As SQLiteException
                    Dim MyStr As String = ex.Message
                    dt(0)(0) = MyStr
                Catch ex As Exception
                    Dim MyStr As String = ex.Message
                    dt(0)(0) = MyStr
                Finally
                    myConnect.Close()
                End Try
            End If

            Return dt
        End Function

#End Region

#Region "Checks"

        ''' <summary>
        ''' Check if table is already existed
        ''' </summary>
        Public Function IsTableExisted(TableName As String, DatabaseName As String, Optional ByVal ConnectionString As String = "") As Boolean
            Dim ReturnValue As Boolean = False
            'SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'dblibrary' AND table_name = 'stud_photo';
            Dim SqlCommand As String = String.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}';", TableName, DatabaseName)
            Dim MyStr As String = ExeQuery(SqlCommand, 0, ConnectionString)

            Dim MyInt As Integer = 0
            If IsNumeric(MyStr) Then MyInt = CInt(MyStr)

            If MyInt > 0 Then ReturnValue = True
            Return ReturnValue
        End Function

#End Region

#Region "Command Copy / Move Tables Row / Column"

        ''' <summary>
        ''' Copy whole column into another table within a database. only support one column.
        ''' </summary>
        ''' <param name="DestTableName">Destination Table Name</param>
        ''' <param name="DestFieldName">Destination Field Name. Only One field. no comma</param>
        ''' <param name="SourceTableName">Source Table Name</param>
        ''' <param name="SourceFieldName">Source Field Name. Only One field. no comma</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Sub CmdCopyColumn(DestTableName As String, DestFieldName As String, SourceTableName As String, SourceFieldName As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "")
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("INSERT INTO {0} ({1}) SELECT {3} FROM {2}{4}{5};", DestTableName, DestFieldName, SourceTableName, SourceFieldName, Criteria, OtherSet)

            SqlCmd(SqlCommand, ConnectionString)
        End Sub

        ''' <summary>
        ''' Copy table rows into another table with the same column names.
        ''' Column count doesn't have to be the same count but all destination column names must have the same name as source column name.
        ''' </summary>
        ''' <param name="DestTableName">Destination Table Name</param>
        ''' <param name="SourceTableName">Source Table Name</param>
        ''' <param name="Fields">Field names seperated by a comma. not supported '*'</param>
        Public Sub CmdCopyTableRows(DestTableName As String, ByVal SourceTableName As String, Optional ByVal Fields As String = "*", Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "")
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            'Source Table
            Dim SourceSqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, SourceTableName, Criteria, OtherSet)
            Dim SourceTable As DataTable = ExeQueryTable(SourceSqlCommand, ConnectionString)

            'Naming the column
            Dim ColumnName() As String = Fields.Split(",")
            For i As Integer = 0 To ColumnName.Count - 1
                SourceTable.Columns(i).ColumnName = ColumnName(i)
            Next

            'Destination Table
            Dim SourceTableRowCount As Integer = SourceTable.Rows.Count

            For i As Integer = 0 To SourceTableRowCount - 1

                Dim DestFieldValues As String = Nothing
                For i2 As Integer = 0 To ColumnName.Count - 1
                    If i2 = 0 Then
                        DestFieldValues = String.Format("""{0}""", SourceTable(i)(i2))
                    Else
                        DestFieldValues = DestFieldValues & "," & String.Format("""{0}""", SourceTable(i)(i2))
                    End If
                Next

                CmdInsert2(DestTableName, Fields, DestFieldValues, ConnectionString)
            Next

            SourceTable.Dispose()

        End Sub

        ''' <summary>
        ''' Copy table rows into another table with the same column names then delete the copied source rows.
        ''' Column count doesn't have to be the same count but all destination column names must have the same name as source column name.
        ''' The primary key is determined by the first column and will be the delete criteria value.
        ''' </summary>
        ''' <param name="DestTableName">Destination Table Name</param>
        ''' <param name="SourceTableName">Source Table Name</param>
        ''' <param name="Fields">Field names seperated by a comma. Make sure the first field is the primary key or the criteria value for delete (unique). not supported '*'</param>
        Public Sub CmdMoveTableRows(DestTableName As String, ByVal SourceTableName As String, Optional ByVal Fields As String = "*", Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "")
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            'Source Table
            Dim SourceSqlCommand As String = String.Format("SELECT {0} FROM {1}{2}{3};", Fields, SourceTableName, Criteria, OtherSet)
            Dim SourceTable As DataTable = ExeQueryTable(SourceSqlCommand, ConnectionString)

            'Naming the column
            Dim ColumnName() As String = Fields.Split(",")
            For i As Integer = 0 To ColumnName.Count - 1
                SourceTable.Columns(i).ColumnName = ColumnName(i)
            Next

            'Determinig PrimaryKey field and value
            Dim PrimaryField As String = ColumnName(0)
            Dim PrimaryValue As String = Nothing

            'Destination Table
            Dim SourceTableRowCount As Integer = SourceTable.Rows.Count

            For i As Integer = 0 To SourceTableRowCount - 1

                Dim DestFieldValues As String = Nothing
                For i2 As Integer = 0 To ColumnName.Count - 1
                    If i2 = 0 Then
                        PrimaryValue = SourceTable(i)(i2)
                        DestFieldValues = String.Format("""{0}""", PrimaryValue)
                    Else
                        DestFieldValues = DestFieldValues & "," & String.Format("""{0}""", SourceTable(i)(i2))
                    End If
                Next

                CmdInsert2(DestTableName, Fields, DestFieldValues, ConnectionString)

                Dim DelCriteria As String = String.Format("{0} = ""{1}""", PrimaryField, PrimaryValue)
                CmdDelete(SourceTableName, DelCriteria, ConnectionString)

            Next

            SourceTable.Dispose()
        End Sub



#End Region

#Region "Command Save into Files"

        ''' <summary>
        ''' Save a blob data into a file. Can only save one blob otherwise they will merge into one file.
        ''' Be sure to use LIMIT 1.
        ''' </summary>
        ''' <param name="SavePath">Path to save including filename and extension. Only support current server only</param>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="BlobFieldName">Fieldname of the blob field</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Sub CmdSaveBlob(SavePath As String, TableName As String, BlobFieldName As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional ByVal ConnectionString As String = "")
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {1} INTO DUMPFILE '{2}' FROM {0}{3}{4};", TableName, BlobFieldName, SavePath, Criteria, OtherSet)

            SqlCmd(SqlCommand, ConnectionString)
        End Sub

        ''' <summary>
        ''' Return Sql Commad to string, on save blob file.
        ''' </summary>
        ''' <param name="SavePath">Path to save including filename and extension. Only support current server only</param>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="BlobFieldName">Fieldname of the blob field</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Function CmdSaveBlobQuery(SavePath As String, TableName As String, BlobFieldName As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "") As String
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {1} INTO DUMPFILE '{2}' FROM {0}{3}{4};", TableName, BlobFieldName, SavePath, Criteria, OtherSet)

            Return SqlCommand
        End Function

        ''' <summary>
        ''' Save generated query data into a text or csv file.
        ''' </summary>
        ''' <param name="SavePath">Path to save including filename and extension. Only support current server only</param>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="FieldNames">Fieldnames seperated by a comma</param>
        ''' <param name="Criteria">WHERE Clause. e.g. "Field1 = 1". *You dont have to wrap in quotes if the value is number for MsAccess</param>
        ''' <param name="OtherSet">Can use "ORDER BY or LIMIT"</param>
        Public Sub CmdSaveToText(SavePath As String, TableName As String, FieldNames As String, Optional ByVal Criteria As String = "", Optional ByVal OtherSet As String = "", Optional FieldsTerminatedBy As String = ":", Optional LinesTerminatedBy As String = "\n", Optional ByVal ConnectionString As String = "")
            If Criteria.Length > 0 Then
                Criteria = " WHERE " & Criteria
            End If

            If OtherSet.Length > 0 Then
                OtherSet = " " & OtherSet
            End If

            Dim SqlCommand As String = String.Format("SELECT {1} FROM {0}{3}{4} INTO OUTFILE '{2}' FIELDS TERMINATED BY '{5}' LINES TERMINATED BY '{6}';", TableName, FieldNames, SavePath, Criteria, OtherSet, FieldsTerminatedBy, LinesTerminatedBy)

            SqlCmd(SqlCommand, ConnectionString)
        End Sub


#End Region

#Region "SQL Commands"

        ''' <summary>
        ''' Run SQL Command that return a string
        ''' </summary>
        Public Function SqlCmdString(ByVal SqlCommand As String, Optional ByVal ConnectionString As String = "") As String
            Dim ReturnValue As String = ExeQuery(SqlCommand, 0, ConnectionString)
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run SQL Command that returns byte()
        ''' </summary>
        Public Function SqlCmdBlob(ByVal SqlCommand As String, Optional ByVal ConnectionString As String = "") As Byte()
            Dim ReturnValue As Byte() = ExeQueryBlob(SqlCommand, 0, ConnectionString)
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Run SQL Command that returns a table
        ''' </summary>
        Public Function SqlCmdTable(ByVal SqlCommand As String, Optional ByVal ConnectionString As String = "") As DataTable
            Dim ReturnValue As DataTable = ExeQueryTable(SqlCommand, ConnectionString)
            Return ReturnValue
        End Function


        ''' <summary>
        ''' Run SQL Command that handle a string. Returns no data
        ''' </summary>
        Public Function SqlCmd(ByVal SqlCommand As String, Optional ByVal ConnectionString As String = "") As String
            Dim ReturnValue As String = ExeQuery(SqlCommand, 0, ConnectionString)
            Return Nothing
        End Function

#End Region

#Region "Menu Generator"

        ''' <summary>
        ''' Use this function to generate treeview. See sample code
        ''' </summary>
        ''' <param name="ParentId">Parent Id</param>
        ''' <param name="TableName">Table Name</param>
        ''' <param name="IdField">The name of Id field</param>
        ''' <param name="NameField">The name of the Subject/Topic field or whatever text to display in treeview</param>
        ''' <param name="ParentIdField">The name of the ParentId field</param>
        Public Function TreeViewGenerate(ParentId As Integer, TableName As String, IdField As String, NameField As String, ParentIdField As String, Optional OrderByField As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            ' '#### START ### Sample Code #####
            'Private Sub PopulateRootLevel()
            '    Dim MyCmd As New MySqlLib.Sql.Commands
            '    Dim MyDt As DataTable = MyCmd.TreeViewGenerate(0, "my_workspace", "id", "name", "parent_id", GetConnectionString)
            '    PopulateNodes(MyDt, TreeView1.Nodes)
            'End Sub

            'Private Sub PopulateSubLevel(ByVal parentid As Integer, ByVal parentNode As TreeNode)
            '    Dim MyCmd As New MySqlLib.Sql.Commands
            '    Dim MyDt As DataTable = MyCmd.TreeViewGenerate(parentid, "my_workspace", "id", "name", "parent_id", GetConnectionString)
            '    PopulateNodes(MyDt, parentNode.ChildNodes)
            'End Sub

            'Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)
            '    For Each dr As DataRow In dt.Rows
            '        Dim tn As New TreeNode()
            '        tn.Text = dr("name").ToString()
            '        tn.Value = dr("id").ToString()
            '        nodes.Add(tn)

            '        'If node has child nodes, then enable on-demand populating
            '        tn.PopulateOnDemand = (CInt(dr("childnodecount")) > 0)
            '    Next
            'End Sub

            'Protected Sub TreeView1_TreeNodePopulate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeView1.TreeNodePopulate
            '    PopulateSubLevel(CInt(e.Node.Value), e.Node)
            'End Sub
            ''##### END ### SAMPLE CODE #########
            If OrderByField = "" Then OrderByField = NameField

            Dim SqlCommand As String = String.Format("SELECT {1},{2},(SELECT COUNT(*) FROM {0} WHERE {3}=sc.{1}) childnodecount FROM {0} sc WHERE {3} = '{4}' ORDER BY {5};", TableName, IdField, NameField, ParentIdField, ParentId, OrderByField)
            Return CmdSelectTableSql(SqlCommand, ConnectionString)
        End Function

        ''' <summary>
        ''' Use this function to generate Menu with Auth
        ''' </summary>
        Public Function MainMenuGenerateAuth(ParentId As Integer, AllowedRoleId As Integer, Optional ByVal ConnectionString As String = "") As DataTable

            Dim TableName As String = "my_app_menus"
            Dim IdField As String = "id"
            Dim TitleField As String = "menu_title"
            Dim ParentIdField As String = "parent_id"
            Dim NavigateUrlField As String = "menu_url"
            Dim PageTargetField As String = "menu_target"
            Dim OrderByField As String = "menu_order"

            Dim SqlCommand As String = String.Format("SELECT {1},{2},{3},{4},(SELECT COUNT(*) FROM {0} WHERE {5}=sc.{1}) childnodecount FROM {0} sc WHERE {5} = '{6}' AND (needAuth = '0' OR RoleIdAllowed = '{8}') ORDER BY {7};", TableName, IdField, TitleField, NavigateUrlField, PageTargetField, ParentIdField, ParentId, OrderByField, AllowedRoleId)
            Return CmdSelectTableSql(SqlCommand, ConnectionString)
        End Function

        ''' <summary>
        ''' Use this function to generate Main Menu
        ''' </summary>
        Public Function MainMenuGenerate(ParentId As Integer, TableName As String, IdField As String, TitleField As String, ParentIdField As String, Optional NavigateUrlField As String = "", Optional PageTargetField As String = "", Optional OrderByField As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If OrderByField = "" Then OrderByField = TitleField

            Dim SqlCommand As String = String.Format("SELECT {1},{2},{3},{4},(SELECT COUNT(*) FROM {0} WHERE {5}=sc.{1}) childnodecount FROM {0} sc WHERE {5} = '{6}' ORDER BY {7};", TableName, IdField, TitleField, NavigateUrlField, PageTargetField, ParentIdField, ParentId, OrderByField)
            Return CmdSelectTableSql(SqlCommand, ConnectionString)
        End Function

        ''' <summary>
        ''' Use this function to generate Menu Control
        ''' </summary>
        Public Function MenuGenerate(ParentId As Integer, TableName As String, IdField As String, TitleField As String, ParentIdField As String, Optional OrderByField As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If OrderByField = "" Then OrderByField = TitleField

            Dim SqlCommand As String = String.Format("SELECT {1},{2},(SELECT COUNT(*) FROM {0} WHERE {3}=sc.{1}) childnodecount FROM {0} sc WHERE {3} = '{4}' ORDER BY {5};", TableName, IdField, TitleField, ParentIdField, ParentId, OrderByField)
            Return CmdSelectTableSql(SqlCommand, ConnectionString)
        End Function

        ''' <summary>
        ''' Use this function to generate Subject Treeview
        ''' </summary>
        Public Function SubjectGenerate(ParentId As Integer, TableName As String, IdField As String, TitleField As String, ParentIdField As String, Optional OrderByField As String = "", Optional ByVal ConnectionString As String = "") As DataTable
            If OrderByField = "" Then OrderByField = TitleField

            Dim SqlCommand As String = String.Format("SELECT {1},{2},(SELECT COUNT(*) FROM {0} WHERE {3}=sc.{1}) childnodecount FROM {0} sc WHERE {3} = '{4}' ORDER BY {5};", TableName, IdField, TitleField, ParentIdField, ParentId, OrderByField)
            Return CmdSelectTableSql(SqlCommand, ConnectionString)
        End Function

#End Region
    End Class

End Namespace



