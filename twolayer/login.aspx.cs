using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace twolayer
{
    public partial class login : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select count(id)from twolayer where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string cid = conobj.fn_scalar(sel);
            if (cid == "1")
            {
                int id1 = 0;
                string sr= "select id from twolayer where username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                //string id= conobj.fn_scalar(sr);
                SqlDataReader dr = conobj.fn_Reader(sr);
                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["id"].ToString()); 
                }
                Session["id"] = id1;
                Response.Redirect("userpage.aspx");
            }
            
            else
            {
                Label1.Text = "invalid user";
            }

        }
    }
}