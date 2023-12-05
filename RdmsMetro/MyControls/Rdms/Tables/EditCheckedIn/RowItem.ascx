<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RowItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.EditCheckedIn.RowItem" %>

<tr>
    <td class="no right"><asp:Label ID="lblNo" runat="server" Text="0"/></td>
    <td class="fullname truncate right"><asp:HyperLink ID="hlFullname" runat="server"/></td>
    <td class="patronid right"><asp:Label ID="lblPatronid" runat="server" Text="0"/></td>
    <td class="medium right"><asp:Label ID="lblMedium" runat="server" Text="0"/></td>
    <td class="date right"><asp:Label ID="lblDate" runat="server" Text="0"/></td>
</tr>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gSessionId" runat="server" Text=""></asp:Label>
    <asp:Label ID="gMediumId" runat="server" Text="0"></asp:Label>
</asp:Panel>
