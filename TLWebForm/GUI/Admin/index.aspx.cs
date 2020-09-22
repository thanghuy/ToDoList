using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;

namespace TLWebForm.GUI.Admin
{
    public partial class index : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NhanVienBUS service = new NhanVienBUS();
                DataTable list = service.GetAllNhanVien();

                foreach(DataRow row in list.Rows)
                {
                    table.Append("<tr>");
                        foreach(DataColumn column in list.Columns)
                        {
                            table.Append("<td>" + row[column.ColumnName] + "</td>");
                        
                        }
                    table.Append("<td>"+ "<a href='chitietcongviec.aspx?id="+row[0]+"'>Chi tiết công việc</a>"+" </td>");
                    //table.Append(row[1]);
                    table.Append("</tr>");
                }
                showNV.Controls.Add(new Literal { Text = table.ToString() });
            }

        }
    }
}