<%@ Page Title="Edit User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="UserEditor.aspx.vb" Inherits="Rdms_Metro.UserEditor" %>

<%@ Register Src="~/MyControls/Rdms/Admin/UserEditor.ascx" TagPrefix="nas" TagName="UserEditor" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Forms.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Search User,Edit User" UrlArray=",~/Pages/Admin/UserSearchInternal.aspx">
    </nas:Breadcrumb>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr />
    <nas:UserEditor runat="server" id="UserEditor1" />
</asp:Content>
