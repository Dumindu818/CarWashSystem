using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RRAutoCare
{

    public partial class CashierNewJob : Form
    {
        functions fn = new functions();
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb");
        String query;
        MySqlCommand command;

        MySqlDataReader reader;

        
        MySqlDataAdapter adapter;
        DataTable table = new DataTable();
        public CashierNewJob()
        {
            InitializeComponent();
        }

        private void EmployeeNewJob_Load(object sender, EventArgs e)
        {

            invoice.LblUserID = textBox2.Text.ToString();
            invoice.LblServiceNumber = Trans.ServiceNumber.ToString();
            invoice.LblCategory = comboBox1.Text.ToString();
            invoice.LblVName = textBox3.Text.ToString();
            invoice.LblVModel = textBox4.Text.ToString();
            invoice.LblVBrand = textBox5.Text.ToString();
            invoice.LblVRegno = textBox6.Text.ToString();
            invoice.LblDType = Dtype;
            invoice.LblPAdd = textBox7.Text.ToString();
            invoice.LblAR = textBox9.Text.ToString();

            if(Trans.ServiceNumber == 0)
            {
                textBox2.Hide();
                label2.Hide();
                button1.Hide();
            }

            try
            {
                radioButton1.Checked = true;

                adapter = new MySqlDataAdapter("SELECT * FROM tblcategory", connection);
                adapter.Fill(table);
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "VehicleCat";
                comboBox1.ValueMember = "VehicleCat";

                if (Trans.ServiceNumber != 0)
                {
                    connection.Open();
                    string selectQuery = "Select * from tblservicerequest where ServiceNumber = '" + Trans.ServiceNumber + " ' ";
                    command = new MySqlCommand(selectQuery, connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox2.Text = reader.GetString("UserId");
                        comboBox1.Text = reader.GetString("Category");
                        textBox3.Text = reader.GetString("VehicleName");
                        textBox4.Text = reader.GetString("VehicleModel");
                        textBox5.Text = reader.GetString("VehicleBrand");
                        textBox6.Text = reader.GetString("VehicleRegno");


                        dateTimePicker1.Text = reader.GetString("ServiceDate");
                        dateTimePicker2.Text = reader.GetString("ServiceTime");

                        if (reader.GetString("DeliveryType") == "pickupservice")
                        {
                            radioButton1.Checked = true;
                            radioButton2.Checked = false;
                        }
                        else if (reader.GetString("DeliveryType") == "dropservice")
                        {
                            radioButton1.Checked = false;
                            radioButton2.Checked = true;

                        }


                        textBox7.Text = reader.GetString("PickupAddress");

                    }
                    connection.Close();

                }
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Trans.ServiceNumber == 0)
            {
                this.Hide();
                CashierDashboard cashierDashboard = new CashierDashboard();
                cashierDashboard.ShowDialog();
                this.Close();
            }
            else
            {
                query = "update tblservicerequest set AdminStatus= NULL where ServiceNumber = '" + Trans.ServiceNumber + "' ";
                fn.setData(query, "Are You Sure.");
                Trans.ServiceNumber = 0;
                this.Hide();
                CashierWebBookings cashierDashboard = new CashierWebBookings();
                cashierDashboard.ShowDialog();
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        String Dtype;

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                invoice.LblUserID = textBox2.Text.ToString();
                invoice.LblServiceNumber = Trans.ServiceNumber.ToString();
                invoice.LblCategory = comboBox1.Text.ToString();
                invoice.LblVName = textBox3.Text.ToString();
                invoice.LblVModel = textBox4.Text.ToString();
                invoice.LblVBrand = textBox5.Text.ToString();
                invoice.LblVRegno = textBox6.Text.ToString();
              //invoice.LblDType = Dtype;
                invoice.LblPAdd = textBox7.Text.ToString();
                invoice.LblAR = textBox9.Text.ToString();
                Random random = new Random();

                if (Trans.ServiceNumber == 0)
                {

                    textBox2.Text = "0";
                    Trans.ServiceNumber = random.Next(100000000, 999999999);

                    try
                    {
                        if (comboBox1.Text != ""  && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""  && textBox9.Text != "" && dateTimePicker2.Text != "" && dateTimePicker1.Value != null && (radioButton1.Checked == true || radioButton2.Checked == true))
                        {
                            int U_id = int.Parse(textBox2.Text);
                            string Category = comboBox1.Text;
                            string VName = textBox3.Text;
                            string VModel = textBox4.Text;
                            string VBrand = textBox5.Text;
                            string VRegno = textBox6.Text;

                            string SerDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
                            string SerTime = Convert.ToDateTime(dateTimePicker2.Text).ToString("HH:mm");
                            string PA;
                             PA = textBox7.Text;
                            string AR = textBox9.Text;


                            if (radioButton1.Checked == true)
                            {
                                Dtype = "pickupservice";
                            }
                            else if (radioButton2.Checked == true)
                            {
                                Dtype = "dropservice";
                            }
                            //invoice.LblDType = Dtype;
                            //Random random = new Random();
                            //Trans.ServiceNumber = random.Next(100000000, 999999999);

                            if (PA != "")
                            {
                                query = "insert into tblservicerequest(UserId,ServiceNumber, PickupAddress, AdminRemark ,DeliveryType, ServiceDate, ServiceTime , Category,VehicleName,VehicleModel,VehicleBrand,VehicleRegno) values ('" +
                               U_id + "','" + Trans.ServiceNumber + "','" + PA + "','" + AR + "','" + Dtype + "','" + SerDate + "','" + SerTime + "','" + Category + "','" + VName + "','" + VModel + "','" + VBrand + "','" + VRegno + "');";
                                fn.setData(query, "Request Proceeded.");
                            }
                            else
                            {
                                query = "insert into tblservicerequest(UserId,ServiceNumber, AdminRemark ,DeliveryType, ServiceDate, ServiceTime , Category,VehicleName,VehicleModel,VehicleBrand,VehicleRegno) values ('" +
                               U_id + "','" + Trans.ServiceNumber  + "','" + AR + "','" + Dtype + "','" + SerDate + "','" + SerTime + "','" + Category + "','" + VName + "','" + VModel + "','" + VBrand + "','" + VRegno + "');";
                                fn.setData(query, "Request Proceeded.");
                            }
                            invoice.LblUserID = textBox2.Text.ToString();
                            invoice.LblServiceNumber = Trans.ServiceNumber.ToString();
                            invoice.LblCategory = comboBox1.Text.ToString();
                            invoice.LblVName = textBox3.Text.ToString();
                            invoice.LblVModel = textBox4.Text.ToString();
                            invoice.LblVBrand = textBox5.Text.ToString();
                            invoice.LblVRegno = textBox6.Text.ToString();
                            invoice.LblDType = Dtype.ToString();
                            invoice.LblPAdd = textBox7.Text.ToString();
                            invoice.LblAR = textBox9.Text.ToString();


                        }
                        else
                        {
                            MessageBox.Show("Fill the Important Fields.", "Warning !!", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        if (textBox9.Text != "")
                        {

                            if (MessageBox.Show("Are You Sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                query = "update tblservicerequest set AdminRemark = '" + textBox9.Text + "' where ServiceNumber = '" + Trans.ServiceNumber + "' ";
                                fn.setData(query, "Done.");

                                

                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    }
                invoice.LblUserID = textBox2.Text.ToString();
                invoice.LblServiceNumber = Trans.ServiceNumber.ToString();
                invoice.LblCategory = comboBox1.Text.ToString();
                invoice.LblVName = textBox3.Text.ToString();
                invoice.LblVModel = textBox4.Text.ToString();
                invoice.LblVBrand = textBox5.Text.ToString();
                invoice.LblVRegno = textBox6.Text.ToString();
 


                if (textBox7.Text != "")
                {
                    invoice.LblPAdd = textBox7.Text.ToString();
                }
                invoice.LblAR = textBox9.Text.ToString();

                invoice.LblDate = DateTime.Now.ToString("yyyy-MM-dd");

                
                this.Hide();
                NewJobStep2 newJobStep2 = new NewJobStep2();
                newJobStep2.ShowDialog();
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            query = "update tblservicerequest set AdminStatus= '2' where ServiceNumber = '" + Trans.ServiceNumber + "' ";
            fn.setData(query, "Are You Sure.");
            Trans.ServiceNumber = 0;
            this.Hide();
            CashierWebBookings newJobStep2 = new CashierWebBookings();
            newJobStep2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            query = "update tblservicerequest set AdminStatus= NULL where ServiceNumber = '" + Trans.ServiceNumber + "' ";
            fn.setData(query, "Are You Sure.");

            Application.Exit();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker2.CustomFormat = "HH:mm";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        bool flag = false;
        private void CashierNewJob_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
        }

        private void CashierNewJob_MouseMove(object sender, MouseEventArgs e)
        {
            //Check if Flag is True ??? if so then make form position same

            //as Cursor position

            if (flag == true)

            {

                this.Location = Cursor.Position;

            }
        }

        private void CashierNewJob_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
    }
}
