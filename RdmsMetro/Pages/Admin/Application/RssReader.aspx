<%@ Page Title="Feed Reader" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="RssReader.aspx.vb" Inherits="Rdms_Metro.RssReader" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagPrefix="nas" TagName="Breadcrumb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb runat="server" id="Breadcrumb1" NameArray="Administrator,Application,Announcement" UrlArray=",,~/Pages/Admin/Application/Announcement/Announcement.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-feed"></span> <%=Title%></h1>
    <hr />
</asp:Content>
