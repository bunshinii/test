<%@ Page Title="Edit Own Information" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="UserEditor.aspx.vb" Inherits="Rdms_Metro.UserEditor1" %>

<%@ Register Src="~/MyControls/Rdms/Admin/UserEditor.ascx" TagPrefix="nas" TagName="UserEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Forms.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <nas:UserEditor runat="server" id="UserEditor1" />
</asp:Content>