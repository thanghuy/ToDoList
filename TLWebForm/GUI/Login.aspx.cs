using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;
using TLWebForm.DataAccess;

namespace TLWebForm.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string em = email.Value;
            string pw = password.Value;

            NhanVienBUS service = new NhanVienBUS();
            List<NhanVienDTO> test = service.getLoginInfo(em, pw);
            if (test.Count() != 0)
            {
                Session["user"] = test[0].TenNV;
                Session["MaNV"] = test[0].idNV;
                Session["Quyen"] = test[0].Quyen;
                if (test[0].Quyen)
                {
                    Response.Redirect("Admin/index.aspx");
                }
                else
                {
                    Response.Redirect("NhanVien/DanhSachCongViecNv.aspx");
                }
            }
            else
            {
                StringBuilder error = new StringBuilder();
                error.Append("<span class='invalid-feedback' style='display: block ; font-size:20px; margin-bottom:10px ;text-align:center'>");
                error.Append("Sai mật khẩu hoặc tên đăng nhập</span>");
                ErrorLogin.Controls.Add(new Literal { Text = error.ToString() });
                
            }
        }
    }
}