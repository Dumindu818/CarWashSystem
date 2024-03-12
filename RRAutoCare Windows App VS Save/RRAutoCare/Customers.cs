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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateACustomer updateACustomer = new UpdateACustomer();
            updateACustomer.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOverview customerOverview = new CustomerOverview();
            customerOverview.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Trans.Loginc == true)
            {
                this.Hide();
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.ShowDialog();
                this.Close();
            }
            else if (Trans.Loginc == false)
            {
                this.Hide();
                CashierDashboard cashierDashboard = new CashierDashboard();
                cashierDashboard.ShowDialog();
                this.Close();
            }
        }
    }
}
