<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUI.Master" CodeBehind="WebForm2.aspx.vb" Inherits="Rdms_Metro.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=ResolveUrl("~/Content/DataTable.min.css")%>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div class="nastable">
        <asp:GridView ID="GridView1" runat="server" CssClass="table striped hovered" AutoGenerateColumns="False" >
            <Columns>

            <asp:TemplateField HeaderText="No" ItemStyle-Width="35" ControlStyle-Width="35">
                <ItemTemplate>
                    <asp:Label ID="Label0" runat="server" 
                            Text="<%# Container.DataItemIndex + 1 %> "></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="35px" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" 
                    Width="5px" />
            </asp:TemplateField>

<%--            <asp:TemplateField HeaderText="ID" SortExpression="Patron_Name">
                <ItemTemplate>
                    <asp:Label ID="LabelId" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Patron ID" SortExpression="Patron_Name">
                <ItemTemplate>
                    <asp:Label ID="LabelFullName" runat="server" Text='<%# Bind("patronid")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Medium" SortExpression="Patron_ID">
                <ItemTemplate>
                    <asp:Label ID="Labele" runat="server" Text='<%# Bind("mediumId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Time Start" SortExpression="timeStart">
                <ItemTemplate>
                    <asp:Label ID="Labelw" runat="server" Text='<%# Bind("timeStart")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Question" SortExpression="question">
                <ItemTemplate>
                    <asp:Label ID="Labelq" runat="server" Text='<%# Bind("question")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

                        
        </Columns>
        </asp:GridView>
    </div>
</asp:Content>
