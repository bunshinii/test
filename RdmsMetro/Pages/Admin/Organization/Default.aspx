<%@ Page Title="Manage Organization" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Default.aspx.vb" Inherits="Rdms_Metro._Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:breadcrumb id="Breadcrumb1" runat="server" namearray="Administrator,Organization" urlarray=",~/Pages/Admin/Organization">
    </nas:breadcrumb>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-grid"></span> <%=Title%></h1>
    <hr />

<h2>Select Type</h2><br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Branch.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-grid"></span> &nbsp; Manage Branch
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Satellite.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-grid"></span> &nbsp; Manage Satellite
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Department.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-grid"></span> &nbsp; Manage Department
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="Division.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-grid"></span> &nbsp; Manage Division
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="Unit.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-grid"></span> &nbsp; Manage Unit
        </div>
    </div>
</asp:HyperLink>
</asp:Content>