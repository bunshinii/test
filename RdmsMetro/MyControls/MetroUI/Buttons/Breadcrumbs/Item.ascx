<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.Buttons.Breadcrumbs.Item" %>

<li<%=Active_%>><asp:hyperlink ID="hlItem" runat="server">Home</asp:hyperlink></li>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gActive" runat="server" Text=""/>
</asp:Panel>
