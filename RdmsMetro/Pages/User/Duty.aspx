<%@ Page Title="On Duty Calendar" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Duty.aspx.vb" Inherits="Rdms_Metro.Duty" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/MyControls/Rdms/Tables/DutyCalendar/Container.ascx" TagPrefix="nas" TagName="DutyTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-calendar"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" CssClass="notification" />
            <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <div class="nastable">
        <nas:DutyTable runat="server" id="DutyTable1" />
    </div>

</asp:Content>
