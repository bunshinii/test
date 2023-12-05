<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DutyLegend.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.DutyLegend" %>

<div class="<%=Colors%>" style="width:100%; padding:5px; margin:0; font-size:large; font-weight:bold;" title="<%=tooltip%>">
    
    <div class="legend">
        <div class="dutyheader"><asp:Label ID="lblLegend" runat="server" Text=""></asp:Label></div>
        <asp:panel ID="PanelButton" runat="server" class="dutybutton" title="Remove this Staff">
            <a href="<%=VirtualPathRemoveStaff%>">
            <span class="icon-cancel-2"></span>
            </a>
        </asp:panel>
    </div>
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gDutyId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gBgColor" runat="server" Text="bg-darkBlue"></asp:Label>
    <asp:Label ID="gFgColor" runat="server" Text="bg-white"></asp:Label>
    <asp:Label ID="gVirtualPathRemoveButton" runat="server" Text="~/"></asp:Label>
    <asp:Label ID="gQueryStringRemoveButton" runat="server" Text=""></asp:Label>
</asp:Panel>
