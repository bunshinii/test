<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Announcement.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.Dashboard.Panel.Announcement1" %>
<%@ Register Src="~/MyControls/Rdms/Announcement/Branch.ascx" TagPrefix="nas" TagName="Branch" %>
<%@ Register Src="~/MyControls/Rdms/Announcement/Satellite.ascx" TagPrefix="nas" TagName="Satellite" %>




<div class="panel <%=PanelCollapse_%>" data-role="panel">
        <div class="panel-header bg-darkCyan fg-white">
            Announcement <b><%=ShowCountStr%></b>
        </div>
        <div class="panel-content" <%=PanelCollapseDisplayNone_%>>
            <div class="listview">
                <div style="clear:both">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label></div><hr />
                    <asp:Panel ID="PanelContentItem" runat="server" ScrollBars="Auto" Height="200px">
                        <%-- START TO DO HERE --%>

                            <nas:Satellite runat="server" ID="Satellite1" />
                            <nas:Branch runat="server" ID="Branch1" />
                       
                        <%-- END  TO DO HERE --%>
                    </asp:Panel>
                <div style="clear:both"></div>
            </div>
        
        </div>
    </div>

    <asp:Panel ID="PanelDebug" runat="server" Visible="false">
        <asp:Label ID="gCount" runat="server" Text="0" />
        <asp:Label ID="gPanelCollapse" runat="server" Text="" />
        <asp:Label ID="gPanelCollapseDisplayNone" runat="server" Text="" />
    </asp:Panel>