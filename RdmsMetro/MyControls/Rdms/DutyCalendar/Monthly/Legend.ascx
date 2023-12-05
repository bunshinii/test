<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Legend.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.Monthly.Legend" %>


    <div class="legendItem <%=BackgroundColor%> <%=foregroundcolor %>">
        <asp:Label ID="lblDutyType" runat="server" Text="Text"/>
        <asp:Label ID="gTypeId" runat="server" Text="0" Visible="false"/>
    </div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBackgroundColor" runat="server" />
    <asp:Label ID="gForegroundColor" runat="server" />
</asp:Panel>

