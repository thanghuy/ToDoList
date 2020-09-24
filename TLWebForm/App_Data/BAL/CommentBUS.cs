using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DAL;

namespace TLWebForm.App_Data.BAL
{
    public class CommentBUS
    {
        private CommentAccess service = new CommentAccess();
        public CommentBUS() { }

       public void MakeComment(string idCongViec, string idNhanVien, string content)
        {
            if(idCongViec == null || idNhanVien == null || content == null)
            {
                throw new ArgumentNullException("IdCongViec, IdNhanVien and Comment content cannot be null");
            }
            else
            {
                service.MakeComment(idCongViec, idNhanVien, content);
            }
        }
        
    }
}