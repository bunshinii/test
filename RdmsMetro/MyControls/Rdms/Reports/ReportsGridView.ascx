<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ReportsGridView.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Reports.ReportsGridView" %>


    <div style="min-height:560px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label> recorded sessions.
     <div class="nastable">
        <asp:GridView ID="GridView1" runat="server" CssClass="table striped hovered" AutoGenerateColumns="False" >
            <Columns>

            <asp:TemplateField HeaderText="sessionId" SortExpression="sessionId" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="sessionId" runat="server" Text='<%# Bind("sessionId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
                
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

            <asp:TemplateField HeaderText="Patron ID" SortExpression="patronId">
                <ItemTemplate>
                    <asp:Label ID="patronId" runat="server" Text='<%# Bind("patronId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Patron Name">
                <ItemTemplate>
                    <asp:HyperLink ID="hlpatronname" runat="server" Target="_blank" NavigateUrl="#">
                        <asp:Label ID="patronname" runat="server" ></asp:Label>
                    </asp:HyperLink>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Medium" SortExpression="mediumId">
                <ItemTemplate>
                    <asp:Label ID="mediumId" runat="server" Text='<%# Bind("mediumId")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subjects">
                <ItemTemplate>
                    <asp:Label ID="sub_od" runat="server" Text='<%# Bind("sub_od")%>' ToolTip="Online Database"></asp:Label>
                    <asp:Label ID="sub_dc" runat="server" Text='<%# Bind("sub_dc")%>' ToolTip="Digital Collection"></asp:Label>
                    <asp:Label ID="sub_it" runat="server" Text='<%# Bind("sub_it")%>' ToolTip="Internet"></asp:Label>
                    <asp:Label ID="sub_op" runat="server" Text='<%# Bind("sub_op")%>' ToolTip="OPAC"></asp:Label>
                    <asp:Label ID="sub_lrc" runat="server" Text='<%# Bind("sub_lrc")%>' ToolTip="Law Reference Collections"></asp:Label>
                    <asp:Label ID="sub_rc" runat="server" Text='<%# Bind("sub_rc")%>' ToolTip="Reference Citations"></asp:Label>
                    <asp:Label ID="sub_fs" runat="server" Text='<%# Bind("sub_fs")%>' ToolTip="Facility & Services"></asp:Label>
                    <asp:Label ID="sub_vp" runat="server" Text='<%# Bind("sub_vp")%>' ToolTip="Validasi Penerbitan"></asp:Label>
                    <asp:Label ID="sub_ja" runat="server" Text='<%# Bind("sub_ja")%>' ToolTip="Record & Archive"></asp:Label>
                    <asp:Label ID="sub_gt" runat="server" Text='<%# Bind("sub_gt")%>' ToolTip="Galeri TAR"></asp:Label>
                    <asp:Label ID="sub_etc" runat="server" Text='<%# Bind("sub_etc")%>' ToolTip="Others"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Enquiries">
                <ItemTemplate>
                    <asp:Label ID="enq_qr" runat="server" Text='<%# Bind("enq_qr")%>' ToolTip="Quick Reference"></asp:Label>
                    <asp:Label ID="enq_rr" runat="server" Text='<%# Bind("enq_rr")%>' ToolTip="Research Reference"></asp:Label>
                    <asp:Label ID="enq_st" runat="server" Text='<%# Bind("enq_st")%>' ToolTip="Search Technique"></asp:Label>
                    <asp:Label ID="enq_ag" runat="server" Text='<%# Bind("enq_ag")%>' ToolTip="Advisory and Guidance"></asp:Label>
                    <asp:Label ID="enq_etc" runat="server" Text='<%# Bind("enq_etc")%>' ToolTip="Others"></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date" SortExpression="timeStart">
                <ItemTemplate>
                    <asp:Label ID="timeStart" runat="server" Text='<%# Bind("timeStart", "{0:dd/MM/yyyy HH:mm:ss}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  /><ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Duration" SortExpression="duration">
                <ItemTemplate>
                    <asp:Label ID="duration" runat="server" Text='<%# Bind("duration")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" /><ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Officer" SortExpression="officer" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="officer" runat="server" Text='<%# Bind("officer")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

                        
        </Columns>
        </asp:GridView>
    </div>

          </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <asp:Timer ID="Timer1" runat="server" Interval="500"></asp:Timer>

<asp:Panel ID="PanelDebug" runat="server" Visible="false">
    <asp:Label ID="gSqlCommand" runat="server" Text=""></asp:Label>
    <asp:Label ID="gTotal" runat="server" Text="0"></asp:Label>
</asp:Panel>
