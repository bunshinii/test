<%@ Page Title="Announcement" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Announcement.aspx.vb" Inherits="Rdms_Metro.Announcement" %>

<%@ Register Src="~/MyControls/Rdms/Announcement/SatelliteEditor.ascx" TagPrefix="nas" TagName="SatelliteEditor" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagPrefix="nas" TagName="Breadcrumb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb runat="server" id="Breadcrumb1" NameArray="Administrator,Application,Announcement" UrlArray=",,~/Pages/Admin/Application/Announcement/Announcement.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-broadcast"></span> <%=Title%></h1>
    <hr />
    
<h2>Select Announcement Type</h2><br />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/Admin/Application/Announcement/AllEdit.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-broadcast"></span> &nbsp; Announcement Broadcast to All (Home Page)
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pages/Admin/Application/Announcement/BranchEdit.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-broadcast"></span> &nbsp; Announcement Broadcast to Branch
        </div>
    </div>
</asp:HyperLink>

<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Pages/Admin/Application/Announcement/SatelliteEdit.aspx">
    <div style="margin:20px 40px;">
        <div class="button large primary" style="width:420px; text-align:left"> 
            <span class="icon-broadcast"></span> &nbsp; Announcement Broadcast to Satellite
        </div>
    </div>
</asp:HyperLink>

</asp:Content>
