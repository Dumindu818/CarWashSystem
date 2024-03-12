using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;



    namespace RRAutoCare
    {
        internal class functions
        {
            protected MySqlConnection Connection()
            {

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=vsmsdb";
                return con;

            }

            public DataSet getData(String query) //Get Data from database
            {
                MySqlConnection con = Connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            public void setData(String query, String message) //Insertion Updation Deletion
            {
                MySqlConnection con = Connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" '" + message + "' ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public MySqlDataReader getForCombo(String query)
            {
                MySqlConnection con = Connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd = new MySqlCommand(query, con);
                MySqlDataReader sdr = cmd.ExecuteReader();
                return sdr;

            }
        }
    }
   



