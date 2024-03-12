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
    public partial class RespondedEnquiries : Form
    {
        functions fn = new functions();
        string query;
        public RespondedEnquiries()
        {
            InitializeComponent();
        }

        private void RespondedEnquiries_Load(object sender, EventArgs e)
        {
            query = "select ID,UserId, EnquiryNumber, EnquiryType, Description, EnquiryDate,AdminResponse, AdminRemarkdate from tblenquiry where AdminStatus = 1";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminEnquiry adminEnquiry = new AdminEnquiry();
            adminEnquiry.ShowDialog();
            this.Close();
        }
    }
}
