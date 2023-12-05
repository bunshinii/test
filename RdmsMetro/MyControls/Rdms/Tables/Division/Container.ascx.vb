Namespace MyControls.Rdms.Tables.Division

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property BranchId As Integer
            Get
                Return gBranchId.Text
            End Get
            Set(value As Integer)
                gBranchId.Text = value

            End Set
        End Property

        Public Property DepartmentId As Integer
            Get
                Return gDepartmentid.Text
            End Get
            Set(value As Integer)
                gDepartmentid.Text = value

            End Set
        End Property


#End Region

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
            Dim IsDivisionCodeExisted As Boolean = NasLib.Database.MySql.Provider.Table.OfficeDivision.IsExistedInitial(txtCode.Text, ProvidersConnectionString)
            If IsDivisionCodeExisted Then
                txtCode.BackColor = Drawing.Color.Red
                txtCode.ToolTip = String.Format("Division code ""{0}"" is already existed.", txtCode.Text)

                Exit Sub
            End If

            '' 2. ### Save all Textboxes values in database ###
            NasLib.Database.MySql.Provider.Table.OfficeDivision.DivisionAdd(txtName.Text, txtCode.Text, BranchId, DepartmentId, ProvidersConnectionString)

            'Dont Modify this
            btnRefresh_ServerClick()
        End Sub

#End Region

#End Region

#Region "Functions"

        Private Sub LoadTableData()
            Dim MyFieldname As String() = {"id", "division", "initial"}

            Dim DivisionTable As DataTable = NasLib.Database.MySql.Provider.Table.OfficeDivision.GetDivisionsByDepartmentId(DepartmentId, MyFieldname, ProvidersConnectionString)

            Dim DivisionCount As Integer = DivisionTable.Rows.Count

            If DivisionCount > 0 Then
                For i As Integer = 0 To DivisionCount - 1
                    Dim MyControls As MyControls.Rdms.Tables.Division.RowItem = LoadControl("~\MyControls\Rdms\Tables\Division\RowItem.ascx")
                    MyControls.No = i + 1
                    MyControls.DivisionidId = DivisionTable(i)("id")
                    MyControls.DivisionName = DivisionTable(i)("division")
                    MyControls.DivisionCode = DivisionTable(i)("initial")

                    PlaceHolder1.Controls.Add(MyControls)
                Next
            End If

            DivisionTable.Dispose()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If MyMasterPage.AsyncPostBackSourceElementID.Length = 0 Then
                LoadTableData()
            End If


        End Sub





    End Class

End Namespace

