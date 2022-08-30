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
    public partial class FORM_CHECK_PAYMENT : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public FORM_CHECK_PAYMENT()
        {
            InitializeComponent();
        }

        #region change form

        private void buttonEditStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_EDIT_STOCK edit = new FORM_EDIT_STOCK();
            edit.ShowDialog();
        }

        private void buttonCheckSale_Click(object sender, EventArgs e)
        {        
            this.Hide();
            FORM_CHECK_SALE sale = new FORM_CHECK_SALE();
            sale.ShowDialog();
        }

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

        #endregion

        private DataTable dataTable = new DataTable(); //เก็บข้อมูล
        private void loadpayment() //โชว์สินค้าที่จ่ายเงินแล้ว
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM equipment WHERE status != '" + "In cart" + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void FORM_CHECK_PAYMENT_Load(object sender, EventArgs e)
        {
            loadpayment();
        }

        private void button10_Click(object sender, EventArgs e) //แก้ status
        {
            try
            {
                dataGridView1.CurrentRow.Selected = true;
                int selectedRows = dataGridView1.CurrentCell.RowIndex;
                int editid = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);
                MySqlConnection conn = databaseConnection();

                String sql = "UPDATE equipment SET status = '" + comboBox1.Text + "'WHERE id = '" + editid + "'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("Your item edited", "Update item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadpayment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            int selectedRows = dataGridView1.CurrentCell.RowIndex;
            int editid = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["date"].FormattedValue.ToString();

            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT slip FROM equipment WHERE id = \"{editid}\"", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();

            //show slip
            MySqlConnection conn1 = new MySqlConnection(connection);
            conn1.Open();
            MySqlCommand cmd1 = new MySqlCommand($"SELECT slip FROM equipment WHERE id =\"{editid}\"", conn1);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["slip"]);
                pictureBox5.Image = new Bitmap(ms);
            }
        }
    }
}