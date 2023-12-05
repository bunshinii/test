<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masters/MetroUINoSide.Master" CodeBehind="Login.aspx.vb" Inherits="Rdms_Metro.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin:100px auto; width:500px;">
        <div style="width:80%; margin:10px auto;">
        <div style="font-size: 2.2rem;line-height: 2.2rem;"> 
            <span class="icon-user-2"></span> <strong>Login</strong>
        </div> 

        <asp:Login ID="Login1" runat="server">
            <LayoutTemplate>
                <label>
                    Staff ID
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login2" ForeColor="Red">*</asp:RequiredFieldValidator>
                </label>
                    <div class="input-control text">
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                </div>

                <label>
                    Password
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login2" ForeColor="Red">*</asp:RequiredFieldValidator>
                </label>

                 <div class="input-control password">
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                 </div>

                <div style="display:inline-block;">
                    <asp:CheckBox ID="RememberMe" runat="server" />    
                </div>
                Remember Me.

                <br /><br />
                <div class="form-actions" style="text-align:right">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="ctl00$Login2" />
                </div>
                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                
            </LayoutTemplate>
        </asp:Login>
    </div>
    </div>
</asp:Content>
