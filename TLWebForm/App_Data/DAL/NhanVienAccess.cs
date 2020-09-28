using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TLWebForm.App_Data.DTO;

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

        public List<NhanVienDTO> allNV()
        {
            /*List<CongViecDTO> list = new List<CongViecDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select * from CongViec";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecDTO cv = new CongViecDTO();
                            cv.Id = Convert.ToInt32(dr[0].ToString());
                            cv.NgayBatDau = dr[2].ToString();
                            cv.NgayKetThuc = dr[3].ToString();
                            cv.PhamVi = (bool)dr["PhamVi"];
                            cv.Status = (bool)dr["Status"];
                            cv.TenCongViec = dr[1].ToString();
                            cv.BinhLuan = dr[6].ToString();
                            cv.FileDinhKem = dr[5].ToString();
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;*/
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"select * from NhanVien";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            NhanVienDTO nv = new NhanVienDTO();
                            nv.idNV = Convert.ToInt32(dr[0].ToString());
                            nv.TenNV = dr[1].ToString();
                            list.Add(nv);
                        }
                    }
                }

            }
            return list;
        }

        public List<NhanVienDTO> GetLoginInfo(string email, string password)
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>(); 
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = @"select * from NhanVien where Email = @Email and Password = @Password ";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        NhanVienDTO nv = new NhanVienDTO();
                        nv.idNV = rd.GetInt32(0);
                        nv.TenNV = rd.GetString(1);
                        nv.Email = rd.GetString(2);
                        nv.Quyen = rd.GetBoolean(3);
                        nv.Password = rd.GetString(4);
                        list.Add(nv);

                    }
                }
                //
            }
            return list;
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
                    System.Diagnostics.Debug.WriteLine(query);
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