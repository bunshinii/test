Imports NasLib.Database.MySql.Provider
Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Admin.UserSearchInternal

    ''' <summary>
    ''' This Control will search Staffs in Providers only.
    ''' </summary>
    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

#Region "Virtual Path"

        ''' <summary>
        ''' VirtualPath to redirect after submit
        ''' </summary>
        Public ReadOnly Property AbsolutePath As String
            Get
                Return ResolveUrl(VirtualPathRedirect & "?" & QueryString)
            End Get
        End Property


        Public Property QueryString As String
            Get
                Return gQueryString.Text
            End Get
            Set(value As String)
                gQueryString.Text = value
            End Set
        End Property

        ''' <summary>
        ''' VirtualPath to redirect after submit
        ''' </summary>
        Public Property VirtualPathRedirect As String
            Get
                Return gVirtualPathRedirect.Text
            End Get
            Set(value As String)
                gVirtualPathRedirect.Text = value
            End Set
        End Property

#End Region

#End Region

#Region "Functions"

        Private Function CriteriaIndex() As Integer
            Dim ReturnValue As Integer = 0
            If rbPatronId.Checked Then ReturnValue = 1
            If rbPassport.Checked Then ReturnValue = 2
            If rbName.Checked Then ReturnValue = 3
            If rbAll.Checked Then ReturnValue = 0

            Return ReturnValue
        End Function

        Private Sub SearchProvider()
            Dim StaffCount As Integer = Table.UsersProfile.SearchUsersCount(txtSearch.Text, CriteriaIndex, ProvidersConnectionString)

            Dim TotalResult As Integer = StaffCount

            Dim MaxDisplay As Integer = 100

            Dim AllTable As DataTable = Table.UsersProfile.SearchUsers(txtSearch.Text, CriteriaIndex, MaxDisplay, ProvidersConnectionString)

            NasLib.Functions.DataTable.Row.Sort(AllTable, "full_name")

            'BP_NAMA,   BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG_DESC, BP_NO_PEKERJA, BK_REKOD_STATUS
            'full_name, branch_id,            department_id,        name,          position_id

            For i As Integer = 0 To AllTable.Rows.Count - 1
                'No mistake here coz using the same User Control 'UserSearchDBLibrary.Item'
                Dim MyControl As MyControls.Rdms.Admin.UserSearchDBLibrary.Item = LoadControl("~\MyControls\Rdms\Admin\UserSearchDBLibrary\Item.ascx")

                Dim PatronId As String = AllTable(i)("name").ToString.Trim
                MyControl.PatronName = AllTable(i)("full_name").ToString.Trim

                Dim PosId As Integer = AllTable(i)("position_id").ToString.Trim
                MyControl.Program = Table.UsersPosition.Position(PosId, ProvidersConnectionString)

                Dim DeptId As Integer = AllTable(i)("department_id").ToString.Trim
                MyControl.Faculty = Table.OfficeDepartment.Department(DeptId, ProvidersConnectionString)

                MyControl.PatronId = PatronId
                MyControl.VirtualPath = VirtualPathRedirect
                MyControl.QueryString = QueryString

                If Role.IsUserInRole(PatronId, "Staff", ProvidersConnectionString) Then
                    MyControl.BackgroundColor = "bg-darkViolet"
                    MyControl.ToolTip = MyControl.PatronName & " (Staff)"

                ElseIf Role.IsUserInRole(PatronId, "Library Staff", ProvidersConnectionString) Then
                    MyControl.BackgroundColor = "bg-darkBlue"
                    MyControl.ToolTip = MyControl.PatronName & " (Library Staff)"

                ElseIf Role.IsUserInRole(PatronId, "Student", ProvidersConnectionString) Then
                    MyControl.BackgroundColor = "bg-darkOrange"
                    MyControl.ToolTip = MyControl.PatronName & " (Student)"

                Else
                    MyControl.BackgroundColor = "bg-darkCobalt"
                    MyControl.ToolTip = "Other"
                End If

                If Role.IsUserInRole(PatronId, "Library Staff", ProvidersConnectionString) Then
                    MyControl.BackgroundColor = "bg-darkBlue"
                    MyControl.ToolTip = MyControl.PatronName & " (Library Staff)"
                End If

                MyControl.VirtualPath = VirtualPathRedirect
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
                        MyResult = "Found {0} result."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case 2 To MaxDisplay - 1
                        MyResult = "Found {0} results."
                        lblResults.Text = String.Format(MyResult, AllCount)
                    Case Else
                        MyResult = "Displaying {0} results out of {1}."
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

#End Region

        Protected Sub btnSearch_Click() Handles btnSearch.ServerClick
            SearchProvider()
        End Sub
        Protected Sub lbOption_Click(sender As Object, e As EventArgs) Handles lbOption.Click
            PanelOption.Visible = Not PanelOption.Visible
        End Sub

        Private Sub hiddenButton_Click(sender As Object, e As EventArgs) Handles hiddenButton.Click
            btnSearch_Click()
        End Sub

    End Class

End Namespace

