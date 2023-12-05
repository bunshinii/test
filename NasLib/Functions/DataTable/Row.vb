Namespace Functions.DataTable

    Public Class Row

        ''' <summary>
        ''' Sort DataTable by Column name
        ''' </summary>
        Public Shared Sub Sort(ByRef DataTableName As System.Data.DataTable, ByVal ColumnName As String)
            DataTableName.DefaultView.Sort = ColumnName

            Dim dv As DataView = New DataView(DataTableName)
            dv.Sort = ColumnName

            If DataTableName.Columns.Contains("NAME") Then DataTableName.Columns("NAME").MaxLength = 1000
            If DataTableName.Columns.Contains("PROCESS_STATUS_CODE") Then DataTableName.Columns("PROCESS_STATUS_CODE").MaxLength = 1000

            DataTableName = dv.ToTable
        End Sub

    End Class

End Namespace


