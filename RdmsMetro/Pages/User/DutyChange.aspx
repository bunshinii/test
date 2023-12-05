<%@ Page Title="Duty Change Request" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="DutyChange.aspx.vb" Inherits="Rdms_Metro.DutyChange" %>

<%@ Register Src="~/MyControls/Rdms/User/Staff.ascx" TagPrefix="nas" TagName="Staff" %>
<%@ Register Src="~/MyControls/Rdms/User/Search.ascx" TagPrefix="nas" TagName="Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/")%>Content/DutyCalendar.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%=Title%> <span class="icon-calendar"></span></h1>
    <h2>On <u><i><%=dutydate%></i></u></h2>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel ID="PanelDesc" runat="server">
        <h3>Duty Description</h3>
        <div style="padding-left:20px;">
            <ul>
                <li><asp:Label ID="lblDutyTypeName" runat="server" Text="None"/> : <asp:Label ID="lblDutyTypeDesc" runat="server" Text="None"/></li>
                <li><asp:Label ID="lblLocation" runat="server" Text="None"/>, <asp:Label ID="lblBranch" runat="server"/></li>
            </ul>
        </div>
    </asp:Panel>
    <br />

    <asp:Panel ID="PanelDuty" runat="server" Width="100%">
        <h3>Staff On Duty</h3>
        <div style="padding-left:20px;">
            <nas:Staff runat="server" ID="Staff1" />
        </div>
    </asp:Panel>
    <div style="clear:both"><br /></div>

    <asp:Panel ID="PanelReciever" runat="server" Visible="false" Width="100%">
        <h3>Request Sent To</h3>
        <div style="padding-left:20px;">
            <asp:PlaceHolder ID="phReceived" runat="server"></asp:PlaceHolder>
            <div style="clear:both"></div>
            Status : <asp:Label ID="lblStatus" runat="server" Text="Waiting Response.." ForeColor="Green" Font-Bold="true"></asp:Label>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel Request" CausesValidation="false" />
        </div>
    </asp:Panel>
    <div style="clear:both"><br /></div>

    <asp:Panel ID="PanelRequest" runat="server">
        <h3>Send Request To</h3>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <nas:Search runat="server" id="Search1" />
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </asp:Panel>

    

    



</asp:Content>
