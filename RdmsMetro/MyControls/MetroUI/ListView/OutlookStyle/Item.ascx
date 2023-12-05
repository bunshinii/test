<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.ListView.OutlookStyle.Item" %>


    <asp:HyperLink ID="hlLink" runat="server" CssClass="list" NavigateUrl="#" Target="_blank">
    <div class="list-content">
        <span class="list-title">
            <asp:Image ID="imgFavicon" runat="server" />&nbsp;
            <asp:Label ID="lblTitle" runat="server"/></span>
        <span class="list-subtitle">On <asp:Label ID="lblPubDate" runat="server" /></span>
    </div>
    </asp:HyperLink>
    
    

