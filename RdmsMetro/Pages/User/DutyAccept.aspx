<%@ Page Title="Accept Duty Schedule" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="DutyAccept.aspx.vb" Inherits="Rdms_Metro.DutyAccept" %>

<%@ Register Src="~/MyControls/Rdms/User/Staff.ascx" TagPrefix="nas" TagName="Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/")%>Content/DutyCalendar.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%=Title%> <span class="icon-calendar"></span></h1>
    <h2>Accept Duty Request on <u><i><%=dutydate%></i></u></h2>
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
        <h3>Requested By</h3>
        <div style="padding-left:20px;">
            <nas:Staff runat="server" ID="Staff1" />

            <div style="padding-left:10px; clear:both"><br />
                <button runat="server" id="btnAccept" class="button success"><i class="icon-thumbs-up on-left"></i>Accept</button>
                <button runat="server" id="btnReject" class="button danger"><i class="icon-thumbs-down on-left"></i>Reject</button>
            </div>

            
        </div>
    </asp:Panel>
    


</asp:Content>
