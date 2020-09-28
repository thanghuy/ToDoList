﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLWebForm.App_Data.BAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.GUI.NhanVien
{
    public partial class DanhSachCongViecNv : System.Web.UI.Page

    {
        StringBuilder table = new StringBuilder();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["MaNV"] == null)
            {
                Response.Redirect("../GUI/Login");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    string id = Session["MaNV"].ToString();
                    CongViecBUS service = new CongViecBUS();
                    //NhanVienBUS nvService = new NhanVienBUS();
                    List<CongViecNvDTO> list = service.GetAllCongViecNv(id);
                    //NhanVienDTO partner = nvService.GetNhanVienById(id);
                    int count = 0;
                    foreach (CongViecNvDTO cv in list)
                    {
                        if (cv.IsVisible == true)
                        {
                            count++;
                            table.Append("<tr>");
                            table.Append("<td>" + count + "</td>");
                            table.Append("<td>" + cv.Id + "</td>");
                            table.Append("<td>" + cv.TenCongViec + "</td>");
                            table.Append("<td>" + cv.IdPartner + "</td>");
                            table.Append("<td>" + cv.NgayBatDau + "</td>");
                            table.Append("<td>" + cv.NgayKetThuc + "</td>");
                            table.Append("<td>" + cv.PhamVi + "</td>");
                            table.Append("<td>" + cv.FileDinhKem + "</td>");
                            //tableAppend(table, cv.Status);
                            table.Append(service.CheckStatusCv(cv.Status));
                            table.Append("</tr>");
                        }
                    }

                    showCV.Controls.Add(new Literal { Text = table.ToString() });
                }
            }
            
        }

        private void tableAppend(StringBuilder table, bool status)
        {
            _ = status == true ? table.Append("<td>" + "Đã hoàn thành" + "</td>") : table.Append("<td>" + "Chưa hoàn thành" + "</td>");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.Remove("MaNV");
            Session.Remove("Quyen");
            Response.Redirect("../Login.aspx");
        }
    }
}