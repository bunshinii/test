<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Legend.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.DutyRequest.Legend" %>

<div style="float:left; padding:5px;margin:0 5px; border:2px solid gray;" class="<%=BackGroundColor%> <%=ForeGroundColor%>" title="<%=DutyTooltip%>">
    <asp:Label ID="lblDutyName" runat="server" Text="None"></asp:Label>
</div>

 <asp:Panel ID="PanelDebug" runat="server" Visible="false">
     <asp:Label ID="gBackgroundColor" runat="server"/>
     <asp:Label ID="gForgroundColor" runat="server"/>
 </asp:Panel>