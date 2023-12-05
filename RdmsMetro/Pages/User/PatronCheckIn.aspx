<%@ Page Title="Duty Calendar" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="PatronCheckIn.aspx.vb" Inherits="Rdms_Metro.PatronCheckIn" %>

<%@ Register Src="~/MyControls/MetroUI/FluentMenu/Container.ascx" TagPrefix="nas" TagName="Ribbon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1><span class="icon-user"></span> <%=Title%></h1>
    <hr /><br />
    <nas:Ribbon runat="server" ID="Ribbon1" />
</asp:Content>
