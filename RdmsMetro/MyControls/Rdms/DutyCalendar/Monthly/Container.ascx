<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.Monthly.Container" %>



<asp:Panel ID="Panel1" runat="server" CssClass="mycalendar">

    <table style="width:100%;">
        <tr>
            <td style="text-align:left; width:100px;"><button class="primary" runat="server" id="btnPrev1"><i class="icon-previous on-left"></i>Previous</button></td>
            <td style="text-align:center;"><h2><strong><asp:Label ID="lblMonthName" runat="server" Text="1" CssClass="fg-darkOrange" /> <asp:Label ID="lblYear" runat="server" Text="2000" CssClass="fg-darkOrange" /></strong></h2></td>
            <td style="text-align:right; width:100px;"><button class="primary" id="btnNext1" runat="server">Next<i class="icon-next on-right"></i></button></td>
        </tr>
    </table>
    
    <table class="monthly">
        <tr class="header">
            <td>
                Sunday
            </td>
            <td>
                Monday
            </td>
            <td>
                Tuesday
            </td>
            <td>
                Wednesday
            </td>
            <td>
                Thursday
            </td>
            <td>
                Friday
            </td>
            <td>
                Saturday
            </td>
        </tr>
        <tr class="w1">
            <td class="content sun">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </td>
            <td class="content mon">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server" />
            </td>
            <td class="content tue">
                <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
            </td>
            <td class="content wed">
                <asp:PlaceHolder ID="PlaceHolder4" runat="server" />
            </td>
            <td class="content thu">
                <asp:PlaceHolder ID="PlaceHolder5" runat="server" />
            </td>
            <td class="content fri">
                <asp:PlaceHolder ID="PlaceHolder6" runat="server" />
            </td>
            <td class="content sat">
                <asp:PlaceHolder ID="PlaceHolder7" runat="server" />
            </td>
        </tr>
        <tr class="w2">
            <td class="content sun">
                <asp:PlaceHolder ID="PlaceHolder8" runat="server" />
            </td>
            <td class="content mon">
                <asp:PlaceHolder ID="PlaceHolder9" runat="server" />
            </td>
            <td class="content tue">
                <asp:PlaceHolder ID="PlaceHolder10" runat="server" />
            </td>
            <td class="content wed">
                <asp:PlaceHolder ID="PlaceHolder11" runat="server" />
            </td>
            <td class="content thu">
                <asp:PlaceHolder ID="PlaceHolder12" runat="server" />
            </td>
            <td class="content fri">
                <asp:PlaceHolder ID="PlaceHolder13" runat="server" />
            </td>
            <td class="content sat">
                <asp:PlaceHolder ID="PlaceHolder14" runat="server" />
            </td>
        </tr>
        <tr class="w3">
            <td class="content sun">
                <asp:PlaceHolder ID="PlaceHolder15" runat="server" />
            </td>
            <td class="content mon">
                <asp:PlaceHolder ID="PlaceHolder16" runat="server" />
            </td>
            <td class="content tue">
                <asp:PlaceHolder ID="PlaceHolder17" runat="server" />
            </td>
            <td class="content wed">
                <asp:PlaceHolder ID="PlaceHolder18" runat="server" />
            </td>
            <td class="content thu">
                <asp:PlaceHolder ID="PlaceHolder19" runat="server" />
            </td>
            <td class="content fri">
                <asp:PlaceHolder ID="PlaceHolder20" runat="server" />
            </td>
            <td class="content sat">
                <asp:PlaceHolder ID="PlaceHolder21" runat="server" />
            </td>
        </tr>
        <tr class="w4">
            <td class="content sun">
                <asp:PlaceHolder ID="PlaceHolder22" runat="server" />
            </td>
            <td class="content mon">
                <asp:PlaceHolder ID="PlaceHolder23" runat="server" />
            </td>
            <td class="content tue">
                <asp:PlaceHolder ID="PlaceHolder24" runat="server" />
            </td>
            <td class="content wed">
                <asp:PlaceHolder ID="PlaceHolder25" runat="server" />
            </td>
            <td class="content thu">
                <asp:PlaceHolder ID="PlaceHolder26" runat="server" />
            </td>
            <td class="content fri">
                <asp:PlaceHolder ID="PlaceHolder27" runat="server" />
            </td>
            <td class="content sat">
                <asp:PlaceHolder ID="PlaceHolder28" runat="server" />
            </td>
        </tr>
        <tr class="w5">
            <td class="content sun">
                <asp:PlaceHolder ID="PlaceHolder29" runat="server" />
            </td>
            <td class="content mon">
                <asp:PlaceHolder ID="PlaceHolder30" runat="server" />
            </td>
            <td class="content tue">
                <asp:PlaceHolder ID="PlaceHolder31" runat="server" />
            </td>
            <td class="content wed">
                <asp:PlaceHolder ID="PlaceHolder32" runat="server" />
            </td>
            <td class="content thu">
                <asp:PlaceHolder ID="PlaceHolder33" runat="server" />
            </td>
            <td class="content fri">
                <asp:PlaceHolder ID="PlaceHolder34" runat="server" />
            </td>
            <td class="content sat">
                <asp:PlaceHolder ID="PlaceHolder35" runat="server" />
            </td>
        </tr>
    </table>

<hr />
<div class="legend">
    <h2>Legend</h2>
    <div style="margin:auto;">
        <asp:PlaceHolder ID="phLegend" runat="server" />
    </div>
</div>
</asp:Panel>



<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gMonthNo" runat="server" Text="1" />
    <asp:Label ID="gSatInit" runat="server" />
</asp:Panel>