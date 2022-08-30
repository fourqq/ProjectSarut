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
    public partial class FORM_FORGETPASS : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");

        public FORM_FORGETPASS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter your info", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                reset_pass();
            }
        }
        private void reset_pass()
        {
            string query = "SELECT * FROM users WHERE email ='" + textBox1.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (textBox2.TextLength < 6)
                    {
                        MessageBox.Show("Your password must have more than 5 character", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            string sql = $"UPDATE users SET password = \"{textBox3.Text}\" WHERE email = '" + textBox1.Text + "' ";
                            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datauser;");
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Your password has been changed.", "New Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Confirmation password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Wrong email Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_BACK_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_LOGIN login = new FORM_LOGIN();
            login.ShowDialog();
        }
    }
}
