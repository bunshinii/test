Imports System.Web.UI.WebControls

Namespace Functions.Controls

    Public Class DataTableTo

#Region "To DropDownList"

        ''' <summary>
        ''' Fill DropDownList with data in DataTable
        ''' </summary>
        ''' <param name="DataTable">DataTable Name</param>
        ''' <param name="DropDownList">DopDownList ID</param>
        ''' <param name="ValueField">DataTable Column Name for Dropdown Value</param>
        ''' <param name="TextField">DataTable Column Name for Dropdown Text</param>
        Public Shared Sub ToDropDownList(ByRef DataTable As System.Data.DataTable, ByRef DropDownList As DropDownList, ValueField As String, TextField As String, Optional FirstItemCaption As String = "")
            If FirstItemCaption.Length > 0 Then
                Dim MyListItem As New ListItem
                MyListItem.Value = 0
                MyListItem.Text = FirstItemCaption
                DropDownList.Items.Add(MyListItem)
            End If

            Dim RowCount As Integer = DataTable.Rows.Count
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Value = DataTable(i)(ValueField)
                    MyListItem.Text = DataTable(i)(TextField)
                    DropDownList.Items.Add(MyListItem)
                Next
            End If

        End Sub

        ''' <summary>
        ''' Fill DropDownList with data in DataTable
        ''' </summary>
        ''' <param name="DataTable">DataTable Name</param>
        ''' <param name="DropDownList">DopDownList ID</param>
        ''' <param name="ValueFieldIndex">DataTable Column Index for Dropdown Value</param>
        ''' <param name="TextFieldIndex">DataTable Column Index for Dropdown Text</param>
        Public Shared Sub ToDropDownList(ByRef DataTable As System.Data.DataTable, ByRef DropDownList As DropDownList, ValueFieldIndex As Integer, TextFieldIndex As Integer, Optional FirstItemCaption As String = "")
            If FirstItemCaption.Length > 0 Then
                Dim MyListItem As New ListItem
                MyListItem.Value = 0
                MyListItem.Text = FirstItemCaption
                DropDownList.Items.Add(MyListItem)
            End If

            Dim RowCount As Integer = DataTable.Rows.Count
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Value = DataTable(i)(ValueFieldIndex)
                    MyListItem.Text = DataTable(i)(TextFieldIndex)
                    DropDownList.Items.Add(MyListItem)
                Next
            End If

        End Sub

        ''' <summary>
        ''' Fill DropDownList with data in DataTable.
        ''' Also Put Value in Text.
        ''' </summary>
        ''' <param name="DataTable">DataTable Name</param>
        ''' <param name="DropDownList">DopDownList ID</param>
        ''' <param name="ValueField">DataTable Column Name for Dropdown Value</param>
        ''' <param name="TextField">DataTable Column Name for Dropdown Text</param>
        Public Shared Sub ToDropDownList2(ByRef DataTable As System.Data.DataTable, ByRef DropDownList As DropDownList, ValueField As String, TextField As String, Optional FirstItemCaption As String = "")
            If FirstItemCaption.Length > 0 Then
                Dim MyListItem As New ListItem
                MyListItem.Value = 0
                MyListItem.Text = FirstItemCaption
                DropDownList.Items.Add(MyListItem)
            End If

            Dim RowCount As Integer = DataTable.Rows.Count
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Value = DataTable(i)(ValueField)
                    MyListItem.Text = DataTable(i)(ValueField) & " - " & DataTable(i)(TextField)
                    DropDownList.Items.Add(MyListItem)
                Next
            End If

        End Sub

        ''' <summary>
        ''' Fill DropDownList with data in DataTable.
        ''' Also Put Value in Text.
        ''' </summary>
        ''' <param name="DataTable">DataTable Name</param>
        ''' <param name="DropDownList">DopDownList ID</param>
        ''' <param name="ValueFieldIndex">DataTable Column Index for Dropdown Value</param>
        ''' <param name="TextFieldIndex">DataTable Column Index for Dropdown Text</param>
        Public Shared Sub ToDropDownList2(ByRef DataTable As System.Data.DataTable, ByRef DropDownList As DropDownList, ValueFieldIndex As Integer, TextFieldIndex As Integer, Optional FirstItemCaption As String = "")
            If FirstItemCaption.Length > 0 Then
                Dim MyListItem As New ListItem
                MyListItem.Value = 0
                MyListItem.Text = FirstItemCaption
                DropDownList.Items.Add(MyListItem)
            End If

            Dim RowCount As Integer = DataTable.Rows.Count
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Dim MyListItem As New ListItem
                    MyListItem.Value = DataTable(i)(ValueFieldIndex)
                    MyListItem.Text = DataTable(i)(ValueFieldIndex) & " - " & DataTable(i)(TextFieldIndex)
                    DropDownList.Items.Add(MyListItem)
                Next
            End If

        End Sub

#End Region

    End Class

End Namespace

