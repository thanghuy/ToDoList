<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TLWebForm.GUI.Admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="../../Content/sb-admin-2.css" rel="stylesheet" />
    <link href="../../Content/style.css" rel="stylesheet" />
</head>
<body id="page-top">

  <!-- Page Wrapper -->
  <div id="wrapper">

    <!-- Sidebar -->
    <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

      <!-- Sidebar - Brand -->
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
        <a class="nav-link" href="ThemCongViec.aspx">
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
              <span class="nav-link dropdown-toggle" href="#" id="userDropdown">
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
              <h6 class="m-0 font-weight-bold text-primary float-left" style="line-height: 35px;">Tất cả nhân viên</h6>
            </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr class="column-title">
                      <th>STT</th>
                      <th>Tên nhân viên</th>
                      <th>Tên đăng nhập</th>
                      <th>Mật khẩu</th>
                      <th>Quyền</th>
                      <th>Xem công việc</th>
                    </tr>
                  </thead>
                  <tbody>
        
                      <asp:PlaceHolder ID="showNV" runat="server"></asp:PlaceHolder>
                      
        
                  </tbody>
                </table>

              </div>
              <nav aria-label="...">
                <ul class="pagination">
                  <li class="page-item disabled">
                    <a class="page-link" href="#" tabindex="-1">Previous</a>
                  </li>
                  <li class="page-item"><a class="page-link" href="#">1</a></li>
                  <li class="page-item active">
                    <a class="page-link" href="#">2 <span class="sr-only">(current)</span></a>
                  </li>
                  <li class="page-item"><a class="page-link" href="#">3</a></li>
                  <li class="page-item">
                    <a class="page-link" href="#">Next</a>
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        </div>
        <!-- /.container-fluid -->

      </div>
    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

</body>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</html>
