<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DutyItem.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.DutyRequest.DutyItem" %>

<div style="float:left; margin:5px 5px;" title="<%=ToolTip %>" >
    <a href="<%=alink%>" class="list <%=BackGroundColor%> <%=ForeGroundColor%> ">
        <div class="list-content">
            <asp:Image ID="Image1" runat="server" CssClass="icon" />
            
            <div class="data">
                <span class="list-title">Duty On: <asp:Label ID="lblDate" runat="server" Text="date"/></span>
                <span class="list-remark"><asp:Label ID="lblSatellite" runat="server" Text="Satellite"/></span>
                <span class="list-remark"><asp:Label ID="lblName" runat="server" Text="Name"/></span>
                <span class="list-remark"><span class="icon-phone"></span> <asp:Label ID="lblPhone" runat="server" Text="Phone"/></span>
            </div>
        </div>
    </a>

    <asp:Panel ID="PanelDebug" runat="server" Visible="false">
        <asp:Label ID="gPatronid" runat="server" Text="" />
        <asp:Label ID="gReqId" runat="server" Text="0" />
        <asp:Label ID="gDutyTypeId" runat="server" Text="0" />
        <asp:Label ID="gDutyId" runat="server" Text="0" />

        <asp:Label ID="gBgColor" runat="server" Text="bg-darkRed"/>
        <asp:Label ID="gFgColor" runat="server" Text="fg-yellow"/>
        <asp:Label ID="gAlink" runat="server" Text="#" />
        <asp:Label ID="gToolTip" runat="server"/>
    </asp:Panel>
</div>