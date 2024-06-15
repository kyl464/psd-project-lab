<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="PSDProject.View.UpdateStationery" %>

<asp:Content ID="UpdateStationery" ContentPlaceHolderID="ContentBody" runat="server">

    <h1>Update Stationery</h1>
    <div>
        <asp:Label ID="lbl_name" runat="server" Text="Stationery Name (Must be between 3 - 50 characters): "></asp:Label>
        <asp:TextBox ID="txt_stationeryname" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_price" runat="server" Text="Stationery Price (Must be greater or equal to 2000): "></asp:Label>
        <asp:TextBox ID="txt_stationeryprice" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
</asp:Content>
