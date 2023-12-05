<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Calendar.aspx.vb" Inherits="Rdms_Metro.Calendar" %>

<%@ Register Src="~/MyControls/Rdms/DutyCalendar/Monthly/Container.ascx" TagPrefix="nas" TagName="Container" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Calendar.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-calendar"></span> <asp:Label ID="lblSattellite" runat="server" /></h1>
    <hr />
    <h2>Staff Duty Calendar</h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <nas:Container runat="server" id="MonthlyContainer1"/>
</asp:Content>
