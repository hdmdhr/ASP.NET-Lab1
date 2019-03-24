<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Available.aspx.cs" Inherits="Lab1.Available" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Available Slips.</h1>
    <asp:GridView ID="grdAvailableSlips" CssClass="table table-striped" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" PageSize="20">
        <Columns>
            <asp:BoundField DataField="SlipID" HeaderText="SlipID" SortExpression="SlipID" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
            <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAvailableSlips" TypeName="CPRG214.Marina.Domain.SlipManager"></asp:ObjectDataSource>

</asp:Content>
