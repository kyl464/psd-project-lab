<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PSDProject.View.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Shopping Cart</h1>
    
    <!-- GridView untuk menampilkan item dalam keranjang -->
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting">
        <Columns>
            <asp:BoundField DataField="StationeryID" HeaderText="Stationery ID" />
            <asp:BoundField DataField="MsStationery.StationeryName" HeaderText="Stationery Name" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Remove" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- Tombol Update Cart -->
    <asp:Button ID="btnUpdateCart" runat="server" Text="Update Cart" OnClick="btnUpdateCart_Click" />

    <!-- Tombol Checkout -->
    <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />
</asp:Content>
