namespace LocalApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlLoginFrm = new Panel();
            btnMin = new Button();
            btnClose = new Button();
            pnlLogin = new Panel();
            chkAdmin = new CheckBox();
            lblPassword = new Label();
            lblUsername = new Label();
            label4 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlLoginDesign = new Panel();
            loader = new PictureBox();
            picImageIcon = new PictureBox();
            pnlLoginFrm.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlLoginDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImageIcon).BeginInit();
            SuspendLayout();
            // 
            // pnlLoginFrm
            // 
            pnlLoginFrm.Controls.Add(btnMin);
            pnlLoginFrm.Controls.Add(btnClose);
            pnlLoginFrm.Controls.Add(pnlLogin);
            pnlLoginFrm.Controls.Add(pnlLoginDesign);
            pnlLoginFrm.Dock = DockStyle.Fill;
            pnlLoginFrm.Location = new Point(0, 0);
            pnlLoginFrm.Margin = new Padding(4, 3, 4, 3);
            pnlLoginFrm.Name = "pnlLoginFrm";
            pnlLoginFrm.Size = new Size(933, 519);
            pnlLoginFrm.TabIndex = 0;
            // 
            // btnMin
            // 
            btnMin.BackColor = Color.DarkOrange;
            btnMin.Cursor = Cursors.Hand;
            btnMin.Location = new Point(855, 3);
            btnMin.Margin = new Padding(4, 3, 4, 3);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(28, 25);
            btnMin.TabIndex = 4;
            btnMin.UseVisualStyleBackColor = false;
            btnMin.Click += btnMin_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Location = new Point(890, 3);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(28, 25);
            btnClose.TabIndex = 5;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(chkAdmin);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(label4);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlLogin.Location = new Point(14, 36);
            pnlLogin.Margin = new Padding(4, 3, 4, 3);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(418, 464);
            pnlLogin.TabIndex = 1;
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            chkAdmin.Location = new Point(128, 260);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(74, 17);
            chkAdmin.TabIndex = 3;
            chkAdmin.Text = "Is Admin";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.Tomato;
            lblPassword.Location = new Point(128, 215);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(179, 13);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Please enter your password...!";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.Tomato;
            lblUsername.Location = new Point(127, 157);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(180, 13);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Please enter your username...!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Rockwell Extra Bold", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 100);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(232, 13);
            label4.TabIndex = 6;
            label4.Text = "Login with Admin and Other Users";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(127, 231);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(254, 20);
            txtPassword.TabIndex = 2;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(128, 177);
            txtUsername.Margin = new Padding(4, 3, 4, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(254, 20);
            txtUsername.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(161, 293);
            btnLogin.Margin = new Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(182, 31);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 236);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 13);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 182);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 13);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell Extra Bold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 51);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // pnlLoginDesign
            // 
            pnlLoginDesign.Controls.Add(loader);
            pnlLoginDesign.Controls.Add(picImageIcon);
            pnlLoginDesign.Dock = DockStyle.Fill;
            pnlLoginDesign.Location = new Point(0, 0);
            pnlLoginDesign.Margin = new Padding(4, 3, 4, 3);
            pnlLoginDesign.Name = "pnlLoginDesign";
            pnlLoginDesign.Size = new Size(933, 519);
            pnlLoginDesign.TabIndex = 0;
            // 
            // loader
            // 
            loader.Image = (Image)resources.GetObject("loader.Image");
            loader.Location = new Point(475, 193);
            loader.Name = "loader";
            loader.Size = new Size(149, 118);
            loader.SizeMode = PictureBoxSizeMode.StretchImage;
            loader.TabIndex = 9;
            loader.TabStop = false;
            // 
            // picImageIcon
            // 
            picImageIcon.Image = (Image)resources.GetObject("picImageIcon.Image");
            picImageIcon.Location = new Point(437, 36);
            picImageIcon.Margin = new Padding(4, 3, 4, 3);
            picImageIcon.Name = "picImageIcon";
            picImageIcon.Size = new Size(481, 464);
            picImageIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            picImageIcon.TabIndex = 6;
            picImageIcon.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(pnlLoginFrm);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JSR INFOTECH";
            pnlLoginFrm.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlLoginDesign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loader).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImageIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginFrm;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlLoginDesign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picImageIcon;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label label4;
        private Label lblPassword;
        private Label lblUsername;
        private PictureBox loader;
        private CheckBox chkAdmin;
    }
}

