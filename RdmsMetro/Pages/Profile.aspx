<%@ Page Title="User Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Profile.aspx.vb" Inherits="Rdms_Metro.Profile" %>

<%@ Register Src="~/MyControls/Rdms/Profile/Container.ascx" TagPrefix="nas" TagName="Container" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/")%>Content/Profile.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-user-2"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <div style="margin-left:20px;display: inline-block; text-align:left;">
            <nas:Container runat="server" id="Container1" />
        </div>
    
</asp:Content>
