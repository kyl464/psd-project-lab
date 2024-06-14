<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSDProject.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Stationeries</h1>
    <asp:Button ID="btn_insert" runat="server" Text="Insert Stationery" OnClick="btn_insert_Click" />
    <asp:GridView ID="gv_stationeries" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StationeryName" HeaderText="Stationery Name" SortExpression="StationeryName" />
            <asp:BoundField DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
        </Columns>
    </asp:GridView>
</asp:Content>
