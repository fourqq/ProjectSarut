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
    public partial class FORM_EDIT_STOCK : Form
    {
        
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public FORM_EDIT_STOCK()
        {
            InitializeComponent();
            showstock();
        }

        private void labelLogOut_Click_1(object sender, EventArgs e)
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

        private void labelLogOut_MouseEnter_1(object sender, EventArgs e)
        {
            labelLogOut.ForeColor = Color.Orange;
        }

        private void labelLogOut_MouseLeave_1(object sender, EventArgs e)
        {
            labelLogOut.ForeColor = Color.DeepSkyBlue;
        }

        private void button5_Click(object sender, EventArgs e) //เพิ่มสินค้า
        {
            try
            {
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
                MySqlConnection conn = new MySqlConnection(connection);
                byte[] image = null;
                string filepath = label4.Text;
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);
                string sql = $" INSERT INTO stock (type,name,price,picture) VALUES(\"{cbbType.Text}\",\"{textBoxName.Text}\",\"{textBoxPrice.Text}\",@Imgg)";
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                    int x = cmd.ExecuteNonQuery();
                    conn.Close();
                    showstock();
                }
                MessageBox.Show("Your item alread added", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showstock()
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

        private void btnImge_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = new Bitmap(open.FileName);
                label4.Text = open.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e) //แก้ไขสินค้า
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRows = dataGridView1.CurrentCell.RowIndex;
                    int editid = Convert.ToInt32(dataGridView1.Rows[selectedRows].Cells["id"].Value);
                    MySqlConnection conn = databaseConnection();
                    byte[] image = null;
                    string filepath = label4.Text;
                    FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                    String sql = "UPDATE stock SET name = '" + textBoxName.Text + "',price = '" + textBoxPrice.Text + "',type = '" + cbbType.Text + "',picture= @imgg WHERE id = '" + editid + "'";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.Add(new MySqlParameter("@Imgg", image));
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {

                        MessageBox.Show("Your item edited", "Update item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showstock();
                    }
                }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button6_Click(object sender, EventArgs e) //ลบสินค้า
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRow = dataGridView1.CurrentCell.RowIndex;
                    int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
                    string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;";
                    MySqlConnection conn = new MySqlConnection(connection);
                    String sql = "DELETE FROM stock WHERE id = '" + deleteId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("Your item already deleted", "Delete item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        showstock();
                    }
                }                  
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
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
                cbbType.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();

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
                    pictureBox7.Image = new Bitmap(ms);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #region Change Form
        private void buttonCheckSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_CHECK_SALE sale = new FORM_CHECK_SALE();
            sale.ShowDialog();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_CHECK_PAYMENT payment = new FORM_CHECK_PAYMENT();
            payment.ShowDialog();
        }
        #endregion

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

        private void button2_Click(object sender, EventArgs e) //refresh
        {
            showstock();
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            cbbType.Text = "";
        }
    }
}
