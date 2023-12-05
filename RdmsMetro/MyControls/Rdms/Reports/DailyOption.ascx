<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DailyOption.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Reports.DailyOption" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="custominfo">
    <table class="bg-darkBlue fg-white" style="width:100%; table-layout:fixed;">
        <tr>
            <td colspan="2" class="padding" style="text-align:right">
                <a id="a1" runat="server" href="#" title="Print" target="_blank">
                <div class="toolbar fg-white">
                    <div class="toolbar-group">
                        <div class="info"><i class="icon-printer"></i></div>
                    </div>
                </div>
                </a>
            </td>
        </tr>
        
        <tr>
            <th colspan="2" class="padding">
                Select a Date :
                    <asp:TextBox ID="txtDate" runat="server" Width="200px" Font-Bold="True" Font-Size="Large" Wrap="False" CssClass="fg-darkOrange"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDateExt" runat="server" TargetControlID="txtDate" Format="dd MMMM yyyy"></asp:CalendarExtender>
                    <asp:RangeValidator ID="txtDateVal" runat="server" ErrorMessage="Invalid Date." ForeColor="Red" ControlToValidate="txtDate" Type="Date" Display="Dynamic" EnableClientScript="false"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="txtDateReq" runat="server" ErrorMessage="The date must not blank" ForeColor="Red" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <td class="padding content">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate>


                <table class="bg-darkBlue fg-white" style="width:100%;">

                    <tr>
                        <td class="caption">
                            Listing Type :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddListType" runat="server" CssClass="dropdown" AutoPostBack="True">
                                <asp:ListItem>Individual</asp:ListItem>
                                <asp:ListItem>Branch</asp:ListItem>
                                <asp:ListItem>Satellite</asp:ListItem>
                                <asp:ListItem>Department</asp:ListItem>
                                <asp:ListItem>Division</asp:ListItem>
                                <asp:ListItem>Unit</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="caption">
                            <%-- Leave Empty --%>
                        </td>
                        <td class="content">
                            <h3><asp:Label ID="lblFullname" runat="server" Text="Fullname" CssClass="fg-white"></asp:Label></h3>
                            <asp:DropDownList ID="ddBranch" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                            <asp:DropDownList ID="ddSatellite" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                            <asp:DropDownList ID="ddDepartment" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                            <asp:DropDownList ID="ddDivision" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                            <asp:DropDownList ID="ddUnit" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                        </td>
                    </tr>
                </table>

                </ContentTemplate></asp:UpdatePanel>

            </td>
            <td class="padding content">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
                    

                    <table class="bg-darkBlue fg-white" style="width:100%;">
                        <tr>
                            <td class="caption2">
                                <div class="input-control checkbox" data-role="input-control">
                                    <label class="inline-block">
                                        <asp:CheckBox ID="chkType" runat="server" AutoPostBack="true" />
                                        <span class="check"></span>
                                        Filter Type :
                                    </label>
                        
                                </div>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddFilter" runat="server" CssClass="dropdown" Enabled="false" AutoPostBack="True">
                                    <asp:ListItem Value="0"> -- Select Filter -- </asp:ListItem>
                                    <asp:ListItem>Student Faculty</asp:ListItem>
                                    <asp:ListItem>Student Programme</asp:ListItem>
                                    <asp:ListItem>Student Campus</asp:ListItem>
                                    <asp:ListItem>Student Level</asp:ListItem>
                                    <asp:ListItem>Student Mode</asp:ListItem>
                                    <asp:ListItem>Staff Department</asp:ListItem>
                                    <asp:ListItem>Staff Type</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="caption">
                                <%-- Leave Empty --%>
                            </td>
                            <td class="content">
                                <asp:DropDownList ID="ddStudBranch" runat="server" CssClass="dropdown" Visible="false" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="ddStudFaculty" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStudProgram" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStudCampus" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStudLevel" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStudMode" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStafDepartment" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                                <asp:DropDownList ID="ddStafType" runat="server" CssClass="dropdown" Visible="false"></asp:DropDownList>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate></asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="padding:0 30px; margin:auto;">
                                <asp:Panel ID="PanelDisplay" runat="server" Visible="false" >
                                    <hr />
                                    <div class="input-control checkbox" data-role="input-control">
                                        <strong><label class="inline-block">Patron Options : </label></strong>

                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkPatron" runat="server" />
                                            <span class="check"></span>
                                            Patron
                                        </label>

                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStudFaculty" runat="server" />
                                            <span class="check"></span>
                                            Faculty
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStudProgram" runat="server" />
                                            <span class="check"></span>
                                            Programme
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStudCampus" runat="server" />
                                            <span class="check"></span>
                                            Campus
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStudLevel" runat="server" />
                                            <span class="check"></span>
                                            Study Level
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStudMode" runat="server" />
                                            <span class="check"></span>
                                            Study Mode
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStafDept" runat="server" />
                                            <span class="check"></span>
                                            Staff Department
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkStafType" runat="server" />
                                            <span class="check"></span>
                                            Staff Type
                                        </label>
                                    </div>

                                    <div style="clear:both"></div>
                                    
                                    <div class="input-control checkbox" data-role="input-control">
                                        <strong><label class="inline-block">Officer Options : </label></strong>

                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkOfficer" runat="server" />
                                            <span class="check"></span>
                                            Officer
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkBranch" runat="server" />
                                            <span class="check"></span>
                                            Branch
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkSatellite" runat="server" />
                                            <span class="check"></span>
                                            Satellite
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkDepartment" runat="server" />
                                            <span class="check"></span>
                                            Department
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkDivision" runat="server" />
                                            <span class="check"></span>
                                            Division
                                        </label>
                                        <label class="inline-block">
                                            <asp:CheckBox ID="chkUnit" runat="server" />
                                            <span class="check"></span>
                                            Unit
                                        </label>
                                    </div>

                                    <div style="clear:both"></div>

                                </asp:Panel>
                    </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="padding" style="text-align:center">
                <asp:Button ID="btnSubmit" runat="server" CssClass="warning" Text="Generate" />
            </td>
        </tr>
    </table>
</div>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gSqlCommand" runat="server" Text=""></asp:Label>
    <asp:Label ID="gMessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="gVirtualRedirectPath" runat="server" Text="#"></asp:Label>
    <asp:Label ID="gQueryString" runat="server" Text=""></asp:Label>
</asp:Panel>
