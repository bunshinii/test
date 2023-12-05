<%@ Page Title="Custom Check-In" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="PatronCheckInCustom.aspx.vb" Inherits="Rdms_Metro.PatronCheckInCustom" %>

<%@ Register Src="~/MyControls/MetroUI/FluentMenu/ContainerCustom.ascx" TagPrefix="nas" TagName="Ribbon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-user-2"></span> Custom Check-In</h1>
    <hr /><br />
    <nas:Ribbon runat="server" id="Ribbon1" />
</asp:Content>
