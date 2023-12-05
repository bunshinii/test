Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Duty
    Inherits System.Web.UI.Page

#Region "Timer Message"
    'INSTRUCTION :
    '1. COPY this whole region.
    '2. Put a Timer1 Control (interval=5000) inside an UpdatePanel.
    '3. Put a LabelMessage inside the same UpdatePanel. Apply the AlwaysVisibleControlExtender on the LabelMessage
    '4. Put DisplayMessage() in PageLoad event.
    '5. Create your own code message in the DisplayMessage(). do NOT put Case 0
    '5. Redirect to this page with "code=n" query string.

    Private Sub DisplayMessage(MessageCode As Integer, ForegroundColor As System.Drawing.Color, BackgroundColor As System.Drawing.Color)
        Timer1.Enabled = True

        '#############################################################################
        'Create your own code message here. do NOT put Case 0
        Select Case MessageCode
            Case 1
                lblMessage.Text = String.Format("Sorry! You can't request on yourself.")
            Case 2
                lblMessage.Text = String.Format("You already send request to {0}.", MyModules.Functions.UserFullname(MyRequest.GetReceiverId))
        End Select
        '#############################################################################

        lblMessage.Visible = True
        lblMessage.ForeColor = Drawing.Color.White
        lblMessage.BackColor = BackgroundColor
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        lblMessage.Visible = Not lblMessage.Visible
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If MyRequest.GetSuccess Then
            Timer1.Enabled = True

            lblMessage.Visible = True
            lblMessage.Text = String.Format("Request Sent Successfully to {0}", MyModules.Functions.UserFullname(MyRequest.GetReceiverId))
            lblMessage.ForeColor = Drawing.Color.White
            lblMessage.BackColor = Drawing.Color.Green
        Else
            Dim ErrorCode As Integer = MyRequest.GetCode
            If ErrorCode > 0 Then
                DisplayMessage(ErrorCode, Drawing.Color.White, Drawing.Color.Red)
            End If

        End If

    End Sub


End Class