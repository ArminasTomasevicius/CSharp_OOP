<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forma1.aspx.cs" Inherits="Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="New text"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Saved text"></asp:Label>
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px">
            </asp:Table>
        </p>
    </form>
</body>
</html>
