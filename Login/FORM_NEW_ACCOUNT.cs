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
    public partial class FORM_NEW_ACCOUNT : Form
    {
        public FORM_NEW_ACCOUNT()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            
        }

        #region enter
        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.Black;
            }
        }

        private void textBoxLastname_Enter(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                textBoxLastname.Text = "";
                textBoxLastname.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            String phone = textBoxPhone.Text;
            if (phone.ToLower().Trim().Equals("phone"))
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = Color.Black;
            }
        }
        private void textBoxAddress_Enter(object sender, EventArgs e)
        {
            String address = textBoxAddress.Text;
            if (address.ToLower().Trim().Equals("address"))
            {
                textBoxAddress.Text = "";
                textBoxAddress.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username (letters and numbers)"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.Black;
            }
        }
        #endregion

        #region leave
        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "first name";
                textBoxFirstname.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                textBoxLastname.Text = "last name";
                textBoxLastname.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "email";
                textBoxEmail.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            String phone = textBoxPhone.Text;
            if (phone.ToLower().Trim().Equals("phone") || phone.Trim().Equals(""))
            {
                textBoxPhone.Text = "phone";
                textBoxPhone.ForeColor = Color.DarkGray;
            }
        }
        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            String address = textBoxAddress.Text;
            if (address.ToLower().Trim().Equals("address") || address.Trim().Equals(""))
            {
                textBoxAddress.Text = "address";
                textBoxAddress.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("username (letters and numbers)") || username.Trim().Equals(""))
            {
                textBoxUsername.Text = "username (letters and numbers)";
                textBoxUsername.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") ||
                cpassword.ToLower().Trim().Equals("password") ||
                cpassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "confirm password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        #region labelClick
        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_LOGIN loginform = new FORM_LOGIN();
            loginform.Show();
        }
        #endregion

        #region MouseEnter
        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelGoToLogin_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.Yellow;
        }
        #endregion

        #region MouseLeave
        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;

        }

        private void labelGoToLogin_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogin.ForeColor = Color.White;
        }
        #endregion


        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            //add user
            string email = textBoxEmail.Text + comboBox1.Text;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO users (firstname, lastname, email, phone, address, username, password, status) VALUES (@fn, @ln, @email, @phone, @address,@usn, @pass, @st)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = textBoxPhone.Text;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = textBoxAddress.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = "user";

            db.openConnection();

            if (textBoxFirstname.Text == "" || textBoxLastname.Text == "" || textBoxEmail.Text == "" || comboBox1.Text == "" || textBoxAddress.Text == "" || textBoxUsername.Text == "" || textBoxPassword.Text == "" || textBoxPasswordConfirm.Text == "" || textBoxEmail.Text == "" || textBoxPhone.Text == "")
            {
                MessageBox.Show("Please enter your info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBoxPhone.TextLength < 10)
            {                
                MessageBox.Show("Please enter correct phone number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter your email address", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBoxPassword.TextLength < 8)
            {
                MessageBox.Show("Your password must have more than 7 character", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!checkTextBoxesValues())
                {
                    if (textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                    {
                        if (checkUsername())
                        {
                            MessageBox.Show("This Username Already Exists", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                FORM_LOGIN user = new FORM_LOGIN();
                                this.Hide();
                                user.Show();
                            }
                            else
                            {
                                MessageBox.Show("ERROR");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                db.closeConnection();

            }
        }

        public Boolean checkUsername()
        {
            DB db = new DB();

            String username = textBoxUsername.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String email = textBoxEmail.Text;
            String address = textBoxAddress.Text;
            String phone = textBoxPhone.Text;
            String uname = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if (fname.Equals("first name") || lname.Equals("last name") || uname.Equals("username (letters and numbers)") || pass.Equals("password") || email.Equals("email") || address.Equals("address") || phone.Equals("phone"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

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

        private void textBoxPasswordConfirm_KeyPress(object sender, KeyPressEventArgs e)
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