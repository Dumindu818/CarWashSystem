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
    public partial class NewJobStep2 : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;
        public NewJobStep2()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            query = "update tblservicerequest set AdminStatus= NULL where ServiceNumber = '" + Trans.ServiceNumber + "' ";
            fn.setData(query, "Are You Sure.");

            this.Hide();
            CashierNewJob cashierNewJob = new CashierNewJob();
            cashierNewJob.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void NewJobStep2_Load(object sender, EventArgs e)
        {
            textBox8.Text = Trans.CashierID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "" && textBox12.Text != "")
            {
                try
                {
                    if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        query = "update tblservicerequest set ServiceBy = '" + textBox8.Text + "', AdminStatus = '3', ServiceCharge = '" + textBox9.Text + "', PartsCharge = '" + textBox10.Text + "', OtherCharge = '" + textBox11.Text + "' where ServiceNumber = '" + Trans.ServiceNumber + "' ;";
                        fn.setData(query, "Done.");
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Trans.ServiceNumber = 0;

            

           invoice.LblSBy = textBox8.Text.ToString();
            invoice.LblSC = textBox9.Text.ToString();
           invoice.LblPC = textBox10.Text.ToString();
            invoice.LblOC = textBox11.Text.ToString();
            invoice.LblTOT = textBox12.Text.ToString();


            this.Hide();
            recipt cash = new recipt();
            cash.ShowDialog();
            this.Close();

           

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            double sc, pc, oc, tot;
            
            sc = Convert.ToDouble(textBox9.Text);
            pc = Convert.ToDouble(textBox10.Text);
            oc = Convert.ToDouble(textBox11.Text);
            tot = sc + pc + oc;
            textBox12.Text = Convert.ToString(tot);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            query = "update tblservicerequest set AdminStatus= NULL where ServiceNumber = '" + Trans.ServiceNumber + "' ";
            fn.setData(query, "Are You Sure.");

            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


     

        bool flag = false;



 

        private void NewJobStep2_MouseDow(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void NewJobStep2_MouseMove_1(object sender, MouseEventArgs e)
        {
            //Check if Flag is True ??? if so then make form position same

            //as Cursor position

            if (flag == true)

            {

                this.Location = Cursor.Position;

            }
        }

        private void NewJobStep2_MouseUp_1(object sender, MouseEventArgs e)
        {
            flag = false;
        }
    }
}
