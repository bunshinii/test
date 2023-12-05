<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RowItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.Snippet.RowItem" %>


<asp:Panel ID="PanelStatic" runat="server">
<tr>
    <td class="no right">
        <asp:Label ID="lblNo" runat="server" Text="0"/>
    </td>
    <td class="fullname truncate right">
        <asp:HyperLink ID="hlSnippet" runat="server"/>
    </td>
        <td class="patronid right">
        <asp:Label ID="lblorder" runat="server" Text="0"/>
    </td>
    <td class="mybutton right">
        <button class="button" runat="server" id="btnEdit"><i class="icon-pencil on-left"></i>Edit</button>
    </td>
</tr>
</asp:Panel>

<asp:Panel ID="PanelEdit" runat="server" Visible="false">
<tr class="success">
    <td class="no right">
        <strong><asp:Label ID="lblNo1" runat="server" Text="0"/></strong>
    </td>
    <td class="fullname truncate right">
        <asp:TextBox ID="txtSnippet" runat="server" Width="100%" ForeColor="blue"></asp:TextBox>
    </td>
    <td class="patronid right">
        <asp:TextBox ID="txtOrder" runat="server" Width="100%"></asp:TextBox>
    </td>
    <td class="mybutton right">
        <button class="button info" runat="server" id="btnCancel"><i class="icon-cancel on-left"></i>Cancel</button>
        <button class="button info" runat="server" id="btnSave"><i class="icon-floppy on-left"></i>Save</button>
        <button class="button warning" runat="server" id="btnDelete"><i class="icon-remove on-left"></i>Remove</button>
        <button class="button danger" runat="server" id="btnConfirm" visible="false"><i class="icon-remove on-left"></i>Confirm?</button>
        <asp:Button ID="btnHiddenSave" runat="server" Text="Button" Visible="false" />
    </td>
</tr>
</asp:Panel>


<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gSnippetId" runat="server" Text="0"></asp:Label>
</asp:Panel>
