<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Profile.Container" %>

<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UserDefault.jpg" />

<p>
    <asp:Label ID="lblName" runat="server" CssClass="name" />
    <asp:Label ID="lblPosition" runat="server" CssClass="position" />
    <asp:Label ID="lblDepartment" runat="server" CssClass="department" />
    <asp:Label ID="lblDivision" runat="server" CssClass="division" />
    <asp:Label ID="lblUnit" runat="server" CssClass="unit" />
    <asp:Label ID="lblEmail" runat="server" CssClass="email" />
    <asp:Label ID="lblPhone" runat="server" CssClass="phone" />
</p>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gStaffId" runat="server" />
</asp:Panel>
