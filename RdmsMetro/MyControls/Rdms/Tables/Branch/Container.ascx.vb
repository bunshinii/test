Namespace MyControls.Rdms.Tables.Branch

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Buttons Functions"

#Region "Static Functions"
        ''No need to midify anything in this region

        ''Refered from ModGlobal Module
        'Private ReadOnly Property AsyncPostBackSourceElementID As String
        '    Get
        '        Dim ToolkitScriptManager1 As AjaxControlToolkit.ToolkitScriptManager = DirectCast(Page.Master.FindControl("ToolkitScriptManager1"), AjaxControlToolkit.ToolkitScriptManager)
        '        Return ToolkitScriptManager1.AsyncPostBackSourceElementID
        '    End Get
        'End Property

        Private WriteOnly Property EditMode As Boolean
            Set(value As Boolean)
                PanelEdit.Visible = value
                PanelStatic.Visible = Not value
            End Set
        End Property

        Private Sub btnAdd_ServerClick(sender As Object, e As EventArgs) Handles btnAdd.ServerClick

            If MyMasterPage.AsyncPostBackSourceElementID.Length = 0 Then
                EditMode = True
            End If

        End Sub

        Private Sub btnRefresh_ServerClick() Handles btnRefresh.ServerClick
            Response.Redirect(CurrentURL(True))
        End Sub

        Private Sub btnCancel_ServerClick() Handles btnCancel.ServerClick
            btnRefresh_ServerClick()
        End Sub

        Private Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
            Dim AsyncPostBackSourceElementID_ As String = MyMasterPage.AsyncPostBackSourceElementID

            If AsyncPostBackSourceElementID_.Length = 0 Then SaveScript()
        End Sub

#End Region

#Region "User Functions"
        '' ### Just modify the functions content within 'User Function' Region
        '' Do NOT modify function name. No need to add extra function
        '' Just Modufy accordingly to instructions commented

        Private Sub SetOriginal()
            txtCode.Text = ""
            txtName.Text = ""
            EditMode = False
        End Sub

        Private Sub SaveScript()
            '' 1. ### SAVE conditions here ### like check if ID existed the cancel save. Please END the condition with EXIT SUB.
            Dim IsBranchCodeExisted As Boolean = NasLib.Database.MySql.Provider.Table.OfficeBranch.IsInitialExisted(txtCode.Text, ProvidersConnectionString)
            If IsBranchCodeExisted Then
                txtCode.BackColor = Drawing.Color.Red
                txtCode.ToolTip = String.Format("Branch code ""{0}"" is already existed.", txtCode.Text)

                Exit Sub
            End If

            '' 2. ### Save all Textboxes values in database ###
            NasLib.Database.MySql.Provider.Table.OfficeBranch.BranchAdd(txtName.Text, txtCode.Text, ProvidersConnectionString)

            'Dont Modify this
            btnRefresh_ServerClick()
        End Sub

#End Region

#End Region

#Region "Functions"

        Private Sub LoadTableData()
            Dim MyFieldname As String() = {"id", "branch", "initial"}

            Dim BranchTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeBranch.GetAllBranches(MyFieldname, ProvidersConnectionString)

            Dim BranchCount As Integer = BranchTable.Rows.Count

            If BranchCount > 0 Then
                For i As Integer = 0 To BranchCount - 1
                    Dim MyControls As MyControls.Rdms.Tables.Branch.RowItem = LoadControl("~\MyControls\Rdms\Tables\Branch\RowItem.ascx")
                    MyControls.No = i + 1
                    MyControls.BranchId = BranchTable(i)("id")
                    MyControls.BranchName = BranchTable(i)("branch")
                    MyControls.BranchCode = BranchTable(i)("initial")

                    PlaceHolder1.Controls.Add(MyControls)
                Next
            End If

            BranchTable.Dispose()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If MyMasterPage.AsyncPostBackSourceElementID.Length = 0 Then
                LoadTableData()
            End If


        End Sub





    End Class

End Namespace

