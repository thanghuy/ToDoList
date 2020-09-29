using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace TLWebForm.GUI.Admin
{
    public partial class chitietcongviec : System.Web.UI.Page
    {
        ChiTietCV services = new ChiTietCV();
        CongViecBUS cv = new CongViecBUS();
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
            string g = Request.QueryString["id"];//this value should be 23 now;
            Console.WriteLine(g.ToString());
            List <ChitTietCvDTO> list = services.getChiTiet(Convert.ToInt32(g));
            foreach(ChitTietCvDTO ctcv in list)
            {
                table.Append("<tr>"
                      +"<td>"+ctcv.idcongviec+"</td>"
                      +"<td>"+ctcv.TenCongViec+"</td>" 
                      +"<td>"+ctcv.NgayBatDau+"</td>"
                      + "<td>" + ctcv.NgayKetThuc + "</td>"
                      + "<td>" + ctcv.PhamVi + "</td>"
                      + "<td> Ninh Ngọc Hiếu</td>"
                      + "<td>" + ctcv.Files + "</td>"
                      + "<td>" + ctcv.Comment + "</td>"
                      + cv.CheckStatusCv(ctcv.Status)//lay status cua cong viecc
                      +"<td>"
                       + "<a href='CapNhapCV.aspx?id=" + ctcv.idcongviec + "&idnv="+ctcv.idnhanvien+"' class='btn btn-primary btn-icon-split'>"
                          + "<span class='text'>Sửa</span>"
                        +"</a>"
                      +"</td>"
                    +"</tr>");
            }
            ChitietCV.Controls.Add(new Literal { Text = table.ToString() });
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