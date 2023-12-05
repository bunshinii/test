Public Class UserSearchInternal
    Inherits System.Web.UI.Page

#Region "Timer Message"
    'INSTRUCTION :
    '1. COPY this whole "Timer Message" region.
    '2. Put a [Timer1 Control (interval=5000, Enabled=false)] and a [lblMessage with AlwaysVisibleControlExtender] inside an [UpdatePanel]. (copy in Template Region)
    '4. Create your own code message in the DisplayMessage(). do NOT put Case 0
    '5. Redirect to this page with "code=n" query string.

    Private Sub DisplayMessage(MessageCode As Integer)
        Timer1.Enabled = True
        Dim ForegroundColor As System.Drawing.Color = Drawing.Color.White
        Dim BackgroundColor As System.Drawing.Color = Nothing

        '#############################################################################
        'Create your own code message here. do NOT put Case 0
        Select Case MessageCode
            Case 1
                lblMessage.Text = String.Format("Nothing happened")
                BackgroundColor = Drawing.Color.Red
            Case 2
                lblMessage.Text = String.Format("The user data is modified successfully")
                BackgroundColor = Drawing.Color.Green

        End Select
        '#############################################################################

        lblMessage.Visible = True
        lblMessage.ForeColor = Drawing.Color.White
        lblMessage.BackColor = BackgroundColor
    End Sub

#Region "Functions"

    Private Sub LoadMessage() Handles Me.Load
        Dim MessageCode As Integer = MyModules.Functions.QueryString.MyRequest.GetCode
        DisplayMessage(MessageCode)
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        lblMessage.Visible = Not lblMessage.Visible
    End Sub

#End Region

#Region "Template"

    '<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    '    <ContentTemplate>
    '        <asp:Label ID="lblMessage" runat="server" />
    '        <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
    '        <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
    '    </ContentTemplate>
    '</asp:UpdatePanel>

#End Region

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class