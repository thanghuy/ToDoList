using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;

namespace TLWebForm.GUI.NhanVien
{
    public partial class CapNhatStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CongViecBUS service = new CongViecBUS();
            String idcv = Request.QueryString["id"];
            service.updateStatusById(idcv);
            Response.Redirect("./DanhSachCongViecNv.aspx");


        }
    }
}