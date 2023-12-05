<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Container.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Admin.UserSearchInternal.Container" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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

            <asp:Panel ID="PanelOption" runat="server" Visible="false">
                <div class="input-control radio inline-block" data-role="input-control">
            
                    <table style="width:100%; table-layout:fixed;">
                        <tr>
                            <td>
                                Search By :
                            </td>
                            <td>
                                <label class="inline-block" title="Search by Patron ID">
                                    <asp:RadioButton ID="rbPatronId" runat="server" GroupName="r1" Checked="true"/>
                                    <span class="check"></span>
                                   Patron ID
                                </label>
                            </td>
                            <td>
                                <label class="inline-block" title="Search by IC or Passport">
                                    <asp:RadioButton ID="rbPassport" runat="server" GroupName="r1"/>
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
                        
                    </table>

                </div>


            </asp:Panel>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <hr />
    <asp:Panel ID="PanelLegend" runat="server" Visible="false">
        <label>Legend :</label>
        <div class="legend bg-darkBlue fg-white">
            Library Staff
        </div>
        <div class="legend bg-darkViolet fg-white">
            Staff
        </div>
        <div class="legend bg-darkOrange fg-white">
            Student
        </div>
        <div class="legend bg-darkCobalt fg-white">
            Other
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

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gVirtualPathRedirect" runat="server" Text="~/"></asp:Label>
    <asp:Label ID="gQueryString" runat="server" Text=""></asp:Label>
</asp:Panel>
