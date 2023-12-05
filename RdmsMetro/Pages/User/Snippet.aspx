<%@ Page Title="Manage Snippet" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="Snippet.aspx.vb" Inherits="Rdms_Metro.Snippet" %>

<%@ Register Src="~/MyControls/Rdms/Tables/Snippet/Container.ascx" TagPrefix="nas" TagName="SnippetTable" %>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
        
    <nas:breadcrumb id="Breadcrumb1" runat="server" namearray="User,Setting,Snippet" urlarray=",~/Pages/User/Default.aspx,~/Pages/User/Snippet.aspx">
</nas:breadcrumb>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-comments-5"></span> <%=Title%></h1>
    <hr />

    <div class="bg-darkBlue" style="padding:20px;">
        <table>
            <tr>
                <td class="bg-darkBlue fg-white">
                    Select Snippet type 
                </td>
                <td class="bg-darkBlue fg-white">
                     : 
                </td>
                <td class="bg-darkBlue fg-white">
                    <asp:DropDownList ID="ddSnippetType" runat="server">
                        <asp:ListItem>Question</asp:ListItem>
                        <asp:ListItem>Answer</asp:ListItem>
                    </asp:DropDownList>
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
        <nas:SnippetTable runat="server" ID="SnippetTable1" />
    </div>
    
</asp:Content>
