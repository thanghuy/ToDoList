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
    public partial class CapNhapCV : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                CongViecBUS service = new CongViecBUS();
                List<CongViecDTO> list = service.GetAllCongViec();

                foreach (CongViecDTO cv in list)
                {
                    table.Append("<option>" + cv.TenCongViec + "</option>");
                }

                getAllCV.Controls.Add(new Literal { Text = table.ToString() });
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Cập nhập công việc tại đây với quyên admin
            String dateEnd = DateTime.Parse(dateE.Value).ToString();
            string idNV = idP.Value;
            string comments = comment.Value;

        }
    }
}