<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNhanVien.aspx.cs" Inherits="TLWebForm.AddNhanVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Full name:
            <asp:TextBox ID="fullNameTxtBox" runat="server"></asp:TextBox>
        </div>
        <p>
            Email:
            <asp:TextBox ID="emailTxtBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="pwTxtBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Is Manager:
            <asp:RadioButtonList ID="managerBtnList" runat="server">
                <asp:ListItem Selected="True">True</asp:ListItem>
                <asp:ListItem>False</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </p>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TodoListDb %>" SelectCommand="SELECT [id], [FullName], [Email], [Password], [AvatarPath], [IsManager] FROM [NhanVien]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TodoListDb %>" SelectCommand="SELECT [Id], [Title], [Description], [Status], [IsPublic], [FilesPath] FROM [CongViec]"></asp:SqlDataSource>
    </form>
</body>
</html>
