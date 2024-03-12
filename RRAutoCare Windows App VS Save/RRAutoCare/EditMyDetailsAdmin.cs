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
    public partial class EditMyDetailsAdmin : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public EditMyDetailsAdmin()
        {
            InitializeComponent();
        }

        private void EditMyDetails_Load(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "Select * from tbladmin where AdminuserName = '" + Trans.AdminID + " ' ";
            command = new MySqlCommand(selectQuery, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox4.Text = reader.GetString("AdminuserName");
                textBox2.Text = reader.GetString("AdminName");
                textBox5.Text = reader.GetString("Email");
                textBox1.Text = reader.GetString("MobileNumber");
                textBox3.Text = reader.GetString("Password");


            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();
            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    query = "update tbladmin set AdminuserName='" + textBox4.Text + "' ,AdminName = '" + textBox2.Text + "' ,Password = '" + textBox3.Text + "' ,MobileNumber = '" + textBox1.Text + "' ,Email = '" + textBox5.Text  + "' where AdminuserName = '" + Trans.AdminID + "' ";
                    fn.setData(query, "Updated");
                    EditMyDetails_Load(this, null);
              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
