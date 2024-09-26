using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace twolayer
{
    public partial class userinsert : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "~/photo/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));
            string str = "insert into twolayer values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + path + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            int i = conobj.fn_nonquery(str);
            if (i == 1)
            {
                Label1.Text = "inserted";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
    }
}