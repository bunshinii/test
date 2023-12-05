<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Breadcrumb.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.Buttons.Breadcrumbs.Breadcrumb" %>

<nav class="breadcrumbs mini">
    <ul>
        <li><asp:hyperlink ID="hlHome" runat="server" NavigateUrl="~/"><i class="icon-home"></i></asp:hyperlink></li>
        <li><asp:hyperlink ID="hlHome2" runat="server" NavigateUrl="~/">Home</asp:hyperlink></li>
        <asp:PlaceHolder ID="phItem" runat="server"/>
    </ul>
</nav>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gNameArray" runat="server" Text="" />
    <asp:Label ID="gUrlArray" runat="server" Text="" />
</asp:Panel>
