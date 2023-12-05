<%@ Page Title="Edit Checked In" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="EditCheckedIn.aspx.vb" Inherits="Rdms_Metro.EditCheckedIn" %>
<%@ Register Src="~/MyControls/Rdms/Tables/EditCheckedIn/Container.ascx" TagPrefix="nas" TagName="TableCheckedIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-user"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="nastable">
        <nas:TableCheckedIn runat="server" id="TableCheckedIn1" IsFinished="true" IsKiv="false" />
    </div>
</asp:Content>