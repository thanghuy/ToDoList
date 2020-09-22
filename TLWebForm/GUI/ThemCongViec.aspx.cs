using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLWebForm.GUI
{
    public partial class ThemCongViec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string job_title = title.Text;
            string job_desc = description.Text;
            bool isPublic = Convert.ToBoolean(Type.SelectedValue);

            Console.WriteLine(job_title + job_desc + "" + isPublic);
        }
    }
}