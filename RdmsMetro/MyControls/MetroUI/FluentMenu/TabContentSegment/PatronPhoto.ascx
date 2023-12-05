<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PatronPhoto.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.PatronPhoto" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <button class="fluent-big-button" title="<%=Tooltip%>">
            <asp:Image ID="Image1" runat="server" Height="64px" Width="64px" ImageUrl="~/Images/UserDefault.jpg" />
        </button>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Label ID="gPatronId" runat="server" Visible="false" />