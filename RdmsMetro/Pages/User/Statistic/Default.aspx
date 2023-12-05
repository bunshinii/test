<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Default.aspx.vb" Inherits="Rdms_Metro._Default4" %>


<%@ Register Src="~/MyControls/Rdms/Reports/DailyOption.ascx" TagPrefix="uc1" TagName="DailyOption" %>
<%@ Register Src="~/MyControls/Rdms/Charts/ByMonthHourly.ascx" TagPrefix="uc1" TagName="ByMonthHourly" %>
<%@ Register Src="~/MyControls/Rdms/Charts/ByMonthWeekly.ascx" TagPrefix="uc1" TagName="ByMonthWeekly" %>
<%@ Register Src="~/MyControls/Rdms/Charts/ByYearHourly.ascx" TagPrefix="uc1" TagName="ByYearHourly" %>
<%@ Register Src="~/MyControls/Rdms/Charts/ByYearMonthly.ascx" TagPrefix="uc1" TagName="ByYearMonthly" %>










<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:DailyOption runat="server" ID="DailyOption" VirtualRedirectPath="~/Pages/User/Statistic/Default.aspx" />
    <uc1:ByMonthHourly runat="server" ID="ByMonthHourly" />
    <uc1:ByMonthWeekly runat="server" ID="ByMonthWeekly" />
    <hr />
    <uc1:ByYearHourly runat="server" ID="ByYearHourly" />
    <uc1:ByYearMonthly runat="server" ID="ByYearMonthly" />
</asp:Content>
