using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TLWebForm.App_Data.DAL
{
    public class NhanVienAccess
    {
        public DataTable GetAllNhanVien()
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"select * from NhanVien";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];

                //List<NhanVien> rows = connection.Query<NhanVien>("ListAll").ToList();
                //return rows;
            }
        }
        public bool Login(string email, string password)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                string query = @"select 1 from NhanVien where Email = @Email and Password = @Password ";
                
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var result = cmd.ExecuteScalar();
                    return result != null ? true : false;
                }
                //return Convert.ToBoolean();
            }
        }

        public DataSet GetNhanVienById(string id)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"select * from NhanVien where id = " + id;
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public void InsertNhanVien(string fullName, string email, string password, bool isManager)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into NhanVien(FullName, Email, Password, AvatarPath, IsManager)" +
                                "values (@FullName, @Email, @Password, NULL, @IsManager)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    //cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);
                    cmd.Parameters.AddWithValue("@IsManager", isManager);
                    //System.Diagnostics.Debug.WriteLine(query);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetNhanVienLatest()
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"select * from NhanVien where id = (select max(id) from NhanVien)";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public void UpdateNhanVien(string id, string fullName, string email, string password, bool isManager)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update NhanVien " +
                                "set FullName = ISNULL(@fullName, FullName), " +
                                "Email = ISNULL(@email, Email), " +
                                "Password = ISNULL(@password, Password), " +
                                "IsManager = @isManager " +
                                "where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    //cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);
                    cmd.Parameters.AddWithValue("@IsManager", isManager);
                    //System.Diagnostics.Debug.WriteLine(query);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}