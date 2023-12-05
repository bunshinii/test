Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Tables.Snippet

    Public Class RowItem
        Inherits System.Web.UI.UserControl

#Region "Public Properties"
        ''1.  ### List all public properties for all controls available.

        Public Property No As Integer
            Get
                Return lblNo.Text
            End Get
            Set(value As Integer)
                lblNo.Text = value
                lblNo1.Text = value
            End Set
        End Property

        Public Property SnippetText As String
            Get
                Return hlSnippet.Text
            End Get
            Set(value As String)
                hlSnippet.Text = value
                hlSnippet.ToolTip = value
                txtSnippet.Text = value
            End Set
        End Property

        Public Property SnippetOrder As String
            Get
                Return lblorder.Text
            End Get
            Set(value As String)
                lblorder.Text = value
                txtOrder.Text = value
            End Set
        End Property

        Public Property SnippetId As Integer
            Get
                Return gSnippetId.Text
            End Get
            Set(value As Integer)
                gSnippetId.Text = value
            End Set
        End Property

#End Region

#Region "Buttons Functions"
        '' ### Just modify the functions content within 'User Function' Region
        '' Do NOT modify function name. No need to add extra function

#Region "Static Functions"

        Private WriteOnly Property EditMode As Boolean
            Set(value As Boolean)
                PanelEdit.Visible = value
                PanelStatic.Visible = Not value
            End Set
        End Property

        Private Sub btnEdit_ServerClick(sender As Object, e As EventArgs) Handles btnEdit.ServerClick
            'No need to modify
            EditMode = True
        End Sub

        Private Sub btnCancel_ServerClick(sender As Object, e As EventArgs) Handles btnCancel.ServerClick
            'No need to modify
            OriginalState(True)
        End Sub

        Private Sub btnDelete_ServerClick(sender As Object, e As EventArgs) Handles btnDelete.ServerClick
            'No need to modify
            btnDelete.Visible = False
            btnConfirm.Visible = True
        End Sub

        Private Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
            'No need to modify
            If SaveScript() Then
                EditMode = False
                OriginalState(False)
            End If

        End Sub

        Private Sub btnConfirm_ServerClick(sender As Object, e As EventArgs) Handles btnConfirm.ServerClick
            'No need modify
            PanelStatic.Visible = False
            PanelEdit.Visible = False
            DeleteScript()
        End Sub

#End Region

#Region "User Functions"
        '' ### Just modify the functions content within 'User Function' Region
        '' Do NOT modify function name. No need to add extra function
        '' Just Modufy accordingly to instructions commented

        Private Sub OriginalState(Optional ResetValue As Boolean = False)
            'No need to modify
            EditMode = False    'Must have this

            If ResetValue Then

                '' 1. ### To Reset original values ### "Textbox" <-- "Label"
                txtSnippet.Text = hlSnippet.Text
                txtOrder.Text = lblorder.Text

            End If

            '' 2. ### Controls here ### to restore all controls original color and other attributes 
            'My NOte: Nothing

        End Sub

        Private Function SaveScript() As Boolean
            'Please set "Return True" in the code below in case of success save OR "Return False" in case of Failure before Exit Sub or End Sub

            '' 1. ### SAVE conditions here ### like check if ID existed the cancel save.
            If Not IsNumeric(txtOrder.Text) Then
                txtOrder.BackColor = Drawing.Color.Red
                txtOrder.ToolTip = String.Format("The order must be numeric")
                Return False
                Exit Function
            End If


            '' 2. ### Save all Textboxes values in database ###
            Dim TheOrder_ As Integer = txtOrder.Text
            MyModules.Database.RdmsSnippets.Snippet(SnippetId) = txtSnippet.Text
            MyModules.Database.RdmsSnippets.Order(SnippetId) = TheOrder_

            '' 3. ### Transfer all Controls values here ### "Label" <-- "Textbox"
            lblorder.Text = TheOrder_
            hlSnippet.Text = txtSnippet.Text

            Return True
        End Function

        Private Sub DeleteScript()
            '' 1.  ### Todo DELETE script here ###
            MyModules.Database.RdmsSnippets.SnippetDelete(SnippetId)
        End Sub

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub



    End Class

End Namespace

