<%@ Page Title="Manage" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Default.aspx.vb" Inherits="Rdms_Metro._Default2" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage" UrlArray=",~/Pages/Admin" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-grid"></span><%=Title%></h1>
    <hr />

    <h2>Select Type</h2><br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="UserSearch.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-user-3"></span> &nbsp; Register New User
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="UserSearchInternal.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-user-3"></span> &nbsp; Edit User
        </div>
    </div>
</asp:HyperLink>

</asp:Content>
