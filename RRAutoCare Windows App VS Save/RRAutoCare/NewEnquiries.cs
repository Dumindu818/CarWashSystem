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
    public partial class NewEnquiries : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public NewEnquiries()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminEnquiry adminEnquiry = new AdminEnquiry();
            adminEnquiry.ShowDialog();
            this.Close();
        }
        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox2.Text = row.Cells[2].Value.ToString();
        }

        private void NewEnquiries_Load(object sender, EventArgs e)
        {
            query = "select ID, UserID, EnquiryNumber, EnquiryType, EnquiryDate from tblenquiry where AdminStatus <=> NULL";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "Select * from tblenquiry where EnquiryNumber = '" + textBox2.Text + " ' ";
            command = new MySqlCommand(selectQuery, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox7.Text = reader.GetString("UserId");
                textBox3.Text = reader.GetString("EnquiryType");
                textBox1.Text = reader.GetString("Description");

                dateTimePicker1.Value = reader.GetDateTime("EnquiryDate");



            }

            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    query = "update tblenquiry set AdminResponse='" + textBox4.Text + "' ,AdminStatus = '1" + "' where EnquiryNumber = '" + textBox2.Text + "' ";
                    fn.setData(query, "Responded Successfully.");
                    NewEnquiries_Load(this, null);
                    clear();

                }
                else
                {
                    MessageBox.Show("Enter the Enquiry Number.", "Warning !!", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();

            dateTimePicker1.Text = null;

        }
    }
}