using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAutoCare
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCashiers adminCashiers = new AdminCashiers();
            adminCashiers.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminReports adminReports = new AdminReports();
            adminReports.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditMyDetailsAdmin editMyDetails = new EditMyDetailsAdmin();
            editMyDetails.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminEnquiry adminEnquiry = new AdminEnquiry();
            adminEnquiry.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminVehicleCategory adminVehicleCategory = new AdminVehicleCategory();
            adminVehicleCategory.ShowDialog();
            this.Close();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
