﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.Admin
{
    public partial class Test : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!Page.IsPostBack)
            {
                CongViecBUS service = new CongViecBUS();
                List<CongViecDTO> list = service.GetAllCongViec();

                foreach (CongViecDTO cv in list)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + cv.Id + "</td>");
                    table.Append("<td>" + cv.TenCongViec + "</td>");
                    table.Append("<td>" + "None Available" + "</td>");
                    table.Append("<td>" + cv.NgayBatDau + "</td>");
                    table.Append("<td>" + cv.NgayKetThuc + "</td>");
                    tableAppend(table, cv.Status);
                    table.Append("/<tr>");

                }

                showCV.Controls.Add(new Literal { Text = table.ToString() });
            }*/
            /*< input runat = "server" type = "checkbox" class="form-check-input" id="idPartner"/>
            <label class="form-check-label" >Partner</label>*/
            if (!Page.IsPostBack)
            {
                NhanVienBUS service = new NhanVienBUS();
                List<NhanVienDTO> list = service.allNV();
                
                foreach(NhanVienDTO nv in list)
                {
                    table.Append("<input type='checkbox' value='"+nv.idNV+"' id='"+nv.TenNV+"'/>");
                    table.Append("<label class='form-check-label'>"+nv.TenNV+"</label>");
                }
                allNhanVien.Controls.Add(new Literal { Text = table.ToString() });
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //Thêm công việc vào chỗ này
            string ten = tenCongViec.Value;
            String timeStart = DateTime.Parse(dateStart.Value).ToString();
            String timeEnd = DateTime.Parse(dateEnd.Value).ToString();
            //String partner = idPartner.Value;
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