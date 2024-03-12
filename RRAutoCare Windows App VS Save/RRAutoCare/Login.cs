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
    public partial class Login : Form
    {
        functions fn = new functions();
        String query;
        public Login()
        {
            InitializeComponent();
        }

        private void EmployeeLogin_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeLogin_Load_1(object sender, EventArgs e)
        {
            if (Trans.Loginc == true)
            {
                label1.Text = "Welcome Admin!";
            }
            else if(Trans.Loginc == false)
            {
                label1.Text = "Welcome Agent!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                if (Trans.Loginc == true)
                {
                    query = "select AdminuserName , Password from tbladmin where AdminuserName ='" + textBox2.Text + "'and Password ='" + textBox3.Text + "'";
                    DataSet ds = fn.getData(query);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Trans.AdminID = textBox2.Text;
                        this.Hide();
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.ShowDialog();
                        this.Close();
                    }
                    else
                    {

                        if (MessageBox.Show("Password is Incorect, Try Again", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            textBox3.Clear();
                        }
                    }
                }
                
                else if (Trans.Loginc == false)
                {
                    query = "select CashieruserName , Password from tblcashiers where CashieruserName ='" + textBox2.Text + "'and Password ='" + textBox3.Text + "'";
                    DataSet ds = fn.getData(query);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Trans.CashierID = textBox2.Text;    
                        this.Hide();
                        CashierDashboard cashierDashboard = new CashierDashboard();
                        cashierDashboard.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        if (MessageBox.Show("Password is Incorect, Try Again", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            textBox3.Clear();
                        }
                    }
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
            Opening opening = new Opening();
            opening.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
