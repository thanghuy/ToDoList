using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DAL;

namespace TLWebForm.App_Data.BAL
{
    public class NhanVienBUS
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public bool IsManager { get; set; }
        private NhanVienAccess service = new NhanVienAccess();
        public NhanVienBUS()
        {

        }

        public DataSet GetNhanVienById(string id)
        {
            return service.GetNhanVienById(id);
        }


        public void InsertNhanVien(string fullName, string email, string password, bool isManager)
        {
            service.InsertNhanVien(fullName, email, password, isManager);
        }

        public DataSet GetNhanVienLatest()
        {
            return service.GetNhanVienLatest();   
        }

        public DataTable GetAllNhanVien()
        {
            return service.GetAllNhanVien();
        }

        public void UpdateNhanVien(string id, string fullName, string email, string password, bool isManager)
        {
            service.UpdateNhanVien(id, fullName, email, password, isManager);
        }

        public bool Login(string email, string password)
        {
            return service.Login(email, password);
        }
    }
}