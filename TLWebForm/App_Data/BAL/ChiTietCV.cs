using System.Collections.Generic;
using TLWebForm.App_Data.DAL;
using TLWebForm.App_Data.DTO;

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