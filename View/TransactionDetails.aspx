<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="PSDProject.View.TransactionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction Details</h1>

    <asp:GridView ID="gvTransactionDetails" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Stationery.StationeryName" HeaderText="Stationery Name" />
            <asp:BoundField DataField="Stationery.StationeryPrice" HeaderText="Stationery Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>

</asp:Content>
