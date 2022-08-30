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
    public partial class FORM_CAST : Form
    {      
         private MySqlConnection databaseConnection()
         {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
         }

        public FORM_CAST()
        {
            InitializeComponent();
        }

        private void BTN_BACK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FORM_PAY pay = new FORM_PAY();            
            pay.sum = price.Text;
            pay.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //ปุ่มลบสินค้า
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selecterow = dataGridView1.CurrentCell.RowIndex;
                var deleteId = dataGridView1.Rows[selecterow].Cells["name"].Value;

                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
                string sql = "DELETE FROM equipment WHERE name = '" + deleteId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();


                if (MessageBox.Show("Your Want To Delete?", "WARING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (rows > 0)
                    {

                        MessageBox.Show("Deleted Your Order", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
                        DataSet ds = new DataSet();
                        conn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("SELECT name,amount,price FROM equipment WHERE status  = '" + "In cart" + "' AND username ='" + FORM_LOGIN.globalusername + "'", conn);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                        adapter.Fill(ds);
                        MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM equipment WHERE status = '" + "In cart" + "'", conn);
                        MySqlDataReader adapter1 = cmd3.ExecuteReader();
                        while (adapter1.Read())
                        {
                            Program.sum = Program.sum + int.Parse(adapter1.GetString("price")); //เก็บค่า price จาก db มาบวกลงใน sum
                        }
                        price.Text = Program.sum.ToString();
                        conn.Close();
                        MySqlConnection conn3 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;

                        FORM_CAST cast = new FORM_CAST();
                        cast.ShowDialog();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showpay() //showสินค้าที่เลือก
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT name,amount,price FROM equipment WHERE status='" + "In cart" + "'AND username='" + FORM_LOGIN.globalusername + "'", conn); 
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private DataTable maindatatable;
        private void FORM_CAST_Load(object sender, EventArgs e) //โชว์สินค้าที่เลือก
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM equipment WHERE status='" + "In cart" + "'AND username ='" + FORM_LOGIN.globalusername + "'", conn);
            MySqlDataReader adapter = cmd.ExecuteReader();
            Program.sum = 0; //ตั้งตัวแปร sum
            while (adapter.Read())
            {
                Program.sum = Program.sum + int.Parse(adapter.GetString("price")); //บวกราคาแบบ loop
            }

            price.Text = Program.sum.ToString(); //แปลงค่า sum และแสดงใน label
            conn.Close();

            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM users WHERE username = '"+ FORM_LOGIN.globalusername +"'",conn);
            DataTable dt = new DataTable();
            new MySqlDataAdapter(cmd).Fill(dt);
            maindatatable = dt;
            textBox1.Text = dt.Rows[0][5].ToString();
            conn.Close();
            showpay();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selecterow = dataGridView1.CurrentCell.RowIndex;
                var productname = dataGridView1.Rows[selecterow].Cells["name"].Value;
                var textBox = dataGridView1.Rows[selecterow].Cells["amount"].Value;
                productname = Convert.ToString(productname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void button2_Click(object sender, EventArgs e) //คอนเฟิร์มที่อยู่
        {
            MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            string sql = "UPDATE users SET address = '" + textBox1.Text + "' WHERE username = '" + FORM_LOGIN.globalusername + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("ARE YOUR SURE?", "WARNING", MessageBoxButtons.YesNo);
            }
            else
            {

            }
        }
        /*
        private DataTable dataTable = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataTable ds = new DataTable();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"UPDATE users SET address = '{textBox1.Text}' WHERE address = '{dataTable.Rows[0]["address"]}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            if (ds.Rows.Count >= 0)
            {
            MessageBox.Show("Change Already!");
            }
        }
            private string usernameC;
        */
    }
}