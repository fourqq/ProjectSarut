namespace Login
{
    partial class FORM_NEW_ACCOUNT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGoToLogin = new System.Windows.Forms.Label();
            this.buttonCreateAccount = new System.Windows.Forms.Button();
            this.textBoxLastname = new System.Windows.Forms.TextBox();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPasswordConfirm = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGoToLogin
            // 
            this.labelGoToLogin.AutoSize = true;
            this.labelGoToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGoToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGoToLogin.ForeColor = System.Drawing.Color.White;
            this.labelGoToLogin.Location = new System.Drawing.Point(180, 708);
            this.labelGoToLogin.Name = "labelGoToLogin";
            this.labelGoToLogin.Size = new System.Drawing.Size(236, 18);
            this.labelGoToLogin.TabIndex = 10;
            this.labelGoToLogin.Text = "Already Have an Account? Sign Up";
            this.labelGoToLogin.Click += new System.EventHandler(this.labelGoToLogin_Click);
            this.labelGoToLogin.MouseEnter += new System.EventHandler(this.labelGoToLogin_MouseEnter);
            this.labelGoToLogin.MouseLeave += new System.EventHandler(this.labelGoToLogin_MouseLeave);
            // 
            // buttonCreateAccount
            // 
            this.buttonCreateAccount.BackColor = System.Drawing.Color.Firebrick;
            this.buttonCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateAccount.FlatAppearance.BorderSize = 0;
            this.buttonCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateAccount.Location = new System.Drawing.Point(51, 638);
            this.buttonCreateAccount.Name = "buttonCreateAccount";
            this.buttonCreateAccount.Size = new System.Drawing.Size(506, 67);
            this.buttonCreateAccount.TabIndex = 9;
            this.buttonCreateAccount.Text = "C R E A T E";
            this.buttonCreateAccount.UseVisualStyleBackColor = false;
            this.buttonCreateAccount.Click += new System.EventHandler(this.buttonCreateAccount_Click);
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastname.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxLastname.Location = new System.Drawing.Point(51, 219);
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(506, 39);
            this.textBoxLastname.TabIndex = 1;
            this.textBoxLastname.Text = "last name";
            this.textBoxLastname.Enter += new System.EventHandler(this.textBoxLastname_Enter);
            this.textBoxLastname.Leave += new System.EventHandler(this.textBoxLastname_Leave);
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstname.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxFirstname.Location = new System.Drawing.Point(51, 174);
            this.textBoxFirstname.Multiline = true;
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(506, 39);
            this.textBoxFirstname.TabIndex = 0;
            this.textBoxFirstname.Text = "first name ";
            this.textBoxFirstname.Enter += new System.EventHandler(this.textBoxFirstname_Enter);
            this.textBoxFirstname.Leave += new System.EventHandler(this.textBoxFirstname_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.labelClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 135);
            this.panel1.TabIndex = 7;
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.White;
            this.labelClose.Location = new System.Drawing.Point(577, 0);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(24, 24);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            this.labelClose.MouseEnter += new System.EventHandler(this.labelClose_MouseEnter);
            this.labelClose.MouseLeave += new System.EventHandler(this.labelClose_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 135);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREATE ACCOUNT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxUsername.Location = new System.Drawing.Point(51, 480);
            this.textBoxUsername.Multiline = true;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(506, 39);
            this.textBoxUsername.TabIndex = 6;
            this.textBoxUsername.Text = "username (letters and numbers)";
            this.textBoxUsername.Enter += new System.EventHandler(this.textBoxUsername_Enter);
            this.textBoxUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUsername_KeyPress);
            this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPassword.Location = new System.Drawing.Point(51, 525);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(506, 39);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.Text = "password";
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // textBoxPasswordConfirm
            // 
            this.textBoxPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordConfirm.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPasswordConfirm.Location = new System.Drawing.Point(51, 570);
            this.textBoxPasswordConfirm.Multiline = true;
            this.textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            this.textBoxPasswordConfirm.Size = new System.Drawing.Size(506, 39);
            this.textBoxPasswordConfirm.TabIndex = 8;
            this.textBoxPasswordConfirm.Text = "confirm Password";
            this.textBoxPasswordConfirm.Enter += new System.EventHandler(this.textBoxPasswordConfirm_Enter);
            this.textBoxPasswordConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPasswordConfirm_KeyPress);
            this.textBoxPasswordConfirm.Leave += new System.EventHandler(this.textBoxPasswordConfirm_Leave);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxEmail.Location = new System.Drawing.Point(51, 287);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(299, 39);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.Text = "email";
            this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(47, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(514, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "---";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "@hotmail.com",
            "@gmail.com",
            "@kkumail.com",
            "@yahoo.com",
            "@outlook.com",
            "@email.com"});
            this.comboBox1.Location = new System.Drawing.Point(356, 288);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 39);
            this.comboBox1.TabIndex = 3;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxPhone.Location = new System.Drawing.Point(51, 333);
            this.textBoxPhone.MaxLength = 10;
            this.textBoxPhone.Multiline = true;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(506, 39);
            this.textBoxPhone.TabIndex = 4;
            this.textBoxPhone.Text = "phone";
            this.textBoxPhone.Enter += new System.EventHandler(this.textBoxPhone_Enter);
            this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
            this.textBoxPhone.Leave += new System.EventHandler(this.textBoxPhone_Leave);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxAddress.Location = new System.Drawing.Point(51, 378);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(506, 96);
            this.textBoxAddress.TabIndex = 5;
            this.textBoxAddress.Text = "address";
            this.textBoxAddress.Enter += new System.EventHandler(this.textBoxAddress_Enter);
            this.textBoxAddress.Leave += new System.EventHandler(this.textBoxAddress_Leave);
            // 
            // FORM_NEW_ACCOUNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(601, 738);
            this.Controls.Add(this.textBoxFirstname);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPasswordConfirm);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelGoToLogin);
            this.Controls.Add(this.buttonCreateAccount);
            this.Controls.Add(this.textBoxLastname);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FORM_NEW_ACCOUNT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGoToLogin;
        private System.Windows.Forms.Button buttonCreateAccount;
        private System.Windows.Forms.TextBox textBoxLastname;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPasswordConfirm;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxAddress;
    }
}