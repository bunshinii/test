<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AllEditor.ascx.vb" Inherits="Rdms_Metro.AllEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

    <table>

        <tr>
            <td>
                <cc1:Editor ID="Editor1" runat="server" Width="100%" Height="350px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            Visible from :
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            To :
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="dd MMM yyyy" TodaysDateFormat="dd MMM yyyy"></asp:CalendarExtender>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="dd MMM yyyy" TodaysDateFormat="dd MMM yyyy"></asp:CalendarExtender>
            </td>
        </tr>

        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnClear" runat="server" Text="Clear" />
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </td>
        </tr>
    </table>
      

    </ContentTemplate>
</asp:UpdatePanel>

