using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLWebForm.App_Data.DTO
{

    public class ChitTietCvDTO
    {
        public int idnhanvien { get; set; }
        public int idcongviec{ get; set; }
        public string NgayBatDau{ get; set; }
        public string NgayKetThuc { get; set; }
        public bool PhamVi{ get; set; }
        public string Comment{ get; set; }
        public int Status { get; set; }
        public string TenCongViec{ get; set; }
        public string Files { get; set; }
    }

}