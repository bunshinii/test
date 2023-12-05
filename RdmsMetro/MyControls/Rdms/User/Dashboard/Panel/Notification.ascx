<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Notification.ascx.vb" Inherits="Rdms_Metro.Notification" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Notification/Container.ascx" TagPrefix="nas" TagName="Container" %>


<div class="panel <%=PanelCollapse_%>" data-role="panel">
        <div class="panel-header bg-darkCyan fg-white">
            Notification <b><%=ShowCountStr%></b>
        </div>
        <div class="panel-content" <%=PanelCollapseDisplayNone_%>>
            <div class="listview">
                <div style="clear:both"></div>
                    <asp:Label ID="lblStatus" runat="server"></asp:Label><hr />
                    <asp:Panel ID="PanelContentItem" runat="server" Height="200px" ScrollBars="Auto">
                        <%-- START TO DO HERE --%>


                        <nas:Container runat="server" id="Container1" />


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