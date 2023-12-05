<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ContainerCustom.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.ContainerCustom" %>

<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinSubject.ascx" TagPrefix="nas" TagName="CheckinSubject" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinEnquiry.ascx" TagPrefix="nas" TagName="CheckinEnquiry" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/SessionInfo.ascx" TagPrefix="nas" TagName="SessionInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/OfficerInfo.ascx" TagPrefix="nas" TagName="OfficerInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/CheckinInfo.ascx" TagPrefix="nas" TagName="CheckinInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/Snippet.ascx" TagPrefix="nas" TagName="Snippet" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/QuickAccess.ascx" TagPrefix="nas" TagName="QuickAccess" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/PatronInfoCustom.ascx" TagPrefix="nas" TagName="PatronInfo" %>


<div style="max-width:760px;min-width:760px; margin:auto;">
	<div class="fluent-menu" data-role="fluentmenu">
		<ul class="tabs-holder">
			<li class="special"><a href="#">Check-In</a></li>
			<li class="active"><a href="#tab_home">Home</a></li>
			<li class=""><a href="#tab_snippet">Snippet</a></li>
			<li class=""><a href="#tab_session">Session Info</a></li>
			<li class=""><a href="#tab_officer">Officer Info</a></li>
			<li class=""><a href="#tab_quick">Quick Access</a></li>
		</ul>

		<div class="tabs-content">

			<div class="tab-panel" id="tab_home" style="display: block;">
				<nas:CheckinInfo runat="server" id="CheckinInfo1" />
			</div>

			<div class="tab-panel" id="tab_snippet" style="display: none;">
				<nas:Snippet runat="server" id="Snippet1" />
			</div>

			<div class="tab-panel" id="tab_session" style="display: none;">
				<!-- Start Group -->
				<%--<div class="tab-panel-group">
					<div class="tab-group-content">--%>
						<nas:SessionInfo runat="server" id="SessionInfo1" />
					<%--</div>
					<div class="tab-group-caption">Session Info</div>
				</div>--%>
				<!-- End Group -->
			</div>

			<div class="tab-panel" id="tab_officer" style="display: none;">
				<nas:OfficerInfo runat="server" ID="OfficerInfo1" />
			</div>

			<div class="tab-panel" id="tab_quick" style="display: none;">
				<nas:QuickAccess runat="server" id="QuickAccess1" />
			</div>
		</div>

	</div>

	<div class="panel" data-role="panel">
		<div class="panel-header bg-darkBlue fg-white">
			Patron Info
		</div>
		<div class="panel-content">
			<nas:PatronInfo runat="server" id="PatronInfo1" />
		</div>
	</div>

	<div class="panel" data-role="panel">
		<div class="panel-header bg-darkBlue fg-white">
			Question And Answer
		</div>
		<div class="panel-content">
			<label>Question :</label>
			<asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="100%" Height="200px" ClientIDMode="Static"></asp:TextBox>
			<label>Answer :</label>
			<asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Width="100%" Height="200px"  ClientIDMode="Static"></asp:TextBox>
			
			<br /><br />
			<asp:Panel ID="Panel1" runat="server" HorizontalAlign="Right">
				<asp:Label ID="lblMessage" runat="server" Text="Please select Patron ID" ForeColor="Red" Visible="false"></asp:Label>
				<asp:Button ID="btnKiv" runat="server" Text="KIV" />
				<asp:Button ID="btnSave" runat="server" Text="Save" />
			</asp:Panel>
			
		</div>
	</div>

</div>