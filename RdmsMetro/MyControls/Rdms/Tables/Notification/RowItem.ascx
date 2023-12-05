<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RowItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.Notification.RowItem" %>

<asp:Panel ID="PanelContent" runat="server">
    <tr>
        <td class="no right"><asp:Label ID="lblNo" runat="server" Text="0"/></td>
        <td class="medium truncate right"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
        <td class="fullname right"><asp:Label ID="lblMessage" runat="server" Text=""/></td>
        <td class="date right"><asp:Label ID="lblDate" runat="server" Text=""/></td>
        <td class="no right"><button id="btnRead" runat="server" class="button mini primary" title="Delete"><span class="icon-cancel-2"></span></button></td>
    </tr>
</asp:Panel>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gNoteId" runat="server" Text="0"></asp:Label>
</asp:Panel>