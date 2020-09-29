<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DanhSachNhanVien.aspx.cs" Inherits="TLWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="GridData" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="FullName" HeaderText="FullName" SortExpression="FullName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="AvatarPath" HeaderText="AvatarPath" SortExpression="AvatarPath" />
                <asp:CheckBoxField DataField="IsManager" HeaderText="IsManager" SortExpression="IsManager" />
            </Columns>
        </asp:GridView>
        /*
        <asp:SqlDataSource ID="TodoListDb" runat="server" ConnectionString="<%$ ConnectionStrings:TodoListDb %>" SelectCommand="SELECT * FROM [NhanVien]" OnSelecting="TodoListDb_Selecting"></asp:SqlDataSource>
        */
    </form>
</body>
</html>
