using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TLWebForm.App_Data.DTO;

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
                string query = @"update CongViec" +
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

                internal List<ChitTietCvDTO> getChiTiet(int id)
        {
            List<ChitTietCvDTO> list = new List<ChitTietCvDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select nv.id,cv.Id, cv.TenCongViec,cv.NgayBatDau,cv.NgayKetThuc,cv.PhamVi,pc.comment, cv.Status from congviec cv,nhanvien nv,phancong pc
where nv.id = pc.idnhanvien and pc.idcongviec=cv.Id and idnhanvien = "+id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ChitTietCvDTO cv = new ChitTietCvDTO();
                            cv.idnhanvien = dr.GetInt32(0);
                            cv.idcongviec = dr.GetInt32(1);
                            cv.TenCongViec = dr.GetString(2);
                            cv.NgayBatDau = dr.GetDateTime(3).ToString();
                            cv.NgayKetThuc = dr.GetDateTime(4).ToString();
                            cv.PhamVi = dr.GetBoolean(5);
                            cv.Comment = dr.GetString(6);
                            cv.Status = dr.GetInt32(7);
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }

                internal List<CongViecNvDTO> GetAllCongViecNv(string idNhanVien)
        {
            List<CongViecNvDTO> list = new List<CongViecNvDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select * from CongViec where IdNhanVien = " + idNhanVien;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecNvDTO cv = new CongViecNvDTO();
                            cv.Id = Convert.ToInt32(dr["Id"].ToString());
                            cv.NgayBatDau = dr["StartDate"].ToString();
                            cv.NgayKetThuc = dr["EndDate"].ToString();
                            cv.PhamVi = Convert.ToBoolean(dr["IsPublic"]);
                            cv.IdPartner = dr["PartnerNhanVien"].ToString();
                            cv.Status = Convert.ToInt32(dr["Status"]);
                            cv.TenCongViec = dr["NameCongViec"].ToString();
                            //cv.BinhLuan = dr[6].ToString();
                            cv.FileDinhKem = dr["Files"].ToString();
                            cv.IsVisible = Convert.ToBoolean(dr["IsVisible"]);
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }

        internal void insertPhanCong(string p, string id)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into PhanCong(idcongviec,idnhanvien)" +
                                "values (@idcongviec,@idnhanvien)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idcongviec", id);
                    cmd.Parameters.AddWithValue("idnhanvien", p);
                    System.Diagnostics.Debug.WriteLine(query);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal string themCongViec(string ten, string timeStart, string timeEnd, string phamvi)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"insert into CongViec(NameCongViec,IdNhanVien,StartDate,EndDate,IsPublic,PartnerNhanVien,Files,Status,IsVisible)" +
                                "values (@NameCongViec,@IdNhanVien,@StartDate,@EndDate,@IsPublic,@PartnerNhanVien,@Files,@Status,@IsVisible)"+ "; SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NameCongViec", ten);
                    cmd.Parameters.AddWithValue("@IdNhanVien", "");
                    cmd.Parameters.AddWithValue("@StartDate", timeStart);
                    cmd.Parameters.AddWithValue("@EndDate", timeEnd);
                    cmd.Parameters.AddWithValue("@IsPublic", phamvi);
                    cmd.Parameters.AddWithValue("@PartnerNhanVien", "");
                    cmd.Parameters.AddWithValue("@Files", "");
                    cmd.Parameters.AddWithValue("@Status",0);
                    cmd.Parameters.AddWithValue("@IsVisible", true);
                    System.Diagnostics.Debug.WriteLine(query);
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        public List<CongViecDTO> GetAllCongViec()
        {
            List<CongViecDTO> list = new List<CongViecDTO>();
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
            return list;
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
                string query = @"update CongViec" +
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

        internal List<CongViecNvDTO> GetAllCongViecPublic()
        {
            //Ignore nhầm file này trong cái commit cũ nên thiếu mất method này
            List<CongViecNvDTO> list = new List<CongViecNvDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select * from CongViec where IsPublic=1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecNvDTO cv = new CongViecNvDTO();
                            cv.Id = Convert.ToInt32(dr["Id"].ToString());
                            cv.NgayBatDau = dr["StartDate"].ToString();
                            cv.NgayKetThuc = dr["EndDate"].ToString();
                            cv.PhamVi = Convert.ToBoolean(dr["IsPublic"]);
                            cv.IdPartner = dr["PartnerNhanVien"].ToString();
                            cv.Status = Convert.ToInt32(dr["Status"]);
                            cv.TenCongViec = dr["NameCongViec"].ToString();
                            //cv.BinhLuan = dr[6].ToString();
                            cv.FileDinhKem = dr["Files"].ToString();
                            cv.IsVisible = Convert.ToBoolean(dr["IsVisible"]);
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }

        public void AssignNhanVienToCongViec(string idCongViec, string idNhanVien)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update CongViec" +
                                "set IdNhanVien = @idNhanVien" +
                                "where Id = @idCongViec";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idCongViec", idCongViec);
                    cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AssignPartnerToCongViec(string idCongViec, string idPartner)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update CongViec" +
                                "set PartnerNhanVien = @idPartner" +
                                "where Id = @idCongViec";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idCongViec", idCongViec);
                    cmd.Parameters.AddWithValue("@idPartner", idPartner);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}