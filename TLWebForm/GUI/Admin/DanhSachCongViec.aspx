<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DanhSachCongViec.aspx.cs" Inherits="TLWebForm.GUI.Admin.DanhSachCongViec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm công việc</title>
    <link href="../../Content/sb-admin-2.css" rel="stylesheet" />
    <link href="../../Content/style.css" rel="stylesheet" />
</head>
<body id="page-top">
    <form id="form1" runat="server">
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
        <hr class="sidebar-divider my-0">
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
              <span class="nav-link dropdown-toggle" id="userDropdown">
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
              <h6 class="m-0 font-weight-bold text-primary float-left" style="line-height: 35px;">Tất cả nhân viên</h6>
              <div class="float-right">
                <a href="ThemCongViec.aspx" class="btn btn-primary" >Thêm công việc</a>
              </div>
              <!-- Modal thêm công việc -->
              <div class="modal fade" id="addJob" tabindex="-1" aria-labelledby="addJobLabel" aria-hidden="true">
                <div class="modal-dialog">
                  <div class="modal-content">
                    <div class="modal-header">
                      <h5 class="modal-title" id="exampleModalLabel">Thêm công việc</h5>
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                      </button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="form-group">
                              <label for="exampleInputEmail1">Tên công việc</label>
                              <input type="text" class="form-control">
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                      <button type="button" class="btn btn-primary">Thêm</button>
                    </div>
                  </div>
                </div>
              </div>
              <!-- end-->
            </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr class="column-title">
                      <th>STT</th>
                      <th>Tên công việc</th>
                      <th>Người đang làm</th>
                      <th>Ngày bắt đầu</th>
                      <th>Ngày kết thúc</th>
                    </tr>
                  </thead>
                  <tbody>
                      <asp:PlaceHolder ID="placeholder" runat="server" />
                    <tr>
                        
                        <asp:PlaceHolder ID="showCV" runat="server"></asp:PlaceHolder>

                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
        <!-- /.container-fluid -->

      </div>
    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

  <!-- Logout Modal-->


  <!-- Bootstrap core JavaScript-->
    </form>
</body>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</html>
