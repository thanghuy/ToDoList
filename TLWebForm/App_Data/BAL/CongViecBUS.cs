﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DAL;

namespace TLWebForm.App_Data.BAL
{
    public class CongViecBUS
    {
        private CongViecAccess service = new CongViecAccess();
        public CongViecBUS() { }

        public void MarkStatus(string id, bool status)
        {
            if(status == true)
            {
                service.MarkStatus(id, status);
                service.UpdateFinishDate(id, "GETDATE()");
            }
            else
            {
                service.MarkStatus(id, status);
                service.UpdateFinishDate(id, "NULL");
            }
        }

        public bool AssignCongViec(string idCongViec, string idNhanVien, string idPartner)
        {
            if((int.Parse(idNhanVien)) <= 0 || (int.Parse(idCongViec)) <= 0)
            {
                return false;
            }

            if(int.Parse(idNhanVien) == int.Parse(idCongViec))
            {
                return false;
            }

            if(idNhanVien == null)
            {
                return false;
            }

            if(idNhanVien != null && idPartner == null)
            {
                service.AssignNhanVienToCongViec(idCongViec, idNhanVien);
                service.AssignPartnerToCongViec(idCongViec, null);
                return true;
            }
            service.AssignNhanVienToCongViec(idCongViec, idNhanVien);
            service.AssignPartnerToCongViec(idCongViec, idPartner);
            return true;
            
        }
    }
}