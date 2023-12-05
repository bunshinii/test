<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.CheckIn.Search.Container" %>


<h2>Search<sup><asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please fill in the Search Box" ForeColor="Red" ControlToValidate="txtSearch"/></sup></h2>

<div style="width:90%; min-height:400px;">
    <asp:Panel ID="PanelMain" runat="server" DefaultButton="hiddenButton">
        <div class="input-control text" data-role="input-control">
            <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
            <button runat="server" id="btnSearch" class="btn-search"></button>

            <div style="width:0;height:0; overflow:hidden">
                <asp:Button ID="hiddenButton" runat="server" text="tst" />
            </div>
        </div>

    

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

            <asp:LinkButton ID="lbOption" runat="server" CausesValidation="false">Option</asp:LinkButton>
            <asp:Panel ID="PanelOption" runat="server" Visible="true">
                <div class="input-control radio inline-block" data-role="input-control">
            
                    <table style="width:100%; table-layout:fixed;">
                        <tr>
                            <td>
                                Search By :
                            </td>
                            <td>
                                <label class="inline-block" title="Search by Patron ID">
                                    <asp:RadioButton ID="rbPatronId" runat="server" GroupName="r1" Checked="true" AutoPostBack="false" />
                                    <span class="check"></span>
                                   Patron ID
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Search by IC or Passport">
                                    <asp:RadioButton ID="rbPassport" runat="server" GroupName="r1" />
                                    <span class="check"></span>
                                    IC/Passport
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Search by Full Name">
                                    <asp:RadioButton ID="rbName" runat="server" GroupName="r1" />
                                    <span class="check"></span>
                                    Name
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Search by Patron ID and IC and Full Name.">
                                    <asp:RadioButton ID="rbAll" runat="server" GroupName="r1" />
                                    <span class="check"></span>
                                    All <sup>*very slow</sup>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Display :
                            </td>
                            <td>
                                <label class="inline-block" title="Display All Students and Staffs">
                                    <asp:RadioButton ID="rbFilterAll" runat="server" GroupName="r2" Checked="true" />
                                    <span class="check"></span>
                                   All
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Display Students Only">
                                    <asp:RadioButton ID="rbFilterStudent" runat="server" GroupName="r2" />
                                    <span class="check"></span>
                                    Student
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Display Staffs Only">
                                    <asp:RadioButton ID="rbFilterStaff" runat="server" GroupName="r2" />
                                    <span class="check"></span>
                                    Staff
                                </label>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td><td></td><td></td><td></td>
                            <td style="text-align:right">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/User/PatronCheckInCustom.aspx">Custom Check-In</asp:HyperLink>
                            </td>
                        </tr>
                    </table>

                </div>


            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <hr />
    <asp:Panel ID="PanelLegend" runat="server" Visible="false">
        <label>Legend :</label>
        <div runat="server" id="LegStud" class="legend bg-darkOrange fg-white">
            Active Student
        </div>
        <div runat="server" id="LegStaf" class="legend bg-darkBlue fg-white">
            Active Staff
        </div>
        <div class="legend bg-darkRed fg-white">
            Not Active
        </div>
        <div runat="server" id="LegOther" class="legend">
            Others
        </div>

        <span style="clear:left; display:block;"></span>
    </asp:Panel>
    <hr />

    <asp:Label ID="lblResults" runat="server"/>

    <div class="listview">
    
    <asp:PlaceHolder ID="phItem" runat="server"/>

    <span style="clear:left; display:block;"></span>
    </div>
</div>



