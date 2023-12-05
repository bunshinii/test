<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.Division.Container" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

<table class="table hovered">
    <thead>
    <tr>
        <%--Start Modify Here--%>

        <th class="no text-left">No</th>
        <th class="patronid text-left">Code</th>
        <th class="fullname text-left">Division Name</th>
        <th class="patronid text-left">Command</th>

        <%--End   Modify Here--%>
    </tr>
    </thead>

    <tbody>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        <asp:Panel ID="PanelEdit" runat="server" Visible="false">
        <tr>
            <%--Start Modify Here--%>

            <td>*</td>
            <td><asp:TextBox ID="txtCode" runat="server" Width="100%"></asp:TextBox></td>
            <td><asp:TextBox ID="txtName" runat="server" Width="100%"></asp:TextBox></td>
            <td class="mybutton right">
                <button class="button" runat="server" id="btnSave"><i class="icon-floppy on-left"></i>Save</button>
                <button class="button" runat="server" id="btnCancel"><i class="icon-cancel-2 on-left"></i>Cancel</button>
            </td>

            <%--End   Modify Here--%>
        </tr>
        </asp:Panel>

    </tbody>

    <tfoot>
        <asp:Panel ID="PanelStatic" runat="server">
        <tr>
        <%--Edir colspan to the number of td--%>
        <td colspan="4" class="mybutton right" style="text-align:right">
            <button class="button info" runat="server" id="btnRefresh"><i class="icon-spin on-left"></i>Refresh</button>
            <button class="button success" runat="server" id="btnAdd"><i class="icon-plus-2 on-left"></i>Add New</button>
        </td>
        </tr>
        </asp:Panel>
    </tfoot>
</table>
</ContentTemplate></asp:UpdatePanel>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBranchId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gDepartmentid" runat="server" Text="0"></asp:Label>
</asp:Panel>
