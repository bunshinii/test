<%@ Page Title="Staff On Duty" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="OnDate.aspx.vb" Inherits="Rdms_Metro.OnDate" %>

<%@ Register Src="~/MyControls/Rdms/DutyCalendar/DutyTypeNote/DutyTypeNotes.ascx" TagPrefix="nas" TagName="DutyTypeNotes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DutyCalendar.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><%=Title%> <span class="icon-calendar"></span></h1>
    <h2>on <b><i><asp:Label ID="lblDate" runat="server" CssClass="fg-darkOrange"/></i></b></h2>
    <hr />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width:100%;">
        <tr>
            <td style="text-align:left; width:100px;"><button class="primary" runat="server" id="btnPrev1"><i class="icon-previous on-left"></i>Previous</button></td>
            <td style="text-align:center;"><button class="warning" id="btnMonthly" runat="server">Monthly Calendar</button></td>
            <td style="text-align:right; width:100px;"><button class="primary" id="btnNext1" runat="server">Next<i class="icon-next on-right"></i></button></td>
        </tr>
    </table>

    <br />
    <h2><asp:Label ID="lblSatellite" runat="server"></asp:Label></h2>
    <br />

    <asp:PlaceHolder ID="phDuty" runat="server"></asp:PlaceHolder>
    <asp:Label ID="lblMessage" runat="server" Text="No staf on duty." Visible="false"></asp:Label>

    <div style="clear:both"></div>

    <asp:Panel ID="PanelAdmin" runat="server" Visible="false">
        
        <div style="margin:20px 40px;">
            <button runat="server" id="btnAdd" class="button large success"> 
                <span class="icon-plus-2"></span> &nbsp; Add Staff on this Date
            </button>
        </div>
    <div style="clear:both"></div>
    </asp:Panel>

    <asp:Panel ID="PanelNotes" runat="server">
        <div = style="clear:both"></div>
        <br /><br /><br />
        <h4>Duty Note : </h4>
        <div style="font-size:12px; color:gray;">
            <nas:DutyTypeNotes runat="server" ID="DutyTypeNotes" />
        </div>

        <div = style="clear:both"></div>
        <br /><br /><br />
    </asp:Panel>

    
</asp:Content>
