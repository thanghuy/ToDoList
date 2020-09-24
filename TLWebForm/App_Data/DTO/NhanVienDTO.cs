using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DTO;

namespace TLWebForm.App_Data.DTO
{
    public class NhanVienDTO
    {
        public int idNV { get; set; }
        public string TenNV { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Quyen { get; set; }
    }
}