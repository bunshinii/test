<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Item.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.Monthly.Item" %>

<table class="item">
    <tr>
        <td>
            <asp:Panel ID="PanelHeader" runat="server" CssClass="itemHeader">
                <asp:Label ID="lblDate" runat="server" Text="1"/>
                <div class="btnGo" title="Go to Date">
                    <asp:HyperLink ID="hlGotoDate" runat="server" NavigateUrl="~/Pages/Duty/OnDate.aspx">
                        <span class="icon-enter"></span>
                    </asp:HyperLink>
                </div>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <div class="itemContentOuter">
            <asp:Panel ID="PanelContent1" runat="server" CssClass="itemContent">

                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </asp:Panel>
            </div>
        </td>
    </tr>
</table>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gDate" runat="server" />
</asp:Panel>
