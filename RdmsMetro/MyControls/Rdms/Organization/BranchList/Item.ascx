<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Organization.BranchList.Item" %>

<li>
    <h5><asp:Label ID="lblBranchName" runat="server" Text=""/></h5>
    <ul class="round">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"/>
    </ul>
</li>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBranchId" runat="server" Text="0" />
</asp:Panel>