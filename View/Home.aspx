<%@ Page Title="" Language="C#" MasterPageFile="~/Master/GuestMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSDProject.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Stationeries</h1>
    <asp:Button ID="btn_insert" runat="server" Text="Insert Stationery" OnClick="btn_insert_Click" />
    <asp:GridView ID="gv_stationeries" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_stationeries_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Stationery Name">
                <ItemTemplate>
                    <asp:HyperLink ID="hlStationeryDetails" runat="server" Text='<%# Eval("StationeryName") %>' NavigateUrl='<%# Eval("StationeryID", "StationeryDetails.aspx?ID={0}") %>' />
                    <asp:Label ID="lblStationeryName" runat="server" Text='<%# Eval("StationeryName") %>' Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StationeryPrice" HeaderText="Stationery Price" SortExpression="StationeryPrice" />
        </Columns>
    </asp:GridView>
</asp:Content>
