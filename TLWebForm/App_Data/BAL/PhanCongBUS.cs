using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DAL;

namespace TLWebForm.App_Data.BAL
{
    public class PhanCongBUS
    {
        private PhanCongAccess service = new PhanCongAccess();
        public PhanCongBUS() { }

       public void MakeComment(string idCongViec, string idNhanVien, string content)
        {
            if(idCongViec == null || idNhanVien == null || content == null)
            {
                throw new ArgumentNullException("IdCongViec, IdNhanVien and Comment content cannot be null");
            }
            else
            {
                //Reup
                service.MakeComment(idCongViec, idNhanVien, content);
            }
        }

        public bool AddPhanCong(string idnhanvien, string idcongviec)
        {
            return service.AddPhanCong(idnhanvien, idcongviec);
        }
        
    }
}