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
    public partial class FORM_LOGIN : Form
    {
        public FORM_LOGIN()
        {
            InitializeComponent();

            this.textBoxPassword.AutoSize = false;
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Width, 50);
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string globalusername;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            globalusername = textBoxUsername.Text;
            DB db = new DB();

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (textBoxUsername.Text == "admin" && textBoxPassword.Text == "admin")
            {
                Program.username = textBoxUsername.Text;
                MessageBox.Show("Login Success", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FORM_EDIT_STOCK f = new FORM_EDIT_STOCK();
                f.ShowDialog();
            }

            else if (table.Rows.Count > 0)
            {
                Program.username = textBoxUsername.Text;
                MessageBox.Show("Login Success", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FORM_MAIN mainform = new FORM_MAIN();
                mainform.Show();
            }

            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Username Or Password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_NEW_ACCOUNT registerForm = new FORM_NEW_ACCOUNT();
            registerForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true; 
            }
        }

        #region MouseEnter
        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Yellow;
        }

        #endregion

        #region MouseLeave
        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.White;
        }

        #endregion

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ' '))
            {
                e.Handled = true;
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ' '))
            {
                e.Handled = true;
            }
        }
    }
}