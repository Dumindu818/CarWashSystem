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
    public partial class CashierOverview : Form
    {
        functions fn = new functions();
        String query;
        public CashierOverview()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCashiers adminCashiers = new AdminCashiers();
            adminCashiers.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CashierOverview_Load(object sender, EventArgs e)
        {
            query = "select ServiceBy AS AgentName ,count(*) AS TotalServices from tblservicerequest GROUP BY ServiceBy";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
