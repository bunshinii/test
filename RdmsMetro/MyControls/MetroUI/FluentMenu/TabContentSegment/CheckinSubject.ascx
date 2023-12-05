<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CheckinSubject.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.CheckinSubject" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinItems/SubjectItem.ascx" TagPrefix="nas" TagName="SubjectItem" %>

<style type="text/css">
    .metro .fluent-menu .tabs-content {
    height: 200px !important;
}
</style>
<div class="tab-content-segment">
    <table style="table-layout:fixed; font-size:12px;">
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subOd" Text="Online Database" ToolTip="Online Database" /> &nbsp;
            </td>
            <td>
                <nas:SubjectItem runat="server" id="subDc" Text="Digital Collection" ToolTip="Digital Collection" /> &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subIt" Text="Internet" ToolTip="Internet" /> &nbsp;
            </td>
            <td>
                <nas:SubjectItem runat="server" id="subOp" Text="OPAC" ToolTip="Online Public Access Catalogue" /> &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subLrc" Text="Law Reference" ToolTip="Law Reference Collections" /> &nbsp;
            </td>
            <td>
                <nas:SubjectItem runat="server" id="subRc" Text="Ref. Citation" ToolTip="Reference Citation" /> &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subFs" Text="Fac. &amp; Services" ToolTip="Facilites &amp; Services" /> &nbsp; &nbsp;
            </td>
            <td>
                <nas:SubjectItem runat="server" id="subVp" Text="Validasi Penerbitan" ToolTip="Validasi Penerbitan" /> &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subJa" Text="Rec. &amp; Archive" ToolTip="Record &amp; Archive (JAU)" /> &nbsp; &nbsp;
            </td>
            <td>
                <nas:SubjectItem runat="server" id="subGt" Text="Galeri TAR" ToolTip="Galeri Tun Abdul Razak (GTAR)" /> &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <nas:SubjectItem runat="server" id="subEtc" Text="Other" ToolTip="Other Subject" /> &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

</div>