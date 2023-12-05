Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Reports

    Public Class ReportsGridView
        Inherits System.Web.UI.UserControl

        Public ReadOnly Property TotalRows As Integer
            Get
                Return GridView1.Rows.Count
            End Get
        End Property

        Public Property SqlCommand As String
            Get
                Return gSqlCommand.Text
            End Get
            Set(value As String)
                gSqlCommand.Text = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            MyMasterPage.MasterCustomProgress.Visible = True
        End Sub

        Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            Timer1.Enabled = False
            MyMasterPage.MasterCustomProgress.Visible = False

            Dim Questiontable As DataTable = MyModules.Database.RdmsQuestions.GetQuestionBySql(SqlCommand)

            If Questiontable.Rows.Count > 0 Then
                GridView1.DataSource = Questiontable
                GridView1.DataBind()
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
            End If

            Questiontable.Dispose()

            Label1.Text = SqlCommand
        End Sub

        Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim RowIndex As Integer = e.Row.RowIndex
                Dim lblsessionid As Label = e.Row.FindControl("sessionId")
                Dim lblPatronId As Label = e.Row.FindControl("patronId")

                'Hyperlinking 1
                Dim hlPatronname As HyperLink = e.Row.FindControl("hlpatronname")
                Dim VirtualPath As String = "~/Pages/User/EditQuestion.aspx"

                'Patron Name
                Dim lblPatronName As Label = e.Row.FindControl("patronname")
                lblPatronName.Text = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronName(lblPatronId.Text, DbLibraryConnectionString)
                If lblPatronName.Text.Length = 0 Then
                    Dim IsCustom As Boolean = MyModules.Database.RdmsQuestions.IsCustom(lblsessionid.Text)
                    If IsCustom Then lblPatronName.Text = MyModules.Database.CustomPatron.Fullname(lblPatronId.Text)

                    'Hyperlinking 2
                    hlPatronname.NavigateUrl = MyResponse.Url(VirtualPath, MyRequest._SessionId, lblsessionid.Text)

                Else
                    'Hyperlinking 3

                    Dim MyKeys() As String = {MyRequest._PatronId, MyRequest._SessionId}
                    Dim MyValues() As String = {lblPatronId.Text, lblsessionid.Text}
                    hlPatronname.NavigateUrl = MyResponse.Url(VirtualPath, MyKeys, MyValues)
                End If

                'MediumName
                Dim lblMediumId As Label = e.Row.FindControl("mediumId")
                lblMediumId.Text = MyModules.Database.RdmsMedium.MediumName(CInt(lblMediumId.Text))

                'Subjects
                Dim lblOd As Label = e.Row.FindControl("sub_od")
                Dim lblDc As Label = e.Row.FindControl("sub_dc")
                Dim lblIt As Label = e.Row.FindControl("sub_it")
                Dim lblOp As Label = e.Row.FindControl("sub_op")
                Dim lblLrc As Label = e.Row.FindControl("sub_lrc")
                Dim lblRc As Label = e.Row.FindControl("sub_rc")
                Dim lblFs As Label = e.Row.FindControl("sub_fs")
                Dim lblVp As Label = e.Row.FindControl("sub_vp")
                Dim lblJa As Label = e.Row.FindControl("sub_ja")
                Dim lblGt As Label = e.Row.FindControl("sub_gt")
                Dim lblSubEtc As Label = e.Row.FindControl("sub_etc")

                If CBool(lblOd.Text) Then lblOd.Text = "OD " Else lblOd.Text = ""
                If CBool(lblDc.Text) Then lblDc.Text = "DC " Else lblDc.Text = ""
                If CBool(lblIt.Text) Then lblIt.Text = "IT " Else lblIt.Text = ""
                If CBool(lblOp.Text) Then lblOp.Text = "OPAC " Else lblOp.Text = ""
                If CBool(lblLrc.Text) Then lblLrc.Text = "LRC " Else lblLrc.Text = ""
                If CBool(lblRc.Text) Then lblRc.Text = "RC " Else lblRc.Text = ""
                If CBool(lblFs.Text) Then lblFs.Text = "FS " Else lblFs.Text = ""
                If CBool(lblVp.Text) Then lblVp.Text = "VP " Else lblVp.Text = ""
                If CBool(lblJa.Text) Then lblJa.Text = "JAU " Else lblJa.Text = ""
                If CBool(lblGt.Text) Then lblGt.Text = "GTAR " Else lblGt.Text = ""
                If CBool(lblSubEtc.Text) Then lblSubEtc.Text = "Other " Else lblSubEtc.Text = ""

                'Enquiries
                Dim lblQr As Label = e.Row.FindControl("enq_qr")
                Dim lblRr As Label = e.Row.FindControl("enq_rr")
                Dim lblSt As Label = e.Row.FindControl("enq_st")
                Dim lblAg As Label = e.Row.FindControl("enq_ag")
                Dim lblEnqEtc As Label = e.Row.FindControl("enq_etc")

                If CBool(lblQr.Text) Then lblQr.Text = "QR " Else lblQr.Text = ""
                If CBool(lblRr.Text) Then lblRr.Text = "RR " Else lblRr.Text = ""
                If CBool(lblSt.Text) Then lblSt.Text = "ST " Else lblSt.Text = ""
                If CBool(lblAg.Text) Then lblAg.Text = "AG " Else lblAg.Text = ""
                If CBool(lblEnqEtc.Text) Then lblEnqEtc.Text = "Other " Else lblEnqEtc.Text = ""

                lblTotal.Text = RowIndex + 1
            End If

        End Sub

    End Class

End Namespace

