<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QuickAccess.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.QuickAccess" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/SegmentItems/Link.ascx" TagPrefix="nas" TagName="Link" %>


<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">
            <nas:Link runat="server" ID="Link" Text="EZAccess UiTM" NavigateUrl="http://ezaccess.library.uitm.edu.my/" /><br />
            <nas:Link runat="server" ID="Link1" Text="Online Database" NavigateUrl="http://online.ptar.uitm.edu.my/databases/" /><br />
        </div>
	</div>
	<div class="tab-group-caption">Online Database</div>
</div>
<!-- End Group -->



<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">
            <nas:Link runat="server" ID="Link2" Text="Digital Collections" NavigateUrl="http://search.ptar.uitm.edu.my/" /><br />
            <nas:Link runat="server" ID="Link3" Text="Exam Papers EQPS" NavigateUrl="http://library.uitm.edu.my/v3/index.php/digital-library/uitm-institutional-repositories/exam-paper" /><br />
            <nas:Link runat="server" ID="Link4" Text="Institutional Repository" NavigateUrl="http://eprints.uitm.edu.my/" /><br />
            <nas:Link runat="server" ID="Link10" Text="FCORP" NavigateUrl="http://www.ptar.uitm.edu.my/elmu-ptar/index.jsp?module=fcorp&action=main.jsp&template=template3.jsp" /><br />
            

        </div>
	</div>
	<div class="tab-group-caption">Digital Collection</div>
</div>
<!-- End Group -->

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">
            <nas:Link runat="server" ID="Link5" Text="Web OPAC" NavigateUrl="http://www.ptar.uitm.edu.my/elmu-ptar/index.jsp?module=webopac-l&action=webopac.jsp&equipSecurityCheck=20110909095850300&equipSessionId=B080DEBE6F44AC2FC2CD6BF0965C8406" /><br />
            <nas:Link runat="server" ID="Link6" Text="Web OPAC 2.0" NavigateUrl="http://www.ptar.uitm.edu.my:8080/" /><br />
            <nas:Link runat="server" ID="Link7" Text="Web Infoline" NavigateUrl="http://www.ptar.uitm.edu.my/elmu-ptar/index.jsp?module=webinfoline&action=webinfoline.jsp" /><br />
            <nas:Link runat="server" ID="Link13" Text="My Library" NavigateUrl="http://ptar.uitm.edu.my/equip-ptar/" /><br />
        </div>
	</div>
	<div class="tab-group-caption">OPAC</div>
</div>
<!-- End Group -->

<!-- Start Group -->
<div class="tab-panel-group">
	<div class="tab-group-content">
        <div class="tab-content-segment">
            <nas:Link runat="server" ID="Link8" Text="Library Web" NavigateUrl="http://library.uitm.edu.my/" /><br />
            <nas:Link runat="server" ID="Link9" Text="Staff Directory" NavigateUrl="http://library.uitm.edu.my/v3/index.php/contact-us/staff-directory2" /><br />
        </div>
	</div>
	<div class="tab-group-caption">Internal</div>
</div>
<!-- End Group -->