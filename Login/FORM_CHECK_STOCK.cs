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
    public partial class FORM_CHECK_STOCK : Form
    {
        List<Bill> allbill = new List<Bill>();
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public FORM_CHECK_STOCK()
        {
            InitializeComponent();
            List<Bill> allbill = new List<Bill>();
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock  ";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView4.DataSource = ds.Tables[0].DefaultView;
        }

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

        private void button15_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stock WHERE name like \"%{textBox12.Text}%\" OR type like \"%{textBox12.Text}%\"";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView4.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView4.CurrentRow.Selected = true;
                int selectedRows = dataGridView4.CurrentCell.RowIndex;
                int editid = Convert.ToInt32(dataGridView4.Rows[selectedRows].Cells["id"].Value);
                textBoxName.Text = dataGridView4.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBoxPrice.Text = dataGridView4.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                textBoxAmount.Text = dataGridView4.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();
                cbbType.Text = dataGridView4.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();

                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT picture FROM stock WHERE id =\"{editid}\"", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["picture"]);
                    pictureBox6.Image = new Bitmap(ms);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void dataGridView4_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
        private void loaddata()//เอาค่าจากดาต้าเบสมาเก็บไว้
        {
            allbill.Clear();
            MySqlConnection conn = new MySqlConnection("host=127.0.0.1;username=root;password=;database=csharp_users;");

            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stock WHERE name like \"%{textBox12.Text}%\" OR type like \"%{textBox12.Text}%\"";

            MySqlDataReader adapter = cmd.ExecuteReader();

            while (adapter.Read())
            {
                Program.name_bill = adapter.GetString("name");
                Program.amount_bill = adapter.GetString("amount");
                Program.price_bill = adapter.GetString("price");

                Bill item = new Bill()
                {
                    name_bill = Program.name_bill,
                    amount_bill = Program.amount_bill,
                    price_bill = Program.price_bill,
                };
                allbill.Add(item);

            }
        }

        private void dataGridView4_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
