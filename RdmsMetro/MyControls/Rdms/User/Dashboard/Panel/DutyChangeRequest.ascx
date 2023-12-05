<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DutyChangeRequest.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.Dashboard.Panel.DutyChangeRequest" %>

    <div class="panel <%=PanelCollapse_%>" data-role="panel">
        <div class="panel-header bg-darkCyan fg-white">
            Duty Change Request <b><%=ShowCountStr%></b>
        </div>
        <div class="panel-content" <%=PanelCollapseDisplayNone_%>>
            <div class="listview">
                <div style="clear:both">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label></div><hr />
                    <asp:Panel ID="PanelContentItem" runat="server">
                        <%-- START TO DO HERE --%>


                        <div style="clear:both">Legend: <br /><br />
                            <asp:PlaceHolder ID="phDutyType" runat="server"></asp:PlaceHolder>
                        </div>
                
                        <div style="clear:both"><br /></div>
                        <asp:PlaceHolder ID="phRequestRec" runat="server"></asp:PlaceHolder>


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