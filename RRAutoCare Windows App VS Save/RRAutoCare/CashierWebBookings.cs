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
    public partial class CashierWebBookings : Form
    {
        functions fn = new functions();
        String query;
        public CashierWebBookings()
        {
            InitializeComponent();
        }

        private void EmployeeAppointments_Load(object sender, EventArgs e)
        {
            query = "select ID,UserID, ServiceNumber, Category, VehicleName, VehicleModel, VehicleBrand, VehicleRegno, ServiceDate, ServiceTime, DeliveryType, PickupAddress, ServicerequestDate from tblservicerequest where AdminStatus <=> NULL";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierDashboard cashierDashboard = new CashierDashboard();
            cashierDashboard.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Trans.ServiceNumber = int.Parse(textBox2.Text);
            query = "update tblservicerequest set AdminStatus='1' where ServiceNumber = '" + textBox2.Text + "' ";
            fn.setData(query, "Request Granted.");
            this.Hide();
            CashierNewJob cashierNewJob = new CashierNewJob();
            cashierNewJob.ShowDialog();
            
            this.Close();
        }
        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i= e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox2.Text = row.Cells[2].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
