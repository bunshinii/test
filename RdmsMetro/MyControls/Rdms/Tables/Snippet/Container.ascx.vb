Namespace MyControls.Rdms.Tables.Snippet

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property SnippetType As String
            Get
                Return MyVariable.PageLevel.DataString(MyVariable.VariableKey.SnippetType)
            End Get
            Set(value As String)
                MyVariable.PageLevel.DataString(MyVariable.VariableKey.SnippetType) = value
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
            txtOrder.Text = ""
            txtSnippet.Text = ""
            EditMode = False
        End Sub

        Private Sub SaveScript()
            '' 1. ### SAVE conditions here ### like check if ID existed the cancel save. Please END the condition with EXIT SUB.

            'My Note: NO CONDITION with snippet

            '' 2. ### Save all Textboxes values in database ###
            MyModules.Database.RdmsSnippets.SnippetAdd(MyOwnId, txtSnippet.Text, SnippetType)

            'Dont Modify this
            btnRefresh_ServerClick()
        End Sub

#End Region

#End Region

#Region "Functions"

        Private Sub LoadTableData()
            Dim MyFieldname As String() = {"id", "snippet", "order_"}

            Dim SnippetTable As DataTable = MyModules.Database.RdmsSnippets.GetAllSnippets(MyOwnId, SnippetType, MyFieldname)

            Dim SnippetCount As Integer = SnippetTable.Rows.Count

            If SnippetCount > 0 Then
                For i As Integer = 0 To SnippetCount - 1
                    Dim MyControls As MyControls.Rdms.Tables.Snippet.RowItem = LoadControl("~\MyControls\Rdms\Tables\Snippet\RowItem.ascx")
                    MyControls.No = i + 1
                    MyControls.SnippetId = SnippetTable(i)("id")
                    MyControls.SnippetText = SnippetTable(i)("snippet")
                    MyControls.SnippetOrder = SnippetTable(i)("order_")

                    PlaceHolder1.Controls.Add(MyControls)
                Next
            End If

            SnippetTable.Dispose()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If MyMasterPage.AsyncPostBackSourceElementID.Length = 0 Then
                LoadTableData()
            End If


        End Sub

    End Class

End Namespace

