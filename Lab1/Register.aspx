<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Lab1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    <table class="table table-primary" style="width: 50%; text-align: center;">
        <thead>
            <tr><th colspan="2">
                <img class="mb-4" src="images/icon_marina.svg" alt="" width="72" height="72">
                <h2 class="mb-3 font-weight-normal">Please Register</h2>
            </th></tr>
        </thead>
        <tbody>
            <tr>
                <td style="text-align: right">
                    <em>First Name:</em>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is required." ControlToValidate="txtFName" ForeColor="Red">*required
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <em>Last Name:</em>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name is required." ControlToValidate="txtLName" ForeColor="Red">*required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <em>Phone:</em>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Phone number is required." ControlToValidate="txtPhone" ForeColor="Red">*required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <em>City:</em>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City is required." ControlToValidate="txtCity" ForeColor="Red">*required</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegister" CssClass="btn-outline-primary" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <p class="mt-5 mb-3 text-muted">&copy; Inland Lake Marina 2019</p>
    
    
    
</asp:Content>
