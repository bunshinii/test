<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CheckinEnquiry.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabContentSegment.CheckinEnquiry" %>
<%@ Register Src="~/MyControls/MetroUI/FluentMenu/TabContentSegment/CheckinItems/EnquiryItem.ascx" TagPrefix="nas" TagName="EnquiryItem" %>


<div class="tab-content-segment">
    <table style="table-layout:fixed; font-size:12px;">
        <tr>
            <td>
                <nas:EnquiryItem runat="server" ID="enqQr" Text="Quick Ref." ToolTip="Quick Reference" /> &nbsp;
            </td>
            <td>
                 <nas:EnquiryItem runat="server" ID="enqSt" Text="Search Technique" ToolTip="Search Technique" /> &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                 <nas:EnquiryItem runat="server" ID="enqRr" Text="Research Ref." ToolTip="Research Reference" /> &nbsp;
            </td>
            <td>
                 <nas:EnquiryItem runat="server" ID="enqAg" Text="Adv. & Guidance" ToolTip="Advisory & Guidance" /> &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                 <nas:EnquiryItem runat="server" ID="enqEtc" Text="Other" ToolTip="Other type of enquiry" /> &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

</div>