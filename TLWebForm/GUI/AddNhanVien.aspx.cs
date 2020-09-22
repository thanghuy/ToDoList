using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.DataAccess;

namespace TLWebForm
{
    public partial class AddNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fullName = fullNameTxtBox.Text;
            string email = emailTxtBox.Text;
            string password = pwTxtBox.Text;
            bool isManager = Convert.ToBoolean(managerBtnList.SelectedValue);
            try
            {
                NhanVienBUS service = new NhanVienBUS();
                service.InsertNhanVien(fullName, email, password, isManager);
                DataSet nv = service.GetNhanVienLatest();
                GridView1.DataSource = nv;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}