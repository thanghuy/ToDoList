using System;
using System.Data;
using System.Data.SqlClient;

namespace TLWebForm.App_Data.DAL
{
    public class CongViecAccess
    {
        public void MarkStatus(string id, bool status)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update NhanVien" +
                                "set Status = @status" +
                                "where Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal void InsertJob(string ten, string timeStart, string timeEnd, string partner, bool phamvi)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into CongViec(TenCongViec, NgayBatDau, NgayKetThuc,PhamVi, FileDinhKem,BinhLuan,Status)" +
                                "values (@TenCongViec, @NgayBatDau, @NgayKetThuc, @PhamVi, @FileDinhKem, @BinhLuan, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TenCongViec", ten);
                    cmd.Parameters.AddWithValue("@NgayBatDau", timeStart);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", timeEnd);
                    //cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);
                    cmd.Parameters.AddWithValue("@PhamVi", phamvi);
                    cmd.Parameters.AddWithValue("@FileDinhKem", "null");
                    cmd.Parameters.AddWithValue("@BinhLuan", "null");
                    cmd.Parameters.AddWithValue("@Status", "false");
                    System.Diagnostics.Debug.WriteLine(query);
                    Console.WriteLine(cmd.ExecuteNonQuery());
                }
            }
        }

        public void UpdateFinishDate(string id, string date)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update NhanVien" +
                                "set NgayKetThuc = @date" +
                                "where Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}