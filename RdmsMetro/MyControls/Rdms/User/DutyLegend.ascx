<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DutyLegend.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.DutyLegend" %>

<div class="<%=Colors%>" style="width:100%; padding:5px; margin:0; font-size:large; font-weight:bold;" title="<%=tooltip%>">
    <asp:Label ID="lblLegend" runat="server" Text=""></asp:Label>
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBgColor" runat="server" Text="bg-darkBlue"></asp:Label>
    <asp:Label ID="gFgColor" runat="server" Text="bg-white"></asp:Label>
</asp:Panel>
