using System.Collections.Generic;
using TLWebForm.App_Data.DAL;
using TLWebForm.App_Data.DTO;

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

        internal List<CongViecNvDTO> GetAllCongViecNv(string idNhanVien)
        {
            return service.GetAllCongViecNv(idNhanVien);
        }

        internal List<CongViecDTO> GetAllCongViec()
        {
            return service.GetAllCongViec();
        }

        internal List<CongViecNvDTO> GetAllCongViecPublic()
        {
            return service.GetAllCongViecPublic();
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
        public void InsertJob(string ten, string timeStart, string timeEnd, string partner, bool phamvi)
        {
            service.InsertJob(ten, timeStart, timeEnd, partner, phamvi);
            
        }
    }
}