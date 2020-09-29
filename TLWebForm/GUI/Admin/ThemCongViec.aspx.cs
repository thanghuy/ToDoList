using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.Admin
{
    public partial class Test : System.Web.UI.Page
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
                NhanVienBUS service = new NhanVienBUS();
                List<NhanVienDTO> list = service.allNV();
                
                foreach(NhanVienDTO nv in list)
                {
                    table.Append(
                        "<div class='form-check'>"
                                      +"<input class='form-check-input' type='checkbox' value='"+nv.idNV+"' id='nv0'/>"
                                      +"<div class='form-check-label' for='defaultCheck1'>"
                                      +nv.TenNV
                                      +"</div>"
                                    +"</div>"
                        );
                }
                allNhanVien.Controls.Add(new Literal { Text = table.ToString() });
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CongViecBUS service = new CongViecBUS();
            //Thêm công việc vào chỗ này
            string ten = tenCongViec.Value;
            String timeStart = DateTime.Parse(dateStart.Value).ToString();
            String timeEnd = DateTime.Parse(dateEnd.Value).ToString();
            String partner = idPartner.Value;
            String phamvi = phamVi.Value;
            // gọi hàm xử ly trên server
            Console.WriteLine(timeStart,ten + timeEnd + partner + phamVi);
            
            if (service.themCongViec(ten, timeStart, timeEnd, partner, phamvi))
            {
                Response.Redirect("./DanhSachCongViec.aspx");
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