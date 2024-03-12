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
    public partial class UpdateACashier : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public UpdateACashier()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCashiers adminCashiers = new AdminCashiers();
            adminCashiers.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {

                        query = "update tblcashiers set CashieruserName='" + CUN.Text + "' ,FullName = '" + CFN.Text + "' ,Email = '" + CE.Text + "' ,Address = '" + CA.Text + "' ,MobileNumber = '" + CM.Text + "' ,Password = '" + CPW.Text + "' where ID = '" + textBox2.Text +"' ";
                        fn.setData(query, "Updated Successfully.");
                        UpdateACashier_Load(this, null);
                        clearAll();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Agent Selected.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            textBox2.Clear();
            CUN.Clear();
            CFN.Clear();
            CA.Clear();
            CE.Clear();
            CM.Clear();
            CPW.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectQuery = "Select * from tblcashiers where ID = '" + textBox2.Text + " ' ";
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

        private void UpdateACashier_Load(object sender, EventArgs e)
        {
            query = "select ID, FullName, CashieruserName AS AgentUserName from tblcashiers";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
                if (MessageBox.Show("are you sure?", "Confirmation...!",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from tblcashiers where ID=" + textBox2.Text + "";
                    fn.setData(query, "Agent Deleted.");
                    UpdateACashier_Load(this, null);
                   
                }
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
