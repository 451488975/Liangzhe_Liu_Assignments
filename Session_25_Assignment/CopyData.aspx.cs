using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Session_25_Assignment
{
    public partial class CopyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            string CD = ConfigurationManager.ConnectionStrings["CD"].ConnectionString;

            using (SqlConnection sourcecon = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Departments", sourcecon);
                sourcecon.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection dstcon = new SqlConnection(CD))
                    {
                        using (SqlBulkCopy cb = new SqlBulkCopy(dstcon))
                        {
                            cb.DestinationTableName = "Departments";
                            dstcon.Open();
                            cb.WriteToServer(rdr);
                        }
                    }
                }

                cmd = new SqlCommand("select * from Employees", sourcecon);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection dstcon = new SqlConnection(CD))
                    {
                        using (SqlBulkCopy cb = new SqlBulkCopy(dstcon))
                        {
                            cb.DestinationTableName = "Employees";
                            dstcon.Open();
                            cb.WriteToServer(rdr);
                        }
                    }
                }
            } 
        }
    }
}