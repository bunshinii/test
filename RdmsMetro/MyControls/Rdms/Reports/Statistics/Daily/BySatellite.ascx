<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BySatellite.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Reports.Statistics.Daily.BySatellite" %>

<%--
MyControls.Rdms.Reports.Statistics
--%>
<asp:GridView ID="GridView1" runat="server" CssClass="table striped hovered" AutoGenerateColumns="false" Width="600px" ShowFooter="true" >
    <Columns>

            <asp:TemplateField HeaderText="No" ItemStyle-Width="35" ControlStyle-Width="35">
                <ItemTemplate>
                    <asp:Label ID="Label0" runat="server" 
                            Text="<%# Container.DataItemIndex + 1 %> "></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="35px" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="5px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Satellite ID" SortExpression="satelliteId" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="satelliteId" runat="server" Text='<%# Bind("satelliteId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Satellite">
                <ItemTemplate>

                        <asp:Label ID="fullname" runat="server" ></asp:Label>

                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total" SortExpression="total">
                <ItemTemplate>
                    <asp:Label ID="total" runat="server" Text='<%# Bind("total")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Wrap="False" Width="5px" />
            </asp:TemplateField>

    </Columns>
</asp:GridView>
