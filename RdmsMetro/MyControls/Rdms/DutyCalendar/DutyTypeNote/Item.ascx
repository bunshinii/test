<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.DutyTypeNote.Item" %>

<tr>
    <td class="<%=Colors%>" style="width:15px;">
         &nbsp; 
    </td>
    <td>
        <asp:Label ID="lblName" runat="server" Text="Name" Font-Bold="true"></asp:Label>
    </td>
    <td> &nbsp; : &nbsp; </td>
    <td>
        <asp:Label ID="lblDecription" runat="server" Text="Desc"></asp:Label>
    </td>
</tr>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBgColor" runat="server" Text="bg-black"></asp:Label>
    <asp:Label ID="gFgColor" runat="server" Text="fg-white"></asp:Label>
</asp:Panel>
