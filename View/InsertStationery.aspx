<%@ Page Title="Insert Stationery" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="InsertStationery.aspx.cs" Inherits="PSDProject.View.InsertStationery" %>
<asp:Content ID="InsertStationery" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Insert Stationery</h1>
    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Stationery Name: "></asp:Label>
        <asp:TextBox ID="txt_stationeryname" runat="server"></asp:TextBox>
    </div>
    <div>
    <asp:Label ID="lbl_price" runat="server" Text="Stationery Price: "></asp:Label>
    <asp:TextBox ID="txt_stationeryprice" runat="server"></asp:TextBox>
</div>
    
    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click" />
</asp:Content>
