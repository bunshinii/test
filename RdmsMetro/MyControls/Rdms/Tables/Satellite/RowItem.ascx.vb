Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Tables.Satellite

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

        Public Property SatelliteName As String
            Get
                Return hlName.Text
            End Get
            Set(value As String)
                hlName.Text = value
                hlName.ToolTip = value
                txtName.Text = value
            End Set
        End Property

        Public Property SatelliteCode As String
            Get
                Return lblCode.Text
            End Get
            Set(value As String)
                lblCode.Text = value
                txtCode.Text = value
            End Set
        End Property

        Public Property SatelliteId As Integer
            Get
                Return gSatId.Text
            End Get
            Set(value As Integer)
                gSatId.Text = value
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
        '' Just Modify accordingly to instructions commented

        Private Sub OriginalState(Optional ResetValue As Boolean = False)
            'No need to modify
            EditMode = False    'Must have this

            If ResetValue Then

                '' 1. ### To Reset original values ### "Textbox" <-- "Label"
                txtName.Text = hlName.Text
                txtCode.Text = lblCode.Text

            End If

            '' 2. ### Controls here ### to restore all controls original color and other attributes 
            txtCode.BackColor = Drawing.Color.White

        End Sub

        Private Function SaveScript() As Boolean
            'Please set "Return True" in the code below in case of success save OR "Return False" in case of Failure before Exit Sub or End Sub

            '' 1. ### SAVE conditions here ### like check if ID existed the cancel save.
            Dim IsSatelliteCodeExisted As Boolean = NasLib.Database.MySql.Provider.Table.OfficeSatellite.IsInitialExistedNotSelf(lblCode.Text, txtCode.Text, ProvidersConnectionString)
            If IsSatelliteCodeExisted Then
                txtCode.BackColor = Drawing.Color.Red
                txtCode.ToolTip = String.Format("Satellite code ""{0}"" is already existed.", txtCode.Text)
                Return False
                Exit Function
            End If


            '' 2. ### Save all Textboxes values in database ###
            Dim TheCode_ As String = txtCode.Text.Replace(" ", "-").Replace(",", "").Trim
            NasLib.Database.MySql.Provider.Table.OfficeSatellite.Initial(SatelliteId, ProvidersConnectionString) = TheCode_.ToLower
            NasLib.Database.MySql.Provider.Table.OfficeSatellite.Satellite(SatelliteId, ProvidersConnectionString) = txtName.Text


            '' 3. ### Transfer all Controls values here ### "Label" <-- "Textbox"
            lblCode.Text = TheCode_.ToLower
            hlName.Text = txtName.Text

            Return True
        End Function

        Private Sub DeleteScript()
            '' 1.  ### Todo DELETE script here ###
            NasLib.Database.MySql.Provider.Table.OfficeSatellite.IsDisabled(SatelliteId, ProvidersConnectionString) = True
        End Sub

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub



    End Class

End Namespace

