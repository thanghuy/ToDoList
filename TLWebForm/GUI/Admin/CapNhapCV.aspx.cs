using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.Admin
{
    public partial class CapNhapCV : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!Page.IsPostBack)
            {
                CongViecBUS service = new CongViecBUS();
                string idCv = Request.QueryString["id"];
                string idNV = Request.QueryString["idnv"];
                //List<CongViecDTO> list = service.GetAllCongViecNVcv(idCv,idNV);

                /*foreach (CongViecDTO cv in list)
                {
                    table.Append("<option>" + cv.TenCongViec + "</option>");
                }

                getAllCV.Controls.Add(new Literal { Text = table.ToString() });*/
            }
            if (!string.IsNullOrEmpty(Session["user"] as string))
            {
                var myStr = Session["user"] as String;
                userName.Controls.Add(new Literal { Text = myStr.ToString() });
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.Remove("MaNV");
            Session.Remove("Quyen");
            Response.Redirect("../Login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            CongViecBUS service = new CongViecBUS();
            //Cập nhập công việc tại đây với quyên admin
            string idCv = Request.QueryString["id"];
            string idNV = Request.QueryString["idnv"];
            string dateEnd = DateTime.Parse(dateE.Value).ToString();
            string dateStart = DateTime.Parse(dateS.Value).ToString();
            string comments = comment.Value;
            Console.WriteLine(idCv, idNV, dateStart, dateE, comments);

            if (service.updatePCCV(idCv, idNV, dateStart, dateEnd, comments))
            {
                Response.Redirect("./chitietcongviec.aspx?id="+idNV);
            }
            else
            {
                Response.Redirect("./CapNhatCV.aspx?id="+idCv+"&idnv="+idNV);
            }

        }
        
    }
}