<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUIBox.Master" CodeBehind="PwdReset.aspx.vb" Inherits="Rdms_Metro.PwdReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
            

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><span class="icon-key"></span> <%=Title%></h1>
    <hr />

        <div style="margin:100px auto; width:500px;">
        <div style="width:80%; margin:10px auto;">
        <div style="font-size: 2.2rem;line-height: 2.2rem;"> 
            <span class="icon-key"></span> <strong>Reset user password</strong>
        </div> 
            <br /><br />


            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PatronId" runat="server" AssociatedControlID="txtPatronId">Staff ID&nbsp; : &nbsp; </asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPatronId" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset Password"/> 
                                </td>
                                <td>
                                    &nbsp; <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

                </div>
    </div>
</asp:Content>
