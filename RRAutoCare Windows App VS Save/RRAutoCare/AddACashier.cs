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
    public partial class AddACashier : Form
    {
        functions fn = new functions();
        String query;

        public AddACashier()
        {
            InitializeComponent();
        }

        private void AddACashier_Load(object sender, EventArgs e)
        {
            query = "select ID, FullName, CashieruserName AS AgentUserName from tblcashiers";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCashiers adminCashiers = new AdminCashiers();
            adminCashiers.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( CUN.Text != "" && CPW.Text != "")
            {
                
                String FName = CFN.Text;
                String Password = CPW.Text;
                String Email = CE.Text;
                String Address = CA.Text;
                String Username= CUN.Text;
                int MNum = int.Parse(CM.Text);

                query = "insert into tblcashiers(FullName,MobileNumber,Email,Address,Password,CashieruserName) values ('" + FName + "','" + MNum + "','" + Email + "','" + Address + "','" +Password + "','" + Username + "');";
                fn.setData(query, "Agent Added Successfully.");
                AddACashier_Load(this, null);
                clear();

            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void clear() 
        {
            CPW.Clear();
            CUN.Clear();
            CE.Clear();
            CA.Clear();
            CFN.Clear();
            CM.Clear();
        }
    }
}
