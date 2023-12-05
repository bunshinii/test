<%@ Page Title="Register User" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="UserRegister.aspx.vb" Inherits="Rdms_Metro.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Forms.min.css")%>" rel="stylesheet" />
</asp:Content>
<%@ Register Src="~/MyControls/MetroUI/Buttons/Breadcrumbs/Breadcrumb.ascx" TagName="Breadcrumb" TagPrefix="nas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
<nas:Breadcrumb ID="Breadcrumb1" runat="server" NameArray="Administrator,Manage,Search User,User Register" UrlArray=",~/Pages/Admin,~/Pages/Admin/UserSearch.aspx" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr />
    <div class="nasform">
        <table><tr><td><h3>User Info</h3></td></tr></table>
        <table>
            <tr>
                <td>

                </td>
                <td>
                    <div style="width:150px; margin:auto;">
                        <asp:Image ID="Image1" runat="server" Width="150px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="caption">
                    Staff ID : &nbsp;
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" Text="*" ForeColor="Red"
                        ControlToValidate="txtStaffId"
                        ErrorMessage="Please fill the Staff ID field" />
                </td>
                <td>
                    <asp:TextBox ID="txtStaffId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="caption">
                    Full Name : 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ForeColor="Red"
                        ControlToValidate="txtFullname"
                        ErrorMessage="Please fill the Full Name field" />
                </td>
                <td>
                    <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="caption">
                    IC : 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ForeColor="Red"
                        ControlToValidate="txtPassport"
                        ErrorMessage="Please fill the IC field" />
                </td>
                <td>
                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="caption">
                    Gender : 
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Text="*" ForeColor="Red"
                         ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddGender"
                        ErrorMessage="Please select Gender" />
                </td>
                <td>
                    <asp:DropDownList ID="ddGender" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="caption">
                    Marriage : 
                </td>
                <td>
                    <asp:DropDownList ID="ddMarriage" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="caption">
                    Email : 
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="caption">
                    Phone : 
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="caption">
                    HandPhone : 
                </td>
                <td>
                    <asp:TextBox ID="txtHandPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <table>
                <tr>
                    <td class="caption">
                        Grade : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddGrade" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
               <tr>
                    <td class="caption">
                        Position : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddPosition" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>

        </ContentTemplate>
        </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                <table>
                <tr>
                    <td class="caption">
                        Branch : 
                        <asp:CompareValidator ID="CompareValidator2" runat="server" Text="*" ForeColor="Red"
                         ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddBranch"
                        ErrorMessage="Please select Branch" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddBranch" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="caption">
                        Satellite : 
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Text="*" ForeColor="Red"
                         ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddSatellite"
                        ErrorMessage="Please select Satellite" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddSatellite" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="caption">
                        Department : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddDepartment" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="caption">
                        Division : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddDivision" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="caption">
                        Unit : 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddUnit" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>

       <table>
           <tr>
                <td colspan="2">
                   &nbsp;
                </td>
            </tr>
            <tr>
                <td class="caption">
                   
                </td>
                <td>
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" />
                </td>
            </tr>
                <tr>
                <td class="caption">

                </td>
                <td class="buttons">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="primary" />
                </td>
            </tr>

        </table>
    </div>
    <div style="clear:both; margin-bottom:100px;"></div>
</asp:Content>
