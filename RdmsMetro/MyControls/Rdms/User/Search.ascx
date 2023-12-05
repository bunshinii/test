<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Search.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.User.Search" %>

<h4>Search<sup><asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Please fill in the Search Box" ForeColor="Red" ControlToValidate="txtSearch"/></sup></h4>

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
            <asp:Panel ID="PanelOption" runat="server" Visible="false">
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
                                   Staff ID
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
                                    <asp:RadioButton ID="rbFilterBranch" runat="server" GroupName="r2" Checked="true" />
                                    <span class="check"></span>
                                   Within Branch
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Display Students Only">
                                    <asp:RadioButton ID="rbFilterSatellite" runat="server" GroupName="r2" />
                                    <span class="check"></span>
                                    Within Satellite
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Display Staffs Only">
                                    <asp:RadioButton ID="rbFilterDepartment" runat="server" GroupName="r2" />
                                    <span class="check"></span>
                                    Within Department
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Display Staffs Only">
                                    <asp:RadioButton ID="rbFilterDivision" runat="server" GroupName="r2" />
                                    <span class="check"></span>
                                    Within Division
                                </label>
                            </td>
                        </tr>
                    </table>

                </div>


            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <hr />

    <asp:Label ID="lblResults" runat="server"/>

    <div class="listview">
    
    <asp:PlaceHolder ID="phItem" runat="server"/>

    <span style="clear:left; display:block;"></span>
    </div>
</div>