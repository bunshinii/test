<%@ Page Title="KIV Listing" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="EditKiv.aspx.vb" Inherits="Rdms_Metro.EditKiv" %>
<%@ Register Src="~/MyControls/Rdms/Tables/EditCheckedIn/Container.ascx" TagPrefix="nas" TagName="TableKiv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-user"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <div class="nastable">
        <nas:TableKiv runat="server" id="TableKiv1" IsKiv="true" IsFinished="false"/>
    </div>
</asp:Content>