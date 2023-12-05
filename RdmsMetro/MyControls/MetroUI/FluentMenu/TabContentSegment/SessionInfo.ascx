<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SessionInfo.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.SessionInfo" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<div class="tab-content-segment">

    <div style="height:95px; padding:10px 10px 0px 20px;" >
    <div class="tab-content-segment">
        <button class="fluent-big-button">
            <span class="icon-cycle"></span>
            <span class="button-label">Refresh</span>
        </button>
    </div>
    </div>
</div>

<div class="tab-content-segment">

    <div style="height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding:20px;" >

        <label><span class="icon-clock"></span> Session Start : <asp:Label ID="lblTimeStart" runat="server">12 Aug 2014 07:23:50</asp:Label></label>
        <label><span class="icon-clock"></span> Session End : <asp:Label ID="lblTimeEnd" runat="server">12 Aug 2014 07:23:56</asp:Label></label>
        <label><span class="icon-clock"></span> Duration : <asp:Label ID="lblDuration" runat="server">07:23:50</asp:Label></label>

        <asp:Timer ID="Timer1" runat="server" Interval="60000" Enabled="true"></asp:Timer>

        <label><asp:Label ID="lblSessionId" runat="server" Visible="false"></asp:Label></label>
    </div>

</div>

</ContentTemplate>
</asp:UpdatePanel>

<div class="tab-content-segment">

    <div style="height:95px; padding:30px; font-size:20px;" >

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <label><asp:Label ID="Label1" runat="server">Loading..</asp:Label></label>
            </ProgressTemplate>
        </asp:UpdateProgress>
        
        
    </div>

</div>