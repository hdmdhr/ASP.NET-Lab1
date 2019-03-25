<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="Lab1.Lease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container p-2">
        <div class="row">
            <h3 class="col-sm-6">To lease slip, please pick a dock.</h3>
            <asp:DropDownList ID="drpDockPicker" runat="server" CssClass="col-sm-6" OnSelectedIndexChanged="drpDockPicker_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">--Please Select--</asp:ListItem>
                <asp:ListItem Value="1">Dock A (Water, Electricity)</asp:ListItem>
                <asp:ListItem Value="2">Dock B (Water only)</asp:ListItem>
                <asp:ListItem Value="3">Dock C (Electricity only)</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    
    <hr/>
        <asp:GridView ID="grdAvailableSlips" runat="server" CssClass="table table-bordered d-sm-table-cell table-hover w-50" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowCommand="grdAvailableSlips_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:ButtonField CommandName="lease" Text="Lease"/>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <asp:Label ID="lblLeaseHistory" runat="server" CssClass="h3 my-4"></asp:Label>
    <asp:GridView ID="grdLeaseHistory" runat="server" CssClass="table table-dark table-striped w-50 my-4"/>

</asp:Content>
