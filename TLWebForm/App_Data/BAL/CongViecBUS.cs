using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using TLWebForm.App_Data.DAL;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.App_Data.BAL
{
    public class CongViecBUS
    {
        private CongViecAccess service = new CongViecAccess();
        private PhanCongAccess service1 = new PhanCongAccess();
        public CongViecBUS() { }

        public void MarkStatus(string id, bool status)
        {
            if(status == true)
            {
                service.MarkStatus(id, status);
                //service.UpdateFinishDate(id, "GETDATE()");
            }
            else
            {
                service.MarkStatus(id, status);
                //service.UpdateFinishDate(id, "NULL");
            }
        }

        internal void updateStatusById(string idcv)
        {
            service.updateStatusById(idcv);
        }

        internal List<CongViecDTO> getCongViecById(string v)
        {
            return service.getCongViecById(v);
        }

        internal List<CongViecNvDTO> GetAllCongViecNv(string idNhanVien)
        {
            return service.GetAllCongViecNv(idNhanVien);
        }

        internal List<CongViecDTO> GetAllCongViec()
        {
            return service.GetAllCongViec();
        }
        internal List<CongViecDTO> GetAllCongViecNVcv(string idCv, string idNv)
        {
            return service.GetAllCongViecNVcv(idCv, idNv);
        }
        internal List<CongViecNvDTO> GetAllCongViecPublic()
        {
            return service.GetAllCongViecPublic();
        }

        internal string getTenNvById(int id)
        {
            return service.getNvById(id);
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

        internal bool updatePCCV(string idCv, string idNV, string dateStart, string dateEnd, string comment)
        {
            if (service.updateNgay(idCv, dateStart, dateEnd) && service1.updateComment(idNV,idCv,comment))
            {
                return true;
            }
            return false;
        }

        public void InsertJob(string ten, string timeStart, string timeEnd, string partner, bool phamvi)
        {
            service.InsertJob(ten, timeStart, timeEnd, partner, phamvi);
        }

        public string CheckStatusCv(int status)
        {
            if(status == 0)
            {
                return "<td><span class='badge badge-primary'>" + "Đang làm" + "</span></td>";
            }
            if(status == 1)
            {
                return "<td><span class='badge badge-success'>" + "Hoàn thành" + "</span></td>";
            }
            if(status == 2)
            {
                return "<td><span class='badge badge-danger'>" + "Trễ hẹn" + "</span></td>";
            }
            return "";
        }

        internal bool themCongViec(string ten, string timeStart, string timeEnd, string partner, string phamvi)
        {
            string id = service.themCongViec(ten,timeStart,timeEnd,phamvi);
            string[] ps = partner.Split(',');
            foreach(var p in ps)
            {
                Console.WriteLine(p);
                service.insertPhanCong(p, id);
            }
            return true;
        }
        public bool ThemCongViecNV(string idcv, string timeStart, string timeEnd)
        {
            return service.CreateCvNv(idcv, timeStart, timeEnd);
        }

        public string GetLatestIdCongViec()
        {
            return service.GetLatestIdCongViec();
        }

        public string UpdateStatus(int status,int idcv)
        {
            if (status == 0)
            {
                return "<td><a href='./CapNhatStatus.aspx?id=" + idcv + "'>Cập nhật</a></td>";
            }
             return "";
        }
    }
}