﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.CheckIn.Search.Item" %>

<div style="float:left; margin:5px 5px;" title="<%=ToolTip%>" >
    <a href="<%=ResolveUrl("~/Pages/User/PatronCheckIn.aspx?patronid=")%><%=PatronId%>&sessionid=<%=NewSessionId%>" class="list <%=BackgroundColor%> fg-white">
        <div class="list-content">
            <asp:Image ID="Image1" runat="server" ImageUrl="http://localhost/Images/Default.ashx?patronid=0" CssClass="icon" />
            
            <div class="data">
                <span class="list-title"><asp:Label ID="lblName" runat="server" Text="Full Name"/></span>
                <span class="list-remark"><asp:Label ID="lblFaculty" runat="server" Text="Faculty"/></span>
                <span class="list-remark"><asp:Label ID="lblProgram" runat="server" Text="Programme"/></span>
                <span class="list-remark"><asp:Label ID="lblPatronId" runat="server" Text="PatronId"/></span>
            </div>
        </div>
    </a>

    <asp:Panel ID="PanelDebug" runat="server" Visible="false">
        <asp:Label ID="gBgColor" runat="server" Text="bg-darkRed"/>
        <asp:Label ID="gToolTip" runat="server"/>
    </asp:Panel>
</div>