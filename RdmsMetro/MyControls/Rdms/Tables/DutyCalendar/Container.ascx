<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Tables.DutyCalendar.Container" %>

<table class="table hovered">
    <thead>
    <tr>
        <th class="no text-left">No</th>
        <th class="date text-left">Date</th>
        <th class="mediumText text-left">Duty Type</th>
        <th class="longText text-left">Location</th>
        <th class="no text-left"></th>
        <th class="note text-left">Note</th>
        <th class="mybutton text-left">Change</th>
    </tr>
    </thead>

    <tbody>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </tbody>

    <tfoot></tfoot>
</table>

<hr />

<h3>Legend</h3>
<table>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
</table>