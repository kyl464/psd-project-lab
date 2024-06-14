<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PSDProject.View.RegisterPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_password" TextMode="Password" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_confirm" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="txt_confirm" TextMode="Password" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:CheckBox ID="check_rememberme" runat="server" Text="Remember Me" />
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="Red" ></asp:Label>
    </div>
    
    <asp:Button ID="Login_Button" runat="server" Text="Login" OnClick="Login_Button_Click" />
</asp:Content>
