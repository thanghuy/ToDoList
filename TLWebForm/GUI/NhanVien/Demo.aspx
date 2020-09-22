<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="TLWebForm.GUI.NhanVien.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 82px;
            width: 420px;
        }
    </style>
</head>
<body>
    <div class="modalfádfsad fadefádf" id="addJob" tabindex="-1" aria-labelledby="addJobLabel" aria-hidden="true">
                <div class="modal-dialog">
                  <div class="modal-content">
                    <div class="modal-header">
                      <h5 class="modal-title" id="exampleModalLabel">Thêm công việc</h5>
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                      </button>
                    </div>
                    <div class="modal-body">
                        <form method="POST" runat="server">
                            <div class="form-group">
                              <label for="exampleInputEmail1">Tên công việc</label>
                              <input runat="server" id="name_job" type="text" class="form-control" />
                            </div>
                            <div class="form-group">
                              <label for="exampleInputEmail1">Mô tả</label>
                              <input runat="server" type="text" id="description" class="form-control" />
                            </div>
                            <div class="form-group">
                                  <label for="exampleInputEmail1">Phạm vi</label>
                                  <select runat="server" class="form-control" id="type_job">
                                    <option value="true">Public</option>
                                    <option value="false">Private</option>
                                  </select>
                                </div>
                        <asp:Button ID="login_user" runat="server" OnClick="Login_Click" Text="Đăng nhập" class="btn btn-primary btn-user btn-block" />
                       </form>
                    </div>
                    <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                    </div>
                  </div>
                </div>
              </div>
</body>
</html>
