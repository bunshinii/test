<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ContainerEditor.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.ContainerEditor" %>


<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/PatronInfo.ascx" TagPrefix="nas" TagName="PatronInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinSubject.ascx" TagPrefix="nas" TagName="CheckinSubject" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinEnquiry.ascx" TagPrefix="nas" TagName="CheckinEnquiry" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/SessionInfoEditor.ascx" TagPrefix="nas" TagName="SessionInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/OfficerInfo.ascx" TagPrefix="nas" TagName="OfficerInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/CheckinInfo.ascx" TagPrefix="nas" TagName="CheckinInfo" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabPanelGroup/Snippet.ascx" TagPrefix="nas" TagName="Snippet" %>


<div style="max-width:760px;min-width:760px; margin:auto;">
	<div class="fluent-menu" data-role="fluentmenu">
		<ul class="tabs-holder">
			<li class="special"><a href="#">Check-In</a></li>
			<li class="active"><a href="#tab_home">Home</a></li>
			<li><a href="#tab_patron_info">Patron Info</a></li>
			<li runat="server" id="li_snippet"><a href="#tab_snippet">Snippet</a></li>
			<li><a href="#tab_session">Session Info</a></li>
			<li><a href="#tab_officer">Officer Info</a></li>
		</ul>

		<div class="tabs-content">

			<div class="tab-panel" id="tab_home" style="display: block;">
				<nas:CheckinInfo runat="server" id="CheckinInfo1" />
			</div>

			<div class="tab-panel" id="tab_patron_info" style="display: none;">
				<nas:PatronInfo runat="server" ID="PatronInfo1" />
			</div>

			<div class="tab-panel" id="tab_snippet" style="display: none;">
				<nas:Snippet runat="server" id="Snippet1" />
			</div>

			<div class="tab-panel" id="tab_officer" style="display: none;">
				<nas:OfficerInfo runat="server" ID="OfficerInfo1" />
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

		</div>


	</div>
	<div style="clear:both"></div>
	<div class="panel">
		<div class="panel-content">
			<label>Question :</label>
			<asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="100%" Height="200px" ClientIDMode="Static"></asp:TextBox>
			<label>Answer :</label>
			<asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Width="100%" Height="200px"  ClientIDMode="Static"></asp:TextBox>
			
			<br /><br />
			<asp:Panel ID="Panel1" runat="server" HorizontalAlign="Right">
				<asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
				<asp:Button ID="btnKiv" runat="server" Text="KIV" />
				<asp:Button ID="btnSave" runat="server" Text="Save" />
			</asp:Panel>
			
		</div>
	</div>

</div>
<div style="clear:both"></div>
<asp:Panel ID="PanelDebug" runat="server" Visible="false">
	<asp:CheckBox ID="gIsReadOnly" runat="server" Checked="false" />
</asp:Panel>
