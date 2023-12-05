<%@ Page Title="Monthly Chart" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Monthly.aspx.vb" Inherits="Rdms_Metro.Monthly1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/MyControls/Rdms/Reports/MonthlyOption.ascx" TagPrefix="nas" TagName="MonthlyOption" %>
<%@ Register Src="~/MyControls/Rdms/Charts/ByMonthHourly.ascx" TagPrefix="nas" TagName="HourlyMonth" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Chart.min.css")%>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-chart-alt"></span> <%=Title%></h1>
    <hr />

    <asp:Panel ID="PanelNoPrint" runat="server">
        <nas:MonthlyOption runat="server" ID="MonthlyOption1" VirtualRedirectPath="~/Pages/User/Chart/Monthly.aspx" />
    </asp:Panel>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    <asp:Panel ID="PanelPrepared" runat="server" HorizontalAlign="Right" Width="100%" Visible="false">
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
