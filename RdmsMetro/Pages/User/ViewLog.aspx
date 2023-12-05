<%@ Page Title="View Logs" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="ViewLog.aspx.vb" Inherits="Rdms_Metro.ViewLog" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Log/Container.ascx" TagPrefix="nas" TagName="Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-file-4"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="nastable">
        <nas:Log runat="server" id="Log1" />
    </div>
</asp:Content>
