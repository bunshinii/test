<%@ Page Title="Home Page Editor" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="AllEdit.aspx.vb" Inherits="Rdms_Metro.AllEdit" %>

<%@ Register Src="~/MyControls/Rdms/Announcement/AllEditor.ascx" TagPrefix="nas" TagName="AllEditor" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagPrefix="nas" TagName="Breadcrumb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    <nas:Breadcrumb runat="server" id="Breadcrumb1" NameArray="Administrator,Application,Announcement,All" UrlArray=",,~/Pages/Admin/Application/Announcement/Announcement.aspx,~/Pages/Admin/Application/Announcement/AllEdit.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-home"></span> <%=Title%></h1>
    <hr />
    <nas:AllEditor runat="server" id="AllEditor1" />

</asp:Content>
