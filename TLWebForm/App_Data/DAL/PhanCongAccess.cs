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
        
    }
}