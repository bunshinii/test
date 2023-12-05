<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Header.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.Header" %>

    <div class="navigation-bar-content container">
        
        <a href="<%=ResolveUrl("~/")%>" class="element" style="vertical-align:top; width:250px;">

            <div style="width:41px; margin:-12px 0 0 -10px; float:left"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/rdms_dark.png" /></div>
            <div style="width:180px; margin-top:-12px; padding:5px 0 0 10px; float:left; font-size:16px; font-weight:bold;">Reference Desk Management System</div></a>

        <span class="element-divider"></span>

        <a class="element1 pull-menu" href="#"></a>
        <ul class="element-menu">
            <li>
                <a href="<%=ResolveUrl("~/")%>"><span class="icon-home"></span> Home </a>
            </li>
            
            <li id="liCalendar" runat="server">
                <a class="dropdown-toggle"  href="#"><span class="icon-calendar"></span> Staff On Duty </a>
                <ul class="dropdown-menu dark" data-role="dropdown">
                    <li><asp:HyperLink ID="hlToday" runat="server" NavigateUrl="~/">Today</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlMonth" runat="server" NavigateUrl="~/">This Month</asp:HyperLink></li>
                </ul>
            </li>

            <li>
                <a class="dropdown-toggle"  href="#"><span class="icon-user-3"></span> Contact Us </a>
                <ul class="dropdown-menu dark" data-role="dropdown">
                    <li><a href="tiles.html">Library Staff</a></li>
                </ul>
            </li>
        </ul>

        <div class="no-tablet-portrait no-phone">
            
            <div class="element place-right">
                <a class="dropdown-toggle" href="#">
                    <span class="icon-cog"></span>
                </a>
                <ul class="dropdown-menu place-right" data-role="dropdown">
                    <li><a href="#"><asp:HyperLink ID="hlSetting" runat="server" NavigateUrl="~/Pages/User/Default.aspx">Setting</asp:HyperLink></a></li>
                    <li><asp:LoginStatus ID="LoginStatus1" runat="server" /></li>
                </ul>
            </div>
        
            <span class="element-divider place-right"></span>
            <button class="element image-button image-left place-right">
                <asp:Panel ID="PanelUser" runat="server">
                    <span style="overflow:hidden"><asp:Label ID="lblFullname" runat="server" /></span>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UserDefault.jpg" CssClass="place-right profile-img" /> 
                </asp:Panel>
            </button>
        </div>
    </div>
