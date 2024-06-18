<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PSDProject.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="txt_name" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_gender" runat="server" Text="Gender: "></asp:Label>
        <asp:Label ID="txt_gender" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lbl_dob" runat="server" Text="DOB: "></asp:Label>
        <asp:Label ID="txt_dob" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_phone" runat="server" Text="Phone: "></asp:Label>
        <asp:Label ID="txt_phone" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_address" runat="server" Text="Address: "></asp:Label>
        <asp:Label ID="txt_address" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        <asp:Label ID="txt_password" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lbl_role" runat="server" Text="Role: "></asp:Label>
        <asp:Label ID="txt_role" runat="server"></asp:Label>
    </div>

    <asp:Button ID="btn_update" runat="server" Text="Update Profile" OnClick="btn_update_Click" />
</asp:Content>
