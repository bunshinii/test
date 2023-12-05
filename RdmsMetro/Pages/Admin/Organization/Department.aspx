<%@ Page Title="Manage Department" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Department.aspx.vb" Inherits="Rdms_Metro.Department" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Department/Container.ascx" TagPrefix="nas" TagName="DepartmentTable" %>

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
        <table>
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Branch
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddBranch" runat="server"></asp:DropDownList>
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
        <nas:DepartmentTable runat="server" ID="DepartmentTable1" />
    </div>
    
</asp:Content>
