Namespace Functions.DataTable

    Public Class Merge

        ''' <summary>
        ''' Merge two tables into one.
        ''' Table structure and datatypes of each column should be the same.
        ''' </summary>
        Public Shared Function TwoTable(DataTable1 As System.Data.DataTable, DataTable2 As System.Data.DataTable) As System.Data.DataTable
            Dim ReturnTable As System.Data.DataTable = Nothing

            'Sync Column Name
            For i As Integer = 0 To DataTable1.Columns.Count - 1
                DataTable2.Columns(i).ColumnName = DataTable1.Columns(i).ColumnName
            Next


            If DataTable1.Rows.Count = 0 And DataTable2.Rows.Count = 0 Then         'No data
                ReturnTable = DataTable1

            ElseIf DataTable1.Rows.Count > 0 And DataTable2.Rows.Count = 0 Then     'Only DataTable1 has data
                ReturnTable = DataTable1

            ElseIf DataTable1.Rows.Count = 0 And DataTable2.Rows.Count > 0 Then     'Only DataTable2 has data
                ReturnTable = DataTable2

            ElseIf DataTable1.Rows.Count > 0 And DataTable2.Rows.Count > 0 Then     'Both has data
                DataTable1.Merge(DataTable2)
                ReturnTable = DataTable1
            End If

            DataTable1.Dispose()
            DataTable2.Dispose()

            Return ReturnTable
        End Function

    End Class

End Namespace


