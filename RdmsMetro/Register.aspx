<%@ Page Title="Staff Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="Register.aspx.vb" Inherits="Rdms_Metro.Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/Forms.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-user-3"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <div class="nasform">
        <table>
            <tr>
                <td>
                    <h3>Staff Info</h3>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>



            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">
                <table>
                    <tr>
                        <td class="caption">
                            Staff ID : &nbsp;
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" Text="*" ForeColor="Red"
                                ControlToValidate="txtStaffId" ValidationGroup="g1"
                                ErrorMessage="Please fill the Staff ID field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtStaffId" runat="server" ValidationGroup="g1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            IC / Passport : 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ForeColor="Red"
                                ControlToValidate="txtPassport" ValidationGroup="g1"
                                ErrorMessage="Please fill the IC field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport" runat="server" ValidationGroup="g1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                   
                        </td>
                        <td>
                             <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="g1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">

                        </td>
                        <td class="buttons">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="primary" ValidationGroup="g1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Visible="false" DefaultButton="btnSubmit">
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
                        <td class="caption">
                            Full Name : 
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ForeColor="Red"
                                ControlToValidate="txtFullname" ValidationGroup="g2"
                                ErrorMessage="Please fill the Full Name field" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtFullname" runat="server" ValidationGroup="g2"></asp:TextBox>
                        </td>
                    </tr>
            
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Gender : 
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Text="*" ForeColor="Red"
                                 ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddGender" ValidationGroup="g2"
                                ErrorMessage="Please select Gender" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddGender" runat="server" ValidationGroup="g2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Marriage : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddMarriage" runat="server" ValidationGroup="g2"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Email : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="g2"></asp:TextBox>
                        </td>
                    </tr>
            
                    <tr>
                        <td class="caption">
                            Phone : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" ValidationGroup="g2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            HandPhone : 
                        </td>
                        <td>
                            <asp:TextBox ID="txtHandPhone" runat="server" ValidationGroup="g2"></asp:TextBox>
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
                                <asp:DropDownList ID="ddGrade" runat="server" ValidationGroup="g2" AutoPostBack="true"></asp:DropDownList>
                            </td>
                        </tr>
                       <tr>
                            <td class="caption">
                                Position : 
                            </td>
                            <td>
                                <asp:DropDownList ID="ddPosition" ValidationGroup="g2" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                    </table>

                </ContentTemplate>
                </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ValidationGroup="g2" UpdateMode="Conditional">
                        <ContentTemplate>

                        <table>
                        <tr>
                            <td class="caption">
                                Branch : 
                                <asp:CompareValidator ID="CompareValidator2" runat="server" Text="*" ForeColor="Red"
                                 ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddBranch" ValidationGroup="g2"
                                ErrorMessage="Please select Branch" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddBranch" runat="server" ValidationGroup="g2" AutoPostBack="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="caption">
                                Satellite : 
                                <asp:CompareValidator ID="CompareValidator3" runat="server" Text="*" ForeColor="Red"
                                 ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddSatellite" ValidationGroup="g2"
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
                                <asp:DropDownList ID="ddDepartment" runat="server" ValidationGroup="g2" AutoPostBack="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="caption">
                                Division : 
                            </td>
                            <td>
                                <asp:DropDownList ID="ddDivision" runat="server" ValidationGroup="g2" AutoPostBack="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="caption">
                                Unit : 
                            </td>
                            <td>
                                <asp:DropDownList ID="ddUnit" runat="server" ValidationGroup="g2"></asp:DropDownList>
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
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="List" ValidationGroup="g2" />
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">

                        </td>
                        <td class="buttons">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="primary" ValidationGroup="g2" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>

        </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div style="clear:both; margin-bottom:100px;"></div>

   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" />
            <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server" TargetControlID="lblMessage" HorizontalSide="Center" VerticalSide="Middle"></asp:AlwaysVisibleControlExtender>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" Enabled="false"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
