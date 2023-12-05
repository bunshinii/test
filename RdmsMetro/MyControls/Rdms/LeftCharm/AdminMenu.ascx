<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AdminMenu.ascx.vb" Inherits="Rdms_Metro.MyControls.Rdms.LeftCharm.AdminMenu" %>

    <li class="title"><span class="icon-wrench"></span> <strong>Administrator</strong> </li>

    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-user-3"></span>Manage Users</a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/Admin/UserSearch.aspx")%>">Register a User</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/UserSearchInternal.aspx")%>">Edit Users</a></li>
            <li><a href="<%=ResolveUrl("~/Account/PwdReset.aspx")%>">Reset User Password</a></li>
        </ul>
    </li>

    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-grid"></span>Manage Organization </a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Organization/Branch.aspx")%>">Branch</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Organization/Satellite.aspx")%>">Satellite</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Organization/Department.aspx")%>">Department</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Organization/Division.aspx")%>">Division</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Organization/Unit.aspx")%>">Unit</a></li>
        </ul>
    </li>

    <li>
        <a class="dropdown-toggle" href="#"><span class="icon-cog"></span>Application </a>
        <ul class="dropdown-menu" data-role="dropdown">
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Application/Announcement/Announcement.aspx")%>">Announcement</a></li>
            <li><a href="<%=ResolveUrl("~/Pages/Admin/Application/RssReader.aspx")%>">Feed Reader</a></li>
        </ul>
    </li>
