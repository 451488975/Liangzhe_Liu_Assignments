using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Session_25_Assignment
{
    public partial class XMLDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml($"{AppDomain.CurrentDomain.BaseDirectory}/XMLFile1.xml");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();

            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sqlQuery = "select * from Departments";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables[0]);

            sqlQuery = "select * from Employees";
            da = new SqlDataAdapter(sqlQuery, con);
            builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables[1]);
        }
    }
}