<%@ Page Title="Patron Search" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="PatronSearch.aspx.vb" Inherits="Rdms_Metro.PatronSearch" %>

<%@ Register Src="~/MyControls/Rdms/User/CheckIn/Search/Container.ascx" TagPrefix="nas" TagName="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/CheckIn.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelMain" runat="server" CssClass="main">
    <h1><span class="icon-search"></span> <%=Title%></h1>
    <hr /><br />

        <div style="margin:50px 0 30px 50px;">
            <nas:Search runat="server" id="Search1" />

        </div>
        

    </asp:Panel>

</asp:Content>
