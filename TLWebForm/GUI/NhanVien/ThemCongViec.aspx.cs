using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.NhanVien
{
    public partial class ThemCongViec : System.Web.UI.Page
    {
        CongViecBUS service = new CongViecBUS();
        PhanCongBUS servicePC = new PhanCongBUS();
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
            StringBuilder dscv = new StringBuilder();
            List<CongViecDTO> ds = service.getCongViecById(Session["MaNV"].ToString());

            foreach(CongViecDTO cv in ds)
            {
                dscv.Append("<option value='" + cv.Id + "'>" + cv.TenCongViec + "</option>");
            }


            dsCongViec.Controls.Add(new Literal { Text = dscv.ToString()});
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string idNV = Session["MaNV"].ToString();
            string idCongViec = idCVNV.Value;
            string startDate = dateStart.Value;
            string endDate = dateEnd.Value;
            if(service.ThemCongViecNV(idCongViec, startDate, endDate))
            {
                if(servicePC.AddPhanCong(idNV, idCongViec))
                {
                    Response.Redirect("./DanhSachCongViecNv");
                }
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