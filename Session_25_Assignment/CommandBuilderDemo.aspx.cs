using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemos2
{
    public partial class CommandBuilderDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sqlQuery = "select * from tblStudents where Id = " + txtStudentID.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = ds;

            if (ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                txtStudentName.Text = dr["Name"].ToString();
                txtGender.Text = dr["Gender"].ToString();
                txtTotalMarks.Text = dr["TotalMarks"].ToString();

                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Loaded";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No Student's Record Found with ID: " + txtStudentID.Text;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            Response.Write(builder.GetUpdateCommand().CommandText);

            DataSet ds = (DataSet)ViewState["DATASET"];

            DataRow dr = ds.Tables["Students"].Rows[0];

            dr["Name"] = txtStudentName.Text;
            dr["Gender"] = txtGender.Text;
            dr["TotalMarks"] = txtTotalMarks.Text;

            int rowsUpdated = da.Update(ds, "Students");
            if (rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Not Updated";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            Response.Write(builder.GetDeleteCommand().CommandText);

            DataSet ds = (DataSet)ViewState["DATASET"];

            DataRow dr = ds.Tables["Students"].Rows[0];

            dr.Delete();
            txtStudentID.Text = txtStudentName.Text = txtGender.Text = txtTotalMarks.Text = "";
            int rowsUpdated = da.Update(ds, "Students");
            
            if (rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Deleted";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Not Deleted";
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sqlQuery = "select * from tblStudents";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);

            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            DataTable dt = ds.Tables["Students"];
            DataRow dr = dt.NewRow();

            dr["Name"] = txtStudentName.Text;
            dr["Gender"] = txtGender.Text;
            dr["TotalMarks"] = txtTotalMarks.Text;
            dr["Id"] = (int)dt.Rows[dt.Rows.Count - 1]["Id"] + 1;
            dt.Rows.Add(dr);
            txtStudentID.Text = (string)dr["Id"];

            int rowsInserted = da.Update(ds, "Students");
            if (rowsInserted > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Inserted";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Student's Record with ID: " + txtStudentID.Text + " Not Inserted";
            }
            Response.Write(builder.GetInsertCommand().CommandText);
        }
    }
}