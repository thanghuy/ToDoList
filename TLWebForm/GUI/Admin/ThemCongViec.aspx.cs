using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLWebForm.GUI.Admin
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Thêm công việc vào chỗ này
            string ten = tenCongViec.Value;
            String timeEnd = DateTime.Parse(dateEnd.Value).ToString();
            String partner = idPartner.Value;
            String phamvi = phamVi.Value;
            Console.WriteLine(ten + timeEnd + partner + phamVi);
        }
    }
}