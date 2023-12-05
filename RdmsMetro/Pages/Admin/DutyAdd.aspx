<%@ Page Title="Add Duty Task" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="DutyAdd.aspx.vb" Inherits="Rdms_Metro.DutyAdd" %>

<%@ Register Src="~/MyControls/Rdms/User/Picture.ascx" TagPrefix="nas" TagName="Picture" %>
<%@ Register Src="~/MyControls/Rdms/User/Staff.ascx" TagPrefix="nas" TagName="Staff" %>
<%@ Register Src="~/MyControls/Rdms/DutyCalendar/DutyTypeNote/DutyTypeNotes.ascx" TagPrefix="nas" TagName="DutyTypeNotes" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DutyCalendar.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
<nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage,Search User, Assign Task" UrlArray=",~/Pages/Admin" />
    </nas:Breadcrumb>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%=Title%> <span class="icon-calendar"></span></h1>
    <h2>On <%=Format(RequestDate, "dd MMMM yyyy")%></h2>
    <hr />

    <nas:Staff runat="server" ID="Staff" />

    <div = style="clear:both"></div>
    <br />
    <h3>Select Duty Type</h3>
    <div class="listview">
        <asp:PlaceHolder ID="phDutyType" runat="server"></asp:PlaceHolder>
    </div>

    <div = style="clear:both"></div>
    <br /><br /><br />
    <h4>Duty Note : </h4>
    <div style="font-size:12px; color:gray;">
        <nas:DutyTypeNotes runat="server" ID="DutyTypeNotes" Initiate="true" />
    </div>

    <div = style="clear:both"></div>
    <br /><br /><br />
</asp:Content>
