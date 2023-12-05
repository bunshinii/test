<%@ Page Title="Yearly Listing" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Yearly.aspx.vb" Inherits="Rdms_Metro.Yearly" %>

<%@ Register Src="~/MyControls/Rdms/Reports/YearlyOption.ascx" TagPrefix="nas" TagName="YearlyOption" %>
<%@ Register Src="~/MyControls/Rdms/Reports/ReportsGridView.ascx" TagPrefix="nas" TagName="ReportsGridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-clipboard-2"></span> <%=Title%></h1>
    <hr />

    <asp:Panel ID="PanelNoPrint" runat="server">
        <nas:YearlyOption runat="server" id="YearlyOption1" DisplayHourlyOption="false" />
    </asp:Panel>

    <h2>
        <asp:Label ID="lblTopic" runat="server" Text=""></asp:Label></h2>

    <nas:ReportsGridView runat="server" id="ReportsGridView" />

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
