using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_29_Assignment_ADO.NET
{
    public partial class ManageDept : Form
    {
        public ManageDept()
        {
            InitializeComponent();
        }

        private void ManageDept_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'empSearchDBDataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.empSearchDBDataSet.Department);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
