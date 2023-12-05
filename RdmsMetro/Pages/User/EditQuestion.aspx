<%@ Page Title="Edit Questions" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="EditQuestion.aspx.vb" Inherits="Rdms_Metro.EditQuestion" %>

<%@ Register Src="~/MyControls/MetroUI/FluentMenu/ContainerEditor.ascx" TagPrefix="nas" TagName="Ribbon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-comments-4"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <nas:Ribbon runat="server" ID="Ribbon1" />
</asp:Content>
