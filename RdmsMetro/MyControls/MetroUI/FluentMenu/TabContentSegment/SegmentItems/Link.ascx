<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Link.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.SegmentItems.Link" %>

<asp:HyperLink ID="link1" runat="server" Target="_blank">
    <span class="<%=Icon%>"></span> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:HyperLink>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gIcon" runat="server" Text="icon-link"></asp:Label>
</asp:Panel>
