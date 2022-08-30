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
    public partial class FORM_CHECK_SALE : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users; ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public FORM_CHECK_SALE()
        {
            InitializeComponent();
            dateTimePicker1.Value = System.DateTime.Now;
        }

        #region Change Form
        private void buttonEditStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_EDIT_STOCK edit = new FORM_EDIT_STOCK();
            edit.ShowDialog();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_CHECK_PAYMENT payment = new FORM_CHECK_PAYMENT();
            payment.ShowDialog();
        }
        #endregion

        private void labelLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                this.Hide();
                FORM_LOGIN login = new FORM_LOGIN();
                login.Show();
            }

            else
            {

            }
        }

        private void loadsale() //โชว์สินค้าที่เลือก
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT name,amount,price,date,status,username,time FROM equipment WHERE status != '" + "In cart" + "'AND status != '" + "Pending" + "'AND status != '" + "ERROR" + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void FORM_CHECK_SALE_Load(object sender, EventArgs e)
        {
            loadsale();
            dateTimePicker1.Value = System.DateTime.Now;
        }

        int total;
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MySqlConnection conn = databaseConnection();

                DataSet ds = new DataSet();

                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT * FROM equipment WHERE status != \"Pending\" AND date between @date1 AND @date2  ";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("MM/dd/yyyy"));

                da.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                total = 0; 
                conn.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    total = total + int.Parse(read.GetString("price"));
                }
                salesamount.Text = $"{total}";
                conn.Close();
            }
            else
            {
                MySqlConnection conn = databaseConnection();

                DataSet ds = new DataSet();

                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM equipment WHERE username = '"+ textBox1.Text + "' AND date between @date1 AND @date2 ";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@date1", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@date2", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                
                da.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                total = 0; 
                conn.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    total = total + int.Parse(read.GetString("price"));
                }
                salesamount.Text = $"{total}"; 
                conn.Close();
            }
        }

        int sum;
        private void sumsale() //total sales
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT price FROM equipment WHERE status != \"Pending\" ";
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                int price = read.GetInt32("price"); //total price
                sum = sum + price;
            }
            conn.Close();
            salesamount.Text = Convert.ToString(sum);
        }

        private DataTable dataTable = new DataTable();
        public static string usernameC;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usernameC = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
            MySqlConnection conn1 = databaseConnection();
            DataTable ds1 = new DataTable();
            conn1.Open();
            MySqlCommand cmd1;
            cmd1 = conn1.CreateCommand();
            cmd1.CommandText = $"SELECT address FROM users WHERE username = '{usernameC}'";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            adapter1.Fill(ds1);
            dataTable = ds1;
            conn1.Close();

            label4.Text = ds1.Rows[0]["address"].ToString();
        }

    }
}