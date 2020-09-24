using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Start;

namespace TLWebForm.GUI.Admin
{
    public partial class DanhSachCongViec : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CongViecBUS service = new CongViecBUS();
                List<CongViecDTO> list = service.GetAllCongViec();

                foreach(CongViecDTO cv in list)
                {
                    table.Append("<tr>");
                        table.Append("<td>"+cv.Id+"</td>");
                          table.Append("<td>" + cv.TenCongViec + "</td>");
                    table.Append("<td>" + "None Available" + "</td>");
                    table.Append("<td>" + cv.NgayBatDau + "</td>");
                    table.Append("<td>" + cv.NgayKetThuc + "</td>");
                    tableAppend(table,cv.Status);
                    table.Append("/<tr>");

                }

                showCV.Controls.Add(new Literal { Text = table.ToString() });
            }
        }

        private void tableAppend(StringBuilder table, bool status)
        {
            _ = status == true ? table.Append("<td>" + "Đã hoàn thành" + "</td>") : table.Append("<td>" + "Chưa hoàn thành" + "</td>");
        }
    }
}