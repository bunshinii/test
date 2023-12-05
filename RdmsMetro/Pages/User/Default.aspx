<%@ Page Title="Account Setting" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Default.aspx.vb" Inherits="Rdms_Metro._Default3" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <nas:breadcrumb id="Breadcrumb1" runat="server" namearray="User,Setting,Snippet" urlarray=",~/Pages/User/Default.aspx,~/Pages/User/Snippet.aspx">
</nas:breadcrumb>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-cog"></span> <%=Title%></h1>
    <hr />

<h2>Select Type</h2><br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Password.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-key"></span> &nbsp; Change Password
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pages/User/UserEditor.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-info"></span> &nbsp; Edit Information
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Pages/User/Snippet.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-comments-5"></span> &nbsp; Manage Snippet
        </div>
    </div>
</asp:HyperLink>
</asp:Content>
