<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateNhanVien.aspx.cs" Inherits="TLWebForm.UpdateNhanVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID:
            <asp:TextBox ID="idTxtBox" runat="server"></asp:TextBox>
            <asp:Button ID="loadBtn" runat="server" OnClick="loadBtn_Click" Text="Load" />
        </div>
        <p>
            FullName: <asp:TextBox ID="fullNameTxtBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:
            <asp:TextBox ID="emailTxtBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="passwordTxtBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Is Manager:<asp:RadioButtonList ID="managerRadio" runat="server">
                <asp:ListItem Selected="True">True</asp:ListItem>
                <asp:ListItem >False</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" />
        </p>
        <asp:TextBox ID="successTxt" runat="server" ReadOnly="True" Visible="False">Thành công</asp:TextBox>
        <asp:TextBox ID="failedTxt" runat="server" ReadOnly="True" Visible="False">Thất bại</asp:TextBox>
    </form>
</body>
</html>
