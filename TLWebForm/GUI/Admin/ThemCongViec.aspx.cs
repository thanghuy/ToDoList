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
            string ten = tenCongViec.Value;
            String timeStart = DateTime.Parse(dateStart.Value).ToString();
            String timeEnd = DateTime.Parse(dateEnd.Value).ToString();
            String partner = idPartner.Value;
            bool phamvi = Convert.ToBoolean(phamVi.Value);

            //Console.WriteLine(ten +timeStart+ timeEnd + partner + phamVi);
            try
            {
                TLWebForm.App_Data.BAL.CongViecBUS services = new App_Data.BAL.CongViecBUS();
                services.InsertJob(ten,timeStart,timeEnd,"Invalid",phamvi);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}