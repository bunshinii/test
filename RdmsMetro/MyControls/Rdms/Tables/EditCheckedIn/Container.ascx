<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.EditCheckedIn.Container" %>

<table class="table hovered">
    <thead>
    <tr>
        <th class="no text-left">No</th>
        <th class="fullname text-left">Patron Name</th>
        <th class="patronid text-left">Patron ID</th>
        <th class="medium text-left">Medium</th>
        <th class="date text-left">Date</th>
    </tr>
    </thead>

    <tbody>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </tbody>

    <tfoot></tfoot>
</table>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:CheckBox ID="gIsKiv" runat="server" Checked="false" />
    <asp:CheckBox ID="gIsFinished" runat="server" Checked="true" />
</asp:Panel>
