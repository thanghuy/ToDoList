using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLWebForm.App_Start
{
    public class CongViecDTO
    {
        public int Id { get; set; }
        public string TenCongViec { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public bool PhamVi { get; set; }
        public string FileDinhKem { get; set; }
        public string BinhLuan { get; set; }
        public bool Status { get; set; }

        public CongViecDTO(int id, string tenCongViec, string ngayBatDau, string ngayKetThuc, bool phamVi, string fileDinhKem, string binhLuan, bool status)
        {
            Id = id;
            TenCongViec = tenCongViec;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            PhamVi = phamVi;
            FileDinhKem = fileDinhKem;
            BinhLuan = binhLuan;
            Status = status;
        }

        public CongViecDTO()
        {
        }
    }
}