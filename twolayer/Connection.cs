using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace twolayer
{
    public class Connection
    {
        SqlConnection con;
        SqlCommand cmd;

        public Connection()
        {
            con = new SqlConnection(@"server=LAPTOP-5IIRRV2L\SQLEXPRESS;database=SqlDB;integrated security=true");
        }
        public int fn_nonquery(string sqlqurey)//insert,delete,update
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            cmd = new SqlCommand(sqlqurey, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string fn_scalar(string sqlqurey)//scalar functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            cmd = new SqlCommand(sqlqurey, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader fn_Reader(string sqlqurey)//scalar functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlqurey, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            return dr;
        }
        public DataSet fn_Dataset(string sqlqurey)//scalar functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlqurey, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlqurey,con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataTable fn_DataTable(string sqlqurey)//scalar functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlqurey, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlqurey, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}