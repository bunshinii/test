<%@ Page Title="Write Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="WorkLog.aspx.vb" Inherits="Rdms_Metro.WorkLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1><span class="icon-pencil"></span> <%=Title%></h1>
    <hr /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel">
        <div class="panel-content">
            <label>Write Log :</label>
            <asp:TextBox ID="txtLog" runat="server" TextMode="MultiLine" Width="100%" Height="200px" ClientIDMode="Static"></asp:TextBox>

            <br /><br />
            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Right">
                <asp:Button ID="btnSave" runat="server" Text="Save Log" />
            </asp:Panel>
            
        </div>
    </div>

</asp:Content>
