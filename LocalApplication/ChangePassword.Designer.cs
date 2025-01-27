namespace LocalApplication
{
    partial class ChangePassword
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
            label1 = new Label();
            label2 = new Label();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            label3 = new Label();
            txtRepeatPassword = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            errNewPassword = new Label();
            errOldPassword = new Label();
            lblEmployeeId = new Label();
            lblOldPassword = new Label();
            btnSave = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 40);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Old Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 87);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "New Password";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(115, 36);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(274, 23);
            txtOldPassword.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(115, 84);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(274, 23);
            txtNewPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 132);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 1;
            label3.Text = "Repeat Password";
            // 
            // txtRepeatPassword
            // 
            txtRepeatPassword.Location = new Point(115, 129);
            txtRepeatPassword.Name = "txtRepeatPassword";
            txtRepeatPassword.PasswordChar = '*';
            txtRepeatPassword.Size = new Size(274, 23);
            txtRepeatPassword.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(136, 22);
            label4.Name = "label4";
            label4.Size = new Size(169, 25);
            label4.TabIndex = 5;
            label4.Text = "Change Password";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(errNewPassword);
            panel1.Controls.Add(errOldPassword);
            panel1.Controls.Add(lblEmployeeId);
            panel1.Controls.Add(lblOldPassword);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(txtNewPassword);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtRepeatPassword);
            panel1.Controls.Add(txtOldPassword);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 239);
            panel1.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(89, 36);
            label10.Name = "label10";
            label10.Size = new Size(12, 15);
            label10.TabIndex = 12;
            label10.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.Red;
            label9.Location = new Point(97, 84);
            label9.Name = "label9";
            label9.Size = new Size(12, 15);
            label9.TabIndex = 11;
            label9.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(99, 127);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 10;
            label8.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(115, 155);
            label7.Name = "label7";
            label7.Size = new Size(196, 15);
            label7.TabIndex = 9;
            label7.Text = "Please enter your repeat passoword.";
            label7.Visible = false;
            // 
            // errNewPassword
            // 
            errNewPassword.AutoSize = true;
            errNewPassword.ForeColor = Color.Red;
            errNewPassword.Location = new Point(115, 110);
            errNewPassword.Name = "errNewPassword";
            errNewPassword.Size = new Size(178, 15);
            errNewPassword.TabIndex = 8;
            errNewPassword.Text = "Please enter your new password.";
            errNewPassword.Visible = false;
            // 
            // errOldPassword
            // 
            errOldPassword.AutoSize = true;
            errOldPassword.ForeColor = Color.Red;
            errOldPassword.Location = new Point(115, 62);
            errOldPassword.Name = "errOldPassword";
            errOldPassword.Size = new Size(173, 15);
            errOldPassword.TabIndex = 7;
            errOldPassword.Text = "Please enter your old password.";
            errOldPassword.Visible = false;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Location = new Point(148, 0);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(13, 15);
            lblEmployeeId.TabIndex = 6;
            lblEmployeeId.Text = "0";
            lblEmployeeId.Visible = false;
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Location = new Point(115, 0);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(0, 15);
            lblOldPassword.TabIndex = 5;
            lblOldPassword.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.Navy;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.ControlLight;
            btnSave.Location = new Point(268, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 36);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 348);
            Controls.Add(panel1);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtOldPassword;
        private TextBox txtNewPassword;
        private Label label3;
        private TextBox txtRepeatPassword;
        private Label label4;
        private Panel panel1;
        private Button btnSave;
        private Label lblOldPassword;
        private Label lblEmployeeId;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label errNewPassword;
        private Label errOldPassword;
    }
}