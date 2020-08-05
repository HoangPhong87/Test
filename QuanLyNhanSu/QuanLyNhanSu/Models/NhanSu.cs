using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class NhanSu
    {
        public int ID { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
    }
    class DsNhanSu
    {
        DBConnection db;
        public DsNhanSu()
        {
            db = new DBConnection();
        }
        //lay ve ds nhan vien
        public List<NhanSu> getnhansu(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT * FROM NhanSu";
            else
                sql = " SELECT * FROM NhanSu WHERE Id=" + ID;
            List<NhanSu> danhsach = new List<NhanSu>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            NhanSu tmpNS;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpNS = new NhanSu();
                tmpNS.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpNS.FullName = dt.Rows[i]["FullName"].ToString();
                tmpNS.Address = dt.Rows[i]["Address"].ToString();
                tmpNS.Phone = dt.Rows[i]["Phone"].ToString();
                tmpNS.Email = dt.Rows[i]["Email"].ToString();
                danhsach.Add(tmpNS);
            }
            return danhsach;
        }
        //Them du lieu nv
        public void AddNhanSu(NhanSu ns)
        {
            string sql = " INSERT INTO NhanSu(FullName,Address,Phone,Email) VALUES (N'" + ns.FullName + "',N'" + ns.Address + "','" + ns.Phone + "','" + ns.Email + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        //Sua du lieu 
        public void UpdateNhanSu(NhanSu ns)
        {
            string sql = " UPDATE NhanSu SET FullName =N'" + ns.FullName + "',Address=N'" + ns.Address + "',Phone='" + ns.Phone + "',Email='" + ns.Email + "' WHERE ID= " + ns.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Xoa du lieu
        public void DeleteNhanSu(NhanSu ns)
        {
            string sql = " DELETE NhanSu WHERE ID =" + ns.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}