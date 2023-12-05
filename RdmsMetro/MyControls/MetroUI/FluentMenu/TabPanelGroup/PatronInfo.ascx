<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PatronInfo.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.PatronInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/PatronPhoto.ascx" TagPrefix="nas" TagName="PatronPhoto" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/PatronContact.ascx" TagPrefix="nas" TagName="PatronContact" %>



<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <nas:PatronPhoto runat="server" id="PatronPhoto1" />
	</div>
	<div class="tab-group-caption">Picture</div>
</div>
<!-- End Group -->

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">

            <div style="min-width:150px; max-width:300px; line-height:none; height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding-top:8px;" >
                <label><asp:Label ID="lblFullname" runat="server" Font-Bold="true"></asp:Label></label>
                <label><asp:Label ID="lblLevel" runat="server"></asp:Label></label>
                <label><span class="icon-phone"></span> <asp:Label ID="lblPhone" runat="server"></asp:Label></label>
                <label><span class="icon-mail"></span> <asp:Label ID="lblEmail" runat="server"></asp:Label></label>
                <label><asp:Label ID="lblPatronId" runat="server"></asp:Label></label>
            </div>

        </div>
    </div>
	<div class="tab-group-caption">Basic</div>
</div>
<!-- End Group -->

 <!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">

        <div style="min-width:150px; max-width:280px; height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding-top:8px;" >
            <label><asp:Label ID="lblFaculty" runat="server"></asp:Label></label>
            <label><asp:Label ID="lblProgram" runat="server"></asp:Label></label>
            <label><asp:Label ID="lblCampus" runat="server"></asp:Label></label>
            <label><asp:Label ID="lblMode" runat="server"></asp:Label></label>
        </div>

	</div>
	<div class="tab-group-caption">Faculty / Department</div>
</div>
<!-- End Group -->

 <!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">

        <div style="min-width:100px; max-width:170px;height:95px; overflow:hidden; font-family:Arial; font-size:12px; padding-top:8px;" >
            <label><asp:Label ID="lblStatus" runat="server"></asp:Label></label>
        </div>

	</div>
	<div class="tab-group-caption">Status</div>
</div>
<!-- End Group -->

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gStudFacultyCode" runat="server" Text="" />
    <asp:Label ID="gStudProgramCode" runat="server" Text="" />
    <asp:Label ID="gStudCampusCode" runat="server" Text="" />
    <asp:Label ID="gStudLevelCode" runat="server" Text="" />
    <asp:Label ID="gStudModeCode" runat="server" Text="" />
    <asp:Label ID="gStafDeptCode" runat="server" Text="" />
    <asp:Label ID="gStafPosCode" runat="server" Text="" />
    <asp:Label ID="gStafTypeCode" runat="server" Text="" />

</asp:Panel>
