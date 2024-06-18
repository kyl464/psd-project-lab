<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="PSDProject.View.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Checkout Confirmation</h1>

    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StationeryID" HeaderText="Stationery ID" />
            <asp:BoundField DataField="MsStationery.StationeryName" HeaderText="Stationery Name" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' ReadOnly="true"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
    <asp:Button ID="btn_confirm" runat="server" Text="Confirm" OnClick="btn_confirm_Click" />

</asp:Content>
