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

        internal void updateStatusById(string idcv)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE CongViec SET Status=1 WHERE id = "+idcv;
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal List<CongViecDTO> getCongViecById(string v)
        {
            List<CongViecDTO> list = new List<CongViecDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"SELECT cv.id,cv.NameCongViec from CongViec cv 
                WHERE cv.id not in (SELECT idcongviec from PhanCong WHERE IdNhanVien = "+v+") ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecDTO cv = new CongViecDTO();
                            cv.Id = Convert.ToInt32(dr["Id"].ToString());
                            cv.TenCongViec = dr["NameCongViec"].ToString();
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }

        internal List<ChitTietCvDTO> getChiTiet(int id)//Cũ
        {
            List<ChitTietCvDTO> list = new List<ChitTietCvDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select cv.id,cv.NameCongViec,cv.StartDate,cv.EndDate,cv.isPublic,cv.Files,cv.Status,pc.comment,nv.id from CongViec cv , NhanVien nv , PhanCong pc 
				where nv.id = pc.idnhanvien
				and cv.id = pc.idcongviec 
				and nv.id = " + id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ChitTietCvDTO cv = new ChitTietCvDTO();
                            cv.idcongviec = dr.GetInt32(0);
                            cv.TenCongViec = dr.GetString(1);
                            cv.NgayBatDau = dr.GetDateTime(2).ToString();
                            cv.NgayKetThuc = dr.GetDateTime(3).ToString() == null ? "" : dr.GetDateTime(3).ToString();
                            cv.PhamVi = dr.GetBoolean(4);
                            cv.Files = dr.GetString(5);
                            cv.Status = dr.GetInt32(6);
                            cv.Comment = dr.GetString(7) == null ? "" : dr.GetString(7);
                            cv.idnhanvien = dr.GetInt32(8);
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }


        internal List<ChitTietCvDTO> getChiTiet1(int id)//Hoang son
        {
            List<ChitTietCvDTO> list = new List<ChitTietCvDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select nv.id,cv.Id, cv.TenCongViec,cv.NgayBatDau,cv.NgayKetThuc,cv.PhamVi,pc.comment, cv.Status from congviec cv,nhanvien nv,phancong pc
where nv.id = pc.idnhanvien and pc.idcongviec=cv.Id and idnhanvien = " + id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ChitTietCvDTO cv = new ChitTietCvDTO();
                            cv.idcongviec = dr.GetInt32(0);
                            cv.TenCongViec = dr.GetString(1);
                            cv.NgayBatDau = dr.GetDateTime(2).ToString();
                            cv.NgayKetThuc = dr.GetDateTime(3).ToString() == null ? "" : dr.GetDateTime(3).ToString();
                            cv.PhamVi = dr.GetBoolean(4);
                            cv.Files = dr.GetString(5);
                            cv.Status = dr.GetInt32(6);
                            cv.Comment = dr.GetString(7) == null ? "" : dr.GetString(7);
                            cv.idnhanvien = dr.GetInt32(8);
                            list.Add(cv);
                        }
                    }
                }
            }
            return list;
        }


        internal string getNvById(int id)
        {
            string s = "";
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"
                    select FullName from CongViec cv,NhanVien nv, PhanCong pc
                    WHERE cv.id = pc.idcongviec and nv.id = pc.idnhanvien
                    and cv.id = "+id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            s = s + dr.GetString(0)+" ,";
                        }
                    }
                }
            }
            return s;
        }

        internal bool updateNgay(string idCv, string dateStart, string dateEnd)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"update CongViec set StartDate = @dateStart, EndDate = @dateEnd where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idCv);
                    cmd.Parameters.AddWithValue("@dateStart", dateStart);
                    cmd.Parameters.AddWithValue("@dateEnd", dateEnd);

                    return cmd.ExecuteNonQuery()!=0;
                }
            }
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
                string query = @"select cv.id,cv.NameCongViec,cv.StartDate,cv.EndDate,cv.isPublic,cv.Files,cv.Status,pc.comment from CongViec cv , NhanVien nv , PhanCong pc 
				where nv.id = pc.idnhanvien
				and cv.id = pc.idcongviec 
				and nv.id = " + idNhanVien;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecNvDTO cv = new CongViecNvDTO();
                            cv.Id = Convert.ToInt32(dr["id"].ToString());
                            cv.NgayBatDau = dr["StartDate"].ToString();
                            cv.NgayKetThuc = dr["EndDate"].ToString();
                            cv.PhamVi = Convert.ToBoolean(dr["IsPublic"]);
                            cv.Status = Convert.ToInt32(dr["Status"]);
                            cv.TenCongViec = dr["NameCongViec"].ToString();
                            cv.BinhLuan = dr["comment"].ToString();
                            cv.FileDinhKem = dr["Files"].ToString();
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
                string query = @"insert into PhanCong(idcongviec,idnhanvien,comment)" +
                                "values (@idcongviec,@idnhanvien,@comment)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idcongviec", id);
                    cmd.Parameters.AddWithValue("idnhanvien", p);
                    cmd.Parameters.AddWithValue("@comment", " ");
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
                            cv.NgayBatDau = dr[3].ToString();
                            cv.NgayKetThuc = dr[4].ToString();
                            cv.PhamVi = (bool)dr["IsPublic"];
                            cv.Status = Convert.ToInt32(dr["Status"].ToString());
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
        public List<CongViecDTO> GetAllCongViecNVcv(string idCv, string idNv)
        {
            List<CongViecDTO> list = new List<CongViecDTO>();
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select cv.StartDate,cv.EndDate,pc.comment from CongViec cv,PhanCong pc , NhanVien nv"
                                + "where nv.id = pc.idnhanvien"
                                + "and cv.id = pc.idcongviec"
                                + "and nv.id = " + idNv + ""
                                + "and cv.id = " + idCv;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CongViecDTO cv = new CongViecDTO();
                            cv.NgayBatDau = dr[0].ToString();
                            cv.NgayKetThuc = dr[1].ToString();
                            cv.BinhLuan = dr[2].ToString();
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


        public bool CreateCvNv(string idcv, string timeStart, string timeEnd)
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE CongViec SET StartDate = @timeStart,EndDate = @timeEnd,Status = 0 WHERE id = @idcv";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@idcv", idcv);
                    cmd.Parameters.AddWithValue("@timeStart", timeStart);
                    cmd.Parameters.AddWithValue("@timeEnd", timeEnd);
                    return cmd.ExecuteNonQuery()!=0;
                }
            }
        }

        public string GetLatestIdCongViec()
        {
            string connectionString = DataAccess.Internal.DataAccess.GetConnectionString("TodoListDb");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                string query = @"select id from CongViec where id = (select max(id) from CongViec)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string id = dr["Id"].ToString();
                            return id;
                        }
                    }
                    return null;
                }
            }
        }
    }
}