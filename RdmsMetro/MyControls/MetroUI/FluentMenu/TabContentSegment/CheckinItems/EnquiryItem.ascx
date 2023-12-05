<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EnquiryItem.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.CheckinItems.EnquiryItem" %>

<label class="inline-block" title='<%=ToolTip%>'>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <span class="check"></span>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</label>