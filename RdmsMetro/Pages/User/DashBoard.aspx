<%@ Page Title="DashBoard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="DashBoard.aspx.vb" Inherits="Rdms_Metro.DashBoard" %>

<%@ Register Src="~/MyControls/Rdms/User/DutyRequest/Legend.ascx" TagPrefix="nas" TagName="Legend" %>
<%@ Register Src="~/MyControls/Rdms/User/Dashboard/Panel/DutyChangeRequest.ascx" TagPrefix="nas" TagName="DutyChangeRequest" %>
<%@ Register Src="~/MyControls/Rdms/User/Dashboard/Panel/Notification.ascx" TagPrefix="nas" TagName="Notification" %>
<%@ Register Src="~/MyControls/Rdms/User/Dashboard/Panel/Announcement.ascx" TagPrefix="nas" TagName="Announcement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/CheckIn.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <h1><span class="icon-meter-fast"></span> <%=Title%></h1>
     <hr /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="PanelAnnouncement" runat="server">
        <nas:Announcement runat="server" ID="Announcement1" />
    </asp:Panel>

    <asp:UpdatePanel ID="upDutyChangeRequest" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <nas:DutyChangeRequest runat="server" id="DutyChangeRequest1" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upNotification" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <nas:Notification runat="server" id="Notification1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    


</asp:Content>
