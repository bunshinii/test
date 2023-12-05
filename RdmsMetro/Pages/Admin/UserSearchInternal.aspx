<%@ Page Title="Edit User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="UserSearchInternal.aspx.vb" Inherits="Rdms_Metro.UserSearchInternal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Admin/UserSearchInternal/Container.ascx" TagPrefix="nas" TagName="Container" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage,Search User" UrlArray=",~/Pages/Admin,~/Pages/Admin/UserSearchInternal.aspx" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr />    

        <div style="margin:50px 0 30px 50px;">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <nas:Container runat="server" id="Container" VirtualPathRedirect="~/Pages/Admin/UserEditor.aspx" />

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