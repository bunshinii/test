<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PatronInfoCustom.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.PatronInfoCustom" %>



<div class="tab-control" data-role="tab-control" data-effect="fade">
    <ul class="tabs">
        
        <li class="active"><a href="#_choose"><span class="icon-arrow-right fg-blue"></span></a></li>
        <li><a href="#_student"><span class="icon-user"></span> Student</a></li>
        <li><a href="#_staff"><span class="icon-user-3"></span> Staff</a></li>
    </ul>

    <div class="frames">
            
            <div class="frame" id="_choose">
                <div style="margin-left:0px; margin-top:-26px; position:absolute; z-index:1000; text-align:center;">
                    <span class="icon-arrow-up-right fg-red" style="font-size:36px;"></span><br />
                    <span style="font-size:14px; background-color:white; border:1px solid black; padding:0 3px;">select student</span>
                </div>
                <div style="margin-left:170px; margin-top:-32px; position:absolute; z-index:1000; text-align:center;">
                    <span class="icon-arrow-up-left fg-red" style="font-size:36px;"></span><br />
                    <span style="font-size:14px; background-color:white; border:1px solid black; padding:0 3px;">select staff</span>
                </div>
            </div>
        
            <div class="frame" id="_student">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <table class="custominfo">
                    <tr>
                        <td class="caption">
                            Patron ID : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddPatronStudent" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td class="caption">
                            Faculty : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddFaculty" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Programme : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddProgram" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Branch : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddBranchStud" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Campus : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddCampus" runat="server" CssClass="dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Mode : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddMode" runat="server" CssClass="dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>

            </div>
                
            <div class="frame" id="_staff">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <table class="custominfo">
                    <tr>
                        <td class="caption">
                            Patron ID : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddPatronStaf" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td class="caption">
                            Branch : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddBranchStaf" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Department : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddDepartment" runat="server" CssClass="dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            Type : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddStafType" runat="server" CssClass="dropdown"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>

    </div>

</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gPatronId" runat="server" Text=""></asp:Label>

    <asp:Label ID="gStudLevelCode" runat="server" Text="" />
    <asp:Label ID="gStafPosCode" runat="server" Text="0" />
</asp:Panel>