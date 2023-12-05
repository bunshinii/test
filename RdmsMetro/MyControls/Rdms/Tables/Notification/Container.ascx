<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.Notification.Container" %>
<%@ Register Src="~/MyControls/Rdms/Tables/Notification/RowItem.ascx" TagPrefix="uc1" TagName="RowItem" %>


<asp:Panel ID="PanelContent" runat="server">
    <table class="table hovered">
        <thead>
        <tr>
            <th class="no text-left">No</th>
            <th class="medium text-left">Title</th>
            <th class="fullname text-left">Message</th>
            <th class="date text-left">Date</th>
            <th class="no text-left"><button id="btnRead" runat="server" class="button mini warning" title="Delete All"><span class="icon-cancel-2"></span></button></th>
        </tr>
        </thead>

        <tbody>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </tbody>

        <tfoot></tfoot>
    </table>
</asp:Panel>
<asp:Panel ID="PanelDebug" runat="server" Visible="false">

</asp:Panel>
