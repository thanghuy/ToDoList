﻿using System;
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
                                + "and nv.id = " + idCv + ""
                                + "and cv.id = " + idNv;
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
    }
}