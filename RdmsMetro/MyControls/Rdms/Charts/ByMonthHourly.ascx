<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ByMonthHourly.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.Charts.ByMonthHourly" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%--Please include the below CSS--%>
<%--<link href="<%=ResolveUrl("~/Content/Chart.min.css")%>" rel="stylesheet" />--%>

    <h2><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h2>
    <h3><asp:Label ID="lblFilter" runat="server" Text=""></asp:Label></h3>

    <asp:CHART id="Chart1" runat="server" Width="1000px" Height="600px" ClientIDMode="Static" >
        <series>
            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" LegendText="Face to Face"  ChartType="StackedColumn" Name="Face2Face" Color="Red">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Live Chat" ChartType="StackedColumn"  Name="LiveChat" Color="Green">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Phone" ChartType="StackedColumn"  Name="Phone" Color="Blue">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="E-mail" ChartType="StackedColumn"  Name="Email" Color="Yellow">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Social Media" ChartType="StackedColumn"  Name="SocialMedia" Color="Purple">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Instant Messenger" ChartType="StackedColumn"  Name="InstantMessenger" Color="Pink">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Video Conferencing" ChartType="StackedColumn"  Name="VideoConferencing" Color="Black">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

            <asp:Series XValueType="Int32" IsValueShownAsLabel="false" Legend="Others" ChartType="StackedColumn"  Name="Others" Color="Gray">
                <Points>
                    <asp:DataPoint AxisLabel="00" YValues="1" />
                    <asp:DataPoint AxisLabel="01" YValues="1" />
                    <asp:DataPoint AxisLabel="02" YValues="1" />
                    <asp:DataPoint AxisLabel="03" YValues="1" />
                    <asp:DataPoint AxisLabel="04" YValues="1" />
                    <asp:DataPoint AxisLabel="05" YValues="1" />
                    <asp:DataPoint AxisLabel="06" YValues="1" />
                    <asp:DataPoint AxisLabel="07" YValues="1" />
                    <asp:DataPoint AxisLabel="08" YValues="1" />
                    <asp:DataPoint AxisLabel="09" YValues="1" />
                    <asp:DataPoint AxisLabel="10" YValues="1" />
                    <asp:DataPoint AxisLabel="11" YValues="1" />
                    <asp:DataPoint AxisLabel="12" YValues="1" />
                    <asp:DataPoint AxisLabel="13" YValues="1" />
                    <asp:DataPoint AxisLabel="14" YValues="1" />
                    <asp:DataPoint AxisLabel="15" YValues="1" />
                    <asp:DataPoint AxisLabel="16" YValues="1" />
                    <asp:DataPoint AxisLabel="17" YValues="1" />
                    <asp:DataPoint AxisLabel="18" YValues="1" />
                    <asp:DataPoint AxisLabel="19" YValues="1" />
                    <asp:DataPoint AxisLabel="20" YValues="1" />
                    <asp:DataPoint AxisLabel="21" YValues="1" />
                    <asp:DataPoint AxisLabel="22" YValues="1" />
                    <asp:DataPoint AxisLabel="23" YValues="1" />
                </Points>
            </asp:Series>

        </series>

        <chartareas>
            
            <asp:ChartArea Name="ChartArea1">
                <axisy Title="Usage"><MajorGrid LineColor="Gray" /></axisy>
                <axisx Title="Hour (24 Hours)" Interval="1" IsLabelAutoFit="true"><MajorGrid LineColor="Gray" Interval="1" /></axisx>
            </asp:ChartArea>
        </chartareas>

    </asp:CHART>

    <table class="table bordered hovered">
        <thead>
        <tr class="bg-darkBlue fg-white">
            <th>Color</th>
            <th>Hour</th>
            <th>00</th>
            <th>01</th>
            <th>02</th>
            <th>03</th>
            <th>04</th>
            <th>05</th>
            <th>06</th>
            <th>07</th>
            <th>08</th>
            <th>09</th>
            <th>10</th>
            <th>11</th>
            <th>12</th>
            <th>13</th>
            <th>14</th>
            <th>15</th>
            <th>16</th>
            <th>17</th>
            <th>18</th>
            <th>19</th>
            <th>20</th>
            <th>21</th>
            <th>22</th>
            <th>23</th>
            <th>Total</th>
        </tr>
        </thead>

        <tbody>
        <tr>
            <td style="background-color:red">&nbsp;</td>
            <td><% =MediumName(1) %></td>
            <td><asp:Label ID="lblFace00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFace23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblFaceTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:green">&nbsp;</td>
            <td><% =MediumName(2) %></td>
            <td><asp:Label ID="lblChat00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChat23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblChatTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:blue">&nbsp;</td>
            <td><% =MediumName(3) %></td>
            <td><asp:Label ID="lblPhone00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhone23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblPhoneTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:yellow">&nbsp;</td>
            <td><% =MediumName(4) %></td>
            <td><asp:Label ID="lblEmail00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmail23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblEmailTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:purple">&nbsp;</td>
            <td><% =MediumName(5) %></td>
            <td><asp:Label ID="lblSocial00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocial23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblSocialTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:pink">&nbsp;</td>
            <td><% =MediumName(6) %></td>
            <td><asp:Label ID="lblInMessanger00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessanger23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblInMessangerTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:black">&nbsp;</td>
            <td><% =MediumName(9) %></td>
            <td><asp:Label ID="lblVc00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVc23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblVcTotal" runat="server" Text="0"/></td>
        </tr>
        <tr>
            <td style="background-color:gray">&nbsp;</td>
            <td><% =MediumName(7) %></td>
            <td><asp:Label ID="lblOther00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOther23" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblOtherTotal" runat="server" Text="0"/></td>
        </tr>
        <tr style="background-color:lightgray">
            <td>&nbsp;</td>
            <td>Total</td>
            <td><asp:Label ID="lblTotalHour00" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour01" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour02" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour03" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour04" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour05" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour06" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour07" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour08" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour09" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour10" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour11" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour12" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour13" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour14" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour15" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour16" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour17" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour18" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour19" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour20" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour21" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour22" runat="server" Text="0"/></td>
            <td><asp:Label ID="lblTotalHour23" runat="server" Text="0"/></td>
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
