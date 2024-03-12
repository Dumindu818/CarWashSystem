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

    public partial class EditMyDetailsAgent : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public EditMyDetailsAgent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("are you sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from tblcashiers where CashieruserName= '" + Trans.CashierID + "' ";
                    fn.setData(query, "Account Deleted.");

                    this.Hide();
                    Opening opening = new Opening();
                    opening.ShowDialog();
                    this.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierDashboard cashierDashboard = new CashierDashboard();
            cashierDashboard.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                query = "update tblcashiers set CashieruserName='" + CUN.Text + "' ,FullName = '" + CFN.Text + "' ,Email = '" + CE.Text + "' ,Address = '" + CA.Text + "' ,MobileNumber = '" + CM.Text + "' ,Password = '" + CPW.Text + "' where CashieruserName = '" + Trans.CashierID + "' ";
                fn.setData(query, "Updated");
                EditMyDetailsAgent_Load(this, null);
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditMyDetailsAgent_Load(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "Select * from tblCashiers where CashieruserName = '" + Trans.CashierID + " ' ";
            command = new MySqlCommand(selectQuery, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                CUN.Text = reader.GetString("CashieruserName");
                CFN.Text = reader.GetString("FullName");
                CE.Text = reader.GetString("Email");
                CA.Text = reader.GetString("Address");
                CM.Text = reader.GetString("MobileNumber");
                CPW.Text = reader.GetString("Password");


            }

            connection.Close();
        }
    }
}