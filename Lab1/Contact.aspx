<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Lab1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact Page.</h3>
    <address>
        Inland Lake Marina<br />
        Box 123<br />
        Inland Lake, Arizona<br/>
        86038<br/>
        <abbr title="Office Phone">OP:</abbr>
        928-450-2234<br/>
        <abbr title="Leasing Phone">LP:</abbr>
        928-450-2235<br/>
        <abbr title="Fax">F:</abbr>
        928-450-2236<br/>
    </address>

    <address>
        <strong>Contact email:</strong>   <a href="mailto:info@inlandmarina.com">info@inlandmarina.com</a><br />
    </address>
</asp:Content>
