<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forma1.aspx.cs" Inherits="Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Items list"></asp:Label>
        <div>
            <asp:Table ID="Table1" runat="server" BackColor="#FFFFCC" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
        </div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Prekes.xml"></asp:XmlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="XmlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="pavadinimas" HeaderText="pavadinimas" SortExpression="pavadinimas" />
                <asp:BoundField DataField="kaina" HeaderText="kaina" SortExpression="kaina" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </form>
</body>
</html>
