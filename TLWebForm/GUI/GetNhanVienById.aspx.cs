using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.DataAccess;

namespace TLWebForm
{
    public partial class GetNhanVienById : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NhanVienAccess service = new NhanVienAccess();
            string id = idTxtBox.Text;
            DataSet nv = service.GetNhanVienById(id);
            GridView1.DataSource = nv;
            GridView1.DataBind();

        }
    }
}