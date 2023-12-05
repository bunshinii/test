<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="CodeTemplates.aspx.vb" Inherits="Rdms_Metro.CodeTemplates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" />
            <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

