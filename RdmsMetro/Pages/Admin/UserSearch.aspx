<%@ Page Title="Register User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="UserSearch.aspx.vb" Inherits="Rdms_Metro.UserSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/MyControls/Rdms/Admin/UserSearchDBLibrary/Container.ascx" TagPrefix="nas" TagName="Container" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage,Search User" UrlArray=",~/Pages/Admin,~/Pages/Admin/UserSearch.aspx" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr />

        <div style="margin:50px 0 30px 50px;">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <nas:Container runat="server" id="Container" />

            </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
        


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server"  CssClass="notification" />
            <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>