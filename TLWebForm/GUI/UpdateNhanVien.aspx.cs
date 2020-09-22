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
    public partial class UpdateNhanVien : System.Web.UI.Page
    {
        private NhanVienBUS service = new NhanVienBUS();
        private string id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadBtn_Click(object sender, EventArgs e)
        {
            failedTxt.Style.Add("Visibility", "true");
            successTxt.Style.Add("Visibility", "false");
            id = idTxtBox.Text;

            DataSet nv = service.GetNhanVienById(id);
            fullNameTxtBox.Text = nv.Tables[0].Rows[0]["FullName"].ToString();
            emailTxtBox.Text = nv.Tables[0].Rows[0]["Email"].ToString();
            passwordTxtBox.Text = nv.Tables[0].Rows[0]["Password"].ToString();
            //string isMan = nv.Tables[0].Rows[5].ToString();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                failedTxt.Style.Add("Visibility", "true");
                successTxt.Style.Add("Visibility", "false");
                string id = idTxtBox.Text;
                string fullName = fullNameTxtBox.Text;
                string email = emailTxtBox.Text;
                string password = passwordTxtBox.Text;
                bool isManager = Convert.ToBoolean(managerRadio.SelectedValue);
                service.UpdateNhanVien(id, fullName, email, password, isManager);
            }
            catch (Exception ex)
            {
                failedTxt.Style.Add("Visibility", "true");
                throw ex;
            }
            finally
            {
                successTxt.Style.Add("Visibility", "false");
            }
        }
    }
}