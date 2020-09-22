<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetNhanVienById.aspx.cs" Inherits="TLWebForm.GetNhanVienById" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="AvatarPath" HeaderText="AvatarPath" SortExpression="AvatarPath" />
                <asp:CheckBoxField DataField="IsManager" HeaderText="IsManager" SortExpression="IsManager" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TodoListDb %>" SelectCommand="SELECT [id], [FullName], [Email], [Password], [AvatarPath], [IsManager] FROM [NhanVien]"></asp:SqlDataSource>
        <div>
            <asp:TextBox ID="idTxtBox" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="idTextBtn" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
