using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.Admin
{
    public partial class DanhSachCongViec : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["user"] as string))
            {
                var myStr = Session["user"] as String;
                userName.Controls.Add(new Literal { Text = myStr.ToString() });
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                CongViecBUS service = new CongViecBUS();
                List<CongViecDTO> list = service.GetAllCongViec();

                foreach(CongViecDTO cv in list)
                {
                    table.Append("<tr>");
                    table.Append("<td>"+cv.Id+"</td>");
                    table.Append("<td>" + cv.TenCongViec + "</td>");
                    table.Append("<td>" + service.getTenNvById(cv.Id) + "</td>");
                    table.Append("<td>" + cv.NgayBatDau + "</td>");
                    table.Append("<td>" + cv.NgayKetThuc + "</td>");
                   /* table.Append(service.CheckStatusCv(cv.Status));*/
                    table.Append("</tr>");

                }

                showCV.Controls.Add(new Literal { Text = table.ToString() });
            }
        }

        private void tableAppend(StringBuilder table, int status)
        {
           // _ = status == 1 ? table.Append("<td>" + "Đã hoàn thành" + "</td>") : table.Append("<td>" + "Chưa hoàn thành" + "</td>");
            switch (status)
            {
                case 0:
                    table.Append("<td>" + "<button type='button' class='btn btn-danger'>Chưa hoàn thành</button>" + "</td>");
                    break;
                case 1:
                    table.Append("<td>" + "<button type='button' class='btn btn-primary'>Đang thực hiện</button>" + "</td>");
                    break;
                case 2:
                    table.Append("<td>" + "<button type='button' class='btn btn-success'>Đã hoàn thành</button>" + "</td>");
                    break;
            }
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.Remove("MaNV");
            Session.Remove("Quyen");
            Response.Redirect("../Login.aspx");
        }
    }
}