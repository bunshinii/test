<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CheckinInfo.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.CheckinInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/PatronPhoto.ascx" TagPrefix="nas" TagName="PatronPhoto" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinMedium.ascx" TagPrefix="nas" TagName="CheckinMedium" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinSubject.ascx" TagPrefix="nas" TagName="CheckinSubject" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinEnquiry.ascx" TagPrefix="nas" TagName="CheckinEnquiry" %>

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <nas:PatronPhoto runat="server" ID="PatronPhoto1" />
	</div>
	<div class="tab-group-caption">Picture</div>
</div>
<!-- End Group -->

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
            <nas:CheckinMedium runat="server" ID="CheckinMedium1" />
	</div>
	<div class="tab-group-caption">Medium</div>
</div>
<!-- End Group -->

<!-- Start Group -->
	<div class="tab-panel-group" style="max-width:259px;">
		<div class="tab-group-content">
            <nas:CheckinSubject runat="server" ID="CheckinSubject1" />
		</div>
		<div class="tab-group-caption">Subject</div>
	</div>
    <!-- End Group -->

    <!-- Start Group -->
	<div class="tab-panel-group" style="max-width:259px;">
		<div class="tab-group-content">
            <nas:CheckinEnquiry runat="server" ID="CheckinEnquiry1" />
		</div>
		<div class="tab-group-caption">Enquiry Type</div>
	</div>
    <!-- End Group -->

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gPatronId" runat="server" Text=""></asp:Label>
</asp:Panel>