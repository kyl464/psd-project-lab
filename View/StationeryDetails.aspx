<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="StationeryDetails.aspx.cs" Inherits="PSDProject.View.StationeryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Stationery Details</h1>

    <asp:GridView ID="gvStationeryDetails" runat="server" AutoGenerateColumns="False" Width="457px">
        <Columns>
            <asp:BoundField DataField="StationeryID" HeaderText="ID" />
            <asp:BoundField DataField="StationeryName" HeaderText="Name" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Price" />
        </Columns>
    </asp:GridView>

    <br />

    Quantity: <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    <br />
    <asp:HiddenField ID="HiddenUserID" runat="server" />
    <asp:HiddenField ID="HiddenStationeryID" runat="server" />
    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
</asp:Content>
