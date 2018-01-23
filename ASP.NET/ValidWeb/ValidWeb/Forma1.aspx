<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forma1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label3" runat="server" Text="Participant Registration"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Age: "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="False year value" ForeColor="Red" MaximumValue="25" MinimumValue="14" Type="Integer">*</asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Programing language"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="pavadinimas" DataValueField="pavadinimas">
            </asp:CheckBoxList>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/kalbos.xml"></asp:XmlDataSource>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register" />
            <asp:Button ID="Button2" runat="server" Text="Delete" />
        </p>
    </form>
</body>
</html>
