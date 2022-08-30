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


namespace Login
{
    public partial class FORM_PRINT : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");

        public string usernametext8;
        public FORM_PRINT()
        {
            InitializeComponent();
        }

        private void FORM_PRINT_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT name,amount,price,date,status,username,address FROM equipment WHERE username='" + usernametext8 + "'", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridViewStatus.DataSource = ds.Tables[0].DefaultView;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("RECEIPT", new Font("Courier New", 20), new SolidBrush(Color.Black), 350, 50);
            e.Graphics.DrawString("Fourqq SHOP", new Font("Courier New", 20), new SolidBrush(Color.Black), 300, 90);
            e.Graphics.DrawString("สั่งซื้อเมื่อวันที่ " + date.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), 560, 180);
            e.Graphics.DrawString("บริษัท Fourqq จำกัด", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 180);
            e.Graphics.DrawString("Khon Khane University", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 200);
            e.Graphics.DrawString("อ.เมือง จ.ขอนแก่น", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 220);
            e.Graphics.DrawString("44444  โทร.0844444444", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 240);
            e.Graphics.DrawString("---------------------------------------------------------", new Font("Courier New", 14), new SolidBrush(Color.Black), 35, 320);
            e.Graphics.DrawString(" ลำดับ            ชื่อสินค้า               จำนวน     ราคา (บาท)", new Font("Courier New", 14), new SolidBrush(Color.Black), 35, 340);
            e.Graphics.DrawString("---------------------------------------------------------", new Font("Courier New", 14), new SolidBrush(Color.Black), 35, 360);
            e.Graphics.DrawString("1", new Font("Courier New", 10), new SolidBrush(Color.Black), 50, 380);
            e.Graphics.DrawString(name.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), 140, 380);
            e.Graphics.DrawString(amount.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), 500, 380);
            e.Graphics.DrawString(price.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), 600, 380);
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 600);
            e.Graphics.DrawString("รวมทั้งสิ้น " + price.Text, new Font("Courier New", 14), new SolidBrush(Color.Black), 520, 620);
            e.Graphics.DrawString("-----------------------------------------------------------------------------", new Font("Courier New", 10), new SolidBrush(Color.Black), 35, 640);
            e.Graphics.DrawString("พิมพ์เมื่อ " + System.DateTime.Now.ToString("dd/MM/yyyy HH : mm : ss น."), new Font("Courier New", 14), new SolidBrush(Color.Black), 50, 660);
            e.Graphics.DrawString("ขอบคุณที่ใช้บริการ", new Font("Courier New", 14), new SolidBrush(Color.Black), 330, 800);
        }

        private void dataGridViewStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewStatus.CurrentRow.Selected = true;
                int selecterow = dataGridViewStatus.CurrentCell.RowIndex;
                var textBox1 = dataGridViewStatus.Rows[selecterow].Cells["name"].Value;
                var textBox2 = dataGridViewStatus.Rows[selecterow].Cells["amount"].Value;
                var textBox3 = dataGridViewStatus.Rows[selecterow].Cells["price"].Value;
                var textBox4 = dataGridViewStatus.Rows[selecterow].Cells["date"].Value;

                name.Text = textBox1.ToString();
                amount.Text = textBox2.ToString();
                price.Text = textBox3.ToString();
                date.Text = textBox4.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
