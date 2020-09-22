<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThemCongViec.aspx.cs" Inherits="TLWebForm.GUI.ThemCongViec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Tên công việc"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="title" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Mô tả công việc"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="description" runat="server"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label5" runat="server" Text="Loại công việc"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButtonList ID="Type" runat="server">
                <asp:ListItem Selected="True" Value="true">Công khai</asp:ListItem>
                <asp:ListItem Value="false">Riêng tư</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p style="margin-left: 200px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" style="height: 29px" />
        </p>
    </form>
</body>
</html>
