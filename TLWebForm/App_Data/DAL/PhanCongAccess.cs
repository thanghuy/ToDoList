using System.Data;
using System.Data.SqlClient;

namespace TLWebForm.App_Data.DAL
{
    public class PhanCongAccess
    {
        public void MakeComment(string idCongViec, string idNhanVien, string comment)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update PhanCong" +
                                "set Comment = @comment" +
                                "where IdNhanVien = @idNhanVien and IdCongViec = @idCongViec";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    //reupS
                    cmd.Parameters.AddWithValue("@idCongViec", idCongViec);
                    cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddPhanCong(string idNhanvien, string idCongViec)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into PhanCong(idnhanvien, idcongviec)" +
                                "values (@idnv, @idcv)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    //reupS
                    cmd.Parameters.AddWithValue("@idnv", idNhanvien);
                    cmd.Parameters.AddWithValue("@idcv", idCongViec);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}