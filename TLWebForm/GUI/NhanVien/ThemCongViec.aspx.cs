using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;

namespace TLWebForm.GUI.NhanVien
{
    public partial class ThemCongViec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CongViecBUS service = new CongViecBUS();
            PhanCongBUS servicePC = new PhanCongBUS();
            string idNV = Session["MaNV"].ToString();
            string tenCv = tenCongViec.Value;
            string startDate = dateStart.Value;
            string endDate = dateEnd.Value;
            string file = filePath.Value;
            bool phamvi = Convert.ToBoolean(phamVi.Value);
            service.ThemCongViecNV(tenCv, idNV, startDate, endDate, phamvi, file);
            string idCV = service.GetLatestIdCongViec();
            servicePC.AddPhanCong(idNV, idCV);
            Response.Redirect("./DanhSachCongViecNv");
        }
    }
}