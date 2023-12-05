<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserMenu.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.LeftCharm.UserMenu" %>

    <li class="title"><span class="icon-user-2"></span> <strong>User</strong> </li>
    <li><a href="<%=ResolveUrl("~/Pages/User/DashBoard.aspx")%>"><i class="icon-home"></i>Dashboard <span id="span1" runat="server" visible="false" style="color:red"><span class="icon-eye"></span></span></a></li>
    <li><a href="<%=ResolveUrl("~/Pages/User/PatronSearch.aspx")%>"><i class="icon-user"></i>Patron Check-In</a></li>
    <li><a href="<%=ResolveUrl("~/Pages/User/EditCheckedIn.aspx")%>"><i class="icon-wrench"></i>Edit Checked-In</a></li>
    <li><a href="<%=ResolveUrl("~/Pages/User/EditKiv.aspx")%>"><i class="icon-busy"></i>KIV <span style="color:red"><%= CaptionKivCount%></span></a></li>
    <li><a href="<%=ResolveUrl("~/Pages/User/Duty.aspx")%>"><i class="icon-calendar"></i>Duty Schedule</a></li>
    <br />

    <li class="title"><span class="icon-files"></span> <strong>Logs</strong> </li>
    <li><a href="<%=ResolveUrl("~/Pages/User/WorkLog.aspx")%>"><i class="icon-pencil"></i>Write Log</a></li>
    <li><a href="<%=ResolveUrl("~/Pages/User/ViewLog.aspx")%>"><i class="icon-file-4"></i>View Logs</a></li>
    <br />

            
    <li class="title"><span class="icon-stats-up"></span> <strong>Reporting </strong> </li>
    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-pie"></span> Charts </a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/User/Chart/Daily.aspx")%>">Daily Chart</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Chart/Monthly.aspx")%>">Monthly Chart</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Chart/Yearly.aspx")%>">Yearly Chart</a></li>
        </ul>
    </li>
            
    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-clipboard-2"></span> Listing </a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/User/Listing/Daily.aspx")%>">Daily Listing</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Listing/Monthly.aspx")%>">Monthly Listing</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Listing/Yearly.aspx")%>">Yearly Listing</a></li>
        </ul>
    </li>

    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-stats-up"></span> Statistics </a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/User/Statistic/Daily.aspx")%>">Daily Statistic</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Statistic/Monthly.aspx")%>">Monthly Statictic</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/User/Statistic/Yearly.aspx")%>">Yearly Statistic</a></li>
        </ul>
    </li>
    <br />