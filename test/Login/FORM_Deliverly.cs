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
    public partial class FORM_Deliverly : Form
    {
        public string address2;
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");

        public string usernametext5;
        public FORM_Deliverly()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=csharp_users;");

            MySqlCommand cmd = new MySqlCommand("UPDATE equipment SET  status='" + "Sending" + "',address='" + address2 + "',nonpic=\"ns\" WHERE status = '" + "In cart" + "'", conn);


            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Thank you for buying !", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("We will send these item to you as soon as possible!", "Sending", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
