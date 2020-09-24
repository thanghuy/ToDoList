using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TLWebForm.App_Start;
using TLWebForm.GUI.Admin;
using TLWebForm.GUI.NhanVien;

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

        internal List<CongViecDTO> GetAllCongViec()
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