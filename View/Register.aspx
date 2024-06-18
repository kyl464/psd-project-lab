<%@ Page Title="Register" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PSDProject.View.LoginPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_gender" runat="server" Text="Gender: "></asp:Label>
        <asp:RadioButtonList ID="radio_gender" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="Male">Male</asp:ListItem>
            <asp:ListItem Value="Female">Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>

    <div>
        <asp:Label ID="lbl_dob" runat="server" Text="DOB: "></asp:Label>
        <asp:TextBox ID="txt_dob" TextMode="Date" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_phone" runat="server" Text="Phone: "></asp:Label>
        <asp:TextBox ID="txt_phone" MaxLength="15" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_address" runat="server" Text="Address :"></asp:Label>
        <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_password" runat="server" Text="Password :"></asp:Label>
        <asp:TextBox ID="txt_password" TextMode="Password" runat="server"></asp:TextBox>
    </div>

     <div>
     <asp:Label ID="lbl_confirm" runat="server" Text="Password :"></asp:Label>
     <asp:TextBox ID="txt_confirm" TextMode="Password" runat="server"></asp:TextBox>
 </div>

    <div>
        <asp:CheckBox ID="check_rememberme" runat="server" Text="Remember Me" />
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    
    <asp:Button ID="Register_Button" runat="server" Text="Register" OnClick="Register_Button_Click" />

</asp:Content>

