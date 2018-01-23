<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forma1.aspx.cs" Inherits="Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Cone Height, H"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Cone Radius, R"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Cone Radius, r"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Cone Volume"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />         
        <br />        
        <asp:Button ID="Button1" runat="server" Text="Skaičiuoti!" OnClick="Button1_Click" /> 
    </form>
</body>
</html>
