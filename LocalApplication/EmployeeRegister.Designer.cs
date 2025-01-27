namespace LocalApplication
{
    partial class EmployeeRegister
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
            CustomerBody = new Panel();
            label19 = new Label();
            label4 = new Label();
            lblClose = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel11 = new Panel();
            label2 = new Label();
            panel8 = new Panel();
            label7 = new Label();
            panel6 = new Panel();
            errPassword = new Label();
            txtPassword = new TextBox();
            panel5 = new Panel();
            errEmail = new Label();
            txtEmailId = new TextBox();
            panel4 = new Panel();
            txtLastName = new TextBox();
            errLastName = new Label();
            panel3 = new Panel();
            errMiddleName = new Label();
            txtMiddleName = new TextBox();
            panel13 = new Panel();
            label8 = new Label();
            panel2 = new Panel();
            txtFirstName = new TextBox();
            errFirstName = new Label();
            panel14 = new Panel();
            lblEmployeeType = new Label();
            cmbEmployeeType = new ComboBox();
            panel9 = new Panel();
            label6 = new Label();
            panel10 = new Panel();
            label5 = new Label();
            panel12 = new Panel();
            label1 = new Label();
            panel15 = new Panel();
            lblManage = new Label();
            panel16 = new Panel();
            cmbManageBy = new ComboBox();
            panel7 = new Panel();
            label3 = new Label();
            chkIsActived = new CheckBox();
            lblID = new Label();
            btnSaveEmployee = new Button();
            panel1 = new Panel();
            CustomerBody.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel13.SuspendLayout();
            panel2.SuspendLayout();
            panel14.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel12.SuspendLayout();
            panel15.SuspendLayout();
            panel16.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // CustomerBody
            // 
            CustomerBody.BorderStyle = BorderStyle.FixedSingle;
            CustomerBody.Controls.Add(label19);
            CustomerBody.Controls.Add(label4);
            CustomerBody.Controls.Add(lblClose);
            CustomerBody.Controls.Add(tableLayoutPanel1);
            CustomerBody.Controls.Add(lblID);
            CustomerBody.Controls.Add(btnSaveEmployee);
            CustomerBody.Location = new Point(0, 0);
            CustomerBody.Name = "CustomerBody";
            CustomerBody.Size = new Size(557, 462);
            CustomerBody.TabIndex = 2;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(9, 13);
            label19.Name = "label19";
            label19.Size = new Size(321, 33);
            label19.TabIndex = 23;
            label19.Text = "Employee Registration";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(14, 7);
            label4.Name = "label4";
            label4.Size = new Size(0, 24);
            label4.TabIndex = 17;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(521, 13);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 16;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8917465F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.10825F));
            tableLayoutPanel1.Controls.Add(panel11, 0, 1);
            tableLayoutPanel1.Controls.Add(panel8, 0, 4);
            tableLayoutPanel1.Controls.Add(panel6, 1, 4);
            tableLayoutPanel1.Controls.Add(panel5, 1, 3);
            tableLayoutPanel1.Controls.Add(panel4, 1, 2);
            tableLayoutPanel1.Controls.Add(panel3, 1, 1);
            tableLayoutPanel1.Controls.Add(panel13, 0, 5);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel14, 1, 5);
            tableLayoutPanel1.Controls.Add(panel9, 0, 3);
            tableLayoutPanel1.Controls.Add(panel10, 0, 2);
            tableLayoutPanel1.Controls.Add(panel12, 0, 0);
            tableLayoutPanel1.Controls.Add(panel15, 0, 6);
            tableLayoutPanel1.Controls.Add(panel16, 1, 6);
            tableLayoutPanel1.Controls.Add(panel7, 0, 7);
            tableLayoutPanel1.Controls.Add(chkIsActived, 1, 7);
            tableLayoutPanel1.Location = new Point(18, 49);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.4752464F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.5247536F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(521, 370);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Controls.Add(label2);
            panel11.Location = new Point(6, 59);
            panel11.Name = "panel11";
            panel11.Size = new Size(95, 39);
            panel11.TabIndex = 14;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(10, 5);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 100;
            label2.Text = "Middle Name";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel8
            // 
            panel8.Controls.Add(label7);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(6, 206);
            panel8.Name = "panel8";
            panel8.Size = new Size(95, 40);
            panel8.TabIndex = 502;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(16, 6);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 400;
            label7.Text = "Password";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Control;
            panel6.Controls.Add(errPassword);
            panel6.Controls.Add(txtPassword);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(110, 206);
            panel6.Name = "panel6";
            panel6.Size = new Size(405, 40);
            panel6.TabIndex = 95;
            // 
            // errPassword
            // 
            errPassword.Anchor = AnchorStyles.None;
            errPassword.AutoSize = true;
            errPassword.ForeColor = Color.OrangeRed;
            errPassword.Location = new Point(4, 25);
            errPassword.Name = "errPassword";
            errPassword.Size = new Size(126, 15);
            errPassword.TabIndex = 29;
            errPassword.Text = "Please enter password.";
            errPassword.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(5, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(394, 23);
            txtPassword.TabIndex = 5;
            txtPassword.KeyDown += txtLastName_KeyDown;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Control;
            panel5.Controls.Add(errEmail);
            panel5.Controls.Add(txtEmailId);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(110, 154);
            panel5.Name = "panel5";
            panel5.Size = new Size(405, 43);
            panel5.TabIndex = 80;
            // 
            // errEmail
            // 
            errEmail.Anchor = AnchorStyles.None;
            errEmail.AutoSize = true;
            errEmail.ForeColor = Color.OrangeRed;
            errEmail.Location = new Point(3, 26);
            errEmail.Name = "errEmail";
            errEmail.Size = new Size(105, 15);
            errEmail.TabIndex = 15;
            errEmail.Text = "Please enter email.";
            errEmail.Visible = false;
            // 
            // txtEmailId
            // 
            txtEmailId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmailId.Location = new Point(5, 2);
            txtEmailId.Name = "txtEmailId";
            txtEmailId.Size = new Size(394, 23);
            txtEmailId.TabIndex = 4;
            txtEmailId.KeyDown += txtPassword_KeyDown;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(txtLastName);
            panel4.Controls.Add(errLastName);
            panel4.Location = new Point(110, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(405, 38);
            panel4.TabIndex = 75;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(5, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(394, 23);
            txtLastName.TabIndex = 3;
            txtLastName.KeyDown += txtEmailId_KeyDown;
            // 
            // errLastName
            // 
            errLastName.Anchor = AnchorStyles.None;
            errLastName.AutoSize = true;
            errLastName.ForeColor = Color.OrangeRed;
            errLastName.Location = new Point(3, 25);
            errLastName.Name = "errLastName";
            errLastName.Size = new Size(127, 15);
            errLastName.TabIndex = 15;
            errLastName.Text = "Please enter last name.";
            errLastName.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(errMiddleName);
            panel3.Controls.Add(txtMiddleName);
            panel3.Location = new Point(110, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(405, 39);
            panel3.TabIndex = 25;
            // 
            // errMiddleName
            // 
            errMiddleName.Anchor = AnchorStyles.None;
            errMiddleName.AutoSize = true;
            errMiddleName.ForeColor = Color.OrangeRed;
            errMiddleName.Location = new Point(3, 24);
            errMiddleName.Name = "errMiddleName";
            errMiddleName.Size = new Size(146, 15);
            errMiddleName.TabIndex = 14;
            errMiddleName.Text = "Please enter middle name.";
            errMiddleName.Visible = false;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMiddleName.Location = new Point(5, 1);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(394, 23);
            txtMiddleName.TabIndex = 2;
            txtMiddleName.KeyDown += txtMiddleName_KeyDown;
            // 
            // panel13
            // 
            panel13.Controls.Add(label8);
            panel13.Location = new Point(6, 255);
            panel13.Name = "panel13";
            panel13.Size = new Size(95, 34);
            panel13.TabIndex = 506;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(6, 7);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 500;
            label8.Text = "Employee Type";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(errFirstName);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(110, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(405, 44);
            panel2.TabIndex = 24;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFirstName.Location = new Point(5, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(394, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.KeyDown += txtFirstName_KeyDown;
            // 
            // errFirstName
            // 
            errFirstName.Anchor = AnchorStyles.None;
            errFirstName.AutoSize = true;
            errFirstName.ForeColor = Color.OrangeRed;
            errFirstName.Location = new Point(5, 26);
            errFirstName.Name = "errFirstName";
            errFirstName.Size = new Size(129, 15);
            errFirstName.TabIndex = 13;
            errFirstName.Text = "Please enter first name.";
            errFirstName.Visible = false;
            // 
            // panel14
            // 
            panel14.Controls.Add(lblEmployeeType);
            panel14.Controls.Add(cmbEmployeeType);
            panel14.Location = new Point(110, 255);
            panel14.Name = "panel14";
            panel14.Size = new Size(405, 34);
            panel14.TabIndex = 508;
            // 
            // lblEmployeeType
            // 
            lblEmployeeType.Anchor = AnchorStyles.None;
            lblEmployeeType.AutoSize = true;
            lblEmployeeType.ForeColor = Color.OrangeRed;
            lblEmployeeType.Location = new Point(5, 22);
            lblEmployeeType.Name = "lblEmployeeType";
            lblEmployeeType.Size = new Size(157, 15);
            lblEmployeeType.TabIndex = 508;
            lblEmployeeType.Text = "Please select employee type.";
            lblEmployeeType.Visible = false;
            // 
            // cmbEmployeeType
            // 
            cmbEmployeeType.FormattingEnabled = true;
            cmbEmployeeType.Items.AddRange(new object[] { "Select Employee Type", "Manager", "Operator" });
            cmbEmployeeType.Location = new Point(5, 3);
            cmbEmployeeType.Name = "cmbEmployeeType";
            cmbEmployeeType.Size = new Size(394, 23);
            cmbEmployeeType.TabIndex = 507;
            cmbEmployeeType.SelectedIndexChanged += cmbEmployeeType_SelectedIndexChanged;
            // 
            // panel9
            // 
            panel9.Controls.Add(label6);
            panel9.Location = new Point(6, 154);
            panel9.Name = "panel9";
            panel9.Size = new Size(95, 43);
            panel9.TabIndex = 503;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(16, 9);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 300;
            label6.Text = "EmailId";
            // 
            // panel10
            // 
            panel10.Controls.Add(label5);
            panel10.Location = new Point(6, 107);
            panel10.Name = "panel10";
            panel10.Size = new Size(95, 38);
            panel10.TabIndex = 504;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(14, 9);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 200;
            label5.Text = "Last Name";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel12
            // 
            panel12.Controls.Add(label1);
            panel12.Location = new Point(6, 6);
            panel12.Name = "panel12";
            panel12.Size = new Size(95, 44);
            panel12.TabIndex = 505;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(15, 4);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // panel15
            // 
            panel15.Controls.Add(lblManage);
            panel15.Location = new Point(6, 298);
            panel15.Name = "panel15";
            panel15.Size = new Size(95, 32);
            panel15.TabIndex = 509;
            // 
            // lblManage
            // 
            lblManage.Anchor = AnchorStyles.Top;
            lblManage.AutoSize = true;
            lblManage.Location = new Point(16, 4);
            lblManage.Name = "lblManage";
            lblManage.Size = new Size(66, 15);
            lblManage.TabIndex = 500;
            lblManage.Text = "Manage By";
            lblManage.TextAlign = ContentAlignment.TopCenter;
            lblManage.Visible = false;
            // 
            // panel16
            // 
            panel16.Controls.Add(cmbManageBy);
            panel16.Location = new Point(110, 298);
            panel16.Name = "panel16";
            panel16.Size = new Size(405, 32);
            panel16.TabIndex = 510;
            // 
            // cmbManageBy
            // 
            cmbManageBy.FormattingEnabled = true;
            cmbManageBy.Location = new Point(5, 3);
            cmbManageBy.Name = "cmbManageBy";
            cmbManageBy.Size = new Size(394, 23);
            cmbManageBy.TabIndex = 507;
            cmbManageBy.Visible = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(label3);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(6, 339);
            panel7.Name = "panel7";
            panel7.Size = new Size(95, 25);
            panel7.TabIndex = 501;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(16, 1);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 500;
            label3.Text = "Activated";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // chkIsActived
            // 
            chkIsActived.Anchor = AnchorStyles.None;
            chkIsActived.AutoSize = true;
            chkIsActived.Location = new Point(269, 342);
            chkIsActived.Name = "chkIsActived";
            chkIsActived.Size = new Size(87, 19);
            chkIsActived.TabIndex = 6;
            chkIsActived.Text = "Is Activated";
            chkIsActived.TextAlign = ContentAlignment.TopLeft;
            chkIsActived.UseVisualStyleBackColor = true;
            chkIsActived.KeyDown += chkIsActived_KeyDown;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(77, 48);
            lblID.Name = "lblID";
            lblID.Size = new Size(0, 15);
            lblID.TabIndex = 8;
            lblID.Visible = false;
            // 
            // btnSaveEmployee
            // 
            btnSaveEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveEmployee.BackColor = Color.Navy;
            btnSaveEmployee.ForeColor = SystemColors.ControlLightLight;
            btnSaveEmployee.Location = new Point(400, 425);
            btnSaveEmployee.Name = "btnSaveEmployee";
            btnSaveEmployee.Size = new Size(139, 26);
            btnSaveEmployee.TabIndex = 7;
            btnSaveEmployee.Text = "Save ";
            btnSaveEmployee.UseVisualStyleBackColor = false;
            btnSaveEmployee.Click += btnSaveEmployee_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(-5, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 10);
            panel1.TabIndex = 3;
            // 
            // EmployeeRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(557, 464);
            Controls.Add(panel1);
            Controls.Add(CustomerBody);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeRegister";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Register";
            CustomerBody.ResumeLayout(false);
            CustomerBody.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel16.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel CustomerBody;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private TextBox txtMiddleName;
        private Label label1;
        private TextBox txtFirstName;
        private Label label2;
        private CheckBox chkIsActived;
        private Button btnSaveEmployee;
        private Label lblID;
        private Label lblClose;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private TextBox txtLastName;
        private Label label6;
        private Label label7;
        private Label label19;
        private Label errFirstName;
        private Panel panel4;
        private Panel panel3;
        private Label errMiddleName;
        private Panel panel2;
        private Panel panel6;
        private Label errPassword;
        private TextBox txtPassword;
        private Panel panel5;
        private Label errEmail;
        private Label errLastName;
        private TextBox txtEmailId;
        private TextBox txt;
        private Panel panel11;
        private Panel panel8;
        private Panel panel7;
        private Panel panel9;
        private Panel panel10;
        private Panel panel12;
        private Panel panel13;
        private Label label8;
        private Panel panel14;
        private ComboBox cmbEmployeeType;
        private Label lblEmployeeType;
        private Panel panel16;
        private ComboBox cmbManageBy;
        private Panel panel15;
        private Label lblManage;
    }
}