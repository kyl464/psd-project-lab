<%@ Page Title="" Language="C#" MasterPageFile="~/Master/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="PSDProject.View.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <div>
            <div>Update Profile</div>
            <div>
                <asp:Label ID="Lbl_Username" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="Txt_Username" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_Email" runat="server" Text="Address:"></asp:Label>
                <asp:TextBox ID="Txt_Email" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="RBtn_Gender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth (DD/MM/YY):"></asp:Label>
                <asp:TextBox ID="Txt_DOB" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_error" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="Lbl_scs" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Button ID="Btn_UpdateProfile" runat="server" Text="Update Profile" OnClick="Btn_UpdateProfile_Click"/>
            </div>
        </div>
        <div>
            <div>
                <asp:Label ID="Lbl_currentPassword" runat="server" Text="Current Password:"></asp:Label>
                <asp:TextBox ID="Txt_currentPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_newPassword" runat="server" Text="New Password:"></asp:Label>
                <asp:TextBox ID="Txt_newPassword" runat="server" TextMode="Password"</asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_confirmationPassword" runat="server" Text="Confirmation Password:"></asp:Label>
                <asp:TextBox ID="Txt_confirmationPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Lbl_error2" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="Lbl_scs2" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Button ID="btn_updatePassword" runat="server" Text="Update Password" OnClick="btn_updatePassword_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
