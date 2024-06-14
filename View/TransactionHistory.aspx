<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/GuestMaster.Master" CodeBehind="TransactionHistory.aspx.cs" Inherits="PSDProject.View.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction History</h1>
    
    <asp:GridView ID="gv_TransactionHistory" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_TransactionHistory_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="UserName" HeaderText="Customer Name" SortExpression="UserName" />
            <asp:ButtonField ButtonType="Button" CommandName="ViewDetails" Text="View Details"/>
        </Columns>
    </asp:GridView>
</asp:Content>