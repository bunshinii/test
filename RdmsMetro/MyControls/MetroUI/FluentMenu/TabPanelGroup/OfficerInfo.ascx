<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OfficerInfo.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.OfficerInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/PatronPhoto.ascx" TagPrefix="nas" TagName="PatronPhoto" %>



<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
       <div class="tab-content-segment">

            <div style="height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding:10px;" >
                <nas:PatronPhoto runat="server" ID="PatronPhoto1" />
            </div>

        </div>
	</div>
	<div class="tab-group-caption">Photo</div>
</div>
<!-- End Group -->


<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
       <div class="tab-content-segment">

            <div style="width:300px; height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding:10px;" >
                <label><asp:Label ID="lblFullname" runat="server" Font-Bold="true" Text="Name"></asp:Label></label>
                <label><asp:Label ID="lblPatronId" runat="server"></asp:Label></label>
                <label><asp:Label ID="lblSatellite" runat="server"></asp:Label></label>
                <label><asp:Label ID="lblBranch" runat="server"></asp:Label></label>
            </div>

        </div>
	</div>
	<div class="tab-group-caption">Basic Info</div>
</div>
<!-- End Group -->

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">

            <div style="width:300px; height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding:10px;" >
                <label><asp:Label ID="lblDepartmet" runat="server"></asp:Label></label>
                <label><asp:Label ID="lblDivision" runat="server"></asp:Label></label>
                <label><asp:Label ID="lblunit" runat="server"></asp:Label></label>
            </div>

        </div>
	</div>
	<div class="tab-group-caption">Department Info</div>
</div>
<!-- End Group -->






<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gBranchId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gSatelliteId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gDepartmentId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gDivisionId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="gUnitId" runat="server" Text="0"></asp:Label>
</asp:Panel>
