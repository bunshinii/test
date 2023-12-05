Imports System.Web.UI.WebControls

Namespace Functions.Controls

    Public Class DropDowns

        ''' <summary>
        ''' Add Item into a DropDownList control
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="Text">Dropdown Text</param>
        ''' <param name="Value">Dropdown Value</param>
        ''' <remarks></remarks>
        Public Shared Sub ItemAdd(ByRef Dropdown As DropDownList, Text As String, Optional Value As String = "")
            Dim MyListItem As New ListItem
            MyListItem.Text = Text
            If Value.Length > 0 Then MyListItem.Value = Value
            Dropdown.Items.Add(MyListItem)
        End Sub

#Region "DataTable Add"

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Index for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Index for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As Integer, ColumnForText As Integer)
            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Name for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As String, ColumnForText As String)
            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                If ColumnForValue.Length > 0 Then MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        Public Shared Sub ItemAddFromDataTable(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForText As String)
            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dropdown.Items.Add(DataTable(i)(ColumnForText))
            Next

            DataTable.Dispose()
        End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Index for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As Integer, ColumnForText As String)
            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

#Region "DataTable Add with leading empty item"

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList with leading Empty item.
        ''' The Empty Item will has "0" as value and " - " as text.
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Index for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Index for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable0(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As Integer, ColumnForText As Integer)
            ItemAdd(Dropdown, " - ", 0)

            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList with leading Empty item.
        ''' The Empty Item will has "0" as value and " - " as text.
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Name for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable0(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As String, ColumnForText As String)
            ItemAdd(Dropdown, " - ", 0)

            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                If ColumnForValue.Length > 0 Then MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList with leading Empty item.
        ''' The Empty Item will has "0" as value and " - " as text.
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        Public Shared Sub ItemAddFromDataTable0(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForText As String)
            ItemAdd(Dropdown, " - ", 0)

            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dropdown.Items.Add(DataTable(i)(ColumnForText))
            Next

            DataTable.Dispose()
        End Sub

        ' ''' <summary>
        ' ''' Add Item from a DataTable into the DropDownList with leading Empty item.
        ' ''' The Empty Item will has "0" as value and " - " as text.
        ' ''' </summary>
        ' ''' <param name="Dropdown">DropDownList ID</param>
        ' ''' <param name="DataTable">DataTable ID</param>
        ' ''' <param name="ColumnIndexForText">Column Index for DropDoown Text</param>
        'Public Shared Sub ItemAddFromDataTable0(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnIndexForText As Integer)
        '    ItemAdd(Dropdown, " - ", 0)

        '    For i As Integer = 0 To DataTable.Rows.Count - 1
        '        Dropdown.Items.Add(DataTable(i)(ColumnIndexForText))
        '    Next

        '    DataTable.Dispose()
        'End Sub

        ''' <summary>
        ''' Add Item from a DataTable into the DropDownList with leading Empty item.
        ''' The Empty Item will has "0" as value and " - " as text.
        ''' </summary>
        ''' <param name="Dropdown">DropDownList ID</param>
        ''' <param name="DataTable">DataTable ID</param>
        ''' <param name="ColumnForText">Column Name for DropDoown Text</param>
        ''' <param name="ColumnForValue">Column Index for DropDoown Value</param>
        Public Shared Sub ItemAddFromDataTable0(ByRef Dropdown As DropDownList, DataTable As System.Data.DataTable, ColumnForValue As Integer, ColumnForText As String)
            ItemAdd(Dropdown, " - ", 0)

            For i As Integer = 0 To DataTable.Rows.Count - 1
                Dim MyListItem As New ListItem
                MyListItem.Value = DataTable(i)(ColumnForValue)
                MyListItem.Text = DataTable(i)(ColumnForText)
                Dropdown.Items.Add(MyListItem)
            Next

            DataTable.Dispose()
        End Sub

#End Region

#End Region



    End Class

End Namespace


