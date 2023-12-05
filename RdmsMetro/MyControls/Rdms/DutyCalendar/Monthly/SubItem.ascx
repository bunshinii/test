<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SubItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.Monthly.SubItem" %>

<asp:Panel ID="Panel1" runat="server">
    <div style="padding:0; margin:0; overflow:hidden; white-space:nowrap;">
        <asp:HyperLink ID="hlName" runat="server">
        <div style="padding:2px 3px; margin:2px 0;" class="staffname <%=Colors%>">
            <div style="overflow:hidden; width:100%;">
            <span class="icon-user"></span> <asp:Label ID="lblName" runat="server" Width="25px" />
            </div>
            <asp:Label ID="lblStaffId" runat="server" Text="0" Visible="false" />
        </div>
        </asp:HyperLink>
    </div>
</asp:Panel>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBackgroundColor" runat="server" />
    <asp:Label ID="gForegroundColor" runat="server" />
</asp:Panel>
