using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.Admin
{
    public partial class chitietcongviec : System.Web.UI.Page
    {
        ChiTietCV services = new ChiTietCV();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string g = Request.QueryString["id"];//this value should be 23 now;
            Console.WriteLine(g.ToString());
            List <ChitTietCvDTO> list = services.getChiTiet(Convert.ToInt32(g));
        }
    }
}