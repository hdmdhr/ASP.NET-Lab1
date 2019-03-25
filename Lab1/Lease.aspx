<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="Lab1.Lease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Redirect back to register if no Session["customer"]</h1>
    <asp:Label ID="lblLeaseHistory" runat="server" CssClass="h3 mb-4"></asp:Label>
    <asp:GridView ID="grdLeaseHistory" runat="server" CssClass="table table-dark table-striped"/>
    <h2>Show leasing table.</h2>

<%--    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="FindLeasingHistory" TypeName="CPRG214.Marina.Domain.CustomerManager">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="c" SessionField="customer" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
</asp:Content>
