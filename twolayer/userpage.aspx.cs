using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace twolayer
{
    public partial class userpage : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strn = "select Name,Age,Address,Photo,Username,Password from twolayer where id="+Session["id"]+"";
            SqlDataReader dr = conobj.fn_Reader(strn);
            while (dr.Read())
            {
                TextBox1.Text = dr["Name"].ToString();
                TextBox2.Text = dr["Age"].ToString();
                TextBox3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["Photo"].ToString();
                
            }
            DataSet ds = conobj.fn_Dataset(strn);
            GridView1.DataSource = ds;
            GridView1.DataBind();



            DataTable dt = conobj.fn_DataTable(strn);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }
    }
}