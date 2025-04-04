<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proweb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #eaeaea;
        }
        h1, h2 {
            font-weight: 600;
        }
        .header-box {
            background-color: #8D6E63;
            padding: 15px;
            margin-top: 10px;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }
        .form-box {
            background-color: white;
            border: 1px solid #ddd;
            padding: 20px;
            border-radius: 10px;
            margin-top: 20px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.05);
        }
        label {
            font-weight: 500;
            color: #333;
        }
        input, select {
            margin-bottom: 10px;
            padding: 6px;
            border-radius: 5px;
            border: 1px solid #ccc;
            width: 100%;
        }
        .btn-container {
            margin-top: 15px;
        }
        .btn-container input {
    margin-right: 8px;
    margin-bottom: 8px;
    padding: 6px 12px;
    background-color: #8D6E63; /* marrón */
    border: none;
    color: white; /* texto blanco */
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.2s ease-in-out;
}

.btn-container input:hover {
    background-color: #6D4C41; /* marrón más oscuro al pasar el ratón */
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><strong>Vlada Mukhareva - Y8521859M</strong> <br /> <strong>Jorge García Hernández - 51256738L</strong></p>

    <div class="header-box">
        <h1 style="text-align: center; color: white;">HADA P3 - CURSO 2024/25</h1>
    </div>

    <div class="form-box">
        <h2 style="text-align: center; font-size: 28px;">💻 Products management 💻</h2>


        <p>
            <label for="txtCode">Code</label>
            <asp:TextBox ID="txtCode" runat="server" />
        </p>
        <p>
            <label for="txtName">Name</label>
            <asp:TextBox ID="txtName" runat="server" />
        </p>
        <p>
            <label for="txtAmount">Amount</label>
            <asp:TextBox ID="txtAmount" runat="server" />
        </p>
        <p>
            <label for="ddlCategory">Category</label><br />
            <asp:DropDownList ID="ddlCategory" runat="server">
                <asp:ListItem>Computing</asp:ListItem>
                <asp:ListItem>Telephony</asp:ListItem>
                <asp:ListItem>Gaming</asp:ListItem>
                <asp:ListItem>Home appliances</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <label for="txtPrice">Price</label>
            <asp:TextBox ID="txtPrice" runat="server" />
        </p>
       <p>
    <label for="txtCreationDate">Creation Date</label>
    <asp:TextBox ID="txtCreationDate" runat="server" TextMode="DateTimeLocal" CssClass="form-control" />
    </p>


        <div class="btn-container">
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
            <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
            <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
            <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />
        </div>

        <p>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </div>
</asp:Content>
