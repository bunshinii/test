<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Picture.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.Picture" %>

<asp:Image ID="Image1" runat="server" DescriptionUrl="~/Pages/Profile.aspx" />

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gPatronId" runat="server" Text=""></asp:Label>
</asp:Panel>
