<%@ Page Title="Manage Satellite" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Satellite.aspx.vb" Inherits="Rdms_Metro.Satellite" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Satellite/Container.ascx" TagPrefix="nas" TagName="SatelliteTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        
    <nas:breadcrumb id="Breadcrumb1" runat="server" namearray="Administrator,Organization,Manage Satellite" urlarray=",~/Pages/Admin/Organization,~/Pages/Admin/Organization/Satellite.aspx">
</nas:breadcrumb>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-grid"></span> <%=Title%></h1>
    <hr />

    <div class="bg-darkBlue" style="padding:20px;">
        <table style="width:100%">
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Branch
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddBranch" runat="server" Width="100%"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="bg-darkBlue fg-white">
                    
                </td>
                <td class="bg-darkBlue fg-white">
                      
                </td>
                <td class="bg-darkBlue fg-white" style="text-align:right">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                </td>
            </tr>
        </table>
        
    </div>

    <div class="nastable">
        <nas:SatelliteTable runat="server" ID="SatelliteTable1" />
    </div>
    
</asp:Content>