<%@ Page Title="Add Duty Task" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="DutySearch.aspx.vb" Inherits="Rdms_Metro.DutySearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Admin/UserSearchInternal/Container.ascx" TagPrefix="nas" TagName="SearchInternal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage,Search User For Duty" UrlArray=",~/Pages/Admin" />
    </nas:Breadcrumb>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1><%=Title%> <span class="icon-calendar"></span> </h1>
    <h3>on <asp:Label ID="lblDate" runat="server"></asp:Label></h3>
    <hr /><br />

    <h2><asp:Label ID="lblSatellite" runat="server"></asp:Label></h2>
    <br />

        
        <div style="margin:50px 0 30px 50px;">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <nas:SearchInternal runat="server" id="SearchInternal1" />

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