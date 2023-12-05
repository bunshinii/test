<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ByMonthWeekly.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Charts.ByMonthWeekly" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%--Please include the below CSS--%>
<%--<link href="<%=ResolveUrl("~/Content/Chart.min.css")%>" rel="stylesheet" />--%>

    <h2><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h2>
    <h3><asp:Label ID="lblFilter" runat="server" Text=""></asp:Label></h3>

    <asp:CHART id="Chart1" runat="server" Width="1000px" Height="600px" ClientIDMode="Static" >
        <series>
            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" LegendText="Face to Face"  ChartType="StackedColumn" Name="Face2Face" Color="Red">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Live Chat" ChartType="StackedColumn"  Name="LiveChat" Color="Green">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Phone" ChartType="StackedColumn"  Name="Phone" Color="Blue">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="E-mail" ChartType="StackedColumn"  Name="Email" Color="Yellow">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Social Media" ChartType="StackedColumn"  Name="SocialMedia" Color="Purple">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Instant Messenger" ChartType="StackedColumn"  Name="InstantMessenger" Color="Pink">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Video Conferencing" ChartType="StackedColumn"  Name="VideoConferencing" Color="Black">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Others" ChartType="StackedColumn"  Name="Others" Color="Gray">
                <Points>
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                </Points>
            </asp:Series>

        </series>

        <chartareas>
            
            <asp:ChartArea Name="ChartArea1">
                <axisy Title="Usage"><MajorGrid LineColor="Gray" /></axisy>
                <axisx Title="Week" Interval="1" IsLabelAutoFit="true"><MajorGrid LineColor="Gray" Interval="1" /></axisx>
            </asp:ChartArea>
        </chartareas>

    </asp:CHART>

    <table class="table bordered hovered">
        <thead>
        <tr class="bg-darkBlue fg-white">
            <th>Color</th>
            <th>Hour</th>
            <th>Week 1</th>
            <th>Week 2</th>
            <th>Week 3</th>
            <th>Week 4</th>
            <th>Week 5</th>
            <th>Total</th>
        </tr>
        </thead>

        <tbody>
        <tr>
            <td style="background-color:red">&nbsp;</td>
            <td><% =MediumName(1) %></td>
            <td><asp:Label ID="lblFace01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFaceTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:green">&nbsp;</td>
            <td><% =MediumName(2) %></td>
            <td><asp:Label ID="lblChat01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChatTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:blue">&nbsp;</td>
            <td><% =MediumName(3) %></td>
            <td><asp:Label ID="lblPhone01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhoneTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:yellow">&nbsp;</td>
            <td><% =MediumName(4) %></td>
            <td><asp:Label ID="lblEmail01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmailTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:purple">&nbsp;</td>
            <td><% =MediumName(5) %></td>
            <td><asp:Label ID="lblSocial01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocialTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:pink">&nbsp;</td>
            <td><% =MediumName(6) %></td>
            <td><asp:Label ID="lblInMessanger01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessangerTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:black">&nbsp;</td>
            <td><% =MediumName(9) %></td>
            <td><asp:Label ID="lblVc01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVcTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:gray">&nbsp;</td>
            <td><% =MediumName(7) %></td>
            <td><asp:Label ID="lblOther01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOtherTotal" runat="server" Text="0"/></td>
        </tr>
        <tr style="background-color:lightgray">
            <td>&nbsp;</td>
            <td>Total</td>
            <td><asp:Label ID="lblTotalHour01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHours" runat="server" Text="0"/></td>
        </tr>

    </tbody>
</table>

<asp:Panel ID="PanelContentBox" runat="server" CssClass="contentBox">

    <asp:Panel ID="PanelSubject" runat="server" CssClass="subjectPanel">

        <table class="table bordered">
            <thead>
                <tr class="bg-darkBlue fg-white">
                    <td colspan="2">Total Subjects</td>
                </tr>
            </thead>

            <tr>
                <td>
                    Online Databases :
                </td>
                <td>
                    <asp:Label ID="lblSubOd" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Digital Collection :
                </td>
                <td>
                    <asp:Label ID="lblSubDc" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Internet :
                </td>
                <td>
                    <asp:Label ID="lblSubIt" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    OPAC :
                </td>
                <td>
                    <asp:Label ID="lblSubOp" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Law Reference Collections :
                </td>
                <td>
                    <asp:Label ID="lblSubLrc" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Reference Citations :
                </td>
                <td>
                    <asp:Label ID="lblSubRc" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Facility & Services :
                </td>
                <td>
                    <asp:Label ID="lblSubFs" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Validasi Penerbitan :
                </td>
                <td>
                    <asp:Label ID="lblSubVp" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Record & Archive :
                </td>
                <td>
                    <asp:Label ID="lblSubJa" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Galeri Tun Abdul Razak :
                </td>
                <td>
                    <asp:Label ID="lblSubGt" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Others :
                </td>
                <td>
                    <asp:Label ID="lblSubEt" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:lightgray">
                <td>
                    <strong>Total :</strong>
                </td>
                <td>
                    <strong><asp:Label ID="lblSubTotal" runat="server" Text="0"></asp:Label></strong>
                </td>
            </tr>

        </table>

    </asp:Panel>

    <asp:Panel ID="PanelEnquiry" runat="server" CssClass="enquiryPanel">

        <table class="table bordered">
            <thead>
                <tr class="bg-darkBlue fg-white">
                    <td colspan="2">Total Enquiries</td>
                </tr>
            </thead>

            <tr>
                <td>
                    Quick Reference :
                </td>
                <td>
                    <asp:Label ID="lblEnqQr" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Research Reference :
                </td>
                <td>
                    <asp:Label ID="lblEnqRr" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Search Technique :
                </td>
                <td>
                    <asp:Label ID="lblEnqSt" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Advice and Guidance :
                </td>
                <td>
                    <asp:Label ID="lblEnqAg" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Others :
                </td>
                <td>
                    <asp:Label ID="lblEnqEtc" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr style="background-color:lightgray">
                <td>
                    <strong>Total :</strong>
                </td>
                <td>
                    <strong><asp:Label ID="lblEnqTotal" runat="server" Text="0"></asp:Label></strong>
                </td>
            </tr>

        </table>

    </asp:Panel>

</asp:Panel>
