using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLWebForm.GUI.NhanVien
{
    public partial class Demo : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                table.Append("<table class='table table - bordered' id='dataTable' width='100%' cellspacing='0'>");
                table.Append("<thead>");
                table.Append("<thead>");
                table.Append("<thead>");
                table.Append("<thead>");
                table.Append("<thead>");
            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            

        }
    }
}