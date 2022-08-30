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
using System.IO;

namespace Login
{
    public partial class FORM_PAY : Form
    {
        public string usernametext5;
        public string address1;
        public string sum;
        public string path;
        public string timeslip;

        public FORM_PAY()
        {
            InitializeComponent();
        }

        private void FORM_PAY_Load(object sender, EventArgs e)
        {
            label7.Text = sum;
            label8.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(open.FileName);
                label11.Text = open.FileName;

            }
        }

        private void insertslip() //เพิ่มรูป
        {
            try
            {
                string timeslip = comboBox1.Text + comboBox2.Text + comboBox3.Text;
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
                MySqlConnection conn = new MySqlConnection(connection);
                byte[] image = null;
                //pictureBox3.ImageLocation = textLocation.Text;
                string filepath = label11.Text;
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);
                string sql = $"UPDATE equipment SET total ={label7.Text}, address='{address1}', status='Pending', time='{timeslip}',slip =@Imgg WHERE status = 'In cart' AND total =0";

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                    int x = cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thank you for ordering with us", "Sending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //ส่งข้อมูลเข้าดาต้า
        {

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || pictureBox4.Image == null)
            {
                MessageBox.Show("Please enter the time correctly", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (pictureBox4.Image != null)
            {
                insertslip();

                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                
            }       
        }

        private void BTN_BACK_Click(object sender, EventArgs e)
        {
            this.Close();
            FORM_CAST cast = new FORM_CAST();
            cast.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet ds_ = new DataSet();
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            MySqlCommand cmd = conn.CreateCommand();
            MySqlCommand cmd_ = conn.CreateCommand();
            conn.Open();
            //cmd.CommandText = "SELECT * FROM equipment WHERE username='" + FORM_LOGIN.globalusername + "'";
            cmd_.CommandText = "SELECT * FROM users WHERE username='" + FORM_LOGIN.globalusername + "'";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            var cmd1 = new MySqlCommand("SELECT * FROM equipment WHERE username='" + FORM_LOGIN.globalusername + "'",conn);
            new MySqlDataAdapter(cmd1).Fill(dt1);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            conn.Close();
            //MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            MySqlDataAdapter adapter_ = new MySqlDataAdapter(cmd_);
            //adapter.Fill(ds);
            adapter_.Fill(ds_);

            conn.Close();
            //var a = ds.Tables[0].Rows[0].ItemArray.ToList();
            var b = ds_.Tables[0].Rows[0].ItemArray.ToList();
            conn.Close();

            e.Graphics.DrawString("FOURQQ SHOP", new Font("Angsana New", 40, FontStyle.Bold), Brushes.Black, new Point(270, 70));
            e.Graphics.DrawString("Address : " + b[5], new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(80, 220));
            e.Graphics.DrawString("Time : " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss น."), new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(80, 250));
            e.Graphics.DrawString("Email : " + b[3], new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(80, 280));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new Point(60, 390));
            e.Graphics.DrawString("Product                   Team                  Size        Amount         Price                                    ", new Font("Angsana New", 26, FontStyle.Bold), Brushes.Black, new Point(90, 410));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new Point(60, 435));

            int sumprice = 0;
            int y = 460;
            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                e.Graphics.DrawString("username : " + dt1.Rows[i][8], new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(80, 190));
                e.Graphics.DrawString(dt1.Rows[i][5] + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(80, y));
                e.Graphics.DrawString(dt1.Rows[i][1] + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(250, y));
                e.Graphics.DrawString(dt1.Rows[i][3] + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(475, y));
                e.Graphics.DrawString(dt1.Rows[i][2] + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(591, y));
                e.Graphics.DrawString(dt1.Rows[i][4] + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(695, y));
                sumprice = sumprice+Convert.ToInt32(dt1.Rows[i][4]);             
                y += 40;
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new Point(60, y));
            e.Graphics.DrawString("Total : ", new Font("Angsana New", 20, FontStyle.Bold), Brushes.Black, new PointF(625, y+25));
            e.Graphics.DrawString(sumprice + "", new Font("Angsana New", 20, FontStyle.Regular), Brushes.Black, new PointF(688, y+25));
            e.Graphics.DrawString("บาท", new Font("Angsana New", 20, FontStyle.Bold), Brushes.Black, new PointF(750, y+25));
            e.Graphics.DrawString("**Thank You For Shopping With Us** ", new Font("Angsana New", 20, FontStyle.Bold), Brushes.Black, new PointF(250, y+150));
            e.Graphics.DrawString("Contact Us : 0874323996 ", new Font("Angsana New", 20, FontStyle.Bold), Brushes.Black, new PointF(300, y+200));

        }
    }
}