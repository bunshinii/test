<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ByDepartment.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Reports.Statistics.Yearly.ByDepartment" %>

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

            <asp:TemplateField HeaderText="Department ID" SortExpression="departmentId" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="departmentId" runat="server" Text='<%# Bind("departmentId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Department">
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
