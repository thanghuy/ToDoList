<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapNhapCV.aspx.cs" Inherits="TLWebForm.GUI.Admin.CapNhapCV" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cập nhập công việc</title>
    <link href="../../Content/sb-admin-2.css" rel="stylesheet" />
    <link href="../../Content/style.css" rel="stylesheet" />
</head>
<body id="page-top">
   <form runat="server" id="demo1" method="post">
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
              <li class="nav-item dropdown no-arrow">
                  <a class="nav-link dropdown-toggle" href="#">Xin chào :
&nbsp;<span class="nav-link text-info"><asp:PlaceHolder ID="userName" runat="server"></asp:PlaceHolder>
                          &nbsp
                          <img class="img-profile rounded-circle" src="https://source.unsplash.com/QAB-WJcbgJk/60x60">
                      </span>
                  </a>
                  <!-- Dropdown - User Information -->
                </li>
            <!-- Nav Item - User Information -->
            <li class="nav-item dropdown no-arrow">
              <span class="nav-link dropdown-toggle" href="#" id="userDropdown">
                  <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" OnClientClick="Logout" Text="Đăng xuất" class="btn btn-primary border mr-2"/>
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
                        
                            <div class="form-group">
                                <label for="exampleInputEmail1">Ngày bắt đầu</label>
                                <input runat="server" type="date" class="form-control" id="dateS"/>
                                <div class="invalid-feedback" id="errorDateS"></div>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Ngày kết thúc</label>
                                <input runat="server" type="date" class="form-control" id="dateE"/>
                                <div class="invalid-feedback" id="errorDateE"></div>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Bình luận</label>
                                <textarea runat="server" id="comment" class="form-control" name="w3review" rows="4" cols="50"></textarea>
                                <div class="invalid-feedback" id="errorComment"></div>
                            </div>
                            <div class="form-group float-right">
                                <asp:Button ID="Button3CV" runat="server" Text="Cập nhập công việc" OnClientClick="return validateForm();" OnClick="Button1_Click" class="btn btn-primary"  />
                            </div>
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
        </form>
</body>
     <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <script src="../../Scripts/xuly.js"></script>
</html>
