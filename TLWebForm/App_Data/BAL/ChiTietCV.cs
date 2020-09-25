using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DAL;
using TLWebForm.App_Data.DTO;
using TLWebForm.App_Start;
using TLWebForm.GUI.Admin;

namespace TLWebForm.App_Data.BAL
{
    public class ChiTietCV
    {
        private CongViecAccess service = new CongViecAccess();

        public List<ChitTietCvDTO> getChiTiet(int id)
        {
            return service.getChiTiet(id);
        }
    }
}