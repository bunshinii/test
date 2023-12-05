<%@ Page Title="Satellite Announcement" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="SatelliteEdit.aspx.vb" Inherits="Rdms_Metro.SatelliteEdit" %>

<%@ Register Src="~/MyControls/Rdms/Announcement/SatelliteEditor.ascx" TagPrefix="nas" TagName="SatelliteEditor" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Application,Announcement,Satellite" UrlArray=",,~/Pages/Admin/Application/Announcement/Announcement.aspx,~/Pages/Admin/Application/Announcement/SatelliteEdit.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-broadcast"></span> <%=Title%></h1>
    <hr />
    <nas:SatelliteEditor runat="server" ID="SatelliteEditor1" />
</asp:Content>
