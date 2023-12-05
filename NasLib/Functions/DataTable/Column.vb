Namespace Functions.DataTable

    Public Class Column

        Public Shared Sub RenameColumn(ByRef DataTableName As System.Data.DataTable, OldColumnName As String, NewColumnName As String)
            DataTableName.Columns(OldColumnName).ColumnName = NewColumnName
        End Sub

        Public Shared Sub RenameColumn(ByRef DataTableName As System.Data.DataTable, ColumnIndex As Integer, NewColumnName As String)
            DataTableName.Columns(ColumnIndex).ColumnName = NewColumnName
        End Sub

        ''' <summary>
        ''' Reorder Column in a DataTable
        ''' </summary>
        ''' <param name="DataTableName">DataTable Name</param>
        ''' <param name="ColumnNames">Order By Column names seperated by comma</param>
        ''' <remarks></remarks>
        Public Shared Sub ReorderColumns(ByRef DataTableName As System.Data.DataTable, ParamArray ColumnNames As String())
            If ColumnNames.Length <> DataTableName.Columns.Count Then
                Throw New ArgumentException("Count of columns must be equal to table.Column.Count", "columns")
            End If

            For i As Integer = 0 To ColumnNames.Length - 1
                DataTableName.Columns(ColumnNames(i)).SetOrdinal(i)
            Next
        End Sub

        ''' <summary>
        ''' Reorder Column in a DataTable
        ''' </summary>
        ''' <param name="DataTableName">DataTable Name</param>
        ''' <param name="ColumnIndexes">Order by Column Index seperated by comma</param>
        ''' <remarks></remarks>
        Public Shared Sub ReorderColumns(ByRef DataTableName As System.Data.DataTable, ParamArray ColumnIndexes As Integer())
            If ColumnIndexes.Length <> DataTableName.Columns.Count Then
                Throw New ArgumentException("Count of columns must be equal to table.Column.Count", "columns")
            End If

            For i As Integer = 0 To ColumnIndexes.Length - 1
                DataTableName.Columns(ColumnIndexes(i)).SetOrdinal(i)
            Next
        End Sub

        ''' <summary>
        ''' Add Numbering Column on the first column.
        ''' </summary>
        Public Shared Sub AddNumberingColumn(ByRef DataTableName As System.Data.DataTable)
            Dim OldCellCount As Integer = DataTableName.Columns.Count

            DataTableName.Columns.Add("No")

            For i As Integer = 0 To DataTableName.Rows.Count - 1
                DataTableName.Rows(i)("No") = i + 1
            Next

            'Reorder Columns
            DataTableName.Columns(OldCellCount).SetOrdinal(0)
            For i As Integer = 1 To OldCellCount - 1
                DataTableName.Columns(i).SetOrdinal(i)
            Next

        End Sub

        Public Shared Function IsPrimaryKeyColumn(ByRef Table As System.Data.DataTable, ByRef Column As DataColumn) As Boolean
            Return Array.IndexOf(Table.PrimaryKey, Column) >= 0
        End Function

        Public Shared Function IsForeignKeyColumn(column As DataColumn) As Boolean
            ' Ensure a valid column was received that actually belongs to a table
            If column Is Nothing Then
                Throw New ArgumentNullException("column")
            End If
            If column.Table Is Nothing Then
                Throw New ArgumentException("Column provided must belong to a table", "column")
            End If

            Dim hasForeignKey As Boolean = False

            ' Loop through ALL constraints
            Dim counter As Integer = 0
            While (Not hasForeignKey) AndAlso (counter < column.Table.Constraints.Count)
                ' Filter to only ForeignKeyConstraints that include the column we were given
                Dim constraint As ForeignKeyConstraint = TryCast(column.Table.Constraints(counter), ForeignKeyConstraint)
                If (constraint IsNot Nothing) AndAlso (constraint.Columns.Contains(column)) Then
                    hasForeignKey = True
                End If
                counter += 1
            End While

            Return hasForeignKey
        End Function

        ''' <summary>
        ''' Remove a Column from DataTable.
        ''' Cannot remove Constrains Column
        ''' </summary>
        Public Shared Sub RemoveColumn(ColumnName As String, ByRef DataTableName As System.Data.DataTable)
            If IsPrimaryKeyColumn(DataTableName, DataTableName.Columns(ColumnName)) Then DataTableName.PrimaryKey = Nothing
            DataTableName.Columns.Remove(ColumnName)
        End Sub

        ''' <summary>
        ''' Remove a Column from DataTable.
        ''' Cannot remove Constrains Column
        ''' </summary>
        Public Shared Sub RemoveColumn(ColumnIndex As Integer, ByRef DataTableName As System.Data.DataTable)
            If IsPrimaryKeyColumn(DataTableName, DataTableName.Columns(ColumnIndex)) Then DataTableName.PrimaryKey = Nothing
            DataTableName.Columns.Remove(DataTableName.Columns(ColumnIndex))
        End Sub

    End Class

End Namespace


