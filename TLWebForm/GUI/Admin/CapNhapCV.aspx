<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapNhapCV.aspx.cs" Inherits="TLWebForm.GUI.Admin.CapNhapCV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cập nhập công việc</title>
    <link href="../../Content/sb-admin-2.css" rel="stylesheet" />
    <link href="../../Content/style.css" rel="stylesheet" />
</head>
<body id="page-top">

  <!-- Page Wrapper -->
  <div id="wrapper">

    <!-- Sidebar -->
    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

      <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.aspx">
        <div class="sidebar-brand-icon rotate-n-15">
          <i class="fas fa-laugh-wink"></i>
        </div>
        <div class="sidebar-brand-text mx-3">Quản lý công việc(Admin)</div>
      </a>
        <hr class="sidebar-divider my-0" />
      <!-- Nav Item - Pages Collapse Menu -->
      <li class="nav-item">
        <a class="nav-link" href="index.aspx">
          <span class="nav-link-title sidebar-brand-text mx-3">Danh sách nhân viên</span>
        </a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="DanhSachCongViec.aspx">
          <span class="nav-link-title sidebar-brand-text mx-3">Danh sách công việc</span>
        </a>
      </li>
      <!-- Nav Item - Utilities Collapse Menu -->
    </ul>
    <!-- End of Sidebar -->

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

        <!-- Topbar -->
        <nav class="navbar navbar-expand navbar-light bg-white topbar mb-3 static-top">
          <ul class="navbar-nav ml-auto">
            <!-- Nav Item - User Information -->
            <li class="nav-item dropdown no-arrow">
              <span class="nav-link dropdown-toggle" id="userDropdown">
                <button type="submit" class="btn btn-primary border mr-2">Đăng xuất</button>
              </span>
              <!-- Dropdown - User Information -->
            </li>

          </ul>

        </nav>
        <!-- End of Topbar -->

        <!-- Begin Page Content -->
        <div class="container-fluidn">
          <!-- DataTales Example -->
          <div class="card mb-4">
            <div class="card-header py-3 clearfix">
              <!-- Modal thêm công việc -->
                <div class="demo">
                    <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Cập nhập công việc</h5>
                    </div>
                    <div class="modal-body">
                        <form runat="server" id="demo1" method="post">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Ngày bắt đầu</label>
                                <input runat="server" type="date" class="form-control" id="dateS"/>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Ngày kết thúc</label>
                                <input runat="server" type="date" class="form-control" id="dateE"/>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Bình luận</label>
                                <textarea runat="server" id="comment" class="form-control" name="w3review" rows="4" cols="50"></textarea>
                            </div>
                            <div class="form-group float-right">
                                <asp:Button ID="Button3CV" runat="server" Text="Cập nhập công việc" OnClientClick="Capnhap_click()" OnClick="Button1_Click" class="btn btn-primary"  />
                            </div>
                        </form>
                    </div>
                    </div>
                </div>
              <!-- end-->
            </div>
          </div>
        </div>
        <!-- /.container-fluid -->

      </div>
    </div>
    <!-- End of Content Wrapper -->

  </div>
</body>
</html>
