using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RRAutoCare
{

    public partial class CustomerOverview : Form
    {
        functions fn = new functions();
        String query;
        public CustomerOverview()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.ShowDialog();
            this.Close();
        }

        private void CustomerOverview_Load(object sender, EventArgs e)
        {
            query = "select UserId AS CustomerID ,count(*) AS TotalServices from tblservicerequest GROUP BY UserId";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
