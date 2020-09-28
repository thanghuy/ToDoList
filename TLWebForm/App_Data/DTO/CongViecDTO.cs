using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLWebForm.App_Data.DTO
{
    public class CongViecNvDTO
    {
        public int Id { get; set; }
        public string TenCongViec { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public bool PhamVi { get; set; }
        public string IdPartner { get; set; }
        public string FileDinhKem { get; set; }
        public string BinhLuan { get; set; }
        public int Status { get; set; }
        public bool IsVisible { get; set; }

        public CongViecNvDTO(int id, string tenCongViec, string ngayBatDau, string ngayKetThuc, bool phamVi, string idPartner, string fileDinhKem, string binhLuan, int status, bool isVisible)
        {
            Id = id;
            TenCongViec = tenCongViec;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            PhamVi = phamVi;
            IdPartner = IdPartner;
            FileDinhKem = fileDinhKem;
            BinhLuan = binhLuan;
            Status = status;
            IsVisible = isVisible;
        }

        public CongViecNvDTO()
        {
        }
    }
}