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
    public partial class FORM_MAIN : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users; ";
            MySqlConnection conn = new MySqlConnection(connectionSting);
            return conn;
        }

        public FORM_MAIN()
        {
            InitializeComponent();
        }

        private void FORM_MAIN_Load(object sender, EventArgs e)
        {
            label4.Text = FORM_LOGIN.globalusername;
            showstock();
        }

        private void labelLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Close();
                FORM_LOGIN login = new FORM_LOGIN();
                login.ShowDialog();
            }
            else
            {

            }
        }
        /*
        private void showname() //โชว์ชื่อลูกค้า
        {
            String name1 = label4.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users; ";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT address FROM users WHERE username =\"{name1}\"";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                addresstext = dr.GetValue(0).ToString();
            }
        }
        */

        private void showstock() //โชว์สินค้า
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selectedRows = dataGridView1.CurrentCell.RowIndex;
                int editid = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);
                textBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBoxPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                textBoxType.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();

                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users; ";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM stock WHERE id =\"{editid}\"", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picture"]);
                    pictureBox2.Image = new Bitmap(ms);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e) //เพิ่มสินค้า
        {          
            try
            {
                if (textBoxQuantity.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER YOUR QUANTITY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER YOUR SIZE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBoxQuantity.Text == "0")
                    {
                        MessageBox.Show("PLEASE ENTER CORRECT QUANTITY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        MySqlConnection conn2 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
                        MySqlCommand cmd2 = conn2.CreateCommand();
                        conn2.Open();
                        cmd2.CommandText = "SELECT name,price FROM stock ";
                        MySqlDataReader dr = cmd2.ExecuteReader();
                        dr.Read();

                        double money = 0;
                        int pr = int.Parse(textBoxPrice.Text);
                        int qty = int.Parse(textBoxQuantity.Text);
                        money = qty * pr;

                        string date = DateTime.Now.ToString("MM/dd/yyyy");                     
                        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
                        String sql = "INSERT INTO equipment (name,amount,size,price,type,date,status,username,slip) VALUES('" + textBoxName.Text + "','" + textBoxQuantity.Text + "','" + comboBox1.Text + "', '" + money + "','" + textBoxType.Text + "','" + date + "','" + "In cart" + "','" + FORM_LOGIN.globalusername + "','" + "-" + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Item Already Added To Your Cart Successfully", "Item Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showstock();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e) //ไปหน้าจ่ายเงิน
        {
            //showname();
            FORM_CAST payment = new FORM_CAST();
            payment.ShowDialog();
            
        }

        //search
        private void button3_Click(object sender, EventArgs e) //ค้นหา
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();

            if (comboBox2.Text == "")
            {
                cmd.CommandText = "SELECT * FROM stock ";
            }
            else
            {
                cmd.CommandText = $"SELECT * FROM stock WHERE name like \"%{comboBox2.Text}%\" ";
            }
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showstock();
            comboBox2.Text = "";
        }
    }
}