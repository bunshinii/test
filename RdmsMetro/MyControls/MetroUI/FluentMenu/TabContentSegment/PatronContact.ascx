<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PatronContact.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.PatronContact" %>

<div class="tab-content-segment">

    <div style="min-width:150px; max-width:300px; line-height:none; height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding-top:8px;" >
        <label><span class="icon-phone"></span> <asp:Label ID="lblPhone" runat="server"></asp:Label></label>
        <label><span class="icon-mail"></span> <asp:Label ID="lblEmail" runat="server"></asp:Label></label>
        <label><asp:Label ID="lblOther" runat="server"></asp:Label></label>
        <asp:Label ID="lblPatronid" runat="server" Visible="false"></asp:Label>
    </div>
</div>
