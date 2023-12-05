<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SimpleContainer.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.ListView.OutlookStyle.SimpleContainer" %>

<div class="listview-outlook">
    <asp:PlaceHolder ID="phListItem" runat="server"/>
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBranchId" runat="server" Text="0"/>
    <asp:CheckBox ID="gFullPage" runat="server" Checked="false" />
</asp:Panel>
