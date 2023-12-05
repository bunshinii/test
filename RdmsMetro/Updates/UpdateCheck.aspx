<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="UpdateCheck.aspx.vb" Inherits="Rdms_Metro.UpdateCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h1>Check for Update</h1>

        <h3><asp:Label ID="lblUrl" runat="server" Text=""></asp:Label></h3>
        <hr />
        <table>
            <tr>
                <td style="vertical-align:top;">
                    <span style="font-weight:700;">Current Revision : </span>
                </td>
                <td style="vertical-align:top;">
                    <asp:Label ID="lblRev" runat="server" Text="0" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                    Date :
                </td>
                <td style="vertical-align:top;">
                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
        </table>

        <p>&nbsp;</p>

        <table>
            <tr>
                <td style="vertical-align:top;">
                    <span style="font-weight:700;">Update Revision : </span>
                </td>
                <td style="vertical-align:top;">
                    <asp:Label ID="lblSvrRev" runat="server" Text="0" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                   Date :
                </td>
                <td style="vertical-align:top;">
                    <asp:Label ID="lblSvrDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top;">
                    Update Message :
                </td>
                <td style="vertical-align:top;">
                    <asp:Label ID="lblSvrMsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>

        </table>

        <p>&nbsp;</p>

        <asp:Label ID="lblUpdateStatus" runat="server" Text="This app is up to date" ForeColor="Green" Font-Bold="true"></asp:Label>

        <asp:Button ID="btnCheck" runat="server" Text="Check Update" Visible="true" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Now" Visible="false" />

    </div>

    <p>&nbsp;</p>
    <hr />

    <div>
        <h3>Update Log</h3>
        <asp:Label ID="lblUpdateLog" runat="server" Text="Nothing"></asp:Label>

    </div>
    


</asp:Content>
