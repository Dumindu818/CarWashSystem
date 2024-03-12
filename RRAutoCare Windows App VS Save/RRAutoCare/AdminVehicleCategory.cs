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
    
    public partial class AdminVehicleCategory : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public AdminVehicleCategory()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminVehicleCategory_Load(object sender, EventArgs e)
        {
            query = "select * from tblcategory";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox3.Text = row.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" )
            {

                String category = textBox2.Text;
              

                query = "insert into tblcategory(VehicleCat) values ('" + category  + "');";
                fn.setData(query, "Category Added Successfully.");
                AdminVehicleCategory_Load(this, null);
                textBox2.Clear();

            }
            else
            {
                MessageBox.Show("Fill The Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                try
                {
                    if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {

                        query = "update tblcategory set VehicleCat='" + textBox1.Text  + "' where ID = '" + textBox3.Text + "' ";
                        fn.setData(query, "Updated Successfully.");
                        AdminVehicleCategory_Load(this, null);
                        textBox1.Clear();
                        textBox3.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Category is Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "Select * from tblcategory where ID = '" + textBox3.Text + " ' ";
            command = new MySqlCommand(selectQuery, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader.GetString("VehicleCat");
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    if (MessageBox.Show("are you sure?", "Confirmation...!",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        query = "delete from tblcategory where ID=" + textBox3.Text + "";
                        fn.setData(query, "Category Deleted.");
                        AdminVehicleCategory_Load(this, null);

                    }

                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message);}
            }
        }
    }
}
