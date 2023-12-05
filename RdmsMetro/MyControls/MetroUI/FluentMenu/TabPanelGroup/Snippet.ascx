<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Snippet.ascx.vb" Inherits="Rdms_Metro.MyControls.MetroUI.FluentMenu.TabPanelGroup.Snippet" %>


<!-- Start Group -->
<%--<div class="tab-panel-group">
	<div class="tab-group-content">--%>

<div style="padding:20px;">
        <div class="tab-content-segment">

            <div style="height:95px; overflow:hidden; font-family:Arial; font-size:12px; white-space:nowrap; padding-top:8px;" >
               <table>
                   <tr>
                       <td>
                            Question Snippet : 
                       </td>
                       <td>
                           <asp:DropDownList ID="ddQuestion" runat="server" Width="600px" ></asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2">&nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                            Answer Snippet : 
                       </td>
                       <td>
                           <asp:DropDownList ID="ddAnswer" runat="server" Width="600px" ></asp:DropDownList>
                       </td>
                   </tr>
               </table>
                
                
              
            </div>

        </div>

</div>
<%--	</div>
	<div class="tab-group-caption">Snippet</div>
</div>--%>
<!-- End Group -->