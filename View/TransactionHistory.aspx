<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/LoggedInMaster.Master" CodeBehind="TransactionHistory.aspx.cs" Inherits="PSDProject.View.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Transaction History</h1>
    
    <asp:GridView ID="gv_TransactionHistory" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_TransactionHistory_SelectedIndexChanged" OnRowCommand="gv_TransactionHistory_RowCommand" DataKeyNames="TransactionID">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
        <asp:TemplateField HeaderText="Customer Name">
            <ItemTemplate>
                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("MsUser.UserName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField ButtonType="Button" CommandName="ViewDetails" Text="View Details" />
    </Columns>
</asp:GridView>

</asp:Content>
