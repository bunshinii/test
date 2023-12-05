<%@ Page Title="Manage Unit" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Unit.aspx.vb" Inherits="Rdms_Metro.Unit" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Unit/Container.ascx" TagPrefix="nas" TagName="UnitTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nas:breadcrumb id="Breadcrumb1" runat="server" namearray="Administrator,Organization,Manage Division" urlarray=",~/Pages/Admin/Organization,~/Pages/Admin/Organization/Division.aspx">
</nas:breadcrumb>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-grid"></span> <%=Title%></h1>
    <hr />

    <div class="bg-darkBlue" style="padding:20px;">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        <table>
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Branch
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddBranch" runat="server" AutoPostBack="true" Width="300px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Department
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddDepartment" runat="server" AutoPostBack="true" Width="300px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Unit
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddDivision" runat="server" Width="300px"></asp:DropDownList>
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

        </ContentTemplate>
    </asp:UpdatePanel>

    </div>

    <div class="nastable"><nas:UnitTable runat="server" ID="UnitTable1" /></div>
    
</asp:Content>