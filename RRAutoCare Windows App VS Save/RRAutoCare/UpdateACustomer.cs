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
    public partial class UpdateACustomer : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public UpdateACustomer()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void UpdateACustomer_Load(object sender, EventArgs e)
        {
            query = "select ID,FullName, MobileNo, Email, RegDate from tbluser";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customers = new Customers();
            customers.ShowDialog();
            this.Close();

        }
        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox2.Text = row.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (MessageBox.Show("are you sure?", "Confirmation...!",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from tbluser where ID=" + textBox2.Text + "";
                    fn.setData(query, "Customer Deleted.");
                    UpdateACustomer_Load(this, null);

                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {

                MessageBox.Show("Search The User ID First");
            }
            else
            {
                connection.Open();
                string selectQuery = "Select * from tbluser where ID = " + int.Parse(textBox2.Text);
                command = new MySqlCommand(selectQuery, connection);
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    textBox3.Text = reader.GetString("FullName");
                    textBox7.Text = reader.GetString("Email");
                    textBox1.Text = reader.GetString("MobileNo");
                    dateTimePicker1.Text = reader.GetString("RegDate");
                }
                else
                {


                    MessageBox.Show("No Data For this ID");
                }
                connection.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string RegDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd HH:mm:ss");
            if (textBox2.Text != "")
            {
                try
                {
                    if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {

                        query = "update tbluser set FullName='" + textBox3.Text  + "' ,Email = '" + textBox7.Text  + "' ,MobileNo = '" + textBox1.Text + "' ,RegDate = '" + RegDate + "' where ID = '" + textBox2.Text + "' ";
                        fn.setData(query, " Updated Successfully.");
                        UpdateACustomer_Load(this, null);
                        clearAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            textBox2.Clear();
            textBox1.Clear();
            textBox7.Clear();
            textBox3.Clear();
            dateTimePicker1.Text = null;

        }
    }
}
