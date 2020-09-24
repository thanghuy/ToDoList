using System.Data;
using System.Data.SqlClient;

namespace TLWebForm.App_Data.DAL
{
    public class CommentAccess
    {
        public void MakeComment(string idCongViec, string idNhanVien, string content)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into Comment (IdCongViec, IdNhanVien, Content)" +
                                "values (@idCongViec, @idNhanVien, @content)" +
                                "where Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idCongViec", idCongViec);
                    cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}