<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RowItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.DutyCalendar.RowItem" %>


<tr>
    <td class="no right"><asp:Label ID="lblNo" runat="server" Text="0"/></td>
    <td class="date right"><asp:Label ID="lblDate" runat="server"/></td>
    <td class="mediumText truncate right"><asp:Label ID="lblType" runat="server"/></td>
    <td class="longText truncate right"><asp:Label ID="lblLocation" runat="server"/></td>
    <td class="no right"><span runat="server" id="spanRequest" visible="false" class="icon-loop fg-green" title="Request Sent" style="font-size:20px;"></span><span runat="server" id="spanRequestDenied" visible="false" class="icon-loop fg-red" title="Request Rejected" style="font-size:20px;"></span></td>
    <td class="note right"><asp:Label ID="lblNote" runat="server"/></td>
    <td class="mybutton right"><button class="button" runat="server" id="btnChange"><i class="icon-loop on-left"></i>Request Change</button></td>
</tr>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gDutyId" runat="server" Text="0"/>
    <asp:Label ID="gDutyTypeId" runat="server" Text="0"/>
    <asp:Label ID="gSetelliteId" runat="server" Text="0"/>
</asp:Panel>
