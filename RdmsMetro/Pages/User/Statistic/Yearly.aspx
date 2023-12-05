<%@ Page Title="Yearly Statistic" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Yearly.aspx.vb" Inherits="Rdms_Metro.Yearly2" %>

<%@ Register Src="~/MyControls/Rdms/Reports/YearlyOption.ascx" TagPrefix="uc1" TagName="YearlyOption" %>
<%@ Register Src="~/MyControls/Rdms/Reports/MessageGeneratorYearly.ascx" TagPrefix="uc1" TagName="MessageGeneratorYearly" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-stats-up"></span> <%=Title%></h1>
    <hr />

    <asp:Panel ID="PanelNoPrint" runat="server">
        <uc1:YearlyOption runat="server" ID="YearlyOption" DisplayHourlyOption="false" DisplayStatisticOption="true" VirtualRedirectPath="~/Pages/User/Statistic/Yearly.aspx" />
    </asp:Panel>
    <uc1:MessageGeneratorYearly runat="server" ID="MessageGeneratorYearly" />
           <br />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>


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
