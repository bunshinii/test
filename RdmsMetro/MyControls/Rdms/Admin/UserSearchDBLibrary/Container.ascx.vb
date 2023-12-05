Imports NasLib.Database.MySql.CustomProvider.DBLibrary

Namespace MyControls.Rdms.Admin.UserSearchDBLibrary

    ''' <summary>
    ''' This Control will search Staffs in DBLibrary only.
    ''' </summary>
    Public Class Container
        Inherits System.Web.UI.UserControl

        ''' <summary>
        ''' Set Background Color for Staff
        ''' </summary>
        ''' <param name="ProcessStatusCode">Obtained in DBLibrary "BK_REKOD_STATUS" from 'staff_activ'</param>
        Private Function StaffBgColor(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "bg-darkBlue"
            If Not ProcessStatusCode = "1" Then ReturnValue = "bg-darkRed"

            Return ReturnValue
        End Function

        Private Function StaffActive(ProcessStatusCode As String) As String
            Dim ReturnValue As String = "Active Staff"
            If Not ProcessStatusCode = "1" Then ReturnValue = "Staff Not Active"

            Return ReturnValue
        End Function

        Private Function CriteriaIndex() As Integer
            Dim ReturnValue As Integer = 0
            If rbPatronId.Checked Then ReturnValue = 1
            If rbPassport.Checked Then ReturnValue = 2
            If rbName.Checked Then ReturnValue = 3
            If rbAll.Checked Then ReturnValue = 0

            Return ReturnValue
        End Function

        Private Sub SearchStaff()
            Dim StaffCount As Integer = Table.StaffActiv.SearchUsersCount(txtSearch.Text, CriteriaIndex, DbLibraryConnectionString)
            Dim TotalResult As Integer = StaffCount

            Dim MaxDisplay As Integer = 100

            Dim AllTable As DataTable = Table.StaffActiv.SearchUsers(txtSearch.Text, CriteriaIndex, MaxDisplay, DbLibraryConnectionString)
            NasLib.Functions.DataTable.Row.Sort(AllTable, "BP_NAMA")

            'BP_NAMA, BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG_DESC, BP_NO_PEKERJA, BK_REKOD_STATUS
            For i As Integer = 0 To AllTable.Rows.Count - 1
                Dim MyControl As MyControls.Rdms.Admin.UserSearchDBLibrary.Item = LoadControl("~\MyControls\Rdms\Admin\UserSearchDBLibrary\Item.ascx")

                Dim PatronId As String = AllTable(i)("BP_NO_PEKERJA")
                Dim StatusCode As String = AllTable(i)("BK_REKOD_STATUS")

                MyControl.PatronName = AllTable(i)("BP_NAMA").ToString.Trim
                MyControl.Program = AllTable(i)("BK_JAW_SEKARANG_DESC").ToString.Trim
                MyControl.Faculty = AllTable(i)("BK_JAB_SEKARANG_DESC").ToString.Trim
                MyControl.PatronId = PatronId

                If Patron.IsStaff(PatronId, DbLibraryConnectionString) Then
                    MyControl.BackgroundColor = StaffBgColor(StatusCode)
                    MyControl.ToolTip = MyControl.PatronName & " (" & StaffActive(StatusCode) & ")"
                Else
                    MyControl.BackgroundColor = "bg-darkCobalt"
                    MyControl.ToolTip = "Other"
                End If

                Dim IsRegistered As Boolean = NasLib.Database.MySql.Provider.Table.Users.IsExisted(PatronId, ProvidersConnectionString)
                If IsRegistered Then MyControl.BackgroundColor = "bg-darkGreen"

                phItem.Controls.Add(MyControl)

            Next

            'Results
            Dim AllCount As Integer = AllTable.Rows.Count

            If AllCount >= 0 Then

                Dim MyResult As String = Nothing
                Select Case AllCount
                    Case 0
                        MyResult = "No Data"
                        lblResults.Text = MyResult
                    Case 1
                        MyResult = "Found {0} staff."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case 2 To MaxDisplay - 1
                        MyResult = "Found {0} staffs."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case Else
                        MyResult = "Displaying {0} staffs out of {1}."
                        lblResults.Text = String.Format(MyResult, AllCount, TotalResult)
                End Select

            End If

            If AllCount > 0 Then
                PanelLegend.Visible = True
            Else
                PanelLegend.Visible = False
            End If

            AllTable.Dispose()
        End Sub

        Protected Sub btnSearch_Click() Handles btnSearch.ServerClick
            SearchStaff()
        End Sub
        Protected Sub lbOption_Click(sender As Object, e As EventArgs) Handles lbOption.Click
            PanelOption.Visible = Not PanelOption.Visible
        End Sub

        Private Sub hiddenButton_Click(sender As Object, e As EventArgs) Handles hiddenButton.Click
            btnSearch_Click()
        End Sub

        Protected Sub lblManual_Click(sender As Object, e As EventArgs) Handles lblManual.Click
            Response.Redirect("~/Pages/Admin/UserRegister.aspx")
        End Sub

    End Class

End Namespace