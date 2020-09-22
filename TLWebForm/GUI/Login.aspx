<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TLWebForm.GUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập admin</title>
    <link rel="stylesheet" href="../Content/sb-admin-2.css" />
    <link rel="stylesheet" href="../Content/style.css" /> 
</head>
<body class="bg-gradient-primary">
    <div class="container">
        <!-- Outer Row -->
        <div class="row justify-content-center">
    
          <div class="col-xl-6 col-lg-7 col-md-6">
            <div class="card o-hidden border-0 shadow-lg my-5" style="margin-top: 20% !important;">
              <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                  <div class="col-lg-12">
                    <div class="p-5">
                      <div class="text-center">
                        <h1 class="h4 text-gray-900 mb-4">Đăng nhập admin</h1>
                      </div>
                      <form class="user" method="POST" runat="server">
                        <div class="form-group">
                          <input type="text" class="form-control form-control-user" id="email" runat="server" name="email" placeholder="Nhập email..."/>
                        </div>
                        <div class="form-group">
                          <input type="password" class="form-control form-control-user" id="password" runat="server" name="password" placeholder="Nhập mật khẩu"/>
                        </div>
                        <asp:Button ID="login_user" runat="server" OnClick="Login_Click" Text="Đăng nhập" class="btn btn-primary btn-user btn-block" />
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
    
          </div>
    
        </div>    
    </div>
</body>
</html>
