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
    public partial class recipt : Form
    {
        public recipt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashierDashboard cashier = new CashierDashboard();
            cashier.ShowDialog();
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);

            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(506, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y,0, 0, size);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void recipt_Load(object sender, EventArgs e)
        {
            lblSBy.Text = invoice.LblSBy;
            lblSC.Text = invoice.LblSC;
            lblPC.Text = invoice.LblPC;
            lblOC.Text = invoice.LblOC;
            lblTOT.Text = invoice.LblTOT;
            lblUserID.Text = invoice.LblUserID;

            lblServiceNumber.Text = invoice.LblServiceNumber;
            lblCategory.Text = invoice.LblCategory;
            lblVName.Text = invoice.LblVName;
            lblVModel.Text = invoice.LblVModel;
            lblVBrand.Text = invoice.LblVBrand;
            lblVRegno.Text = invoice.LblVRegno;
            lblDType.Text = invoice.LblDType;

            lblPAdd.Text = invoice.LblPAdd;
            lblDate.Text = invoice.LblDate;
            lblAR.Text = invoice.LblAR;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        bool flag = false;

        private void recipt_MouseDown(object sender, MouseEventArgs e)

        {

            flag = true;

        }

        private void recipt_MouseMove(object sender, MouseEventArgs e)

        {

            //Check if Flag is True ??? if so then make form position same

            //as Cursor position

            if (flag == true)

            {

                this.Location = Cursor.Position;

            }

        }

        private void recipt_MouseUp(object sender, MouseEventArgs e)

        {

            flag = false;

        }
    }
}
