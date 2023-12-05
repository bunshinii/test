Public Class CodeTemplates
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
                lblMessage.Text = String.Format("The user is already registered")
                BackgroundColor = Drawing.Color.Red
            Case 2
                lblMessage.Text = String.Format("The user is registered successfully")
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

#Region "Notification"

    Private Sub SendNotification(ReceiverId_ As String)

        'Pelase determine the owner or sender by swapping the values. comment the unused one.
        Dim OwnerId As String = MyModules.Functions.QueryString.MyRequest.OwnerId
        Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)
        Dim ReceiverId As String = ReceiverId_
        Dim ReceiverName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(ReceiverId, ProvidersConnectionString)

        Dim MessageTitle As String = "Duty Change Rejected"
        Dim MessageText As String = String.Format("Your Duty Change Request has been Rejected by '{0}'.", OwnerName)

        MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)
    End Sub

#Region "Template"

    ''Run the code below to send notification
    ''Send Notification
    'Dim SenderId As String = MyModules.Database.DutyRequest.SenderIdByDutyId(DutyId_)
    'SendNotification(SenderId)

#End Region

#End Region

End Class