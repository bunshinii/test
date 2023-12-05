<%@ Page Title="Branch Announcement" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="BranchEdit.aspx.vb" Inherits="Rdms_Metro.BranchEdit" %>

<%@ Register Src="~/MyControls/Rdms/Announcement/BranchEditor.ascx" TagPrefix="nas" TagName="BranchEditor" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Application,Announcement,Branch" UrlArray=",,~/Pages/Admin/Application/Announcement/Announcement.aspx,~/Pages/Admin/Application/Announcement/BranchEdit.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-broadcast"></span> <%=Title%></h1>
    <hr />
    <nas:BranchEditor runat="server" ID="BranchEditor1" />

</asp:Content>
