<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="PSDProject.View.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Checkout Confirmation</h1>

    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting">
        <Columns>
            <asp:BoundField DataField="StationeryID" HeaderText="Stationery ID" />
            <asp:BoundField DataField="MsStationery.StationeryName" HeaderText="Stationery Name" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" />
    <asp:Button ID="btn_confirm" runat="server" Text="Confirm" />

</asp:Content>
