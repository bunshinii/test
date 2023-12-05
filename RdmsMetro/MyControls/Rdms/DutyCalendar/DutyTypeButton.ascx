<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DutyTypeButton.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.DutyCalendar.DutyTypeButton" %>


<a href="<%=AbsolutePath%>" class="list <%=Colors%>" title="<%=ToolTip%>"
    style="float:left; margin:5px; width:250px; min-width:250px;max-width:250px;padding:10px 20px;">
    <div style="">
        <i class="icon-enter-2 on-left"></i>
       <asp:Label ID="lblName" runat="server" Text="Name"/>
    </div>
</a>

 <asp:Panel ID="PanelDebug" runat="server" Visible="false">
     <asp:Label ID="gDutyTypeId" runat="server" Text="0"/>

    <asp:Label ID="gVirtualPath" runat="server" Text="~/"/>
    <asp:Label ID="gQueryString" runat="server" Text=""/>

    <asp:Label ID="gBgColor" runat="server" Text="bg-darkRed"/>
    <asp:Label ID="gFgColor" runat="server" Text="bg-white"/>

    <asp:Label ID="gToolTip" runat="server"/>
 </asp:Panel>