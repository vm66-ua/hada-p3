<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proweb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Vlada Mukhareva - Y8521859M <br />
    Jorge García Hernández - 51256738L

<div style="background-color: #66C7C7; padding: 10px; margin-top: 10px;">
    <h1 style="text-align: center;">HADA P3 - CURSO 2024/25</h1>
</div>

<h2>Products management</h2>

<p>Code <asp:TextBox ID="txtCode" runat="server" /></p>
<p>Name <asp:TextBox ID="txtName" runat="server" /></p>
<p>Amount <asp:TextBox ID="txtAmount" runat="server" /></p>
<p>
    Category
    <asp:DropDownList ID="ddlCategory" runat="server">
        <asp:ListItem>Computing</asp:ListItem>
        <asp:ListItem>Telephony</asp:ListItem>
        <asp:ListItem>Gaming</asp:ListItem>
        <asp:ListItem>Home appliances</asp:ListItem>
    </asp:DropDownList>
</p>
<p>Price <asp:TextBox ID="txtPrice" runat="server" /></p>
<p>Creation Date (dd/MM/yyyy HH:mm:ss) <asp:TextBox ID="txtCreationDate" runat="server" /></p>

<p>
    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
    <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
    <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
    <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />
</p>

<p>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</p>

</asp:Content>
