<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Organization.SatelliteList.Item" %>

<li>
    <asp:HyperLink ID="hlSatellite" runat="server">
        <asp:Label ID="lblSatelliteName" runat="server" Text=""/>
    </asp:HyperLink>
</li>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gSatelliteId" runat="server" Text="0" />
</asp:Panel>