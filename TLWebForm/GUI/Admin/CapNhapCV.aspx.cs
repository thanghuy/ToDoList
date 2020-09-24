using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLWebForm.GUI.Admin
{
    public partial class CapNhapCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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