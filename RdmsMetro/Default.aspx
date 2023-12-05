<%@ Page Title="Reference Desk Management System" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Default.aspx.vb" Inherits="Rdms_Metro._Default" %>

<%@ Register Src="~/MyControls/Rdms/Announcement/All.ascx" TagPrefix="nas" TagName="All" %>
<%@ Register Src="~/MyControls/Rdms/Announcement/Branch.ascx" TagPrefix="nas" TagName="Branch" %>
<%@ Register Src="~/MyControls/Rdms/Announcement/Satellite.ascx" TagPrefix="nas" TagName="Satellite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DutyCalendar.min.css")%>" rel="stylesheet" />
    <link href="<%=ResolveUrl("~/Content/FrontPage.min.css")%>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        <h1>Reference Desk Management System</h1>
        <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        
    <asp:Panel ID="PanelSelectSatellite" runat="server">

        <div class="columning">
            <h2>Select Your Branch</h2>
            <ol class="round">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"/>
            </ol>
        </div>

    </asp:Panel>

    <asp:Panel ID="PanelSatelliteView" runat="server">
        <h1><asp:Label ID="lblSatelliteName" runat="server" /></h1>

        <table style="width:100%;">
            <tr>
                <td  style="vertical-align:top;">
                    <nas:Satellite runat="server" id="Satellite1" />
                    <nas:Branch runat="server" id="Branch1" />
                    <nas:All runat="server" id="All1" />
                    <div style="clear:both;"></div>

                    <br />
                    <h3>Todays Staff On Duty</h3>
                    <asp:PlaceHolder ID="phDuty" runat="server"/>
                    <div style="clear:both;"></div>

                    <div style="padding-left:10px; padding-bottom:100px; color:cornflowerblue;">
                        <span class="icon-calendar"></span> <asp:HyperLink ID="hlCalendar" runat="server" NavigateUrl="~/">View Staff On Duty..</asp:HyperLink>
                    </div>
                    
                </td>
                <td  class="right-panel">
                    <div class="rss">
                        
                                <asp:PlaceHolder ID="phRss" runat="server"/>
                        
                    </div>
                </td>
            </tr>
        </table>

    </asp:Panel>

</asp:Content>