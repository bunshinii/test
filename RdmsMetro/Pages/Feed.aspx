<%@ Page Title="Activity Feeds" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Feed.aspx.vb" Inherits="Rdms_Metro.Feed" %>

<%@ Register Src="~/MyControls/MetroUI/ListView/OutlookStyle/SimpleContainer.ascx" TagPrefix="nas" TagName="SimpleContainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-feed"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <nas:SimpleContainer runat="server" ID="SimpleContainer" />
</asp:Content>
