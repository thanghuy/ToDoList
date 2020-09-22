<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chitietcongviec.aspx.cs" Inherits="TLWebForm.GUI.Admin.chitietcongviec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết công việc</title>
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
              <h6 class="m-0 font-weight-bold text-primary float-left" style="line-height: 35px;">Tất cả công việc</h6>
             </div>
            </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr class="column-title">
                      <th>STT</th>
                      <th>Tên công việc</th>
                      <th>Ngày bắt đầu</th>
                      <th>Ngày kết thúc</th>
                      <th>Phạm vi</th>
                      <th>Người làm chung</th>
                      <th>Tập tin</th>
                      <th>Bình luận</th>
                      <th>Trạng thái</th>
                      <th>Thao tác</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>1</td>
                      <td>Lập trình fontend</td>
                      <td>21-9-2020</td>
                      <td>27-9-2020</td>
                      <td>Public</td>
                      <td>Ninh Ngọc Hiếu</td>
                      <td>text.pdf</td>
                      <td>Rất tốt</td>  
                      <td> 
                        <span class="badge badge-primary">Đang làm</span>
                      </td>
                      <td>
                        <button type="button" class="btn btn-primary btn-icon-split" data-toggle="modal" data-target="#updateJobNV" >
                          <span class="text">Sửa</span>
                        </button>
        
                        <a href="#" class="btn btn-danger btn-circle">
                            <span class="text">Xóa</span>
                        </a>
                      </td>
                    </tr>
                  </tbody>
                  <div class="modal fade" id="updateJobNV" tabindex="-1" aria-labelledby="updateJobNVLabel" aria-hidden="true">
                    <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                        <h5 class="modal-title" id="updateJobNVLabel">Sửa công việc</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="modal-body">
                            <form>
                                <div class="form-group">
                                  <label for="exampleInputEmail1">Ngày bắt đầu</label>
                                  <input type="text" class="form-control">
                                </div>
                                <div class="form-group">
                                  <label for="exampleInputEmail1">Ngày kết thúc</label>
                                  <input type="text" class="form-control">
                                </div>
                                <div class="form-group">
                                  <label for="exampleInputEmail1">Người làm chung</label>
                                  <select class="form-control" id="exampleFormControlSelect1">
                                    <option>Huy Thắng</option>
                                    <option>Trịnh Đưc Hiếu</option>
                                  </select>
                                </div>
                                <div class="form-group">
                                  <label for="exampleInputEmail1">Bình luận</label>
                                  <input type="text" class="form-control">
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                            <button type="button" class="btn btn-primary">Lưu</button>
                        </div>
                    </div>
                  </div>
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

  <!-- Scroll to Top Button-->

  <!-- Bootstrap core JavaScript-->

</body>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</html>
