using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLWebForm.GUI.Admin
{
    public partial class chitietcongviec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var g = Request.QueryString["id"];//this value should be 23 now;
            Console.WriteLine(g.ToString());
            
        }
    }
}