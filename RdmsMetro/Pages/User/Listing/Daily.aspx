﻿<%@ Page Title="Daily Listing" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Daily.aspx.vb" Inherits="Rdms_Metro.Daily" %>

<%@ Register Src="~/MyControls/Rdms/Reports/DailyOption.ascx" TagPrefix="nas" TagName="DailyOption" %>
<%@ Register Src="~/MyControls/Rdms/Reports/ReportsGridView.ascx" TagPrefix="nas" TagName="ReportsGridView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-clipboard-2"></span> <%=Title%></h1>
    <hr />

    <asp:Panel ID="PanelNoPrint" runat="server">
        <nas:DailyOption runat="server" id="DailyOption1"  />
    </asp:Panel>

    <h2>
        <asp:Label ID="lblTopic" runat="server" Text=""></asp:Label></h2>

    <nas:ReportsGridView runat="server" id="ReportsGridView1" />

    <asp:Panel ID="PanelPrepared" runat="server" HorizontalAlign="Right" Width="100%">
        <br /><br /><br /><br />
        <table style="display:inline-block">
            <tr>
                <td style="text-align:left;">
                    Prepared By :
                </td>
            </tr>
            <tr>
                <td>
                    <br /><br /><br /><br />
                    <hr style="border:2px solid black;" />
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <strong><asp:Label ID="lblFullname" runat="server" Text=""></asp:Label></strong><br />
                    <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lblDivision" runat="server" Text=""></asp:Label><br />
                    <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
