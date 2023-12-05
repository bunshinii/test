<%@ Page Title="Manage Branch" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Branch.aspx.vb" Inherits="Rdms_Metro.Branch" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Branch/Container.ascx" TagPrefix="nas" TagName="BranchTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Organization,Manage Branch" UrlArray=",~/Pages/Admin/Organization,~/Pages/Admin/Organization/Branch.aspx" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1><span class="icon-grid"></span> <%=Title%></h1>
    <hr />

    <div class="nastable">
        <nas:BranchTable runat="server" id="BranchTable1" />
    </div>


</asp:Content>
