Namespace Functions.DataTable

    Public Class Convert

        ''' <summary>
        ''' Convert DataTable to HTML string. Using THEAD TBODY table format. Complete with HTML tag
        ''' </summary>
        ''' <param name="DataTableName">DataTable Name</param>
        ''' <param name="HeaderText">Table Header (using H2 tag)</param>
        ''' <param name="StyleString">CSS Style string (eg '.foo{color:black}')</param>
        ''' <param name="PrintStyleString">CSS Style string for print view only (eg ''@page {size: landscape;margin: 2cm;}')</param>
        Public Shared Function DataTableToHTML(DataTableName As System.Data.DataTable, HeaderText As String, StyleString As String, PrintStyleString As String) As String

            Dim html As String = "<html><head>"

            '#### STYLE ####
            html += "<style>"
            html += "thead {display: table-header-group; }"
            html += "th {background-color: lightgray;}"
            html += ".break { page-break-before: always; }"
            html += StyleString
            html += "</style>"

            'Print View
            html += "<style type='text/css' media='print'>"
            html += PrintStyleString
            html += "</style>"

            html += "</head><body>"

            ' Header Text
            html += String.Format("<h2>{0}</h2>", HeaderText)

            '#### TABLE #####

            html += "<table border='1' width='100%'>"

            'add header row
            html += "<thead><tr>"
            For i As Integer = 0 To DataTableName.Columns.Count - 1
                html += String.Format("<th class='{0}'>{0}</th>", DataTableName.Columns(i).ColumnName)
            Next
            html += "</tr></thead>"

            'add rows
            html += "<tbody>"
            For i As Integer = 0 To DataTableName.Rows.Count - 1
                html += "<tr>"
                For j As Integer = 0 To DataTableName.Columns.Count - 1
                    html += String.Format("<td class='{0}'>{1}</td>", DataTableName.Columns(j).ColumnName, DataTableName.Rows(i)(j).ToString())
                Next
                html += "</tr>"
            Next
            html += "</tbody>"

            html += "</table>"

            html += "</body></html>"
            Return html
        End Function

        
        ''' <summary>
        ''' Convert DataTable to HTML string for MS-WORD format. Using THEAD TBODY table format. Complete with HTML tag.
        ''' Only Print view.
        ''' </summary>
        ''' <param name="DataTableName">DataTable Name</param>
        ''' <param name="HeaderText">Table Header (using H2 tag)</param>
        ''' <param name="StyleString">CSS Style string (eg '.foo{color:black}')</param>
        Public Shared Function DataTableToHTMLWord(DataTableName As System.Data.DataTable, HeaderText As String, StyleString As String) As String
            'build the content for the dynamic Word document
            'in HTML alongwith some Office specific style properties. 
            Dim strBody As New System.Text.StringBuilder("")

            strBody.Append("<html " & _
                    "xmlns:o='urn:schemas-microsoft-com:office:office' " & _
                    "xmlns:w='urn:schemas-microsoft-com:office:word'" & _
                    "xmlns='http://www.w3.org/TR/REC-html40'>" & _
                    "<head><title>Time</title>")

            'The setting specifies document's view after it is downloaded as Print
            'instead of the default Web Layout
            strBody.Append("<!--[if gte mso 9]>" & _
                            "<xml>" & _
                            "<w:WordDocument>" & _
                            "<w:View>Print</w:View>" & _
                            "<w:Zoom>90</w:Zoom>" & _
                            "<w:DoNotOptimizeForBrowser/>" & _
                            "</w:WordDocument>" & _
                            "</xml>" & _
                            "<![endif]-->")

            strBody.Append("<style>" & _
                            "<!-- /* Style Definitions */" & _
                            "@page Section1" & _
                            "   {size:8.5in 11.0in; " & _
                            "   margin:1.0in 1.25in 1.0in 1.25in ; " & _
                            "   mso-header-margin:.5in; " & _
                            "   mso-footer-margin:.5in; mso-paper-source:0;}" & _
                            " div.Section1{page:Section1;}" & _
                            " .break { page-break-before: always; }" & _
                            StyleString & _
                            "-->" & _
                            "</style></head>")

            strBody.Append("<body lang=EN-US style='tab-interval:.5in'>")

            ' ## Start Section1     <===========================================================
            strBody.Append("<div class='Section1'>")

            ''Content

            strBody.Append(String.Format("<h2>{0}</h2>", HeaderText))

            '#### TABLE #####

            strBody.Append("<table border='1' width='100%'>")

            'add header row
            strBody.Append("<thead><tr>")
            For i As Integer = 0 To DataTableName.Columns.Count - 1
                strBody.Append(String.Format("<th class='{0}'>{0}</th>", DataTableName.Columns(i).ColumnName))
            Next
            strBody.Append("</tr></thead>")

            'add rows
            strBody.Append("<tbody>")
            For i As Integer = 0 To DataTableName.Rows.Count - 1
                strBody.Append("<tr>")
                For j As Integer = 0 To DataTableName.Columns.Count - 1
                    strBody.Append(String.Format("<td class='{0}'>{1}</td>", DataTableName.Columns(j).ColumnName, DataTableName.Rows(i)(j).ToString()))
                Next
                strBody.Append("</tr>")
            Next
            strBody.Append("</tbody>")
            strBody.Append("</table>")

            strBody.Append("</div>")
            ' ## End Section1       <===========================================================

            strBody.Append("</body></html>")

            'Force this content to be downloaded 
            'as a Word document with the name of your choice
            'Dim context As System.Web.HttpContext = System.Web.HttpContext.Current

            'context.Response.AppendHeader("Content-Type", "application/msword")
            'context.Response.AppendHeader("Content-disposition", _
            '                       "attachment; filename=myword.doc")
            'context.Response.Write(strBody)

            Dim ReturnValue As String = strBody.ToString
            Return ReturnValue
        End Function



    End Class

End Namespace


