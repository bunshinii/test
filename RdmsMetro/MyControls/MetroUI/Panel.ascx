<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Panel.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.Panel" %>
<%@ Register Src="~/MyControls/MetroUI/Icons.ascx" TagPrefix="uc1" TagName="Icons" %>
<%@ Register Src="~/MyControls/MetroUI/ListView/OutlookStyle/SimpleContainer.ascx" TagPrefix="nas" TagName="SimpleContainer" %>



<div class="panel" data-role="panel">
    <div class="panel-header">
        <asp:Image ID="imgRss" runat="server" ImageUrl="~/Images/rss.png" /> <strong>Activity Feed</strong>
    </div>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div style="width:100%; text-align:center">
                <asp:Button ID="btnWarning1" runat="server" Text="Fetching RSS Feeds.." CssClass="button warning" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>

            <asp:Panel ID="PanelWait" runat="server">
                <div style="width:100%; text-align:center">
                    <asp:Button ID="btnWarning2" runat="server" Text="Please wait" CssClass="button warning" />
                </div>
            </asp:Panel>

            <div class="panel-content">
                <nas:SimpleContainer runat="server" id="SimpleContainer" />
            </div>
            <div class="warning">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
            </div>

            <table style="width:100%">
                <tr>
                    <td style="text-align:left">
                        <asp:Button ID="btnRefresh2" runat="server" Text="Refresh" CssClass="button info" />
                    </td>
                    <td style="text-align:right">
                        <asp:Button ID="btnMore" runat="server" Text="More" CssClass="button info" />
                    </td>
                </tr>
                
            </table>

            <asp:Timer ID="Timer1" runat="server" Enabled="false" Interval="500" />

        </ContentTemplate>
    </asp:UpdatePanel>
    
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBranchId" runat="server" Text="0"/>
</asp:Panel>
