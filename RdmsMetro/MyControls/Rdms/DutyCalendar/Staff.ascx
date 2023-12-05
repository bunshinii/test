<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Staff.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.Staff" %>

<div class="duty-staff">
    <a id="alink" runat="server" href="#">
    <table>
        <tr>
            <td colspan="2" style="padding:0;margin:0; text-align:center">
                <asp:PlaceHolder ID="phLegend" runat="server"/>
            </td>
        </tr>
        <tr>
            <td class="image">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UserDefault.jpg" />
            </td>
            <td class="content">
                <div class="truncate">
                    <asp:Label ID="lblName" runat="server" CssClass="title" />
                    <asp:Label ID="lblPosition" runat="server" CssClass="position" />
                    <asp:Label ID="lblDepartment" runat="server" CssClass="department" />
                    <asp:Label ID="lblDivision" runat="server" CssClass="division" />
                    <asp:Label ID="lblEmail" runat="server" CssClass="email" />
                    <asp:Label ID="lblPhone" runat="server" CssClass="phone" />
                </div>
            </td>
        </tr>
    </table>
    </a>
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gStaffId" runat="server" Text="0"/>
    <asp:Label ID="gDutyTypeId" runat="server" Text="0"/>
    <asp:Label ID="gDutyId" runat="server" Text="0"/>
    <asp:Label ID="gVirtualPathRemoveButton" runat="server" Text="~/"></asp:Label>
    <asp:Label ID="gQueryStringRemoveButton" runat="server" Text=""></asp:Label>
    <asp:CheckBox ID="gButtonVisible" runat="server" Checked="false" />
</asp:Panel>
